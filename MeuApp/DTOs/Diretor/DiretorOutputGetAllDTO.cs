using System.Collections.Generic;

public class DiretorOutputGetAllDTO {

    public DiretorOutputGetAllDTO(long id, string nome) {
        
        Id = id;
        Nome = nome;
    }
    
    public long Id { get; set; }
    public string Nome { get; set; }
}