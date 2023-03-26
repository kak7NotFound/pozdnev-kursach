using System;
using System.Collections;
using System.Collections.Generic;

namespace pozdnev_kursach
{
    public class Test
    {

        public List<ArrayList> data = new List<ArrayList>();
        public int questionsCount;
        public int answersCount;
        
        public Test(string id)
        {
            
            using (var reader = Program.database.GetReader($"select * from questions where test_id = {Int32.Parse(id)}"))
            {
                while (reader.Read())
                {
                    ArrayList q = new ArrayList();
                    
                    for (int i = 1; i <= 3; i++)
                    {
                        Console.WriteLine(reader.GetString(i));
                        q.Add(reader.GetString(i));
                    }
                    data.Add(q);
                }
            }

            new QuestionForm(data, id).Show();
            
        }
        
        
    }
}