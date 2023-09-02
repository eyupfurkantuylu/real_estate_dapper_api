using Dapper;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Dtos.ServiceDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ServiceRepository
{
    public class ServiceRepository : IServiceRepository
    {

        private readonly Context _context;

        public ServiceRepository(Context context)
        {
            _context = context;
        }
        
        public async Task<List<ResaultServiceDto>> GetAllServiceAsync()
        {
            string query = "Select * From Service";

            using(var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResaultServiceDto>(query);
                return values.ToList();
            }
        }

        public void CreateService(CreateServiceDto serviceDto)
        {
            throw new NotImplementedException();
        }

        public void DeleteService(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateService(UpdateServiceDto serviceDto)
        {
            throw new NotImplementedException();
        }

        public Task<GetByIDServiceDto> GetService(int id)
        {
            throw new NotImplementedException();
        }
    }
}

