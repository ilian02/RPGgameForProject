using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPGGame.Controllers
{
    class GameSetUp
    {


        public GameSetUp()
        {

        }

        public List<Hero> getHeroes()
        {
            List <Hero> heroes = new List<Hero>();

            heroes.Add(new Hero("pesho", 5, 4, 2, 3, 6, 25, 250));
            heroes.Add(new Hero("ivan", 55, 78, 25, 50, 150, 100, 1500));


            Place place = new Place("Starting Village", true, true, true, true, new List<Enemy>(), new List<Item>());
            Place place2 = new Place("Second Village", true, true, false, true, new List<Enemy>(), new List<Item>());

            heroes[0].CharPlace = place;
            heroes[1].CharPlace = place2;

            return heroes;
        }


    }
}
