using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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


    }
}