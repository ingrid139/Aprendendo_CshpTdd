﻿using System;
using A.LeilaoOnline.Core;

namespace A.LeilaoOnline.ConsoleApp2
{
    class Program
    {

        private static void Verifica(double esperado, double obtido)
        {
            var cor = Console.ForegroundColor;
            if (esperado == obtido)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Teste Ok");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Teste Falhou");
            }
            Console.ForegroundColor = cor;
        }
        private static void LeilaoComVariosLances()
        {
            //processo que acontece para verificar os requisitos
            //substituir trabalho humano por maquina
            //Como garantir que meu sistema não tem problemas ou defeitos?

            //Arrange
            var leilao = new Leilao("Van Gogh");
            var juliana = new Interessada("Juliana", leilao);
            var maria = new Interessada("Maria", leilao);


            leilao.RecebeLance(juliana, 800);
            leilao.RecebeLance(maria, 900);
            leilao.RecebeLance(juliana, 1000);

            //depois de rodar a primeira vez
            leilao.RecebeLance(maria, 990);

            //Act - método sob teste
            leilao.TerminaPregao();

            //Assert -- automático
            //var valorEsperado = 1000;
            var valorEsperado = 1200;
            var valorObtido = leilao.Ganhador.Valor;

            Verifica(valorEsperado, valorObtido);
            //if (valorEsperado == valorObtido)
            //{
            //    Console.WriteLine("Teste Ok");
            //}
            //else
            //{
            //    Console.WriteLine("Teste Falhou");
            //}
        }

        private static void LeilaoComApenasUmLances()
        {
            //processo que acontece para verificar os requisitos
            //substituir trabalho humano por maquina
            //Como garantir que meu sistema não tem problemas ou defeitos?

            //Arrange
            var leilao = new Leilao("Van Gogh");
            var juliana = new Interessada("Juliana", leilao);

            leilao.RecebeLance(juliana, 800);

            //Act - método sob teste
            leilao.TerminaPregao();

            //Assert -- automático
            var valorEsperado = 800;
            var valorObtido = leilao.Ganhador.Valor;

            Verifica(valorEsperado, valorObtido);

            //if (valorEsperado == valorObtido)
            //{
            //    Console.WriteLine("Teste Ok");
            //}
            //else
            //{
            //    Console.WriteLine("Teste Falhou");
            //}
        }

        static void Main()
        {
            LeilaoComVariosLances();
            LeilaoComApenasUmLances();

            Console.ReadKey();

        }
    }
}
