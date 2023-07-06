using SnotraApiDotNet.Dados;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SnotraApiDotNet.Dominio.Entidades;
using System.Collections.Generic;
using System.Linq;
using SnotraApiDotNet.Dominio.Dto;

namespace SnotraApiDotNet.Controllers;

[ApiController]  //define uma clase como controller
[Route("api/[controller]")]
public class NotaController : ControllerBase //tem que ser filho de ControllerBase [o nome tem que terminar com controller]
{
    private readonly Contexto _contexto;

    public NotaController(Contexto ctx)
    {
        _contexto = ctx;
    }

    [HttpGet]
    public ActionResult<List<NotaDto>> Get()
    {
        return Ok(_contexto
            .Notas
            .Include(x => x.Urls)
            .ToList()
            
            .Select(n => n.ToDto())
            .ToList());
    }


    [HttpGet("{pag:int}/{qtde:int}")]
    public ActionResult<List<NotaDto>> Get(int pag, int qtde)
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
            
            .Select(n => n.ToDto())
            .ToList());
    }



    [HttpGet("{id:int}")]
    public ActionResult<NotaDto> Get(int id)
    {
        var nota = _contexto
            .Notas
            .Include(x => x.Urls)
            .FirstOrDefault(x => x.Id == id)?.ToDto();

        if(nota == null)
        {
            return NotFound();
        }
        return Ok(nota);
    }


    [HttpPatch("{id:int}")]
    public ActionResult<NotaDto> Patch(int id, ModificarNotaRequest nota)
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
        
        
        // original.Urls.Clear();
        // foreach(var url in nota.Urls)
        // {
        //     var existente = _contexto.Links.FirstOrDefault(x => x.Url == url);
        //     if(existente != null)
        //     {
        //        original.Urls.Add(existente); 
        //     }
        //     else
        //     {
        //         original.Urls.Add(new LinkModelo{
        //             Url = url
        //         });
        //     }
        // }


        var limpar = original.Urls.Where(x => !nota.Urls.Any(y => y == x.Url)).ToList();
        var acrescentar = nota.Urls.Where(x => !original.Urls.Any(y => y.Url == x)).ToList();
        
        foreach(var l in limpar)
        {
            original.Urls.Remove(l);
        }

        foreach(var url in acrescentar.Distinct())
        {
            var existente = _contexto.Links.FirstOrDefault(x => x.Url == url);
            if(existente != null)
            {
               original.Urls.Add(existente); 
            }
            else
            {
                original.Urls.Add(new Link{
                    Url = url
                });
            }
        }


        _contexto.Entry(original).State = EntityState.Modified;
        _contexto.SaveChanges();

        return Ok(original.ToDto());

    }



    [HttpPost]
    public IActionResult Post(CriarNotaRequest nota)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var notaModelo  = new Nota{
            Caminho = nota.Caminho,
            Texto = nota.Texto,
            
        };


        foreach(var url in nota.Urls.Distinct())
        {
            var existente = _contexto.Links.FirstOrDefault(x => x.Url == url);
            if(existente != null)
            {
               notaModelo.Urls.Add(existente); 
            }
            else
            {
                notaModelo.Urls.Add(new Link{
                    Url = url
                });
            }

        }

        _contexto.Notas.Add(notaModelo);

        _contexto.SaveChanges();

        return Ok(notaModelo.ToDto());
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
