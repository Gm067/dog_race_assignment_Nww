using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dog_race_assignment_Nw
{
    public partial class Form1 : Form
    {
        GameClass Game = new GameClass();
        String [,]better=new String[3,4];
        int indx = -1,dog=0,winner=0;
        
        public Form1()
        {
            InitializeComponent();
            racenow.Enabled = false;
            //Name 
            better[0, 0] = "Roney";
            better[1, 0] = "Nangu";
            better[2, 0] = "Guri";

            //Amount
            better[0, 1] = "100";
            better[1, 1] = "100";
            better[2, 1] = "100";

            better[0, 2] = "";
            better[1, 2] = "";
            better[2, 2] = "";

            roney.Text = roney.Text.ToString() + " 100";
            nangu.Text = nangu.Text.ToString() + " 100";
            guri.Text = guri.Text.ToString() + " 100";

            int y = 10;
            while (y<=50) {
                cbBet.Items.Add("" + y);
                y++;
            }
        }

        private void lockbet_Click(object sender, EventArgs e)
        {
            if (indx>-1 && dog>0 && !cbBet.SelectedItem.ToString().Equals("")) {

                //let us set the bet 
                better[indx, 2] = "" + dog;
                better[indx, 3] = "" + cbBet.SelectedItem.ToString();

                if (indx == 0)
                {
                    lblFirst.Text = better[indx, 0] + "--" + better[indx, 1] + "--" + better[indx, 2] + "--" + better[indx, 3];
                }
                if (indx == 1)
                {
                    lblSecond.Text = better[indx, 0] + "--" + better[indx, 1] + "--" + better[indx, 2] + "--" + better[indx, 3];
                }
                if (indx == 2)
                {
                    lblThrd.Text = better[indx, 0] + "--" + better[indx, 1] + "--" + better[indx, 2] + "--" + better[indx, 3];
                }
                racenow.Enabled = true;

                MessageBox.Show("Bet is stored ");
            }
            //reset the value again to set again 


            indx = -1;
            dog = 0;
        }

        private void dog1_CheckedChanged(object sender, EventArgs e)
        {
            if (dog1.Checked) {
                dog = 1;
                dog2.Checked = false;
                dog3.Checked = false;
                dog4.Checked = false;

            }

        }
        // dog 3 events changing
        private void dog3_CheckedChanged(object sender, EventArgs e)
        {
            if (dog3.Checked) {
                dog = 3;
                dog1.Checked = false;
                dog2.Checked = false;
                dog4.Checked = false;

            }

        }
        // dog 4 events changing
        private void dog4_CheckedChanged(object sender, EventArgs e)
        {
            if (dog4.Checked) {
                dog = 4;
                dog2.Checked = false;
                dog3.Checked = false;
                dog1.Checked = false;

            }

        }
        // players events changing 
        private void roney_CheckedChanged(object sender, EventArgs e)
        {
            if (roney.Checked) {
                indx = 0;
                nangu.Checked = false;
                guri.Checked = false;
            }
        }
        // showing results 
        public void Result() {
            for (int z = 0; z < 3; z++)
            {
                if (!better[z, 2].ToString().Equals(""))
                {
                    better[z, 1] = "" + Game.updateAmount(winner, Convert.ToInt32(better[z, 2]), Convert.ToInt32(better[z, 1]), Convert.ToInt32(better[z, 3]));
                    MessageBox.Show(better[z, 0] + " has "+ better[z, 1]);
                }
            }
                better[0, 2] = "";
                better[1, 2] = "";
                better[2, 2] = "";
                dogPic1.Left = 0;
                dogPic2.Left = 0;
                dogPic3.Left = 0;
                dogPic4.Left = 0;
                indx = -1;
                dog = 0;
                winner = 0;
            lblFirst.Text = "";
            lblSecond.Text = "";
            lblThrd.Text = "";
            roney.Text =  "Roney has $"+ better[0, 1];
            nangu.Text =  "Nangu has $"+ better[1, 1];
            guri.Text =  "Guri has $"+ better[2, 1];


        }

        // timer events
        private void timer1_Tick(object sender, EventArgs e)
        {
            dogPic1.Left += Game.GenRandom();
            dogPic2.Left += Game.GenRandom();
            dogPic3.Left += Game.GenRandom();
            dogPic4.Left += Game.GenRandom();

            if (dogPic1.Left > 730)
            {
                winner = 1;
                
                timer1.Stop();
                MessageBox.Show("winner Dog " + winner);
                Result();
            }

            if (dogPic4.Left > 730)
            {
                winner = 4;
                
                timer1.Stop();
                MessageBox.Show("winner Dog " + winner);
                Result();
            }

            if (dogPic2.Left > 730)
            {
                winner = 2;
                
                timer1.Stop();
                MessageBox.Show("winner Dog " + winner);
                Result();
            }

            if (dogPic3.Left > 730)
            {
                winner = 3;
                
                timer1.Stop();
                MessageBox.Show("winner Dog " + winner);
                Result();
            }
        }

        //when user click on racenow button 
        private void racenow_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
        //when nangu player is checked
        private void nangu_CheckedChanged(object sender, EventArgs e)
        {
            if (nangu.Checked) {
                indx = 1;
                roney.Checked = false;
                guri.Checked = false;
            }
        }

        private void guri_CheckedChanged(object sender, EventArgs e)
        {

            if (guri.Checked)
            {
                indx = 2;
                roney.Checked = false;
                nangu.Checked = false;
            }
        }

        private void dog2_CheckedChanged(object sender, EventArgs e)
        {
            if (dog2.Checked) {
                dog = 2;
                dog1.Checked = false;
                dog3.Checked = false;
                dog4.Checked = false;

            }

        }
    }
}
