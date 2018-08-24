using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces.ReadModel
{
    public interface IQueryProcessor
    {
        Task<TResult> Process<TResult>(IQuery<TResult> query, CancellationToken token);
    }
}