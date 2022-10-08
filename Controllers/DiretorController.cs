using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class DiretorController : ControllerBase {

    private readonly IDiretorService _diretorService;

    public DiretorController(IDiretorService diretorService) {
        
        _diretorService = diretorService;
    }
    
    /// <summary>
    /// Busca todos os diretores
    /// </summary>
    /// <returns>Todos os diretores</returns>
    /// <response code="200">Lista de diretores retornadas com sucesso</response>
    [HttpGet]
    public async Task<ActionResult<List<DiretorOutputGetAllDTO>>> GetAll()
    {
        
        var diretores = await _diretorService.GetAll();

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
   
        var diretor =  await _diretorService.GetById(id);

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
        await _diretorService.Post(diretor);

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

        var diretor = await _diretorService.Delete(id);

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

        await _diretorService.Put(diretor, id);

        var diretorOutputPutDTO = new DiretorOutputPutDTO(diretor.Id, diretor.Nome);

        return Ok(diretorOutputPutDTO);
    }
}