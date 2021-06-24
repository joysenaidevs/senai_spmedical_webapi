using senai_projmed_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_projmed_webApi.Interfaces
{
    interface ITiposUsuariosRepository
    {
        List<tiposUsuariosDomain> ListarTodos();
        tiposUsuariosDomain BuscarPorId(int id);
        void Cadastrar(tiposUsuariosDomain novaConsulta);
        void AtualizarIdCorpo(tiposUsuariosDomain consulta);
        void Deletar(int id);
    }
}
