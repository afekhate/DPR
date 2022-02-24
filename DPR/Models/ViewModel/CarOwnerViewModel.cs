using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DPR.Models.ViewModel
{
    public class CarOwnerViewModel
    {
        public string Model { get; set; }
        public string Year { get; set; }

        public string EngineNo { get; set; }

        public string ChasisNo { get; set; }

        public string PlateNo { get; set; }

        public string Phone { get; set; }
        public string BVN { get; set; }

        //Proof Of Owner
        public string POW { get; set; }

        public string Receipt { get; set; }


        public IFormFile POWs { get; set; }

        public IFormFile Receipts { get; set; }

        public long Litre { get; set; }
    }
}
