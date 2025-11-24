using System;

namespace TamburelloDavideMusicManager.Model;

public class Festival
{
    public int Id { get; set; }
    public string Nome { get; set; }=null!;
    public DateTime DataInizio { get; set; }
    public ICollection<Esibizione> Esibizioni { get; set; }=[];
    
}
