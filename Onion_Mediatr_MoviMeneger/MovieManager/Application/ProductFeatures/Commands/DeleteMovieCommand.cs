using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace Application.ProductFeatures.Commands
{
    public class DeleteMovieCommand : IRequest<bool>
    {
        public int MovieId { get; set; }


        public class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand, bool>
        {
            private readonly IApplicationDbContext _context;

            public DeleteMovieCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<bool> Handle(DeleteMovieCommand request, CancellationToken cancellationToken = default)
            {
                var movie = await GetMovieAsync(request.MovieId, cancellationToken);

                if (movie != null)
                {
                    _context.Remove(movie);
                    await _context.SaveChangesAsync(cancellationToken);

                    return true;
                }

                return false;
            }

            private async Task<Movie> GetMovieAsync(int movieId, CancellationToken cancellationToken = default)
            {
                return await _context.Movies.SingleOrDefaultAsync(x => x.MovieId == movieId, cancellationToken);
            }
        }
    }
}
