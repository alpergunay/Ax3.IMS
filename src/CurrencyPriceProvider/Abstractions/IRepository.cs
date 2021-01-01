using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.Model;
using CurrencyPriceProvider.Models;

namespace CurrencyPriceProvider.Abstractions
{
    public interface IRepository
    {
        Task Put(InvestmentToolPrice price);
        void Get();
    }
}
