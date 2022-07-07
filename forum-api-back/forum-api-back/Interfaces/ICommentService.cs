using forum_api_back.DataAccess.DataObjects;

namespace forum_api_back.Interfaces
{
    public interface ICommentService
    {
        public Comment FindById(int id);
        public List<Comment> FindAll();
        public Comment Create(Comment comment);
        public Comment Update(Comment comment);
        public void Delete(int id);
    }
}
