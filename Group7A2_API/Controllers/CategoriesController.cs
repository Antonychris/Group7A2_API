using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Group7A2_API.Controllers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Group7A2_API.Controllers
{
    [Route("api/[controller]")]
    public class CategoriesController : Controller
    {
        //Db Connect
        Group7A2Context db;

        public CategoriesController(Group7A2Context db)
        {
            this.db = db;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return db.Categories.OrderBy(c => c.Name).ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var category = db.Categories.SingleOrDefault(c => c.CategoryId == id);
            
            if(category == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(category);
            }
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult Post([FromBody]Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return CreatedAtAction("Post", new { id = category.CategoryId }, category);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return AcceptedAtAction("Put", new { id = category.CategoryId }, category);
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var category = db.Categories.SingleOrDefault(c => c.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }
            else
            {
                db.Categories.Remove(category);
                db.SaveChanges();
                return Ok();
            }
        }
    }
}
