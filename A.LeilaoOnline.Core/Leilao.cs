using System.Collections.Generic;
using System.Linq;

namespace A.LeilaoOnline.Core
{
    public enum EstadoLeilao
    {
        AntesDoPregao,
        EmAndamento,
        Finalizado
    }
    public class Leilao
    {
        private Interessada _ultimoCliente;
        private IList<Lance> _lances;
        public IEnumerable<Lance> Lances => _lances;
        public string Peca { get; }
        public Lance Ganhador { get; private set; }
        public EstadoLeilao Estado { get; private set; }

        public Leilao(string peca)
        {
            Peca = peca;
            _lances = new List<Lance>();
            Estado = EstadoLeilao.AntesDoPregao;
        }
        private bool NovoLanceAceito(Interessada cliente, double valor)
        {
            return (Estado == EstadoLeilao.EmAndamento && cliente != _ultimoCliente);
        }

        public void RecebeLance(Interessada cliente, double valor)
        {
            //_lances.Add(new Lance(cliente, valor));
            //if(Estado == EstadoLeilao.EmAndamento)
            //{
            //    _lances.Add(new Lance(cliente, valor));
            //}
            if (NovoLanceAceito(cliente, valor))
            {
                _lances.Add(new Lance(cliente, valor));
                _ultimoCliente = cliente;
            }

        }

        public void IniciaPregao()
        {
            Estado = EstadoLeilao.EmAndamento;
        }

        public void TerminaPregao()
        {
            //Ganhador = Lances.Last();
            //Ganhador = Lances.OrderBy(l => l.Valor).Last();
            if(Estado != EstadoLeilao.EmAndamento)
            {
                //throw new System.InvalidOperationException();
                throw new System.InvalidOperationException("Não é possível terminar o pregão sem que ele tenha começado. Para isso, utilize o método IniciaPregao().");
            }
            Ganhador = Lances.DefaultIfEmpty(new Lance(null, 0)).OrderBy(l => l.Valor).Last();
            Estado = EstadoLeilao.Finalizado;
        }
    }
}
