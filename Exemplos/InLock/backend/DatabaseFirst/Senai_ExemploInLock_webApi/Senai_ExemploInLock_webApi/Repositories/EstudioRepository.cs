using Microsoft.EntityFrameworkCore;
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
            //Busca um estudio através de seu id 
            Estudio estudioBuscado = ctx.Estudios.Find(idEstudio);

            //Verifica se o novo nome do estudio foi informado
            if (estudioAtualizado.NomeEstudio != null)
            {
                //se sim, altera o valor da propriedade NomeEstudio
                estudioBuscado.NomeEstudio = estudioAtualizado.NomeEstudio;
            }

            //atualiza o estudio que foi buscado
            ctx.Estudios.Update(estudioBuscado);

            //salva as informações que serão gravadas no banco de dados
            ctx.SaveChanges();
        }

        public Estudio BuscarId(int idEstudio)
        {
            return ctx.Estudios.FirstOrDefault(e => e.IdEstudio == idEstudio);
        }

        public void Cadastrar(Estudio novoEstudio)
        {
            //Adiciona um novo estudio
            ctx.Estudios.Add(novoEstudio);

            //salva as informações que serão gravadas no banco de dados
            ctx.SaveChanges();
        }

        public void Deletar(int idEstudio)
        {
            //busca um estudio através de seu id
            Estudio estudioBuscado = BuscarId(idEstudio);

            //remove o estudio que foi buscado
            ctx.Remove(estudioBuscado);

            //salva as informações que serão gravadas no banco de dados
            ctx.SaveChanges();
        }

        public List<Estudio> Listar()
        {
            //Retorna uma lista com todas as informações dos estúdios
            return ctx.Estudios.ToList();
        }

        public List<Estudio> ListarJogos()
        {
            return ctx.Estudios.Include(e => e.Jogos).ToList();
        }
    }
}
