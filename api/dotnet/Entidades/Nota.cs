namespace dotnet
{
    public class Nota
    {

        public Nota()
        {
            Caminho = "";
            Texto = "";
            Urls = new List<string>();
        }

        public string Caminho {get; set;}

        public string Texto {get; set;}

        public List<string> Urls {get; set;}

        public int Id {get; set;}


    }
}