using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces.ReadModel
{
    public interface IQueryProcessor
    {
        /// <summary>
        /// Uses the input query's Type & ResultType
        /// to execute its matching Query Handler
        /// and return a result to the caller
        /// </summary>
        /// <param name="query"></param>
        /// <param name="token"></param>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        Task<TResult> Process<TResult>(IQuery<TResult> query, CancellationToken token);
    }
}