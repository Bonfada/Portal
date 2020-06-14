using AutoMapper;
using BD.Entities;
using Business.DTO;

namespace Business.AutoMapper
{
    public class DataTransferObjectToDomainMappingProfile : Profile
    {
        public DataTransferObjectToDomainMappingProfile()
        {
            CreateMap<UsuarioDTO, Usuario>();
                
        }
    }
}
