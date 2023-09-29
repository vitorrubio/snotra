using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace SnotraApiDotNet.Dominio.Entidades
{
    

    [Table(nameof(Lista))]
    [Index(nameof(Nome), IsUnique = true)]
    public class Lista
    {

        public Lista()
        {
            Nome = "";
        }

        [Key]
        public int Id {get; set;}


        [MaxLength(250)]
        [Column(TypeName = "nvarchar")]        
        public string Nome {get; set;}

        [MaxLength(500)]
        [Column(TypeName = "nvarchar")]
        public string? Descricao {get; set;}

        [Column(TypeName = "nvarchar(MAX)")]
        public string? Comentarios {get; set;}

        public string? Obs {get; set;}
    }
}