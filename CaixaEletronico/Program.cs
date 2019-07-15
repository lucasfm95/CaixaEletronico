using System;

namespace CaixaEletronico
{
    class Program
    {
        static void Main( string[] args )
        {

            Console.WriteLine( "Simulador Caixa Eletrônico.\n" );

            Menu menu = new Menu( new Caixa() );
            menu.InteracaoUsuario( );

        }
    }
}
