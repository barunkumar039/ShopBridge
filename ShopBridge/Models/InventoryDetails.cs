using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.Models
{
    public class InventoryDetails
    {
        [Key]
        public int InventoryId { get; set; }

        [Column(TypeName ="nvarchar(100)")]
        [Required]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(500)")]
        [Required]
        public string Discription { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        [Required]
        public decimal Price { get; set; }
    }
}
