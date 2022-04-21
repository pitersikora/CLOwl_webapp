using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClowlWebApp.Data;
using ClowlWebApp.Entities;

namespace ClowlWebApp.Controllers
{
    public class ContentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContentController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int categoryItemId)
        {
            Content content = await (from item in _context.Content
                                     where item.CategoryItem.Id == categoryItemId
                                     select new Content
                                     {
                                         Title = item.Title,
                                         VideoLink = item.VideoLink,
                                         HTMLContent = item.HTMLContent
                                     }).FirstOrDefaultAsync();

            var categoryId = await (from item in _context.CategoryItem
                                    where item.Id == categoryItemId
                                    select item.CategoryId).FirstOrDefaultAsync();

            List<CategoryItem> categoryItems = await (from item in _context.CategoryItem
                                                      where item.CategoryId == categoryId
                                                      select new CategoryItem
                                                      {
                                                          Id = item.Id,
                                                          Title = item.Title,
                                                          Description = item.Description,
                                                          DateTimeItemReleased = item.DateTimeItemReleased,
                                                          MediaTypeId = item.MediaTypeId,
                                                          CategoryId = categoryId
                                                      }).ToListAsync();

            ViewBag.categoryItems = categoryItems;
            return View(content);
        }
    }
}