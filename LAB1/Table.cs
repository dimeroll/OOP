using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace LabCalculator
{
    public class Table
    {
        private const int initColumnCount = 10;
        private const int initRowCount = 10;
        public int ColCount;
        public int RowCount;

        public Dictionary<string, string> dictionary = new Dictionary<string, string>();
        public List<List<Cell>> table = new List<List<Cell>>();

        public Table()
        {
            ColCount = initColumnCount;
            RowCount = initRowCount;

            for(int i =0; i< initRowCount; i++)
            {
                List<Cell> row = new List<Cell>();
                for(int j = 0; j < initColumnCount; j++)
                {
                    string name = _26Sys.To26Sys(j) + i.ToString();
                    row.Add(new Cell(name, i, j));
                    dictionary.Add(name, "");
                }
                table.Add(row);
            }
        }
        public void Clear()
        {
            table.Clear();
            dictionary.Clear();
            ColCount = 0;
            RowCount = 0;
        }

        public void SetTable(int row, int col)
        {
            Clear();
            ColCount = col;
            RowCount = row;
            for(int i = 0; i < RowCount; i++)
            {
                List<Cell> newrow = new List<Cell>();
                for(int j = 0; j< ColCount; j++)
                {
                    string name = _26Sys.To26Sys(j) + i.ToString();
                    newrow.Add(new Cell(name, i, j));
                    dictionary.Add(name, "");
                }
                table.Add(newrow);
            }

        }

        public void ChangeCellWithAllPointers(int row, int col, string expression, DataGridView dataGridView)
        {
            table[row][col].DeleteToFromCells();
            string old_expression = table[row][col]._expression;
            table[row][col]._expression = expression;

            table[row][col].new_FromThis.Clear();

            string new_expression = ConvertReferences(row, col, expression);
            //if (new_expression != "")
            //    new_expression = new_expression.Remove(0, 1);
            if (!table[row][col].CheckLoop(table[row][col].new_FromThis))
            {
                MessageBox.Show("Change the expression, there is a LOOP in references");
                table[row][col]._expression = old_expression;
                return;
            }

            table[row][col].AddToFromCells();
            string value = Calculate(new_expression);
            if(value == "error")
            {
                MessageBox.Show("Error in cell" + _26Sys.To26Sys(col) + row);
                return;
            }

            table[row][col]._value = value;
            dictionary[_26Sys.To26Sys(col) + row] = value;
            foreach (Cell cell in table[row][col].ToThis)
                RefreshToThis(cell, dataGridView);
        }

        public bool RefreshToThis(Cell cell, DataGridView dataGridView)
        {
            cell.new_FromThis.Clear();
            string new_expression = ConvertReferences(cell.RowIndex, cell.ColIndex, cell._expression);
            string value = Calculate(new_expression);

            if(value == "error")
            {
                MessageBox.Show("Error in cell" + cell.Index);
                return false;
            }

            table[cell.RowIndex][cell.ColIndex]._value = value;
            dictionary[_26Sys.To26Sys(cell.ColIndex) + cell.RowIndex] = value;
            dataGridView[cell.ColIndex, cell.RowIndex].Value = value;

            foreach(Cell point in cell.ToThis)
                if(!RefreshToThis(point, dataGridView)) return false;
            return true;
        }

        public string ConvertReferences(int row, int col, string expression)
        {
            string cellPattern = @"[A-Z]+[0-9]+";
            Regex regex = new Regex(cellPattern, RegexOptions.IgnoreCase);
            int[] nums;

            foreach(Match match in regex.Matches(expression))
                if(dictionary.ContainsKey(match.Value))
                {
                    nums = _26Sys.From26Sys(match.Value);
                    table[row][col].new_FromThis.Add(table[nums[1]][nums[0]]);
                }
            MatchEvaluator mE = new MatchEvaluator(RefToValue);
            string new_expression = regex.Replace(expression, mE);
            return new_expression;
        }

        public string RefToValue(Match m)
        {
            if (dictionary.ContainsKey(m.Value))
                if (dictionary[m.Value] == "") return "0";
                else return dictionary[m.Value];
            return m.Value;
        }

        public void AddRow(DataGridView dataGridView)
        {
            RowCount++;
            List<Cell> newrow = new List<Cell>();
            for(int i = 0; i < ColCount; i++)
            {
                string name = _26Sys.To26Sys(i) + (RowCount-1);
                newrow.Add(new Cell(name, RowCount-1, i));
                dictionary.Add(name, "");
            }
            table.Add(newrow);

            RefreshReferences();

            foreach (List<Cell> list in table)
                foreach (Cell cell in list)
                    if (cell.FromThis != null)
                        foreach (Cell cell_in_ref in cell.FromThis)
                            if (cell_in_ref.RowIndex == RowCount - 1)
                                if (!cell_in_ref.ToThis.Contains(cell)) cell_in_ref.ToThis.Add(cell);

            for (int i = 0; i < ColCount; i++)
                ChangeCellWithAllPointers(RowCount - 1, i, "", dataGridView);
        }

        public void AddColumn(DataGridView dataGridView)
        {
            ColCount++;
            for (int i = 0; i < RowCount; i++)
            {
                string name = _26Sys.To26Sys(ColCount-1) + i;
                table[i].Add(new Cell(name, i, ColCount-1));
                dictionary.Add(name, "");
            }

            RefreshReferences();

            foreach (List<Cell> list in table)
                foreach (Cell cell in list)
                    if (cell.FromThis != null)
                        foreach (Cell cell_in_ref in cell.FromThis)
                            if (cell_in_ref.ColIndex == ColCount - 1)
                                if (!cell_in_ref.ToThis.Contains(cell)) cell_in_ref.ToThis.Add(cell);

            for (int i = 0; i < RowCount; i++)
                ChangeCellWithAllPointers(i, ColCount-1, "", dataGridView);
        }

        public void RefreshReferences()
        {
            foreach(List<Cell> list in table)
                foreach(Cell cell in list)
                {
                    if (cell.FromThis != null) cell.FromThis.Clear();
                    if (cell.new_FromThis != null) cell.new_FromThis.Clear();

                    if (cell._expression == "") continue;
                    string new_expression = cell._expression;
                    new_expression = ConvertReferences(cell.RowIndex, cell.ColIndex, cell._expression);
                    cell.FromThis.AddRange(cell.new_FromThis);
                }
        }

        public bool DeleteRow(DataGridView dataGridView)
        {
            List<Cell> riskCells = new List<Cell>();
            List<string> notEmptyCells = new List<string>();
            if (RowCount == 0) return false;

            int curRow = RowCount - 1;

            for(int i = 0; i < ColCount; i++)
            {
                string name = _26Sys.To26Sys(i) + curRow;
                if (dictionary[name] != "0" && dictionary[name] != "" && dictionary[name] != " ")
                    notEmptyCells.Add(name);
                if (table[curRow][i].ToThis.Count != 0)
                    riskCells.AddRange(table[curRow][i].ToThis);
            }

            if((riskCells.Count != 0) || (notEmptyCells.Count != 0)){
                string errorMess = "";
                if(notEmptyCells.Count != 0)
                {
                    errorMess = "Not empty cells in last row : ";
                    errorMess += String.Join(" ", notEmptyCells.ToArray());
                    errorMess += Environment.NewLine;
                }

                if(riskCells.Count != 0)
                {
                    errorMess = "Other cells refer to cells from last row : ";
                    foreach (Cell cell in riskCells)
                        errorMess += cell.Index + " ";
                    errorMess += Environment.NewLine;
                }

                errorMess += "Do you really want to delete the last row?";
                DialogResult res = MessageBox.Show(errorMess, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (res == System.Windows.Forms.DialogResult.No) return false;
            }

            for(int i = 0; i < ColCount; i++)
            {
                string name = _26Sys.To26Sys(i) + curRow;
                dictionary.Remove(name);
                table[curRow][i].DeleteToFromCells();
            }

            foreach (Cell cell in riskCells)
            {
                RefreshToThis(cell, dataGridView);
            }

            table.RemoveAt(curRow);
            RowCount--;
            return true;
        }

        public bool DeleteColumn(DataGridView dataGridView)
        {
            List<Cell> riskCells = new List<Cell>();
            List<string> notEmptyCells = new List<string>();
            if (ColCount == 0) return false;

            int curColumn = ColCount - 1;

            for (int i = 0; i < RowCount; i++)
            {
                string name = _26Sys.To26Sys(curColumn) + i;
                if (dictionary[name] != "0" && dictionary[name] != "" && dictionary[name] != " ")
                    notEmptyCells.Add(name);
                if (table[i][curColumn].ToThis.Count != 0)
                    riskCells.AddRange(table[i][curColumn].ToThis);
            }

            if ((riskCells.Count != 0) || (notEmptyCells.Count != 0))
            {
                string errorMess = "";
                if (notEmptyCells.Count != 0)
                {
                    errorMess = "Not empty cells in last column : ";
                    errorMess += String.Join(" ", notEmptyCells.ToArray());
                    errorMess += Environment.NewLine;
                }

                if (riskCells.Count != 0)
                {
                    errorMess = "Other cells refer to cells from last column : ";
                    foreach (Cell cell in riskCells)
                        errorMess += cell.Index + " ";
                    errorMess += Environment.NewLine;
                }

                errorMess += "Do you really want to delete the last column?";
                DialogResult res = MessageBox.Show(errorMess, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (res == System.Windows.Forms.DialogResult.No) return false;
            }

            for (int i = 0; i < RowCount; i++)
            {
                string name = _26Sys.To26Sys(curColumn) + i;
                dictionary.Remove(name);
                table[i][curColumn].DeleteToFromCells();
            }

            foreach (Cell cell in riskCells)
                RefreshToThis(cell, dataGridView);

            foreach (List<Cell> list in table)
                list.RemoveAt(curColumn);
            ColCount--;
            return true;
        }

        public string Calculate(string expression)
        {
            string res = null;
            try
            {
                res = (Calculator.Evaluate(expression)).ToString();
                if (res == "∞" || res == "-∞")
                    return "Divide by zero";
                return res;
            }
            catch { return "Error"; }   
        }

        public void Save(StreamWriter sw)
        {
            sw.WriteLine(RowCount);
            sw.WriteLine(ColCount);
            foreach(List<Cell> list in table)
                foreach(Cell cell in list)
                {
                    sw.WriteLine(cell.Index);
                    sw.WriteLine(cell._expression);
                    sw.WriteLine(cell._value);

                    if (cell.FromThis == null)
                        sw.WriteLine(0);
                    else
                    {
                        sw.WriteLine(cell.FromThis.Count);
                        foreach (Cell refcell in cell.FromThis)
                            sw.WriteLine(refcell.Index);
                    }

                    if (cell.ToThis == null)
                        sw.WriteLine(0);
                    else
                    {
                        sw.WriteLine(cell.ToThis.Count);
                        foreach (Cell tothiscell in cell.ToThis)
                            sw.WriteLine(tothiscell.Index);
                    }

                }
        }

        public void Open(int row, int col, StreamReader sr, DataGridView dataGridView)
        {
            for(int r=0; r < row; r++)
            {
                for(int c=0; c<col; c++)
                {
                    string index = sr.ReadLine();
                    string expression = sr.ReadLine();
                    string value = sr.ReadLine();

                    if (expression != "")
                        dictionary[index] = value;
                    else
                        dictionary[index] = "";
                    int refCount = Convert.ToInt32(sr.ReadLine());
                    List<Cell> newRef = new List<Cell>();
                    string refer;
                    for(int i = 0; i < refCount; i++)
                    {
                        refer = sr.ReadLine();
                        newRef.Add(table[_26Sys.From26Sys(refer)[1]][_26Sys.From26Sys(refer)[0]]);
                    }

                    int tothisCount = Convert.ToInt32(sr.ReadLine());
                    List<Cell> newToThis = new List<Cell>();
                    string point;
                    for (int i = 0; i < tothisCount; i++)
                    {
                        point = sr.ReadLine();
                        newToThis.Add(table[_26Sys.From26Sys(point)[1]][_26Sys.From26Sys(point)[0]]);
                    }

                    table[r][c].SetCell(value, expression, newRef, newToThis);
                    int icol = table[r][c].ColIndex;
                    int irow = table[r][c].RowIndex;
                    dataGridView[icol, irow].Value = dictionary[index];
                }
            }
        }
    }

    public class Cell
    {
        public string Index { get; set; }
        public int ColIndex { get; set; }
        public int RowIndex { get; set; }
        public string _value;
        public string _expression;
        public List<Cell> ToThis = new List<Cell>();
        public List<Cell> FromThis = new List<Cell>();
        public List<Cell> new_FromThis = new List<Cell>();

        public Cell(string index, int row, int col)
        {
            Index = index;
            ColIndex = col;
            RowIndex = row;
            _value = "0";
            _expression = "";
        }
        public void SetCell(string value, string expression, List<Cell> fromthis, List<Cell> tothis)
        {
            this._value = value;
            this._expression = expression;

            this.FromThis.Clear();
            this.FromThis.AddRange(fromthis);
            this.ToThis.Clear();
            this.ToThis.AddRange(tothis);
        }

        public void AddToFromCells()
        {
            foreach (Cell point in new_FromThis)
                point.ToThis.Add(this);
            FromThis = new_FromThis;
        }

        public void DeleteToFromCells()
        {
            if(FromThis != null)
               foreach (Cell point in FromThis)
                  point.ToThis.Remove(this);
            FromThis = null;
        }

        public bool CheckLoop(List<Cell> checklist)
        {
            foreach(Cell cell in checklist)
            {
                if (cell.Index == Index) return false;
            }
            foreach(Cell point in ToThis)
            {
                foreach (Cell cell in checklist)
                    if (cell.Index == point.Index) return false;
                if (!point.CheckLoop(checklist)) return false;
            }
            return true;
        }
    }
}
