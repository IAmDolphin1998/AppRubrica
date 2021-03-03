using System;
using System.Collections.Generic;

namespace AppRubrica
{
    class Program
    {
        private static GestoreRubrica gestore;
        private static bool fineEx = false;
        public static void Lettura()
        {  
            System.Xml.Serialization.XmlSerializer lettore = new System.Xml.Serialization.XmlSerializer(typeof(List<Contatto>));
            System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Users\test\Documents\Rubrica.xml");
            List<Contatto> vistaContatti = (List<Contatto>)lettore.Deserialize(file);
            file.Close();
            gestore = new GestoreRubrica(vistaContatti);
        }
        public static void Scrittura()
        {
            List<Contatto> vistaContatti = gestore.GetContatti();
            System.Xml.Serialization.XmlSerializer scrittore = new System.Xml.Serialization.XmlSerializer(typeof(List<Contatto>));

            var percorso = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//Rubrica.xml";
            System.IO.FileStream file = System.IO.File.Create(percorso);

            scrittore.Serialize(file, vistaContatti);
            file.Close();
        }
        public static void Main(string[] args)
        {
            Lettura();
            while (!fineEx)
            {
                Console.WriteLine("Scegli una operazione tra le seguenti: ");
                Console.WriteLine("\ta - Aggiungi un nuovo contatto");
                Console.WriteLine("\tm - Modifica un contatto esistente");
                Console.WriteLine("\tc - Cerca un contatto nella rubrica");
                Console.WriteLine("\tr - Rimuovi un contatto esistente");
                Console.WriteLine("\ts - Stampa l'intera rubrica");
                Console.Write("La tua richiesta? ");
                string op = Console.ReadLine();
                gestore.EseguiOperazione(op);
                Console.Write("Vuoi fare un'altra operazione (y/n)? ");
                op = Console.ReadLine();
                if (op == "n")
                {
                    fineEx = true;
                }
            }
            Scrittura();
        }
    }
}
