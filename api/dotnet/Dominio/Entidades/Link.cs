using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace SnotraApiDotNet.Dominio.Entidades
{
    
    [Table("Link")]
    [Index(nameof(Url), IsUnique = true)]
    public class Link
    {

        public Link()
        {
            Url = "";
            Notas = new List<Nota>();
        }

        
        [MaxLength(2048)]
        [Column("Url", TypeName = "varchar(2048)")]        
        public string Url {get; set;}

        [Key]
        public int Id {get; set;}


        public IList<Nota> Notas {get; set;}


    }
}