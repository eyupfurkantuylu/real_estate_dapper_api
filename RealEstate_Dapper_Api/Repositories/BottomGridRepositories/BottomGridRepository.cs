using Dapper;
using RealEstate_Dapper_Api.Dtos.BottomGridDtos;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.BottomGridRepositories
{

    public class BottomGridRepository: IBottomGridRepository
    {
        
        private readonly Context _context;

        public BottomGridRepository(Context context)
        {
            _context = context;
        }


        
        public async Task<List<ResaultBottomGridDto>> GetAllBottomGridAsync()
        {
            string query = "Select * From BottomGrid";

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResaultBottomGridDto>(query);
                return values.ToList();
            }
        }

        public void CreateBottomGrid(CreateBottomGridDto bottomGridDto)
        {
            throw new NotImplementedException();
        }

        public void DeleteBottomGrid(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateBottomGrid(UpdateBottomGridDto bottomGridDto)
        {
            throw new NotImplementedException();
        }

        public Task<GetBottomGridDto> GetBottomGrid(int id)
        {
            throw new NotImplementedException();
        }
    }

}