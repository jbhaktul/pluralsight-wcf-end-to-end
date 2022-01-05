using GeoLib.Contracts;
using GeoLib.Data;
using GeoLib.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace GeoLib.Tests
{
    [TestClass]
    public class ManagerTests
    {
        [TestMethod]
        public void test_zip_code_retrieval()
        {
            Mock<IZipCodeRepository> mockZipCodeRepository = new Mock<IZipCodeRepository>();

            ZipCode zipCode = new ZipCode()
            {
                City = "Herndon",
                State = new State() { Abbreviation = "VA" },
                Zip = "20166"
            };

            mockZipCodeRepository.Setup(obj => obj.GetByZip("20166")).Returns(zipCode);

            IGeoService geoService = new GeoManager(mockZipCodeRepository.Object);

            ZipCodeData data = geoService.GetZipInfo("20166");

            Assert.IsTrue(data.City.ToUpper() == "HERNDON");
            Assert.IsTrue(data.State == "VA");
        }
    }
}
