using System.Data.Common;
using TamburelloDavideMusicManager.Data;
using TamburelloDavideMusicManager.Model;

internal class Program
{
    private static void Main(string[] args)
    {
        using(var db = new MusicContext())
        {
            //PopulateDb(db);
            
        }
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