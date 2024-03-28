using Application.Interfaces;
using Application.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace Application.ProductFeatures.Queires
{
    public class GetMovieByIdQuery : IRequest<MovieResponse>
    {
        public int MovieId { get; set; }
        public class GetMovieByIdQueryHandler : IRequestHandler<GetMovieByIdQuery, MovieResponse>
        {
            private readonly IApplicationDbContext _context;

            public GetMovieByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<MovieResponse> Handle(GetMovieByIdQuery req, CancellationToken cancellationToken = default)
            {
                return await _context.Movies
                    .AsNoTracking()
                    .Where(x => x.MovieId == req.MovieId)
                    .Select(x => new MovieResponse
                    {
                        MovieId = x.MovieId,
                        Title = x.Title,
                        Description = x.Description,
                        ReleaseDate = x.ReleaseDate
                    })
                    .SingleOrDefaultAsync(cancellationToken);
            }
        }
    }

}
