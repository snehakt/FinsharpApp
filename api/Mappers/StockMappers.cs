using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dto.Stock;
//using api.Helpers;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;


namespace api.Mappers
{
    public static class StockMappers
    {
        //Extension Method
        public static StockDto ToStockDto(this Stock stockModel){
            return new StockDto{
                Id=stockModel.Id,
                Symbol=stockModel.Symbol,
                CompanyName=stockModel.CompanyName,
                Purchase=stockModel.Purchase,
                LastDiv=stockModel.LastDiv,
                Industry=stockModel.Industry,
                MarketCap=stockModel.MarketCap,
                Comments= stockModel.Comments.Select(c=>c.ToCommentDto()).ToList()

            };

        }

        public static Stock ToStockFromCreateDTO(this CreateStockRequestDto stockDto){
            return new Stock{
                Symbol=stockDto.Symbol,
                CompanyName=stockDto.CompanyName,
                Purchase=stockDto.Purchase,
                LastDiv=stockDto.LastDiv,
                Industry=stockDto.Industry,
                MarketCap=stockDto.MarketCap



            };
        }
    }
}