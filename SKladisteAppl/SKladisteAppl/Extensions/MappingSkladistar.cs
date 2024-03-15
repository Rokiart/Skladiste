using SKladisteAppl.Models;
using AutoMapper;
using SKladisteAppl.Mappers;

namespace SKladisteAppl.Extensions
{
    public class MappingSKladistar
    {




        public static List<SkladistarDTORead> MapSkladistarReadList(this List<Skladistar> lista)
        {
            var mapper = SkladistarMapper.InicijalizirajReadToDTO();
            var vrati = new List<SkladistarDTORead>();
            lista.ForEach(e =>
            {
                vrati.Add(mapper.Map<SkladistarDTORead>(e));
            });
            return vrati;
        }

        public static SkladistarDTORead MapSkladistarReadToDTO(this Skladistar entitet)
        {
            var mapper = SkladistarMapper.InicijalizirajReadToDTO();
            return mapper.Map<SkladistarDTORead>(entitet);
        }

        public static SkladistarDTOInsertUpdate MapSkladistarInsertUpdatedToDTO(this Skladistar entitet)
        {
            var mapper = SkladistarMapper.InicijalizirajInsertUpdateToDTO();
            return mapper.Map<SkladistarDTOInsertUpdate>(entitet);
        }

        public static Skladistar MapSkladistarInsertUpdateFromDTO(this SkladistarDTOInsertUpdate dto, Skladistar entitet)
        {
            entitet.Ime = dto.ime;
            entitet.Prezime = dto.Prezime;
            entitet.BrojTelefona = dto.BrojTelefona;
            entitet.Email = dto.Email;

            return entitet;
        }

    }
        
}
