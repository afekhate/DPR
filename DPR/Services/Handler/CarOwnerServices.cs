using DPR.Models.Domain;
using DPR.Models.ViewModel;
using DPR.Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DPR.Services.Handler
{
    public class CarOwnerServices : ICarOwner
    {
        protected readonly appDPRContext _context;
        public CarOwnerServices(appDPRContext context)
        {
            _context = context;
        }
        



      
        public string GetCarDetails(CarOwnerViewModel car)
        {
            try
            {
                var Car = new CarOwner
                {
                    Model = car.Model,
                    Year = car.Year,
                    EngineNo = car.EngineNo,
                    ChasisNo = car.ChasisNo,
                    PlateNo = car.PlateNo,
                    BVN = car.BVN,
                    POW = car.POW,
                    Receipt = car.Receipt,
                    Litre = car.Litre,
                    DateCreated = DateTime.Now
                };

                _context.CarOwners.Add(Car);
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
