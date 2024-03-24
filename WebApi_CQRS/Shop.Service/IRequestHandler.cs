using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Service
{
    public interface IRequestHandler<in TRequest, TResponse>
    {
        Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken = default);
    }

    public interface IRequestHandler<TResponse>
    {
        Task<TResponse> Handle(CancellationToken cancellationToken = default);
    }
}
