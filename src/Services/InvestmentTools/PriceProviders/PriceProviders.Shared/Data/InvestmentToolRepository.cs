using System;
using System.Collections.Generic;
using System.Text;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Microsoft.Extensions.Logging;
using PriceProviders.Shared.Models;

namespace PriceProviders.Shared.Data
{
    public class InvestmentToolRepository : Repository<InvestmentTool>
    {
        public InvestmentToolRepository(IAmazonDynamoDB dynamoDb, IDynamoDBContext context, ILogger<InvestmentTool> logger) : base(dynamoDb, context, logger)
        {
        }
    }
}
