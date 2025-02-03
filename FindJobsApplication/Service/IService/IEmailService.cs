using FindJobsApplication.Models;

namespace FindJobsApplication.Service.IService
{
    public interface IEmailService
    {
        public void SendMail(string title, string recip, string s);
        public void SendRegisterMail(string recip, string name, string username, string pw);
        public void SendChangePasswordMail(string recip, string name, string pw);
        public void SendForgotPasswordMail(string recip, string name, string pw);
        public void SendConfirmQ(string recip, string name, string title);
        public void SendResponseQ(string recip, string name, string title, string messageQ, string response);
        public void SendApllyJobNotification(string recip, JobApply jobApply, Employee employee);
    }
}