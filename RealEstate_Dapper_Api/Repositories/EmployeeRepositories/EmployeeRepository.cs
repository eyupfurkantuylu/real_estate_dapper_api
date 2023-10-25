using Dapper;
using RealEstate_Dapper_Api.Dtos.EmployeeDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.EmployeeRepositories
{

    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly Context _context;

        public EmployeeRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResaultEmployeeDto>> GetAllEmployeeAsync()
        {
            string query = "Select * From Employee";

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResaultEmployeeDto>(query);
                return values.ToList();
            }
        }

        public async void CreateEmployee(CreateEmployeeDto employeeDto)
        {
            string query =
                "INSERT INTO Employee (Name, Title, Mail, PhoneNumber, ImageUrl,Status) values (@name,@title, @mail, @phoneNumber, @imageUrl, @status)";
            var parameters = new DynamicParameters();

            parameters.Add("@name", employeeDto.Name);
            parameters.Add("@title", employeeDto.Title);
            parameters.Add("@mail", employeeDto.Mail);
            parameters.Add("@phoneNumber", employeeDto.PhoneNumber);
            parameters.Add("@imageUrl", employeeDto.ImageUrl);
            parameters.Add("@status", true);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteEmployee(int id)
        {
            string query = "DELETE FROM Employee WHERE EmployeeID=@employeeId";

            var parameters = new DynamicParameters();
            parameters.Add("@employeeId", id);


            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task UpdateEmployee(UpdateEmployeeDto employeeDto)
        {
            string query =
                "Update Employee Set Name=@name,Title=@title,Mail=@mail,PhoneNumber=@phoneNumber,ImageUrl=@imageUrl,Status=@status where EmployeeID=@employeeId";
            var parameters = new DynamicParameters();

            parameters.Add("@name", employeeDto.Name);
            parameters.Add("@title", employeeDto.Title);
            parameters.Add("@mail", employeeDto.Mail);
            parameters.Add("@phoneNumber", employeeDto.PhoneNumber);
            parameters.Add("@imageUrl", employeeDto.ImageUrl);
            parameters.Add("@status", employeeDto.Status);
            parameters.Add("@employeeId", employeeDto.EmployeeID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<GetByIDEmployeeDto> GetEmployee(int id)
        {
            string query = "SELECT * FROM Employee WHERE EmployeeID=@EmployeeID";

            var parameters = new DynamicParameters();

            parameters.Add("@EmployeeID", id);

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryFirstOrDefaultAsync<GetByIDEmployeeDto>(query, parameters);
                return result;
            }
        }
    }

}