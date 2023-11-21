using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Models;

namespace API.Controllers;

[Route("api/tarefa")]
[ApiController]
public class TarefaController : ControllerBase
{
    private readonly AppDataContext _context;

    public TarefaController(AppDataContext context) =>
        _context = context;

    // GET: api/tarefa/listar
    [HttpGet]
    [Route("listar")]
    public IActionResult Listar()
    {
        try
        {
            List<Tarefa> tarefas = _context.Tarefas.Include(x => x.Categoria).ToList();
            return Ok(tarefas);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    // POST: api/tarefa/cadastrar
    [HttpPost]
    [Route("cadastrar")]
    public IActionResult Cadastrar([FromBody] Tarefa tarefa)
    {
        try
        {
            Categoria? categoria = _context.Categorias.Find(tarefa.CategoriaId);
            if (categoria == null)
            {
                return NotFound();
            }
            tarefa.Categoria = categoria;
            _context.Tarefas.Add(tarefa);
            _context.SaveChanges();
            return Created("", tarefa);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut]
    [Route("alterar/{id}")]
    public async Task<ActionResult<Tarefa>> PutTarefa(int id)
    {
        var tarefa = await _context.Tarefas.FindAsync(id);

        if (tarefa == null)
        {
            return NotFound();
        }


        if (tarefa.Concluida == false)
        {
            tarefa.TextoAlternado = "Em Andamento";
            tarefa.Concluida = true;
        }
        else
        {
            tarefa.TextoAlternado = "Concluido";
            tarefa.Concluida = false;
        }

       
        try
        {
            await _context.SaveChangesAsync();
            var tarefaAtualizada = await _context.Tarefas
                .Include(t => t.Categoria)
                .FirstOrDefaultAsync(t => t.TarefaId == id);
            if (tarefaAtualizada == null)
            {
                return NotFound();
            }
            return tarefaAtualizada;
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TarefaExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
    }

    
    [HttpGet]
    [Route("naoconcluidas")]
    public ActionResult<Tarefa> GetNaoConcluidas()
    {
        List<Tarefa> naoFeitas;
        try
        {
            List<Tarefa> tarefas = _context.Tarefas.ToList();
            naoFeitas = new List<Tarefa>();
            foreach (var item in tarefas)
            {
                if (item.Concluida == false)
                {
                    naoFeitas.Add(item);
                }
            }
            return Ok(naoFeitas);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);

        }
    }

    [HttpGet]
    [Route("concluidas")]
    public ActionResult<Tarefa> GetConcluidas()
    {
        List<Tarefa> naoFeitas;
        try
        {
            List<Tarefa> tarefas = _context.Tarefas.ToList();
            naoFeitas = new List<Tarefa>();
            foreach (var item in tarefas)
            {
                if (item.Concluida == true)
                {
                    naoFeitas.Add(item);
                }
            }
            return Ok(naoFeitas);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);

        }
    }




    private bool TarefaExists(int id)
    {
        return _context.Tarefas.Any(e => e.TarefaId == id);
    }
}