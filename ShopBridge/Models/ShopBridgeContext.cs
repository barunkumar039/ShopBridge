using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopBridge.Models;

namespace ShopBridge.Models
{
    public class ShopBridgeContext : DbContext
    {
        public ShopBridgeContext(DbContextOptions<ShopBridgeContext> options) : base(options)
        {

        }
        public DbSet<ShopBridge.Models.InventoryDetails> InventoryDetails { get; set; }
    }
}
