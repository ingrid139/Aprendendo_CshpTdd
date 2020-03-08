using System;
using System.Collections.Generic;
using System.Text;

namespace A.LeilaoOnline.Core
{
    public class Lance
    {
        public Interessada Cliente { get; }
        public double Valor { get; }

        public Lance(Interessada cliente, double valor)
        {
            if (valor < 0)
            {
                throw new ArgumentException("Lance inválido: valor deve ser maior que zero.");
            }
            Cliente = cliente;
            Valor = valor;
        }
    }
}
