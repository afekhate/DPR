using DPR.Models.Domain;
using DPR.Models.ViewModel;
using DPR.Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DPR.Services.Handler
{
    public class FillingStationOwnerService : IFillingStationOwner
    {
        protected readonly appDPRContext _context;
        public FillingStationOwnerService(appDPRContext context)
        {
            _context = context;
        }
        
        public string GetFillingStationDetails(FillingStationOwnerViewModel station)
        {
            try
            {
                var FillingStationOwner = new FillingStationOwner
                {
                    BusinessName = station.BusinessName,
                    Location = station.Location,
                    Certificate = station.Certificate,
                    Merchant = station.Merchant,
                    Depot = station.Depot,
                    Carrier = station.Carrier,
                    LLB = station.LLB,
                    DeliveryTime = station.DeliveryTime,
                    Manifest = station.Manifest,
                    DPRCode = station.DPRCode,
                    DateCreated = DateTime.Now
                };

                _context.FillingStationOwners.Add(FillingStationOwner);
                _context.SaveChanges();
                return "Successful";
            }
            catch (Exception)
            {
                return "Failed";
                throw;
            }
        }
    }
}
