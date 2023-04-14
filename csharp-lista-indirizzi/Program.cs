using System;
using System.Collections.Generic;
using System.IO;

namespace csharp_lista_indirizzi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<Indirizzo> indirizzi = new List<Indirizzo>();

                using (StreamReader inputstream = File.OpenText("addresses.csv"))
                {
                    // Leggi la prima riga che contiene i nomi dei campi
                    string primaRiga = inputstream.ReadLine();

                    // Leggi le righe successive contenenti gli indirizzi
                    while (!inputstream.EndOfStream)
                    {
                        string riga = inputstream.ReadLine();

                        // Dividi la riga in un array di valori
                        string[] valori = riga.Split(',');

                        // Verifica se ci sono informazioni mancanti sull'indirizzo
                        if (valori.Length < 6)
                        {
                            Console.WriteLine("Attenzione: controllare l'output per vedere quali campi sono mancanti.");
                            continue;
                        }

                        // Verifica se ci sono valori mancanti e sostituiscili con una stringa predefinita
                        string nome = string.IsNullOrWhiteSpace(valori[0]) ? "[Nome-mancante]" : valori[0];
                        string cognome = string.IsNullOrWhiteSpace(valori[1]) ? "[Cognome-mancante]" : valori[1];
                        string strada = string.IsNullOrWhiteSpace(valori[2]) ? "[Indirizzo-mancante]" : valori[2];
                        string città = string.IsNullOrWhiteSpace(valori[3]) ? "[Città-mancante]" : valori[3];
                        string provincia = string.IsNullOrWhiteSpace(valori[4]) ? "[Provincia-mancante]" : valori[4];
                        string cap = string.IsNullOrWhiteSpace(valori[5]) ? "[CAP-mancante]" : valori[5];

                        // Crea l'oggetto Indirizzo e aggiungilo alla lista
                        Indirizzo indirizzo = new Indirizzo(nome, cognome, strada, città, provincia, cap);
                        indirizzi.Add(indirizzo);
                    }
                }

                // Stampa gli indirizzi nella lista
                foreach (Indirizzo indirizzo in indirizzi)
                {
                    Console.WriteLine(
                        $"Nome: {indirizzo.Name}, " +
                        $"Cognome: {indirizzo.Surname}, " +
                        $"Indirizzo: {indirizzo.Street}, " +
                        $"Città: {indirizzo.City}, Provincia: " +
                        $"{indirizzo.Province}, " +
                        $"CAP: {indirizzo.ZIP}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}