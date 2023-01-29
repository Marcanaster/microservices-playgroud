using AutoMapper;
using Playground.API.Data.ValueObjects;
using Playground.API.Model;

namespace Playground.API.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductVO, Product>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
