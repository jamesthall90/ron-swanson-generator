using Infrastructure.Interfaces.ReadModel;
using Models.DTO;

namespace Read.Queries.Quotes
{
    public class GetRandomSwansonQuoteQuery : IQuery<RonSwansonQuoteDetailDto>
    {
        public GetRandomSwansonQuoteQuery()
        { }
    }
}