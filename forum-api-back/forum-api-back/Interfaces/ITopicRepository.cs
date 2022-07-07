using forum_api_back.DataAccess.DataObjects;

namespace forum_api_back.Interfaces
{
    public interface ITopicRepository
    {
        Topic CreateTopic(Topic topic);
        Topic UpdateTopic(Topic topic);
        Topic DeleteTopic(int id);
        Topic GetTopicById(int id);
        List<Topic> GetAllTopics();

    }
}
