using CoreReference.Contracts.Responses;
using CoreReferenceMyData.Enteties.Enteties;
using DAL.ReferenceMyData.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreReference.Service.Commands
{

    public class PostSubscribeFilm
    {
        public int Id { get; set; }
        public string SubscribeFilmsData { get; set; }

        public SubscribeFilm CreateCategory()
        {
            var subscribeFilm = new SubscribeFilm
            {
                Id = Id,
                SubscribeFilmsData = SubscribeFilmsData,
            };
            return subscribeFilm;
        }
    }
    public class PostSubscribeFilmCommandHandler : IRequestHandler<PostSubscribeFilm, SubscribeFilmsResponse>
    {
        private readonly ReferenceConext _context;
        public PostSubscribeFilmCommandHandler(ReferenceConext context)
        {
            _context = context;
        }

        public async Task<SubscribeFilmsResponse> Handle(PostSubscribeFilm request, CancellationToken cancellationToken = default)
        {
            var subscribeFilm = request.CreateCategory();
            await _context.SubscribeFilms.AddAsync(subscribeFilm, cancellationToken);
            _context.SaveChanges();
            var lastSubscribeFilms = await GetLastCategoryesAsync();

            return new SubscribeFilmsResponse
            {
                Id = lastSubscribeFilms.Id,
                SubscribeFilms = lastSubscribeFilms.SubscribeFilmsData,
            };
        }

        public async Task<SubscribeFilm> GetLastCategoryesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SubscribeFilms.OrderByDescending(c => c.Id).FirstOrDefaultAsync();
        }
    }
}
