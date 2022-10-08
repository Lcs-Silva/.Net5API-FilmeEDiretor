using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public interface IFilmeService {

    Task<FilmePagedOutputDTO> GetAll(int page, int limit, CancellationToken cancellationToken);
    Task<Filme> GetById(long id);
    Task<Filme> Post(Filme filme);
    Task<Filme> Delete(long id);
    Task<Filme> Put(Filme filme, long id);
}