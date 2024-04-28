using Application.ProductFeatures.Commands;
using Application.Responses;
using AutoFixture;
using Domain.Entities;
using MovieManager.Tests;
using Persistence.Context;
using static Application.ProductFeatures.Commands.UpsertMovieCommand;
using static Application.ProductFeatures.Commands.UpsertSessionCommand;
namespace MovieManager.Test.Commands
{
    public class UpsertSessionCommandTests
    {
        private readonly DbContextDecorator<MovieManagerContext> _dbContext;
        protected readonly CancellationTokenSource _cts = new();

        public UpsertSessionCommandTests()
        {
            var options = Utilities.CreateInMemoryDbOptions<MovieManagerContext>();

            _dbContext = new DbContextDecorator<MovieManagerContext>(options);
        }

        [SetUp]
        public void Init()
        {
            var fixture = new Fixture();
            var session = fixture.Build<Session>().With(x => x.SessionId, 1).Create();
            _dbContext.AddAndSave(session);
        }

        [TearDown]
        public void Cleanup()
        {
            _dbContext.Clear();
        }

        [Test]
        public void AddsSession()
        {
            var fixture = new Fixture();

            var sessionCommand = fixture.Build<UpsertSessionCommand>()
                .With(x => x.SessionId, 2)
                .Create();

            _dbContext.Assert(async context =>
            {
                // Arrange
                var sut = CreateSut(context);

                // Act
                var result = await sut.Handle(sessionCommand, _cts.Token);

                // Assert
                Assert.That(result, Is.Not.Null);
                AssertMovieResult(sessionCommand, result);
            });
        }

        [Test]
        public void UpdatesMovie()
        {
            var fixture = new Fixture();

            var movieCommand = fixture.Build<UpsertSessionCommand>()
                .With(x => x.MovieId, 1)
                .Create();

            _dbContext.Assert(async context =>
            {
                // Arrange
                var sut = CreateSut(context);

                // Act
                var result = await sut.Handle(movieCommand, _cts.Token);

                // Assert
                Assert.That(result, Is.Not.Null);
                AssertMovieResult(movieCommand, result);
            });
        }

        private static void AssertMovieResult(UpsertSessionCommand expected, SessionResponse result)
        {
            Assert.Multiple(() =>
            {
                Assert.That(result.SessionId, Is.EqualTo(expected.SessionId));
                Assert.That(result.MovieId, Is.EqualTo(expected.MovieId));
                Assert.That(result.RoomName, Is.EqualTo(expected.RoomName));
                Assert.That(result.StartDateTime, Is.EqualTo(expected.StartDateTime));
            });
        }

        private static UpsertSessionCommandHandler CreateSut(MovieManagerContext context) => new(context);
    }
}
