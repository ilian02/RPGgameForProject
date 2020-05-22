using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextBasedRPGGame.Database;

namespace TextBasedRPGGame
{
    public class Enemy : LivingThing
    {

        private int xpGain;
        private int moneyGain;
        private int id;
        private int placeId;

        public Enemy(EnemyModel enemy)
        {
            this.Id = enemy.Id;
            this.Name = enemy.Name;
            this.HealthPoints = (int)enemy.Healthpoints;
            this.CurrentHealthPoints = (int)enemy.Current_healthpoints;
            this.Vitality = enemy.Vit;
            this.Dexterity = enemy.Dex;
            this.Strength = enemy.STR;
            this.Accuracy = enemy.ACC;
            this.xpGain = (int)enemy.Exp_Gain;
            this.Level = (int)enemy.EnLevel;
            this.MoneyGain = (int)enemy.Money_Gain;
            this.PlaceId = (int)enemy.Place_Id;
        }

        public int XpGain
        {
            get { return xpGain; }
            set { xpGain = value; }
        }
        public int MoneyGain
        {
            get { return moneyGain; }
            set { moneyGain = value; }
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public int PlaceId
        {
            get { return placeId; }
            set { placeId = value; }
        }
    }
}
