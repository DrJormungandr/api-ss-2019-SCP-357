using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testAPIcore.Models;
using testAPIcore.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace testAPIcore.Controllers
{



    [Route("api/[controller]")]
    [ApiController]
    public class EditPagesController : ControllerBase
    {
        private readonly IDbInteraction _dbi;

        public EditPagesController(IDbInteraction dbi) {
            _dbi = dbi;

        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Page>> GetPageReq(int id)
        {
            var page = await _dbi.GetPage(id);

            if (page == null)
            {
                return NotFound();
            }

            return page;
        }


        [HttpPost]
        public async Task<ActionResult<Page>> PostReq(Page page)
        {
            /*page.timestamp = DateTime.Now;
            _context.Pages.Add(page);
            await _context.SaveChangesAsync();
               */
            bool result =await _dbi.PostPage(page);
            string name = nameof(_dbi.GetPage);
            return CreatedAtAction(nameof(GetPageReq), new { id = page.id }, page);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutPage(int id, Page page)
        {
            if (id != page.id)
            {
                return BadRequest();
            }
            await _dbi.PutPage(id, page);
            /*page.timestamp = DateTime.Now;
            _context.Entry(page).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            */

            return NoContent();

        }
    
    
    // DELETE: api/EditPages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReq(int id)
        {
            bool result = await _dbi.DeletePage(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
