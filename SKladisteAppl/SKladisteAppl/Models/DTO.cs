namespace SKladisteAppl.Models
{
    /// <summary>
    /// mapa DTO
    /// </summary>
    /// <param name="sifra"></param>
    /// <param name="ime"></param>
    /// <param name="prezime"></param>
    /// <param name="brojTelefona"></param>
    /// <param name="email"></param>
   public record OsobaDTORead(int sifra, string ime, string prezime,
       string brojTelefona, string email);
    /// <summary>
    /// update DTO
    /// </summary>
    /// <param name="ime"></param>
    /// <param name="prezime"></param>
    /// <param name="brojTelefona"></param>
    /// <param name="email"></param>

   public record OsobaDTOInsertUpdate(string ime, string prezime,
       string brojTelefona, string email);
}
