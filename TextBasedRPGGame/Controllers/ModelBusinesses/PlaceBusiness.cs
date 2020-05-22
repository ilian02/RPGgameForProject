using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextBasedRPGGame.Database;

namespace TextBasedRPGGame.Controllers.ModelBusinesses
{
    public class PlaceBusiness
    {

        private MyDBcontext DbContext;

        public List<PlaceModel> GetAll()
        {
            using (DbContext = new MyDBcontext())
            {
                return DbContext.Place.ToList();
            }
        }


        public PlaceModel Get(int id)
        {
            using (DbContext = new MyDBcontext())
            {
                return DbContext.Place.Find(id);
            }
        }

        public List<MarketItem> GetAllByPlaceId(int place_id)
        {

            using (DbContext = new MyDBcontext())
            {

                var shopItems = DbContext.MarketItems.Where(i => i.PlaceSold_id == place_id).ToList();


                return shopItems;
            }
        }

        public void Add(PlaceModel place)
        {
            using (DbContext = new MyDBcontext())
            {
                DbContext.Place.Add(place);
                DbContext.SaveChanges();

            }
        }

        public void Update(PlaceModel place)
        {
            using (DbContext = new MyDBcontext())
            {

                var item = DbContext.Place.Find(place.Id);
                if (item != null)
                {
                    DbContext.Entry(item).CurrentValues.SetValues(place);
                    DbContext.SaveChanges();
                }

            }
        }

        public void Delete(int id)
        {
            using (DbContext = new MyDBcontext())
            {
                var place = DbContext.Place.Find(id);
                if (place != null)
                {
                    DbContext.Place.Remove(place);
                    DbContext.SaveChanges();
                }
            }
        }

    }
}
