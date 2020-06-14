using Otomax_Addon.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Otomax_Addon
{
    public partial class MainFrom : Form
    {
        List<Request> myRequestCodes = new List<Request>();
        string coded_number, coded_amount, main_number;
       

        public MainFrom()
        {
            InitializeComponent();
        }

        private void MainFrom_Load(object sender, EventArgs e)
        {
            

            Connection connection = new  Connection();
            SqlConnection conn = connection.Open();
            if(conn==null)
            {
                MessageBox.Show("Otomax Database Not Connected !!");
                return;
            }else
            {
                statuslabel.Text = "Connected";
                statuslabel.ForeColor = Color.Green;
                LoadReqCodes();
                statuslabel.Text = myRequestCodes.Count+" Codes";
            }
            conn.Close();
            inboxTimer.Start();

        }

     

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            helpPanel.Visible = false;

        }

        private void addRequestCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {

            GlobalData data = GlobalData.getinstance();
            data.isEditingNow = false;
            CodeForm to = new CodeForm();
            to.Show();
        }

        private void viewMyCodesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadReqForm too = new LoadReqForm();
            too.Show();

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            inboxTimer.Start();
        }

        private void ShowUpdate(string msg)
        {
            string time = DateTime.Now.ToString("HH:mm:ss tt");
            statusBox.AppendText(Environment.NewLine + time + "-- " + msg+"\n");
            statusBox.ScrollToCaret();
             
        }

        private void button1_Click(object sender, EventArgs e)
        {
            inboxTimer.Stop();
            startButton.Enabled = true;
        }

        private void inboxTimer_Tick(object sender, EventArgs e)
        {
            if (startButton.Enabled)
            {
                startButton.Enabled = false;
            }

            if (MyWorker.IsBusy)
                return;
            else
            {
                MyWorker.RunWorkerAsync();
            }

        }

        private void MyWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            CheckInbox();
        }

        private void CheckInbox()
        {
            Connection connection = new Connection();
            SqlConnection conn = connection.Open();
            string sql = "select TOP 1 *  from inbox where kode_reseller <> 'NULL' and addons='0' order by kode DESC ";
            SqlCommand command;
            SqlDataReader readear;
            command = new SqlCommand(sql, conn);
            readear = command.ExecuteReader();
            while (readear.Read())
            {
                String id, pesan;
                id = readear.GetValue(0).ToString();
                pesan = readear.GetValue(5).ToString();
                if (IsRequest(pesan))
                {
                  for(int i = 0; i < myRequestCodes.Count; i++)
                    { if (myRequestCodes[i].number_code.Equals(coded_number,StringComparison.InvariantCultureIgnoreCase))
                        {
                            CreateResponseAndUpdate(id,myRequestCodes[i].replace_code);
                            break;
                        }
                  }
                }
                else
                {
                    UpdateAddonsFalse(id);
                }

            }

            ShowUpdate("Inbox Check Completed!!");

            readear.Close();
            conn.Close();
              
        }

        private void CreateResponseAndUpdate(string id,string pcode)
        {
            String response = "";
            response = pcode + "*" + main_number + "*" + coded_amount;
            ShowUpdate("Response: "+response);


            Connection connection = new Connection();
            SqlConnection conn = connection.Open();
            string sql = "update inbox set addons='1',pesan='"+response+"',status='0' where kode='"+id+"'";
            SqlCommand command;
            command = new SqlCommand(sql, conn);
            int result = command.ExecuteNonQuery();
            if (result == 1)
            {
                ShowUpdate(response+" updated!!");
                conn.Close();

            }
            else
            {
                ShowUpdate("addons Not updated!! Restart please");
                conn.Close();
            }



        }

        private void UpdateAddonsFalse(string id)
        {
            Connection connection = new Connection();
            SqlConnection conn = connection.Open();
            string sql = "update inbox set addons='1' where kode='"+id+"'";
            SqlCommand command;
            command = new SqlCommand(sql, conn);
            int result = command.ExecuteNonQuery();
            if (result == 1)
            {
                  ShowUpdate("addons updated!!");
                  conn.Close();
                 
            }
            else
            {
                ShowUpdate("addons Not updated!! Restart please");
                conn.Close();
            }

        }

        private void restartButton_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void tutorialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            helpPanel.Visible = true;
            helpRichTextbox.Text = "১। আপনার কম্পিউটার এর মধ্যে অবশ্যই otomax সফটওয়ার ইনস্টল করা থাকতে হবে\n" +
                "২। প্রথমে addons এর জন্য একটি টেবিল sql server এ করে নিতে হবে\n" +
                "৩। এর পর inbox table এ addons কলাম যোগ করা লাগবে\n" +
                "৪। settings অপশনে গিয়ে আপনার নতুন কোড এড করার অপশনে যাবেন\n" +
                "৫। number code এর জায়গায় আপনার রিসেলার যেই কোড লিখবে সেটা লিখুন\n" +
                "৬। replace code এর জায়গায় লিখুন অটোম্যাক্স এ যেই কোড যাবে। \n" +
                "৭। সেভ করুন ";


        }

       

        private void developerInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://youtube.com/rakibulislamcse");
        }

        private bool IsRequest(String msg)
        {
            coded_number = "";
            coded_amount = "";

            bool reqType = false;
            String[] codes = msg.Split('*');
           
            if (codes.Length < 2)
            { 
                ShowUpdate("Not Valid Requset Msg!");
                return false;

            }else if (codes.Length == 2)
            {
                ShowUpdate(msg+" Replacing Req Codes!!");

                coded_amount = codes[1];
                string num = codes[0];

                if (num.Length == 11&& num[0]=='0')
                {
                    main_number = codes[0];
                    coded_number = num.Substring(0, 3);

                }
                else if (num.Length == 12)
                {//MNP or OFFER recharge//postpaid;
                    string firstLatter = num[0].ToString();
                    if (firstLatter.Equals("p", StringComparison.InvariantCultureIgnoreCase))
                    { 
                        main_number = num.Substring(1, 11);
                        coded_number = num.Substring(0, 4);
                    }
                    else
                    {
                        main_number = num.Substring(1, 11);
                        coded_number = num.Substring(0, 1);
                    }

                }
                else if (num.Length == 13)
                {
                    main_number = num.Substring(2, 11);
                    coded_number = num.Substring(0, 2);

                }else if(num.Length == 14)
                {
                    main_number = num.Substring(3, 11);
                    coded_number = num.Substring(0, 3);

                } 
                 return true;
            }else if (codes.Length == 3)
            {
                ShowUpdate("Requst codes Already Completed!!");
                return false;
            }

            return reqType;
        }

        private void LoadReqCodes()
        {
            Connection connection = new Connection();
            SqlConnection conn = connection.Open();
            string sql = "select * from addons";
            SqlCommand command;
            SqlDataReader readear;
            command = new SqlCommand(sql, conn);
            readear = command.ExecuteReader();


            while (readear.Read())
            {
                String id, num, rep, am;
                 
                 id= readear.GetValue(0).ToString();
                 num= readear.GetValue(1).ToString();
                 rep= readear.GetValue(2).ToString();
                 am= readear.GetValue(3).ToString();
                 Request req = new Request();
                req.id = id;
                req.number_code = num;
                req.replace_code = rep;
                req.amount = am;

                myRequestCodes.Add(req);

            }
            readear.Close();
            conn.Close();



        }


    }

    
}
