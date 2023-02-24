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
    public class CategoriesControllerTests
    {

        private readonly Mock<ICategories> _mockRepo = new Mock<ICategories>();

        private CategoriesController _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new CategoriesController(_mockRepo.Object);
            
        }
        
        [Test]
        public void CategoriesController_Get_Success()
        {

            // Arrange
            _mockRepo.Setup(x => x.Execute(It.IsAny<int>()));

            // Act
            var results = _sut.GetAllCategories(It.IsAny<int>()).Result as OkObjectResult;

            // Assert
            Assert.IsNotNull(results);
            Assert.AreEqual(200, results?.StatusCode);
        }

        [Test]
        public void CategoriesController_Get_With_Exception_500()
        {

            // Arrange
            _mockRepo.Setup(x => x.Execute(It.IsAny<int>())).Throws(new Exception());

            // Act
            var results = _sut.GetAllCategories(It.IsAny<int>()).Result as StatusCodeResult;

            // Assert
            // Assert
            Assert.IsNotNull(results);
            Assert.AreEqual((int)HttpStatusCode.InternalServerError, results.StatusCode);
        }
    }
}
