using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProblemeFinal_Gatinois_Marion_GroupeD
{
    class Plateau
    {
        Dé[] tab; ///Chaque case comprend une instance de la classe Dé (Dé1 ; Dé2 ...) 
        string[,] plateau_jeu; ///Chaque case de la matrice comprend une lettre de type string (Dé1.Lettre : Obtention de la lettre à la surface du Dé obtenue par la méthode Dé.Lance(r)
        string[] valeurSupérieur;

        public Plateau()
        {
            this.tab = new Dé[16];
            this.plateau_jeu = new string[4, 4];
            this.valeurSupérieur = new string[16];
            Random r = new Random();
            ReadFile("Des.txt");
            for (int i = 0; i < tab.Length; i++) ///création du plateau de jue pour ne pas à avoir à l'appeler à chaque fois
            {
                this.tab[i].Lance(r);
                this.valeurSupérieur[i] = this.tab[i].Lettre; ///on recupere une lettre sur le dé
            }
            int j = 0;
            for (int ligne = 0; ligne < 4; ligne++)
            {
                for (int colonne = 0; colonne < 4; colonne++)
                {
                    this.plateau_jeu[ligne, colonne] = valeurSupérieur[j];
                    j++;
                }
            }
        }

        public Dé[] Tab
        {
            get
            {
                return this.tab;
            }
            set
            {
                this.tab = value;
            }
        }
        public string[] ValeurSupérieur
        {
            get
            {
                return this.valeurSupérieur;
            }
            set
            {
                this.valeurSupérieur = value;
            }
        }
        public string[,] Plateau_jeu
        {
            get
            {
                return this.plateau_jeu;
            }
            set
            {
                this.plateau_jeu = value;
            }
        }


        /// <summary>
        /// recherche si les lettres entrées par l'utilisateur sont adjcentes (pas effectué)
        /// </summary>
        /// <param name="mot">le mot entré par l'utilisateur</param>
        /// <returns></returns>
        public bool adjacent(char[] mot)
        {
            bool adjacent = false;
            for (int i = 0; i < tab.Length; i++)
            {
                if(mot[i] == mot [i])
                {
                    adjacent = true;
                }
            }
            return adjacent;
        }

        /// <summary>
        /// lecture du fichier des.txt et création d'un tableau de dé pour ensuite créé le tableau de jeu dans le constructeur 
        /// </summary>
        /// <param name="Filename">fichier des.txt</param>
        public void ReadFile(string Filename) ///on rattache le fichier à la classe Dé
        {
            int nbLignes = File.ReadAllLines(Filename).Length;
            string[] tableauLignes = new string[nbLignes]; ///on créé un tableau qui va lire et récupérer toutes les lignes de notre fichiers 
            string[] tableauDé = new string[6];
            int compteur = 0;
            StreamReader streamReader = null;

            try ///test pour lire le fichier 
            {
                string Line;
                streamReader = new StreamReader(Filename);

                while ((Line = streamReader.ReadLine()) != null) ///tant qu'il y a des lignes dans le fichier à lire on récupère les lignes dans notre tableau
                {
                    tableauLignes[compteur] = Line;
                    compteur++;
                }
                for (int i = 0; i < tableauLignes.Length; i++)
                {
                    tableauDé = tableauLignes[i].Split(';');
                    this.tab[i] = new Dé();
                    this.tab[i].EnsembleLettre = tableauDé ;
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
            finally
            {
                if (streamReader != null) { streamReader.Close(); } ///si le streamReader nétait pas null on ne l'aurait pas ouvert, et si il est ouvert il faut obligatoirement fermer le flux, d'où le finally
            }

        }

        /// <summary>
        /// fonction qui va retourner vrai si toutes les lettres du mots sont bien adjacentes
        /// </summary>
        /// <param name="mot">le mot entré par l'utilisateur</param>
        /// <returns></returns>
        public bool Test_Plateau(char[]mot)
        {
            bool Test_Plateau = false;
            if (adjacent(mot) == true )
                {
                    Test_Plateau = true;
                }
            return Test_Plateau;
        }

        /// <summary>
        /// affiche le plateau de jeu 
        /// </summary>
        public void toString()
        {
            Console.WriteLine("//////////////");
            for (int ligne = 0; ligne < 4; ligne++)
            {
                for (int colonne = 0; colonne < 4; colonne++)
                {
                     Console.Write(this.plateau_jeu[ligne, colonne] + " ");
                }
                Console.WriteLine(" ");                
            }
            Console.WriteLine("//////////////");
        }

    }
}
