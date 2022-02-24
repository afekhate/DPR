using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DPR.Models.Domain
{
    public class CarOwner : BaseObject
    {
        public string Model { get; set; }
        public string Year { get; set; }

        public string EngineNo { get; set; }

        public string ChasisNo { get; set; }

        public string PlateNo { get; set; }

        public string BVN { get; set; }

        //Proof Of Owner
        public string POW { get; set; }

        public string Receipt { get; set; }

        public long Litre { get; set; }
    }
}
