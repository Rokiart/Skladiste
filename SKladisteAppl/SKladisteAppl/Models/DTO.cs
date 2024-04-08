﻿using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.ComponentModel.DataAnnotations;


namespace SKladisteAppl.Models
{

    /// <summary>
    /// Predstavlja podatke o osobi za čitanje.
    /// </summary>
    public record OsobaDTORead(int sifra, string ime, string prezime,
        string? brojtelefona, string? email);

    /// <summary>
    /// Predstavlja podatke o osobi za unos i ažuriranje.
    /// </summary>
    public record OsobaDTOInsertUpdate(
        [Required(ErrorMessage = "Naziv obavezno")]
        string ime,
        [Required(ErrorMessage = "Naziv obavezno")]
        string prezime,
        string brojtelefona, string email);

    /// <summary>
    /// Predstavlja podatke o proizvodu za čitanje.
    /// </summary>
    public record ProizvodDTORead(int sifra, string naziv, string sifraproizvoda,
        string mjernajedinica);

    /// <summary>
    /// Predstavlja podatke o proizvodu za unos i ažuriranje.
    /// </summary>
    public record ProizvodDTOInsertUpdate(string naziv, string sifraproizvoda,
        string mjernajedinica);

    /// <summary>
    /// Predstavlja podatke o skladištaru za čitanje.
    /// </summary>
    public record SkladistarDTORead(int? sifra, string ime, string prezime,
        string brojtelefona, string email);

    /// <summary>
    /// Predstavlja podatke o skladištaru za unos i ažuriranje.
    /// </summary>
    public record SkladistarDTOInsertUpdate(string ime, string prezime,
        string brojtelefona, string email);

    /// <summary>
    /// Predstavlja podatke o izdatnici za čitanje.
    /// </summary>
    public record IzdatnicaDTORead(int sifra, string? brojIzdatnice,
        DateTime? datum, string? osobaImePrezime, string? skladistarImePrezime, string napomena, string? proizvodiPopis);

    /// <summary>
    /// Predstavlja podatke o izdatnici za unos i ažuriranje.
    /// </summary>
    public record IzdatnicaDTOInsertUpdate(string? brojizdatnice,
        DateTime? datum, int? osobasifra, int? skladistarSifra, string napomena);

    public record IzdatnicaProizvodSTORead(int? sifra, string? naziv, int? kolicina);

    public record IzdatnicaProizvodSTOInsertUpdate(int? izdatnicaSifra, int? proizvodSifra, [Required(ErrorMessage = "Kolicina obavezno")] string? kolicina);

    public record OperaterDTO(
       [Required(ErrorMessage = "Email obavezno")]
        string? email,
       [Required(ErrorMessage = "Lozinka obavezno")]
        string? password);

}

