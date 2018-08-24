using AutoMapper;
using Models.Domain;
using Models.DTO;

namespace Models
{
    public class AutoMapperModelProfile : Profile
    {
        public AutoMapperModelProfile()
        {
            CreateMap<RonSwansonQuote, RonSwansonQuoteDetailDto>();
        }
    }
}