using ApiCatalogoJogos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Repositorio
{
    public interface ItfRepositorioJogo : IDisposable
    {
        Task<List<Jogo>> Obter(int pagina, int quantidade);
        Task<Jogo> Obter(Guid id);
        Task<List<Jogo>> Obter(string nome, string produtora);
        Task Atualizar(Jogo jogo);  //***
        Task Inserir(Jogo jogo);
        Task Remover(Guid id);
    }
}
