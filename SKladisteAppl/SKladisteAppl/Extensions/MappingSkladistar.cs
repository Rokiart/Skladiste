using SKladisteAppl.Models;
using SKladisteAppl.Mappers;

namespace SKladisteAppl.Extensions
{
    public class MappingSKladistar
    {
        /// <summary>
        /// mapiranje liste
        /// </summary>
        /// <param name="lista"></param>
        /// <returns></returns>

        public static List<SkladistarDTORead> MapSkladistarReadList(this List<Skladistar> lista)
        {
            var mapper = SkladistarMapper.InicijalizirajReadToDTO();
            var vrati = new List<SkladistarDTORead>();
            lista.ForEach(e => {
                vrati.Add(mapper.Map<SkladistarDTORead>(e));
            });
            return vrati;
        }
       /// <summary>
       /// kreiranje liste
       /// </summary>
       /// <param name="lista"></param>
       /// <returns></returns>

        public static List<SkladistarDTORead> MapSkladistarTODTO(this List<Skladistar> lista)
        {
            var mapper = SkladistarMapper.InicijalizirajReadToDTO();
            var vrati = new List<SkladistarDTORead>();
            lista.ForEach(e => {
                vrati.Add(mapper.Map<SkladistarDTORead>(e));
            });
            return vrati;
        }
        /// <summary>
        /// kreiranje entiteta
        /// </summary>
        /// <param name="entitet"></param>
        /// <returns></returns>
        public static SkladistarDTORead MapSkladistarReadToDTO(this Skladistar entitet)
        {
            var mapper = SkladistarMapper.InicijalizirajReadToDTO();
            return mapper.Map<SkladistarDTORead>(entitet);
        }

        /// <summary>
        /// mapiranje SKladistara
        /// </summary>
        /// <param name="entitet"></param>
        /// <returns></returns>
        public static Osoba MapSKladistarInsertUpdateFromDTO(this SkladistarDTOInsertUpdate dto, Skladistar entitet)
        {
            entitet.Ime = dto.Ime;
            entitet.Prezime = dto.Prezime;
            entitet.BrojTelefona = dto.BrojTelefona;
            entitet.Email = dto.Email;
            return entitet;

        }
    }
}
