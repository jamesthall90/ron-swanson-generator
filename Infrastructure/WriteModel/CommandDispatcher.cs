using System.ComponentModel;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using Infrastructure.Interfaces.ReadModel;
using Infrastructure.Interfaces.WriteModel;

namespace Infrastructure.WriteModel
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IComponentContext _context;

        public CommandDispatcher(IComponentContext context)
        {
            _context = context;
        }
        
        ///  <inheritdoc/>
        public Task<TResult> Execute<TResult>(ICommand<TResult> command, CancellationToken token)
        {
            // Gets the MethodInfo for ExecuteInternal
            // with reflection so that the command's type 
            // and result type are retrieved at compile time
            var genericMethod = typeof(CommandDispatcher)
                .GetMethod("ExecuteInternal", BindingFlags.NonPublic | BindingFlags.Instance)
                .MakeGenericMethod(command.GetType(), typeof(TResult));
            
            // Calls ExecuteInternal generated MethodInfo  
            var result = genericMethod.Invoke(this, new object[] { command, token });
                
            return (Task<TResult>)result;
        }

        internal Task<TResult> ExecuteInternal<TCommand, TResult>(TCommand command, CancellationToken token)
            where TCommand : ICommand<TResult>
        {
            // Uses Autofac to retrieve a CommandHandler whose signature matches
            // the query type and result passed into the Execute method
            var handler = _context.Resolve<ICommandHandler<TCommand, TResult>>();
        
            // Calls CommandHandler's Handle method to invoke its associated logic 
            return handler.Handle(command, token);
        }
    }
}