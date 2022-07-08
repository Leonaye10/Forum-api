using forum_api_back.DataAccess.DataObjects;
using forum_api_back.Repositories;
using forum_api_back.Interfaces;
using forum_api_back.Exceptions;

namespace forum_api_back.Services
{
    public class TopicService : ITopicService
    {

        private readonly ITopicRepository repo;
        private IWorldFilterService worldFilterService;
        public TopicService(ITopicRepository Repo, IWorldFilterService worldFilterService)
        {
            repo = Repo;
            this.worldFilterService = worldFilterService;
        }

        public Topic CreateTopic(Topic topic)
        {
            if(topic == null)
            {
                throw new NotFoundException("Impossible de construire un topic null");
            }
            topic.DateCreation = DateTime.Now;
            topic.Comments = new List<Comment>();
            topic.Titre = this.worldFilterService.ChangeInsultToStar(topic.Titre);
            return this.repo.CreateTopic(topic);
        }

        public List<Topic> GetAllTopics()
        {
            List<Topic> topicList = this.repo.GetAllTopics();
            if(topicList == null)
            {
                throw new NotFoundException("Aucun résultat");
            }
            return this.repo.GetAllTopics();
        }

        public Topic GetTopicById(int id)
        {
            Topic topic = this.repo.GetTopicById(id);
            if (topic == null)
            {
                throw new NotFoundException("Aucun résultat");
            }
            return topic;
        }

        public Topic UpdateTopic(Topic topic)
        {
            if( topic == null)
            {
                throw new NotFoundException("Update impossible");
            }
            topic.DateModification = DateTime.Now;
            topic.Titre = this.worldFilterService.ChangeInsultToStar(topic.Titre);
            return this.repo.UpdateTopic(topic);
        }

        public void DeleteTopic(int id)
        {
            this.GetTopicById(id);
            this.repo.DeleteTopic(id);
        }


    }
}

