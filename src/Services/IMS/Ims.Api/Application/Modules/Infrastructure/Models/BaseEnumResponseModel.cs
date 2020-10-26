namespace Ims.Api.Application.Modules.Infrastructure.Models
{
    public class BaseEnumResponseModel:IBaseModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
