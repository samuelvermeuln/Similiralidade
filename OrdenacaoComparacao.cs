using System;
using System.Collections.Generic; 
using System.Text;

namespace Projet_01_Prog._Avançado
{
    public class OrdenacaoComparacao 
    {
        public string NomeCandidato { get; set; }
        public double ResultadoDaRecomendacao { get; set; }


        public OrdenacaoComparacao(double correlacao, string candidato)
        {
            NomeCandidato = candidato;
            ResultadoDaRecomendacao = correlacao;
            //Console.WriteLine("Nome {0} / Resultado {1}", NomeCandidato, ResultadoDaRecomendacao);
        }
    }
}
