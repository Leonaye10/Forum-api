using forum_api_back.DataAccess.DataObjects;
using forum_api_back.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public List<Topic> GetAllTopics()
        {
            return this.service.GetAllTopics();
        }

        [HttpGet("{id}")]
        public IActionResult GetTopicById(int id)
        {
            try
            {
                return Ok(this.service.GetTopicById(id));
            }
            catch (Exception e)
            {

                return BadRequest("Invalide requête : " + e.Message);
            }
            
        }

        [HttpPost]
        public IActionResult CreateTopic(Topic topic)
        {
            this.service.CreateTopic(topic);
            return Ok("Création avec succès !");
        }

        [HttpPut]
        public IActionResult UpdateTopic(Topic topic)
        {
            try
            {
                this.service.UpdateTopic(topic);
                return Ok("Modification avec succès");
            }
            catch (ArgumentException e)
            {

                throw new Exception("");
            }

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTopic(int id)
        {
            this.service.DeleteTopic(id);
            return Ok("Supprimé avec succès");
        }




    }
}
