using Identity.Api.Data;
using Identity.Api.Models;
using Identity.Api.Models.AccountViewModels;
using Identity.Api.Services;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Api.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILoginService<ApplicationUser> _loginService;
        private readonly IIdentityServerInteractionService _interaction;
        private readonly IClientStore _clientStore;
        private readonly ILogger<AccountController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;

        public AccountController(

            //InMemoryUserLoginService loginService,
            ILoginService<ApplicationUser> loginService,
            IIdentityServerInteractionService interaction,
            IClientStore clientStore,
            ILogger<AccountController> logger,
            UserManager<ApplicationUser> userManager,
            IConfiguration configuration,
            ApplicationDbContext context)
        {
            _loginService = loginService;
            _interaction = interaction;
            _clientStore = clientStore;
            _logger = logger;
            _userManager = userManager;
            _configuration = configuration;
            _context = context;
        }

        /// <summary>
        /// Show login page
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Login(string returnUrl)
        {
            var context = await _interaction.GetAuthorizationContextAsync(returnUrl).ConfigureAwait(false);
            if (context?.IdP != null)
            {
                throw new NotImplementedException("External login is not implemented!");
            }

            var vm = await BuildLoginViewModelAsync(returnUrl, context).ConfigureAwait(false);

            ViewData["ReturnUrl"] = returnUrl;

            return View(vm);
        }

        /// <summary>
        /// Handle postback from username/password login
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _loginService.FindByUsername(model.Email).ConfigureAwait(false);

                if (await _loginService.ValidateCredentials(user, model.Password).ConfigureAwait(false))
                {
                    var tokenLifetime = _configuration.GetValue("TokenLifetimeMinutes", 120);

                    var props = new AuthenticationProperties
                    {
                        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(tokenLifetime),
                        AllowRefresh = true,
                        RedirectUri = model.ReturnUrl
                    };

                    if (model.RememberMe)
                    {
                        var permanentTokenLifetime = _configuration.GetValue("PermanentTokenLifetimeDays", 365);

                        props.ExpiresUtc = DateTimeOffset.UtcNow.AddDays(permanentTokenLifetime);
                        props.IsPersistent = true;
                    }
                    ;

                    await _loginService.SignInAsync(user, props).ConfigureAwait(false);

                    // make sure the returnUrl is still valid, and if yes - redirect back to authorize endpoint
                    if (_interaction.IsValidReturnUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }

                    return Redirect("~/");
                }

                ModelState.AddModelError(string.Empty, "Invalid username or password.");
            }

            // something went wrong, show form with error
            var vm = await BuildLoginViewModelAsync(model).ConfigureAwait(false);

            ViewData["ReturnUrl"] = model.ReturnUrl;

            return View(vm);
        }

        private async Task<LoginViewModel> BuildLoginViewModelAsync(string returnUrl, AuthorizationRequest context)
        {
            if (context?.ClientId != null)
            {
                await _clientStore.FindEnabledClientByIdAsync(context.ClientId).ConfigureAwait(false);
            }

            return new LoginViewModel { ReturnUrl = returnUrl, Email = context?.LoginHint, };
        }

        private async Task<LoginViewModel> BuildLoginViewModelAsync(LoginViewModel model)
        {
            var context = await _interaction.GetAuthorizationContextAsync(model.ReturnUrl).ConfigureAwait(false);
            var vm = await BuildLoginViewModelAsync(model.ReturnUrl, context).ConfigureAwait(false);
            vm.Email = model.Email;
            vm.RememberMe = model.RememberMe;
            return vm;
        }

        /// <summary>
        /// Show logout page
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Logout(string logoutId)
        {
            if (User.Identity.IsAuthenticated == false)
            {
                // if the user is not authenticated, then just show logged out page
                return await Logout(new LogoutViewModel { LogoutId = logoutId }).ConfigureAwait(false);
            }

            //Test for Xamarin.
            var context = await _interaction.GetLogoutContextAsync(logoutId).ConfigureAwait(false);
            if (context?.ShowSignoutPrompt == false)
            {
                //it's safe to automatically sign-out
                return await Logout(new LogoutViewModel { LogoutId = logoutId }).ConfigureAwait(false);
            }

            // show the logout prompt. this prevents attacks where the user
            // is automatically signed out by another malicious web page.
            var vm = new LogoutViewModel { LogoutId = logoutId };
            return View(vm);
        }

        [Route("/connect/logout")]
        public async Task<IActionResult> TokenLogout(string redirectUrl)
        {
            await HttpContext.SignOutAsync().ConfigureAwait(false);
            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme).ConfigureAwait(false);

            UserLogin userLogin = null;
            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                var userLogins = _context.UserLogins.Where(x => x.UserId == user.Id && x.StatusId == LoginStatus.Login).ToList();

                if (userLogins.Any())
                {
                    userLogins.ForEach(x =>
                    {
                        userLogin = x;

                        userLogin.StatusId = LoginStatus.Logout;
                        userLogin.LastlastTradingTime = DateTime.Now;
                        userLogin.LogoffTime = DateTime.Now;
                    });

                    await _context.SaveChangesAsync();
                }
            }
            else
            {
                var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
                userLogin = await _context.UserLogins.FirstOrDefaultAsync(x => x.Token == token);
            }

            if (userLogin == null)
            {
                return Unauthorized();
            }

            userLogin.StatusId = LoginStatus.Logout;
            userLogin.LastlastTradingTime = DateTime.Now;
            userLogin.LogoffTime = userLogin.LastlastTradingTime;

            await _context.SaveChangesAsync();


            if (!string.IsNullOrEmpty(redirectUrl))
            {
                return Redirect(redirectUrl);
            }

            return Ok();
        }

        /// <summary>
        /// Handle logout page postback
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout(LogoutViewModel model)
        {
            var idp = User?.FindFirst(JwtClaimTypes.IdentityProvider)?.Value;

            if (idp != null && idp != IdentityServerConstants.LocalIdentityProvider)
            {
                if (model.LogoutId == null)
                {
                    // if there's no current logout context, we need to create one
                    // this captures necessary info from the current logged in user
                    // before we signout and redirect away to the external IdP for signout
                    model.LogoutId = await _interaction.CreateLogoutContextAsync().ConfigureAwait(false);
                }

                string url = "/Account/Logout?logoutId=" + model.LogoutId;

                try
                {
                    // hack: try/catch to handle social providers that throw
                    await HttpContext.SignOutAsync(idp, new AuthenticationProperties { RedirectUri = url })
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "LOGOUT ERROR: {ExceptionMessage}", ex.Message);
                }
            }

            // delete authentication cookie
            await HttpContext.SignOutAsync().ConfigureAwait(false);

            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme).ConfigureAwait(false);

            // set this so UI rendering sees an anonymous user
            HttpContext.User = new ClaimsPrincipal(new ClaimsIdentity());

            // get context information (client name, post logout redirect URI and iframe for federated signout)
            var logout = await _interaction.GetLogoutContextAsync(model.LogoutId).ConfigureAwait(false);

            return Redirect(logout?.PostLogoutRedirectUri);
        }

        public async Task<IActionResult> DeviceLogOut(string redirectUrl)
        {
            // delete authentication cookie
            await HttpContext.SignOutAsync().ConfigureAwait(false);

            // set this so UI rendering sees an anonymous user
            HttpContext.User = new ClaimsPrincipal(new ClaimsIdentity());

            return Redirect(redirectUrl);
        }

        // GET: /Account/Register
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    SurName = model.User.SurName,
                    Name = model.User.Name,
                    PhoneNumber = model.User.PhoneNumber
                };
                var result = await _userManager.CreateAsync(user, model.Password).ConfigureAwait(false);
                if (result.Errors.Any())
                {
                    AddErrors(result);
                    // If we got this far, something failed, redisplay form
                    return View(model);
                }
            }

            if (returnUrl != null)
            {
                if (HttpContext.User.Identity.IsAuthenticated)
                    return Redirect(returnUrl);
                else
                if (ModelState.IsValid)
                    return RedirectToAction("login", "account", new { returnUrl });
                else
                    return View(model);
            }

            return RedirectToAction("index", "home");
        }

        [HttpGet]
        public IActionResult Redirecting() { return View(); }

        [HttpPost]
        [Route("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromForm] ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email).ConfigureAwait(false);
                if (user == null)
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return BadRequest("Bu mail adresi ile kayıtlı bir kullanıcı bulunamadı.");
                }

                // For more information on how to enable account confirmation and password reset please
                // visit https://go.microsoft.com/fwlink/?LinkID=532713
                var code = await _userManager.GeneratePasswordResetTokenAsync(user).ConfigureAwait(false);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                //var callbackUrl = Url.Page("/Account/ResetPassword", values: new { code });

                // Sifirlama Emaili gönderilecek
                //$"Please reset your password by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>."

                return Ok($"Şifre sıfırlama linki mail adresinize gönderildi. code : {code}");
            }

            return BadRequest("Geçersiz mail adresi");
        }

        [HttpPost]
        [Route("reset-password")]
        public async Task<IActionResult> ResetPassword([FromForm] ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByEmailAsync(model.Email).ConfigureAwait(false);
            if (user == null)
            {
                return BadRequest("Geçersiz mail adresi");
            }

            var result = await _userManager.ResetPasswordAsync(user, model.Code, model.Password).ConfigureAwait(false);
            if (result.Succeeded)
            {
                return Ok("Şifreniz başarılı bir şekilde değiştirildi.");
            }

            AddErrors(result);

            return BadRequest(ModelState);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
    }
}