using MonopolyCommon.Cases.Categories;
using MonopolyCommon.Players;

namespace MonopolyCommon.Cases
{
    public class ChestCase : TextImageCase
    {
        public ChestCase()
        {
            //Default values
            Text = "COMMUNITY CHEST";
            ImagePath = "";
            Type = "Chest";
        }

        public override void RandomFill()
        {

        }

        public override string Action(Player _player, Platter _platter)
        {
            //TODO random in action

            //Remove nbPlayer*50
            _player.Balance -= (_platter.Players.Count - 1)*50;

            //Add 50 to each other players
            foreach(Player player in _platter.Players)
            {
                if (player != _player)
                    player.Balance += 50;
            }
            
            return "Vous récupérez un carte communautaire. Payez 50 à chaque joueur.";
        }

        public override bool IsLegal()
        {
            return true;
        }
    }
}
