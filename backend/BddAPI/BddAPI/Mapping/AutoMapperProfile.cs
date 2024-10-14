using AutoMapper;
using BddAPI.DTOs.Request;
using BddAPI.DTOs.Response;
using BddAPI.Models;

namespace BddAPI.Mapping;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<User, UserRequestDto>();
        CreateMap<UserRequestDto, User>();

        CreateMap<User, UserResponseDto>();
        CreateMap<UserResponseDto, User>();

        CreateMap<Reservation, ReservationRequestDto>();
        CreateMap<ReservationRequestDto, Reservation>();

        CreateMap<Reservation, ReservationResponseDto>();
        CreateMap<ReservationResponseDto, Reservation>();

        CreateMap<CommunityCenter, CommunityCenterRequestDto>();
        CreateMap<CommunityCenterRequestDto, CommunityCenter>();

        CreateMap<CommunityCenter, CommunityCenterResponseDto>();
        CreateMap<CommunityCenterResponseDto, CommunityCenter>();
    }
}