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
    public class SkillMatrixControllerTests
    {

        private readonly Mock<ISkillMatrix> _mockRepo = new Mock<ISkillMatrix>();
        private readonly Mock<ICreateSkillMatrix> _mockCreateSkill = new Mock<ICreateSkillMatrix>();
        private readonly Mock<IUpdateSkillMatrix> _mockUpdateSkill = new Mock<IUpdateSkillMatrix>();

        private SkillsMatrixController _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new SkillsMatrixController(_mockRepo.Object, _mockCreateSkill.Object, _mockUpdateSkill.Object);
            
        }
        
        [Test]
        public void SkillMatrixController_Get_Success()
        {

            // Arrange
            _mockRepo.Setup(x => x.Execute("Angular"));

            // Act
            var results = _sut.GetTechnologySkillMatrix("Angular").Result as OkObjectResult;

            // Assert
            Assert.IsNotNull(results);
            Assert.AreEqual(200, results?.StatusCode);
        }

        [Test]
        public void SkillMatrixController_Get_With_Exception_500()
        {

            // Arrange
            _mockRepo.Setup(x => x.Execute("Angular")).Throws(new Exception());

            // Act
            var results = _sut.GetTechnologySkillMatrix("Angular").Result as StatusCodeResult;

            // Assert
            Assert.IsNotNull(results);
            Assert.AreEqual((int)HttpStatusCode.InternalServerError, results.StatusCode);
        }

        [Test]
        public void SkillMatrixController_CreateSkillMatrix_Success()
        {
            List<Contracts.Dto.SkillsMatrix.SkillsMatrixDto> lstSkillsMatrix = new List<Contracts.Dto.SkillsMatrix.SkillsMatrixDto>();
            Contracts.Dto.SkillsMatrix.SkillsMatrixDto skillmatrix = new Contracts.Dto.SkillsMatrix.SkillsMatrixDto();
            lstSkillsMatrix.Add(skillmatrix);

            // Arrange
            _mockCreateSkill.Setup(x => x.Execute(lstSkillsMatrix));

            // Act
            var results = _sut.CreateSkillsMatrixOnSearch(lstSkillsMatrix).Result as NoContentResult;

            // Assert
            Assert.IsNotNull(results);
            Assert.AreEqual(204, results?.StatusCode);
        }

        [Test]
        public void SkillMatrixController_UpdateSkillMatrix_Success()
        {
            List<Contracts.Dto.TechnologyStack.TechnologyStackDto> lstSkillsMatrix = new List<Contracts.Dto.TechnologyStack.TechnologyStackDto>();
            Contracts.Dto.TechnologyStack.TechnologyStackDto skillmatrix = new Contracts.Dto.TechnologyStack.TechnologyStackDto();
            lstSkillsMatrix.Add(skillmatrix);

            // Arrange
            _mockUpdateSkill.Setup(x => x.Execute(lstSkillsMatrix));

            // Act
            var results = _sut.UpdateSkillsMatrix(lstSkillsMatrix).Result as NoContentResult;

            // Assert
            Assert.IsNotNull(results);
            Assert.AreEqual(204, results?.StatusCode);
        }
    }
}
