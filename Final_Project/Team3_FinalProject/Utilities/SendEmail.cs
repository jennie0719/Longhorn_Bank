using System;
using System.Net.Mail;
using System.Net;

namespace Team3_FinalProject.SendMail
{
    public static class EmailMessaging
    {
        public static void SendEmail(String toEmailAddress, String emailSubject, String emailBody)
        {
          
            //Create a variable for YOUR TEAM'S Email address
            //This is the address that will be SENDING the emails (the FROM address)
            //TODO: Change this to YOUR TEAM's email address
            String strFromEmailAddress = "team03mis33k@gmail.com";

            //This is the password for YOUR TEAM'S "fake" Gmail account
            //TODO: Change this password to your team's Gmail account password
            String strPassword = "xizwnnpucufzqvhr";

            //This is the name of the business from which you are sending
            //TODO: Change this to the name of the company you are creating the website for
            String strCompanyName = "LonghornBank03";
            
            
            //Create an email client to send the emails
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                UseDefaultCredentials = false,
                //This is the SENDING email address and password
                //This will be your team's email address and password
                Credentials = new NetworkCredential(strFromEmailAddress, strPassword),
                EnableSsl = true
            };


            //Add anything that you need to the body of the message
            //emailBody is passed into the method as a parameter
            // /n is a new line – this will add some white space after the main body of the message
            //TODO: Change or remove the disclaimer below
            String finalMessage = emailBody + "\n\n This is a disclaimer that will be on all messages.";

            //Create an email address object for the sender address
            MailAddress senderEmail = new MailAddress(strFromEmailAddress, strCompanyName);

            //Create a new mail message
            MailMessage mm = new MailMessage();

            //Set the subject line of the message (including your team number)
            //TODO: Change XX to your team number.
            mm.Subject = "Team 03 - " + emailSubject;

            //Set the sender address
            mm.Sender = senderEmail;

            //Set the from address
            mm.From = senderEmail;

            //Add the recipient (passed in as a parameter) to the list of people receiving the email
            mm.To.Add(new MailAddress(toEmailAddress));

            //Add the message (passed)
            mm.Body = finalMessage;

            //Using HTML Format
            mm.IsBodyHtml = true;

            //send the message!
            client.Send(mm);
        }
    }
}