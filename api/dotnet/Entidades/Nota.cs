using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnet.Entidades
{
    public class Nota
    {

        public Nota()
        {
            Caminho = "";
            Texto = "";
            Urls = new List<Link>();
        }

        
        [MaxLength(50)]
        [Column("C_CAMINHO", TypeName = "varchar(50)")]
        public string Caminho {get; set;}

        [Column("Texto", TypeName = "nvarchar(max)")]
        public string Texto {get; set;}


        public List<Link> Urls {get; set;}

        [Key]
        public int Id {get; set;}


    }
}