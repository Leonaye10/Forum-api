using forum_api_back.DataAccess.DataObjects;
using forum_api_back.Interfaces;

namespace forum_api_back.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly forumdbContext context;

        public CommentRepository(forumdbContext context)
        {
            this.context = context;
        }

        public Comment FindById(int id)
        {
            return this.context.Comments.FirstOrDefault(c => c.Idcomment == id);
        }

        public List<Comment> FindAll()
        {
            return this.context.Comments.ToList();
        }

        public Comment Create(Comment comment)
        {
            this.context.Comments.Add(comment);
            this.context.SaveChanges();
            return comment;
        }

        public Comment Update(Comment comment)
        {
            this.context.Comments.Update(comment);
            this.context.SaveChanges();
            return comment;
        }

        public void Delete(int id)
        {
            Comment comment = this.FindById(id);
            this.context.Comments.Remove(comment);
            this.context.SaveChanges();
        }
    }
}
