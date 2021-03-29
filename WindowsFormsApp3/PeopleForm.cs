using ClassLibrary2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class PeopleForm : Form
    {
        List<PersonModel> People = new List<PersonModel>();
        public PeopleForm()
        {
            InitializeComponent();

            LoadPeopleList();
        }
        private void LoadPeopleList()
        {
            People = SqliteDataAccess.LoadPeople();

            WireUpPeopleList();
        }

        private void WireUpPeopleList()
        {
            personlistBox.DataSource=null;
            personlistBox.DataSource= People;
            personlistBox.DisplayMember = "FullName";
        }

        private void refreshListbuton_Click(object sender, EventArgs e)
        {
            LoadPeopleList();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            PersonModel p = new PersonModel();

            p.FirstName = firstNameText.Text;
            p.LastName = lastNameText.Text;

            SqliteDataAccess.SavePerson(p);

            firstNameText.Text = "";
            lastNameText.Text = "";





            /*
            string metin = firstNameText.Text;
            string metin1 = lastNameText.Text;
            personlistBox1.Items.Add(metin);
            personlistBox1.Items.Add(metin1);
            firstNameText.Text = "";
            lastNameText.Text = "";
            */
        }

        
    }
}
