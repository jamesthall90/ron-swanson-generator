using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces.WriteModel
{
    public interface ICommandDispatcher
    {
        /// <summary>
        /// Uses the input command's Type & ResultType
        /// to execute its matching Command Handler
        /// and return a result to the caller
        /// </summary>
        /// <param name="command"></param>
        /// <param name="token"></param>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        Task<TResult> Execute<TResult>(ICommand<TResult> command, CancellationToken token);
    }
}