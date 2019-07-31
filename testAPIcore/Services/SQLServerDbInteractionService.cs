using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using testAPIcore.Models;
using Microsoft.EntityFrameworkCore;


namespace testAPIcore.Services
{
    public class SQLServerDbInteractionService : IDbInteraction
    {
       private readonly PageContext _context;
        public SQLServerDbInteractionService(PageContext context)
        {
            _context = context;
            if (_context.Pages.Count() == 0)
            {
                // Create a new Page if collection is empty,
                // which means you can't delete all Pages.
                _context.Pages.Add(new Page { title = "Page1", snippet = "HelloWorld", id = 1, timestamp = DateTime.Now });
                _context.SaveChanges();
            }

        }
        public async Task<bool> PostPage(Page page)
        {
            page.timestamp = DateTime.Now;
            _context.Pages.Add(page);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> PutPage(int id, Page page)
        {
            page.timestamp = DateTime.Now;
            _context.Entry(page).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletePage(int id)
        {
            var page = await _context.Pages.FindAsync(id);

            if (page == null)
            {
                return false;
            }
            page.timestamp = DateTime.Now;
            _context.Pages.Remove(page);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Page>> GetPages()
        {
            return await _context.Pages.ToListAsync();
        }

        public async Task<Page> GetPage(int id)
        {
            var page = await _context.Pages.FindAsync(id);
            return page;

        }
    }
}
