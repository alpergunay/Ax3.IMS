using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Ax3.IMS.Infrastructure.Cache.Redis;
using Newtonsoft.Json;
using PriceProviders.Shared.Abstractions;
using PriceProviders.Shared.Models;

namespace Pricing.BackgroundServices.Data
{
    public class InvestmentToolSeeder
    {
        public async Task SeedAsync(IRepository<InvestmentTool> repository, ICacheManager cacheManager, bool seedData)
        {
            if (seedData)
            {
                string json =
                    File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "Data", "investmentTools.json"));
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
                PutInvestmentToolsToCache(cacheManager, investmentTools);
            }
            else
            {
                var investmentTools = repository.GetAllAsync().Result;
                File.WriteAllText("subscribe.txt", String.Empty);
                using (var sw = new StreamWriter("subscribe.txt"))
                {
                    sw.Write("command:subscribe;{\"SUBSCRIBE\":[");

                    var investmentToolsExceptLast = investmentTools.GetRange(0, investmentTools.Count - 1);

                    foreach (var investmentTool in investmentToolsExceptLast)
                    {
                        sw.Write($"\"{investmentTool.Key}.ask\",");
                        sw.Write($"\"{investmentTool.Key}.bid\",");
                    }

                    var lastInvestmentTool = investmentTools[^1];
                    sw.Write($"\"{lastInvestmentTool.Key}.ask\",");
                    sw.Write($"\"{lastInvestmentTool.Key}.bid\"]}}");
                    sw.Flush();
                    sw.Close();
                }
                PutInvestmentToolsToCache(cacheManager, investmentTools);
            }
        }
        private void PutInvestmentToolsToCache(ICacheManager cacheManager, List<InvestmentTool> investmentTools)
        {
            foreach (var investmentTool in investmentTools)
            {
                if(!string.IsNullOrEmpty(investmentTool.Key))
                    cacheManager.Set(new CacheKey(investmentTool.Key, 43200), investmentTool);
            }
        }
    }
}
