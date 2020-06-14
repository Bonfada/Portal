using AutoMapper;
using BD.Entities;
using Business.DTO;

namespace Business.AutoMapper
{
    public class DomainToDataTransferObjectMappingProfile : Profile
    {
        public DomainToDataTransferObjectMappingProfile()
        {
            CreateMap<Usuario, UsuarioDTO>();
        }
    }
}
