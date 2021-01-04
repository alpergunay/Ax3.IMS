using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.Model;
using PriceProviders.Shared.Models;

namespace PriceProviders.Shared.Abstractions
{
    public interface IRepository<T> where T:InvestmentToolPrice
    {
        Task SavePriceAsync(T price);
        void Get();
    }
}
