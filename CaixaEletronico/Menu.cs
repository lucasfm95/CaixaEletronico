using System;
using System.Collections.Generic;
using System.Text;

namespace CaixaEletronico
{
    public class Menu
    {
        private readonly ICaixa _caixa;
        public Menu( ICaixa caixa )
        {
            _caixa = caixa;
        }

        public void InteracaoUsuario( )
        {
            bool programaEmLoop = true;

            do
            {
                Console.WriteLine( "Escolha uma opção: " );
                Console.WriteLine( "1 - Carregar notas" );
                Console.WriteLine( "2 - Saque" );
                Console.WriteLine( "3 - Saldo" );
                Console.WriteLine( "4 - Sair\n" );

                int opcaoSelecionada = Convert.ToInt32( Console.ReadLine( ) );

                switch ( opcaoSelecionada )
                {
                    case 1:
                        DepositarNotas( );
                        break;
                    case 2:
                        SacarNotas( );
                        break;
                    case 3:
                        RelatorioNotas( );
                        break;
                    case 4:
                        programaEmLoop = false;
                        Console.Clear( );
                        break;
                    default:
                        Console.Clear( );
                        Console.WriteLine( "Infome uma opção válida.\n" );
                        break;
                }

            } while ( programaEmLoop );
        }

        private void DepositarNotas( )
        {
            Console.Clear( );
            Console.WriteLine( "Informe a nota que deseja carregar:\n" );

            foreach ( var nota in _caixa.Notas )
            {
                Console.WriteLine( $"{nota.Key} Reais" );
            }

            Console.WriteLine( "" );

            int notaSelecionada = Convert.ToInt32( Console.ReadLine( ) );

            Console.Clear( );
      
            Console.WriteLine( "Informe a quantidade de notas que deseja inserir:\n" );

            int quantidade = Convert.ToInt32( Console.ReadLine( ) );

            if ( _caixa.Depositar( notaSelecionada, quantidade ) )
            {
                Console.Clear( );
                Console.WriteLine( "Deposito efetuado com sucesso.\n" );
            }
        }

        private void SacarNotas( )
        {
            Console.Clear( );
            Console.WriteLine( "Informe o valor que deseja sacar:\n" );
            int valorSacar = Convert.ToInt32( Console.ReadLine( ) );

            if ( _caixa.Sacar( valorSacar ) )
            {
                //Console.Clear( );
                Console.WriteLine( "Saque efetuado com sucesso" );
            }
            else
            {
                Console.WriteLine( "Não é possível sacar esse valor" );
            }
        }

        private void RelatorioNotas( )
        {
            Console.Clear( );
            foreach ( var nota in _caixa.Notas )
            {
                Console.WriteLine( $"{nota.Value} de {nota.Key} reais - R${nota.Key * nota.Value},00" );
            }
            Console.WriteLine($"Saldo total de R$ {_caixa.ValorTotalNotas},00" );
            Console.WriteLine( "" );
        }
    }
}
