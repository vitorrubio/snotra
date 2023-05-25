using SnotraApiDotNet.Dados;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SnotraApiDotNet.Dados.Modelo;
using SnotraApiDotNet.Dominio.Entidades;

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
    public ActionResult<List<NotaEntidade>> Get()
    {
        return Ok(_contexto
            .Notas
            .Include(x => x.Urls)
            .ToList()
            
            .Select(n => n.ToNotaEntidade())
            .ToList());
    }


    [HttpGet("{pag:int}/{qtde:int}")]
    public ActionResult<List<NotaEntidade>> Get(int pag, int qtde)
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
            .ToList()
            
            .Select(n => n.ToNotaEntidade())
            .ToList());
    }



    [HttpGet("{id:int}")]
    public ActionResult<NotaEntidade> Get(int id)
    {
        var nota = _contexto
            .Notas
            .Include(x => x.Urls)
            .FirstOrDefault(x => x.Id == id)?.ToNotaEntidade();

        if(nota == null)
        {
            return NotFound();
        }
        return Ok(nota);
    }


    [HttpPatch("{id:int}")]
    public ActionResult<NotaEntidade> Patch(int id, ModificarNotaRequest nota)
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
        original.Urls.AddRange(nota.Urls.Select(x => new LinkModelo{
            Url = x
        }));

        _contexto.Entry(original).State = EntityState.Modified;
        _contexto.SaveChanges();

        return Ok(original.ToNotaEntidade());

    }



    [HttpPost]
    public IActionResult Post(CriarNotaRequest nota)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var notaModelo  = new NotaModelo{
            Caminho = nota.Caminho,
            Texto = nota.Texto,
            
        };

        notaModelo.Urls.AddRange(nota.Urls.Select(x => new LinkModelo{
            Url = x
        }));

        _contexto.Notas.Add(notaModelo);

        _contexto.SaveChanges();

        return Ok(notaModelo.ToNotaEntidade());
    }


    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var nota = _contexto
            .Notas
            .Include(x => x.Urls)
            .FirstOrDefault(x => x.Id == id);

        if(nota == null)
        {
            return NotFound();
        }

        _contexto.Notas.Remove(nota);
        _contexto.SaveChanges();

        return NoContent();
    }
}
