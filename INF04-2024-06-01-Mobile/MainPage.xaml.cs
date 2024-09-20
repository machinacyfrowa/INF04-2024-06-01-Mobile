namespace INF04_2024_06_01_Mobile
{
    public partial class MainPage : ContentPage
    {
        int GameScore = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void DiceRoll(object sender, EventArgs e)
        {
            //create empty array for dice
            int[] dice = new int[5]; 
            //create random object
            Random random = new Random();
            //loop through dice array
            for (int i = 0; i < dice.Length; i++)
            {
                //generate random number between 1 and 6
                dice[i] = random.Next(1, 7);
            }
            //display dice
            Dice1.Source = "k6_" + dice[0] + ".png";
            Dice2.Source = "k6_" + dice[1] + ".png";
            Dice3.Source = "k6_" + dice[2] + ".png";
            Dice4.Source = "k6_" + dice[3] + ".png";
            Dice5.Source = "k6_" + dice[4] + ".png";
            
            //look for duplicates - if found add to score
            int score = 0;
            for(int i = 1; i <= 6; i++)
            {
                //find all duplicate entities
                //count of duplicates
                int count = 0;
                //iterate array
                for(int j = 0; j < dice.Length; j++)
                {
                    if (dice[j] == i)
                    {
                        count++;
                    }
                }
                //now we know if the number exists "count" times
                //add to score count of items and their value
                if(count > 1) score += count * i;
            }
            GameScore += score;
            //display score
            RollScoreLabel.Text = "Wynik rzutu: " + score;
            GameScoreLabel.Text = "Wynik gry: " + GameScore;
        }

        private void ResetScore(object sender, EventArgs e)
        {
            GameScore = 0;
            GameScoreLabel.Text = "Wynik gry: " + GameScore;
        }
    }

}
