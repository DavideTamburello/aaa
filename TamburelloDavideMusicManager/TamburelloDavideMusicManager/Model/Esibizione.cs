using System;
using System.Reflection.PortableExecutable;

namespace TamburelloDavideMusicManager.Model;

public class Esibizione
{
    public int FestivalId { get; set; }
    public int CantanteId { get; set; }
    public int VotiGiuria { get; set; }
    public int OrdineUscita { get; set; }
    public Cantante Cantante { get; set; }=null!;
    public Festival Festival { get; set; }=null!;
}
