using System.Collections.Generic;

public class DiretorPagedOutputDTO {
        public int CurrentPage { get; init; }

        public int TotalItems { get; init; }

        public int TotalPages { get; init; }

        public List<DiretorOutputGetAllDTO> Items { get; init; }
}