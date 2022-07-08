using Microsoft.VisualStudio.TestTools.UnitTesting;
using forum_api_back.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using forum_api_back.DataAccess.DataObjects;
using forum_api_back.Interfaces;
using Moq;
using forum_api_back.Exceptions;

namespace forum_api_back.Services.Tests
{
    [TestClass()]
    public class CommentServiceTests
    {
        private ICommentService _commentService;
        private Mock<ICommentRepository> _commentRepository;
        private List<Comment> _comments;
        private IWorldFilterService _worldFilterService;
        private ITopicService _topicService;
        

        [TestInitialize]
        public void Initialize()
        {
            this._commentRepository = new Mock<ICommentRepository>();
            this._worldFilterService = new WorldFilterService();
            this._commentService = new CommentService(this._commentRepository.Object, this._worldFilterService, _topicService);
            this._comments = new List<Comment>();

            this._comments.Add(new Comment()
            {
                Idcomment = 1,
                NomUtilisateur = "user",
                Contenu = "contenu",
                DateCreation = DateTime.Now,
                DateModification = DateTime.Now,
                TopicId = 1
            }
            );

            this._comments.Add(new Comment()
            {
                Idcomment = 2,
                NomUtilisateur = "user 2",
                Contenu = "contenu 2",
                DateCreation = DateTime.Now,
                DateModification = DateTime.Now,
                TopicId = 2
            }
            );
        }

        [TestMethod()]
        [DataRow(1)]
        [DataRow(2)]
        public void FindByIdTest_IdOk(int id)
        {
            // GIVEN
            _commentRepository.Setup(repo => repo.FindById(id)).Returns(_comments.Find(c => c.Idcomment == id));
            Comment expectedComment = _comments.Find(c => c.Idcomment == id);

            // WHEN
            Comment result = _commentService.FindById(id);

            // THEN
            Assert.AreEqual(expectedComment, result);
        }

        [TestMethod()]
        [DataRow(10)]
        public void FindByIdTest_IdpasOk(int id)
        {
            // GIVEN
            _commentRepository.Setup(repo => repo.FindById(id)).Returns(this._comments.Find(c => c.Idcomment == id));

            // WHEN
            Assert.ThrowsException<NotFoundException>(() => this._commentService.FindById(id));

            // THEN
        }

        [TestMethod()]
        public void FindAllTest_OK()
        {
            // GIVEN
            _commentRepository.Setup(repo => repo.FindAll()).Returns(this._comments);

            // WHEN
            List<Comment> results = _commentService.FindAll();

            // THEN
            Assert.AreEqual(this._comments, results);
        }

        [TestMethod()]
        public void CreateTest_paramNotNull()
        {
            // GIVEN

            Comment comment = new Comment();
            comment.Idcomment = 1;
            comment.NomUtilisateur = "user";
            comment.Contenu = "contenu";
            comment.DateCreation = new DateTime(2022);
            comment.TopicId = 1;

            Comment expectedComment = new Comment();
            expectedComment.Topic = _topicService.GetTopicById(comment.TopicId);
            _commentRepository.Setup(repo => repo.Create(comment)).Callback<Comment>(c =>
            {
                c.Idcomment = 1;
                c.NomUtilisateur = "user";
                c.Contenu = "contenu";
                c.DateCreation = new DateTime(2022);
                c.TopicId = 1;
                expectedComment = c;
            });

            // WHEN
            Comment result = _commentService.Create(comment);

            // THEN
            //Assert.AreEqual(expectedComment.Idcomment, 1);
        }

        [TestMethod()]
        public void UpdateTest_paramNotNull()
        {
            // GIVEN
            Topic topic = new Topic();
            topic.Idtopic = 1;
            topic.NomUtilisateur = "topicUser";
            topic.Titre = "Titre";

            Comment comment = new Comment();
            comment.Idcomment = 1;
            comment.Contenu = "Test";
            comment.DateCreation = DateTime.Now;
            comment.Topic = topic;

            Comment expectedComment = new Comment();
            _commentRepository.Setup(repo => repo.Update(comment)).Callback<Comment>(c =>
            {
                c.Idcomment = 1;
                c.NomUtilisateur = "user";
                c.Contenu = "contenu";
                c.DateCreation = new DateTime(2022);
                c.Topic = topic;
                expectedComment = c;
            });

            // WHEN
            Comment result = _commentService.Update(comment);

            // THEN
            Assert.AreEqual(expectedComment.Idcomment, 1);
            Assert.AreEqual(expectedComment.Topic.Idtopic, 1);
        }

        [TestMethod()]
        [DataRow(1)]
        public void DeleteTest_IdOk(int id)
        {
            // GIVEN
            _commentRepository.Setup(repo => repo.FindById(id)).Returns(this._comments[0]);
            _commentRepository.Setup(repo => repo.Delete(id));
            int expectedNbre = _comments.RemoveAll(c => c.Idcomment == id);

            // WHEN
            _commentService.Delete(id);

            // THEN_comm
            Assert.IsNotNull(expectedNbre);
        }

        [TestMethod()]
        [DataRow(5)]
        public void DeleteTest_IdpasOk(int id)
        {
            // GIVEN
            _commentRepository.Setup(repo => repo.FindById(id)).Returns(_comments.Find(c => c.Idcomment == id));
            _commentRepository.Setup(repo => repo.Delete(id));

            // WHEN
            Assert.ThrowsException<ArgumentException>(() => _commentService.Delete(id));
            // THEN
        }
    }
}