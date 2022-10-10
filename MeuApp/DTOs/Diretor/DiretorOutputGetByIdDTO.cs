public class DiretorOutputGetByIdDTO {

    public DiretorOutputGetByIdDTO(long id, string nome) {
        Id = id;
        Nome = nome;
    }
    
    public long Id { get; set; }
    public string Nome { get; set; }
}