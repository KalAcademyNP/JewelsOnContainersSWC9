using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductCatalogAPI.Data;

namespace ProductCatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly CatalogContext _context;
        public CatalogController(CatalogContext context)
        {
            _context = context;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Items(
            [FromQuery]int pageIndex=0, 
            [FromQuery]int pageSize = 6)
        {
            var items = await _context.Catalog
                    .OrderBy(c => c.Name)
                    .Skip(pageIndex * pageSize)
                    .Take(pageSize)
                    .ToListAsync();


        }
    }
}