using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemeFinal_Gatinois_Marion_GroupeD
{
    class Program
    {
        static void Main(string[] args)
        {     
                                   
            Dictionnaire dico = new Dictionnaire();

            Console.WriteLine("Bonjour, vous avez chacun 1min pour jouer pour un total de 6 min");
            Console.WriteLine("Trouvez le plus de mots possible en un minimum de temps ! A vous de jouer !");

            Console.WriteLine("Nom du joueur 1 : ");
            string Joueur1 = Console.ReadLine();
            while(Joueur1 == "") ///pas de nom, pas de jeu 
            {
                Console.WriteLine("Erreur, merci d'entrez un nom");
                Console.WriteLine("Nom du joueur 1 : ");
                Joueur1 = Console.ReadLine();
            }
            Console.WriteLine("Nom du joueur 2 : ");
            string Joueur2 = Console.ReadLine();
            while (Joueur2 == "") ///pas de nom, pas de jeu
            {
                Console.WriteLine("Erreur, merci d'entrez un nom");
                Console.WriteLine("Nom du joueur 1 : ");
                Joueur2 = Console.ReadLine();
            }

            Joueur A = new Joueur(Joueur1);
            Joueur B = new Joueur(Joueur2);
            DateTime TempsDébutJeu = DateTime.Now; 
            TimeSpan TempsJeu = DateTime.Now - TempsDébutJeu;

            while (TempsJeu.TotalMinutes <= 6)
            {
                Plateau plateau = new Plateau();
                plateau.toString();
                Console.WriteLine("C'est au tour de "+ Joueur1 + " de jouer ");
                DateTime TempsDébutTour = DateTime.Now;
                TimeSpan TempsTour = DateTime.Now - TempsDébutTour;

                while (TempsTour.TotalMinutes <= 1) ///tour du joueur1
                {
                    Console.WriteLine("Saississez un nouveau mot trouvé (majuscule)");
                    string NouveauMot = Console.ReadLine();
                    if (NouveauMot.Length <= 1)
                    {
                        Console.WriteLine("///erreur, le mot est trop court/// "); ///verification d'un mot qui ne fais plus parti du dico car trop long 
                    }
                    else if (NouveauMot != "" && NouveauMot.Length < 15)/// verification d'un mot non vide
                    {
                        if (A.Contain(NouveauMot) == false && dico.RechDichoRecursif(0, dico.Mots[NouveauMot.Length - 2].Length, NouveauMot) == true && NouveauMot.Length >= 3 )
                        {
                            A.CalculScore(NouveauMot);
                            A.Add_Mot(NouveauMot);
                            Console.WriteLine(A.toString());
                        }
                    }
                    else if(NouveauMot.Length > 14)
                    {
                        Console.WriteLine("///erreur, le mot est trop long/// "); ///verification d'un mot qui ne fais plus parti du dico car trop long 
                    }
                    else
                    {
                        Console.WriteLine("///erreur, veuillez entrez un mot///"); 
                    }
                    TempsTour = DateTime.Now - TempsDébutTour;
                }
                TempsJeu = DateTime.Now - TempsDébutJeu;

                plateau = new Plateau();
                plateau.toString();
                Console.WriteLine("C'est au tour de " + Joueur2 + " de jouer ");
                TempsDébutTour = DateTime.Now;
                TempsTour = DateTime.Now - TempsDébutTour;

                while (TempsTour.TotalMinutes <= 1) ///tour du joueur 2
                {
                    Console.WriteLine("Saississez un nouveau mot trouvé (majuscule)");
                    string NouveauMot = Console.ReadLine();
                    if (NouveauMot != "" && NouveauMot.Length < 15)/// verification d'un mot non vide
                    {
                        if (B.Contain(NouveauMot) == false && dico.RechDichoRecursif(0, dico.Mots[NouveauMot.Length - 2].Length, NouveauMot) == true && NouveauMot.Length >= 3)
                        {
                            B.CalculScore(NouveauMot);
                            B.Add_Mot(NouveauMot);
                            Console.WriteLine(B.toString());
                        }
                    }
                    else if (NouveauMot.Length > 14)
                    {
                        Console.WriteLine("///erreur, le mot est trop long/// "); ///verification d'un mot qui ne fais plus parti du dico car trop long 
                    }
                    else
                    {
                        Console.WriteLine("///erreur, veuillez entrez un mot///");
                    }
                    TempsTour = DateTime.Now - TempsDébutTour;
                }
                TempsJeu = DateTime.Now - TempsDébutJeu;
            }

            if(A.Score > B.Score)
            {
                Console.WriteLine("C'est " + Joueur1 + " qui a gagné" + " avec " + A.Score + " points contre " + B.Score +  " points  pour " + Joueur2);
            }
            if (A.Score < B.Score)
            {
                Console.WriteLine("C'est " + Joueur2 + " qui a gagné" + " avec " + B.Score + " points contre " + A.Score + " points pour " + Joueur1);
            }
            if (A.Score == B.Score)
            {
                Console.WriteLine("Egalité entre " + Joueur1 + " et " + Joueur2 + " avec " + A.Score + " points");
            }

            Console.ReadKey();
        }
    }
}
