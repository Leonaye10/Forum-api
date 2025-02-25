﻿using forum_api_back.DataAccess.DataObjects;
using forum_api_back.Exceptions;
using forum_api_back.Interfaces;
using forum_api_back.Repositories;

namespace forum_api_back.Services
{
    public class CommentService : ICommentService
    {
        private ICommentRepository repository;
        private ITopicService topicService;
        private IWorldFilterService worldFilterService;

        public ICommentRepository Object { get; }
        public WorldFilterService WorldFilterService { get; }

        public CommentService(ICommentRepository repository, IWorldFilterService worldFilterService, ITopicService topicService)
        {
            this.repository = repository;
            this.worldFilterService = worldFilterService;
            this.topicService = topicService;
        }

        public Comment FindById(int id) 
        {
            Comment comment = this.repository.FindById(id);
            if (comment == null)
            {
                throw new NotFoundException("Pas d'objet trouvé avec cet id : " + id);
            }
            return comment;
        }

        public List<Comment> FindAll()
        {
            List<Comment> comments = this.repository.FindAll();
            if(comments == null)
            {
                throw new NotFoundException("Pas d'objet dans la base de données");
            }
            return comments;
        }

        public Comment Create(Comment comment)
        {
            if(comment == null)
            {
                throw new ArgumentException("L'objet est null");
            }

            Topic topic = this.topicService.GetTopicById(comment.TopicId);

            if (topic == null)
            {
                throw new ArgumentException("Le commentaire n'est pas lié a un topic");
            }

            comment.DateCreation = DateTime.Now;
            comment.Contenu = this.worldFilterService.ChangeInsultToStar(comment.Contenu);
            return this.repository.Create(comment);
        }

        public Comment Update(Comment comment)
        {
            if(comment == null)
            {
                throw new ArgumentException("L'objet est null");
            }

            comment.DateModification = DateTime.Now;
            comment.Contenu = this.worldFilterService.ChangeInsultToStar(comment.Contenu);
            return this.repository.Update(comment);
        }

        public void Delete(int id)
        {
            Comment comment = this.repository.FindById(id);
            if(comment == null)
            {
                throw new ArgumentException("L'objet n'existe pas");
            }
            this.repository.Delete(id);
        }
    }
}
