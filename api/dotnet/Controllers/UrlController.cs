using dotnet.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace dotnet.Controllers;

[ApiController]  //define uma clase como controller
[Route("api/[controller]")]
public class UrlController : ControllerBase //tem que ser filho de ControllerBase [o nome tem que terminar com controller]
{

    [HttpGet]
    //public IActionResult Get()
    public string Get()
    //public ActionResult<string> Get()
    {
        //return Ok("Tudo bem"); //200 ok
        //return BadRequest("Tudo mal"); //400 bad request
        //return NotFound("Não encontrado"); //404
        //return StatusCode(425, "Mutcho Esquisito");


        return "Tudo bem mesmo";

        /*
        return StatusCode(505, new   {
                            Mensagem="not found sei lá procura no ipiranga", 
                            Saldo = "100" 
                        });
                        */
    }


    [HttpGet("hello")]
    public string Hello()
    {
        return "Hello World";
    }

    [HttpGet("{id}")]
    public string Get(string id)
    {
        return $"O id procurado foi {id}";
    }


    [HttpGet("{pag:int}/{qtde:int}")]
    public string Get(int pag, int qtde)
    {
        return $"exbindo {qtde} resultados da página {pag}";
    }

    ///informações do metodo
    [HttpGet("categoria/{cat}/produtos")]
    public string GetProdutos(string cat)
    {
        return $"exbindo os produtos da categoria {cat}";
    }

    [HttpPost]
    public IActionResult Post(Nota nota)
    {
        nota.Id = DateTime.Now.Second;
        return Ok(nota);
    }
}
