using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class DiretorService : IDiretorService {

    private readonly ApplicationDbContext _context;

    public DiretorService(ApplicationDbContext context) {
        
        _context = context;
    }

    public async Task<List<Diretor>> GetAll() {
        
        var diretores =  await _context.Diretores.ToListAsync();

        if (!diretores.Any()) {
                
            throw new Exception("Não foi encontrado nenhum diretor.");
        }

        return diretores;
    }

    public async Task<Diretor> GetById(long id) {

        var diretor = await _context.Diretores.FirstOrDefaultAsync(d => d.Id == id);

        if(diretor is null) {
            
            throw new Exception("Não foi encontrado nenhum diretor.");
        }

        return diretor;
    }

    public async Task<Diretor> Post(Diretor diretor) {

        _context.Diretores.Add(diretor);
        await _context.SaveChangesAsync();

        return diretor;
    }

    public async Task<Diretor> Delete(long id) {

        var diretor = await _context.Diretores.FirstOrDefaultAsync(d => d.Id == id);
        _context.Diretores.Remove(diretor);
        await _context.SaveChangesAsync();

        return diretor;
    }

    public async Task<Diretor> Put(Diretor diretor, long id) {

        diretor.Id = id;

        _context.Diretores.Update(diretor);
        await _context.SaveChangesAsync();

        return diretor;
    }
}