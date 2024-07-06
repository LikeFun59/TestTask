using Microsoft.Data.SqlClient;

namespace TestTask
{
    public class DbConnect
    {
        static string connectString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=F:\\Users\\rockb\\source\\repos\\TestTask\\TestTask\\LocalDB.mdf;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectString);

        /// <summary>
        /// Проверку подключения к БД
        /// </summary>
        /// <returns></returns>
        public async Task ConnectToDb()
        {
            try
            {
                // Открываем подключение
                await connection.OpenAsync();
                Console.WriteLine("Подключение в БД выполнено");
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Проверка закрытия подключения к БД
        /// </summary>
        /// <returns></returns>
        public async Task CloseConnectToDb()
        {
            try
            {
                // Открываем подключение
                await connection.CloseAsync();
                Console.WriteLine("Отключение от БД выполнено");
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Добавление данных в БД или обновления
        /// </summary>
        /// <param name="word">Слово</param>
        /// <param name="count">Количество</param>
        /// <param name="procedure">Тип процедуры InsertProcedure или UpdateProcedure</param>
        public async Task InsertUpdateData(string word, int count, string procedure)
        {
            SqlCommand command = new SqlCommand(procedure, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@word", word);
            command.Parameters.AddWithValue("@count", count);
            command.ExecuteNonQuery();
        }

        public async Task<string> FindWord(string word)
        {
            try
            {
                string sqlString = $"SELECT Counts FROM DataTable WHERE Word = N'{word}'";
                SqlCommand command = new SqlCommand(sqlString, connection);
#pragma warning disable CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
                return command.ExecuteScalar().ToString();
#pragma warning restore CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
            }
            catch
            {
                return "";
            }
        }
    }
}
