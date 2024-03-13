using SKladisteAppl.Models;
using SKladisteAppl.Mappers;
namespace SKladisteAppl.Extensions
{

    /// <summary>
    /// 
    /// </summary>
    public class MappingProizvod
    {
        /// <summary>
        /// mapiranje liste
        /// </summary>
        /// <param name="lista"></param>
        /// <returns></returns>

        public static List<ProizvodDTORead> MapProizvodReadList(this List<Proizvod> lista)
        {
            var mapper = ProizvodMapper.InicijalizirajReadToDTO();
            var vrati = new List<ProizvodDTORead>();
            lista.ForEach(e => {
                vrati.Add(mapper.Map<ProizvodDTORead>(e));
            });
            return vrati;
        }
        /// <summary>
        /// mapiranje entiteta
        /// </summary>
        /// <param name="entitet"></param>
        /// <returns></returns>

        public static ProizvodDTORead MapOsobaReadToDTO(this Proizvod entitet)
        {
            var mapper = ProizvodMapper.InicijalizirajReadToDTO();
            return mapper.Map<ProizvodDTORead>(entitet);
        }
        /// <summary>
        /// mapiranje Proizvoda
        /// </summary>
        /// <param name="entitet"></param>
        /// <returns></returns>
        public static Proizvod MapProizvodInsertUpdateFromDTO(this ProizvodDTOInsertUpdate dto, Proizvod entitet)
        {
            entitet.Naziv = dto.naziv;
            entitet.Sifraproizvoda = dto.sifraproizvoda;
            entitet.Mjernajedinica = dto.mjernajedinica;
            return entitet;

        }
    }
}
