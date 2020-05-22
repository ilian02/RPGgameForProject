using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextBasedRPGGame.Database;

namespace TextBasedRPGGame.Controllers
{
    class GameSetUp
    {


        public GameSetUp()
        {

        }

        public List<HeroModel> getHeroes()
        {

            HeroBusiness HeroBus = new HeroBusiness();

            return HeroBus.GetAll();

        }


    }
}
