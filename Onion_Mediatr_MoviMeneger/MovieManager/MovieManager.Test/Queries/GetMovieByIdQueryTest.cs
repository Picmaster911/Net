using Application.ProductFeatures.Queires;
using AutoFixture;
using Domain.Entities;
using MovieManager.Tests;
using Persistence.Context;
using static Application.ProductFeatures.Queires.GetMovieByIdQuery;

namespace MovieManager.Service.Tests.Queries
{
    public class GetMoviesByIdQueryTests
    {
        private readonly DbContextDecorator<MovieManagerContext> _dbContext;

        public GetMoviesByIdQueryTests()
        {
            var options = Utilities.CreateInMemoryDbOptions<MovieManagerContext>();

            _dbContext = new DbContextDecorator<MovieManagerContext>(options);
        }

        [Test]
        public void DataSet_ReturnsCorrectRows()
        {
            var fixture = new Fixture();
            var movie1 = fixture.Build<Movie>().With(x => x.MovieId, 1).Create();
            var movie2 = fixture.Build<Movie>().With(x => x.MovieId, 2).Create();
            _dbContext.AddAndSaveRange(new List<Movie> { movie1, movie2 });

            _dbContext.Assert(async context => {
                // Arrange
                var sut = CreateSut(context);

                // Act
                var results = await sut.Handle(new GetMovieByIdQuery() { MovieId = 2 }); ;

                // Assert
                Assert.That(results, Is.Not.Null);

                Assert.Multiple(() =>
                {
                    Assert.That(results.MovieId, Is.EqualTo(movie2.MovieId));
                    Assert.That(results.Title, Is.EqualTo(movie2.Title));
                    Assert.That(results.Description, Is.EqualTo(movie2.Description));
                    Assert.That(results.ReleaseDate, Is.EqualTo(movie2.ReleaseDate));
                });
            });
        }

        private static GetMovieByIdQueryHandler CreateSut(MovieManagerContext context) => new(context);
    }
}
