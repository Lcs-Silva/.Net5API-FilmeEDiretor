using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public interface IDiretorService {

    Task<DiretorPagedOutputDTO> GetAll(int page, int limit, CancellationToken cancellationToken);
    Task<Diretor> GetById(long id);
    Task<Diretor> Post(Diretor diretor);
    Task<Diretor> Delete(long id);
    Task<Diretor> Put(Diretor diretor, long id);
}