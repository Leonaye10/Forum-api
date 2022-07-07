using forum_api_back.DataAccess.DataObjects;
using forum_api_back.Interfaces;

namespace forum_api_back.Repositories
{
    public class TopicRepository : ITopicRepository
    {
        private readonly forumdbContext context;
        public TopicRepository(forumdbContext Context)
        {
            this.context = Context;
        }


        public Topic CreateTopic(Topic topic)
        {
            this.context.Topics.Add(topic);
            this.context.SaveChanges();
            return topic;
        }

        public Topic DeleteTopic(int id)
        {
            Topic topic = this.context.Topics.FirstOrDefault(t => t.Idtopic == id);
            this.context.Topics.Remove(topic);
            this.context.SaveChanges();
            return topic;
        }

        public Topic GetTopicById(int id)
        {
            Topic topic = this.context.Topics.FirstOrDefault(t => t.Idtopic == id);
            return topic;
        }

        public List<Topic> GetAllTopics()
        {
            List<Topic> topics = this.context.Topics.ToList();
            return topics;
        }


        public Topic UpdateTopic(Topic topic)
        {
            this.context.Topics.Update(topic);
            this.context.SaveChanges();
            return topic;
        }

    }
}
