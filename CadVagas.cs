using System;
using System.Collections.Generic;
using System.IO;
using static System.Console;
using Newtonsoft.Json.Linq;
using System.Text;
using static Projet_01_Prog._Avançado.Habilidades;

namespace Projet_01_Prog._Avançado
{
    class CadVagas : Habilidades, IHabilidades
    {
        public List<string> Skils { get ; set ; }
        public string Experiencia { get; set; }
        String Titulo { get; set; }
        String Salario { get; set; }
        String Tipo { get; set; }
        String Local { get; set; }
        String NomeEmpresa { get; set; }

        public void CadastraVaga() { }
        public void MostraVagas() { }

        public override void CadastraVaga(string CaminhoDoJson)
        {
            string LocalDoBD = CaminhoDoJson;

            List<string> teste = new List<string>();

            WriteLine("\tInforme seu Titulo davaga : ");
            var NomeVaga = Console.ReadLine();

            WriteLine("");

            WriteLine("\tInforme sua Principal Skill : ");
            var SkillCandidato = Console.ReadLine();
            teste.Add(SkillCandidato);

            WriteLine("");

            WriteLine("\tInforme sua Principal Experiencia : ");
            var ExperienciaVaga = Console.ReadLine();

            WriteLine("");

            WriteLine("\tInforme Pretensão Salarial: ");
            var SalarioVaga = Console.ReadLine();

            WriteLine("");

            WriteLine("\tInforme o Tipo ex. CLT ou PJ : ");
            var TipoVaga = Console.ReadLine();

            WriteLine("");

            WriteLine("\tEndereço ex.Bairro. : ");
            var BairroVaga = Console.ReadLine();

            WriteLine("");

            WriteLine("\tInforme seu Nome da Empresa : ");
            var NomeDaEmpresa = Console.ReadLine();

            WriteLine("");

            this.Titulo = NomeVaga;
            this.Skils = teste;
            this.Experiencia = ExperienciaVaga;
            this.Salario = SalarioVaga;
            this.Tipo = TipoVaga;
            this.Local = BairroVaga;
            this.NomeEmpresa = NomeDaEmpresa;

            string newCadastro = "{ 'titulo': " + "'" + this.Titulo.ToLower() + "'" + "," + "'skills': " + "'" + this.Skils + "'" + "," + "'experiencia': " + "'" + this.Experiencia + "'" + "," +
                "'salario': " + "'" + this.Salario + "'" + "," +
                "'tipo': " + "'" + this.Tipo + "'" + "," +
                "'local': " + "'" + this.Local + "'" + "," +
                "'nomeEmpresa': " + "'" + this.NomeEmpresa + "'" + "}";

            try
            {
                var json = File.ReadAllText(LocalDoBD);
                var jsonObj = JObject.Parse(json);

                var arrayCandidato = jsonObj.GetValue("Vagas") as JArray;

                var newCandidato = JObject.Parse(newCadastro);

                arrayCandidato.Add(newCandidato);
                jsonObj["Vagas"] = arrayCandidato;

                string novoJsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj,
                Newtonsoft.Json.Formatting.Indented);

                File.WriteAllText(LocalDoBD, novoJsonResult);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error ao NOVA Cadastrar Vaga", ex);
            }

            Console.WriteLine("NOVA vaga Cadastrar com Sucesso !");
        }

        public override void MostraVagas(string CaminhoDoJson)
        {
            string LocalDoBD = CaminhoDoJson;

            var json = File.ReadAllText(LocalDoBD);

            try
            {
                var jObject = JObject.Parse(json);

                if (jObject != null)
                {
                    JArray arrayCandidato = (JArray)jObject["Vagas"];
                    if (arrayCandidato != null)
                    {
                        WriteLine("Vagas : ");
                        foreach (var item in arrayCandidato)
                        {
                            WriteLine("\t titulo :" + item["titulo"]);
                            WriteLine("\t skills :" + item["skills"]);
                            WriteLine("\t experiencia :" + item["experiencia"]);
                            WriteLine("\t salario :" + item["salario"]);
                            WriteLine("\t tipo :" + item["tipo"]);
                            WriteLine("\t local :" + item["local"]);
                            WriteLine("\t nomeEmpresa :" + item["nomeEmpresa"].ToString());
                            WriteLine("===============================================================");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error ao Lisa Vagas", ex);
            }

            Console.WriteLine("Vagas Listadas com Sucesso !");
        }

    }
}
