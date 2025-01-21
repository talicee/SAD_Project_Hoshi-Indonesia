using Microsoft.SqlServer.Server;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ALP_Hoshi
{
    public partial class Sign_In : Form
    {
        public Sign_In()
        {
            InitializeComponent();
        }

        MySqlDataAdapter sqldataadapter;
        MySqlConnection sqlconnect;
        MySqlCommand sqlcommand;
        DataTable Account = new DataTable();
        string query;
        private void Sign_In_Load(object sender, EventArgs e)
        {
            panel1.BackColor = ColorTranslator.FromHtml("#F7FBFF");
            textBox_Username.BackColor = ColorTranslator.FromHtml("#F7FBFF");
            textBox_Username.ForeColor = ColorTranslator.FromHtml("#8897AD");
            panel2.BackColor = ColorTranslator.FromHtml("#F7FBFF");
            textBox_Password.BackColor = ColorTranslator.FromHtml("#F7FBFF");
            textBox_Password.ForeColor = ColorTranslator.FromHtml("#8897AD");
            label4.ForeColor = ColorTranslator.FromHtml("#313957");
            label5.ForeColor = ColorTranslator.FromHtml("#313957");
            label6.ForeColor = ColorTranslator.FromHtml("#959CB6");
            Button_SignIn.BackColor = ColorTranslator.FromHtml("#FF8F8F");
            butt_corner(Button_SignIn);

            sqlconnect = DatabaseConnection.Connection;
            query = "SELECT * FROM ACCOUNT;";
            sqlcommand = new MySqlCommand(query, sqlconnect);
            sqldataadapter = new MySqlDataAdapter(sqlcommand);
            sqldataadapter.Fill(Account);

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;

            Color strokeColor = ColorTranslator.FromHtml("#D4D7E3");
            int strokeWidth = 1;
            int cornerRadius = 20;

            using (Pen pen = new Pen(strokeColor, strokeWidth))
            {
                GraphicsPath path = new GraphicsPath();
                path.AddArc(0, 0, cornerRadius, cornerRadius, 180, 90);
                path.AddArc(panel.Width - cornerRadius - strokeWidth, 0, cornerRadius, cornerRadius, 270, 90);
                path.AddArc(panel.Width - cornerRadius - strokeWidth, panel.Height - cornerRadius - strokeWidth, cornerRadius, cornerRadius, 0, 90);
                path.AddArc(0, panel.Height - cornerRadius - strokeWidth, cornerRadius, cornerRadius, 90, 90);
                path.CloseFigure();

                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.DrawPath(pen, path);
            }
        }

        public void butt_corner(Button butt)
        {
            int cornerRadius = 20;
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, cornerRadius, cornerRadius, 180, 90);
            path.AddArc(butt.Width - cornerRadius, 0, cornerRadius, cornerRadius, 270, 90);
            path.AddArc(butt.Width - cornerRadius, butt.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90);
            path.AddArc(0, butt.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90);
            path.CloseFigure();

            butt.Region = new Region(path);
        }

        private void textBox_Username_Enter(object sender, EventArgs e)
        {
            if (textBox_Username.Text == "Enter Your Username")
            {
                textBox_Username.Text = "";
            }
        }

        private void textBox_Username_Leave(object sender, EventArgs e)
        {
            if (textBox_Username.Text == "")
            {
                textBox_Username.Text = "Enter Your Username";
            }
        }

        private void textBox_Password_Enter(object sender, EventArgs e)
        {
            if (textBox_Password.Text == "Enter Your Password")
            {
                textBox_Password.Text = "";

            }
        }
        private void textBox_Password_Leave(object sender, EventArgs e)
        {
            if (textBox_Password.Text == "")
            {
                textBox_Password.Text = "Enter Your Password";
            }
        }

        private void Button_SignIn_Click(object sender, EventArgs e)
        {
            bool cekusername = false;
            bool cekpassword = false;
            if (textBox_Username.Text != "" || textBox_Password.Text != "" || textBox_Username.Text != "Enter Your Username" || textBox_Password.Text != "Enter Your Password")
            {
                for (int i = 0; i < Account.Rows.Count; i++)
                {
                    if (textBox_Username.Text == Account.Rows[i][0].ToString())
                    {
                        cekusername = true;
                        if (textBox_Password.Text == Account.Rows[i][1].ToString())
                        {
                            cekpassword = true;
                            DialogResult DR = MessageBox.Show("Login successful", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (DR == DialogResult.OK)
                            {
                                GlobalData.Nama = textBox_Username.Text;
                                Menu menu = new Menu();
                                menu.Show();
                                this.Hide();
                                menu.StartPosition = FormStartPosition.CenterScreen;
                                break;
                            }
                        }
                    }
                }
                if (cekusername == false)
                {
                    DialogResult DR = MessageBox.Show("Username Invalid", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_Username.Text = "Enter Your Username";
                    textBox_Password.Text = "Enter Your Password";
                }
                else if (cekpassword == false)
                {
                    DialogResult DR = MessageBox.Show("Password Invalid", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_Password.Text = "Enter Your Password";
                }
            }
            else
            {
                DialogResult DR = MessageBox.Show("Login Invaid", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
    }
}

