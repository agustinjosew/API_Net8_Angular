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
                .ForMember(dest => dest.DepartamentoId, opt => opt.MapFrom(src => IsValidObjectId(src.DepartamentoId) ? ObjectId.Parse(src.DepartamentoId) : ObjectId.Empty))
                .ForMember(dest => dest.PuestoId, opt => opt.MapFrom(src => IsValidObjectId(src.PuestoId) ? ObjectId.Parse(src.PuestoId) : ObjectId.Empty));

        }

        private static bool IsValidObjectId(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) return false;

            return ObjectId.TryParse(id, out _);
        }
    }
}
