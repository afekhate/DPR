using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DPR.Models.ViewModel
{
    public class FillingStationOwnerViewModel
    {
        public string BusinessName { get; set; }

        public string Location { get; set; }

        public string Certificate { get; set; }

        public IFormFile Certificates { get; set; }

        public string Merchant { get; set; }

        public string Depot { get; set; }

        public string Carrier { get; set; }

        //Last Litre Bought
        public long LLB { get; set; }

        public DateTime DeliveryTime { get; set; }

        public string Manifest { get; set; }

        public IFormFile Manifests { get; set; }



        public string DPRCode { get; set; }
    }
}
