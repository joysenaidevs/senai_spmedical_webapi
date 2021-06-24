using senai_projmed_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_projmed_webApi.Interfaces
{
    interface IConsultaRepository
    {
        List<ConsultaDomain> ListarTodos();
        ConsultaDomain BuscarPorId(int id);
        void Cadastrar(ConsultaDomain novaConsulta);
        void AtualizarIdCorpo(ConsultaDomain consulta);
        void Deletar(int id);
    }
}
