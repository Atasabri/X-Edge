using Xedge.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Xedge.Domain.Models
{
    public class Product : BaseNamedModel
    {
        [Required]
        public string Description { get; set; }
        [Required]
        public string Description_AR { get; set; }

        [Required]
        public int SubCategory_Id { get; set; }

        public string Serial_Number { get; set; }

        [Required]
        public double Price { get; set; }
        public double? OldPrice { get; set; }
        [Required]
        public int Market_Id { get; set; }
        [Required]
        public int Brand_Id { get; set; }

        public int? Offer_Id { get; set; }


        [ForeignKey(nameof(SubCategory_Id))]
        public SubCategory SubCategory { get; set; }


        [ForeignKey(nameof(Offer_Id))]
        public Offer Offer { get; set; }

        [ForeignKey(nameof(Market_Id))]
        public Market Market { get; set; }

        [ForeignKey(nameof(Brand_Id))]
        public Brand Brand { get; set; }



        public virtual ICollection<OrderDetails> OrderDetails { get; set; }

        public virtual ICollection<Favorites> Favorites { get; set; }
        public virtual ICollection<ProductImages> Images { get; set; } 
    }
}
