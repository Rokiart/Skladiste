using AutoMapper;

using SKladisteAppl.Models;

namespace SKladisteAppl.Extensions

{ 
    /// <summary>
    /// maper
    /// </summary>
    public static class OsobaMapper
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
                    c.CreateMap<Osoba, OsobaDTORead>();
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
                    c.CreateMap<OsobaDTORead ,Osoba>();
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
                    c.CreateMap<Osoba, OsobaDTOInsertUpdate>();
                })
                );
        }
        /// <summary>
        /// update iz DTO
        /// </summary>
        /// <returns></returns>

        public static Mapper InicijalizirajInsertUpdateFromDTO()
        {
            return new Mapper(
                new MapperConfiguration(c =>
                {
                    c.CreateMap<OsobaDTOInsertUpdate, Osoba>();
                })
                );
        }
    }
}
