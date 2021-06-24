using senai_projmed_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_projmed_webApi.Interfaces
{
    interface IEspecialidadeRepository
    {
        List<EspecialidadesDomain> ListarTodos();
        EspecialidadesDomain BuscarPorId(int id);
        void Cadastrar(EspecialidadesDomain novaConsulta);
        void AtualizarIdCorpo(EspecialidadesDomain consulta);
        void Deletar(int id);
    }
}
