using System;
using System.Diagnostics;
using Autofac;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Interfaces.ReadModel;

namespace Infrastructure.ReadModel
{
    public class QueryProcessor : IQueryProcessor
    {
        private readonly IComponentContext _context;

        public QueryProcessor(IComponentContext context)
        {
            _context = context;
        }

        public Task<TResult> Process<TResult>(IQuery<TResult> query, CancellationToken token = default(CancellationToken))
        {
            // Uses reflection to call Process Internal 
            // with reflection so that the query's type 
            // and result type are retrieved at compile time
            var genericMethod = typeof(QueryProcessor)
                .GetMethod("ProcessInternal")
                .MakeGenericMethod(query.GetType(), typeof(TResult));
            
            try
            {
                var result = genericMethod.Invoke(this, new object[] { query, token });
                return (Task<TResult>)result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return null;

        }

        public Task<TResult> ProcessInternal<TQuery, TResult>(TQuery query, CancellationToken token)
            where TQuery : IQuery<TResult>
        {
            // Uses Autofac to retrieve a QueryHandler whose signature matches
            // the query type and result passed into the Process method
            var handler = _context.Resolve<IQueryHandler<TQuery, TResult>>();
        
            // Calls QueryHandler's Handle method to invoke its associated logic 
            return handler.Handle(query, token);
        }
    }
}