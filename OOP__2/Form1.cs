using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP__2
{
    
    public partial class Form : System.Windows.Forms.Form
    {
        private int[,] matrix;
        public Form()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            int rows = Convert.ToInt32(numericUpDown1.Value); // Отримує кількість рядків від користувача
            int columns = Convert.ToInt32(numericUpDown2.Value); // Отримує кількість стовпців від користувача

            
            // Генерує та відображує випадкову матрицю
            matrix = GenerateRandomMatrix(rows, columns);
            DisplayMatrix(matrix, dataGridView1);
        }

        // Обробник натискання кнопки "Calculate"
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (matrix == null)
            {
                MessageBox.Show("Спочатку згенеруйте матрицю.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Розраховує та відображує результати
            int negativeElementsWithZeroRow = CountNegativeElementsWithZeroRow(matrix);
            string saddlePoints = FindSaddlePoints(matrix);

            //11111
        }

        // Генерує випадкову матрицю заданого розміру
        private int[,] GenerateRandomMatrix(int rows, int columns)
        {
            
            int[,] matrix = new int[rows, columns];
            Random rand = new Random();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = rand.Next(-10, 11); // Генерує випадкові цілі числа в діапазоні від -10 до 10
                }
            }
              
            return matrix;
        }

        // Відображує матрицю у вказаному DataGridView
        private void DisplayMatrix(int[,] matrix, DataGridView dataGridView)
        {
            dataGridView.Rows.Clear();
            dataGridView.ColumnCount = matrix.GetLength(1);

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                dataGridView.Rows.Add();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    dataGridView.Rows[i].Cells[j].Value = matrix[i, j];
                }
            }
        }

        // Підраховує кількість від'ємних елементів у рядках з нульовим елементом
        private int CountNegativeElementsWithZeroRow(int[,] matrix)
        {
            int count = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                bool hasZero = false;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        hasZero = true;
                        break;
                    }
                }
                if (hasZero)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i, j] < 0)
                        {
                            count++;
                        }
                    }
                }
            }
            return count;
        }

        // Знаходить сідлові точки у матриці
        private string FindSaddlePoints(int[,] matrix)
        {
            string saddlePoints = "";
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    int currentValue = matrix[i, j];
                    bool isSaddlePoint = true;

                    // Перевіряємо, чи є currentValue мінімальним у своєму рядку
                    for (int k = 0; k < matrix.GetLength(1); k++)
                    {
                        if (matrix[i, k] < currentValue)
                        {
                            isSaddlePoint = false;
                            break;
                        }
                    }

                    // Перевіряємо, чи є currentValue максимальним у своєму стовпці
                    for (int k = 0; k < matrix.GetLength(0); k++)
                    {
                        if (matrix[k, j] > currentValue)
                        {
                            isSaddlePoint = false;
                            break;
                        }
                    }

                    // Якщо елемент є сідловою точкою, додаємо його координати до рядка результату
                    if (isSaddlePoint)
                    {
                        saddlePoints += $"({i + 1}, {j + 1}) ";
                    }
                }
            }
            if (saddlePoints == "")
            {
                saddlePoints = "немає сідлових точок";
            }
            return saddlePoints;
        }
        //123
        private void button2_Click(object sender, EventArgs e)
        {
            if (matrix == null)
            {
                MessageBox.Show("Спочатку згенеруйте матрицю.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int negativeElementsWithZeroRow = CountNegativeElementsWithZeroRow(matrix);
            string saddlePoints = FindSaddlePoints(matrix);
           MessageBox.Show($"Кількість від'ємних елементів у рядках з нульовим елементом: {negativeElementsWithZeroRow}\nСідлові точки: {saddlePoints}", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int rows = Convert.ToInt32(numericUpDown1.Value); // Отримує кількість рядків від користувача
            int columns = Convert.ToInt32(numericUpDown2.Value); // Отримує кількість стовпців від користувача

            // Генерує та відображує випадкову матрицю
            matrix = GenerateRandomMatrix(rows, columns);
            DisplayMatrix(matrix, dataGridView1);
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
    

// Клас форми для виконання операцій над матрицею

