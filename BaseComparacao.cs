using System;
using System.Collections.Generic;
using System.Text;

namespace Projet_01_Prog._Avançado
{
    class BaseComparacao
    {
        public double Recomendacao (List<double> Xs, List<double> Ys)
        {
            var distancia = Math.Sqrt((Math.Pow(Xs[0] - Xs[1], 2)) + (Math.Pow(Ys[0] - Ys[1], 2)));

            return distancia;
        }    
    }    
}
