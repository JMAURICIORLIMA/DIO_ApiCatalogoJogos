using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Excecoes
{
    public class JogoJaCadastradoExcecao : Exception
    {
        public JogoJaCadastradoExcecao() : base("Este jogo já está cadastrado. ")
        { }
    }
}
