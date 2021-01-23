using Amazon.DynamoDBv2.DataModel;
using PriceProviders.Shared.Abstractions;

namespace PriceProviders.Shared.Models
{
    [DynamoDBTable("InvestmentTools")]
    public class InvestmentTool : IEntity
    {
        [DynamoDBProperty("id")] 
        public string Id { get; set; }
        [DynamoDBProperty("code")]
        public string Code { get; set; }
        [DynamoDBProperty("name")]
        public string Name { get; set; }
        [DynamoDBProperty("key")]
        public string Key { get; set; }

        public InvestmentToolType InvestmentToolType { get; set; }

        public InvestmentTool(string code, string name, string key)
        {
            Code = code;
            Name = name;
            Key = key;
        }

        public InvestmentTool()
        {
            //Parameter-less constructor is required for DynamoDB
        }
    }
}
