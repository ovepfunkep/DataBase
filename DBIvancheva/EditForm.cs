using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DBIvancheva.Stuff1;

namespace DBIvancheva
{
    public partial class EditForm : Form
    {

        private MainForm mainFormTaken;
        private string styleTaken;
        public EditForm(MainForm mainFormGiven,string styleGiven, string ID = "", int cellColumn = -1)
        {
            InitializeComponent();
            mainFormTaken = mainFormGiven;
            styleTaken = styleGiven;
            CustomizeForm(ID, styleTaken, cellColumn) ;
        }

        private void EmptyAllBoxes()
        {
            CardIDTxtBox.Text = string.Empty;
            FullNameTxtBox.Text = string.Empty;
            GenderComboBox.SelectedIndex = -1;
            DateOfBirthTxtBox.Text = string.Empty; 
            AdressTxtBox.Text= string.Empty;
            PhoneNumberTxtBox.Text = string.Empty;
        }

        private void CustomizeForm(string ID, string styleTaken, int cellColumn = -1)
        {
            if (styleTaken == "add")
            {
                CardIDTxtBox.ReadOnly = false;
                DeleteBtn.Visible = false;
                EmptyAllBoxes();
            }
            else
            {
                CardIDTxtBox.ReadOnly = true;
                Patient patient = Methods.GetPatientByID(ID);
                CardIDTxtBox.Text = patient.CardID;
                FullNameTxtBox.Text = patient.FullName;
                GenderComboBox.SelectedIndex = (patient.Gender == 'M')? 0 : 1;
                DateOfBirthTxtBox.Text = patient.DateOfBirth;
                AdressTxtBox.Text = patient.Adress;
                PhoneNumberTxtBox.Text = patient.PhoneNumber;
                switch (cellColumn)
                {
                    case 0: { CardIDTxtBox.Select(); break; }
                    case 1: { FullNameTxtBox.Select(); break; }
                    case 2: { GenderComboBox.Select(); break; }
                    case 3: { DateOfBirthTxtBox.Select(); break; }
                    case 4: { AdressTxtBox.Select(); break; }
                    case 5: { PhoneNumberTxtBox.Select(); break; }
                }
            }
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            Patient patient = new Patient();
            patient.CardID = CardIDTxtBox.Text;
            patient.FullName = FullNameTxtBox.Text;
            patient.Gender = GenderComboBox.Items[GenderComboBox.SelectedIndex].ToString()[0];
            patient.DateOfBirth = DateOfBirthTxtBox.Text;
            patient.Adress = AdressTxtBox.Text;
            patient.PhoneNumber = PhoneNumberTxtBox.Text;
            if (styleTaken == "add") Methods.AddPatient(patient);
            else Methods.UpdatePatient(patient);
            mainFormTaken.fillGrid();
            this.Hide();
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this patient?", "Check" ,MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Methods.DeletePatient(CardIDTxtBox.Text);
                mainFormTaken.fillGrid();
                this.Hide();
            }
        }
    }
}
