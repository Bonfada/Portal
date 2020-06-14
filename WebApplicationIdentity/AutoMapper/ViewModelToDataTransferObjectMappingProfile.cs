using AutoMapper;
using Business.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationIdentity.ViewModels;

namespace WebApplicationIdentity.AutoMapper
{
    public class ViewModelToDataTransferObjectMappingProfile : Profile
    {
        public ViewModelToDataTransferObjectMappingProfile()
        {
            CreateMap<ViewModelUsuario, UsuarioDTO>();
        }
    }
}