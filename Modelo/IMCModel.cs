using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Modelo
{
    public class IMCModel
    {
        public double Peso {  get; set; }
        public double Altura { get; set; }

        public double CalcularIMC()
        {
            if (Altura > 0)
                return Peso / (Altura * Altura);
            return 0;
        }
    }
}
