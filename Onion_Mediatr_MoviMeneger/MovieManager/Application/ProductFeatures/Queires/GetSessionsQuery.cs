﻿using Application.Interfaces;
using Application.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.ProductFeatures.Queires
{
    public class GetSessionsQuery : IRequest<IList<SessionResponse>>
    {

        public class GetSessionsQueryHandler : IRequestHandler<GetSessionsQuery, IList<SessionResponse>>
        {
            private readonly IApplicationDbContext _context;

            public GetSessionsQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<IList<SessionResponse>> Handle(GetSessionsQuery req, CancellationToken cancellationToken = default)
            {
                return await _context.Sessions
                    .AsNoTracking()
                    .Include(x => x.Movie)
                    .Select(x => new SessionResponse
                    {
                        SessionId = x.SessionId,
                        MovieId = x.MovieId,
                        RoomName = x.RoomName,
                        StartDateTime = x.StartDateTime,
                        MovieResponse = new MovieResponse
                        {
                            MovieId = x.Movie.MovieId,
                            Title = x.Movie.Title,
                            Description = x.Movie.Description,
                            ReleaseDate = x.Movie.ReleaseDate
                        }
                    })
                    .OrderByDescending(x => x.SessionId)
                    .ToListAsync(cancellationToken);
            }
        }
    }
}
