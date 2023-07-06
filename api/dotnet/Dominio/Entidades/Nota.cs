using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using SnotraApiDotNet.Dominio.Dto;


namespace SnotraApiDotNet.Dominio.Entidades
{
    [Table("Notas")]
    public class Nota
    {

        public Nota()
        {
            Caminho = "";
            Texto = "";
            Urls = new List<Link>();
        }

        
        [MaxLength(50)]
        [Column("Caminho", TypeName = "varchar(50)")]
        public string Caminho {get; set;}

        
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