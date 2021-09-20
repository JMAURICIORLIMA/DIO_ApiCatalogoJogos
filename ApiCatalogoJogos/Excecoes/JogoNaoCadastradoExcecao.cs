using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Excecoes
{
    public class JogoNaoCadastradoExcecao : Exception
    {
        public JogoNaoCadastradoExcecao() : base("Jogo não cadastrado. ")
        { }
    }
}
