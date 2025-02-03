﻿using Microsoft.EntityFrameworkCore;
using WebApi9.Data;
using WebApi9.Models;

namespace WebApi9.Services.Autor {
    public class AutorService : IAutorInterface {
        // Passo 2: Implementamos os métodos

        private readonly AppDbContext _context;
        public AutorService(AppDbContext context) {
            _context = context;
        }

        public async Task<ResponseModel<AutorModel>> BuscarAutorPorId(int idAutor) {
            ResponseModel<AutorModel> resposta = new ResponseModel<AutorModel>();

            try {

                var autor = await _context.Autores.FirstOrDefaultAsync(autorBanco => autorBanco.Id == idAutor);

                if (autor == null) {
                    resposta.Mensagem = "Nenhum registro localizado.";
                    return resposta;
                }

                resposta.Dados = autor;
                resposta.Mensagem = "Autor localizado.";
                return resposta;

            }
            catch (Exception ex) { 
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<AutorModel>> BuscarAutorPorIdLivro(int idLivro) {
            ResponseModel<AutorModel> resposta = new ResponseModel<AutorModel>();

            try {

                var livro = await _context.Livros
                    .Include(a => a.Autor)
                    .FirstOrDefaultAsync(livroBanco => livroBanco.Id == idLivro);

                if (livro == null) {
                    resposta.Mensagem = "Nenhum registro localizado!";
                    return resposta;
                }

                resposta.Dados = livro.Autor;
                resposta.Mensagem = "Autor localizado!";
                return resposta;

            }
            catch (Exception ex) {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<AutorModel>>> ListarAutores() {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();

            try {

                var autores = await _context.Autores.ToListAsync();

                resposta.Dados = autores;
                resposta.Mensagem = "Todos os autores foram coletados!";
                return resposta;

            }
            catch (Exception ex) { 
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
    }
}
