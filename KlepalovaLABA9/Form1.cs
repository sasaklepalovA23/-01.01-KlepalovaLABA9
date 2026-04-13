using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KlepalovaLABA9
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();

            numericUpDown1.Minimum = 1;
            numericUpDown2.Minimum = 1;
            radioButton2.Checked = true; 
            radioButton3.Checked = true; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int rows = (int)numericUpDown1.Value;
            int cols = (int)numericUpDown2.Value;

            dataGridView1.RowCount = rows;
            dataGridView1.ColumnCount = cols;

            
            foreach (DataGridViewColumn col in dataGridView1.Columns)
                col.Width = 40;

            
            if (radioButton2.Checked)
            {
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = rnd.Next(1, 100);
                    }
                }
            }
            else 
            {
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = "";
                    }
                }
            }
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int rows = dataGridView1.RowCount;
                int cols = dataGridView1.ColumnCount;

                if (rows == 0 || cols == 0) return;

                textBox1.Clear();

                if (radioButton3.Checked)
                {
                   
                    for (int i = 0; i < rows; i++)
                    {
                        int[] tempArr = new int[cols];
                        for (int j = 0; j < cols; j++)
                            tempArr[j] = Convert.ToInt32(dataGridView1.Rows[i].Cells[j].Value);

                        BubbleSort(tempArr);
                        textBox1.Text += "Строка " + (i + 1) + ": " + string.Join(", ", tempArr) + Environment.NewLine;
                    }
                }
                else
                {
                    
                    for (int j = 0; j < cols; j++)
                    {
                        int[] tempArr = new int[rows];
                        for (int i = 0; i < rows; i++)
                            tempArr[i] = Convert.ToInt32(dataGridView1.Rows[i].Cells[j].Value);

                        BubbleSort(tempArr);
                        textBox1.Text += "Столбец " + (j + 1) + ": " + string.Join(", ", tempArr) + Environment.NewLine;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! Убедитесь, что все ячейки заполнены числами. " + ex.Message);
            }
        }

        
        void BubbleSort(int[] arr)
        {
            int temp;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
        }
    }
}

