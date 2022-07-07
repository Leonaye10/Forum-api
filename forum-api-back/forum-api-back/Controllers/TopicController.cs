using forum_api_back.DataAccess.DataObjects;
using forum_api_back.Services;
using forum_api_back.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using forum_api_back.Exceptions;

namespace forum_api_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        private readonly ITopicService service;
        public TopicController(ITopicService Service)
        {
            this.service = Service;
        }

        [HttpGet]
        public IActionResult GetAllTopics()
        {
            try
            {
                return Ok(this.service.GetAllTopics());
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            
        }

        [HttpGet("{id}")]
        public IActionResult GetTopicById(int id)
        {
            try
            {
                return Ok(this.service.GetTopicById(id));
            }
            catch (NotFoundException e)
            {

                return BadRequest("Invalide requête : " + e.Message);
            }
            
        }

        [HttpPost]
        public IActionResult CreateTopic(Topic topic)
        {
            try
            {
                this.service.CreateTopic(topic);
                return Ok("Création avec succès !");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPut]
        public IActionResult UpdateTopic(Topic topic)
        {
            try
            {
                this.service.UpdateTopic(topic);
                return Ok("Modification avec succès");
            }
            catch (NotFoundException e)
            {

                return BadRequest("Erreur dans l'update : " + e.Message);
            }

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTopic(int id)
        {
            try
            {
                this.service.DeleteTopic(id);
                return Ok("Supprimé avec succès");
            }
            catch (NotFoundException e)
            {
                return BadRequest("Erreur dans la suppression " + e.Message);
            }

        }




    }
}
