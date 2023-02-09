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
    public partial class regist : System.Windows.Forms.Form
    {
        public regist()
        {
            InitializeComponent();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string add = ("insert into user(log, pass) values('" + textBox1.Text + "', '" + textBox2.Text + "');");
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand cmDB = new MySqlCommand(add, conn);
            try
            {
                conn.Open();
                MySqlDataReader rd = cmDB.ExecuteReader();
                conn.Close();
                MessageBox.Show("Регистрация успешна!");
              
            }
            catch (Exception)
            {
                MessageBox.Show("Заполните все поля!");
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }
    }
}
