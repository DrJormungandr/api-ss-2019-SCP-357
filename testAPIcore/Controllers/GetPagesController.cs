using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testAPIcore.Models;
using testAPIcore.Services;

namespace testAPIcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetPagesController : ControllerBase
    {
        private readonly IDbInteraction _dbi;
        public GetPagesController(IDbInteraction dbi)
        {
            //            _context = context;
            _dbi = dbi;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Page>>> GetAllReq()
        {
            
            return Ok(await _dbi.GetPages()); //await _context.Pages.ToListAsync();
        }

        // GET: api/pages/5
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
    }
}