using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase {

    private readonly IFilmeService _filmeService;

    public FilmeController(IFilmeService filmeService) {
        
        _filmeService = filmeService;
    }

    
    /// <summary>
    /// Busca todos os filmes
    /// </summary>
    /// <returns>Todos os filmes</returns>
    /// <response code="200">Lista de filmes retornadas com sucesso</response>
    [HttpGet]
    public async Task<ActionResult<FilmePagedOutputDTO>> GetAll(CancellationToken cancellationToken, int limit = 5, int page = 1) {
            
        var pagedFilmes = await _filmeService.GetAll(page, limit, cancellationToken);

        return pagedFilmes;
    }

   
   /// <summary>
   /// Busca um filme específico
   /// </summary>
   /// <param name="id">Id do filme</param>
   /// <returns>O filme com Id requisitado</returns>
   /// <response code="200">Filme retornado com sucesso</response>
   [HttpGet("{id:long}")]
    public async Task<ActionResult<Filme>> GetById(long id) {
        
        var filme = await _filmeService.GetById(id);
        
        var filmeOutputGetByIdDTO = new FilmeOutputGetByIdDTO(filme.Titulo, filme.Ano, filme.Genero, filme.Diretor.Nome);

        return Ok(filmeOutputGetByIdDTO);
    }

    /// <summary>
    /// Cria um filme
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     {
    ///        "titulo": "Martin Scorsese",
    ///        "ano": "2000",
    ///        "genero": "Aventura",
    ///        "diretorId": 5
    ///     }
    ///
    /// </remarks>
    /// <param name="filmeInputPostDTO">Atributos do filme</param>
    /// <returns>O filme criado</returns>
    /// <response code="200">Filme criado com sucesso</response>
    [HttpPost]
    public async Task<ActionResult<FilmeOutputPostDTO>> Post([FromBody] FilmeInputPostDTO filmeInputPostDTO) {
                 
        var filme = new Filme(filmeInputPostDTO.Titulo, filmeInputPostDTO.Ano, filmeInputPostDTO.Genero, filmeInputPostDTO.DiretorId);

        await _filmeService.Post(filme);

        var filmeOutputPostDTO = new FilmeOutputPostDTO(filme.Titulo, filme.Ano, filme.Genero);
            
        return Ok(filmeOutputPostDTO);
    }
    
    /// <summary>
    /// Deleta um filme
    /// </summary>
    /// <param name="id">Id do filme</param>
    /// <returns>O filme deletado</returns>
    /// <response code="200">Filme deletado com sucesso</response>
    [HttpDelete("{id:long}")]
    public async Task<ActionResult<Filme>> Delete(long id) {
        
        var filme = await _filmeService.Delete(id);

        return Ok(filme);
    }

    /// <summary>
    /// Atualiza um filme
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     {
    ///        "titulo": "Martin Scorsese",
    ///        "ano": "2000",
    ///        "genero": "Aventura",
    ///        "diretorId": 5
    ///     }
    ///
    /// </remarks>
    /// <param name="filmeInputPutDTO">Atributos do filme</param>
    /// <param name="id">Id do filme</param>
    /// <returns>O filme atualizado</returns>
    /// <response code="200">Filme atualizado com sucesso</response>
    [HttpPut("{id:long}")]
    public async Task<ActionResult<FilmeOutputPutDTO>> Put([FromBody] FilmeInputPutDTO filmeInputPutDTO, long id) {
            
        var filme = new Filme(filmeInputPutDTO.Titulo, filmeInputPutDTO.Ano, filmeInputPutDTO.Genero, filmeInputPutDTO.DiretorId);

        await _filmeService.Put(filme, id);

        var filmeOutputPutDTO = new FilmeOutputPutDTO(filme.Titulo, filme.Ano, filme.Genero);

        return Ok(filmeOutputPutDTO);
    }
}