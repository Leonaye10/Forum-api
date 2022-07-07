using forum_api_back.DataAccess.DataObjects;
using forum_api_back.Interfaces;
using forum_api_back.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using forum_api_back.Exceptions;

namespace forum_api_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService service;

        public CommentController(ICommentService service)
        {
            this.service = service;
        }

        [HttpGet("{id}")]
        public IActionResult FindById(int id)
        {
            try
            {
                return Ok(this.service.FindById(id));
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet]
        public IActionResult FindAll()
        {
            try
            {
                return Ok(this.service.FindAll());
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Create(Comment comment)
        {
            try
            {
                return Created("Le commenatire a été créé", this.service.Create(comment));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public IActionResult Update(Comment comment)
        {
            try
            {
                return Ok(this.service.Create(comment));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                this.service.Delete(id);
                return Ok("Le commentaire a été supprimer");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
