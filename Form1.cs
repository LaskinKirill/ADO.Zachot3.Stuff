using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;

namespace ADO.Zachot3.Stuff
{
    public partial class Form1 : Form
    {
        private AdventureWorks2017Entities CustomerContext;
        public Form1()
        {
            InitializeComponent();
        }
         private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "adventureWorks2017DataSet.Person". При необходимости она может быть перемещена или удалена.
            this.personTableAdapter.Fill(this.adventureWorks2017DataSet.Person);
            CustomerContext = new AdventureWorks2017Entities();
            var person = CustomerContext.Person.Include(x => x.PersonType).OrderBy(x => x.LastName);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.dataGridView1.DataSource = personBindingSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == Convert.ToString(1111))
            {
                dataGridView1.ReadOnly = false;
                try
                {                   
                    MessageBox.Show("Изменения в базе доступны.");
                    this.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
                MessageBox.Show("Введите пароль.");
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
                
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.Update(adventureWorks2017DataSet.Person);
            CustomerContext.SaveChanges();           

            MessageBox.Show("Изменения в базе сохранены.");
        }

        private void personBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {

        }

        private void personBindingSource_DataSourceChanged(object sender, EventArgs e)
        {

        }
    }
}
