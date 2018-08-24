using Infrastructure.Interfaces.ReadModel;
using Models.DTO;

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