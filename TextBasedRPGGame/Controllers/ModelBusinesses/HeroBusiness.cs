using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextBasedRPGGame.Database;

namespace TextBasedRPGGame.Controllers
{
    public class HeroBusiness
    {

        private MyDBcontext DbContext;

        public List<HeroModel> GetAll()
        {
            using (DbContext = new MyDBcontext())
            {
                return DbContext.Heroes.ToList();
            }
        }


        public HeroModel Get(int id)
        {
            using (DbContext = new MyDBcontext())
            {
                return DbContext.Heroes.Find(id);

            }
        }

        public HeroModel GetLast()
        {
            using (DbContext = new MyDBcontext())
            {
                return DbContext.Heroes.OrderByDescending(p => p.Id)
                       .FirstOrDefault();

            }
        }

        public void Add(HeroModel hero)
        {
            using (DbContext = new MyDBcontext())
            {
                DbContext.Heroes.Add(hero);
                DbContext.SaveChanges();

            }
        }

        public void Update(HeroModel hero)
        { 
            using (DbContext = new MyDBcontext())
            {

                var item = DbContext.Heroes.Find(hero.Id);
                if (item != null)
                {
                    DbContext.Entry(item).CurrentValues.SetValues(hero);
                    DbContext.SaveChanges();
                }

            }
        }
        public void Update(Hero hero)
        {

            HeroModel heroToUpdate = new HeroModel() { Id = hero.Id, HealthPoints = hero.HealthPoints, Current_healthpoints = hero.CurrentHealthPoints, Char_level = hero.Level, Acc = hero.Accuracy, Current_place = hero.PlaceId, Dex = hero.Dexterity, Str = hero.Strength, Equiped_Armor_id = hero.Armor, Equiped_weapon_id = hero.Weapon, Exp = hero.ExperiencePoints, Money = hero.Money, Name = hero.Name, Vit = hero.Vitality};


            using (DbContext = new MyDBcontext())
            {

                var item = DbContext.Heroes.Find(heroToUpdate.Id);
                if (item != null)
                {
                    DbContext.Entry(item).CurrentValues.SetValues(heroToUpdate);
                    DbContext.SaveChanges();
                }

            }
        }

        public void Delete(int id)
        {
            using (DbContext = new MyDBcontext())
            {
                var product = DbContext.Heroes.Find(id);
                if (product != null)
                {
                    DbContext.Heroes.Remove(product);
                    DbContext.SaveChanges();
                }
            }
        }
    }
}
