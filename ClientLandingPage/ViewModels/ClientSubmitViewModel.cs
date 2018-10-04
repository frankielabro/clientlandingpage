using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientLandingPage.ViewModels
{
    public class ClientSubmitViewModel
    {
        public string ContactName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public IFormFile UploadFile { get; set; }
        public string AdSource { get; set; }
        public string AdType { get; set; }

    }
}
