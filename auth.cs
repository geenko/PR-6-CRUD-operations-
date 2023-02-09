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
    public partial class auth : Form
    {
        public auth()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Form Win = new regist();
            Win.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "SELECT id_user FROM user WHERE log ='" + textBox1.Text + "' and pass = '" + textBox2.Text + "';";
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand cmDB = new MySql.Data.MySqlClient.MySqlCommand(query, conn);
            try
            {
                conn.Open();
                int result = 0;
                result = Convert.ToInt32(cmDB.ExecuteScalar());
                if (result > 1)
                {
                    menu Win = new menu(result);
                    Win.Owner = this;
                    this.Hide();
                    Win.Show();
                    textBox1.Clear();
                    textBox2.Clear();
                }
                else
                    MessageBox.Show("Возникла ошибка авторизации!");
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла непредвиденная ошибка!" + Environment.NewLine + ex.Message);
            }
        }

        private void auth_Load(object sender, EventArgs e)
        {

        }
    }
}
