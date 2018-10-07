using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientLandingPage.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string UploadFile { get; set; }
        public string AdSource { get; set; }
        public string AdType { get; set; }
        
    }
}
