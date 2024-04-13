using Application.ProductFeatures.Queires;
using AutoFixture;
using Domain.Entities;
using MovieManager.Tests;
using Persistence.Context;
using static Application.ProductFeatures.Queires.GetMoviesQuery;
using static Application.ProductFeatures.Queires.GetSessionsQuery;


namespace MovieManager.Service.Tests.Queries
{
    public class GetMoviesSesionTests
    {
        private readonly DbContextDecorator<MovieManagerContext> _dbContext;

        public GetMoviesSesionTests()
        {
            var options = Utilities.CreateInMemoryDbOptions<MovieManagerContext>();

            _dbContext = new DbContextDecorator<MovieManagerContext>(options);
        }

        [Test]
        public void DataSet_ReturnsCorrectRows()
        {
            var fixture = new Fixture();
            var session1 = fixture.Build<Session>().With(x => x.SessionId, 1).Create();
            var session2 = fixture.Build<Session>().With(x => x.SessionId, 2).Create();
            _dbContext.AddAndSaveRange(new List<Session> { session1, session2 });

            _dbContext.Assert(async context => {
                // Arrange
                var sut = CreateSut(context);

                // Act
                var results = await sut.Handle(new GetSessionsQuery());

                // Assert
                Assert.That(results, Is.Not.Null);
                Assert.That(results.Count, Is.EqualTo(2));

                var firstMovie = results.Last();
                Assert.Multiple(() =>
                {
                    Assert.That(firstMovie.SessionId, Is.EqualTo(session1.SessionId));
                    Assert.That(firstMovie.MovieId, Is.EqualTo(session1.MovieId));
                    Assert.That(firstMovie.RoomName, Is.EqualTo(session1.RoomName));
                    Assert.That(firstMovie.StartDateTime, Is.EqualTo(session1.StartDateTime));
                });
            });
        }

        private static GetSessionsQueryHandler CreateSut(MovieManagerContext context) => new(context);
    }
}
