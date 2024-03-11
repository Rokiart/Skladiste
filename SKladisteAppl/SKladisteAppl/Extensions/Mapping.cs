using SKladisteAppl.Mappers;
using SKladisteAppl.Models;

namespace SKladisteAppl.Extensions
{
    public static class Mapping
    {

        public static List<OsobaDTORead> MapOsobaReadList(this List<Osoba> lista)
        {
            var mapper = OsobaMapper.InicijalizirajReadToDTO();
            var vrati = new List<OsobaDTORead>();
            lista.ForEach(e => {
                vrati.Add(mapper.Map<OsobaDTORead>(e));
            });
            return vrati;
        }

        public static OsobaDTORead MapOsobaReadToDTO(this Osoba entitet)
        {
            var mapper = OsobaMapper.InicijalizirajReadToDTO();
            return mapper.Map<OsobaDTORead>(entitet);
        }

        public static Osoba MapOsobaInsertUpdateFromDTO(thisOsobaDTOInsertUpdate entitet)
        {
            var mapper = OsobaMapper.InicijalizirajInsertUpdateFromDTO();
            return mapper.Map<Osoba>(entitet);
        }

    }
}
