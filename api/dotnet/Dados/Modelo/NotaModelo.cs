using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using SnotraApiDotNet.Dominio.Entidades;

namespace SnotraApiDotNet.Dados.Modelo
{
    [Table("Notas")]
    public class NotaModelo
    {

        public NotaModelo()
        {
            Caminho = "";
            Texto = "";
            Urls = new List<LinkModelo>();
        }

        
        [MaxLength(50)]
        [Column("Caminho", TypeName = "varchar(50)")]
        public string Caminho {get; set;}

        
        public string Texto {get; set;}


        public IList<LinkModelo> Urls {get; set;}

        [Key]
        public int Id {get; set;}


        public NotaEntidade ToNotaEntidade()
        {
            var result = new NotaEntidade{
                Caminho = this.Caminho,
                Texto = this.Texto,
                Id = this.Id,
            };

            result.Urls.AddRange(this.Urls.Select(x => x.Url).Distinct().ToList());

            return result;
        }
    }
}