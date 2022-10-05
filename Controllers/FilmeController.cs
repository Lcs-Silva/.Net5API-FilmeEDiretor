using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase {

    private readonly ApplicationDbContext _context;

    public FilmeController(ApplicationDbContext context) {
        
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<FilmeOutputGetAllDTO>>> GetAll() {
        
        var filmes =  await _context.Filmes.ToListAsync();
        var filmeOutputGetAllDTO = new List<FilmeOutputGetAllDTO>();

        foreach(var filme in filmes) {
            var filmeOutput = new FilmeOutputGetAllDTO(filme.Titulo, filme.Ano, filme.Genero);
            filmeOutputGetAllDTO.Add(filmeOutput);
        }

        return Ok(filmeOutputGetAllDTO);
    }

    [HttpGet("{id:long}")]
    public async Task<ActionResult<Filme>> GetById(long id) {

        var filme = await _context.Filmes.FirstOrDefaultAsync(d => d.Id == id);

        var filmeOutputGetByIdDTO = new FilmeOutputGetByIdDTO(filme.Titulo, filme.Ano, filme.Genero);

        return Ok(filmeOutputGetByIdDTO);
    }

    [HttpPost]
    public async Task<ActionResult<FilmeOutputPostDTO>> Post([FromBody] FilmeInputPostDTO filmeInputPostDTO) {
        
        var filme = new Filme(filmeInputPostDTO.Titulo, filmeInputPostDTO.Ano, filmeInputPostDTO.Genero, filmeInputPostDTO.DiretorId);
        
        _context.Filmes.Add(filme);
        await _context.SaveChangesAsync();

        var filmeOutputPostDTO = new FilmeOutputPostDTO(filme.Titulo, filme.Ano, filme.Genero);
        
        return Ok(filmeOutputPostDTO);
    }

    [HttpDelete("{id:long}")]
    public async Task<ActionResult<Filme>> Delete(long id) {

        var filme = await _context.Filmes.FirstOrDefaultAsync(d => d.Id == id);
        _context.Filmes.Remove(filme);
        await _context.SaveChangesAsync();

        return Ok(filme);
    }

    [HttpPut("{id:long}")]
    public async Task<ActionResult<FilmeOutputPutDTO>> Put([FromBody] FilmeInputPutDTO filmeInputPutDTO, long id) {

        var filme = new Filme(filmeInputPutDTO.Titulo, filmeInputPutDTO.Ano, filmeInputPutDTO.Genero, filmeInputPutDTO.DiretorId);
        
        filme.Id = id;
        _context.Filmes.Update(filme);
        await _context.SaveChangesAsync();

        var filmeOutputPutDTO = new FilmeOutputPutDTO(filme.Titulo, filme.Ano, filme.Genero);

        return Ok(filmeOutputPutDTO);   
    }
}