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

        public override string Action(Player _player, Platter _platter)
        {
            //TODO random chance action

            _player.Balance += 100;
            return "C'est un carte chance. Vous recevez 100.";
        }

        public override bool IsLegal()
        {
            return true;
        }
    }
}
