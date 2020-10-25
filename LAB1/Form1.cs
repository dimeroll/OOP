using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabCalculator
{
    public partial class Form1 : Form
    {
        Table TAB = new Table();
        public Form1()
        {
            InitializeComponent();
            InitTable(TAB.RowCount, TAB.ColCount);
        }
        private void InitTable(int row, int col)
        {
            for(int i = 0; i < col; i++)
            {
                string columnName = _26Sys.To26Sys(i);
                dataGridView1.Columns.Add(columnName, columnName);
                dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dataGridView1.RowCount = row + 1;
            for (int i = 0; i < row; i++)
                dataGridView1.Rows[i].HeaderCell.Value = i.ToString();
            //dataGridView1.Rows[row].Visible = false;
            TAB.SetTable(row, col);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int curRow = TAB.RowCount - 1;
            if (!TAB.DeleteRow(dataGridView1)) return;

            dataGridView1.Rows.RemoveAt(curRow);
            RefreshRowNumbers();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "MyExcelFile|*.txt";
            saveFileDialog.Title = "Save MyExcel File";
            saveFileDialog.ShowDialog();

            if(saveFileDialog.FileName != "")
            {
                FileStream fs = (FileStream)saveFileDialog.OpenFile();
                StreamWriter sw = new StreamWriter(fs);

                TAB.Save(sw);

                sw.Close();
                fs.Close();
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            int col = dataGridView1.SelectedCells[0].ColumnIndex;
            int row = dataGridView1.SelectedCells[0].RowIndex;
            string expr = textBox1.Text;
            if (expr == "") return;

            TAB.ChangeCellWithAllPointers(row, col, expr, dataGridView1);
            dataGridView1[col, row].Value = TAB.table[row][col]._value;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int col = dataGridView1.SelectedCells[0].ColumnIndex;
            int row = dataGridView1.SelectedCells[0].RowIndex;

            string expr = TAB.table[row][col]._expression;
            textBox1.Text = expr;
            textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            if(dataGridView1.Columns.Count == 0)
            {
                MessageBox.Show("No columns");
                return;
            }
            dataGridView1.Rows.Add(row);
            TAB.AddRow(dataGridView1);
            RefreshRowNumbers();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string colname = _26Sys.To26Sys(TAB.ColCount);
            dataGridView1.Columns.Add(colname, colname);

            TAB.AddColumn(dataGridView1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int curCol = TAB.ColCount - 1;
            if (!TAB.DeleteColumn(dataGridView1)) return;

            dataGridView1.Columns.RemoveAt(curCol);
        }

        private void RefreshRowNumbers()
        {
            for(int i = 0; i < TAB.RowCount; i++)
            {
                dataGridView1.Rows[i].HeaderCell.Value = i.ToString();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string errorMess = "Save a current file if you need";
            DialogResult res = MessageBox.Show(errorMess, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == System.Windows.Forms.DialogResult.Yes) return;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "MyExcelFile|.txt";
            openFileDialog.Title = "Select MyExcel File";
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;
            StreamReader sr = new StreamReader(openFileDialog.FileName);

            TAB.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            Int32.TryParse(sr.ReadLine(), out int row);
            Int32.TryParse(sr.ReadLine(), out int col);

            InitTable(row, col);
            TAB.Open(row, col, sr, dataGridView1);
            sr.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string message = "Список варіантів операцій та функцій :";
            message += Environment.NewLine;
            message += "+, -, *, / (бінарні операції)";
            message += Environment.NewLine;
            message += "+, - (унарні операції)";
            message += Environment.NewLine;
            message += "mmax(x1,x2,...,xN), mmіn(x1,x2,...,xN)";
            message += "=, <, >, >=, <=, <>";
            message += Environment.NewLine;
            message += "Вибравши клітинку, вводимо вираз у TextBox, натискаючи arithmetic result або logic result, присвоюємо значення цього виразу вибраній клітинці";
            message += Environment.NewLine + Environment.NewLine;
            message += "logic result лише відображає результат виразу для клітинки у вигляді 0 або 1, але інші клітинки використовують арифметичне значення виразу даної клітинки";
            message += Environment.NewLine + Environment.NewLine;
            message += "Останній рядок таблиці, який не нумерований, НЕ є функціональним (пов'язано з особливостями DataGridView)";
            DialogResult res = MessageBox.Show(message, "Допомогa користувачу", MessageBoxButtons.OK, MessageBoxIcon.Information );
            if (res == System.Windows.Forms.DialogResult.OK) return;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int col = dataGridView1.SelectedCells[0].ColumnIndex;
            int row = dataGridView1.SelectedCells[0].RowIndex;
            string expr = textBox1.Text;
            if (expr == "") return;
            TAB.ChangeCellWithAllPointers(row, col, expr, dataGridView1);
            if (TAB.table[row][col]._value == "Divide by zero" || TAB.table[row][col]._value == "Error" || TAB.table[row][col]._value == (Double.NaN).ToString())
                dataGridView1[col, row].Value = TAB.table[row][col]._value;
            else
                dataGridView1[col, row].Value = Convert.ToDouble(Convert.ToBoolean(Convert.ToDouble(TAB.table[row][col]._value)));
        }
    }
}
