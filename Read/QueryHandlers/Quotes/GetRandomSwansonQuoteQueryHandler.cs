using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess;
using Infrastructure.Extensions;
using Infrastructure.Interfaces.ReadModel;
using Microsoft.EntityFrameworkCore;
using Models.DTO;
using Models.DTO.RonSwansonQuote;
using Read.Queries.Quotes;

namespace Read.QueryHandlers.Quotes
{
    public class GetRandomSwansonQuoteQueryHandler : IQueryHandler<GetRandomSwansonQuoteQuery, RonSwansonQuoteDetailDto>
    {
        private readonly IMapper _mapper;
        private readonly RonSwansonContext _context;
        
        public GetRandomSwansonQuoteQueryHandler(RonSwansonContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public async Task<RonSwansonQuoteDetailDto> Handle(GetRandomSwansonQuoteQuery query, CancellationToken token)
        {
            var quoteList = await _context.RonSwansonQuotes
                .AsNoTracking()
                .ToListAsync(token);
            
            // Returns a random Ron Swanson quote using custom Shuffle extension method
            var randomQuote = quoteList.Shuffle().SingleOrDefault();
            
            return _mapper.Map<RonSwansonQuoteDetailDto>(randomQuote);
        }
    }
}