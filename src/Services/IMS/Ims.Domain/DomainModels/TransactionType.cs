using Ax3.IMS.Domain.Types;

namespace Ims.Domain.DomainModels
{
    public class TransactionType : Entity
    {
        public string Code { get; }
        public string Description { get; }
        public int DirectionTypeId { get; }
        public DirectionType DirectionType { get; set; }

        public TransactionType(string code, string description, int directionTypeId)
        {
            Code = code;
            Description = description;
            DirectionTypeId = directionTypeId;
        }
    }
}
