using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextBasedRPGGame.Database;

namespace TextBasedRPGGame.Controllers
{
    public class EquipmentBusiness
    {

        private MyDBcontext DbContext;

        public List<Equipment> GetAll()
        {
            using (DbContext = new MyDBcontext())
            {
                return DbContext.Equipments.ToList();
            }
        }


        public Equipment Get(int id)
        {
            using (DbContext = new MyDBcontext())
            {
                return DbContext.Equipments.Find(id);

            }
        }

        public Equipment GetEquipedByIdAndType(int owner_id, string Type)
        {
            using (DbContext = new MyDBcontext())
            {
                return DbContext.Equipments.Where(i => i.Owner_id == owner_id && i.Type == Type && i.Is_equiped == true).FirstOrDefault();
                
            }
        }


        public List<Equipment> GetAllByOwnerId(int owner_id)
        {
            using (DbContext = new MyDBcontext())
            {
                return DbContext.Equipments.Where(i => i.Owner_id == owner_id).ToList();
            }         
        }

        public List<Equipment> GetAllTypeByOwnerId(int owner_id, string Type)
        {
            using (DbContext = new MyDBcontext())
            {
                return DbContext.Equipments.Where(i => i.Owner_id == owner_id && i.Type == Type).ToList();
            }
        }

        public void Add(Equipment tool)
        {
            using (DbContext = new MyDBcontext())
            {
                DbContext.Equipments.Add(tool);
                DbContext.SaveChanges();

            }
        }

        public void AddNewItem(MarketItem tool, int id)
        {
            Equipment newItem = new Equipment { Name = tool.Name, Points = tool.Points, Is_equiped = false, Price = tool.Price, Type = tool.Type, Owner_id = id };

            using (DbContext = new MyDBcontext())
            {
                DbContext.Equipments.Add(newItem);
                DbContext.SaveChanges();

            }
        }

        public void Update(Equipment tool)
        {
            using (DbContext = new MyDBcontext())
            {

                var item = DbContext.Equipments.Find(tool.Id);
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
                var tool = DbContext.Equipments.Find(id);
                if (tool != null)
                {
                    DbContext.Equipments.Remove(tool);
                    DbContext.SaveChanges();
                }
            }
        }

    }
}
