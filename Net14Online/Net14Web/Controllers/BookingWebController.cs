﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualBasic;
using Net14Web.DbStuff;
using Net14Web.DbStuff.Models.BookingWeb;
using Net14Web.Models.BookingWeb;
using System.ComponentModel.Design;
using System.Linq;

namespace Net14Web.Controllers
{
    public class BookingWebController : Controller
    {
        private WebDbContext _webDbContext;

        public static List<UserLoginViewModel> userLoginViewModel = new List<UserLoginViewModel>();

        public static List<SearchResultViewModel> searchResultViewModel = new List<SearchResultViewModel>();

        public BookingWebController(WebDbContext webDbContext)
        {
            _webDbContext = webDbContext;
        }

        public IActionResult Help()
        {
            return View();
        }
        public IActionResult UserLogin()
        {
            return View(userLoginViewModel);
        }

        public IActionResult SearchResult()
        {
            var searches = _webDbContext.Searches.Include(x => x.LoginBooking).Take(10).ToList();

            var viewModels = searches.Select(search => new SearchResultViewModel
            {
                Id = search.Id,
                Country = search.Country,
                City = search.City,
                CheckinDate = search.Checkin,
                CheckoutDate = search.Checkout,
                LoginEmail = search.LoginBooking.Email
            }).ToList();

            return View(viewModels);
        }
        public IActionResult Remove(string name)
        {
            var user = userLoginViewModel.First(x => x.Name == name);
            userLoginViewModel.Remove(user);
            return RedirectToAction("UserLogin");
        }

        public IActionResult RemoveSearch(int id)
        {
            var user = _webDbContext.Searches.First(x => x.Id == id);
            _webDbContext.Searches.Remove(user);
            _webDbContext.SaveChanges();

            return RedirectToAction("SearchResult");
        }

        [HttpPost]
        public IActionResult UpdateEmail(string name, string email)
        {
            userLoginViewModel.First(x => x.Name == name).Email = email;
            return RedirectToAction("UserLogin");
        }

        [HttpPost]
        public IActionResult UpdateCity(int Id, string City)
        {
            var searches = _webDbContext.Searches.First(x => x.Id == Id);
            searches.City = City;
            _webDbContext.SaveChanges();

            return RedirectToAction("SearchResult");
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string name, string email, string password)
        {
            userLoginViewModel.Add(new UserLoginViewModel
            {
                Name = name,
                Email = email,
                Password = password
            });
            return RedirectToAction("UserLogin");
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(IndexViewModel searchResultViewModel)
        {
            var login = _webDbContext.LoginsBooking.FirstOrDefault();

            var search = new Search
            {
                Country = searchResultViewModel.Country,
                City = searchResultViewModel.City,
                Checkin = searchResultViewModel.CheckinDate, 
                Checkout = searchResultViewModel.CheckoutDate
            };
            _webDbContext.Searches.Add(search);
            _webDbContext.SaveChanges();
            return RedirectToAction("SearchResult");
        }

        [HttpGet]
        public IActionResult UserCountrySearch()
        {
            var viewModel = new UserSearchViewModel();

            viewModel.Logins = _webDbContext.LoginsBooking.Select(x => new SelectListItem(x.Name, x.Id.ToString())).ToList();
            viewModel.Searches = _webDbContext.Searches.Select(x => new SelectListItem(x.Country, x.Id.ToString())).ToList();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult UserCountrySearch(int loginId, int searchId)
        {
            return RedirectToAction("Index");
        }
    }
}