using Microsoft.AspNetCore.Html;
using MyMarket.Business.Domain;
using MyMarket.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMarket.ViewModels
{
    public class ProductViewModel
    {
        public Product Product { get; set; }


        [Required]
        [RegularExpression(@"^[\d\.,]*$")]
        [Display(Name = "Price")]
        public double ProductPrice { get; set; }

        [Required(ErrorMessage = "Please select Currency")]
        [Display(Name = "Product Currency")]
        public Currency ProductCurrency { get; set; }

        [Required(ErrorMessage = "Please select Currency")]
        [Display(Name = "Customer Currency")]
        public Currency CustomerCurrency { get; set; }

        [Display(Name = "Customer amount")]
        [RegularExpression(@"^[\d\.,]*$")]
        public double CustomerAmount { get; set; }

        public double BalanceAmount { get; set; }

        public HtmlString Denominations { get; set; }
    }
}
