using AutoMapper;
using SKladisteAppl.Models;

namespace SKladisteAppl.Mappers
{
    public class IzdatnicaMapper
    {
        public static Mapper InicijalizirajReadToDTO()
        {
            return new Mapper(
            new MapperConfiguration(c =>
            {
                c.CreateMap<Izdatnica, IzdatnicaDTORead>()
                .ConstructUsing(entitet =>
                 new IzdatnicaDTORead(
                    entitet.Sifra,
                    entitet.BrojIzdatnice,
                    entitet.Osoba == null ? "" : entitet.Osoba.Ime,
                        +" " + entitet.Osoba.Prezime).Trim(),
                    entitet.Skladistar == null ? "" : (entitet.Skladistar.Ime
                        + " " + entitet.Skladistar.Prezime).Trim(),
                    entitet.Proizvodi!.Count(),
                    entitet.Datum,
                    entitet.Napomena;
                   
            })
            );
        }



        public static Mapper InicijalizirajInsertUpdateToDTO()
        {
            return new Mapper(
             new MapperConfiguration(c =>
             {
                 c.CreateMap<Izdatnica, IzdatnicaDTOInsertUpdate>()
                 .ConstructUsing(entitet =>
                  new IzdatnicaDTOInsertUpdate(
                     entitet.BrojIzdatnice,
                     entitet.Osoba == null ? null : entitet.Osoba.Sifra,
                     entitet.Skladistar == null ? null : entitet.Skladistar.Sifra,
                     entitet.Datum,
                     entitet.Napomena))
                 ;
             })
             );
        }
    }
}
