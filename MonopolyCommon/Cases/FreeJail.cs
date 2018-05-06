using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonopolyCommon.Cases.Categories;
using MonopolyCommon.Players;

namespace MonopolyCommon.Cases
{
    [Serializable]
    public class FreeJail : TextImageCase
    {
        public FreeJail()
        {
            Text = "FREE JAIL";
            Type = "free_jail";
            IsEditable = false;
        }

        public override void RandomFill()
        {
            
        }

        public override string Action(Player _player, Platter _platter)
        {
            return "Vous êtes en visite en prison";
        }

        public override bool IsLegal()
        {
            return true;
        }
    }
}
