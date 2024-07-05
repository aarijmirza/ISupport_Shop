//using ISupportNew_Web2.Models;
using ISupportWebsite.Models.BLL;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ISupportNew_Web2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }
        [Route("Home")]
        public IActionResult Index(int? CategoryID)
        {
            var popularService = new serviceBLL().GetPopularService();
            ViewBag.popularService = popularService;
            var categories = new categoryBLL().GetCategory();
            ViewBag.categories = categories.Take(8).ToList();
            ViewBag.categorylist = categories.Take(5).ToList();
            var serviceBanner = new BannerBLL().GetServiceBanner();
            ViewBag.serviceBanner = serviceBanner;
            var imageUrl = _configuration["ConnectionStrings:ImageUrl"];
            ViewData["ImageUrl"] = imageUrl;
            if (CategoryID == null)
            {
                var items = new ItemBLL().GetItems();
                ViewBag.items = items.Take(10).ToList();
                ViewBag.trendingItem = items.Take(4).ToList();
            }
            else
            {
                var items = new ItemBLL().GetFilterItems(CategoryID);
                ViewBag.items = items.Take(10).ToList();
            }
            return View();
        }
        [Route("About")]
        public IActionResult About()
        {
            return View();
        }
        [Route("Contact")]
        public IActionResult Contact()
        {
            return View();
        }
        [Route("Service")]
        public IActionResult Service(int? ServiceID, int? ServiceCategoryID)
        {
            var serviceCategory = new serviceCategoryBLL().GetServiceCategory();
            ViewBag.serviceCategory = serviceCategory;
            var CatCount = new serviceCategoryBLL().GetServiceCategoryCount();
            ViewBag.CatCount = CatCount;
            var serviceBanner = new BannerBLL().GetServiceBanner();
            ViewBag.serviceBanner = serviceBanner.Take(2).ToList();
            if (ServiceID != null)
            {
                var service = new serviceBLL().GetService(ServiceID);
                ViewBag.service = service;
            }
            else if (ServiceCategoryID != null)
            {
                var service = new serviceCategoryBLL().GetServiceByCategoryID(ServiceCategoryID);
                ViewBag.service = service;
            }
            else if (ServiceID == null && ServiceCategoryID == null)
            {
                var service = new serviceBLL().GetPopularService();
                ViewBag.service = service.Take(6).ToList();

            }
            else
            {
            }

            var imageUrl = _configuration["ConnectionStrings:ImageUrl"];
            ViewData["ImageUrl"] = imageUrl;
            return View();
        }
        [Route("FAQS")]
        public IActionResult Faqs()
        {
            return View();
        }
        [Route("PrivacyPolicy")]
        public IActionResult PrivacyPolicy()
        {
            return View();
        }
        [Route("TermsCondition")]
        public IActionResult TermsCondition()
        {
            return View();
        }   
        [Route("ReturnRefund")]
        public IActionResult ReturnRefund()
        {
            return View();
        }
        [Route("Wishlist")]
        public IActionResult Wishlist()
        {
            return View();
        }
    }
}
