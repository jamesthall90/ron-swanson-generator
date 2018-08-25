using Infrastructure.Interfaces.WriteModel;
using Models.DTO.RonSwansonQuote;

namespace Write.Commands
{
    public class CreateRonSwansonQuoteCommand : ICommand<RonSwansonQuoteDetailDto>
    {
        public CreateRonSwansonQuoteInputDto Input;

        public CreateRonSwansonQuoteCommand(CreateRonSwansonQuoteInputDto input)
        {
            Input = input;
        }
    }
}