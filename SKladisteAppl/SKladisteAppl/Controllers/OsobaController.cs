﻿using SKladisteAppl.Data;
using SKladisteAppl.Extensions;
using SKladisteAppl.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Text;
using Microsoft.EntityFrameworkCore;


namespace SKladisteAppl.Controllers
{

    /// <summary>
    /// Namjenjeno za CRUD operacije nad entitetom osoba u bazi
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OsobaController : ControllerBase
    {
        /// <summary>
        /// Kontest za rad s bazom koji će biti postavljen s pomoću Dependecy Injection-om
        /// </summary>
        private readonly SkladisteContext _context;
        /// <summary>
        /// Konstruktor klase koja prima Skladiste kontext
        /// pomoću DI principa
        /// </summary>
        /// <param name="context"></param>
        public OsobaController(SkladisteContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Dohvaća sve osobe iz baze
        /// </summary>
        /// <remarks>
        /// Primjer upita
        /// 
        ///    GET api/v1/Osoba
        ///    
        /// </remarks>
        /// <returns>Osobe u bazi</returns>
        /// <response code="200">Sve OK, ako nema podataka content-length: 0 </response>
        /// <response code="400">Zahtjev nije valjan</response>
        /// <response code="503">Baza na koju se spajam nije dostupna</response>
        [HttpGet]
        public IActionResult Get()
        {
            // kontrola ukoliko upit nije valjan
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var lista = _context.Osobe.ToList();
                if (lista == null || lista.Count == 0)
                {
                    return new EmptyResult();
                }
                return new JsonResult(lista.MapOsobaReadList());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                    ex.Message);
            }
        }

        /// <summary>
        /// Dohvaća sve sifru iz baze
        /// </summary>
        /// <remarks>
        /// Primjer upita
        /// 
        ///    GET api/v1/Sifra
        ///    
        /// </remarks>
        /// <returns>Sifre u bazi</returns>
        /// <response code="200">Sve OK, ako nema podataka content-length: 0 </response>
        /// <response code="400">Zahtjev nije valjan</response>
        /// <response code="503">Baza na koju se spajam nije dostupna</response>

        [HttpGet]
        [Route("{sifra:int}")]
        public IActionResult GetBySifra(int sifra)
        {
            // kontrola ukoliko upit nije valjan
            if (!ModelState.IsValid || sifra <= 0)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var osoba = _context.Osobe.Find(sifra);
                if (osoba == null)
                {
                    return BadRequest("Osoba s šifrom " + sifra + " ne postoji");
                }
                
                return new JsonResult(osoba.MapOsobaInsertUpdatedToDTO());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                    ex.Message);
            }
        }
        /// <summary>
        /// Dodaje novu osobu u bazu
        /// </summary>
        /// <remarks>
        ///     POST api/v1/Osoba
        ///     {naziv: "Primjer naziva"}
        /// </remarks>
        /// <param name="osobaDTO">Osoba za unijeti u JSON formatu</param>
        /// <response code="201">Kreirano</response>
        /// <response code="400">Zahtjev nije valjan (BadRequest)</response> 
        /// <response code="503">Baza nedostupna iz razno raznih razloga</response> 
        /// <returns>Osoba s šifrom koju je dala baza</returns>
        [HttpPost]
        public IActionResult Post(OsobaDTOInsertUpdate osobaDTO)
        {
            if (!ModelState.IsValid || osobaDTO == null)
            {
                return BadRequest();
            }
            try
            {
                var osoba = osobaDTO.MapOsobaInsertUpdateFromDTO(new Osoba());
                _context.Osobe.Add(osoba);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, osoba.MapOsobaReadToDTO());

            }catch (Exception ex)
            

            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                    ex.Message);
            }
        }

        /// <summary>
        /// Mijenja podatke postojeće osobe u bazi
        /// </summary>
        /// <remarks>
        /// Primjer upita:
        ///
        ///    PUT api/v1/osoba/1
        ///
        /// {
        ///  "sifra": 0,
        ///  "ime": "Novo ime",
        ///  "prezime": "Novo prezime",
        ///  "Email": "Novi Email",
        ///  "Broj telefona":"Novi broj telefona"
        /// }
        ///
        /// </remarks>
        /// <param name="sifra">Šifra osobe koji se mijenja</param>  
        /// <param name="osobaDTO">Osoba za unijeti u JSON formatu</param>  
        /// <returns>Svi poslani podaci od osoba koji su spremljeni u bazi</returns>
        /// <response code="200">Sve je u redu</response>
        /// <response code="204">Nema u bazi osobe kojeu želimo promijeniti</response>
        /// <response code="415">Nismo poslali JSON</response> 
        /// <response code="503">Baza nedostupna</response> 
        [HttpPut]
        [Route("{sifra:int}")]
        public IActionResult Put(int sifra, OsobaDTOInsertUpdate osobaDTO)
        {
            if (sifra <= 0 || !ModelState.IsValid || osobaDTO == null)
            {
                return BadRequest();
            }


            try
            {


                var osobaIzBaze = _context.Osobe.Find(sifra);

                if (osobaIzBaze == null)
                {
                    return BadRequest("Ne postoje osobe s šifrom " + sifra + " u bazi");
                }

                var osoba = osobaDTO.MapOsobaInsertUpdateFromDTO(osobaIzBaze);

                _context.Osobe.Update(osoba);
                _context.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, osoba.MapOsobaInsertUpdatedToDTO());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                    ex.Message);
            }

        }

        /// <summary>
        /// Briše osobu iz baze
        /// </summary>
        /// <remarks>
        /// Primjer upita:
        ///
        ///    DELETE api/v1/osoba/1
        ///    
        /// </remarks>
        /// <param name="sifra">Šifra osobe koja se briše</param>  
        /// <returns>Odgovor da li je obrisano ili ne</returns>
        /// <response code="200">Sve je u redu, obrisano je u bazi</response>
        /// <response code="204">Nema u bazi osobe kojeu želimo obrisati</response>
        /// <response code="503">Problem s bazom</response> 
        [HttpDelete]
        [Route("{sifra:int}")]
        [Produces("application/json")]
        public IActionResult Delete(int sifra)
        {
            if (!ModelState.IsValid || sifra <= 0)
            {
                return BadRequest();
            }

            try
            {
                var osobaIzbaze = _context.Osobe.Find(sifra);

                if (osobaIzbaze == null)
                {
                    return BadRequest("Ne postoji osoba s šifrom " + sifra + " u bazi");
                }

                var lista = _context.Izdatnice.Include(x => x.Osoba).Where(x => x.Osoba.Sifra == sifra).ToList();

                if (lista != null && lista.Count() > 0)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("Osoba se ne može obrisati jer je postavljena na izdatnicia: ");
                    foreach (var e in lista)
                    {
                        sb.Append(e.BrojIzdatnice).Append(", ");
                    }

                    return BadRequest(sb.ToString().Substring(0, sb.ToString().Length - 2));
                }

                _context.Osobe.Remove(osobaIzbaze);
                _context.SaveChanges();

                return Ok("Obrisano");

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                    ex.Message);
            }

        }
        [HttpGet]
        [Route("trazi/{uvjet}")]
        public IActionResult TraziOsoba(string uvjet)
        {
            // ovdje će ići dohvaćanje u bazi

            if (uvjet == null || uvjet.Length < 3)
            {
                return BadRequest(ModelState);
            }

            // ivan se PROBLEM riješiti višestruke uvjete
            uvjet = uvjet.ToLower();
            try
            {
                IEnumerable<Osoba> query = _context.Osobe;
                var niz = uvjet.Split(" ");

                foreach (var s in uvjet.Split(" "))
                {
                    query = query.Where(p => p.Ime.ToLower().Contains(s) || p.Prezime.ToLower().Contains(s));
                }


                var osobe = query.ToList();

                return new JsonResult(osobe.MapOsobaReadList()); //200

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, e.Message); //204
            }
        }


    }

}
