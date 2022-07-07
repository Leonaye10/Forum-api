using forum_api_back.DataAccess.DataObjects;

namespace forum_api_back.Services
{
    public interface ITopicService
    {
        Topic CreateTopic(Topic topic);
        void DeleteTopic(int id);
        Topic GetTopicById(int id);
        List<Topic> GetAllTopics();
        Topic UpdateTopic(Topic topic);
    }
}
