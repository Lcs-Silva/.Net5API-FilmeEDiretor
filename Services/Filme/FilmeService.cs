using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class FilmeService : IFilmeService {

    private readonly ApplicationDbContext _context;

     public FilmeService(ApplicationDbContext context) {
        
        _context = context;
     }

    public async Task<List<Filme>> GetAll() {
        
        var filmes = await _context.Filmes.ToListAsync();

        if(!filmes.Any()) {
            throw new Exception("Não foi encontrado nenhum filme.");
        }

        return filmes;
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

    public async Task<Filme> Put(Filme filme) {
        
        if(filme.DiretorId == 0) {
            throw new Exception("Insira um ID válido de diretor.");
        }
        
        _context.Filmes.Update(filme);
        await _context.SaveChangesAsync();

        return filme;
    }
}