using Microsoft.EntityFrameworkCore;
using Senai_ExemploInLock_webApi.Interfaces;
using Senai_ExemploInLock_WebApi.Contexts;
using Senai_ExemploInLock_WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_ExemploInLock_webApi.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        //Objeto contexto por onde serão chamados os métodos do EF Core
        Senai_ExemploInLock_WebApi.Contexts.InLockContext ctx = new InLockContext();



        public void Atualizar(int idEstudio, Estudios estudioAtualizado)
        {
            //Busca um estudio através de seu id 
            Estudios estudioBuscado = ctx.Estudios.Find(idEstudio);

            //Verifica se o novo nome do estudio foi informado
            if (estudioAtualizado.nomeEstudio != null)
            {
                //se sim, altera o valor da propriedade NomeEstudio
                estudioBuscado.nomeEstudio = estudioAtualizado.nomeEstudio;
            }

            //atualiza o estudio que foi buscado
            ctx.Estudios.Update(estudioBuscado);

            //salva as informações que serão gravadas no banco de dados
            ctx.SaveChanges();
        }

        public Estudios BuscarId(int idEstudio)
        {
            return ctx.Estudios.FirstOrDefault(e => e.idEstudio == idEstudio);
        }

        public void Cadastrar(Estudios novoEstudio)
        {
            //Adiciona um novo estudio
            ctx.Estudios.Add(novoEstudio);

            //salva as informações que serão gravadas no banco de dados
            ctx.SaveChanges();
        }

        public void Deletar(int idEstudio)
        {
            //busca um estudio através de seu id
            Estudios estudioBuscado = BuscarId(idEstudio);

            //remove o estudio que foi buscado
            ctx.Remove(estudioBuscado);

            //salva as informações que serão gravadas no banco de dados
            ctx.SaveChanges();
        }

        public List<Estudios> Listar()
        {
            //Retorna uma lista com todas as informações dos estúdios
            return ctx.Estudios.ToList();
        }

        public List<Estudios> ListarJogos()
        {
            return ctx.Estudios.Include(e => e.jogos).ToList();
        }
    }
}
