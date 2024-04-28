using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreReference.Contracts.Responses;
using DAL.ReferenceMyData.Context;
using Microsoft.EntityFrameworkCore;


namespace CoreReference.Service.Queiries
{
    internal class GetSubscribeFilmByIdQuery : IRequestHandler<int, SubscribeFilmsResponse>
    {
        private readonly ReferenceConext _context;
        public GetSubscribeFilmByIdQuery(ReferenceConext context)
        {
            _context = context;
        }

        public async Task<SubscribeFilmsResponse> Handle(int Id, CancellationToken cancellationToken = default)
        {
            return await _context.SubscribeFilms
                .AsNoTracking()
                .Where(x => x.Id == Id)
                .Select(x => new SubscribeFilmsResponse
                {
                    Id = x.Id,
                    SubscribeFilms = x.SubscribeFilmsData,
                })
                .SingleOrDefaultAsync(cancellationToken);
        }
    }
}

