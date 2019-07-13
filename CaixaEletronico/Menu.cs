using System;
using System.Collections.Generic;
using System.Text;

namespace CaixaEletronico
{
    public class Menu
    {
        private readonly ICaixa _caixa;
        public Menu(ICaixa caixa )
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
                Console.WriteLine( "4 - Sair" );

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
                        break;
                    default:
                        Console.WriteLine( "Infome uma opção válida" );
                        break;
                }

            } while ( programaEmLoop );
        }

        private void DepositarNotas( )
        {
            Console.WriteLine("Informe a nota que deseja carregar : ");

            foreach ( var nota in _caixa.Notas )
            {
                Console.WriteLine($"{nota.Key} Reais" );
            }

            int notaSelecionada = Convert.ToInt32( Console.ReadLine( ) );

            Console.WriteLine("Informe a quantidade de notas que deseja inserir: ");

            int quantidade = Convert.ToInt32( Console.ReadLine( ) );

            if ( _caixa.Depositar( notaSelecionada, quantidade ) )
            {
                Console.WriteLine("Deposito efetuado com sucesso");
            }
        }

        private void SacarNotas( )
        {
            Console.WriteLine("Informe o valor que deseja sacar: ");
            int valorSacar = Convert.ToInt32( Console.ReadLine( ) );

            if ( _caixa.Sacar( valorSacar ) )
            {
                Console.WriteLine("Saque efetuado com sucesso");
            }
        }

        private void RelatorioNotas( )
        {
            foreach ( var nota in _caixa.Notas )
            {
                Console.WriteLine($"{nota.Key} reais - R${nota.Key * nota.Value},00");
            }
        }
    }
}
