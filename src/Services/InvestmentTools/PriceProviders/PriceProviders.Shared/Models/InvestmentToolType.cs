using System;
using System.Collections.Generic;
using System.Text;
using Amazon.DynamoDBv2.DataModel;

namespace PriceProviders.Shared.Models
{
    [DynamoDBTable("InvestmentToolTypes")]
    public class InvestmentToolType
    {
        public int Id { get; set; }
        [DynamoDBProperty("code")]
        public string Code { get; set; }
        [DynamoDBProperty("name")]
        public string Name { get; set; }
    }
}
