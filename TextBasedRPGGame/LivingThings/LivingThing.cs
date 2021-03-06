﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPGGame
{
    public class LivingThing
    {

        private int healthPoints;
        private int currentHealthPoints;

        private int vitality;
        private int dexterity;
        private int strength;
        private int accuracy;
        private int level;

        private String name;


        public int HealthPoints
        {
            get { return healthPoints; }
            set { healthPoints = value; }
        }

        public int CurrentHealthPoints
        {
            get { return currentHealthPoints; }
            set { currentHealthPoints = value; }
        }

        public int Vitality
        {
            get { return vitality;}
            set { vitality = value; }
        }

        public int Dexterity
        {
            get { return dexterity; }
            set { dexterity = value; }
        }

        public int Strength
        {
            get { return strength; }
            set { strength = value; }
        }

        public int Accuracy
        {
            get { return accuracy; }
            set { accuracy = value; }
        }

        public int Level
        {
            get { return level; }
            set { level = value; }
        }

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

    }
}
