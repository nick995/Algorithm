using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumorMill
{




    public class RumorMill
    {

        public static void Main(string[] args) {



            Dictionary<string, Student> studentsList = new Dictionary<string, Student>();

            List<string> answer = new List<string>();

            int studentCount = int.Parse(Console.ReadLine());
            
            //insert the student to the studentlist
            for (int i = 0; i < studentCount; i++)
            {
                string studentName = Console.ReadLine();

                studentsList.Add(studentName, new Student(0,studentName));
                //alphabetList.Add(studentName);
            }

            int connectCount = int.Parse(Console.ReadLine());

            for(int j=0; j< connectCount; j++)
            {
                string[] friendShip = Console.ReadLine().Split(" ");

                AddFriend(studentsList[friendShip[0]], studentsList[friendShip[1]]);
            }

            int rumorCount = int.Parse(Console.ReadLine());

            for(int k=0; k< rumorCount; k++)
            {
                string rumorStarter = Console.ReadLine();

                RumorSpread(studentsList[rumorStarter], studentsList, answer);

            }

        }

        public static void RumorSpread(Student rumorStarter, Dictionary<string, Student> stu, List<string> an)
        {

            Dictionary<string, Student> studentList = new Dictionary<string, Student>(stu);

            List<string>answer = new List<string>(an);

            rumorStarter.day = 0;

            Queue<Student> queue = new Queue<Student>();

            queue.Enqueue(rumorStarter);

            while (queue.Count > 0)
            {
                Student student = queue.Dequeue();  //pointing same memory.

                if (student.day<3)
                {
                    if (student.visited == false)
                    {
                        answer.Add(student.name);    //adding answer.

                        studentList.Remove(student.name); 
                    }

                    student.visited = true; //change to visit.

                    IEnumerable<Student> orderByName = student.friendList.OrderBy(p => p.name);

                    foreach (Student s in orderByName)
                    {
                        if (!s.visited)
                        {
                            queue.Enqueue((Student)s);
                            s.day = student.day + 1;
                        }
                    }
                }
            }

            if (studentList.Count() > 0)
            {
                List<string> temp = studentList.Select(kvp => kvp.Key).ToList();

                temp.Sort();

                foreach (string s in temp)
                {
                    answer.Add(s);
                }
            }

            foreach (string s in answer)
            {
                Console.Write(s + " ");
            }
        }




        public static void AddFriend(Student s1, Student s2)
        {
            s1.friendList.Add(s2);
            s2.friendList.Add(s1);
        }




        public class Student
        {
            //LinkedList<Student> friendList { get; set; };
            //int day { get; set; };
            //string name { get; set; };

            public Student(int day, string name)
            {
                this.name = name;
                this.day = day;
                this.friendList = new List<Student>();
                this.visited = false;
            }

            public bool visited { get; set; }
            public string name { get;  set; }
            public int day { get;  set; }
            public List<Student> friendList { get;}

        }
    }
}
