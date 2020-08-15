using System.Text.RegularExpressions;

namespace Identity.Api.Services
{
    public class RedirectService : IRedirectService
    {
        public string ExtractRedirectUriFromReturnUrl(string url)
        {
            var result = string.Empty;
            var decodedUrl = System.Net.WebUtility.HtmlDecode(url);
            var results = Regex.Split(decodedUrl, "redirect_uri=");
            if (results.Length < 2)
                return string.Empty;

            result = results[1];

            var splitKey = string.Empty;
            if (result.Contains("signin-oidc"))
                splitKey = "signin-oidc";
            else
                splitKey = "scope";

            results = Regex.Split(result, splitKey);
            if (results.Length < 2)
                return string.Empty;

            result = results[0];

            return result.Replace("%3A", ":").Replace("%2F", "/").Replace("&", string.Empty);
        }
    }
}