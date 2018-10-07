using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientLandingPage.ViewModels
{
    public class ClientUploadFileViewModel
    {
        public int ClientId { get; set; }
        public IFormFile UploadFile { get; set; }
    }
}
