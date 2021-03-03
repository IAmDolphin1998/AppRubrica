using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static AppRubrica.Contatto;

namespace AppRubrica
{
    public class GestoreRubrica
    {
        private List<Contatto> Contatti = new List<Contatto>();
        public GestoreRubrica(List<Contatto> contatti)
        {
            var i = 0;
            foreach (var item in contatti.ToList())
            {
                if(item.Nome == null || item.Cognome == null || item.Numero == null)
                {
                    Console.WriteLine($"Nel file XML il contatto {i} non è valido!");
                    contatti.Remove(item);
                }
                i++;
            }
            Contatti = contatti;
        } 
        public List<Contatto> GetContatti() => Contatti;
        public void CercaPerNome(string nome)
        {
            bool trovato = false;
            foreach (var item in Contatti)
            {
                if (item.Nome == nome)
                {
                    Console.WriteLine(item.ToString());
                    trovato = true;
                }
            }
            if (!trovato)
            {
                Console.WriteLine($"Non esiste nessun contatto nella rubrica avente come nome {nome}!");
            }
        }
        public void CercaPerCognome(string cognome)
        {
            bool trovato = false;
            foreach (var item in Contatti)
            {
                if (item.Cognome == cognome)
                {
                    Console.WriteLine(item.ToString());
                    trovato = true;
                }
            }
            if (!trovato)
            {
                Console.WriteLine($"Non esiste nessun contatto nella rubrica avente come cognome {cognome}!");
            }
        }
        public void CercaPerNumero(string numero)
        {
            bool trovato = false;
            foreach (var item in Contatti)
            {
                if (item.Numero == numero)
                {
                    Console.WriteLine(item.ToString());
                    trovato = true;
                }
            }
            if (!trovato)
            {
                Console.WriteLine($"Non esiste nessun contatto nella rubrica avente come numero {numero}!");
            }
        }
        public void CercaPerEmail(string email)
        {
            bool trovato = false;
            foreach (var item in Contatti)
            {
                if (item.Email == email)
                {
                    Console.WriteLine(item.ToString());
                    trovato = true;
                }
            }
            if (!trovato)
            {
                Console.WriteLine($"Non esiste nessun contatto nella rubrica avente come email {email}!");
            }
        }
        public void CercaPerPreferiti()
        {
            bool trovato = false;
            foreach (var item in Contatti)
            {
                if (item.Tipo == TipoContatto.Preferito)
                {
                    Console.WriteLine(item.ToString());
                    trovato = true;
                }
            }
            if (!trovato)
            {
                Console.WriteLine($"Non esiste nessun contatto \"preferito\" nella rubrica!");
            }
        }
        public void CercaPerGruppo(string gruppo)
        {
            bool trovato = false;
            foreach (var item in Contatti)
            {
                if (item.Gruppo == gruppo)
                {
                    Console.WriteLine(item.ToString());
                    trovato = true;
                }
            }
            if (!trovato)
            {
                Console.WriteLine($"Non esiste nessun contatto nella rubrica che appartiene al gruppo {gruppo}!");
            }
        }
        public void Cerca(string op)
        {
            switch (op)
            {
                case "n":
                    Console.Write("Inserisci il nome da ricercare: ");
                    CercaPerNome(Console.ReadLine());
                    break;
                case "c":
                    Console.Write("Inserisci il cognome da ricercare: ");
                    CercaPerCognome(Console.ReadLine());
                    break;
                case "num":
                    Console.Write("Inserisci il numero da ricercare: ");
                    CercaPerNumero(Console.ReadLine());
                    break;
                case "e":
                    Console.Write("Inserisci l'email da ricercare: ");
                    CercaPerEmail(Console.ReadLine());
                    break;
                case "p":
                    CercaPerPreferiti();
                    break;
                case "g":
                    Console.Write("Inserisci il gruppo da ricercare: ");
                    CercaPerGruppo(Console.ReadLine());
                    break;
                default:
                    Console.WriteLine("Hai inserito una operazione non valida!");
                    break;
            }
        }
        private string RichiestaFalcoltativo(string msg)
        {
            Console.Write(msg);
            if(Console.ReadLine() == "y")
            {
                Console.Write("Inserisci il dato richiesto: ");
                return Console.ReadLine();
            }
            return "";
        }
        private TipoContatto RichiestaTipoContatto(string msg)
        {
            Console.Write(msg);
            if (Console.ReadLine() == "y")
            {
                return TipoContatto.Preferito;
            }
            return TipoContatto.Normale;
        }
        public void Aggiungi()
        {
            //Chiedo i parametri obbligatori
            Console.Write("Inserisci il nome: ");
            string n = Console.ReadLine();
            Console.Write("Inserisci il cognome: ");
            string c = Console.ReadLine();
            Console.Write("Inserisci il numero: ");
            string num = Console.ReadLine();
            //Chiedo i paramentri falcoltativi
            string e = RichiestaFalcoltativo("Vuoi inserire anche l'email (y/n)? ");
            string g = RichiestaFalcoltativo("Vuoi inserire anche il gruppo (y/n)? ");
            TipoContatto tc = RichiestaTipoContatto("Vuoi impostare il tipo di contatto a \"preferito\" [il valore default del tipo di contatto è \"normale\"] (y/n)? ");
            Contatti.Add(new Contatto() { Nome = n, Cognome = c, Numero = num, Email = e, Gruppo =g, Tipo = tc});
        }
        private void ModificaTipoContatto(Contatto item)
        {
            if (item.Tipo == TipoContatto.Normale)
            {
                Console.WriteLine("Il contatto è impostato in \"normale\", vuoi cambiare in \"preferito\" (y/n)? ");
                if (Console.ReadLine() == "y")
                {
                    item.Tipo = TipoContatto.Preferito;
                }
            }
            else
            {
                Console.WriteLine("Il contatto è impostato in \"preferito\", vuoi cambiare in \"normale\" (y/n)? ");
                if (Console.ReadLine() == "y")
                {
                    item.Tipo = TipoContatto.Normale;
                }
            }
        }
        public void Modifica()
        {
            //Chiedo i parametri obbligatori per la ricerca
            Console.Write("Inserisci il nome: ");
            string n = Console.ReadLine();
            Console.Write("Inserisci il cognome: ");
            string c = Console.ReadLine();
            Console.Write("Inserisci il numero: ");
            string num = Console.ReadLine();
            bool trovato = false;
            foreach (var item in Contatti)
            {
                if (item.Nome == n && item.Cognome == c && item.Numero == num)
                {
                    trovato = true;
                    Console.Write("Contatto Trovato! Cosa vuoi modificare (scegli tra le seguenti opzioni)? ");
                    Console.WriteLine("Scegli una operazione tra le seguenti: ");
                    Console.WriteLine("\tn - Modifica il nome");
                    Console.WriteLine("\tc - Modifica il cognome");
                    Console.WriteLine("\tnum - Modifica il numero");
                    Console.WriteLine("\te - Modifica l'email");
                    Console.WriteLine("\ttp - Modifica il tipo di contatto");
                    Console.WriteLine("\tg - Modifica il gruppo");
                    switch (Console.ReadLine())
                    {
                        case "n":
                            Console.WriteLine("Inserire il nuovo nome: ");
                            item.Nome = Console.ReadLine();
                            break;
                        case "c":
                            Console.WriteLine("Inserire il nuovo cognome: ");
                            item.Cognome= Console.ReadLine();
                            break;
                        case "num":
                            Console.WriteLine("Inserire il nuovo numero: ");
                            item.Numero = Console.ReadLine();
                            break;
                        case "e":
                            Console.WriteLine("Inserire la nuova email: ");
                            item.Email = Console.ReadLine();
                            break;
                        case "tp":
                            ModificaTipoContatto(item);
                            break;
                        case "g":
                            Console.WriteLine("Inserire il nuovo gruppo: ");
                            item.Numero = Console.ReadLine();
                            break;
                        default:
                            Console.WriteLine("Hai scelto una operazione non valida!");
                            break;
                    }
                }
            }
            if (!trovato)
            {
                Console.WriteLine("Il contatto richiesto non esiste!");
            }
        }
        public void Rimuovi()
        {
            //Chiedo i parametri obbligatori per la ricerca
            Console.Write("Inserisci il nome: ");
            string n = Console.ReadLine();
            Console.Write("Inserisci il cognome: ");
            string c = Console.ReadLine();
            Console.Write("Inserisci il numero: ");
            string num = Console.ReadLine();
            bool trovato = false;
            foreach (var item in Contatti.ToList())
            {
                if (item.Nome == n && item.Cognome == c && item.Numero == num)
                {
                    trovato = true;
                    Console.Write("Contatto Trovato! Sei sicuro di voler eliminare (y/n)? ");
                    if(Console.ReadLine() == "y")
                    {
                        Contatti.Remove(item);
                    }
                }
            }
            if (!trovato)
            {
                Console.WriteLine("Il contatto richiesto non esiste!");
            }
        }
        public void EseguiOperazione(string op)
        {
            switch (op)
            {
                case "a":
                    Aggiungi();
                    break;
                case "m":
                    Modifica();
                    break;
                case "c":
                    Console.WriteLine("Scegli una operazione tra le seguenti: ");
                    Console.WriteLine("\tn - Cerca per nome");
                    Console.WriteLine("\tc - Cerca per cognome");
                    Console.WriteLine("\tnum - Cerca per numero");
                    Console.WriteLine("\te - Cerca per email");
                    Console.WriteLine("\tp - Cerca per contatti preferiti");
                    Console.WriteLine("\tg - Cerca per gruppi");
                    Console.Write("La tua richiesta? ");
                    string opR = Console.ReadLine();
                    Cerca(opR);
                    break;
                case "r":
                    Rimuovi();
                    break;
                case "s":
                    Console.Write(ToString());
                    break;
                default:
                    Console.WriteLine("Hai richiesto una operazione non valida!");
                    break;
            }
        }
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("{\n");
            for (int i = 0; i < Contatti.Count; i++)
            {
                stringBuilder.AppendLine($"Contatto {i} : {Contatti[i]}");
            }
            stringBuilder.Append("}\n");
            return stringBuilder.ToString();
        }
    }
}
