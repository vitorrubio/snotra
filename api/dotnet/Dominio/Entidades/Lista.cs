using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace SnotraApiDotNet.Dominio.Entidades
{
    

    [Index(nameof(Nome), IsUnique = true)]
    public class Lista
    {

        public Lista()
        {
            Nome = "";
        }

        [Key]
        public int Id {get; set;}


        public string Nome {get; set;}


    }
}