using WebApi9.Models;

namespace WebApi9.Services.Autor {
    public interface IAutorInterface {
        // Passo 1: Iniciando os metódos que vamos precisar

        Task<ResponseModel<List<AutorModel>>> ListarAutores();
        Task<ResponseModel<AutorModel>> BuscarAutorPorId(int idAutor);
        Task<ResponseModel<AutorModel>> BuscarAutorPorIdLivro(int idLivro);
    }
}
