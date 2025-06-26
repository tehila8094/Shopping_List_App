using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace Entities
{
    public class ShoppingListDbContextFactory : IDesignTimeDbContextFactory<ShoppingListDB>
    {
        public ShoppingListDB CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ShoppingListDB>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ShoppingListDB;Trusted_Connection=True;TrustServerCertificate=True");

            return new ShoppingListDB(optionsBuilder.Options);
        }
    }
}

