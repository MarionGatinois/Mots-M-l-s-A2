using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemeFinal_Gatinois_Marion_GroupeD
{
    class Joueur
    {
        string nom;
        int score ; ///on initialise le score à 0
        string[] motTrouve ; ///on crée un tableau dont la taille max ne sera jamais atteinte, le joueur ne pourra pas trouver 40 mots
        int i = 0; ///on va l'utiliser pour void Add_mot

        public Joueur(string nom)
        {
            this.nom = nom;
            this.score = 0;
            this.motTrouve = new string[40];
        }

        public int Score 
            {
            get ///besoin du score pour le changer à chaque mot trouvé du joueur
            {
                return this.score;
            }
            }
        public string[] MotTrouve  
        {
            get ///besoin des mots déjà trouvés
            {
                return this.motTrouve;
            }
            set ///besoin d'ajouter les mots trouvés au tableau
            {
                this.motTrouve = value;
            }
        }

        /// <summary>
        /// Définie si ca contient ou pas le mot
        /// </summary>
        /// <param name="mot">le mot entré par l'utilisateur</param>
        /// <returns></returns>
        public bool Contain(string mot) ///mot trouvé a déjà été trouvé?
        {
            bool Contain = false;
            if((mot != "") && (motTrouve != null)) ///on vérifie que la tableau et le mot ne soit pas null, vide
            {
                for (int i = 0; i < motTrouve.Length; i++) ///on parcours tous les mots trouvés dans le tableau
                {
                    if (this.motTrouve[i] == mot)
                    {
                        Contain = true;
                    }
                }
            }
            return Contain;
        }

        /// <summary>
        /// ajoute le mot à la liste des mots trouvés
        /// </summary>
        /// <param name="mot">le mot entré par l'utilisateur</param>
        public void Add_Mot(string mot) ///si le mot n'est pas déjà trouvé, le mot est ajouté à la liste des mots trouvés
        {
             if (Contain(mot) == false)
            {
                this.motTrouve[i] = mot;
                i++;
            }
        }

        public void CalculScore(string mot)
        {
            if(mot.Length == 3 )
            {
                this.score = score + 2;
            }
            if (mot.Length == 4)
            {
                this.score = score + 3;
            }
            if (mot.Length == 5)
            {
                this.score = score + 4;
            }
            if (mot.Length ==  6)
            {
                this.score = score + 5;
            }
            if (mot.Length ==  7)
            {
                this.score = score + 11;
            }
        }


        public string toString() ///décrit le nom, le score et les mots trouvés du joueur
        {
            string tab ="" ;
            for (int i = 0; i < this.motTrouve.Length; i++) ///on récupère tous les mots
            {
                tab = tab + this.motTrouve[i] + " ";
            }
            return "Le joueur : " + this.nom + " a un score de " + this.score + " grâce aux mots cités :" + tab ;
        }

    }
}
