using Infrastructure.Interfaces.ReadModel;
using Models.DTO;
using Models.DTO.RonSwansonQuote;

namespace Read.Queries.Quotes
{
    public class GetRandomSwansonQuoteQuery : IQuery<RonSwansonQuoteDetailDto>
    {
        public GetRandomSwansonQuoteQuery()
        { }
    }
}