using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPGGame.Models
{
    public class CharacterCreation
    {

        public String nickname { get; set; }

        public CharacterCreation(String name)
        {
            this.nickname = name;
        }

    }
}
