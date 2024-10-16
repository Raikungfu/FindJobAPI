using System.Net.Mail;
using System.Net;
using System.Text.RegularExpressions;
using FindJobsApplication.Service.IService;

namespace FindJobsApplication.Service
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SendRegisterMail(string recip, string name, string username, string pw)
        {
            string message = string.Format("<!DOCTYPE html>\r\n<html lang=\"en\">\r\n<head>\r\n    " +
                    "<meta charset=\"UTF-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n    " +
                    "<title>Đăng ký thành công - Jobby</title>\r\n</head>\r\n<body>\r\n    <h2>Đăng ký thành công!</h2>\r\n    " +
                    "<p>Xin chào <strong>{0},</strong></p>\r\n    " +
                    "<p>Chúc mừng bạn đã đăng ký thành công trên Jobby!</p>\r\n    " +
                    "<p>Tên đăng nhập của bạn: <strong>{1}</strong></p>\r\n    " +
                    "<p>Mật khẩu của bạn: <strong>{2}</strong></p>\r\n    " +
                    "<p>Cảm ơn bạn đã sử dụng dịch vụ của chúng tôi!</p>\r\n     <p>Trân trọng,</p>\r\n    " +
                    "<p style=\"font-style: italic; font-weight: bold;\">Đội ngũ Jobby</p>\r\n</body>\r\n</html>\r\n\r\n\r\n" +
                    "<h3 style=\"color:red;\">Jobby - Việc làm mê ly</h3>\r\n    " +
                    "<p style=\"font-style: italic;\">Uy tín - Tận tâm - Nhanh chóng - Thuận tiện</p>\r\n</body>\r\n</html>\r\n", name, username, pw);
            try
            {
                checkEmailValid(recip);
                SendMail("Đăng ký thành công - Jobby", recip, message);
            }
            catch (Exception ex)
            {
                throw new Exception("Email không thể gửi. " + ex.Message);
            }
        }

        public void SendConfirmQ(string recip, string name, string title)
        {
            string message = string.Format("<!DOCTYPE html>\r\n<html lang=\"en\">\r\n<head>\r\n    " +
                    "<meta charset=\"UTF-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n    " +
                    "<title>Xác Nhận Yêu Cầu! Jobby!</title>\r\n</head>\r\n<body>\r\n    <h2>Xác Nhận Yêu Cầu Thành Công!</h2>\r\n    " +
                    "<p>Xin chào <strong>{0},</strong></p>\r\n    " +
                    "<p>Yêu cầu của bạn: <span style=\"color:red; font-style: italic;\">{1}</span> đang được xử lý. Chúng tôi sẽ phản hồi trong vòng 24 giờ!</p>\r\n    " +
                    "<p>Cảm ơn bạn đã sử dụng dịch vụ của chúng tôi!</p>\r\n    <p>Trân trọng,</p>\r\n    " +
                    "<p style=\"font-style: italic; font-weight: bold;\">Đội ngũ Jobby</p>\r\n</body>\r\n</html>\r\n\r\n\r\n" +
                    "<h3 style=\"color:red;\">Jobby - Việc làm mê ly</h3>\r\n    " +
                    "<p style=\"font-style: italic;\">Uy tín - Tận tâm - Nhanh chóng - Thuận tiện</p>\r\n</body>\r\n</html>\r\n", name, title);
            try
            {
                checkEmailValid(recip);
                SendMail("Xác Nhận Yêu Cầu Thành Công! Jobby!", recip, message);
            }
            catch (Exception ex)
            {
                throw new Exception("Email không thể gửi đi. " + ex.Message);
            }
        }

        public void SendResponseQ(string recip, string name, string title, string messageQ, string response)
        {
            string message = string.Format("<!DOCTYPE html>\r\n<html lang=\"en\">\r\n<head>\r\n    " +
                    "<meta charset=\"UTF-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n    " +
                    "<title>Phản Hồi Yêu Cầu! Jobby!</title>\r\n</head>\r\n<body>\r\n    <h2>Phản Hồi Đối Với Yêu Cầu Của Bạn,</h2>\r\n    " +
                    "<p>Xin chào <strong>{0},</strong></p>\r\n    " +
                    "<p>Chúng tôi đã nhận được yêu cầu của bạn. Yêu cầu của bạn: <span style=\"color:red; font-style: italic;\">{1}</span></p>\r\n    " +
                    "<p>Thông điệp: <span style=\"color:red; font-style: italic;\">{2}</span> </p>\r\n    " +
                    "<p>Phản hồi: <span style=\"color:red; font-style: italic;\">{3}</span> </p>\r\n    " +
                    "<p>Cảm ơn bạn đã sử dụng dịch vụ của chúng tôi!</p>\r\n    <p>Trân trọng,</p>\r\n    " +
                    "<p style=\"font-style: italic; font-weight: bold;\">Đội ngũ Jobby</p>\r\n</body>\r\n</html>\r\n\r\n\r\n" +
                    "<h3 style=\"color:red;\">Jobby - Việc làm mê ly</h3>\r\n    " +
                    "<p style=\"font-style: italic;\">Uy tín - Tận tâm - Nhanh chóng - Thuận tiện</p>\r\n</body>\r\n</html>\r\n", name, title, messageQ, response);
            try
            {
                checkEmailValid(recip);
                SendMail("Phản Hồi Yêu Cầu! Jobby!", recip, message);
            }
            catch (Exception ex)
            {
                throw new Exception("Email không thể gửi đi. " + ex.Message);
            }
        }

        public void SendChangePasswordMail(string recip, string name, string pw)
        {
            string message = string.Format("<!DOCTYPE html>\r\n<html lang=\"en\">\r\n<head>\r\n    " +
                    "<meta charset=\"UTF-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n    " +
                    "<title>Đổi mật khẩu thành công - Jobby</title>\r\n</head>\r\n<body>\r\n    <h2>Đổi mật khẩu thành công!</h2>\r\n    " +
                    "<p>Xin chào <strong>{0},</strong></p>\r\n    " +
                    "<p>Mật khẩu mới của bạn: <strong>{1}</strong></p>\r\n    " +
                    "<p>Cảm ơn bạn đã sử dụng dịch vụ của chúng tôi!</p>\r\n      <p>Trân trọng,</p>\r\n    " +
                    "<p style=\"font-style: italic; font-weight: bold;\">Đội ngũ Jobby</p>\r\n</body>\r\n</html>\r\n\r\n\r\n" +
                    "<h3 style=\"color:red;\">Jobby - Việc làm mê ly</h3>\r\n    " +
                    "<p style=\"font-style: italic;\">Uy tín - Tận tâm - Nhanh chóng - Thuận tiện</p>\r\n</body>\r\n</html>\r\n", name, pw);
            try
            {
                SendMail("Đổi mật khẩu thành công - Jobby", recip, message);
            }
            catch (Exception ex)
            {
                throw new Exception("Email không thể gửi. " + ex.Message);
            }
        }

        public void SendForgotPasswordMail(string recip, string name, string password)
        {
            string message = string.Format("<!DOCTYPE html>\r\n<html lang=\"en\">\r\n<head>\r\n    " +
                    "<meta charset=\"UTF-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n    " +
                    "<title>Quên Mật Khẩu! Jobby!</title>\r\n</head>\r\n<body>\r\n    <h2>Lấy Lại Mật Khẩu Thành Công!</h2>\r\n    " +
                    "<p>Xin chào <strong>{0},</strong></p>\r\n    " +
                    "<p>Mật khẩu cũ của bạn:<strong> {1}</strong></p>\r\n    " +
                    "<p>Vui lòng thay đổi mật khẩu ngay khi nhận được email này</p>\r\n    " +
                    "<p>Cảm ơn bạn đã sử dụng dịch vụ của chúng tôi!</p>\r\n    <p>Trân trọng,</p>\r\n    " +
                    "<p style=\"font-style: italic; font-weight: bold;\">Đội ngũ Jobby</p>\r\n</body>\r\n</html>\r\n\r\n\r\n" +
                    "<h3 style=\"color:red;\">Jobby - Việc làm mê ly</h3>\r\n    " +
                    "<p style=\"font-style: italic;\">Uy tín - Tận tâm - Nhanh chóng - Thuận tiện</p>\r\n</body>\r\n</html>\r\n", name, password);
            try
            {
                SendMail("Quên Mật Khẩu! Jobby!", recip, message);
            }
            catch (Exception ex)
            {
                throw new Exception("Email không thể gửi đi. " + ex.Message);
            }
        }

        public async void SendMail(string title, string recip, string s)
        {
            try
            {
                string fromMail = _configuration["EmailSetting:EmailID"];
                string fromPassword = _configuration["EmailSetting:AppPassword"];
                MailMessage message = new MailMessage();
                message.From = new MailAddress(fromMail);
                message.Subject = title;
                message.To.Add(new MailAddress(recip));
                message.Body = s;
                message.IsBodyHtml = true;

                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(fromMail, fromPassword),
                    EnableSsl = true,
                };

                await smtpClient.SendMailAsync(message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void checkEmailValid(string email)
        {
            try
            {
                string pattern = @"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$";
                if (!Regex.IsMatch(email, pattern))
                {
                    throw new Exception("Email invalid!");
                }
                string[] domain = email.Split('@');
                if (domain.Length >= 2)
                {
                    IPHostEntry emailEntry = Dns.GetHostEntry(domain[domain.Length - 1]);
                    if (emailEntry == null || emailEntry.AddressList.Length == 0)
                    {
                        throw new Exception("Email invalid!");
                    }
                }
                else
                {
                    throw new Exception("Email invalid!");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}