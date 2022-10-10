using System.Collections.Generic;

public class FilmePagedOutputDTO {
        public int CurrentPage { get; init; }

        public int TotalItems { get; init; }

        public int TotalPages { get; init; }

        public List<FilmeOutputGetAllDTO> Items { get; init; }
}