using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PriceProviders.Shared.Abstractions;
using PriceProviders.Shared.Models;

namespace Pricing.Consumer.Data
{
    public class InvestmentToolSeeder
    {
        public async Task SeedAsync(IRepository<InvestmentTool> repository)
        {
            string json = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "Data", "investmentTools.json"));
            var investmentTools = JsonConvert.DeserializeObject<List<InvestmentTool>>(json);

            foreach (var it in investmentTools)
            {
                switch (it.InvestmentToolType.Id)
                {
                    case 1:
                        it.Key = $"{it.Code}.RATE.GARAN";
                        break;
                    case 2:
                        it.Key = $"{it.Code}";
                        break;
                    case 5:
                        it.Key = $"{it.Code}.GOLD.GARAN";
                        break;
                }
                await repository.SaveAsync(it);
            }
        }
    }
}
