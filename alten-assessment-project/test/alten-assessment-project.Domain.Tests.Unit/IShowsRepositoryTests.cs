using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using alten_assessment_project.Domain.Entities;
using alten_assessment_project.Domain.Repositories;
using AutoFixture;
using Moq;

namespace alten_assessment_project.Domain.Tests.Unit
{
    public class IShowsRepositoryTests
    {
        private readonly Mock<IShowRepository> _showsRepository;
        private Fixture _fixture;

        public IShowsRepositoryTests()
        {
            _showsRepository = new Mock<IShowRepository>();
            _fixture = new Fixture();
        }

        [Fact]
        public void GetShowsAsync_ShouldReturnShows()
        {
            List<Show> shows = new List<Show>();
            // Arrange
            for (int i = 0; i < 10; i++)
            {
                var show = _fixture.Create<Show>();
                shows.Add(show);
            }
            _showsRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(shows);

            // Act
            var result = _showsRepository.Object.GetAllAsync().Result;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(shows.Count, result.Count());
        }
        
    }
}
