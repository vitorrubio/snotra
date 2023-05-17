using SnotraApiDotNet.Dados;
using SnotraApiDotNet.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SnotraApiDotNet.Controllers;

[ApiController]  //define uma clase como controller
[Route("api/[controller]")]
public class UrlController : ControllerBase //tem que ser filho de ControllerBase [o nome tem que terminar com controller]
{
    private readonly Contexto _contexto;

    public UrlController(Contexto ctx)
    {
        _contexto = ctx;
    }

    [HttpGet]
    public ActionResult<List<Nota>> Get()
    {
        return Ok(_contexto
            .Notas
            .Include(x => x.Urls)
            .ToList());
    }


    [HttpGet("{pag:int}/{qtde:int}")]
    public ActionResult<List<Nota>> Get(int pag, int qtde)
    {
        if (pag < 1 || qtde < 1)
        {
            return BadRequest();
        }

        return Ok(_contexto
            .Notas
            .Include(x => x.Urls)
            .OrderBy(x => x.Caminho)
            .Skip((pag - 1) * qtde)
            .Take(qtde)
            .ToList());
    }



    [HttpGet("{id:int}")]
    public ActionResult<Nota> Get(int id)
    {
        return Ok(_contexto
            .Notas
            .Include(x => x.Urls)
            .FirstOrDefault(x => x.Id == id));
    }


    [HttpPatch("{id:int}")]
    public ActionResult<Nota> Patch(int id, Nota nota)
    {
        var original = _contexto
            .Notas
            .Include(x => x.Urls)
            .FirstOrDefault(x => x.Id == id);

        if (original == null)
        {
            return NotFound();
        }

        original.Caminho = nota.Caminho;
        original.Texto = nota.Texto;
        
        original.Urls.Clear();
        original.Urls.AddRange(nota.Urls);

        _contexto.Entry(original).State = EntityState.Modified;
        _contexto.SaveChanges();

        return Ok(original);

    }



    [HttpPost]
    public IActionResult Post(Nota nota)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        _contexto.Notas.Add(nota);

        _contexto.SaveChanges();

        return Ok(nota);
    }
}
