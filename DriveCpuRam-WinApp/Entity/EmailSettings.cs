using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveCpuRam_WinApp.Entity
{
    public class EmailSettings
    {
        public string SmtpServer { get; set; } = "smtp.gmail.com";
        public int SmtpPort { get; set; } = 587; // Common port for TLS
        public string SenderEmail { get; set; } = "kenanismayilzade16@gmail.com";
        public string SenderPassword { get; set; } = "sgiw cvdu jnkk eaza";
    }
}
