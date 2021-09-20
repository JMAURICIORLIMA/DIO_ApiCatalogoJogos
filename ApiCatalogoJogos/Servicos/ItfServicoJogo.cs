using ApiCatalogoJogos.ModeloEntrada;
using ApiCatalogoJogos.VerModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Servicos
{
    public interface ItfServicoJogo : IDisposable
    {
        Task<List<VerModeloJogo>> Obter(int pagina, int quantidade); //Lista de Jogos
        Task<VerModeloJogo> Obter(Guid id); //Obter apenas um Jogo
        Task<VerModeloJogo> Inserir(ModeloEntradaJogo jogo); //Inserir Jogo
        Task Atualizar(Guid id, ModeloEntradaJogo jogo); //Atualizar tudo
        Task Atualizar(Guid id, double preco); //Atualizar preço
        Task Remover(Guid id); //Excluir
    }
}
