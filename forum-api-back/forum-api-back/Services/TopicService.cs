using forum_api_back.DataAccess.DataObjects;
using forum_api_back.Repositories;
using forum_api_back.Interfaces;

namespace forum_api_back.Services
{
    public class TopicService : ITopicService
    {

        private readonly ITopicRepository repo;
        public TopicService(ITopicRepository Repo)
        {
            repo = Repo;
        }

        public Topic CreateTopic(Topic topic)
        {
            if(topic == null)
            {
                throw new ArgumentNullException("Impossible de construire un topic null");
            }
            topic.DateCreation = DateTime.Now;
            return this.repo.CreateTopic(topic);
        }

        public List<Topic> GetAllTopics()
        {
            return this.repo.GetAllTopics();
        }

        public Topic GetTopicById(int id)
        {
            return this.repo.GetTopicById(id);
        }

        public Topic UpdateTopic(Topic topic)
        {
            topic.DateModification = DateTime.Now;
            return this.repo.UpdateTopic(topic);
        }

        public void DeleteTopic(int id)
        {
            Topic topic = this.repo.DeleteTopic(id);
            if(topic == null)
            {
                throw new Exception("Le topic a supprimé n'existe pas");
            }
        }


    }
}

