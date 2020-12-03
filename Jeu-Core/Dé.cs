using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProblemeFinal_Gatinois_Marion_GroupeD
{
    class Dé
    {
        string[] ensembleLettres ;  
        string lettre ;

        public Dé ()
        {
            this.ensembleLettres = new string[6];///dé 6 faces
            this.lettre = " ";
             ///on relie le fichier au constructeur pour ne pas à avoir à appeler la fonction ReadFile dans le Main et que ça se fasse automatiquement quand on va utiliser/appeler la classe Dé
        }

        public string Lettre 
        {
            get
            {
                return this.lettre;
            }
        }
        public string[] EnsembleLettre
        {
            get
            {
                return this.ensembleLettres;
            }
            set
            {
                this.ensembleLettres = value; 
            }
        }


        /// <summary>
        /// lance le dé
        /// </summary>
        /// <param name="r">r nombre aléatoire</param>
        public void Lance(Random r)
        {
            int i = r.Next(0, 5);/// le nombre au hasard correspondra a la place de la valeur que l'on va prendre dans le tableau
            this.lettre = this.ensembleLettres[i]; //la lettre prend une valeur entre la 1ere et la dernière valeur du tableau (0 à 5 pour 6 cases) 
        }

        public string toString()
        {
            string TotalLettre = ""; ///on affiche l'ensemble des lettres du tableau
            for (int i = 0; i < this.ensembleLettres.Length; i++)
            {
                TotalLettre = TotalLettre + this.ensembleLettres[i] + " ; ";
            }

            return "Le dé est composé d'une ensemble de lettres :" + TotalLettre + " dont la lettre choisie au hasard parmis celles-ci est : " + this.lettre;
        }

    }
}
