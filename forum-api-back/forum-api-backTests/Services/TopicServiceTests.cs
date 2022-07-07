using Microsoft.VisualStudio.TestTools.UnitTesting;
using forum_api_back.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using forum_api_back.Interfaces;
using forum_api_back.DataAccess.DataObjects;
using forum_api_back.Exceptions;

namespace forum_api_back.Services.Tests
{
    [TestClass()]
    public class TopicServiceTests
    {
        private ITopicService _topicService;
        private Mock<ITopicRepository> _topicRepository;
        private Topic expectedTopic;
        private List<Topic> _listTopics;
        private DateTime date = new DateTime(2022);


        [TestInitialize]
        public void Initialize()
        {
            this._topicRepository = new Mock<ITopicRepository>();
            this._topicService = new TopicService(this._topicRepository.Object);
            this._listTopics = new List<Topic>();
            this._listTopics.Add(new Topic()
            {
                Idtopic = 2,
                Titre = "Test2",
                NomUtilisateur = "nom de l'utilisateur2",
                DateCreation = DateTime.Now,
                DateModification = null,
                Comments = new List<Comment>()
            }
            );
            this._listTopics.Add(new Topic()
            {
                Idtopic = 3,
                Titre = "Test3",
                NomUtilisateur = "nom de l'utilisateur3",
                DateCreation = DateTime.Now,
                DateModification = null,
                Comments = new List<Comment>()
            }
            );
            this._listTopics.Add(new Topic()
            {
                Idtopic = 4,
                Titre = "Test4",
                NomUtilisateur = "nom de l'utilisateur4",
                DateCreation = DateTime.Now,
                DateModification = null,
                Comments = new List<Comment>()
            }
            );

            this.expectedTopic = new Topic()
            {
                Idtopic = 1,
                Titre = "Test",
                NomUtilisateur = "nom de l'utilisateur",
                DateCreation = DateTime.Now,
                DateModification = null,
                Comments = new List<Comment>()

            };
        }

        [TestMethod]
        [DataRow(1)]
        public void FindById_IdOk(int id)
        {
            // GIVEN
            this._topicRepository.Setup(r => r.GetTopicById(id)).Returns(this.expectedTopic);
            // WHEN
            Topic topic = this._topicService.GetTopicById(id);
            // THEN
            Assert.AreEqual(this.expectedTopic, topic);

            this._topicRepository.VerifyAll();
        }

        [TestMethod]
        [DataRow(5)]
        public void FindById_IdPasOk(int id)
        {
            // GIVEN
            this._topicRepository.Setup(r => r.GetTopicById(id)).Returns(this._listTopics.Find(t => t.Idtopic == id));
            // WHEN / THEN
            Assert.ThrowsException<NotFoundException>(() => this._topicService.GetTopicById(id));

            this._topicRepository.VerifyAll();
        }


        [TestMethod]
        public void GetAllTopics_Ok()
        {
            // GIVEN
            this._topicRepository.Setup(r => r.GetAllTopics()).Returns(this._listTopics);
            // WHEN
            var topics = _topicService.GetAllTopics();
            // THEN
            Assert.AreEqual(this._listTopics, topics);

            this._topicRepository.VerifyAll();
        }


        [TestMethod]
        public void CreateTopic_ParamsOk()
        {
            // GIVEN
            Topic sendTopic = new Topic() { Titre = "Bonjour tout le monde", NomUtilisateur = "toto" };
            Topic returnedTopic = new Topic();
            this._topicRepository.Setup(r => r.CreateTopic(sendTopic)).Callback<Topic>(top =>
            {
                top.Idtopic = 5;
                top.DateCreation = new DateTime(2022);
                returnedTopic = top;
            });

            // WHEN
            Topic topicActuel = this._topicService.CreateTopic(sendTopic);

            // THEN
            Assert.AreEqual(returnedTopic.DateCreation, date);
            Assert.AreEqual(returnedTopic.Idtopic, 5);

            this._topicRepository.VerifyAll();
        }

        [TestMethod]
        public void UpdateTopic_ParamsOk()
        {
            // GIVEN
            Topic updateTopic = new Topic() { Titre = "Bonjour tout le monde", NomUtilisateur = "toto" };
            Topic returnedTopic = new Topic();
            this._topicRepository.Setup(r => r.UpdateTopic(updateTopic)).Callback<Topic>(top =>
            {
                top.Titre = "Bonjour";
                top.DateModification = new DateTime(2023);
                returnedTopic = top;
            });

            // WHEN
            var topicActuel = this._topicService.UpdateTopic(updateTopic);

            // THEN
            Assert.AreNotEqual(returnedTopic.DateModification, date);

            this._topicRepository.VerifyAll();
        }

        [TestMethod]
        [DataRow(1)]
        public void DeleteTopic_ParamsOk(int id)
        {
            // GIVEN
            this._topicRepository.Setup(r => r.GetTopicById(id)).Returns(this.expectedTopic);
            this._topicRepository.Setup(r => r.DeleteTopic(id));
            // WHEN
            this._topicService.DeleteTopic(id);

            this._topicRepository.VerifyAll();
        }

        [TestMethod]
        [DataRow(10)]
        public void DeleteTopic_ParamsPasOk(int id)
        {
            // GIVEN
            this._topicRepository.Setup(r => r.GetTopicById(id)).Returns(this._listTopics.Find(t => t.Idtopic == id));

            // WHEN / THEN
            Assert.ThrowsException<NotFoundException>(() => this._topicService.DeleteTopic(id));

            this._topicRepository.VerifyAll();
        }





    }
}