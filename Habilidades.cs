using System;
using System.Collections.Generic;
using System.Text;

namespace Projet_01_Prog._Avançado
{
    class Habilidades : Cadastro
    {
        public interface IHabilidades
        {
            List<string> Skils { get; set; }
            string Experiencia { get; set; }
        }
    }
}
