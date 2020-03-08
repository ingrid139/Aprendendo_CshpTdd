using Xunit;
using A.LeilaoOnline.Core;
using System.Linq;
using System;

namespace LeilaoTestes2
{
    public class LeilaoRecebeOferta
    {
        [Theory]
        [InlineData(4, new double[] { 800, 900, 1000, 1200 })]
        [InlineData(3, new double[] { 800, 900, 1000 })]
        [InlineData(1, new double[] { 800 })]
        //public void LeilaoComVariosLances(double valorEsperado, double[] ofertas)
        public void NaoPermiteNovosLancesDadoLeilaoFinalizado(double qtdeEsperada, double[] ofertas)
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
            leilao.TerminaPregao();

            //Act - método sob teste
            leilao.RecebeLance(juliana, 500);

            //Assert -- automático
            var qtdeObtida = leilao.Lances.Count();

            Assert.Equal(qtdeEsperada, qtdeObtida);
        }

        //após regressão
        [Theory]
        [InlineData(new double[] { 200, 300, 400, 500 })]
        [InlineData(new double[] { 200 })]
        [InlineData(new double[] { 200, 300, 400 })]
        [InlineData(new double[] { 200, 300, 400, 500, 600, 700 })]
        public void QtdePermaneceZeroDadoQuePregaoNaoFoiIniciado(double[] ofertas)
        {
            //Arrange
            var leilao = new Leilao("Van Gogh");
            var juliana = new Interessada("Juliana", leilao);

            //act
            foreach (var valor in ofertas)
            {
                leilao.RecebeLance(juliana, valor);
            }

            //assert
            Assert.Equal(0, leilao.Lances.Count());
        }

        [Fact]
        //public void LeilaoComVariosLances(double valorEsperado, double[] ofertas)
        public void NaoAceitaProximoLanceDadoMesmoClienteRealizouUltimoLance()
        {
            //Arrange
            var leilao = new Leilao("Van Gogh");
            var juliana = new Interessada("Juliana", leilao);
            leilao.IniciaPregao();
            leilao.RecebeLance(juliana, 800);

            //Act - método sob teste
            leilao.RecebeLance(juliana, 1000);

            //Assert -- automático
            Assert.Equal(1, leilao.Lances.Count());
        }

        
    }
}
