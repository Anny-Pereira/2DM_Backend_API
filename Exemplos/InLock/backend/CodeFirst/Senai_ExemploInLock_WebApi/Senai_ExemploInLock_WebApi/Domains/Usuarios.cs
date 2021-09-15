using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_ExemploInLock_WebApi.Domains
{
    /// <summary>
    /// Classe que representa a entidade Usuarios
    /// </summary>
    /// 

    [Table("Usuarios")]
    public class Usuarios
    {
        //Define que será uma chave primária
        [Key]
        //Define o auto-incremento(id identity)
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idUsuario { get; set; }

        //Define o tipo de dado
        [Column(TypeName = "varchar(150)")]
        //Define que a propriedade é obrigatória
        [Required(ErrorMessage = "O email é obrigatório!")]
        public string email { get; set; }


        //Define o tipo de dado
        [Column(TypeName = "varchar(150)")]
        //Define que a propriedade é obrigatória
        [Required(ErrorMessage = "A senha é obrigatória!")]
        //Define os requisitos da propriedade
        [StringLength(30, MinimumLength =5, ErrorMessage ="A senha do usuário deve conter de 5 a 30 caracteres.")]
        public string senha { get; set; }

        public int idTiposUsuario { get; set; }


        //Define a chave estrangeira 
        [ForeignKey("idTiposUsuario")]
        public TiposUsuario tiposUsuario { get; set; }
    }
}
