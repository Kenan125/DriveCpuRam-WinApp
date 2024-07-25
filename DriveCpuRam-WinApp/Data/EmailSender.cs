using DriveCpuRam_WinApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DriveCpuRam_WinApp.Data
{
    public class EmailSender
    {
        private readonly EmailSettings _emailSettings;
        private readonly string _recipientEmail;

        public EmailSender(string recipientEmail, EmailSettings emailSettings)
        {
            _recipientEmail = recipientEmail;
            _emailSettings = emailSettings;
        }

        public void SendEmail(CpuInfoEntity cpuInfoEntity, RamInfoEntity ramInfoEntity, List<object[]> driveInfos)
        {
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(_emailSettings.SenderEmail);
                    mail.To.Add(_recipientEmail);
                    mail.Subject = "PC Info Update";
                    mail.Body = $"Hello, this is your PC info:\n\n" +
                                $"CPU Info:\n" +
                                $"Name: {cpuInfoEntity.CpuName}\n" +
                                $"Cores: {cpuInfoEntity.CpuCore}\n" +
                                $"Usage: {Math.Round(cpuInfoEntity.CpuUsage, 2)}%\n\n" +
                                $"RAM Info:\n" +
                                $"Total: {ramInfoEntity.RamTotal} GB\n" +
                                $"Available: {ramInfoEntity.RamAvailable} GB\n" +
                                $"Used: {ramInfoEntity.RamUsed} GB\n" +
                                $"Usage: {ramInfoEntity.RamPercentage}%\n\n" +
                                $"Drive Info:\n";

                    foreach (var driveInfo in driveInfos)
                    {
                        mail.Body += $"Drive: {driveInfo[0]}\n" +
                                     $"Total Space: {Math.Round((double)driveInfo[1], 2)} GB\n" +
                                     $"Available Space: {Math.Round((double)driveInfo[2], 2)} GB\n" +
                                     $"Used Space: {Math.Round((double)driveInfo[3], 2)} GB\n" +
                                     $"Used Percentage: {Math.Round((double)driveInfo[4], 2)}%\n\n";
                    }

                    using (SmtpClient smtp = new SmtpClient(_emailSettings.SmtpServer, _emailSettings.SmtpPort))
                    {
                        smtp.Credentials = new NetworkCredential(_emailSettings.SenderEmail, _emailSettings.SenderPassword);
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while sending email: " + ex.Message);
            }
        }
    }
}
