using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces.WriteModel
{
    public interface ICommandHandler<in TCommand, TResult> where TCommand : ICommand<TResult>
    {
        Task<TResult> Handle(TCommand command, CancellationToken token);
    }
}