
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SKladisteAppl.Models
{
    /// <summary>
    /// Ovo mi je POCO koji je mapiran na bazu
    /// </summary>
    public class Izdatnica : Entitet

    {

        /// <summary>
        /// Broj izdatnice u bazi
        /// </summary>
        [Required(ErrorMessage = "Broj izdatnice obavezno")]
        public string? BrojIzdatnice { get; set; }
        /// <summary>
        /// datum izdatnice u bazi
        /// </summary>
        public DateTime? Datum { get; set; }
        /// <summary>
        /// Vanjski kljuc za osobu
        /// </summary>
        [ForeignKey("osoba")]
        public Osoba? Osoba { get; set; }
        /// <summary>
        /// Vanjski kljuc za skladistara
        /// </summary>
        [ForeignKey("skladistar")]
        public Skladistar? Skladistar { get; set; }
        /// <summary>
        /// Napomena max 250 karaktera u bazi
        /// </summary>
        public string? Napomena { get; set; }
        /// <summary>
        /// ključ više na više
        /// </summary>

        public List<Proizvod>? Proizvodi{ get; set; }

    }
}
