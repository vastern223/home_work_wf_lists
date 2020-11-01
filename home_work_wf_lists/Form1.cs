using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace home_work_wf_lists
{
    public partial class Form1 : Form
    {
        public List<Employee> employees = new List<Employee>();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {         
            if (button1.Text == "change")
            {             
                   employees[Employee1.SelectedIndex].Surname = textBox1.Text;
                employees[Employee1.SelectedIndex].Salary = numericUpDown1.Value;
                employees[Employee1.SelectedIndex].Position = comboBox1.Text;
                employees[Employee1.SelectedIndex].Street = comboBox2.Text;
                employees[Employee1.SelectedIndex].City = comboBox3.Text;
                employees[Employee1.SelectedIndex].House = numericUpDown2.Value;

                foreach (var item in employees)
                {
                    Employee1.Items.Remove(item);
                }

                foreach (var item in employees)
                {
                    Employee1.Items.Add(item);
                }           
                textBox1.ResetText();
                numericUpDown1.Value = 0;
                comboBox1.ResetText();
                comboBox2.ResetText();
                comboBox3.ResetText();
                numericUpDown2.Value = 0;
                button1.Text = "creation";
            }
            else
            {             
                Employee employee = new Employee();

                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    MessageBox.Show("Enter valid Surname!");
                    return;
                }
                else
                {
                    employee.Surname = textBox1.Text;
                }

                if (numericUpDown1.Value > 0 && 10000 >= numericUpDown1.Value)
                {
                    employee.Salary = numericUpDown1.Value;
                }
                else
                {
                    MessageBox.Show("Enter valid salary!");
                    return;
                }

                if (string.IsNullOrWhiteSpace(comboBox1.Text))
                {
                    MessageBox.Show("Enter valid position!");
                    return;
                }
                else
                {
                    employee.Position = comboBox1.Text;
                }

                if (string.IsNullOrWhiteSpace(comboBox2.Text))
                {
                    MessageBox.Show("Enter valid Street!");
                    return;
                }
                else
                {
                    employee.Street = comboBox2.Text;
                }

                if (string.IsNullOrWhiteSpace(comboBox3.Text))
                {
                    MessageBox.Show("Enter valid city!");
                    return;
                }
                else
                {
                    employee.City = comboBox3.Text;
                }


                if (numericUpDown2.Value > 0 && numericUpDown2.Value < 100)
                {
                    employee.House = numericUpDown2.Value;
                }
                else
                {
                    MessageBox.Show("Enter valid House!");
                    return;
                }

                Employee1.Items.Add(employee);
                employees.Add(employee);
                textBox1.ResetText();
                numericUpDown1.Value = 0;
                comboBox1.ResetText();
                comboBox2.ResetText();
                comboBox3.ResetText();
                numericUpDown2.Value = 0;
                MessageBox.Show("employee added!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            employees.RemoveAt(Employee1.SelectedIndex);
            Employee1.Items.RemoveAt(Employee1.SelectedIndex);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (Employee1.SelectedIndex != -1)
            {
                button1.Text = "change";
                textBox1.Text = employees[Employee1.SelectedIndex].Surname;
                numericUpDown1.Value = employees[Employee1.SelectedIndex].Salary;
                comboBox1.Text = employees[Employee1.SelectedIndex].Position;
                comboBox2.Text = employees[Employee1.SelectedIndex].Street;
                comboBox3.Text = employees[Employee1.SelectedIndex].City;
                numericUpDown2.Value = employees[Employee1.SelectedIndex].House;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (FileStream fout = new FileStream("file1.xml", FileMode.OpenOrCreate))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(List<Employee>));
                formatter.Serialize(fout, employees);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (FileStream fin = new FileStream("file1.xml", FileMode.OpenOrCreate))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(List<Employee>));
                List<Employee> newlistWorkers = (List<Employee>)formatter.Deserialize(fin);
                employees = newlistWorkers;
            }

            foreach (var item in employees)
            {
                Employee1.Items.Add(item.ToString());
            }

        }
    }




    public class Employee
    {
        public string Surname { get; set; }
        public decimal Salary { get; set; }
        public string Position { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public decimal House { get; set; }
        public override string ToString()
        {
            return $"Surname: {Surname} \n" +
                $"Selery: {Salary} \n" +
                $"Position: {Position} \n" +
                $"City: {City} \n" +
                $"Street: {Street} \n" +
                $"House: {House} \n";
        }

    }
}
