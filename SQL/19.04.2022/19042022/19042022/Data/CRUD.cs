using _19042022.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace _19042022.Data
{
    internal class CRUD
    {
        public static void AddPost(string title, string content)
        {
            using (SqlConnection con = new SqlConnection(DataBase.conStr))
            {
                con.Open();
                string query = "INSERT INTO Posts (Title,Content) VALUES (@title,@content)";
                using (SqlCommand cmd = new SqlCommand(query,con))
                {
                    cmd.Parameters.AddWithValue("title", title);
                    cmd.Parameters.AddWithValue("content", content);
                    var result = cmd.ExecuteNonQuery();
                    Console.WriteLine($"{result} sayda data insert edildi");
                }
            }
        }
        public static void EditPostTitle(int id,string title)
        {
            using (SqlConnection con = new SqlConnection(DataBase.conStr))
            {
                con.Open();
                string query = $"UPDATE Posts SET Title = @title WHERE Id = {id}";
                using (SqlCommand cmd = new SqlCommand(query,con))
                {
                    cmd.Parameters.AddWithValue("title", title);
                    var result = cmd.ExecuteNonQuery();
                    Console.WriteLine($"{result} sayda data update edildi");
                }
            }
        }
        public static void GetPostById(int id)
        {
            using (SqlConnection con = new SqlConnection(DataBase.conStr))
            {
                con.Open();
                string query = $"SELECT * FROM Posts WHERE Id={id}";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {                    
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        int id_ = dr.GetInt32(0);
                        string title = dr.GetString(1);
                        string content = dr.GetString(2);
                        Post post = new Post()
                        {
                            Id = id_,
                            Title = title,
                            Content = content,
                        };
                        post.ShowInfo();
                    }
                }
            }
        }
        public static void GetAllPosts()
        {
            using (SqlConnection con = new SqlConnection(DataBase.conStr))
            {
                con.Open();
                string query = $"SELECT * FROM Posts";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        int id_ = dr.GetInt32(0);
                        string title = dr.GetString(1);
                        string content = dr.GetString(2);
                        Post post = new Post()
                        {
                            Id = id_,
                            Title = title,
                            Content = content,
                        };
                        post.ShowInfo();
                    }
                }
            }
        }
        public static void DeletePost(int id)
        {
            using (SqlConnection con = new SqlConnection(DataBase.conStr))
            {
                con.Open();
                string query = $"DELETE FROM Posts WHERE Id = {id}";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    var result = cmd.ExecuteNonQuery();
                    Console.WriteLine($"{result} sayda data delete edildi");
                }
            }
        }
    }
}
