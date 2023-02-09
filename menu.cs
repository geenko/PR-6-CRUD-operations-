using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace caffee
{
    public partial class menu : Form
    {
        public menu(int result)
        {
            InitializeComponent();
            getInfo();
        }

        private void getInfo()
        {
            string query = ("SELECT id_order as'№ заказа', buy as'Заказчик', phone_buy as'Телефон', id_list as'№ Списка выбора',sumprice as 'Итоговая цена', id_staff as '№ сотрудника' from orders;");
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlDataAdapter ada = new MySqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                ada.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }




        private void menu_Load(object sender, EventArgs e)
        {

        }

        private void едаНапиткиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Win = new dish();
            Win.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void спискиЗаказовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Win = new list();
            Win.Show();
        }

        private void работникиToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form Win = new staff();
            Win.Show();
        }

        private void должностиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Win = new post();
            Win.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form Win = new orders();
            Win.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
