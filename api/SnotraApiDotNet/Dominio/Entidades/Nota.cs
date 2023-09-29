using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using SnotraApiDotNet.Dominio.Dto;


namespace SnotraApiDotNet.Dominio.Entidades
{
    [Table("Nota")]
    public class Nota
    {

        public Nota()
        {
            Caminho = "";
            Texto = "";
            Urls = new List<Link>();
        }

        
        [MaxLength(260)]
        [Column(TypeName = "varchar")]
        public string Caminho {get; set;}

        
        [Column(TypeName = "nvarchar(MAX)")]
        public string Texto {get; set;}


        public IList<Link> Urls {get; set;}

        [Key]
        public int Id {get; set;}


        public NotaDto ToDto()
        {
            var result = new NotaDto{
                Caminho = this.Caminho,
                Texto = this.Texto,
                Id = this.Id,
            };

            result.Urls.AddRange(this.Urls.Select(x => x.Url).Distinct().ToList());

            return result;
        }
    }
}