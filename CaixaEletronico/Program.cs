using System;
using System.Collections.Generic;

namespace CaixaEletronico
{
    class Program
    {
        static void Main( string[] args )
        {

            Console.WriteLine( "Simulador Caixa Eletrônico.\n" );

            List<int> notas = new List<int>( );

            foreach ( var item in args )
            {
                notas.Add( Convert.ToInt32( item ) );
            }

            Menu menu = new Menu( new Caixa( notas ) );
            menu.InteracaoUsuario( );

        }
    }
}
