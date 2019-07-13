using System;
using System.Collections.Generic;
using System.Text;

namespace CaixaEletronico
{
    public interface ICaixa
    {
        Dictionary<int, int> Notas { get; set; }
        bool Depositar( int nota, int quantidade ); 
        bool Sacar( int value );
    }
}
