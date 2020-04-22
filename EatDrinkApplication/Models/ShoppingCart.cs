using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EatDrinkApplication.Models
{
    public class ShoppingCart
    {
        public int ShoppingCartId { get; set; }
        public string Items { get; set; }

        [ForeignKey("HomeCook")]
        public int HomeCookId { get; set; }
        public HomeCook HomeCook { get; set; }
    }
}
