using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("[controller]")]
public class DiretorController : ControllerBase {

    private readonly ApplicationDbContext _context;

    public DiretorController(ApplicationDbContext context) {
        
        _context = context;
    }

    [HttpGet]
    public async Task<List<Diretor>> GetAll() {
        
        return await _context.Diretores.ToListAsync();
    }

    [HttpGet("{id:long}")]
    public async Task<Diretor> GetById(long id) {

        return await _context.Diretores.FirstOrDefaultAsync(d => d.Id == id);
    }

    [HttpPost]
    public async Task<ActionResult<Diretor>> Post([FromBody] Diretor diretor) {
        
        _context.Diretores.Add(diretor);
        await _context.SaveChangesAsync();
        
        return Ok(diretor);
    }

    [HttpDelete("{id:long}")]
    public async Task<ActionResult<Diretor>> Delete(long id) {

        var diretor = await _context.Diretores.FirstOrDefaultAsync(d => d.Id == id);
        _context.Diretores.Remove(diretor);
        await _context.SaveChangesAsync();

        return Ok(diretor);
    }

    [HttpPut]
    public async Task<ActionResult<Diretor>> Put([FromBody] Diretor diretor) {

        _context.Entry(diretor).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return Ok(diretor);   
    }
}