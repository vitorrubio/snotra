using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SnotraApiDotNet.Dados.Modelo
{
    
    [Table("Link")]
    public class LinkModelo
    {

        public LinkModelo()
        {
            Url = "";
        }

        
        [MaxLength(2048)]
        [Column("Url", TypeName = "varchar(2048)")]
        public string Url {get; set;}

        [Key]
        public int Id {get; set;}

        [ForeignKey("NotaId")]
        [JsonIgnore]
        public NotaModelo? Nota {get; set;}

        [ForeignKey("NotaId")]
        [Required]
        public int NotaId {get; set;}




    }
}