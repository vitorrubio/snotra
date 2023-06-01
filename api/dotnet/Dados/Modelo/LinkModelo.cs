using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace SnotraApiDotNet.Dados.Modelo
{
    
    [Table("Link")]
    [Index(nameof(Url), IsUnique = true)]
    public class LinkModelo
    {

        public LinkModelo()
        {
            Url = "";
            Notas = new List<NotaModelo>();
        }

        
        [MaxLength(2048)]
        [Column("Url", TypeName = "varchar(2048)")]        
        public string Url {get; set;}

        [Key]
        public int Id {get; set;}


        public IList<NotaModelo> Notas {get; set;}


    }
}