using System;
using Xunit;
using A.LeilaoOnline.Core;

namespace LeilaoTestes2
{
    public class LeilaoTerminaPregao
    {
        //classe de equivalencia - 3 testes em um (mesmo cen�rio)
        [Theory]
        [InlineData(1200, new double[] { 800, 900, 1000, 1200 })]
        [InlineData(1000, new double[] { 800, 900, 1000, 990 })]
        [InlineData(800, new double[] { 800 })]
        //public void LeilaoComVariosLances(double valorEsperado, double[] ofertas)
        public void RetornaMaiorValorDadoLeilaoComPeloMenosUmLance(double valorEsperado, double[] ofertas)
        {
            //Arrange
            var leilao = new Leilao("Van Gogh");
            var juliana = new Interessada("Juliana", leilao);
            var mariana = new Interessada("Mariana", leilao);

            leilao.IniciaPregao();
            for (int i = 0; i < ofertas.Length; i++)
            {
                var valor = ofertas[i];
                if ((i % 2) == 0)
                {
                    leilao.RecebeLance(juliana, valor);
                }
                else
                {
                    leilao.RecebeLance(mariana, valor);
                }
            }

            //Act - m�todo sob teste
            leilao.TerminaPregao();

            //Assert -- autom�tico
            var valorObtido = leilao.Ganhador.Valor;

            Assert.Equal(valorEsperado, valorObtido);
        }

        [Fact]
        //public void LeilaoSemLance()
        public void RetornaZeroDadoLeilaoSemLances()
        {
            //Arrange
            var leilao = new Leilao("Van Gogh");
            leilao.IniciaPregao();
            //Act - m�todo sob teste
            leilao.TerminaPregao();

            //Assert -- autom�tico
            var valorEsperado = 0;
            var valorObtido = leilao.Ganhador.Valor;

            Assert.Equal(valorEsperado, valorObtido);
        }


        [Fact]
        public void LancaInvalidOperationExceptionDadopregaoNaoIniciado()
        {
            //Arrange - cen�rio
            var leilao = new Leilao("Van Gogh");

            //Assert
            //Assert.Throws<System.InvalidOperationException>(
            //    //Act - m�todo sob teste
            //    () => leilao.TerminaPregao()
            //);
            var excecaoObtida = Assert.Throws<System.InvalidOperationException>(
                //Act - m�todo sob teste
                () => leilao.TerminaPregao()
            );

            //ap�s
            var msgEsperada = "N�o � poss�vel terminar o preg�o sem que ele tenha come�ado. Para isso, utilize o m�todo IniciaPregao().";
            Assert.Equal(msgEsperada, excecaoObtida.Message);
        }
    }
}
