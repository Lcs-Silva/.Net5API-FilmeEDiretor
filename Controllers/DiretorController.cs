using System;
using System.Collections.Generic;
using System.Linq;
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
    
    /// <summary>
    /// Busca todos os diretores
    /// </summary>
    /// <returns>Todos os diretores</returns>
    /// <response code="200">Lista de diretores retornadas com sucesso</response>
    [HttpGet]
    public async Task<ActionResult<List<DiretorOutputGetAllDTO>>> GetAll()
    {
        
        var diretores = await _context.Diretores.ToListAsync();

        if (!diretores.Any()) {
                
            throw new Exception("Não foi encontrado nenhum diretor.");
        }

        var diretorOutputGetAllDTO = new List<DiretorOutputGetAllDTO>();

        foreach (var diretor in diretores)
        {
            var diretorOutput = new DiretorOutputGetAllDTO(diretor.Id, diretor.Nome);
            diretorOutputGetAllDTO.Add(diretorOutput);
        }

        return Ok(diretorOutputGetAllDTO);
    }

    /// <summary>
    /// Busca um diretor específico
    /// </summary>
    /// <param name="id">Id do diretor</param>
    /// <returns>O diretor com Id requisitado</returns>
    /// <response code="200">Diretor retornado com sucesso</response>
    [HttpGet("{id:long}")]
    public async Task<ActionResult<DiretorOutputGetByIdDTO>> GetById(long id) {
   
        var diretor =  await _context.Diretores.FirstOrDefaultAsync(d => d.Id == id);

        if(diretor is null) {
            throw new Exception("Não foi encontrado nenhum diretor.");
        }

        var diretorOutputGetByIdDTO = new DiretorOutputGetByIdDTO(diretor.Id, diretor.Nome);

        return Ok(diretorOutputGetByIdDTO);  
    }

    /// <summary>
    /// Cria um diretor
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     {
    ///        "nome": "Lucas Silva"
    ///     }
    ///
    /// </remarks>
    /// <param name="diretorInputPostDTO">Atributos do diretor</param>
    /// <returns>O diretor criado</returns>
    /// <response code="200">Diretor criado com sucesso</response>
    /// <response code="400">Erro de validação</response>
    [HttpPost]
    public async Task<ActionResult<DiretorOutputPostDTO>> Post([FromBody] DiretorInputPostDTO diretorInputPostDTO) {
        
        var diretor = new Diretor(diretorInputPostDTO.Nome);
        _context.Diretores.Add(diretor);
        await _context.SaveChangesAsync();

        var diretorOutputDTO = new DiretorOutputPostDTO(diretor.Id, diretor.Nome);
            
        return Ok(diretorOutputDTO);
    }

    /// <summary>
    /// Deleta um diretor
    /// </summary>
    /// <param name="id">Id do diretor</param>
    /// <returns>O diretor deletado</returns>
    /// <response code="200">Diretor deletado com sucesso</response>
    [HttpDelete("{id:long}")]
    public async Task<ActionResult<Diretor>> Delete(long id) {

        var diretor = await _context.Diretores.FirstOrDefaultAsync(d => d.Id == id);
        _context.Diretores.Remove(diretor);
        await _context.SaveChangesAsync();

        return Ok(diretor);
    }

    /// <summary>
    /// Atualiza um diretor
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     {
    ///        "nome": "Lucas Silva"
    ///     }
    ///
    /// </remarks>
    /// <param name="diretorInputPutDTO">Atributos do diretor</param>
    /// <param name="id">Id do diretor</param>
    /// <returns>O diretor atualizado</returns>
    /// <response code="200">Diretor atualizado com sucesso</response>
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