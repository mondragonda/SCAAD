namespace SCAAD.APIs.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using SCAAD.APIs.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Data;
    internal sealed class Configuration : DbMigrationsConfiguration<SCAAD.APIs.Data.SCAAD_DbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SCAAD.APIs.Data.SCAAD_DbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //var manager = new UserManager<Usuario>(new UserStore<Usuario>(new SCAAD_DbContext()));

            //var user = new Usuario()
            //{
            //    UserName = "SuperPowerUser",
            //    Email = "taiseer.joudeh@mymail.com",
            //    EmailConfirmed = true,
            //    Nombre = "Taiseer",
            //    Apellido = "Joudeh",
            //    Activo = true
            //};

            //manager.Create(user, "MySuperP@ssword!");


           // var manager = new UserManager<Usuario>(new UserStore<Usuario>(new SCAAD_DbContext()));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new SCAAD_DbContext()));

            //var user = new Usuario()
            //{
            //    UserName = "SuperPowerUser",
            //    Email = "taiseer.joudeh@gmail.com",
            //    EmailConfirmed = true,
            //};

            //manager.Create(user, "MySuperP@ss!");

            //if (roleManager.Roles.Count() == 0)
            //{
                roleManager.Create(new IdentityRole { Name = SCAAD.APIs.Common.Constants.Docente });
                roleManager.Create(new IdentityRole { Name = SCAAD.APIs.Common.Constants.Admin });
                roleManager.Create(new IdentityRole { Name = SCAAD.APIs.Common.Constants.Director });


            //roleManager.Create(new IdentityRole { Name = "Admin" });
            //roleManager.Create(new IdentityRole { Name = "User" });
            //}

            //var adminUser = manager.FindByName("SuperPowerUser");

            //manager.AddToRoles(adminUser.Id, new string[] { "SuperAdmin", "Admin" });
        }
    }
    
}
