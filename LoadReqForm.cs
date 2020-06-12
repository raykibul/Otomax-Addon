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
    public partial class LoadReqForm : Form
    {

        DataTable myTable = new DataTable();
        public LoadReqForm()
        {
            InitializeComponent();
        }

        private void LoadReqForm_Load(object sender, EventArgs e)
        {

            LoadDataTable();
            LoadReqCodes();
             

        }
        private void LoadDataTable()
        {
            myTable.Columns.Add("ID", typeof(String));
            myTable.Columns.Add("Number Code", typeof(String));
            myTable.Columns.Add("Replace Code", typeof(String));
            myTable.Columns.Add("Amount", typeof(String));
            dataGridView1.DataSource = myTable;

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

                DataRow dt = myTable.NewRow();
                dt[0] = readear.GetValue(0).ToString();
                dt[1] = readear.GetValue(1).ToString();
                dt[2] = readear.GetValue(2).ToString();
                dt[3] = readear.GetValue(3).ToString();
                myTable.Rows.InsertAt(dt,0);
                  
            }
            readear.Close();
            conn.Close();





        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView1.CurrentRow.Selected = true;
                Request req = Request.getInstance();
                req.id = dataGridView1.Rows[e.RowIndex].Cells["ID"].FormattedValue.ToString();
                req.number_code = dataGridView1.Rows[e.RowIndex].Cells["Number Code"].FormattedValue.ToString();
                req.replace_code = dataGridView1.Rows[e.RowIndex].Cells["Replace Code"].FormattedValue.ToString();
                req.amount = dataGridView1.Rows[e.RowIndex].Cells["Amount"].FormattedValue.ToString();
                Request.SetInstance(req);
                GlobalData data = GlobalData.getinstance();
                data.isEditingNow = true;

                CodeForm to = new CodeForm();
                to.Show();
                


            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }
    }
}
