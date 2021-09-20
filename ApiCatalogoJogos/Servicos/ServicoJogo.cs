using ApiCatalogoJogos.Entidades;
using ApiCatalogoJogos.Excecoes;
using ApiCatalogoJogos.ModeloEntrada;
using ApiCatalogoJogos.Repositorio;
using ApiCatalogoJogos.VerModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Servicos
{
    public class ServicoJogo : ItfServicoJogo
    {
        private readonly ItfRepositorioJogo _repositorioJogo;

        public ServicoJogo(ItfRepositorioJogo repositorioJogo)
        {
            _repositorioJogo = repositorioJogo;
        }

        public async Task<List<VerModeloJogo>> Obter(int pagina, int quantidade)
        {
            var jogos = await _repositorioJogo.Obter(pagina, quantidade);

            return jogos.Select(jogo => new VerModeloJogo
            {
                Id = jogo.Id,
                Nome = jogo.Nome,
                Produtora = jogo.Produtora,
                Preco = jogo.Preco
            }).ToList();

        }

        public async Task<VerModeloJogo> Obter(Guid id)
        {
            var jogo = await _repositorioJogo.Obter(id);

            if (jogo == null)
                return null;

            return new VerModeloJogo
            {
                Id = jogo.Id,
                Nome = jogo.Nome,
                Produtora = jogo.Produtora,
                Preco = jogo.Preco
            };
        }

        public async Task<VerModeloJogo> Inserir(ModeloEntradaJogo jogo)
        {
            var entidadeJogo = await _repositorioJogo.Obter(jogo.Nome, jogo.Produtora);

            if (entidadeJogo.Count > 0)
                throw new JogoJaCadastradoExcecao();

            var inserirJogo = new Jogo
            {
                Id = Guid.NewGuid(),
                Nome = jogo.Nome,
                Produtora = jogo.Produtora,
                Preco = jogo.Preco
            };

            await _repositorioJogo.Inserir(inserirJogo);

            return new VerModeloJogo
            {
                Id = inserirJogo.Id,
                Nome = jogo.Nome,
                Produtora = jogo.Produtora,
                Preco = jogo.Preco
            };
        }

        public async Task Atualizar(Guid id, ModeloEntradaJogo jogo)
        {
            var entidadeJogo = await _repositorioJogo.Obter(id);

            if (entidadeJogo == null)
                throw new JogoNaoCadastradoExcecao();

            entidadeJogo.Nome = jogo.Nome;
            entidadeJogo.Produtora = jogo.Produtora;
            entidadeJogo.Preco = jogo.Preco;

            await _repositorioJogo.Atualizar(entidadeJogo);
        }

        public async Task Atualizar(Guid id, double preco)
        {
            var entidadeJogo = await _repositorioJogo.Obter(id);

            if (entidadeJogo == null)
                throw new JogoNaoCadastradoExcecao();

            entidadeJogo.Preco = preco;

            await _repositorioJogo.Atualizar(entidadeJogo);
        }

        public async Task Remover(Guid id)
        {
            var jogo = await _repositorioJogo.Obter(id);

            if (jogo == null)
                throw new JogoNaoCadastradoExcecao();

            await _repositorioJogo.Remover(id);
        }

        public void Dispose() //Após exclusão, encerra conexão com banco.
        {
            _repositorioJogo?.Dispose();
        }
    }
}
