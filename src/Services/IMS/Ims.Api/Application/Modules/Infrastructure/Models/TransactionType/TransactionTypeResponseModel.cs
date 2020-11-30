namespace Ims.Api.Application.Modules.Infrastructure.Models.TransactionType
{
    public class TransactionTypeResponseModel:BaseEnumResponseModel
    {
        public int DirectionTypeId { get; set; }
        public Domain.DomainModels.DirectionType DirectionType { get; set; }
    }
}
