using System;
using AutoMapper;
using DataAccess;
using Infrastructure.Interfaces.WriteModel;
using Microsoft.EntityFrameworkCore;
using Models.Domain;
using Models.DTO.RonSwansonQuote;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Write.Commands;

namespace Write.CommandHandlers
{
    public class BulkCreateRonSwansonQuoteCommandHandler : ICommandHandler<BulkCreateRonSwansonQuoteCommand, List<RonSwansonQuoteDetailDto>>
    {
        private readonly RonSwansonContext _context;
        private readonly IMapper _mapper;

        public BulkCreateRonSwansonQuoteCommandHandler(RonSwansonContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        // TODO: FINISH IT!!
        public async Task<List<RonSwansonQuoteDetailDto>> Handle(BulkCreateRonSwansonQuoteCommand command, CancellationToken token)
        {
            //Converting to Hashset gives a slight performance boost and removes any duplicates
            var quoteSet = command.InputList
                .Select(a => a.Quote)
                .ToHashSet();

            // Remove any null values (there can be at max one)
            // Maybe this should be handled with an exception instead?
            quoteSet.RemoveWhere(string.IsNullOrWhiteSpace);
            
            // Gets the last row Id currently in the database
            var lastId = await _context.RonSwansonQuotes
                .OrderBy(a => a.Id)
                .Select(a => a.Id)
                .LastOrDefaultAsync(token);

            var quoteList = new List<RonSwansonQuote>();
            
            foreach (var quote in quoteSet)
            {
                lastId += 1; 
                
                quoteList.Add(new RonSwansonQuote
                {
                    Id = lastId,
                    Quote = quote,
                    Created = DateTime.Today
                });
            }
            
            await _context.RonSwansonQuotes.AddRangeAsync(quoteList, token);

            await _context.SaveChangesAsync(token);

            return _mapper.Map<List<RonSwansonQuoteDetailDto>>(quoteList);
        }
    }
}