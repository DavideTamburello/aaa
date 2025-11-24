using TamburelloDavideMusicManager.Model;

public class Abilita
{
    public int CantanteId { get; set; }
    public Cantante Cantante { get; set; }=null!;

    public int StrumentoId { get; set; }
    public Strumento Strumento { get; set; }=null!;

    public int Livello { get; set; } // da 1 a 5
}
