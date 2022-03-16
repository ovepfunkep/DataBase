using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static DBIvancheva.Stuff1;

namespace DBIvancheva
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
        }

        public void fillGrid()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string queryText = "select * from Patients";
                SqlDataAdapter adapter = new SqlDataAdapter(queryText, connection);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                MainDataGrid.DataSource = dataSet.Tables[0];
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            fillGrid();
        }

        private void AddPatientBtn_Click(object sender, EventArgs e)
        {
            EditForm editForm = new EditForm(this,"add");
            editForm.ShowDialog();
        }

        private void MainDataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                int cellColumn = e.ColumnIndex;
                string CardID = MainDataGrid.Rows[e.RowIndex].Cells[0].Value.ToString();
                EditForm editForm = new EditForm(this, "update", CardID, cellColumn);
                editForm.ShowDialog();
            }
        }
    }
}
