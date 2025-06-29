using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Interfaces;
using api.Models;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using api.Dto.Stock;
using Newtonsoft.Json;
using api.Mappers;

namespace api.Service
{
    public class FMPService : IFMPService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;

        public FMPService(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
        }
        public async Task<Stock> FindStockBySymbolAsync(string symbol){
            try{
                var result = await _httpClient.GetAsync($"https://financialmodelingprep.com/stable/profile?symbol={symbol}&apikey={_config["FMPKey"]}");
                
                if(result.IsSuccessStatusCode){
                    var content = await result.Content.ReadAsStringAsync();
                    var tasks = JsonConvert.DeserializeObject<FMPStock[]>(content);
                    var stock= tasks[0];
                    if(stock != null){
                        return stock.ToStockFromFMP();
                    }
                    return null;

                }
                return null;
            }catch(Exception e){
                Console.WriteLine(e);
                return null;
            }
        }
    }
}