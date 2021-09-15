﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_ExemploInLock_WebApi.Domains
{
    /// <summary>
    /// lasse que representa a entidade Jogos
    /// </summary>

    [Table("Jogos")]
    public class Jogos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idJogo { get; set; }

        [Column(TypeName ="varchar(150)")]
        [Required(ErrorMessage = "O nome do jogo é obrigatório!")]
        public string nomeJogo { get; set; }


        [Column(TypeName ="TEXT")]
        [Required(ErrorMessage = "a descrição do jogo é obrigatória!")]
        public string descricao { get; set; }

        [Column(TypeName ="DATE")]
        [Required(ErrorMessage = "A data de lançamento do jogo é obrigatória!")]
        public DateTime dataLancamento { get; set; }


        [Column(TypeName ="DECIMAL (10,2)")]
        [Required(ErrorMessage = "É necessário informar o preço do jogo!")]
        public decimal valor { get; set; }


        [Required(ErrorMessage = "É necessário informar o estúdio que produziu o jogo!")]
        public int idEstudio { get; set; }

        
        [ForeignKey("idEstudio")]
        public Estudios estudio { get; set; }
    }
}
