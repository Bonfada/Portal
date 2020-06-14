using AutoMapper;
using Business.AutoMapper;

namespace smart.erp.business.AutoMapper
{
    public class AutoMapperBusinessConfig
    {
        public static IMapper MapperService { get; private set; }

        public static void RegisterMappings()
        {
            var _mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DomainToDataTransferObjectMappingProfile());
                cfg.AddProfile(new DataTransferObjectToDomainMappingProfile());
            });
            MapperService = _mapper.CreateMapper();
        }
    }
}
