using System;
using A.LeilaoOnline.Core;

namespace A.LeilaoOnline.ConsoleApp
{
    class Program
    {
        static void Main()
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

            //Assert -- não automatico
            Console.WriteLine(leilao.Ganhador.Valor);

            //Assert -- automático
            var valorEsperado = 1000;
            var valorObtido = leilao.Ganhador.Valor;

            if (valorEsperado == valorObtido)
            {
                Console.WriteLine("Teste Ok");
            }
            else
            {
                Console.WriteLine("Teste Falhou");
            }

            Console.ReadKey();

        }
    }
}
