using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextBasedRPGGame.Database;

namespace TextBasedRPGGame.Controllers.ModelBusinesses
{
    public class MarketItemsBusiness
    {

        private MyDBcontext DbContext;

        public List<MarketItem> GetAll()
        {
            using (DbContext = new MyDBcontext())
            {
                return DbContext.MarketItems.ToList();
            }
        }


        public MarketItem Get(int id)
        {
            using (DbContext = new MyDBcontext())
            {
                return DbContext.MarketItems.Find(id);

            }
        }

        public List<MarketItem> GetAllByPlaceId(int place_id)
        {
            using (DbContext = new MyDBcontext())
            {
                return DbContext.MarketItems.Where(i => i.PlaceSold_id == place_id).ToList();
            }
        }

        public void Add(MarketItem tool)
        {
            using (DbContext = new MyDBcontext())
            {
                DbContext.MarketItems.Add(tool);
                DbContext.SaveChanges();

            }
        }

        public void Update(EnemyModel tool)
        {
            using (DbContext = new MyDBcontext())
            {

                var item = DbContext.MarketItems.Find(tool.Id);
                if (item != null)
                {
                    DbContext.Entry(item).CurrentValues.SetValues(tool);
                    DbContext.SaveChanges();
                }

            }
        }

        public void Delete(int id)
        {
            using (DbContext = new MyDBcontext())
            {
                var tool = DbContext.MarketItems.Find(id);
                if (tool != null)
                {
                    DbContext.MarketItems.Remove(tool);
                    DbContext.SaveChanges();
                }
            }
        }
    }
}
