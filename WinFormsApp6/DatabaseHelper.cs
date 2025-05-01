using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public class DatabaseHelper
{
    private readonly string connectionString;

    public DatabaseHelper()
    {
        // جلب سلسلة الاتصال من ملف الإعدادات
        connectionString = ConfigurationManager.ConnectionStrings["MyDBConnection"].ConnectionString;
    }

    // 1. طريقة لجلب كل المنتجات
    public DataTable GetAllProducts()
    {
        DataTable productsTable = new DataTable();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT ProductID, ProductName, Category, Price, StockQuantity FROM Products";
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(productsTable);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        return productsTable;
    }

    // 2. طريقة لإضافة منتج جديد
    public bool AddProduct(string productName, string category, decimal price, int stockQuantity)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "INSERT INTO Products (ProductName, Category, Price, StockQuantity) " +
                          "VALUES (@ProductName, @Category, @Price, @StockQuantity)";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ProductName", productName);
            command.Parameters.AddWithValue("@Category", category);
            command.Parameters.AddWithValue("@Price", price);
            command.Parameters.AddWithValue("@StockQuantity", stockQuantity);

            try
            {
                connection.Open();
                int result = command.ExecuteNonQuery();
                return result > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }
    }

    // 3. طريقة لتحديث منتج موجود
    public bool UpdateProduct(int productId, string productName, string category, decimal price, int stockQuantity)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "UPDATE Products SET " +
                          "ProductName = @ProductName, " +
                          "Category = @Category, " +
                          "Price = @Price, " +
                          "StockQuantity = @StockQuantity " +
                          "WHERE ProductID = @ProductID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ProductID", productId);
            command.Parameters.AddWithValue("@ProductName", productName);
            command.Parameters.AddWithValue("@Category", category);
            command.Parameters.AddWithValue("@Price", price);
            command.Parameters.AddWithValue("@StockQuantity", stockQuantity);

            try
            {
                connection.Open();
                int result = command.ExecuteNonQuery();
                return result > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }
    }

    // 4. طريقة لحذف منتج
    public bool DeleteProduct(int productId)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "DELETE FROM Products WHERE ProductID = @ProductID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ProductID", productId);

            try
            {
                connection.Open();
                int result = command.ExecuteNonQuery();
                return result > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }
    }

    // 5. طريقة للبحث عن منتجات حسب الفئة
    public DataTable GetProductsByCategory(string category)
    {
        DataTable productsTable = new DataTable();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT ProductID, ProductName, Price, StockQuantity " +
                          "FROM Products WHERE Category = @Category";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Category", category);

            try
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(productsTable);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        return productsTable;
    }
}
CREATE TABLE Products (
    ProductID INT PRIMARY KEY IDENTITY(1,1),
    ProductName NVARCHAR(100) NOT NULL,
    Category NVARCHAR(50) NOT NULL,
    Price DECIMAL(10,2) NOT NULL,
    StockQuantity INT NOT NULL
);
