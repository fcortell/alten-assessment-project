using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using alten_assessment_project.Application.Job;
using alten_assessment_project.Domain.Entities;
using alten_assessment_project.Domain.Repositories;
using FluentAssertions;
using FluentResults;
using Moq;
using tvmazeAPIClient.Model;

namespace alten_assessment_project.Application.Tests.Unit.Job
{
    public class SaveExternalShowsCommandHandlerTests
    {
        private readonly Mock<IShowRepository> _showsRepositoryMock;
        private readonly Mock<INetworkRepository> _networkRepositoryMock;  
        private readonly Mock<IEpisodeRepository> _episodeRepositoryMock;
        private readonly Mock<IWebChannelRepository> _webChannelRepositoryMock;
        private readonly Mock<IScheduleRepository> _scheduleRepositoryMock;
        private readonly Mock<IGenreRepository> _genreRepositoryMock;
        private readonly Mock<ICountryRepository> _countryRepositoryMock;
        private readonly Mock<ILinkRepository> _linkRepositoryMock;
        private readonly Mock<IRatingRepository> _ratingRepositoryMock;
        private readonly Mock<IImageRepository> _imageRepositoryMock;
        private readonly Mock<ISelfRepository> _selfRepositoryMock;
        private readonly Mock<IExternalRepository> _externalRepositoryMock;

        public SaveExternalShowsCommandHandlerTests()
        {
            _showsRepositoryMock = new Mock<IShowRepository>();
            _networkRepositoryMock = new Mock<INetworkRepository>();
            _episodeRepositoryMock = new Mock<IEpisodeRepository>();
            _webChannelRepositoryMock = new Mock<IWebChannelRepository>();
            _scheduleRepositoryMock = new Mock<IScheduleRepository>();
            _genreRepositoryMock = new Mock<IGenreRepository>();
            _countryRepositoryMock = new Mock<ICountryRepository>();
            _linkRepositoryMock = new Mock<ILinkRepository>();
            _ratingRepositoryMock = new Mock<IRatingRepository>();
            _imageRepositoryMock = new Mock<IImageRepository>();
            _selfRepositoryMock = new Mock<ISelfRepository>();
            _externalRepositoryMock = new Mock<IExternalRepository>();

        }

        [Fact]
        public async Task Handle_ShouldSaveShows()
        {
            // Arrange
            var shows = new List<TVMazeShow>
            {
                new TVMazeShow
                {
                    Name = "Show 1",
                    Schedule = new tvmazeAPIClient.Model.Schedule
                    {
                        Time = "20:00",
                        Days = new List<string> { "Monday", "Wednesday" }
                    }
                },
                new TVMazeShow
                {
                    Name = "Show 2",
                    Schedule = new tvmazeAPIClient.Model.Schedule
                    {
                        Time = "21:00",
                        Days = new List<string> { "Tuesday", "Wednesday" }
                    }
                }
            };

            var command = new SaveExternalShowsCommand();
            command.externalShows = shows;

            var handler = new SaveExternalShowsCommandHandler(_showsRepositoryMock.Object, _scheduleRepositoryMock.Object, 
                _countryRepositoryMock.Object, _ratingRepositoryMock.Object, _networkRepositoryMock.Object, _webChannelRepositoryMock.Object, 
                _imageRepositoryMock.Object, _externalRepositoryMock.Object, _linkRepositoryMock.Object, _selfRepositoryMock.Object, _episodeRepositoryMock.Object);
            // Conver TVMazeShow to Show
            var show1 = new Show
            {
                Name = "Show 1",
                Schedule = new Domain.Entities.Schedule
                {
                    Time = "20:00",
                    Days = "Monday, Wednesday"
                }
            };
            _showsRepositoryMock.Setup(x => x.Insert(show1));

            // Act
            Result<bool> result = await handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsFailed.Should().BeFalse();
        }
    }
}
