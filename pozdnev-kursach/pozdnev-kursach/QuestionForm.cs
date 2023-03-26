using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace pozdnev_kursach
{
    public partial class QuestionForm : Form
    {
        int count;
        public int trueAnswerCount;
        public ArrayList question;
        public List<ArrayList> questions;
        public string test_id;
        public QuestionForm(List<ArrayList> q, string id)
        {
            InitializeComponent();
            button3.Visible = false;

            test_id = id;

            count = 0;
            trueAnswerCount = 0;
            questions = q;
            
            question = q[count];
            InsertData(question);
            
        }

        public void InsertData(ArrayList question)
        {
            richTextBox1.Text = question[0].ToString();

            var o = question[1].ToString().Split(';');
            Console.WriteLine(o);
            
            radioButton1.Text = o[0];
            radioButton2.Text = o[1];
            radioButton3.Text = o[2];

        }

        public void Check_the_end()
        {
            if (questions.Count <= count)
            {
                Console.WriteLine("END OF QUESTIORNS");
                richTextBox1.Text = $"Ты ответил на {trueAnswerCount} / {questions.Count}!";
                button1.Enabled = false;
                button3.Visible = true;
                Program.database.ExecuteNonQuery($"UPDATE main.test_list SET status = 'Пройдено' WHERE id = {test_id}");
                
                return;
            }
            InsertData(questions[count]);
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("button");

            count++;
            Console.WriteLine(count);

            foreach (var rb in new RadioButton[] {radioButton1, radioButton2, radioButton3})
            {
                if (rb.Checked)
                {
                    Console.WriteLine("checked");
                    if (rb.Text == question[2].ToString())
                    {
                        Console.WriteLine("success");
                        trueAnswerCount++;
                    }

                }
                Check_the_end();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new TestingForm().Show();
        }
    }
}