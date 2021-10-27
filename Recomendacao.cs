using System;
using System.Collections.Generic;
using System.IO;
using static System.Console;
using Newtonsoft.Json.Linq;
using static Projet_01_Prog._Avançado.Habilidades;
using System.Linq;

namespace Projet_01_Prog._Avançado
{
    class Recomendacao
    {

        public void ListaRecomendacao(string CaminhoDoJson, string TituloVaga)
        {
            BaseComparacao baseComparacao = new BaseComparacao();

            string LocalDoBD = CaminhoDoJson;

            var json = File.ReadAllText(LocalDoBD);

            List<double> ListaVagas = new List<double>();// Lista recebe os valores da empresa para comparar
            List<double> ListaDeUsers = new List<double>();// Lista recebe os valores de cada usuario

            List<OrdenacaoComparacao> Ordem = new List<OrdenacaoComparacao>();// Lista que recebe e ordena o return da recomendação

            try
            {
                var jObject = JObject.Parse(json);

                if (jObject != null)
                {
                    JArray arrayCandidato = (JArray)jObject["Candidato"];
                    JArray arrayVagas = (JArray)jObject["Vagas"];

                    if (arrayCandidato != null)
                    {
                        // Pega a Empresa que voce quer comparar e coloca em uma lista
                        for (int i = 0; i < arrayVagas.Count(); i++)
                        {
                            if (arrayVagas[i]["titulo"].ToString() == TituloVaga)
                            {
                                var NomeEmpresa = arrayVagas[i]["titulo"].ToString();

                                WriteLine("\t\nVOCÊ ESCOLHEU A EMPRESA => {0} <= PARA FAZER A COMPARAÇÃO", NomeEmpresa);
                                WriteLine("");

                                var xVagas = arrayVagas[i]["skills"].ToString().Split(',').Length;

                                var yVagas = arrayVagas[i]["experiencia"];
                                var ConvY = Convert.ToInt32(yVagas);

                                ListaVagas.Add(xVagas);
                                ListaVagas.Add(ConvY);

                            }
                        }
                        //quanto menor mais proximo

                        for (int i = 0; i < arrayCandidato.Count(); i++)
                        {
                            var numYs = arrayCandidato[i]["experiencia"];
                            var yCandidato = Convert.ToInt32(numYs);

                            var xCandidato = arrayCandidato[i]["skills"].ToString().Split(',').Length;

                            //Limpa A lista
                            ListaDeUsers.Clear();

                            ListaDeUsers.Add(xCandidato);
                            ListaDeUsers.Add(yCandidato);

                            var Correlacao = baseComparacao.Recomendacao(ListaVagas, ListaDeUsers);

                            var Candidato = arrayCandidato[i]["nome"].ToString();

                            Ordem.Add(new OrdenacaoComparacao(Correlacao, Candidato));
                        }

                        foreach (var item in Ordem.Select((x, index) => (x, index)).OrderBy(y => y.x.ResultadoDaRecomendacao))
                        {

                            if ( item.index == 1)
                            {
                                WriteLine("==============MAIS RECOMENDADO==================");
                                WriteLine("");
                                WriteLine("O Algoritimo recomendou o Candidato: {0}", item.x.NomeCandidato);
                                WriteLine("Resultado da Recomendação:{0}", item.x.ResultadoDaRecomendacao);
                                WriteLine("");
                                WriteLine("================================================");
                                WriteLine("");
                            }
                            else if( item.index != 1)
                            {
                                WriteLine("\tCANDIDATO MENOS RECOMENDADO");
                                WriteLine("Nome: {0}", item.x.NomeCandidato);
                                WriteLine("Resultado da Recomendação: {0}", item.x.ResultadoDaRecomendacao);
                                WriteLine("\n================================================");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(" Error Lista Recomendacao", ex);
            }

            Console.WriteLine("\t ============= Sucesso! =============");
        }

    }
}
