using System;
using System.Collections.Generic;
using System.IO;
using static System.Console;
using Newtonsoft.Json.Linq;
using static Projet_01_Prog._Avançado.Habilidades;
using System.Linq;

namespace Projet_01_Prog._Avançado
{
    class CadCandidato : Habilidades, IHabilidades
    {
        public List<string> Skils { get; set ; }
        public string Experiencia { get ; set ; }
        string PretencaoSalarial { get; set; }
        
        public void CadastraCandidato(){}

        public void MostraCandidato() { }

        public override void CadastraCandidato(string CaminhoDoJson)
        {
            string LocalDoBD = CaminhoDoJson;

            List<string> teste = new List<string>();

            WriteLine("\tInforme seu Nome : ");
            var NomeCandidato = Console.ReadLine();

            WriteLine("");

            WriteLine("\tInforme o Telefone : ");
            var TelefoneCanidado = Console.ReadLine();

            int value = 1;

            if (value == 1)
            {
                var samuel = true;
                while (samuel)
                {
                    WriteLine(Skils);

                    WriteLine("\n");
                    WriteLine("Deseja Adicionar uma nova Skill");
                    WriteLine("Digite 1 para Sim");
                    WriteLine("Digite 2 para Não");

                    switch (Console.ReadLine())
                    {
                        case "1":

                            WriteLine("\nInforme sua Skill : ");
                            var SkillCandidato = Console.ReadLine();
                            teste.Add(SkillCandidato);
                            break;

                        case "2":
                            samuel = false;
                            break;
                    }
                }
            }

            WriteLine("");

            WriteLine("\tInforme o E-mail : ");
            var EmailCandidato = Console.ReadLine();

            WriteLine("");

            WriteLine("\tEndereço ex.Bairro. : ");
            var BairroCandidato = Console.ReadLine();

            WriteLine("");

            WriteLine("\tInforme sua Principal Experiencia : ");
            var ExperienciaCandidato = Console.ReadLine();

            WriteLine("");

            WriteLine("\tInforme Pretensão Salarial: ");
            var SalarioCandidato = Console.ReadLine();

            WriteLine("");

            Nome = NomeCandidato;
            Telefone = TelefoneCanidado;
            Email = EmailCandidato;
            Endereco = BairroCandidato;
            Skils = teste;
            Experiencia = ExperienciaCandidato;
            PretencaoSalarial = SalarioCandidato;

            string newCadastro = "{ 'nome': " + "'" + Nome + "'" + "," + "'telefone': " + "'" + Telefone + "'" + "," + "'email': " + "'" + Email + "'" + "," +
                "'endereco': " + "'" + Endereco + "'" + "," +
                "'skills': " + "'" + Skils.Aggregate((x, y) => x + ", " + y) + "'" + "," +
                "'experiencia': " + "'" + Experiencia + "'" + "," +
                "'pretensaoSalarial': " + "'" + PretencaoSalarial + "'" + "}";

            try
            {
                var json = File.ReadAllText(LocalDoBD);
                var jsonObj = JObject.Parse(json);

                var arrayCandidato = jsonObj.GetValue("Candidato") as JArray;

                var newCandidato = JObject.Parse(newCadastro);

                arrayCandidato.Add(newCandidato);
                jsonObj["Candidato"] = arrayCandidato;

                string novoJsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj,
                Newtonsoft.Json.Formatting.Indented);

                File.WriteAllText(LocalDoBD, novoJsonResult);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error ao Cadastrar Candidato", ex);
            }
        }

        public override void MostraCandidato (string CaminhoDoJson)
        {
            string LocalDoBD = CaminhoDoJson;

            var json = File.ReadAllText(LocalDoBD);

            try
            {
                var jObject = JObject.Parse(json);

                if (jObject != null)
                {
                    JArray arrayCandidato = (JArray)jObject["Candidato"];

                    if (arrayCandidato != null)
                    {
                        WriteLine("Candidados : ");
                        foreach (var item in arrayCandidato)
                        {
                            WriteLine("\tNome :" + item["nome"]);
                            WriteLine("\tTelefone :" + item["telefone"]);
                            WriteLine("\tEmail :" + item["email"]);
                            WriteLine("\tEndereço :" + item["endereco"]);
                            WriteLine("\tSkills :" + item["skills"].ToString().Split(',').Length);
                            WriteLine("\tExperiencia :" + item["experiencia"]);
                            WriteLine("\tPretensaoSalarial :" + item["pretensaoSalarial"].ToString());
                            WriteLine("===============================================================");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(" Error ao Listar Candidato", ex);
            }

            Console.WriteLine("Candidato Listado com Sucesso !");
        }

    }
}
