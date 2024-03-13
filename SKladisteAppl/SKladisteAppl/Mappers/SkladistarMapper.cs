using AutoMapper;
using SKladisteAppl.Models;

namespace SKladisteAppl.Mappers
{
    public class SkladistarMapper
    {
        public static Mapper InicijalizirajReadToDTO()
        {
            return new Mapper(
                new MapperConfiguration(c =>
                {
                    c.CreateMap<Skladistar, SkladistarDTORead>();
                })
                );
        }

        public static Mapper InicijalizirajReadFromDTO()
    {
        return new Mapper(
            new MapperConfiguration(c =>
            {
                c.CreateMap< SkladistarDTORead, Skladistar>();
            })
            );
    }

    public static Mapper InicijalizirajInsertUpdateToDTO()
    {
        return new Mapper(
            new MapperConfiguration(c =>
            {
                c.CreateMap<Skladistar, SkladistarDTOInsertUpdate>();
            })
            );
    }

}
}
