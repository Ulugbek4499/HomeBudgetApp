using AutoMapper;
using HomeBudgetApp.Application.Commons.Models;
using HomeBudgetApp.Domain.Entities;

namespace HomeBudgetApp.Application.Commons.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Expence, ExpenceDto>().ReverseMap();
            CreateMap<Income, IncomeDto>().ReverseMap();
        }
    }
}
