using Application.Interfaces;
using Application.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace Application.ProductFeatures.Queires
{
    public class GetMoviesQuery : IRequest<IList<MovieResponse>>
    {

        public class GetMoviesQueryHandler : IRequestHandler<GetMoviesQuery, IList<MovieResponse>>
        {
            private readonly IApplicationDbContext _context;

            public GetMoviesQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<IList<MovieResponse>> Handle(GetMoviesQuery req, CancellationToken cancellationToken = default)
            {
                return await _context.Movies
                    .AsNoTracking()
                    .Select(x => new MovieResponse
                    {
                        MovieId = x.MovieId,
                        Title = x.Title,
                        Description = x.Description,
                        ReleaseDate = x.ReleaseDate
                    })
                    .OrderByDescending(x => x.MovieId)
                    .ToListAsync(cancellationToken);
            }
        }
    }
}
