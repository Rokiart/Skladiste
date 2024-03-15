using AutoMapper;

using SKladisteAppl.Models;

namespace SKladisteAppl.Extensions

{ 
    /// <summary>
    /// maper
    /// </summary>
    public static class OsobaMapper
    {
        public static Mapper InicijalizirajReadToDTO()
        {
            return new Mapper(
                new MapperConfiguration(c =>
                {
                    c.CreateMap<Osoba, OsobaDTORead>();
                })
                );
        }

        public static Mapper InicijalizirajReadFromDTO()
        {
            return new Mapper(
                new MapperConfiguration(c =>
                {
                    c.CreateMap<OsobaDTORead, Osoba>();
                })
                );
        }

        public static Mapper InicijalizirajInsertUpdateToDTO()
        {
            return new Mapper(
                new MapperConfiguration(c =>
                {
                    c.CreateMap<Osoba, OsobaDTOInsertUpdate>();
                })
                );
        }
    }
}
