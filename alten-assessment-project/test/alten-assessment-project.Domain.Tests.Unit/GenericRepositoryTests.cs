using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using alten_assessment_project.Domain.Entities;
using alten_assessment_project.Domain.Repositories;
using AutoFixture;
using Moq;

namespace alten_assessment_project.Domain.Tests.Unit
{
    public class GenericRepositoryTests
    {
        private readonly Mock<IShowRepository> _showMockRepository;
        private Fixture _fixture;

        public GenericRepositoryTests()
        {
            _fixture = new Fixture();
            _showMockRepository = new Mock<IShowRepository>();
        }

        [Fact()]
        public void SaveChangesAsyncTest()
        {
            // Arrange
            var testShow = _fixture.Create<Show>();
            _showMockRepository.Setup(p => p.Update(It.IsAny<Show>())).Callback(() => { return; });

            // Act

            _showMockRepository.Object.Update(testShow);
            _showMockRepository.Object.SaveChangesAsync(CancellationToken.None);

            // Assert
            _showMockRepository.Verify(d => d.SaveChangesAsync(CancellationToken.None), Times.Once());
        }

        [Fact()]
        public void DeleteTest()
        {
            // Arrange
            var testShow = _fixture.Create<Show>();
            _showMockRepository.Setup(p => p.Delete(It.IsAny<Show>())).Callback(() => { return; });

            // Act

            _showMockRepository.Object.Delete(testShow);

            // Assert
            _showMockRepository.Verify(d => d.Delete(It.IsAny<Show>()), Times.Once());
        }

        [Fact()]
        public void FindTest()
        {
            // Arrange
            var ShowList = _fixture.CreateMany<Show>(10).ToList();
            _showMockRepository.Setup(p => p.Find(It.IsAny<Expression<Func<Show, bool>>>())).ReturnsAsync(ShowList);

            // Act
            var result = _showMockRepository.Object.Find(x => x.Name == ShowList.First().Name).Result;

            // Assert
            Assert.True(ShowList.First() == result.First());
        }

        [Fact()]
        public void GetAllAsyncTest()
        {
            // Arrange
            var ShowList = _fixture.CreateMany<Show>(10).ToList();
            _showMockRepository.Setup(p => p.GetAllAsync()).ReturnsAsync(ShowList);

            // Act
            var result = _showMockRepository.Object.GetAllAsync().Result;

            // Assert
            Assert.True(ShowList.Count() == result.Count());
        }

        [Fact()]
        public void GetByIdAsyncTest()
        {
            // Arrange
            var testShow = _fixture.Create<Show>();
            _showMockRepository.Setup(p => p.GetByIdAsync(It.IsAny<long>())).ReturnsAsync(testShow);

            // Act
            var result = _showMockRepository.Object.GetByIdAsync(testShow.Id).Result;

            // Assert
            Assert.NotNull(result);
            Assert.True(testShow.Id == result.Id);
        }

        [Fact()]
        public void InsertTest()
        {
            // Arrange
            var testShow = _fixture.Create<Show>();
            _showMockRepository.Setup(p => p.Insert(It.IsAny<Show>())).Callback(() => { return; });

            // Act
            _showMockRepository.Object.Insert(testShow);

            //Assert
            _showMockRepository.Verify(d => d.Insert(It.IsAny<Show>()), Times.Once());
        }

        [Fact()]
        public void UpdateTest()
        {
            // Arrange
            var testShow = _fixture.Create<Show>();
            _showMockRepository.Setup(p => p.Update(It.IsAny<Show>())).Callback(() => { return; });

            // Act

            _showMockRepository.Object.Update(testShow);

            // Assert
            _showMockRepository.Verify(d => d.Update(It.IsAny<Show>()), Times.Once());
        }
    }
}
