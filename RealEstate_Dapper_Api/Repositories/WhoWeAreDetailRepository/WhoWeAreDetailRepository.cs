using Dapper;
using RealEstate_Dapper_Api.Dtos.WhoWeAreDetailDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.WhoWeAreDetailRepository
{
    public class WhoWeAreDetailRepository : IWhoWeAreDetailRepository
    {
        private readonly Context _context;

        public WhoWeAreDetailRepository(Context context)
        {
            _context = context;
        }

        public async void CreateWhoWeAreDetail(CreateWhoWeAreDetailDto whoWeAreDetailDto)
        {

            string query = "INSERT INTO WhoWeAreDetail (Title,Subtitle,Description1,Description2) values (@title,@subtitle,@description1,@description2)";
            var parameters = new DynamicParameters();

            parameters.Add("@title", whoWeAreDetailDto.Title);
            parameters.Add("@subtitle", whoWeAreDetailDto.Subtitle);
            parameters.Add("@description1", whoWeAreDetailDto.Description1);
            parameters.Add("@description2", whoWeAreDetailDto.Description2);
            parameters.Add("@whoWeAreDetailStatus", true);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteWhoWeAreDetail(int id)
        {
            string query = "DELETE FROM WhoWeAreDetail WHERE WhoWeAreDetailID=@whoWeAreDetailID";

            var parameters = new DynamicParameters();
            parameters.Add("@whoWeAreDetailID", id);


            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultWhoWeAreDetailDto>> GetAllWhoWeAreDetailAsync()
        {
            string query = "Select * From WhoWeAreDetail";

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultWhoWeAreDetailDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIDWhoWeAreDetailDto> GetWhoWeAreDetail(int id)
        {
            string query = "SELECT * FROM WhoWeAreDetail WHERE WhoWeAreDetailID=@whoWeAreDetailID";

            var parameters = new DynamicParameters();

            parameters.Add("@whoWeAreDetailID", id);

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryFirstOrDefaultAsync<GetByIDWhoWeAreDetailDto>(query, parameters);
                return result;
            }
        }

        public async void UpdateWhoWeAreDetail(UpdateWhoWeAreDetailDto whoWeAreDetailDto)
        {
            string query = @"UPDATE WhoWeAreDetail SET
                                Title=@title,
                                Subtitle=@subtitle,
                                Description1=@description1,
                                Description2=@description2
                            where WhoWeAreDetailID=@whoWeAreDetailID";

            var parameters = new DynamicParameters();
            parameters.Add("@title", whoWeAreDetailDto.Title);
            parameters.Add("@subtitle", whoWeAreDetailDto.Subtitle);
            parameters.Add("@description1", whoWeAreDetailDto.Description1);
            parameters.Add("@description2", whoWeAreDetailDto.Description2);
            parameters.Add("@whoWeAreDetailID", whoWeAreDetailDto.WhoWeAreDetailID);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}