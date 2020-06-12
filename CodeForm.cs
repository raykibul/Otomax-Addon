using Otomax_Addon.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Otomax_Addon
{
    public partial class CodeForm : Form
    {
        GlobalData data = GlobalData.getinstance();
        String id;


        public CodeForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (numberCode.Text.Length < 1)
                MessageBox.Show("Please Enter Number Code");
            else if (replaceCode.Text.Length < 1)
                MessageBox.Show("Please Enter replace Code");
            else if(data.isEditingNow)
            {
                Connection connection = new Connection();
                SqlConnection conn = connection.Open();
                if (conn == null)
                    MessageBox.Show("Database Not Connected");
                else
                {
                    String number = numberCode.Text;
                    String replace = replaceCode.Text;
                    String amount;

                    if (amountText.Text.Length == 0)
                        amount = "0";
                    else
                        amount = amountText.Text;

                    string sql = "Update addons set number_code='"+number+"',replace_code='"+replace+"',amount='"+amount+"' where id='"+id+"'";
                    SqlCommand command;
                    command = new SqlCommand(sql, conn);
                    int result = command.ExecuteNonQuery();
                    if (result == 1)
                    {
                        data.isEditingNow = false;
                        MessageBox.Show("Code Edited  Successfully");
                        conn.Close();
                        this.Close();
                    }
                    else
                    {
                        data.isEditingNow = false;
                        MessageBox.Show("Code Not Edited !!! ");
                        conn.Close();
                        this.Close();
                    }
                }

            }
            else
            {
                Connection connection = new Connection();
                SqlConnection conn = connection.Open();
                if (conn == null)
                    MessageBox.Show("Database Not Connected");
                else
                {
                    String number = numberCode.Text;
                    String replace = replaceCode.Text;
                    String amount;

                    if (amountText.Text.Length == 0)
                        amount = "0";
                    else
                        amount = amountText.Text;

                    string sql = "Insert into addons (number_code,replace_code,amount)values('"+number+"','"+replace+"','"+amount+"')";
                    SqlCommand command;
                    command = new SqlCommand(sql, conn);
                    int result = command.ExecuteNonQuery();
                    if (result == 1)
                    {
                        MessageBox.Show("Code Added Successfully");
                         
                        conn.Close();
                        replaceCode.Text = "";
                        numberCode.Text = "";
                        
                    }
                    else
                    {
                        MessageBox.Show("Code Not Added!!! ");
                        conn.Close();
                    }
                    
                }

            }



        }

        private void CodeForm_Load(object sender, EventArgs e)
        {
       
            if (data.isEditingNow)
            {
                Request req = Request.getInstance();
                numberCode.Text = req.number_code;
                replaceCode.Text = req.replace_code;
                amountText.Text = req.amount;
                id = req.id;
                delete.Enabled = true;

            }

        }

        private void delete_Click(object sender, EventArgs e)
        {

            Connection connection = new Connection();
            SqlConnection conn = connection.Open();
            if (conn == null)
                MessageBox.Show("Database Not Connected");
            else
            {
                String number = numberCode.Text;
                String replace = replaceCode.Text;
                String amount;

                if (amountText.Text.Length == 0)
                    amount = "0";
                else
                    amount = amountText.Text;

                string sql = "Delete FROM addons where id='"+id+"'";
                SqlCommand command;
                command = new SqlCommand(sql, conn);
                int result = command.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("Code Deleted Successfully");
                    conn.Close();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Code Not Deleted !!! ");
                    conn.Close();
                    this.Close();
                }
            }
        }
    }
}
