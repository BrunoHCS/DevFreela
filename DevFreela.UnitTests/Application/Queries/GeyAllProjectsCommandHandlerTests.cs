using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Moq;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Application.Queries.GetAllProject;
using System.Threading;

namespace DevFreela.UnitTests.Application.Queries
{
    public class GeyAllProjectsCommandHandlerTests
    {
        [Fact]
        public async Task ThreeProjectsExist_Executed_ReturnThreeProjectViewModels()
        {
            //Arrange
            var projects = new List<Project>
            {
                new Project("Nome de Teste 1", "Descricao de Teste 1", 1, 2, 10000),
                new Project("Nome de Teste 2", "Descricao de Teste 2", 1, 2, 10000),
                new Project("Nome de Teste 3", "Descricao de Teste 3", 1, 2, 10000)
            };

            var projectRepositoryMock = new Mock<IProjectRepository>();
            projectRepositoryMock.Setup(pr => pr.GetAllAsync().Result).Returns(projects);

            var getAllProjectQuery = new GetAllProjectQuery("");
            var getAllProjectQueryHendler = new GetAllProjectQueryHandler(projectRepositoryMock.Object);

            //Act
            var projectViewModelList = await getAllProjectQueryHendler.Handle(getAllProjectQuery, new CancellationToken());

            //Assert
            Assert.NotNull(projectViewModelList);
            Assert.NotEmpty(projectViewModelList);
            Assert.Equal(projects.Count, projectViewModelList.Count);

            projectRepositoryMock.Verify(pr => pr.GetAllAsync().Result, Times.Once);
        }
    }
}
