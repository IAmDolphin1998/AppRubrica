using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Text.RegularExpressions;

namespace AppRubrica
{
     public class Contatto 
     {
        public enum TipoContatto
        {
            Normale,
            Preferito
        }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        private string email;
        public string Email 
        {
            get => email;
            set 
            {
                if (Regex.IsMatch(value, @"^[^@\s]+@[^@\s]+\.[^@\s]+$") || value == "")
                {
                    email = value;
                }
                else
                {
                    Console.WriteLine($"L'email {value} non è valida!");
                }
            } 
        }
        public string Numero { get; set; }
        public string Gruppo { get; set; }
        public TipoContatto Tipo { get; set; }
        public override string ToString() => $"[Nome = {Nome} , Cognome = {Cognome} , Numero = {Numero} , Email = {Email} , Categoria = {Tipo} , Gruppo = {Gruppo}]";
    }
}
