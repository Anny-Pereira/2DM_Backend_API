using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_ExemploInLock_WebApi.Domains
{
    /// <summary>
    /// Classe que representa a entidade de TiposUsuario
    /// </summary>
    /// 

    [Table("TiposUsuario")]
    public class TiposUsuario
    {
        //Define que será uma chave primária
        [Key]
        //Define o auto-incremento(id identity)
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idTiposUsuario { get; set; }


        //Define o tipo de dado
        [Column(TypeName = "varchar(150)")]
        //Define que a propriedade é obrigatória
        [Required(ErrorMessage ="O título do tipo de usuário é obrigatório!")]
        public string tituloTiposUsuario { get; set; }
    }
}
