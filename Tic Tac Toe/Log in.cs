using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Tic_Tac_Toe
{
    public partial class Form1 : Form
    {
        List<string> Usernames = new List<string>();
        List<string> Passwords = new List<string>();
        readonly string filePath = "users.csv";

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            string inputUsername = tbUserName.Text.Trim();
            string inputPassword = tBPassword.Text.Trim();

            if (inputUsername == "")
            {
                MessageBox.Show("Input username !");
                return;

            }
            if (inputPassword == "")
            {
                MessageBox.Show("Input password !");
                return;
            }
            if (Usernames.Contains(inputUsername))
            {
                MessageBox.Show("Username exists !");
                return;
            }

            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine(inputUsername + "," + inputPassword);

                // sw.WriteLine(inputUsername);
                //sw.WriteLine(inputPassword);

                sw.Close();
            }

            Usernames.Add(inputUsername);
            Passwords.Add(inputPassword);

            MessageBox.Show("Successful registration ! ");
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            bool isFound = false;
            string inputUsername = tbUserName.Text;
            string inputPassword = tBPassword.Text;

            for (int i = 0; i < Usernames.Count; i++)
            {
                if (Usernames[i] == inputUsername && Passwords[i] == inputPassword)
                {
                    isFound = true;
                    MessageBox.Show("log in successfull");
                    button1.Visible = true;
                    button2.Visible = true;
                }
            }
            if (!isFound)
                MessageBox.Show("Invalid username / password ! ");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] splitted = line.Split(',');

                        Usernames.Add(splitted[0]);
                        Passwords.Add(splitted[1]);

                    }
                    sr.Close();
                }
            }
        }
        Form3 f3;
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f3 = new Form3();
            // f3.MdiParent = this;
            f3.Show();
        }
        Form2 f2;
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Do you really want to leave?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult.Yes == res)
            {
                Application.Exit();
            }
        }
    }
   
}
 

    


