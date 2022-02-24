using DPR.Models;
using DPR.Models.Domain;
using DPR.Models.ViewModel;
using DPR.Services.Contract;
using DPR.Services.FileHandler;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DPR.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICarOwner _carOwner;
        private readonly IFillingStationOwner _stationOwner;
        private readonly IFileHandler _filehandler;
        private readonly IConfiguration _configuration;


        public HomeController(ILogger<HomeController> logger, ICarOwner carOwner, IFillingStationOwner stationOwner, IFileHandler fileHandler, IConfiguration configuration)
        {
            _logger = logger;
            _carOwner = carOwner;
            _stationOwner = stationOwner;
            _filehandler = fileHandler;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Car()
        {
            return View();
        }

        [HttpGet]
        public IActionResult FillingStation()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CarDetails(CarOwnerViewModel carOwner)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    //Upload files
                    string pow = carOwner.POWs.FileName;
                    if (pow.ToLower().EndsWith(".pdf") || pow.ToLower().EndsWith(".jpg") || pow.ToLower().EndsWith(".jpeg") || pow.ToLower().EndsWith(".png"))
                    {
                        carOwner.POW = await _filehandler.UploadFile(carOwner.POWs, _configuration["temp_upload"],
                                _configuration["AllExtensionImage"], Convert.ToInt32(_configuration["oneMegaByte"]), Convert.ToInt32(_configuration["_fileMaxSize"])); ;
                    }

                    string receipt = carOwner.Receipts.FileName;
                    if (receipt.ToLower().EndsWith(".pdf") || receipt.ToLower().EndsWith(".jpg") || receipt.ToLower().EndsWith(".jpeg") || receipt.ToLower().EndsWith(".png"))
                    {
                        carOwner.POW = await _filehandler.UploadFile(carOwner.Receipts, _configuration["temp_upload"],
                                _configuration["AllExtensionImage"], Convert.ToInt32(_configuration["oneMegaByte"]), Convert.ToInt32(_configuration["_fileMaxSize"])); ;
                    }


                    var response = _carOwner.GetCarDetails(carOwner);

                    if(response == "Successful")
                    {
                        //Add toast message
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }

                else
                {
                    return View("Car", carOwner);
                }

                   
            }
            catch (Exception)
            {

                throw;
            }
           
        }


        [HttpPost]
        public async Task<IActionResult> FillingStationDetails(FillingStationOwnerViewModel fillingStation)
        {
            if (ModelState.IsValid)
            {
                //upload fiiles
               
                string certificate = fillingStation.Certificates.FileName;
                if (certificate.ToLower().EndsWith(".pdf") || certificate.ToLower().EndsWith(".jpg") || certificate.ToLower().EndsWith(".jpeg") || certificate.ToLower().EndsWith(".png"))
                {
                    fillingStation.Certificate = await _filehandler.UploadFile(fillingStation.Certificates, _configuration["temp_upload"],
                            _configuration["AllExtensionImage"], Convert.ToInt32(_configuration["oneMegaByte"]), Convert.ToInt32(_configuration["_fileMaxSize"])); ;
                }

                string manifest = fillingStation.Manifests.FileName;
                if (manifest.ToLower().EndsWith(".pdf") || manifest.ToLower().EndsWith(".jpg") || manifest.ToLower().EndsWith(".jpeg") || manifest.ToLower().EndsWith(".png"))
                {
                    fillingStation.Manifest = await _filehandler.UploadFile(fillingStation.Certificates, _configuration["temp_upload"],
                            _configuration["AllExtensionImage"], Convert.ToInt32(_configuration["oneMegaByte"]), Convert.ToInt32(_configuration["_fileMaxSize"])); ;
                }

                var response = _stationOwner.GetFillingStationDetails(fillingStation);

                if (response == "Successful")
                {
                    //Add toast message
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            else
            {
                return View("FillingStation", fillingStation);
            }

        }


        [HttpPost]
        public IActionResult ContactUs()
        {
            return RedirectToAction("Index","Home");
            
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
