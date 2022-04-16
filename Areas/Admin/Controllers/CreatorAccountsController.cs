using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClowlWebApp.Data;
using ClowlWebApp.Entities;
using Microsoft.AspNetCore.Authorization;
using ClowlWebApp.Models;
using Microsoft.AspNetCore.Identity;

namespace ClowlWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CreatorAccountsController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public CreatorAccountsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Admin/CreatorAccounts
        public async Task<IActionResult> Index()
        {
            List<UserRole> list = await (from userItem in _context.Users
                                         join userRoleItem in _context.UserRoles
                                         on userItem.Id equals userRoleItem.UserId
                                         into g1
                                         from userWithRole in g1.DefaultIfEmpty()
                                         join RoleItem in _context.Roles
                                         on userWithRole.RoleId equals RoleItem.Id
                                         into g2
                                         from fullTable in g2.DefaultIfEmpty()
                                         where fullTable.NormalizedName != "ADMIN"
                                         select new UserRole
                                         {
                                             UserName = userItem.UserName.ToString(),
                                             Role = fullTable.NormalizedName ?? null
                                         }).ToListAsync();

            ViewBag.UserList = list;
            return View();
        }

        [HttpPost]
        public async Task<bool> ChangeRole(UserRole userRole)
        {
            var user = await _userManager.FindByNameAsync(userRole.UserName);
            try
            {
                if (userRole.Role == "CREATOR")
                {
                    await _userManager.AddToRoleAsync(user, userRole.Role);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, "CREATOR");
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
