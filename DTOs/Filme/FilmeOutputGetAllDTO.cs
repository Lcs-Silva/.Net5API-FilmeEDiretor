public class FilmeOutputGetAllDTO {

    public FilmeOutputGetAllDTO(string titulo, string ano, string genero)
    {
        Titulo = titulo;
        Ano = ano;
        Genero = genero;
    }
    
    public string Titulo { get; set; }
    public string Ano { get; set; }
    public string Genero { get; set; }
}