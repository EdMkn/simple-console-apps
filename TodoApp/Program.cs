using System;
using System.Collections.Generic;
namespace _todolist
{
    class Program
    {
        static List<string> todoList = new List<string>();

        static void Main()
        {
            string input = "";

            while (input != "4")
            {
                Console.Clear();
                Console.WriteLine("===== TO-DO LIST =====");
                Console.WriteLine("1. Afficher les tâches");
                Console.WriteLine("2. Ajouter une tâche");
                Console.WriteLine("3. Supprimer une tâche");
                Console.WriteLine("4. Quitter");
                Console.Write("Choix : ");
                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AfficherTaches();
                        break;
                    case "2":
                        AjouterTache();
                        break;
                    case "3":
                        SupprimerTache();
                        break;
                    case "4":
                        Console.WriteLine("Au revoir !");
                        break;
                    default:
                        Console.WriteLine("Choix invalide.");
                        break;
                }

                if (input != "4")
                {
                    Console.WriteLine("\nAppuyez sur une touche pour continuer...");
                    Console.ReadKey();
                }
            }
        }

        static void AfficherTaches()
        {
            Console.WriteLine("\nVos tâches :");
            if (todoList.Count == 0)
            {
                Console.WriteLine("Aucune tâche.");
                return;
            }

            for (int i = 0; i < todoList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {todoList[i]}");
            }
        }

        static void AjouterTache()
        {
            Console.Write("\nEntrez la nouvelle tâche : ");
            string tache = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(tache))
            {
                todoList.Add(tache);
                Console.WriteLine("Tâche ajoutée !");
            }
            else
            {
                Console.WriteLine("Tâche vide ignorée.");
            }
        }

        static void SupprimerTache()
        {
            AfficherTaches();
            Console.Write("\nNuméro de la tâche à supprimer : ");
            if (int.TryParse(Console.ReadLine(), out int index))
            {
                if (index >= 1 && index <= todoList.Count)
                {
                    todoList.RemoveAt(index - 1);
                    Console.WriteLine("Tâche supprimée !");
                }
                else
                {
                    Console.WriteLine("Numéro invalide.");
                }
            }
            else
            {
                Console.WriteLine("Entrée non valide.");
            }
        }
    }

}
