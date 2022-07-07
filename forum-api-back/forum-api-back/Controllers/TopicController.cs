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
        private readonly TopicService service;
        public TopicController(TopicService Service)
        {
            this.service = Service;
        }

        [HttpGet]
        public List<Topic> GetAllTopic()
        {
            return this.service.GetAllTopic();
        }

        [HttpGet("{id}")]
        public Topic GetTopicId(int id)
        {
            return this.service.GetTopicId(id);
        }

        [HttpPost]
        public IActionResult Create(Topic topic)
        {
            this.service.Create(topic);
            return Ok("Création avec succès !");
        }

        [HttpPut]
        public IActionResult UpdateTopic(Topic topic)
        {
            this.service.UpdateTopic(topic);
            return Ok("Modification avec succès");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            this.service.Delete(id);
            return Ok("Supprimé avec succès");
        }




    }
}
