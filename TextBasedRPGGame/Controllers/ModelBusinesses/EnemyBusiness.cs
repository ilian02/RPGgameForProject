using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextBasedRPGGame.Database;

namespace TextBasedRPGGame.Controllers
{
    public class EnemyBusiness
    {

        private MyDBcontext DbContext;

        public List<EnemyModel> GetAll()
        {
            using (DbContext = new MyDBcontext())
            {
                return DbContext.Enemies.ToList();
            }
        }


        public EnemyModel Get(int id)
        {
            using (DbContext = new MyDBcontext())
            {
                return DbContext.Enemies.Find(id);

            }
        }

        public void Add(EnemyModel enemy)
        {
            using (DbContext = new MyDBcontext())
            {
                DbContext.Enemies.Add(enemy);
                DbContext.SaveChanges();

            }
        }

        public List<EnemyModel> GetAllByOwnerId(int owner_id)
        {
            using (DbContext = new MyDBcontext())
            {
                return DbContext.Enemies.Where(i => i.Place_Id == owner_id).ToList();
            }
        }

        public void Update(EnemyModel enemy)
        {
            using (DbContext = new MyDBcontext())
            {

                var item = DbContext.Enemies.Find(enemy.Id);
                if (item != null)
                {
                    DbContext.Entry(item).CurrentValues.SetValues(enemy);
                    DbContext.SaveChanges();
                }

            }
        }

        public void Delete(int id)
        {
            using (DbContext = new MyDBcontext())
            {
                var enemy = DbContext.Enemies.Find(id);
                if (enemy != null)
                {
                    DbContext.Enemies.Remove(enemy);
                    DbContext.SaveChanges();
                }
            }
        }
    }
}
