using NoneScaled.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoneScaled.Models
{
    public class User
    {
        public int id { get; set; }
        public List<Paller> pallers { get; set; } //mange til mange
        public List<TempPlates> tempPlates { get; set; } //mange til mange

        public static User GetUser(int id)
        {
            User user = null;
            try
            {   //da den kun såger behøver der ikke at være adgang til all
                using (var _reposetory = new WebbookingDBEnteties("WebBooking"))
                {
     
                    string SELECT = "SELECT [id],[vertion],[pallers],[tempPlates] ";
                    string FROM = "[bookingUser]";
                    //    string WHERE = "WHERE [WebBooking].[dbo].[bookingUser].[id]";
                    //    string Like = "like '" + id + "'";

                    string sqlCode = SELECT + FROM;// + WHERE + Like;
                    var ws = _reposetory.user.SqlQuery(sqlCode).ToList();
                    if (ws.Count != 0)
                    {
                        user = ws[0];
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            if (user == null)
            {
                user = new User() {id = -1};
            }
            return user;
        }
    }
}