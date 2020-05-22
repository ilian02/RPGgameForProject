using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TextBasedRPGGame.Controllers.ModelBusinesses;
using TextBasedRPGGame.Database;

namespace TextBasedRPGGame
{
    public class Place
    {

        private int id;
        private String name;
        private bool forge;
        private bool bed;
        private bool arena;
        private bool shop;
        private int? nextPlace;
        private int? prevPlace;


        public String showPlaceInformation()
        {

            Console.WriteLine($"You are in {name}");
            Console.WriteLine("-----------------------");
            Console.WriteLine();
            if (forge)
            {
                showForge();
            }
            if (shop)
            {
                showShop();
            }
            if (bed)
            {
                showBed();
            }
            if (arena)
            {
                showFightEnemy();
            }
            if (nextPlace != null)
            {
                ShowNextPlace();
            }
            if (prevPlace != null)
            {
                ShowPreviousPlace();
            }

            String command = Console.ReadLine().ToLower();
            return command;
        }



        public Place(PlaceModel place)
        {
            this.id = place.Id;
            this.name = place.Name;
            this.forge = (bool)place.Forge;
            this.bed = (bool)place.Bed;
            this.shop = (bool)place.Shop;
            this.arena = (bool)place.Arena;
            this.nextPlace = place.Next_Place;
            this.prevPlace = place.Prev_Place;
        }


        public Place goToNextPlace()
        {
            PlaceBusiness pb = new PlaceBusiness();

            if (this.nextPlace == null)
            {
                Console.WriteLine("There is no next place");
                return this;
            }
            else
            {
                Place newPlace = new Place(pb.Get((int)this.nextPlace));
                Console.WriteLine("Do you wish to go to " + newPlace.Name + "?");
                Console.WriteLine("(Y)es or (N)o");
                string command = Console.ReadLine().ToLower();
                if (command == "y")
                    return newPlace;
                else 
                return this;
            }
        }

        public Place goToPrevPlace()
        {
            PlaceBusiness pb = new PlaceBusiness();

            if (this.prevPlace == null)
            {
                Console.WriteLine("There is no previous place");
                return this;
            }
            else
            {

                Place newPlace = new Place(pb.Get((int)this.prevPlace));
                Console.WriteLine("Do you wish to go to " + newPlace.Name + "?");
                Console.WriteLine("(Y)es or (N)o");
                string command = Console.ReadLine().ToLower();
                if (command == "y")
                    return newPlace;
                else
                return this;
            }

        }


        public void showForge()
        {
            Console.WriteLine("Visit (F)orge");
        }
        public void showBed()
        {
            Console.WriteLine("Go to (B)ed");
        }
        public void showFightEnemy()
        {
            Console.WriteLine("Go to (A)rena");
        }
        public void showShop()
        {
            Console.WriteLine("Visit (S)hop");
        }
        public void ShowNextPlace()
        {
            Console.WriteLine("(N)ext place");
        }

        public void ShowPreviousPlace()
        {
            Console.WriteLine("(P)revious place");
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public bool Bed
        {
            get { return bed; }
            set { bed = value; }
        }

        public bool Shop
        {
            get { return shop; }
            set { shop = value; }
        }

        public bool Forge
        {
            get { return forge; }
            set { forge = value; }
        }

        public bool Arena
        {
            get { return arena; }
            set { arena = value; }
        }
        public int? NextPlace
        {
            get { return nextPlace; }
            set { nextPlace = value; }
        }
        public int? PrevPlace
        {
            get { return prevPlace; }
            set { prevPlace = value; }
        }

    }


}
