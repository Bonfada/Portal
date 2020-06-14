using AutoMapper;
using BD.Entities;
using Business.DTO;
using Business.Interface;
using Repository.Interface;
using System.Collections.Generic;

namespace Business
{
    public class UsuarioBusiness : IUsuarioBusiness
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioBusiness(
            IMapper mapper,
            IUsuarioRepository usuarioRepository)
        {
            _mapper = mapper;
            _usuarioRepository = usuarioRepository;
        }

        public IEnumerable<UsuarioDTO> List()
        {
            return _mapper.Map<IEnumerable<UsuarioDTO>>(_usuarioRepository.Listar());
        }

        public void  Add(UsuarioDTO usuario)
        {
            _usuarioRepository.Add(_mapper.Map<Usuario>(usuario));
            _usuarioRepository.Save();
        }

        public UsuarioDTO GetById(int id)
        {
            return _mapper.Map<UsuarioDTO>(_usuarioRepository.GetById(id));
        }

        public void Remove(UsuarioDTO usuario)
        {
            _usuarioRepository.Delete(_mapper.Map<Usuario>(usuario));
        }
    }
}
