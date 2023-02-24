using AutoMapper;
using Castle.Core.Logging;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SkillManagement.API.Controllers;
using SkillManagement.Repositary.Interfaces;
using SkillMangement.API.Logging;
using SkillMangement.Domain.DomainInterfaces.Queries;
using SkillMangement.Domain.Practices.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using SkillMangement.API.Logging;

namespace SkillManagement.Tests.Controller
{
    [TestFixture]
    public class PracticesControllerTests
    {

        private readonly Mock<IPractices> _mockRepo = new Mock<IPractices>();

 
        private PracticesController _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new PracticesController(_mockRepo.Object);
            
        }
        
        [Test]
        public void PracticesController_Get_Success()
        {

        // Arrange
            _mockRepo.Setup(x => x.Execute());

            // Act
            var results = _sut.GetAllPractices().Result as OkObjectResult;

            // Assert
            // Assert
            Assert.IsNotNull(results);
            Assert.AreEqual(200, results?.StatusCode);
        }

        [Test]
        public void PracticesController_Get_With_Exception_500()
        {

            // Arrange
            _mockRepo.Setup(x => x.Execute()).Throws(new Exception());

            // Act
            var results = _sut.GetAllPractices().Result as StatusCodeResult;

            // Assert
            // Assert
            Assert.IsNotNull(results);
            Assert.AreEqual((int)HttpStatusCode.InternalServerError, results.StatusCode);
        }
    }
}
