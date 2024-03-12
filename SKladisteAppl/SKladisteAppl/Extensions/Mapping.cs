
using SKladisteAppl.Models;

namespace SKladisteAppl.Extensions
{
   /// <summary>
   /// mapiranje
   /// </summary>
    public static class Mapping
    {
        /// <summary>
        /// mapiranje liste
        /// </summary>
        /// <param name="lista"></param>
        /// <returns></returns>

        public static List<OsobaDTORead> MapOsobaReadList(this List<Osoba> lista)
        {
            var mapper = OsobaMapper.InicijalizirajReadToDTO();
            var vrati = new List<OsobaDTORead>();
            lista.ForEach(e => {
                vrati.Add(mapper.Map<OsobaDTORead>(e));
            });
            return vrati;
        }
       /// <summary>
       /// mapiranje entiteta
       /// </summary>
       /// <param name="entitet"></param>
       /// <returns></returns>

        public static OsobaDTORead MapOsobaReadToDTO(this Osoba entitet)
        {
            var mapper = OsobaMapper.InicijalizirajReadToDTO();
            return mapper.Map<OsobaDTORead>(entitet);
        }
        /// <summary>
        /// mapiranje osobe
        /// </summary>
        /// <param name="entitet"></param>
        /// <returns></returns>
        public static Osoba MapOsobaInsertUpdateFromDTO(this OsobaDTOInsertUpdate entitet)
        {
            var mapper = OsobaMapper.InicijalizirajInsertUpdateFromDTO();
            return mapper.Map<Osoba>(entitet);
        }

    }
}
