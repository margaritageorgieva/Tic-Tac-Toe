using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    public partial class Form3 : Form
    {
        bool turn = false;
        int turnCount = 0;

        bool COMPUTER = false;
        bool match_over = false;

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
           

            EnableButtons(false);


            //check if AI is active
            if (turn == false && COMPUTER)
            {
                AI_move();
            }

        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {

            p1.Text = "Player 1";
            p2.Text = " COMPUTER ";
            if (p2.Text.ToUpper() == " COMPUTER ")
            { COMPUTER = true; }
            else
            { COMPUTER = false; }



            EnableButtons(true);

            EnablePlayerOptions(false);
            turn = false;
            turnCount = 0;
            match_over = false;
            foreach (Control c in Controls)
            {
                try
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }//end try
                catch
                { }
            }//end of foreach loop

            //check if AI is active
            if (turn == false && COMPUTER)
            {
                AI_move();
            }
        }//end for New game button

        private void EnablePlayerOptions(bool enable)
        {
            p1.Enabled = enable;
            p2.Enabled = enable;
        }
        private void EnableButtons(bool enable)
        {

            A1.Enabled = enable;
            B1.Enabled = enable;
            C1.Enabled = enable;
            A2.Enabled = enable;
            B2.Enabled = enable;
            C2.Enabled = enable;
            A3.Enabled = enable;
            B3.Enabled = enable;
            C3.Enabled = enable;

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" Играете срещу компютър.Който първи запълни ред,стълб или диагонал със своя знак ПЕЧЕЛИ !");
        }



        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            if (turn)
            {
                b.Text = "X";
            }
            else
            {
                b.Text = "O";
            }

            b.Enabled = false;
            turnCount++;
            turn = !turn;
            winner();

            //check if AI is active
            if (turn == false && COMPUTER)
            {
                AI_move();
            }
        }//end for button click method 
        private void AI_move()
        {

            Button move = null;

            move = win_Or_Block("O");//look for the  win
            if (move == null)
            {
                move = win_Or_Block("X");//look for the block
                if (move == null)
                {
                    move = center_tile();//always get center tile
                    if (move == null)
                    {
                        move = corner_tile();
                        if (move == null)
                        {
                            move = open_space();
                        }
                    }
                }
            }
            if (!match_over)
            { move.PerformClick(); }
        }//end of ai_move        

        private Button center_tile()
        {
            if (B2.Text == "")
            { return B2; }
            return null;
        }

        private Button open_space()
        {
            Console.WriteLine("Looking for open space");
            Button b = null;
            foreach (Control c in Controls)
            {
                b = c as Button;
                if (b != null)
                {
                    if (b.Text == "")
                        return b;
                }//end if
            }//end if

            return null;
        }

        private Button corner_tile()
        {
            Console.WriteLine("Looking for corner");
            if (A1.Text == "O")
            {
                if (A3.Text == "")
                    return A3;
                if (C3.Text == "")
                    return C3;
                if (C1.Text == "")
                    return C1;
            }

            if (A3.Text == "O")
            {
                if (A1.Text == "")
                    return A1;
                if (C3.Text == "")
                    return C3;
                if (C1.Text == "")
                    return C1;
            }

            if (C3.Text == "O")
            {
                if (A1.Text == "")
                    return A3;
                if (A3.Text == "")
                    return A3;
                if (C1.Text == "")
                    return C1;
            }

            if (C1.Text == "O")
            {
                if (A1.Text == "")
                    return A3;
                if (A3.Text == "")
                    return A3;
                if (C3.Text == "")
                    return C3;
            }

            if (A1.Text == "")
                return A1;
            if (A3.Text == "")
                return A3;
            if (C1.Text == "")
                return C1;
            if (C3.Text == "")
                return C3;

            return null;

        }

        private Button win_Or_Block(string mark)
        {
            Console.WriteLine("Looking for win or block:  " + mark);

            //HORIZONTAL TESTS
            if ((A1.Text == mark) && (A2.Text == mark) && (A3.Text == ""))
                return A3;
            if ((A2.Text == mark) && (A3.Text == mark) && (A1.Text == ""))
                return A1;
            if ((A1.Text == mark) && (A3.Text == mark) && (A2.Text == ""))
                return A2;

            if ((B1.Text == mark) && (B2.Text == mark) && (B3.Text == ""))
                return B3;
            if ((B2.Text == mark) && (B3.Text == mark) && (B1.Text == ""))
                return B1;
            if ((B1.Text == mark) && (B3.Text == mark) && (B2.Text == ""))
                return B2;

            if ((C1.Text == mark) && (C2.Text == mark) && (C3.Text == ""))
                return C3;
            if ((C2.Text == mark) && (C3.Text == mark) && (C1.Text == ""))
                return C1;
            if ((C1.Text == mark) && (C3.Text == mark) && (C2.Text == ""))
                return C2;

            //VERTICAL TESTS
            if ((A1.Text == mark) && (B1.Text == mark) && (C1.Text == ""))
                return C1;
            if ((B1.Text == mark) && (C1.Text == mark) && (A1.Text == ""))
                return A1;
            if ((A1.Text == mark) && (C1.Text == mark) && (B1.Text == ""))
                return B1;

            if ((A2.Text == mark) && (B2.Text == mark) && (C2.Text == ""))
                return C2;
            if ((B2.Text == mark) && (C2.Text == mark) && (A2.Text == ""))
                return A2;
            if ((A2.Text == mark) && (C2.Text == mark) && (B2.Text == ""))
                return B2;

            if ((A3.Text == mark) && (B3.Text == mark) && (C3.Text == ""))
                return C3;
            if ((B3.Text == mark) && (C3.Text == mark) && (A3.Text == ""))
                return A3;
            if ((A3.Text == mark) && (C3.Text == mark) && (B3.Text == ""))
                return B3;

            //DIAGONAL TESTS
            if ((A1.Text == mark) && (B2.Text == mark) && (C3.Text == ""))
                return C3;
            if ((B2.Text == mark) && (C3.Text == mark) && (A1.Text == ""))
                return A1;
            if ((A1.Text == mark) && (C3.Text == mark) && (B2.Text == ""))
                return B2;

            if ((A3.Text == mark) && (B2.Text == mark) && (C1.Text == ""))
                return C1;
            if ((B2.Text == mark) && (C1.Text == mark) && (A3.Text == ""))
                return A3;
            if ((A3.Text == mark) && (C1.Text == mark) && (B2.Text == ""))
                return B2;

            return null;
        }

        private void winner()
        {
            bool winnerWinner = false;

            //horizontal win check
            if (A1.Text == A2.Text && A2.Text == A3.Text && A1.Enabled == false)
            { winnerWinner = true; }
            else if (B1.Text == B2.Text && B2.Text == B3.Text && B1.Enabled == false)
            { winnerWinner = true; }
            else if (C1.Text == C2.Text && C2.Text == C3.Text && C1.Enabled == false)
            { winnerWinner = true; }
            //end horizontal win check

            //vettical win check
            else if (A1.Text == B1.Text && B1.Text == C1.Text && A1.Enabled == false)
            { winnerWinner = true; }
            else if (A2.Text == B2.Text && B2.Text == C2.Text && A2.Enabled == false)
            { winnerWinner = true; }
            else if (A3.Text == B3.Text && B3.Text == C3.Text && A3.Enabled == false)
            { winnerWinner = true; }
            //end vertical win check

            //diagonal win check
            else if (A1.Text == B2.Text && B2.Text == C3.Text && A1.Enabled == false)
            { winnerWinner = true; }
            else if (A3.Text == B2.Text && B2.Text == C1.Text && C1.Enabled == false)
            { winnerWinner = true; }
            //end diagonal win check


            if (winnerWinner == true)
            {
                disableButton();
                string msg = "";

                if (turn)
                {
                    msg = p2.Text;

                    o_win_count.Text = (int.Parse(o_win_count.Text) + 1).ToString();
                    match_over = true;
                }
                else
                {
                    msg = p1.Text;

                    x_win_count.Text = (int.Parse(x_win_count.Text) + 1).ToString();
                    match_over = true;
                }

                MessageBox.Show(msg + "wins!", "Win Msg");
            }//end of win "IF"
            else
            {
                if (turnCount == 9)
                {
                    MessageBox.Show(" There is NO winner !");

                    draw.Text = (int.Parse(draw.Text) + 1).ToString();
                    match_over = true;
                }
            }

        }//end for winner method

        private void disableButton()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }//end of foreach loop
            }//end Try
            catch
            { }
        }

        private void mouse_leave(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {
                b.Text = "";
            }
        }//end mouse leave

       



        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Do you really want to leave?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult.Yes == res)
            {
                Application.Exit();
            }
        }

        private void backToBeginningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();

            f1.Show();
        }

        private void resetScoreToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

            ClearButton();
            o_win_count.Text = "0";
            x_win_count.Text = "0";
            draw.Text = "0";
        }

        private void ClearButton()
        {
            A1.Text = "";
            A2.Text = "";
            A3.Text = "";
            B1.Text = "";
            B2.Text = "";
            B3.Text = "";
            C1.Text = "";
            C2.Text = "";
            C3.Text = "";
        }
       

        private void rulesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" Играете срещу компютър.Който първи запълни ред,стълб или диагонал със своя знак ПЕЧЕЛИ !");
        }
    }

}


