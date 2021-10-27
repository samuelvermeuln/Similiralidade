using System;

namespace Projet_01_Prog._Avançado
{
    class Program
    {
        static void Main(string[] args)
        {
            string LocalDoBD = @"C:\Users\samuel\Documents\GitHub\Programação-Avançada C#\Projeto2PAHemera\BD.json";

            CadCandidato cadCandidato = new CadCandidato();
            CadEmpresa cadastraEmpresa = new CadEmpresa();
            CadVagas cadVagas = new CadVagas();
            Recomendacao recomendacao = new Recomendacao();

            var menu = true;

            while (menu)
            {
                Console.Clear();
                // COR DO CONSOLE
                Console.ForegroundColor = ConsoleColor.Blue;

                Console.WriteLine("");
                Console.WriteLine("");


                Console.Write("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒ COMPARAÇÃO DE SIMILARIDADE ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");

                Console.WriteLine("");
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("╔═════════════════MENU DE OPÇÕES════════════════╗");
                Console.WriteLine("║ PARA INCIAR ESCOLHA UMA OPÇÃO                 ║");
                Console.WriteLine("║ DIGITE 1️ Para Cadastro de Candidato          ║");
                Console.WriteLine("║ DIGITE 2️ Para Cadastro de Empresa            ║");
                Console.WriteLine("║ DIGITE 3️ Para Cadastro de Vagas              ║");
                Console.WriteLine("║ DIGITE 4 Lista Todos os Candidato             ║");
                Console.WriteLine("║ DIGITE 5 Lista Todos as Empresas              ║");
                Console.WriteLine("║ DIGITE 6 Lista Todos as Vagas                 ║");
                Console.WriteLine("║ DIGITE 7 Comparação Vaga com  Candidatos      ║");
                Console.WriteLine("║ DIGITE 8  PARA FINALIZAR TUDO !               ║");
                Console.WriteLine("╚═══════════════════════════════════════════════╝");
                Console.ForegroundColor = ConsoleColor.White;

                // INICO DE TUDO

                switch (Console.ReadLine())
                {
                    // ❌❌❌ 
                    case "1":

                        Console.WriteLine("══════════════════════════════════════════════");
                        cadCandidato.CadastraCandidato(LocalDoBD);
                        Console.WriteLine(@"");
                        Console.WriteLine(@"DIGITE ENTER PARA VOLTAR INICIO");
                        Console.ReadKey();
                        break;

                    // ❌❌❌  
                    case "2":

                        Console.WriteLine("══════════════════════════════════════════════");
                        cadastraEmpresa.CadastraEmpresa(LocalDoBD);
                        Console.WriteLine(@"");
                        Console.WriteLine(@"DIGITE ENTER PARA VOLTAR INICIO");
                        Console.ReadKey();
                        break;

                    // ❌❌❌  
                    case "3":
                        Console.WriteLine("══════════════════════════════════════════════");
                        cadVagas.CadastraVaga(LocalDoBD);
                        Console.WriteLine(@"");
                        Console.WriteLine(@"DIGITE ENTER PARA VOLTAR INICIO");
                        Console.ReadKey();
                        break;

                    // ❌❌❌  
                    case "4":

                        Console.WriteLine("══════════════════════════════════════════════");
                        cadCandidato.MostraCandidato(LocalDoBD);
                        Console.WriteLine(@"");
                        Console.WriteLine(@"DIGITE ENTER PARA VOLTAR INICIO");
                        Console.ReadKey();
                        break;

                    // ❌❌❌  
                    case "5":

                        Console.WriteLine("══════════════════════════════════════════════");
                        cadastraEmpresa.MostraEmpresas(LocalDoBD);
                        Console.WriteLine(@"");
                        Console.WriteLine(@"DIGITE ENTER PARA VOLTAR INICIO");
                        Console.ReadKey();
                        break;

                    // ❌❌❌  
                    case "6":

                        Console.WriteLine("══════════════════════════════════════════════");
                        cadVagas.MostraVagas(LocalDoBD);
                        Console.WriteLine(@"");
                        Console.WriteLine(@"DIGITE ENTER PARA VOLTAR INICIO");
                        Console.ReadKey();
                        break;

                    // ❌❌❌  
                    case "7":

                        //COLOCAR PARA LISTA AS VAGAS

                        Console.WriteLine("══════════════════════════════════════════════");

                        Console.WriteLine("");
                        Console.WriteLine("══════════════════ DIGITE SIM OU NÃO ═══════════════════");
                        Console.WriteLine("");

                        Console.WriteLine("\tDeseja Lista Todas as Vagas para Saber qual o nome da vaga que Deseja : ");
                        var Condicao = Console.ReadLine();

                        if(Condicao.ToLower() == "sim")
                        {
                            cadVagas.MostraVagas(LocalDoBD);
                            Console.WriteLine("══════════════════════════════════════════════");
                            Console.WriteLine("");
                            Console.WriteLine("\tO Titulo da Vaga que Deseja Verificar PARA qual candito e mais recomendado : ");
                            var TitleVaga = Console.ReadLine();
                            Console.WriteLine("");
                            Console.WriteLine("══════════════════════════════════════════════");

                            recomendacao.ListaRecomendacao(LocalDoBD, TitleVaga.ToLower());
                        }
                        else
                        {
                            Console.WriteLine("");
                            Console.WriteLine("\tO Titulo da Vaga que Deseja Verificar PARA qual candito e mais recomendado : ");
                            var TitleVaga = Console.ReadLine();
                            Console.WriteLine("");

                            Console.WriteLine("══════════════════════════════════════════════");
                            recomendacao.ListaRecomendacao(LocalDoBD, TitleVaga.ToLower());
                        }

                        Console.WriteLine(@"");
                        Console.WriteLine(@"DIGITE ENTER PARA VOLTAR INICIO");
                        Console.ReadKey();
                        break;

                    case "8":
                        Console.Clear();
                        Console.WriteLine($@" FIM ... Muito Obrigado!!");
                        menu = false;
                        break;
                }
            }
        }
    }
}
