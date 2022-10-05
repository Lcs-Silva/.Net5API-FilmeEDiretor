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
    public async Task<ActionResult<List<DiretorOutputGetAllDTO>>> GetAll() {
        
        var diretores =  await _context.Diretores.ToListAsync();
        var diretorOutputGetAllDTO = new List<DiretorOutputGetAllDTO>();
        
        foreach(var diretor in diretores) {
            var diretorOutput = new DiretorOutputGetAllDTO(diretor.Id, diretor.Nome);
            diretorOutputGetAllDTO.Add(diretorOutput);
        }

        return Ok(diretorOutputGetAllDTO);
    }

    [HttpGet("{id:long}")]
    public async Task<ActionResult<DiretorOutputGetByIdDTO>> GetById(long id) {

        var diretor =  await _context.Diretores.FirstOrDefaultAsync(d => d.Id == id);

        var diretorOutputGetByIdDTO = new DiretorOutputGetByIdDTO(diretor.Id, diretor.Nome);

        return Ok(diretorOutputGetByIdDTO);
    }

    [HttpPost]
    public async Task<ActionResult<DiretorOutputPostDTO>> Post([FromBody] DiretorInputPostDTO diretorInputPostDTO) {
        
        var diretor = new Diretor(diretorInputPostDTO.Nome);
        _context.Diretores.Add(diretor);
        await _context.SaveChangesAsync();

        var diretorOutputDTO = new DiretorOutputPostDTO(diretor.Id, diretor.Nome);
        
        return Ok(diretorOutputDTO);
    }

    [HttpDelete("{id:long}")]
    public async Task<ActionResult<Diretor>> Delete(long id) {

        var diretor = await _context.Diretores.FirstOrDefaultAsync(d => d.Id == id);
        _context.Diretores.Remove(diretor);
        await _context.SaveChangesAsync();

        return Ok(diretor);
    }

    [HttpPut("{id:long}")]
    public async Task<ActionResult<DiretorOutputPutDTO>> Put([FromBody] DiretorInputPutDTO diretorInputPutDTO, long id) {

        var diretor = new Diretor(diretorInputPutDTO.Nome);
        
        diretor.Id = id;
        _context.Diretores.Update(diretor);
        await _context.SaveChangesAsync();

        var diretorOutputPutDTO = new DiretorOutputPutDTO(diretor.Id, diretor.Nome);

        return Ok(diretorOutputPutDTO);   
    }
}