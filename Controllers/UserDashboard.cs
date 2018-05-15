using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using UserDashboard.Models;
using System;
using Microsoft.EntityFrameworkCore;

namespace UserDashboard.Controllers{
	[Route("/")]
    public class UserDashboardController:Controller{
    	private Context context;

    	public UserDashboardController(Context context){
    		this.context = context;
    	}

        [HttpGet]
        [Route("")]
        public IActionResult Index(){
            return View("Index");
        }

        [HttpGet]
        [Route("/login")]
        public IActionResult login(){
            HttpContext.Session.Clear();
            return View("login");
        }

        [HttpGet]
        [Route("/logout")]
        public IActionResult logout(){
            return RedirectToAction("login");
        }

        [HttpPost]
        [Route("/login")]
        public IActionResult loginPost(LoginVM loginVM){
            if(ModelState.IsValid){
                User user = context.Login(loginVM);

                if(user == null){
                    ViewBag.error = "Invalid Credentials!";
                    return View("login");
                }else{
                    HttpContext.Session.SetString("id",user.Id+"");

                    if(user.admin){
                        return RedirectToAction("adminDashboard");
                    }else{
                        return RedirectToAction("dashboard");
                    }
                }
            }else{
                return View("login");
            }
        }

        [HttpGet]
        [Route("/register")]
        public IActionResult register(){
            return View("register");
        }

        [HttpPost]
        [Route("/register")]
        public IActionResult registerPost(RegisterVM registerVM){
            if(ModelState.IsValid){
                User user = context.CreateUser(registerVM);
                HttpContext.Session.SetString("id",user.Id+"");
                return RedirectToAction("register");
            }

            return View("register");
        }

        [HttpGet]
        [Route("/dashboard")]
        public IActionResult dashboard(){
            string id = HttpContext.Session.GetString("id");

            if(id == null){
                return RedirectToAction("login");
            }else{
                int uid = Int32.Parse(id);
                User user = context._users.Where(u => u.Id == uid).SingleOrDefault();
                ViewBag.user = user;
                ViewBag.users = context._users.ToList();
                return View("dashboard");
            }
        }

        [HttpGet]
        [Route("/dashboard/admin")]
        public IActionResult adminDashboard(){
            string id = HttpContext.Session.GetString("id");

            if(id == null){
                return RedirectToAction("login");
            }else{
                int uid = Int32.Parse(id);
                User user = context._users.Where(u => u.Id == uid).SingleOrDefault();
                ViewBag.user = user;

                if(user.admin){
                    ViewBag.users = context._users.ToList();
                    return View("admin");
                }else{
                    return RedirectToAction("dashboard");
                }
            }
        }

        [HttpGet]
        [Route("/users/{id}")]
        public IActionResult show(int id){
            string uid = HttpContext.Session.GetString("id");
            if(uid == null){return RedirectToAction("login");}

            ViewBag.user = context._users
            .Where(u => u.Id == id )
            .Include(u => u.posts)
            .SingleOrDefault();

            return View("show");
        }

        [HttpPost]
        [Route("/users/posts")]
        public IActionResult post(string text, int id){
            // User postee = context._users.Where(u => u.Id == id).SingleOrDefault();
            // int uid = Int32.Parse(HttpContext.Session.GetString("id"));
            // User poster = context._users.Where(u => u.Id == uid).SingleOrDefault();
            // Post post = new Post(text,poster);

            // post.poster = poster;
            // post.postee = postee;

            // context.Add(post);
            // context.SaveChanges();

            return Redirect("/users/"+id);
        }
    }
}
