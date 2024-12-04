using Lab8.DataObjects;
using System.Data;
using System.Data.SqlClient;

namespace Lab8.Repositories
{
    public class DbImageRepository : IImageRepository
    {
        private readonly IConfiguration _Config;
        public DbImageRepository(IConfiguration config)
        {
            _Config = config;
        }
        public byte[] GetImageData(int id)
        {
            byte[] imageData = new byte[0];
            using SqlConnection connection = new SqlConnection(_Config.GetConnectionString("DB_CST465"));
            using SqlCommand command = new SqlCommand("Images_GetDataByID", connection) { CommandType = CommandType.StoredProcedure };
            connection.Open();
            command.Parameters.AddWithValue("@ID", id);
            using SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                imageData = (byte[])reader["FileData"];
            }
            return imageData;
        }

        public virtual List<ImageObject> GetImages()
        {
            List<ImageObject> images = new List<ImageObject>();
            using SqlConnection connection = new SqlConnection(_Config.GetConnectionString("DB_CST465"));
            using SqlCommand command = new SqlCommand("Images_GetList", connection) { CommandType = CommandType.StoredProcedure };
            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ImageObject img = new ImageObject();

                //TODO: Set properties of object
                img.ID = (int)reader["ID"];
                img.FileName = (string)reader["FileName"];
                img.Description = (string)reader["Description"];

                images.Add(img);
            }
            return images;
        }

        public virtual void SaveImage(ImageObject image)
        {
            using SqlConnection connection = new SqlConnection(_Config.GetConnectionString("DB_CST465"));
            using SqlCommand command = new SqlCommand("Images_Insert", connection) { CommandType = CommandType.StoredProcedure };
            //TODO: Add parameters for the query
            //command.Parameters.AddWithVaule("@ID", image.ID)
            command.Parameters.AddWithValue("@FileName", image.FileName);
            command.Parameters.AddWithValue("@FileData", image.FileData);
            command.Parameters.AddWithValue("@Description", image.Description);
            connection.Open();
            command.ExecuteNonQuery();

        }
    }
}
