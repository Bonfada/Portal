using Business.DTO;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Business.Interface
{
    public interface IUsuarioBusiness
    {
        void Add(UsuarioDTO usuario);


        UsuarioDTO GetById(int id);

        IEnumerable<UsuarioDTO> List();

        void Remove(UsuarioDTO usuario);
        
    }
}
