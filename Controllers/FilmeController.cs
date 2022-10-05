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
    public async Task<List<Filme>> GetAll() {
        
        return await _context.Filmes.ToListAsync();
    }

    [HttpGet("{id:long}")]
    public async Task<Filme> GetById(long id) {

        return await _context.Filmes.FirstOrDefaultAsync(d => d.Id == id);
    }

    [HttpPost]
    public async Task<ActionResult<Filme>> Post([FromBody] Filme filme) {
        
        _context.Filmes.Add(filme);
        await _context.SaveChangesAsync();
        
        return Ok(filme);
    }

    [HttpDelete("{id:long}")]
    public async Task<ActionResult<Filme>> Delete(long id) {

        var filme = await _context.Filmes.FirstOrDefaultAsync(d => d.Id == id);
        _context.Filmes.Remove(filme);
        await _context.SaveChangesAsync();

        return Ok(filme);
    }

    [HttpPut]
    public async Task<ActionResult<Filme>> Put([FromBody] Filme filme) {

        _context.Entry(filme).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return Ok(filme);   
    }
}