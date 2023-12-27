using AutoMapper;
using GestionRecursosHumanos.API.DTOs;
using GestionRecursosHumanos.API.Models;
using MongoDB.Bson;

namespace GestionRecursosHumanos.API.Mappings
{
    public class PerfilDeMapeo : Profile
    {
        public PerfilDeMapeo()
        {
            // Definicion de los mapeos
            CreateMap<Empleado, EmpleadoDTO>()
                .ForMember(dest => dest.DepartamentoId, opt => opt.MapFrom(src => src.DepartamentoId.ToString()))
                .ForMember(dest => dest.PuestoId, opt => opt.MapFrom(src => src.PuestoId.ToString()));

            CreateMap<EmpleadoDTO, Empleado>()
                .ForMember(dest => dest.DepartamentoId, opt => opt.MapFrom(src => ObjectId.Parse(src.DepartamentoId)))
                .ForMember(dest => dest.PuestoId, opt => opt.MapFrom(src => ObjectId.Parse(src.PuestoId)));
        }
    }
}
