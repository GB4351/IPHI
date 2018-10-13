using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConnectionSQL_webAPI_.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net.Mail;
using System.Net;

namespace ConnectionSQL_webAPI_.Controllers
{
    public class UserController : Controller
    {
        

        // GET: User
        public ActionResult Index(UserRecords ur)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["Myconn"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string s1 = "SELECT * FROM [dbo].[User]";
            SqlCommand sqlcomm = new SqlCommand(s1);
            sqlcomm.Connection = sqlconn;
            sqlconn.Open();
            SqlDataReader sdr = sqlcomm.ExecuteReader();
            List<UserRecords> objmodel = new List<UserRecords>();
            if(sdr.HasRows)
            {
                while(sdr.Read())
                {
                    var details = new UserRecords();
                    details.FirstName = sdr["FirstName"].ToString();
                    details.MiddleName = sdr["MiddleName"].ToString();
                    details.LastName = sdr["LastName"].ToString();
                    details.EmailAddress = sdr["EmailAddress"].ToString();
                    details.Password = sdr["Password"].ToString();
                    details.PhoneNumber = sdr["PhoneNumber"].ToString();
                    objmodel.Add(details);
                }
                ur.userinfo = objmodel;
                sqlconn.Close();
            }
            return View("Index",ur);
        }

        [HttpGet]
        public ActionResult Registration(int id = 0)
        {
            User usermodel = new User();
            usermodel.UserTypesCollection = new List<UserType>();
            using (IPHISEntities dbModel = new IPHISEntities())
            {
                var v = dbModel.UserTypes.OrderBy(x => x.UserTypeId);
                int a = v.Count();
                foreach (UserType t in v)
                    usermodel.UserTypesCollection.Add(new UserType
                     {
                        UserTypeId=t.UserTypeId,
                        TypeName=t.TypeName
                     });
                return View(usermodel);
            }
        }

        [HttpPost]
        public ActionResult Registration(User usermodel)
        {
            User usermodel1 = new User();
            usermodel.AddressId = 1;
            usermodel.UserId = 12;
            usermodel.LoginErrorMessage = "No error";
            using (IPHISEntities dbmodel = new IPHISEntities())
            {
                //dbmodel.Addresses.Add(usermodel);
                dbmodel.Users.Add(usermodel);
                usermodel1.UserTypesCollection = dbmodel.UserTypes.ToList<UserType>();
                dbmodel.SaveChanges();


                //var emp = dbmodel.User_Addr_Sec_Ans(usermodel.FirstName, usermodel.MiddleName, usermodel.LastName, usermodel.EmailAddress, usermodel.Password, usermodel.PhoneNumber, usermodel.UserUniqueId, usermodel.UserTypeId);
            }

            ModelState.Clear();
            ViewBag.SuccessMessage = "Registration Successfull.";
            return View("Registration", new User_Addr_Sec_Ans_Result());

            
        }

        

        //[HttpGet]
        //public ActionResult Question(int id=0)
        //{
        //    Answer answermodel = new Answer();
        //    using (UserModels dbmodel = new UserModels())
        //    {
        //        answermodel.QuestionCollection = dbmodel.SecurityQuestions.ToList<SecurityQuestion>();

        //    }
        //        return View(answermodel);
        //}

        //[HttpPost]
        //public ActionResult Question(Answer answermodel)
        //{
            
        //    return View();
        //}

        [HttpGet]
        public ActionResult Login(int id = 0)
        {
            User usermodel = new User();
            return View(usermodel);
        }

        [HttpPost]
        public ActionResult Login(User usermodel)
        {
            using (IPHISEntities dbmodel = new IPHISEntities())
            {
                //var userDetails = dbmodel.Users.Where(x => x.EmailAddress == usermodel.EmailAddress && string.Compare(usermodel.Password,Crypto.Hash(x.Password))==0).FirstOrDefault();
                var userDetails = dbmodel.Users.FirstOrDefault(x => x.EmailAddress == usermodel.EmailAddress);
                if (userDetails==null)
                {
                    
                    usermodel.LoginErrorMessage = "Invalid Email or Password.";
                    return View("Login", usermodel);
                }
                else 
                {
                    if (userDetails.Password == Crypto.Hash(usermodel.Password))
                    {
                        Session["userID"] = userDetails.UserId;
                        Session["firstName"] = userDetails.FirstName;
                        Session["lastName"] = userDetails.LastName;
                        return RedirectToAction("Default_P", "Patient", new { firstName = Session["firstName"].ToString(), lastName = Session["lastName"].ToString() });

                    }
                }
                return View();
                
            }
           
        }

        public ActionResult Logout()
        {
            int userId = (int)Session["userID"];
            Session.Abandon();
            return RedirectToAction("Login","User");
        }


        //Verify Account  

        [HttpGet]
        public ActionResult VerifyAccount(string id)
        {
            bool Status = false;
            using (IPHISEntities dc = new IPHISEntities())
            {
                dc.Configuration.ValidateOnSaveEnabled = false; // This line I have added here to avoid 
                                                                // Confirm password does not match issue on save changes
                var v = dc.Users.Where(a => a.ActivationCode == new Guid(id)).FirstOrDefault();
                if (v != null)
                {
                    v.IsEmailVerified = true;
                    dc.SaveChanges();
                    Status = true;
                }
                else
                {
                    ViewBag.Message = "Invalid Request";
                }
            }
            ViewBag.Status = Status;
            return View();
        }

        //Is Email Exist
        [NonAction]
        public bool IsEmailExist(string emailID)
        {
            using (IPHISEntities dc = new IPHISEntities())
            {
                var v = dc.Users.Where(a => a.EmailAddress == emailID).FirstOrDefault();
                return v != null;
            }
        }

        //Send Verification Link Email
        [NonAction]
        public void SendVerificationLinkEmail(string emailID, string activationCode, string emailFor = "ResetPassword")
        {
            var verifyUrl = "/User/" + emailFor + "/" + activationCode;
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);


            var fromEmail = new MailAddress("megaproject.g5@gmail.com", "IPHIS");
            var toEmail = new MailAddress(emailID);
            var fromEmailPassword = "iphis.g5"; // Replace with actual password

            string subject = "";
            string body = "";
            if (emailFor == "VerifyAccount")
            {
                subject = "Your account is successfully created!";
                body = "<br/><br/>We are excited to tell you that your IPHIS account is" +
                    " successfully created. Please click on the below link to verify your account" +
                    " <br/><br/><a href='" + link + "'>" + link + "</a> ";

            }
            else if (emailFor == "ResetPassword")
            {
                subject = "Reset Password";
                body = "Hi,<br/><br/>We got request for reset your account password. Please click on the below link to reset your password" +
                   "<br/><br/><a href=" + link + ">Reset Password link</a>";

            }


            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
            };

            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
                smtp.Send(message);
        }

        //Forgot Password
        public ActionResult ForgotPassword()
        {
            return View();
        }
        //Forgot Password-2
        [HttpPost]
        public ActionResult ForgotPassword(string EmailAddress)
        {
            //Verify Email ID
            //Generate Reset password link 
            //Send Email 
            string message = " ";


            using (IPHISEntities dc = new IPHISEntities())
            {
                var account = dc.Users.Where(a => a.EmailAddress == EmailAddress).FirstOrDefault();
                if (account != null)
                {
                    //Send email for reset password
                    string resetCode = Guid.NewGuid().ToString();
                    SendVerificationLinkEmail(account.EmailAddress, resetCode, "ResetPassword");
                    account.ResetPasswordCode = resetCode;
                    //This line I have added here to avoid confirm password not match issue , as we had added a confirm password property 
                    //in our model class in part 1
                    dc.Configuration.ValidateOnSaveEnabled = false;
                    dc.SaveChanges();
                    message = "Reset password link has been sent to your email id.";
                    
                }
                else
                {
                    message = "Account not found";
                }
            }
            ViewBag.Message = message;
            return View();
        }

        //Reset Password
        public ActionResult ResetPassword(string id)
        {
            //Verify the reset password link
            //Find account associated with this link
            //redirect to reset password page
            if (string.IsNullOrWhiteSpace(id))
            {
                return HttpNotFound();
            }

            using (IPHISEntities dc = new IPHISEntities())
            {
                var user = dc.Users.Where(a => a.ResetPasswordCode == id).FirstOrDefault();
                if (user != null)
                {
                    ResetPasswordModel model = new ResetPasswordModel();
                    model.ResetCode = id;
                    return View(model);
                    
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }
        //Reset Password-2
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassword(ResetPasswordModel model)
        {
            var message = "";
            
            if (ModelState.IsValid)
            {
                using (IPHISEntities dc = new IPHISEntities())
                {
                    var user = dc.Users.Where(a => a.ResetPasswordCode == model.ResetCode).FirstOrDefault();
                    if (user != null)
                    {
                        user.Password = Crypto.Hash(model.NewPassword);
                        user.ResetPasswordCode = "";
                        dc.Configuration.ValidateOnSaveEnabled = false;
                        dc.SaveChanges();
                        message = "New password updated successfully";
                        return RedirectToAction("Login", "User");
                    }
                }
            }
            else
            {
                message = "Something invalid";
            }
            ViewBag.Message = message;
            return View(model);
        }
    }
}