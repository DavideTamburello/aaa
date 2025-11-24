using System;

namespace TamburelloDavideMusicManager.Model;

public class Cantante
{
    public int Id { get; set; }
    public string NomeArte { get; set; }=null!;
    public string NomeReale { get; set; }=null!;
    public int EtichettaId { get; set; }
    public Etichetta Etichetta { get; set; }=null!;
    public ICollection<Esibizione> Esibizioni { get; set; } = [];
}
