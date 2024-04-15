using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Logic
{
    public class RoleActions
    {
        internal void AddUserAndRole()
        {

            Models.ApplicationDbContext context = new ApplicationDbContext();
            IdentityResult IdRoleResult;
            IdentityResult IdUserResult;

            var uloge = new RoleStore<IdentityRole>(context);

            var ulogeMgr = new RoleManager<IdentityRole>(uloge);

            if (!ulogeMgr.RoleExists("canEdit"))
            {
                IdRoleResult = ulogeMgr.Create(new IdentityRole { Name = "canEdit" });
            }
            var korisnikMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var appKorisnik = new ApplicationUser
            {
                UserName = "admin123@part.com",
                Email = "admin123@part.com"
            };
            IdUserResult = korisnikMgr.Create(appKorisnik, "Partizan01!");

            if (!korisnikMgr.IsInRole(korisnikMgr.FindByEmail("admin123@part.com").Id, "canEdit"))
            {
                IdUserResult = korisnikMgr.AddToRole(korisnikMgr.FindByEmail("admin123@part.com").Id, "canEdit");
            }
        }
    }
}