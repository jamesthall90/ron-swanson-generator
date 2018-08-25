using System.Collections.Generic;
using Infrastructure.Interfaces.WriteModel;
using Models.DTO.RonSwansonQuote;

namespace Write.Commands
{
    public class BulkCreateRonSwansonQuoteCommand : ICommand<List<RonSwansonQuoteDetailDto>>
    {
        public List<CreateRonSwansonQuoteInputDto> InputList;

        public BulkCreateRonSwansonQuoteCommand(List<CreateRonSwansonQuoteInputDto> inputList)
        {
            InputList = inputList;
        }
    }
}