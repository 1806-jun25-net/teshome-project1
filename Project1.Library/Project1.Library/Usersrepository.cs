using Project1.data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Library
{
    public class Usersrepository
    {

        private readonly Project1DBContext _db;

        public Usersrepository(Project1DBContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public IEnumerable<data.Users> GetUsers()
        {
            // disable pointless tracking for performance
            return Mapper.Map(_db.Users.Include(r => r.Review).AsNoTracking());
        }

        public void AddRestaurant(Models.Restaurant restaurant)
        {
            _db.Add(Mapper.Map(restaurant));
        }

        public void DeleteRestaurant(int restaurantId)
        {
            _db.Remove(_db.Restaurant.Find(restaurantId));
        }

        public void UpdateRestaurant(Models.Restaurant restaurant)
        {
            // calling Update would mark every property as Modified.
            // this way will only mark the changed properties as Modified.
            _db.Entry(_db.Review.Find(restaurant.Id)).CurrentValues.SetValues(Mapper.Map(restaurant));
        }

        public void AddReview(Models.Review review, Models.Restaurant restaurant)
        {
            if (restaurant != null)
            {
                // get the db's version of that restaurant
                // (can't use Find with Include)
                var contextRestaurant = _db.Restaurant.Include(r => r.Review).First(r => r.Id == restaurant.Id);
                restaurant.Reviews.Add(review);
                contextRestaurant.Review.Add(Mapper.Map(review));
            }
            else
            {
                _db.Add(Mapper.Map(review));
            }
        }

        public void DeleteReview(int reviewId)
        {
            _db.Remove(_db.Review.Find(reviewId));
        }

        public void UpdateReview(Models.Review review)
        {
            _db.Entry(_db.Review.Find(review.Id)).CurrentValues.SetValues(Mapper.Map(review));
        }

        public void Save()
        {
            _db.SaveChanges();
        }

    }
}
