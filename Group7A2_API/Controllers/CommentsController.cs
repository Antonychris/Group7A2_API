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
    public class CommentsController : Controller
    {
        //Db Connect
        Group7A2Context db;

        public CommentsController(Group7A2Context db)
        {
            this.db = db;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Comment> Get()
        {
            return db.Comments.OrderBy(c => c.Author).ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var Comment = db.Comments.SingleOrDefault(c => c.CommentId == id);
            
            if(Comment == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(Comment);
            }
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult Post([FromBody]Comment Comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                db.Comments.Add(Comment);
                db.SaveChanges();
                return CreatedAtAction("Post", new { id = Comment.CommentId }, Comment);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Comment cmt)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                db.Entry(cmt).State = EntityState.Modified;
                db.SaveChanges();
                return AcceptedAtAction("Put", new { id = cmt.CommentId }, cmt);
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var Comment = db.Comments.SingleOrDefault(c => c.CommentId == id);
            if (Comment == null)
            {
                return NotFound();
            }
            else
            {
                db.Comments.Remove(Comment);
                db.SaveChanges();
                return Ok();
            }
        }
    }
}
