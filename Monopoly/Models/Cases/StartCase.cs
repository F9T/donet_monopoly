namespace Monopoly.Models.Cases
{
    public class StartCase : AbstractCase
    {
        public StartCase()
        {
            Name = "StartCase";
            Text = "START";
        }

        public string Text { get; set; }

        public override void Action()
        {
            
        }

        public override bool IsLegal()
        {
            return true;
        }
    }
}
