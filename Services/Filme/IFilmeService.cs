using System.Collections.Generic;
using System.Threading.Tasks;

public interface IFilmeService {

    Task<List<Filme>> GetAll();
    Task<Filme> GetById(long id);
    Task<Filme> Post(Filme filme);
    Task<Filme> Delete(long id);
    Task<Filme> Put(Filme filme);
}