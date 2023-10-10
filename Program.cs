using System;
using System.Data.SqlTypes;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Crea una stringa di connessione con i parametri necessari per connettersi a SQL Server
            // Puoi modificare questi parametri a seconda del tuo server, del tuo database, del tuo utente e della tua password
            string connectionString = "Server=127.0.0.1;Database=myDataBase;User Id=myUser;Password=myPassword;TrustServerCertificate=True";

            // Crea un'istanza della classe DbContextOptionsBuilder, che serve per configurare le opzioni per il contesto del database
            var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();

            // Usa il metodo UseSqlServer per specificare il provider di database e la stringa di connessione
            optionsBuilder.UseSqlServer(connectionString);

            // Crea un'istanza della classe MyDbContext, che rappresenta il contesto del database, usando le opzioni configurate
            using (var context = new MyDbContext(optionsBuilder.Options))
            {
                // Qui puoi eseguire le operazioni che vuoi sul database, ad esempio query o comandi, usando le classi di entità definite nel contesto
                // Per esempio, puoi usare il metodo LINQ ToList per ottenere tutti gli elementi della tabella Prodotti
                var prodotti = context.Prodotti.ToList();

                // Stampa il numero di elementi ottenuti dalla query
                Console.WriteLine("La query ha restituito {0} elementi.", prodotti.Count);

                // Stampa i dettagli di ogni elemento ottenuto dalla query
                foreach (var prodotto in prodotti)
                {
                    Console.WriteLine("Id: {0}, Nome: {1}, Prezzo: {2}", prodotto.Id, prodotto.Nome, prodotto.Prezzo);
                }

                Thread.Sleep(10000);
            }
        }
    }

    // Definisce la classe MyDbContext, che eredita dalla classe DbContext e rappresenta il contesto del database
    public class MyDbContext : DbContext
    {
        // Definisce il costruttore della classe, che accetta le opzioni per il contesto come parametro e le passa al costruttore base
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        // Definisce la proprietà Prodotti, che rappresenta la tabella Prodotti nel database e usa la classe Prodotto come tipo di entità
        public DbSet<Prodotto> Prodotti { get; set; }
    }

    // Definisce la classe Prodotto, che rappresenta un'entità della tabella Prodotti nel database
    public class Prodotto
    {
        // Definisce la proprietà Id, che rappresenta la chiave primaria della tabella Prodotti
        public int Id { get; set; }

        // Definisce la proprietà Nome, che rappresenta una colonna della tabella Prodotti
        public string Nome { get; set; }

        // Definisce la proprietà Prezzo, che rappresenta una colonna della tabella Prodotti
        public decimal Prezzo { get; set; }
    }
}
