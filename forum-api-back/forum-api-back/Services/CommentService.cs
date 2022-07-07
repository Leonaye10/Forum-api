using forum_api_back.DataAccess.DataObjects;
using forum_api_back.Interfaces;
using forum_api_back.Repositories;

namespace forum_api_back.Services
{
    public class CommentService : ICommentService
    {
        private ICommentRepository repository;

        public CommentService(ICommentRepository repository)
        {
            this.repository = repository;
        }

        public Comment FindById(int id) 
        {
            if(id <= 0)
            {
                throw new ArgumentException("Pas d'objet trouvé avec cet id : " + id);
            }
            return this.repository.FindById(id);
        }

        public List<Comment> FindAll()
        {
            List<Comment> comments = this.repository.FindAll();
            if(comments == null)
            {
                throw new ArgumentNullException("Pas d'objet dans la base de données");
            }
            return comments;
        }

        public Comment Create(Comment comment)
        {
            if(comment == null)
            {
                throw new ArgumentNullException("L'objet est null");
            }

            if(comment.TopicId == 0)
            {
                throw new ArgumentNullException("Le commentaire n'est pas lié a un topic");
            }

            comment.DateCreation = DateTime.Now;
            return this.repository.Create(comment);
        }

        public Comment Update(Comment comment)
        {
            if(comment == null)
            {
                throw new ArgumentNullException("L'objet est null");
            }

            comment.DateModification = DateTime.Now;
            return this.repository.Update(comment);
        }

        public void Delete(int id)
        {
            if(id <= 0)
            {
                throw new ArgumentNullException("id n'existe pas");
            }
            this.repository.Delete(id);
        }
    }
}
