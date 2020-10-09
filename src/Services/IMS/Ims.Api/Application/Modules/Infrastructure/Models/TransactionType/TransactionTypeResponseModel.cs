namespace Ims.Api.Application.Modules.Infrastructure.Models.TransactionType
{
    public class TransactionTypeResponseModel
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public Domain.DomainModels.DirectionType DirectionType { get; set; }
        
    }
}
