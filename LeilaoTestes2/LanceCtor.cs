using Xunit;
using A.LeilaoOnline.Core;
using System.Linq;
using System;

namespace LeilaoTestes2
{
    public class LanceCtor
    {
        [Fact]
        public void LancaArgumentExceptionDadoValorNegativo()
        {
            var excecaoCapturada = Assert.Throws<ArgumentException>(
              () => new Lance(null, -100)
            );
        }
    }
}
