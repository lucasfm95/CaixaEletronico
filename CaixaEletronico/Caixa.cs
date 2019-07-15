using System;
using System.Collections.Generic;
using System.Linq;
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

        public bool Sacar( int valor )
        {
            int valorTotal = 0;

            foreach ( var nota in Notas )
            {
                valorTotal += nota.Key * nota.Value;
            }

            if ( valorTotal >= valor )
            {
                var notasDesc = Notas.OrderByDescending( x => x.Key ).ToList().FindAll(a => a.Value > 0).ToDictionary( x => x.Key, x => x.Value );

                Dictionary<int, int> valorSacado = new Dictionary<int, int>( );

                int resto = valor;
                int subTotal = valor;

                foreach ( var nota in notasDesc )
                {
                    
                    int qtdNotasNecessarias = resto / nota.Key;
                    if ( qtdNotasNecessarias <= nota.Value )
                    {
                        resto = resto % nota.Key;
                    }
                    else
                    {
                        resto = ( resto - ( nota.Value * nota.Key ) );
                        qtdNotasNecessarias = nota.Value;
                    }

                    valorSacado.Add( nota.Key, qtdNotasNecessarias );

                }

                if ( resto > 0 )
                {
                    return false;
                }
                else
                {
                    foreach ( var nota in valorSacado )
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

        public bool Depositar( int nota, int quantidade )
        {
            Notas[nota] += quantidade;

            return true;
        }
    }
}
