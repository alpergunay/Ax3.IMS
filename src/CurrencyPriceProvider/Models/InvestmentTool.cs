using Amazon.DynamoDBv2.DataModel;

namespace CurrencyPriceProvider.Models
{
    [DynamoDBTable("InvestmentTool")]
    public class InvestmentTool
    {
        [DynamoDBProperty("code")]
        public string Code { get; set; }
        [DynamoDBProperty("name")]
        public string Name { get; set; }

        public InvestmentTool(string code, string name)
        {
            Code = code;
            Name = name;
        }

        public InvestmentTool()
        {
            //Parameter-less constructor is required for DynamoDB
        }
    }
}
