using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProblemeFinal_Gatinois_Marion_GroupeD
{
    class Dictionnaire 
    {
        string[][] mots;

        public Dictionnaire()
        {
            this.mots = new string[13][]; ///tableau de tableau
            ReadFile("MotsPossibles.txt"); ///on relie le fichier au constructeur pour ne pas à avoir à appeler la fonction ReadFile dans le Main et que ça se fasse automatiquement quand on va utiliser/appeler la classe Dé
        }

        public string[][]Mots
        {
            get
            {
                return this.mots;
            }
            set
            {
                this.mots = value;
            }
        }

        /// <summary>
        /// lecture du fichier MotsPossibles et création du tableau de mots avec tous les mots du dictionnaire
        /// </summary>
        /// <param name="Filename">fichier MotsPossibles</param>
        public void ReadFile(string Filename) ///on rattache le fichier à la classe MotsPossibles
        {
            int nbLignes = File.ReadAllLines(Filename).Length;
            string[] tableauLignes = new string[nbLignes]; ///on créé un tableau qui va lire et récupérer toutes les lignes de notre fichiers 

            try ///test pour lire le fichier 
            {
                int j = 1;
                tableauLignes = File.ReadAllLines(Filename);
                for (int i = 0; i < 13 ; i++) //13 car 13 lignes avec des mots
                {
                    this.mots[i] = new string[tableauLignes[j].Split(' ').Length];
                    this.mots[i] = tableauLignes[j].Split(' '); ///on remplit à la fin le tableau du constructeur grâce au tableau de toutes les lignes mais pour 
                    j = j + 2; ///car une ligne sur 2 a des mots       /// cela on a rempli les cases avec pour chaque case, une valeur séparée par un espace car c'est la construction du fichier MotsPossibles.txt
                }
            }
            catch (FileNotFoundException e) ///test des exception pour ne pas que le fichier ne plante
            {
                Console.WriteLine(e.Message);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }

        public string toString()
        {
            string tab = "";
            for (int i = 0; i < this.mots.Length; i++) ///on récupère tous les mots
            {
                tab = tab + this.mots[i] + " ";
            }
            return "Le dictionnaire contient l'ensemble des mots suivants : " + tab ;
        }

        /// <summary>
        /// Permet de rechercher le mot parmis le tableau de mots récupéré grâce au fichier MotsPossibles sans parcourir tout le tableau (recherche récusive)
        /// </summary>
        /// <param name="debut">début de la recherche (0)</param>
        /// <param name="fin">fin de la recherche (taille du nouveau mot)</param>
        /// <param name="mot">le mot entré par l'utilisateur</param>
        /// <returns></returns>
        public bool RechDichoRecursif(int debut, int fin, string mot)
        {
            {
                    int milieu = (debut + fin) / 2;
                    if (debut > fin)
                    {
                        return false;
                    }
                    else if (mot == mots[mot.Length - 2][milieu])
                    {
                        return true;
                    }
                    else if (String.Compare(mot, mots[mot.Length - 2][milieu]) < 0)
                    {
                        return RechDichoRecursif(debut, milieu - 1, mot);
                    }
                    else
                    {
                        return RechDichoRecursif(milieu + 1, fin, mot);
                    }
            }
           
        }

}
}
