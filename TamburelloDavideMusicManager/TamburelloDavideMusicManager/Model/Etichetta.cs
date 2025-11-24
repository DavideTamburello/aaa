using System;

namespace TamburelloDavideMusicManager.Model;

public class Etichetta
{
    public int Id { get; set; }
    public string Nome { get; set; }=null!;
    public string SedeLegale { get; set; }=null!;
    public ICollection<Cantante> Cantanti { get; set; }=null!;
}
