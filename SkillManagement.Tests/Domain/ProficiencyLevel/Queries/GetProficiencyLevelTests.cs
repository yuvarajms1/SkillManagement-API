using AutoMapper;
using Moq;
using SkillManagement.Repositary.Interfaces;
using SkillMangement.Domain.Practices.Queries;
using SkillMangement.Domain.ProficiencyLevel.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillManagement.Tests.Domain.ProficiencyLevel.Queries
{
    [TestFixture]
    public class GetProficiencyLevelTests
    {

        private readonly Mock<IProficiencyLevelRepository> _mockRepo = new Mock<IProficiencyLevelRepository>();

        private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();

        [Test]
        public void Verify_GetProficiencyLevel_Execute_Call()
        {


        // Arrange
            _mockRepo.Setup(x => x.GetAllProficiencyLevels());

            var sut = new GetProficiencyLevel(_mockMapper.Object, _mockRepo.Object);
            // Act
            sut.Execute();

            // Assert
            _mockRepo.VerifyAll();
            _mockMapper.VerifyAll();
        }
    }
}
