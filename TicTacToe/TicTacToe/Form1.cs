namespace TicTacToe
{
    public partial class Form1 : Form
    {
        List<Button> btns;
        public enum player
        {
            X, O
        }

        public player currentPlayer;
        Random random = new Random();
        int PlayerWinCount = 0;
        int ComWinCount = 0;

        public Form1()
        {
            InitializeComponent();
            RestartGame();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void PlayerClickButton(object sender, EventArgs e)
        {
            var btn = (Button)sender;

            currentPlayer = player.X;
            btn.Text = currentPlayer.ToString();
            btn.Enabled = false;

            btns.Remove(btn);
            MainGame();
            timer1.Start();

        }

        private void Restart(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void MainGame()
        {
            if ((button1.Text == "X" && button5.Text == "X" && button7.Text == "X")
                || (button3.Text == "X" && button5.Text == "X" && button9.Text == "X")
                || (button1.Text == "X" && button6.Text == "X" && button9.Text == "X")
                || (button2.Text == "X" && button5.Text == "X" && button8.Text == "X")
                || (button3.Text == "X" && button4.Text == "X" && button7.Text == "X")
                || (button1.Text == "X" && button2.Text == "X" && button3.Text == "X")
                || (button4.Text == "X" && button5.Text == "X" && button6.Text == "X")
                || (button7.Text == "X" && button7.Text == "X" && button9.Text == "X"))
            {
                timer1.Stop();
                MessageBox.Show("Player Win");
                PlayerWinCount++;
                label1.Text = "Player Wins: " + PlayerWinCount;
                RestartGame();
            }
            else if ((button1.Text == "O" && button5.Text == "O" && button7.Text == "O")
                || (button3.Text == "O" && button5.Text == "O" && button9.Text == "O")
                || (button1.Text == "O" && button6.Text == "O" && button9.Text == "O")
                || (button2.Text == "O" && button5.Text == "O" && button8.Text == "O")
                || (button3.Text == "O" && button4.Text == "O" && button7.Text == "O")
                || (button1.Text == "O" && button2.Text == "O" && button3.Text == "O")
                || (button4.Text == "O" && button5.Text == "O" && button6.Text == "O")
                || (button7.Text == "O" && button7.Text == "O" && button9.Text == "O"))
            {
                timer1.Stop();
                MessageBox.Show("Com Win");
                ComWinCount++;
                label2.Text = "Com Wins: " + ComWinCount;
                RestartGame();
            }
        }

        private void RestartGame()
        {
            btns = new List<Button> { button1, button2, button3, button4, button5, button6, button7, button8, button9};

            foreach(Button bt in btns)
            {
                bt.Enabled = true;
                bt.Text = "";
                bt.BackColor = DefaultBackColor;
            }
        }

        private void ComTurn(object sender, EventArgs e)
        {
            if(btns.Count > 0)
            {
                int i = random.Next(btns.Count);
                btns[i].Enabled = false;
                currentPlayer = player.O;
                btns[i].Text = currentPlayer.ToString();
                btns.RemoveAt(i);
                MainGame();
                timer1.Stop();
            }
        }
    }
}