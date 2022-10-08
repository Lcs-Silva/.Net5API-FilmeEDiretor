using System.Collections.Generic;
using System.Threading.Tasks;

public interface IDiretorService {

    Task<List<Diretor>> GetAll();
    Task<Diretor> GetById(long id);
    Task<Diretor> Post(Diretor diretor);
    Task<Diretor> Delete(long id);
    Task<Diretor> Put(Diretor diretor);
}