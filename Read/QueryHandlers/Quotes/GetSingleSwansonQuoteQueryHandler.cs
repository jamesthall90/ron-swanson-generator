using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess;
using Infrastructure.Interfaces.ReadModel;
using Microsoft.EntityFrameworkCore;
using Models.Domain;
using Models.DTO;
using Read.Queries.Quotes;

namespace Read.QueryHandlers.Quotes
{
    public class GetSingleSwansonQuoteQueryHandler : IQueryHandler<GetSingleSwansonQuoteQuery, RonSwansonQuoteDetailDto>
    {
        private readonly RonSwansonContext _context;
        private readonly IMapper _mapper;
        
        public GetSingleSwansonQuoteQueryHandler(RonSwansonContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<RonSwansonQuoteDetailDto> Handle(GetSingleSwansonQuoteQuery query, CancellationToken token)
        {
            var quote = await _context.RonSwansonQuotes
                .Where(a => a.Id == query.Input)
                .AsNoTracking()
                .FirstOrDefaultAsync(token);

            return _mapper.Map<RonSwansonQuoteDetailDto>(quote ?? new RonSwansonQuote());
        }
    }
}