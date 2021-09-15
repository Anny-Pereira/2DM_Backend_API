using Senai_ExemploInLock_webApi.Contexts;
using Senai_ExemploInLock_webApi.Domains;
using Senai_ExemploInLock_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_ExemploInLock_webApi.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        //Objeto contexto por onde serão chamados os métodos do EF Core
        InLockContext ctx = new InLockContext();



        public void Atualizar(int idEstudio, Estudio estudioAtualizado)
        {
            throw new NotImplementedException();
        }

        public Estudio BuscarId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Estudio novoEstudio)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int idEstudio)
        {
            throw new NotImplementedException();
        }

        public List<Estudio> Listar()
        {
            //Retorna uma lista com todas as informações dos estúdios
            return ctx.Estudios.ToList();
        }

        public List<Estudio> ListarJogos()
        {
            throw new NotImplementedException();
        }
    }
}
