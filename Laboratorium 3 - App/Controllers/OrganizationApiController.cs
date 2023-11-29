using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorium_3___App.Controllers
{
    [Route("api/organizations")]
    [ApiController]
    public class OrganizationApiController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrganizationApiController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetByName(string? q)
        {
            return Ok(
                q == null ?
                _context.Organizations
                .Select(o => new { o.ID, o.Name })
                .ToList()
                :
                _context.Organizations
                .Where(x => x.Name.ToUpper().StartsWith(q.ToUpper()))
                .Select(o => new {o.ID, o.Name})
                .ToList()
                ) ;
        }

    }
}
