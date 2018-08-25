using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces.ReadModel
{
    public interface IQueryHandler<in TQuery, TResult> where TQuery : IQuery<TResult>
    {
        Task<TResult> Handle(TQuery query, CancellationToken token);
    }
}