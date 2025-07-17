using MySql.Data.MySqlClient;
using System.ComponentModel;

namespace BeatHealth.Services
{
    public class DoctorService
    { private readonly MySqlConnection _connection;
        public DoctorService(MySqlConnection connection) { _connection = connection; }
        public async Task< List<Doctor>> Get(int id) {
            List<Doctor> result = [];
            try
            {
                await _connection.OpenAsync();
                MySqlCommand cmd = new()
                {
                    Connection = _connection,
                    CommandText = "SELECT email,first_name,last_name,phone_number,birth_date,certification_num,specialty,bank_account\r\n " +
                        "FROM co.user,co.doctor_info where id=doctor_id " + ((id != 0) ? "and id= @id ;" : ";")
                };
                cmd.Parameters.AddWithValue("@id", id);
                using var reader = cmd.ExecuteReader();
                {
                    while (reader.Read())
                    {
                        result.Add(new Doctor(
                            reader.GetString("email"),
                            "",
                            reader.GetString("first_name"),
                            reader.GetString("last_name"),
                            reader.GetString("phone_number"),
                            DateOnly.FromDateTime(reader.GetDateTime("birth_date")),
                            reader.GetString("certification_num"),
                            reader.GetString("specialty"),
                            reader.GetString("bank_account")
                            ));
                    }

                }
                await _connection.CloseAsync();

            }
            catch (Exception e) { throw ; }

            return result;
        }

        public async Task<int> Post(Doctor doctor) {
            int result = 0;

                await _connection.OpenAsync();
            using var tran = await _connection.BeginTransactionAsync();


            try
            {
                
                MySqlCommand cmd1 = new()
                {
                    Connection = _connection,
                    Transaction= tran,
                    CommandText = " insert into co.`user` values" +
                    " (default,@email,@password,@first_name,@last_name,@phone_number,default,@birth_date,1) ;"
                  
                };
                cmd1.Parameters.AddWithValue("@email", doctor.Email);
                cmd1.Parameters.AddWithValue("@password", doctor.Password);
                cmd1.Parameters.AddWithValue("@first_name", doctor.FirstName);
                cmd1.Parameters.AddWithValue("@last_name", doctor.LastName);
                cmd1.Parameters.AddWithValue("@phone_number", doctor.PhoneNumber);
                cmd1.Parameters.AddWithValue("@birth_date", doctor.BirthDate.ToString("yyyy-MM-dd"));
                await cmd1.ExecuteNonQueryAsync();
                MySqlCommand cmd2 = new()
                {
                    Connection = _connection,
                    Transaction = tran,
                    CommandText = " insert into co.doctor_info values ( last_insert_id(), @certification_num,@specialty,@bank_account) ;"
                };

                cmd2.Parameters.AddWithValue("@certification_num", doctor.CertificationNum);
                cmd2.Parameters.AddWithValue("@specialty", doctor.Specialty);
                cmd2.Parameters.AddWithValue("@bank_account", doctor.BankAccount);

                await cmd2.ExecuteNonQueryAsync();

                MySqlCommand cmd3 = new() {
                Connection=_connection,
                Transaction=tran,
                CommandText = " select last_insert_id(); "
                };
                 result= Convert.ToInt32(await cmd3.ExecuteScalarAsync());

                await tran.CommitAsync();
                await _connection.CloseAsync();

            }
            catch (Exception e) { 
               await tran.RollbackAsync();
                throw; }

            return result;
        }

    }
    
}
