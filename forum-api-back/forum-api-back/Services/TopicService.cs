using forum_api_back.DataAccess.DataObjects;
using forum_api_back.Repositories;

namespace forum_api_back.Services
{
    public class TopicService
    {

        private readonly TopicRepository repo;
        public TopicService(TopicRepository Repo)
        {
            repo = Repo;
        }

        public Topic Create(Topic topic)
        {
            if(topic == null)
            {
                throw new ArgumentNullException("Impossible de construire un topic null");
            }
            topic.DateCreation = DateTime.Now;
            return this.repo.Create(topic);
        }

        public List<Topic> GetAllTopic()
        {
            return this.repo.GetAllTopic();
        }

        public Topic GetTopicId(int id)
        {
            return this.repo.GetTopicId(id);
        }

        public Topic UpdateTopic(Topic topic)
        {
            topic.DateModification = DateTime.Now;
            return this.repo.UpdateTopic(topic);
        }

        public void Delete(int id)
        {
            Topic topic = this.repo.Delete(id);
            if(topic == null)
            {
                throw new Exception("Le topic a supprimé n'existe pas");
            }
        }


    }
}

