using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using NoneScaled.Models;
namespace GetFromDBDapper
{
    class DBCaller
    {
        public static User GetUser(int id) 
        {          
            User user = null;
            try
            {
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DBCaller.Connection("db")))
                {
                    string SELECT = "SELECT 'id','vertion','pallers','tempPlates' ";
                    string FROM = "[bookingUser]";
                    //    string WHERE = "WHERE [WebBooking].[dbo].[bookingUser].[id]";
                    //    string Like = "like '" + id + "'";
                    string sqlCode = SELECT + FROM;// + WHERE + Like;

                    List<User> users = connection.Query<User>(sqlCode).ToList();


                if (users.Count != 0)
                    {
                        user = users[0];
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            if (user == null)
            {
                user = new User() { id = -1 };
            }
            return user;
        }
        public static string Connection(string name) 
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
