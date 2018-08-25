using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess;
using Infrastructure.Interfaces.WriteModel;
using Microsoft.EntityFrameworkCore;
using Models.Domain;
using Models.DTO.RonSwansonQuote;
using Write.Commands;
using static System.DateTime;

namespace Write.CommandHandlers
{
    public class CreateRonSwansonQuoteCommandHandler : ICommandHandler<CreateRonSwansonQuoteCommand, RonSwansonQuoteDetailDto>
    {
        private readonly RonSwansonContext _context;
        private readonly IMapper _mapper;
        
        public CreateRonSwansonQuoteCommandHandler(RonSwansonContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<RonSwansonQuoteDetailDto> Handle(CreateRonSwansonQuoteCommand command, CancellationToken token)
        {
            var quoteToCreate = command.Input.Quote;
            var lastId = await _context.RonSwansonQuotes
                .OrderBy(a => a.Id)
                .Select(a => a.Id)
                .LastAsync(token);

            //TODO: Add Custom Error Handling Here
            if (string.IsNullOrWhiteSpace(quoteToCreate))
            {
                throw new Exception("Cannot create a quote from an empty string!");
            }

            var quoteDto = new RonSwansonQuote
            {
                Id = lastId + 1,
                Quote = quoteToCreate,
                Created = Today,
            };

            await _context.RonSwansonQuotes.AddAsync(quoteDto, token);

            await _context.SaveChangesAsync(token);

            return _mapper.Map<RonSwansonQuoteDetailDto>(quoteDto);
        }
    }
}