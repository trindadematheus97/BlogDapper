using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using System;
using System.ComponentModel.DataAnnotations;

namespace BlogDapper
{
    public class Program
    {
        const string connectionString = "Server=DESKTOP-O1775Q7;Database=Blog;User ID=sa;Password=85882678;Encrypt=false";

        static void Main(string[] args)
        {

            Console.WriteLine("Hello World!");
            ReadUsers();
            //ReadUser();
            //InsertUser();
            //UpdateUser();
            //DeleteUser();
        }

        public static void ReadUsers()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var users = connection.GetAll<User>();
                foreach (var user in users)
                {
                    Console.WriteLine($"{user.Name}  {user.Id}");
                }
            }


        }

        public static void ReadUser()
        {

            using (var connection = new SqlConnection(connectionString))
            {
                var user = connection.Get<User>(1);
                Console.WriteLine(user.Name);

            }

        }

        public static void InsertUser()
        {
            var user = new User()
            {
                Name = "Balta",
                Bio = "Equipe Balta",
                Email = "balta@gmail.com",
                Image = "http://...",
                PasswordHash = "HASH",
                Slug = "equipe-balta"
            };
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Insert<User>(user);              
                Console.WriteLine("Usuário cadastrado com sucesso.");
            }
        }

        public static void UpdateUser()
        {
            var user = new User()
            {
                Id=5,
                Name = "Balta.io",
                Bio = "Equipe Balta",
                Email = "balta@gmail.com",
                Image = "http://...",
                PasswordHash = "HASH",
                Slug = "equipe-balta"
            };
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Update<User>(user);
                Console.WriteLine("Usuário atualizado com sucesso.");
            }


        }

        public static void DeleteUser()
        {
           
            using (var connection = new SqlConnection(connectionString))
            {
                var user = connection.Get<User>(5);
                connection.Delete<User>(user);
                Console.WriteLine("Exclusão realizada com sucesso.");
            }
        }

    }   
}   
