using senai_projmed_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_projmed_webApi.Interfaces
{
    interface IProntuarioRepository
    {
        List<ProntuariosDomain> ListarTodos();
        ProntuariosDomain BuscarPorId(int id);
        void Cadastrar(ProntuariosDomain novaConsulta);
        void AtualizarIdCorpo(ProntuariosDomain consulta);
        void Deletar(int id);
    }
}
