using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project1WebApp.Models
{
    public class OrderWeb
    {

        [Required]
        [Display(Name = "locationID")]
        [Range(0, 1)]
        public int locationID { get; set; }
        [BindNever]
        public string username { get; set; }
        [BindNever]
        public DateTime ordertime { get; set; }
        [Required]
        [Display(Name = "Cheese Pizza")]
        [Range(0, 12)]
        public int cheesepizza { get; set; }
        [Required]
        [Display(Name = "Pepperoni Pizza")]
        [Range(0, 12)]
        public int pepperonipizza { get; set; }
        [Required]
        [Display(Name = "Sausage Pizza")]
        [Range(0, 12)]
        public int sausagepizza { get; set; }
        [BindNever]
        public int currentprice { get; set; }
        [BindNever]
        public int orderID { get; set; }

        

    }
}
