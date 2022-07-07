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

namespace forum_api_back.Services.Tests
{
    [TestClass()]
    public class TopicServiceTests
    {
        private ITopicService _topicService;
        private Mock<ITopicRepository> _topicRepository;
        private Topic expectedTopic;

        [TestInitialize]
        public void Initialize()
        {
            this._topicRepository = new Mock<ITopicRepository>();
            this._topicService = new TopicService(this._topicRepository.Object);

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
        public void FindById_IdOk(int id)
        {
            // GIVEN
            this._topicRepository.Setup(r => r.GetTopicById())
            // WHEN
            // THEN
        }



        [TestMethod()]
        public void TopicServiceTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CreateTopicTest()
        {
            Assert.Fail();
        }

        public void GetAllTopicsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetTopicByIdTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateTopicTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteTopicTest()
        {
            Assert.Fail();
        }
    }
}