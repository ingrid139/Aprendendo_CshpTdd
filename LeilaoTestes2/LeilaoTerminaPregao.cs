using System;
using Xunit;
using A.LeilaoOnline.Core;

namespace LeilaoTestes2
{
    public class LeilaoTerminaPregao
    {
        //classe de equivalencia - 3 testes em um (mesmo cenário)
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

            //Act - método sob teste
            leilao.TerminaPregao();

            //Assert -- automático
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
            //Act - método sob teste
            leilao.TerminaPregao();

            //Assert -- automático
            var valorEsperado = 0;
            var valorObtido = leilao.Ganhador.Valor;

            Assert.Equal(valorEsperado, valorObtido);
        }


        [Fact]
        public void LancaInvalidOperationExceptionDadopregaoNaoIniciado()
        {
            //Arrange - cenário
            var leilao = new Leilao("Van Gogh");

            //Assert
            //Assert.Throws<System.InvalidOperationException>(
            //    //Act - método sob teste
            //    () => leilao.TerminaPregao()
            //);
            var excecaoObtida = Assert.Throws<System.InvalidOperationException>(
                //Act - método sob teste
                () => leilao.TerminaPregao()
            );

            //após
            var msgEsperada = "Não é possível terminar o pregão sem que ele tenha começado. Para isso, utilize o método IniciaPregao().";
            Assert.Equal(msgEsperada, excecaoObtida.Message);
        }
    }
}
