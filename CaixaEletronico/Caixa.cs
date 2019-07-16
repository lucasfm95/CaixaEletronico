using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CaixaEletronico
{
    public class Caixa : ICaixa
    {
        public Dictionary<int, int> Notas { get; set; } = new Dictionary<int, int>( );
        public int ValorTotalNotas { get { return Notas.Sum( x => x.Value * x.Key ); }  }

        public Caixa( List<int> notas )
        {
            foreach ( var item in notas )
            {
                Notas.Add( item, 0 );
            }
        }

        public bool Sacar( int valorSaque )
        {
            if ( ValorTotalNotas >= valorSaque )
            {
                Dictionary<int, int> notasSacadas = new Dictionary<int, int>( );

                int resto = valorSaque;

                notasSacadas = PegarNotasSaque( ref resto );

                if ( resto > 0 )
                {
                    return false;
                }
                else
                {
                    foreach ( var nota in notasSacadas )
                    {
                        Notas[nota.Key] = Notas[nota.Key] - nota.Value;
                    }
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        public Dictionary<int, int> PegarNotasSaque(ref int resto )
        {
            Dictionary<int, int> notasOrdenadas = Notas.OrderByDescending( x => x.Key ).ToList( ).FindAll( a => a.Value > 0 ).ToDictionary( x => x.Key, x => x.Value );
            Dictionary<int, int> notasSacadas = new Dictionary<int, int>( );

            foreach ( var nota in notasOrdenadas )
            {

                int qtdNotasNecessarias = resto / nota.Key;
                if ( qtdNotasNecessarias <= nota.Value )
                {
                    resto = resto % nota.Key;
                }
                else
                {
                    resto = resto - ( nota.Value * nota.Key );
                    qtdNotasNecessarias = nota.Value;
                }

                notasSacadas.Add( nota.Key, qtdNotasNecessarias );

            }

            return notasSacadas;
        }

        public bool Depositar( int nota, int quantidade )
        {
            Notas[nota] += quantidade;

            return true;
        }
    }
}
