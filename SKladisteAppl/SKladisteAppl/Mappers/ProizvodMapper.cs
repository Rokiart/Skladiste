using AutoMapper;
using SKladisteAppl.Models;

namespace SKladisteAppl.Mappers
{
    /// <summary>
    /// mapiranje proizvoda
    /// </summary>
    public class ProizvodMapper
    {
        /// <summary>
        /// inicijalizacija
        /// </summary>
        /// <returns></returns>
        public static Mapper InicijalizirajReadToDTO()
        {
            return new Mapper(
                new MapperConfiguration(c =>
                {
                    c.CreateMap<Proizvod, ProizvodDTORead>();
                })
                );
        }
        /// <summary>
        /// read inicijalizacije
        /// </summary>
        /// <returns></returns>

        public static Mapper InicijalizirajReadFromDTO()
        {
            return new Mapper(
                new MapperConfiguration(c =>
                {
                    c.CreateMap<ProizvodDTORead, Proizvod>();
                })
                );
        }
        /// <summary>
        /// update
        /// </summary>
        /// <returns></returns>

        public static Mapper InicijalizirajInsertUpdateToDTO()
        {
            return new Mapper(
                new MapperConfiguration(c =>
                {
                    c.CreateMap<Proizvod, ProizvodDTOInsertUpdate>();
                })
                );
        }
    }
}
