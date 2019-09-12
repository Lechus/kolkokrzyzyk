namespace KolkoKrzyzyk.UWP.Core.Models
{
    public class Winner
    {
        public string Name { get; set; }
        public string WinnerText { get; set; }

        public Winner(string name)
        {
            Name = name;

            WinnerText = (name + " is winner!");
        }

        public Winner()
        {
        }
    }
}
