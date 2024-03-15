namespace SKladisteAppl.Models
{
    /// <summary>
    /// osoba DTO učitaj
    /// </summary>
    /// <param name="sifra"></param>
    /// <param name="ime"></param>
    /// <param name="prezime"></param>
    /// <param name="brojtelefona"></param>
    /// <param name="email"></param>
    public record OsobaDTORead(int sifra, string ime, string prezime,
        string brojtelefona, string email);
    /// <summary>
    /// osoba DTO update
    /// </summary>
    /// <param name="ime"></param>
    /// <param name="prezime"></param>
    /// <param name="brojtelefona"></param>
    /// <param name="email"></param>
    public record OsobaDTOInsertUpdate(string ime, string prezime,
        string brojtelefona, string email);



    /// <summary>
    /// Proizvod DTO read
    /// </summary>
    /// <param name="sifra"></param>
    /// <param name="naziv"></param>
    /// <param name="sifraproizvoda"></param>
    /// <param name="mjernajedinica"></param>


    public record ProizvodDTORead(int sifra, string naziv, string sifraproizvoda,
        string mjernajedinica);
    /// <summary>
    /// proizvod DTO update
    /// </summary>
    /// <param name="naziv"></param>
    /// <param name="sifraproizvoda"></param>
    /// <param name="mjernajedinica"></param>
    public record ProizvodDTOInsertUpdate(string naziv, string sifraproizvoda,
        string mjernajedinica)
    {
        internal Proizvod MapProizvodInsertUpdateFromDTO(Proizvod proizvod)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// skladistar DTO read
    /// </summary>
    /// <param name="sifra"></param>
    /// <param name="ime"></param>
    /// <param name="prezime"></param>
    /// <param name="brojtelefona"></param>
    /// <param name="email"></param>


    public record SkladistarDTORead(int sifra, string ime, string prezime,
        string brojtelefona, string email);
    /// <summary>
    /// skladistar DTO update
    /// </summary>
    /// <param name="Ime"></param>
    /// <param name="Prezime"></param>
    /// <param name="BrojTelefona"></param>
    /// <param name="Email"></param>
    public record SkladistarDTOInsertUpdate(string Ime, string Prezime,
        string BrojTelefona, string Email);

    /// <summary>
    /// Izdatnica DTO read
    /// </summary>
    /// <param name="Sifra"></param>
    /// <param name="BrojIzdatnice"></param>
    /// <param name="Datum"></param>
    /// <param name="OsobaImePrezime"></param>
    /// <param name="SkladistarImePrezime"></param>
    /// <param name="Napomena"></param>

    public record IzdatnicaDTORead(int Sifra, string BrojIzdatnice,
        DateTime Datum, string OsobaImePrezime, string SkladistarImePrezime, string Napomena);
    /// <summary>
    /// Izdatnica DTO update
    /// </summary>
    /// <param name="Sifra"></param>
    /// <param name="BrojIzdatnice"></param>
    /// <param name="Datum"></param>
    /// <param name="Osobasifra"></param>
    /// <param name="Skladistarsifra"></param>
    /// <param name="Napomena"></param>

    public record IzdatnicaDTOInsertUpdate(int Sifra, string BrojIzdatnice,
        DateTime Datum, int Osobasifra, string Skladistarsifra, string Napomena);
}

