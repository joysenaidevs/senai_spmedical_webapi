using senai_projmed_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_projmed_webApi.Interfaces
{
    interface IMedicoRepository
    {
        List<MedicosDomain> ListarTodos();
        MedicosDomain BuscarPorId(int id);
        void Cadastrar(MedicosDomain novaConsulta);
        void AtualizarIdCorpo(MedicosDomain consulta);
        void Deletar(int id);
    }
}
}
