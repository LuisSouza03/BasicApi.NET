using System.Text.Json.Serialization;

namespace WebApi9.Models {
    public class AutorModel {

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        // Coloco para ignorar os livros, não precisamos colocar os livros na hora de cadastrar o autor.
        [JsonIgnore]
        public ICollection<LivroModel> Livro { get; set; }



    }
}
