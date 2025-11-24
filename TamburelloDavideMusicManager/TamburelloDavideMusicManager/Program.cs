using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using TamburelloDavideMusicManager.Data;
using TamburelloDavideMusicManager.Model;

internal class Program
{
    private static void Main(string[] args)
    {
        using var db = new MusicContext();
        //PopulateDb(db);
        //Q1();
        //Q2();
        //Q3();
        //Q4();
        //Q5();
    }
    static void Q1()
    {
        using var db = new MusicContext();
        /*
            Q1: Creare un metodo che riceve in input un punteggio minimo (es. 80) e stampa l'elenco delle
            Esibizioni di successo. Per ogni esibizione stampare: Nome d'Arte del cantante, Nome del Festival e
            Voti ottenuti, filtrando solo chi ha superato la soglia inserita.
        */
        Console.WriteLine("inserisci il voto minimo");
        int votoMinimo = int.Parse(Console.ReadLine());
        db.Esibizioni
            .Where(e => e.VotiGiuria >= votoMinimo)
            .Include(e => e.Cantante)
            .Include(e => e.Festival)
            .ToList()
            .ForEach(e => Console.WriteLine($"{e.Cantante.NomeArte}, {e.Festival.Nome}, {e.VotiGiuria}"));

    }
    static void Q2()
    {
        using var db = new MusicContext();
        /*
            Q2: Creare un metodo che riceve in input il nome di un'Etichetta e stampa l'elenco dei Festival 
            in cui ha partecipato almeno un cantante di quell'etichetta (evitare duplicati nei nomi dei festival)
        */
        Console.WriteLine("inserisci il nome dell'etichetta");
        string? nomeEtichetta = Console.ReadLine();
        db.Esibizioni
            .Include(e => e.Cantante)
            .Include(e => e.Festival)
            .Where(e => e.Cantante.Etichetta.Nome == nomeEtichetta)
            .Select(e => new{e.Festival.Nome})
            .Distinct()
            .ToList()
            .ForEach(f => Console.WriteLine(f.Nome));
    }

    static void Q3()
    {
        using var db = new MusicContext();
        /*
            Q3: Trovare e stampare i nomi dei cantanti (e il relativo Festival) che hanno avuto 
            l'onere di aprire il festival (ovvero quelli con OrdineUscita uguale a 1)
        */
        db.Esibizioni
            .Include(e => e.Cantante)
            .Include(e => e.Festival)
            .Where(e => e.OrdineUscita == 1)
            .ToList()
            .ForEach(e => Console.WriteLine($"{e.Festival.Nome}, {e.Cantante.NomeArte}"));
    }

    static void Q4()
    {
        using var db = new MusicContext();
        /*
            Q4: Stampare la classifica dei cantanti basata sulla media voti. 
            Per ogni cantante mostrare il Nome d'Arte e la media aritmetica dei voti 
            presi in tutte le sue esibizioni, 
            ordinando dal più bravo (media più alta) al meno bravo.
        */
        db.Cantanti
            .Select(c => new 
            {
                Nome = c.NomeArte,
                MediaVoti = db.Esibizioni
                                .Where(e => e.CantanteId == c.Id)
                                .Average(e => e.VotiGiuria)
            })
            .OrderByDescending(c => c.MediaVoti)
            .ToList()
            .ForEach(c => Console.WriteLine($"{c.Nome}: {c.MediaVoti}"));
    }

    static void Q5()
    {
        using var db = new MusicContext();
        /*
            Q5: Per ogni Festival presente nel database, stampare il nome del Festival 
            e il punteggio più alto (Record) registrato in quel festival.
        */
        db.Esibizioni
            .Include(e => e.Festival)
            .GroupBy(e => e.Festival)
            .Select(g => new {g.Key.Nome, VotoMax = g.Max(e => e.VotiGiuria)})
            .ToList()
            .ForEach(e => Console.WriteLine($"{e.Nome}: {e.VotoMax}"));
    }

    static void PopulateDb(MusicContext db)
    {
        List<Etichetta> etichette =
        [
            new (){Id=1, Nome="Universal Music", SedeLegale="Milano"},
            new (){Id=2, Nome="Sony Music", SedeLegale="Roma"},
            new (){Id=3, Nome="Warner Music", SedeLegale="Milano"},
        ];
        List<Festival> festival =
        [
            new (){Id=1, Nome="Sanremo Giovani", DataInizio=DateTime.Today},
            new (){Id=2, Nome="Festivalbar", DataInizio=DateTime.Today.AddDays(-30)}
        ];

        etichette.ForEach(e => db.Add(e));
        festival.ForEach(f => db.Add(f));
        db.SaveChanges();

        List<Cantante> cantanti =
        [
            new (){Id = 1, NomeArte="The Rocker", NomeReale="Mario Rossi", EtichettaId=1},
            new (){Id = 2, NomeArte="Melody", NomeReale="Anna Verdi", EtichettaId=1},
            new (){Id = 3, NomeArte="Trap King", NomeReale="Luca Bianchi", EtichettaId=2},
            new (){Id = 4, NomeArte="Jazz Master", NomeReale="Paolo Neri", EtichettaId=2},
            new (){Id = 5, NomeArte="Pop Queen", NomeReale="Giulia Gialli", EtichettaId=3},
            new (){Id = 6, NomeArte="Indie Boy", NomeReale="Marco Blu", EtichettaId=3}
        ];

        cantanti.ForEach(c => db.Add(c));
        db.SaveChanges();

        List<Esibizione> esibizioni =
        [
            // Festival 1 (Sanremo)
            new (){CantanteId = 1, FestivalId = 1, VotiGiuria= 85, OrdineUscita = 1},
            new (){CantanteId = 2, FestivalId = 1, VotiGiuria = 92, OrdineUscita = 2},
            new (){CantanteId = 3, FestivalId = 1, VotiGiuria = 70, OrdineUscita = 3},
            new (){CantanteId = 4, FestivalId = 1, VotiGiuria = 60, OrdineUscita = 4},
            new (){CantanteId = 5, FestivalId = 1, VotiGiuria = 95, OrdineUscita = 5}, 
            new (){CantanteId = 6, FestivalId = 1, VotiGiuria = 50, OrdineUscita = 6},

            // Festival 2 (Festivalbar)
            new (){CantanteId = 4, FestivalId = 2, VotiGiuria = 88, OrdineUscita = 1},
            new (){CantanteId = 2, FestivalId = 2, VotiGiuria = 90, OrdineUscita = 2},
            new (){CantanteId = 1, FestivalId = 2, VotiGiuria = 75, OrdineUscita = 3},
            new (){CantanteId = 5, FestivalId = 2, VotiGiuria = 80, OrdineUscita = 4},
            new (){CantanteId = 6, FestivalId = 2, VotiGiuria = 65, OrdineUscita = 5},
            new (){CantanteId = 3, FestivalId = 2, VotiGiuria = 55, OrdineUscita = 6},
        ];

        esibizioni.ForEach(e => db.Add(e));
        db.SaveChanges();
    }
}