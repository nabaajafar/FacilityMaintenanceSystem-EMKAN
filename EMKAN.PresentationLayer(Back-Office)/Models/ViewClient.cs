using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EMKAN.PresentationLayer_Back_Office_.Models
{
    public class ViewClient
    {

        public int ID { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("Email ")]
        public string Username { get; set; }
        [DisplayName("Client")]
        public string FullName { get; set; }
        [DisplayName("Phone")]
        public string Phone { get; set; }
        [DisplayName("Services No")]
        public int ServicesCount { get; set; }

        [DisplayName("Status")]
        public int Status { get; set; }

        internal Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
        {
            throw new NotImplementedException();
        }
    }



    public class UpdateActivationStatus
    {
        public int ID { get; set; }
        public int Status { get; set; }
    }
}
