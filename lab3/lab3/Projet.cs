using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    internal class Projet
    {
        string numero;
        string dateDebut;
        int budget;
        string description;
        string employe;

        public string Numero { get => numero; set => numero = value; }
        public string DateDebut { get => dateDebut; set => dateDebut = value; }
        public int Budget { get => budget; set => budget = value; }
        public string Description { get => description; set => description = value; }
        public string Employe { get => employe; set => employe = value; }
        

        public override string ToString()
        {
            return numero + " " + dateDebut + " " + budget + " " + description + " " + employe;
        }
    }
}
