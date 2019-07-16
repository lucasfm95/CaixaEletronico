using System;
using System.Collections.Generic;
using System.Text;

namespace CaixaEletronico
{
    public interface ICaixa
    {
        Dictionary<int, int> Notas { get; set; }
        int ValorTotalNotas { get; }
        bool Depositar( int nota, int quantidade ); 
        bool Sacar( int valor );
    }
}
