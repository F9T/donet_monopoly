using System;
using MonopolyCommon.Cases.Categories;
using MonopolyCommon.Players;

namespace MonopolyCommon.Cases
{
    [Serializable]
    public class ChanceCase : TextImageCase
    {
        public ChanceCase()
        {
            //Default values
            Text = "CHANCE";
            ImagePath = "";
            Type = "Chance";
        }

        public override void RandomFill()
        {

        }

        public override void Action(Player _player, Platter _platter)
        {

        }

        public override bool IsLegal()
        {
            return true;
        }
    }
}
