using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace SnotraApiDotNet.Dominio.Dto
{
    public class NotaDto
    {
        public NotaDto()
        {
            Caminho = "";
            Texto = "";
            Urls = new List<string>();
        }

        public int Id { get; init; }
        public string Caminho {get; set;}

        public string Texto {get; set;}

        public List<string> Urls {get; private set;}

    }
}