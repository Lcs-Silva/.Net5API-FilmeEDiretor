public class FilmeOutputGetAllDTO {

    public FilmeOutputGetAllDTO(long id, string titulo, string ano, string genero)
    {
        
        Id = id;
        Titulo = titulo;
        Ano = ano;
        Genero = genero;
    }
    
    public long Id { get; set; }
    public string Titulo { get; set; }
    public string Ano { get; set; }
    public string Genero { get; set; }
}