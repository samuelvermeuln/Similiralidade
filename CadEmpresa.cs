using System;
using System.Collections.Generic;
using System.IO;
using static System.Console;
using Newtonsoft.Json.Linq;

using System.Text;

namespace Projet_01_Prog._Avançado
{
    class CadEmpresa : Habilidades
    {
        private String Cnpj { get; set; }

        public void CadastraEmpresa() { }

        public override void CadastraEmpresa(string CaminhoDoJson)
        {
            string LocalDoBD = CaminhoDoJson;

            WriteLine("\tQual o nome da Empresa : ");
            var NomeEmpresa = Console.ReadLine();

            WriteLine("");

            WriteLine("\tInforme o CNPJ : ");
            var NumeroCNPJ = Console.ReadLine();

            WriteLine("");

            WriteLine("\tEndereço da empresa ex.Bairro. : ");
            var BairroEmpresa = Console.ReadLine();

            WriteLine("");

            WriteLine("\tInforme o Tefone : ");
            var TelefoneEmpresa = Console.ReadLine();

            WriteLine("");

            WriteLine("\tInforme o E-mail : ");
            var EmailEmpresa = Console.ReadLine();

            WriteLine("");

            Nome = NomeEmpresa;
            this.Cnpj = NomeEmpresa;
            Endereco = BairroEmpresa;
            Telefone = TelefoneEmpresa;
            Email = EmailEmpresa;

            string newCadastro = "{ 'nome': " + "'" + Nome + "'" + "," + "'telefone': " + "'" + this.Cnpj + "'" + "," + "'email': " + "'" + Endereco + "'" + "," +
            "'endereco': " + "'" + Telefone + "'" + "," +
            "'skills': " + "'" + Email + "'" + "," + "}";

            try
            {
                var json = File.ReadAllText(LocalDoBD);
                var jsonObj = JObject.Parse(json);

                var arrayCandidato = jsonObj.GetValue("Empresa") as JArray;

                var newEmpresa = JObject.Parse(newCadastro);

                arrayCandidato.Add(newEmpresa);
                jsonObj["Empresa"] = arrayCandidato;

                string novoJsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj,
                Newtonsoft.Json.Formatting.Indented);

                File.WriteAllText(LocalDoBD, novoJsonResult);
            }
            catch (Exception ex)
            {
                Console.WriteLine(" Error ao Cadastrar Empresa", ex);
            }

            Console.WriteLine("Nova Empresa Cadastrada com Sucesso !");
        }

        public override void MostraEmpresas(string CaminhoDoJson)
        {
            string LocalDoBD = CaminhoDoJson;

            var json = File.ReadAllText(LocalDoBD);

            try
            {
                var jObject = JObject.Parse(json);

                if (jObject != null)
                {
                    JArray arrayCandidato = (JArray)jObject["Empresa"];
                    if (arrayCandidato != null)
                    {
                        WriteLine("Empresa : ");
                        foreach (var item in arrayCandidato)
                        {
                            WriteLine("\tNome :" + item["nome"]);
                            WriteLine("\tCnpj :" + item["cnpj"]);
                            WriteLine("\tEndereço :" + item["endereco"]);
                            WriteLine("\tTelefone :" + item["telefone"]);
                            WriteLine("\tEmail :" + item["email"]);
                            WriteLine("===============================================================");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(" Error ao Listar Empresas", ex);
            }

            Console.WriteLine("Empresas Listadas com Sucesso !");
        }
    
    }
}
