using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace dotnet.Entidades
{
    public class Link
    {

        public Link()
        {
            Url = "";
        }

        
        [MaxLength(2048)]
        [Column("Url", TypeName = "varchar(2048)")]
        public string Url {get; set;}

        [Key]
        public int Id {get; set;}

        // [ForeignKey("NotaId")]
        // [JsonIgnore]
        // public Nota Nota {get; set;}

        [ForeignKey("NotaId")]
        [Required]
        public int NotaId {get; set;}




    }
}