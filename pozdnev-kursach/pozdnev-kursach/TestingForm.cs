using System;
using System.Windows.Forms;

namespace pozdnev_kursach
{
    public partial class TestingForm : Form
    {
        public TestingForm()
        {
            InitializeComponent();

            dataGridView1.Rows.Clear();
            using (var reader = Program.database.GetReader(@"select * from test_list"))
            {
                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetString(2));
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Hide();
            Console.WriteLine(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            new Test(dataGridView1.CurrentRow.Cells[0].Value.ToString());
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}