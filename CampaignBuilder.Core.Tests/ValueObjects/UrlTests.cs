using System;
using CampaignBuilder.ValueObjects;
using CampaignBuilder.ValueObjects.Exceptions;

namespace CampaignBuilder.Core.Tests.ValueObjects
{
    [TestClass]
    public class UrlTests
    {
        private const string InvalidUrl = "wrong";
        private const string ValidUrl = "https://maxdaniel.dev";

        [TestMethod]
        [ExpectedException(typeof(InvalidUrlException))]
        public void ShouldReturnExceptionWhenUrlIsInvalid()
        {
                new Url(InvalidUrl);
                
        }

        [TestMethod]

        public void ShouldNotReturnExceptionWhenUrlIsInvalid()
        {
            new Url(ValidUrl);
            Assert.IsTrue(true);
        }
    }
}
