using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Traversal.API.DAL.Context;
using Traversal.API.DAL.Entities;

namespace Traversal.API.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]

    public class VisitorController : ControllerBase
    {
        [HttpGet]
        public IActionResult VisitorList()
        {
            using var context = new VisitorContext();
            var values = context.Visitors.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateVisitor(Visitor visitor)
        {
            using var context = new VisitorContext();
            context.Visitors.Add(visitor);
            context.SaveChanges();
            return Ok();
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOneVisitor(int id)
        {
            using var context = new VisitorContext();
            var visitorId = context.Visitors.Find(id);
            if (visitorId == null)
                return NotFound();
            return Ok(visitorId);
        }
    }
}
