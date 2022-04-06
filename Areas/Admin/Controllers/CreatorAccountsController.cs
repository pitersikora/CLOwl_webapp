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

namespace ClowlWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CreatorAccountsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CreatorAccountsController(ApplicationDbContext context)
        {
            _context = context;
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
                                            Role = (fullTable.NormalizedName != null) ? true : false
                                         }).ToListAsync();

            ViewBag.UserList = list;
            return View();
        }
    }
}
