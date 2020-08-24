using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GithubRepos.Models;
using System.Net.Http;
using System.Linq.Expressions;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Nancy.Json;
using Nancy.Session;
using Microsoft.AspNetCore.Http;

namespace GithubRepos.Controllers
{

    public class HomeController : Controller
    {
        
        private readonly ILogger<HomeController> _logger;
        //static variable type of RepositoriesViewModel 
        //use for as model of repositories that saved by the user
        public static RepositoriesViewModel repositories;
        public HomeController(ILogger<HomeController> logger)
        {

           _logger = logger;
        }

     
        
        public IActionResult Index( )
        {           
            return View();
        }

        //BookMarks action method show the bookmarked repositories 
        //that saved inside session dictionary and send the model to the view

        public ActionResult BookMarks()
        {

            var BookmarksRepos = HttpContext.Session.GetObject<RepositoriesViewModel>("repos");
            return View(BookmarksRepos);
       
        }
        //get data from view by ajax call.
        //params: Bookmark - the repository that user clicked
        [HttpPost]
        public ActionResult AddBookMarks(RepositoryModel Bookmark)
        {
            try
            {
                if (repositories == null)
                {
                    repositories = new RepositoriesViewModel();
                    repositories.Repositories = new List<RepositoryModel>();
                }
                //add new bookmark to Repostories list 
                repositories.Repositories.Add(Bookmark);

                //save list to session
                HttpContext.Session.SetObject("repos", repositories);
            }
            catch (Exception)
            {

                throw;
            }

            
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public ActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
