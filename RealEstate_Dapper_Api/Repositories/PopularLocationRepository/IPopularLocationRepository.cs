using RealEstate_Dapper_Api.Dtos.ResaultPopularLocationDtos;

namespace RealEstate_Dapper_Api.Repositories.PopularLocationRepository
{

    public interface IPopularLocationRepository
    {
        Task<List<ResaultPopularLocationDto>> GetAllPopularLocationAsync();

    }

}