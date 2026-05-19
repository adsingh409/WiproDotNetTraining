using BookStoreApp.Models;
using System.Data;
using System.Data.SqlClient;


namespace BookStoreApp.Data
{
    public class BookRepository
    {
        private readonly string connectionString;

        public BookRepository(string conn)
        {
            connectionString = conn;
        }

        // 🔹 GET ALL BOOKS
        public List<Book> GetBooks()
        {
            List<Book> list = new List<Book>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Books", con);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Book
                    {
                        Id = (int)reader["Id"],
                        Title = reader["Title"].ToString(),
                        Author = reader["Author"].ToString(),
                        Price = (decimal)reader["Price"]
                    });
                }
            }
            return list;
        }

        // 🔹 ADD BOOK
        public void AddBook(Book book)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("AddBook", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Title", book.Title);
                cmd.Parameters.AddWithValue("@Author", book.Author);
                cmd.Parameters.AddWithValue("@Price", book.Price);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // 🔹 UPDATE BOOK
        public void UpdateBook(Book book)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("UpdateBook", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", book.Id);
                cmd.Parameters.AddWithValue("@Title", book.Title);
                cmd.Parameters.AddWithValue("@Author", book.Author);
                cmd.Parameters.AddWithValue("@Price", book.Price);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // 🔹 DELETE BOOK
        public void DeleteBook(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("DeleteBook", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}
