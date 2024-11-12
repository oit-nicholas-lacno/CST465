
using System.Data.SqlClient;

namespace Assignment3
{
    public class BlogDBRepository : IDataEntityRepository<BlogPost>
    {
        private readonly IConfiguration _config;

        public BlogDBRepository(IConfiguration config)
        {
            _config = config;
        }


        public BlogPost Get(int id)
        {
            BlogPost post = new BlogPost();
            using (SqlConnection conn = new SqlConnection(_config["ConnectionStrings:DB_BlogPosts"]))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT ID, Title, Content, Author, Timestamp from BlogPost WHERE ID = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        post.ID = id;
                        post.Author = (string)reader["Author"];
                        post.Content = (string)reader["Content"];
                        post.Title = (string)reader["Title"];
                        post.Timestamp = (DateTime)reader["Timestamp"];

                    }
                }
            }
            return post;
        }

        public List<BlogPost> GetList()
        {
            List<BlogPost> posts = new();
            using (SqlConnection conn = new SqlConnection(_config["ConnectionStrings:DB_BlogPosts"]))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "BlogPost_GetList";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        posts.Add(new BlogPost()
                        {
                            ID = (int)reader["ID"],
                            Author = (string)reader["Author"],
                            Title = (string)reader["Title"],
                            Content = (string)reader["Content"],
                            Timestamp = (DateTime)reader["Timestamp"]
                        });
                    }
                }
            }
            return posts;
        }

        public void Save(BlogPost entity)
        {
            using (SqlConnection conn = new SqlConnection(_config["ConnectionStrings:DB_BlogPosts"]))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "BlogPost_InsertUpdate";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", entity.ID);
                    cmd.Parameters.AddWithValue("@Author", entity.Author);
                    cmd.Parameters.AddWithValue("@Title", entity.Title);
                    cmd.Parameters.AddWithValue("@Content", entity.Content);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
