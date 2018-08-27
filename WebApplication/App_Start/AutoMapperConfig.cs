using AutoMapper;
using WebApplication.DTO;
using WebApplication.Models;

namespace WebApplication.App_Start
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize((config) =>
            {
                config.CreateMap<Statement,StatementDTO>().ReverseMap();
            });
        }
    }
}