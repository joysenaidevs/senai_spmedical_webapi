using senai_projmed_webApi.Domains;
using senai_projmed_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_projmed_webApi.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        
        public void AtualizarIdCorpo(ConsultaDomain consulta)
        {
            throw new NotImplementedException();
        }

        public ConsultaDomain BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(ConsultaDomain novaConsulta)
        {
            //ctx.Consultas.Add(novaConsulta);

            //ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<ConsultaDomain> ListarTodos()
        {
            //return ctx.Consultas

            //     .Include(c => c.IdPacienteNavigation)

            //     .Include(c => c.IdMedicoNavigation)

            //     .Include(c => c.IdMedicoNavigation.IdEspecialidadeNavigation)

            //     .Include(c => c.IdStatusConsultaNavigation)

            //     .ToList();

            throw new NotImplementedException();
        }
    }
}
