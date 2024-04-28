using CoreReference.Contracts.Responses;
using CoreReferenceMyData.Enteties.Enteties;
using DAL.ReferenceMyData.Context;
using Microsoft.EntityFrameworkCore;

namespace CoreReference.Service.Commands
{
    public class PutSubscribeFilmCommand
    {
        public int Id { get; set; }
        public string SubscribeFilmsData { get; set; }

    }
    public class PutSubscribeFilmHandler : IRequestHandler<PutSubscribeFilmCommand, SubscribeFilmsResponse>
    {
        private readonly ReferenceConext _context;
        public PutSubscribeFilmHandler(ReferenceConext context)
        {
            _context = context;
        }

        public async Task<SubscribeFilmsResponse> Handle(PutSubscribeFilmCommand request, CancellationToken cancellationToken = default)
        {
            var subscribeFilm = await SubscribeFilm(request.Id, cancellationToken);
            if (subscribeFilm != null)
            {
                if (subscribeFilm.SubscribeFilmsData != null)
                    subscribeFilm.SubscribeFilmsData = request.SubscribeFilmsData;

                _context.SaveChanges();

            }
            return new SubscribeFilmsResponse
            {
                Id = request.Id,
                SubscribeFilms = request.SubscribeFilmsData,
            };
        }
        private async Task<SubscribeFilm> SubscribeFilm(int subscribeFilmId, CancellationToken cancellationToken = default)
        {
            return await _context.SubscribeFilms.SingleOrDefaultAsync(x => x.Id == subscribeFilmId, cancellationToken);
        }

    }
}
