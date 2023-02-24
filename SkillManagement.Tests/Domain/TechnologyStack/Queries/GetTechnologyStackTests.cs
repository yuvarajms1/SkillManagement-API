using AutoMapper;
using Moq;
using SkillManagement.Repositary.Interfaces;
using SkillMangement.Domain.Practices.Queries;
using SkillMangement.Domain.TechnologyStack.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillManagement.Tests.Domain.TechnologyStack.Queries
{
    [TestFixture]
    public class GetTechnologyStackTests
    {

        private readonly Mock<ITechnologyStackRepository> _mockRepo = new Mock<ITechnologyStackRepository>();

        private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();

        [Test]
        public void Verify_GetTechnologyStack_Execute_Call()
        {


        // Arrange
            _mockRepo.Setup(x => x.GetTechnologyByCategoryId(It.IsAny<int>()));

            var sut = new GetTechnologyStack(_mockMapper.Object, _mockRepo.Object);
            // Act
            sut.ExecuteByCategoryId(It.IsAny<int>());

            // Assert
            // Assert
            _mockRepo.VerifyAll();
            _mockMapper.VerifyAll();
        }
    }
}
