using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dining.DAL;
using Dining.Models;

namespace Dining.Controllers
{
    public class HomeController : Controller
    {
        DiningContext context = new DiningContext();

        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Find(string search)
        {
            var query = from p in context.dining_restaurants
                        where p.city.ToLower().Contains(search)
                        select p;
            return View(query.ToList());
        }

        public ActionResult CreateRestaurant()
        {
            return View();
        }

        public ActionResult AllReviewsByUser(int id)
        {
            var name = context.dining_restaurant_reviews.SingleOrDefault(r => r.Restaurant_Review_Id == id).user_name;
            var query = from r in context.dining_restaurant_reviews
                        join d in context.dining_restaurants
                        on r.restaurant_Id equals d.restaurant_Id
                        where r.user_name.ToLower() == name.ToLower()
                        select new
                        {
                            rating = r.rating,
                            comment = r.comment,
                            name = d.name
                        };
            List<ReviewWithRestaurantNameVM> lstreview = new List<ReviewWithRestaurantNameVM>();
            ReviewWithRestaurantNameVM reviewVM;
            foreach (var r in query.ToList())
            {
                reviewVM = new ReviewWithRestaurantNameVM();
                reviewVM.rating = r.rating;
                reviewVM.comment = r.comment;
                reviewVM.restaurant_name = r.name;
                lstreview.Add(reviewVM);
            }
            ViewBag.Name = name;
            return View(lstreview);
        }

        [HttpPost]
        public ActionResult CreateRestaurant(Restaurant restaurant)
        {
            context.dining_restaurants.Add(restaurant);
            context.SaveChanges();
            return View();
        }

        public ActionResult Reviews(int restaurantId)
        {
            var query = from r in context.dining_restaurants
                        where r.restaurant_Id.Equals(restaurantId)
                        select r;
            return View(query.First());
        }
        public ActionResult AddReview(int id)
        {
            Restaurant_Review review = new Restaurant_Review();
            review.restaurant_Id = id;
            return View(review);
        }

        public ActionResult DeleteReview(int id)
        {
            var query = from p in context.dining_restaurant_reviews
                        where p.Restaurant_Review_Id.Equals(id)
                        select p;

            Restaurant_Review review = query.FirstOrDefault();
            return View(review);
        }

        [HttpPost]
        public ActionResult DeleteReview(Restaurant_Review review)
        {
            var itemToRemove = context.dining_restaurant_reviews.SingleOrDefault(x => x.Restaurant_Review_Id == review.Restaurant_Review_Id);
            if (itemToRemove != null)
            {
                context.dining_restaurant_reviews.Remove(itemToRemove);
                context.SaveChanges();
            }
            return View("Index");
        }

        [HttpPost]
        public ActionResult AddReview(Restaurant_Review review)
        {
            var query = from r in context.dining_restaurants
                        where r.restaurant_Id.Equals(review.restaurant_Id)
                        select r;
            Restaurant restaurant = query.FirstOrDefault();
            restaurant.reviews.Add(review);
            context.SaveChanges();
            return View("Index");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}