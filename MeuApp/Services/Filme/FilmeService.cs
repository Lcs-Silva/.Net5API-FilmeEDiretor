using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class FilmeService : IFilmeService {

    private readonly ApplicationDbContext _context;

     public FilmeService(ApplicationDbContext context) {
        
        _context = context;
     }

    public async Task<FilmePagedOutputDTO> GetAll(int page, int limit, CancellationToken cancellationToken) {
        
        var pagedFilmes = await _context.Filmes.OrderBy(f => f.Id).PaginateAsync(page, limit, cancellationToken);

        if(!pagedFilmes.Items.Any()) {
            throw new Exception("Não foi encontrado nenhum filme.");
        }

        return new FilmePagedOutputDTO {
            CurrentPage = pagedFilmes.CurrentPage,
            TotalPages = pagedFilmes.TotalPages,
            TotalItems = pagedFilmes.TotalItems,
            Items = pagedFilmes.Items.Select(filme => new FilmeOutputGetAllDTO(filme.Id, filme.Titulo, filme.Ano, filme.Genero)).ToList()
        };

    }
    
    public async Task<Filme> GetById(long id) {
        
        var filme = await _context.Filmes.FirstOrDefaultAsync(f => f.Id == id);

        if(filme is null) {
            throw new Exception("Não foi encontrado nenhum filme");
        }

        return filme;
    }
    
    public async Task<Filme> Post(Filme filme) {
        
        var diretor = _context.Diretores.FirstOrDefaultAsync(d => d.Id == filme.DiretorId);

        if(diretor is null) {
                
            throw new Exception("Informe um Id de diretor que seja válido");
        }
        
        _context.Filmes.Add(filme);
        await _context.SaveChangesAsync();

        return filme;
    }
    
    public async Task<Filme> Delete(long id) {
        var filme = await _context.Filmes.FirstOrDefaultAsync(f => f.Id == id);

        _context.Filmes.Remove(filme);
        await _context.SaveChangesAsync();

        return filme;
    }

    public async Task<Filme> Put(Filme filme, long id) {
        
        if(filme.DiretorId == 0) {
            throw new Exception("Insira um ID válido de diretor.");
        }

        filme.Id = id;
        
        _context.Filmes.Update(filme);
        await _context.SaveChangesAsync();

        return filme;
    }
}