using ecommerce.domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.domain.repositories;

public interface IUsuarioRepository
{
    Usuario Salvar(Usuario usuario);
    Usuario BuscarPorId(Guid id);
    Usuario BuscarPorEmail(string email);
    Usuario BuscarPorCpf(string cpf);
    List<Usuario> ListarTodos();

}
