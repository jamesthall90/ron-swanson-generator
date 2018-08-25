using Infrastructure.Interfaces.ReadModel;
using Models.DTO;
using Models.DTO.RonSwansonQuote;

namespace Read.Queries.Quotes
{
    public class GetSingleSwansonQuoteQuery : IQuery<RonSwansonQuoteDetailDto>
    {
        public int Input;

        public GetSingleSwansonQuoteQuery(int input)
        {
            Input = input;
        }
    }
}