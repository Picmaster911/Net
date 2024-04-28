using Application.ProductFeatures.Commands;
using Application.ProductFeatures.Queires;
using Application.Responses;
using AutoFixture;
using Domain.Entities;
using MovieManager.Tests;
using Newtonsoft.Json.Linq;
using Persistence.Context;
using static Application.ProductFeatures.Commands.DeleteMovieCommand;
using static Application.ProductFeatures.Commands.UpsertMovieCommand;
using static Application.ProductFeatures.Queires.GetMoviesQuery;
namespace MovieManager.Test.Commands
{
    public class DeleteMovieCommandTests
    {
        private readonly DbContextDecorator<MovieManagerContext> _dbContext;
        protected readonly CancellationTokenSource _cts = new();

        public DeleteMovieCommandTests()
        {
            var options = Utilities.CreateInMemoryDbOptions<MovieManagerContext>();

            _dbContext = new DbContextDecorator<MovieManagerContext>(options);
        }

        [SetUp]
        public void Init()
        {

                var fixture = new Fixture();
                var movie = fixture.Build<Movie>().With(x => x.MovieId, 5).Create();
                _dbContext.AddAndSave(movie);

        }

        [TearDown]
        public void Cleanup()
        {
            _dbContext.Clear();
        }

        [Test]
        public void DeleteMovie()
        {
    
            _dbContext.Assert(async context =>
            {
                // Arrange
                var sut = CreateSut(context);

                var movieCommand = new DeleteMovieCommand { MovieId = 5 };
                // Act
                var result = await sut.Handle(movieCommand, _cts.Token);

                // Assert
                Assert.That(result, Is.True);
                var getMoviesQuery = GetMovies(context);
                var allMovies = await getMoviesQuery.Handle(new GetMoviesQuery(), _cts.Token);
                AssertMovieResult(movieCommand, allMovies);
            });
        }
        private static void AssertMovieResult(DeleteMovieCommand expected, IList<MovieResponse> result)
        {
            Assert.Multiple(() =>
            {
                Assert.That(result.Count, Is.EqualTo(0));

            });
        }

        private static DeleteMovieCommandHandler CreateSut(MovieManagerContext context) => new(context);
        private static GetMoviesQueryHandler GetMovies(MovieManagerContext context) => new(context);
    }
}
