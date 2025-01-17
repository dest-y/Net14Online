﻿using Net14Web.DbStuff.Models.InvestPort;
using System.ComponentModel.DataAnnotations.Schema;

namespace Net14Web.DbStuff.Models
{
    public class Dividend : BaseModel
    {
        public DateTime DateOfReplenishment { get; set; }
        public int TheAmountOfTheDividend { get; set; }

        public int StockId { get; set; }
        [ForeignKey("StockId")]
        public virtual Stock Stock { get; set; }


    }

}
