using DrugMApi.Models;
using System.Net.Mail;
using System.Net;

namespace DrugMApi.Repos
{
    public class LoginRepo
    {
        private readonly mdContext _db;



        public LoginRepo(mdContext db)
        {
            _db = db;
        }
        public User Logins(User u)
        {
            if (u.UserId != 0)
            {
                var result = (from i in _db.Users where i.UserPassword == u.UserPassword && i.UserId == u.UserId select i).SingleOrDefault();

                return result;
            }
            else
            {
                _db.Add(u);
                _db.SaveChanges();
                var senderEmail = new MailAddress("librarymanagement13@gmail.com", "Melbourne Drugs");
                var receiverEmail = new MailAddress(u.Email, "Receiver");
                var password = "kigksgbmzemtqrax";
                var sub = "Hello " + u.UserName + "! Welcome to Pizza Day";
                var body = "Your User Id: " + u.UserId + " And your password is :" + u.UserPassword;
                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(senderEmail.Address, password)
                };
                using (var mess = new MailMessage(senderEmail, receiverEmail)
                {
                    Subject = sub,
                    Body = body
                })
                {
                    smtp.Send(mess);



                }
                return u;
            }
        }

        public User Registers(User u)
        {
            _db.Add(u);
            _db.SaveChanges();
            return u;

        }

        //public Admin AdminLogin(Admin u)
        //{
        //    if (u.AdminId != 0)
        //    {
        //        var result = (from i in _db.admins where i.password == u.password && i.AdminId == u.AdminId select i).SingleOrDefault();

        //        return result;
        //    }
        //    else
        //    {
        //        return null;
        //    }

        //}
        public Admin AdminLogin(Admin a)
        {
            if (a.AdminId != 0)
            {
                var result = (from i in _db.Admins where i.AdminPassword == a.AdminPassword && i.AdminId == a.AdminId select i).SingleOrDefault();

                return result;
            }
            else
            {
                _db.Admins.Add(a);
                _db.SaveChanges();
                return a;
            }
        }

        public List<User> UserList()
        {
            List<User> u1 = _db.Users.ToList();
            return u1;
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
