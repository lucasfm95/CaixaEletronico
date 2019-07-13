using System;
using System.Collections.Generic;
using System.Text;

namespace CaixaEletronico
{
    public class Caixa : ICaixa
    {
        public Dictionary<int, int> Notas { get; set; } = new Dictionary<int, int>( );

        public Caixa( )
        {
            Notas.Add( 10, 0 );
            Notas.Add( 20, 0 );
            Notas.Add( 50, 0 );
        }

        public bool Sacar( int value )
        {
            throw new NotImplementedException( );
        }

        public bool Depositar( int nota, int quantidade )
        {
            Notas[nota] += quantidade;

            return true;
        }
    }
}
