using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Group7A2_API.Controllers.Models
{
    [Route("api/[controller]")]
    public class PostsController : Controller
    {
        //Db Connect
        Group7A2Context db;

        public PostsController(Group7A2Context db)
        {
            this.db = db;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Post> Get()
        {
            return db.Posts.OrderBy(p => p.Subject).ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var post = db.Posts.SingleOrDefault(p => p.PostId == id);

            if (post == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(post);
            }
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult Post([FromBody]Post post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                db.Posts.Add(post);
                db.SaveChanges();
                return CreatedAtAction("Post", new { id = post.PostId }, post);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Post post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return AcceptedAtAction("Put", new { id = post.PostId }, post);
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var post = db.Posts.SingleOrDefault(p => p.PostId == id);
            if (post == null)
            {
                return NotFound();
            }
            else
            {
                db.Posts.Remove(post);
                db.SaveChanges();
                return Ok();
            }
        }
    }
}
