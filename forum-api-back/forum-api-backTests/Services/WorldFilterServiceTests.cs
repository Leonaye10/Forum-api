using Microsoft.VisualStudio.TestTools.UnitTesting;
using forum_api_back.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using forum_api_back.Interfaces;

namespace forum_api_back.Services.Tests
{
    [TestClass()]
    public class WorldFilterServiceTests
    {
        private IWorldFilterService _wordFilterService;
        private string insulte;

        [TestInitialize]
        public void Initialize()
        {
            this._wordFilterService = new WorldFilterService();
            this.insulte = "c*n";
        }

        [TestMethod]
        [DataRow("con")]
        public void ChangeInsultToStar_ParamsOk(string text)
        {
            var textActuel = this._wordFilterService.ChangeInsultToStar(text);

            Assert.AreEqual(textActuel, this.insulte);
        }

        [TestMethod]
        [DataRow(null)]
        public void ChangeInsultToStar_ParamsIsNull(string text)
        {
            var textActuel = this._wordFilterService.ChangeInsultToStar(text);

            Assert.IsNull(textActuel);
        }

    }
}