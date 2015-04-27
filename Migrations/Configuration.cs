namespace Tema2_2.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Tema2_2.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<Tema2_2.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        bool AddUserAndRole(Tema2_2.Models.ApplicationDbContext context)
        {
            IdentityResult ir;
            var rm = new RoleManager<IdentityRole>
                (new RoleStore<IdentityRole>(context));
            ir = rm.Create(new IdentityRole("canEdit"));
            var um = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));
            var user = new ApplicationUser()
            {
                UserName = "user1@contoso.com",
            };
            ir = um.Create(user, "P_assw0rd1");
            if (ir.Succeeded == false)
                return ir.Succeeded;
            ir = um.AddToRole(user.Id, "canEdit");
            return ir.Succeeded;
        }

        protected override void Seed(Tema2_2.Models.ApplicationDbContext context)
        {
            AddUserAndRole(context);
            context.Products.AddOrUpdate(p => p.Name,
            new Product
            {
                Name = "LG Nexus 5",
                Quantity = 17,
                Price = 1749.99,
            },
            new Product
            {
                Name = "Samsung Galaxy S3",
                Quantity = 15,
                Price = 769.99,
            },
            new Product
            {
                Name = "Samsung Galaxy S4",
                Quantity = 25,
                Price = 1349.99,
            },
            new Product
            {
                Name = "Samsung Galaxy S5",
                Quantity = 38,
                Price = 1949.99,
            },
            new Product
            {
                Name = "Samsung Galaxy Note 4",
                Quantity = 32,
                Price = 2899.99,
            },
            new Product
            {
                Name = "Nokia Lumia 530",
                Quantity = 14,
                Price = 329.99,
            },
            new Product
            {
                Name = "Nokia Lumia 630",
                Quantity = 17,
                Price = 549.99,
            },
            new Product
            {
                Name = "Nokia Lumia 830",
                Quantity = 25,
                Price = 1599.99,
            },
            new Product
            {
                Name = "iPhone 4S",
                Quantity = 13,
                Price = 1229.99,
            },
            new Product
            {
                Name = "iPhone 5S",
                Quantity = 22,
                Price = 2399.99,
            },
            new Product
            {
                Name = "iPhone 6",
                Quantity = 34,
                Price = 3149.99,
            },
            new Product
            {
                Name = "LG G2",
                Quantity = 20,
                Price = 1399.99,
            },
            new Product
            {
                Name = "LG G3",
                Quantity = 36,
                Price = 1799.99,
            },
            new Product
            {
                Name = "HTC Desire 310",
                Quantity = 28,
                Price = 499.99,
            },
            new Product
            {
                Name = "HTC One M8",
                Quantity = 37,
                Price = 2199.99,
            }
            );
        }


        
    }
}
