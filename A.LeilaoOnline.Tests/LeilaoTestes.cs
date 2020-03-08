using Xunit;
using A.LeilaoOnline.Core;

namespace A.LeilaoOnline.Tests
{
    //class LeilaoTestes
    public class LeilaoTestes
    {
        [Fact]
        public void LeilaoComTresClientes()
        {
            //Arrange
            var leilao = new Leilao("Van Gogh");
            var juliana = new Interessada("Juliana", leilao);
            var maria = new Interessada("Maria", leilao);
            var roberta = new Interessada("Roberta", leilao);

            //add após modificar a classe (AntesDoPregao) - testes de regressão 
            leilao.IniciaPregao();

            leilao.RecebeLance(juliana, 800);
            leilao.RecebeLance(maria, 900);
            leilao.RecebeLance(juliana, 1000);
            leilao.RecebeLance(roberta, 1200);

            //depois de rodar a primeira vez
            leilao.RecebeLance(maria, 990);

            //Act - método sob teste
            leilao.TerminaPregao();

            //Assert -- automático
            //var valorEsperado = 1000;
            var valorEsperado = 1200;
            var valorObtido = leilao.Ganhador.Valor;

            Assert.Equal(valorEsperado, valorObtido);
            Assert.Equal(roberta, leilao.Ganhador.Cliente);
        }

        [Fact]
        public void LeilaoComVariosLances()
        {

            //Arrange
            var leilao = new Leilao("Van Gogh");
            var juliana = new Interessada("Juliana", leilao);
            var maria = new Interessada("Maria", leilao);

            leilao.IniciaPregao();

            leilao.RecebeLance(juliana, 800);
            leilao.RecebeLance(maria, 900);
            leilao.RecebeLance(juliana, 1000);

            //depois de rodar a primeira vez
            leilao.RecebeLance(maria, 990);

            //Act - método sob teste
            leilao.TerminaPregao();

            //Assert -- automático
            var valorEsperado = 1000;
            //var valorEsperado = 1200;
            var valorObtido = leilao.Ganhador.Valor;

            Assert.Equal(valorEsperado, valorObtido);
        }

        [Fact]
        public void LeilaoComApenasUmLances()
        {
            //Arrange
            var leilao = new Leilao("Van Gogh");
            var juliana = new Interessada("Juliana", leilao);
            
            leilao.IniciaPregao();

            leilao.RecebeLance(juliana, 800);

            //Act - método sob teste
            leilao.TerminaPregao();

            //Assert -- automático
            var valorEsperado = 800;
            var valorObtido = leilao.Ganhador.Valor;

            Assert.Equal(valorEsperado, valorObtido);

        }

        [Fact]
        public void LeilaoSemLance()
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
    }
}
