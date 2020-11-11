using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Xsl;

namespace LAB2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            GetAllEmployees();
        }

        public void GetAllEmployees()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"D:\OOP\LAB2\XMLFileLab2.xml");
            XmlElement Root = doc.DocumentElement;
            XmlNodeList childNodes = Root.SelectNodes("Employee");

            for( int i=0; i < childNodes.Count; i++)
            {
                XmlNode node = childNodes.Item(i);
                AddItemsToForm(node);
            }
        }

        public void AddItemsToForm(XmlNode node)
        {
            if (!comboBoxFullName.Items.Contains(node.SelectSingleNode("@FullName").Value))
                comboBoxFullName.Items.Add(node.SelectSingleNode("@FullName").Value);

            if (!comboBoxFaculty.Items.Contains(node.SelectSingleNode("@Faculty").Value))
                comboBoxFaculty.Items.Add(node.SelectSingleNode("@Faculty").Value);

            if (!comboBoxDepartment.Items.Contains(node.SelectSingleNode("@Department").Value))
                comboBoxDepartment.Items.Add(node.SelectSingleNode("@Department").Value);

            if (!comboBoxEducation.Items.Contains(node.SelectSingleNode("@Education").Value))
                comboBoxEducation.Items.Add(node.SelectSingleNode("@Education").Value);

            if (!comboBoxUniversity.Items.Contains(node.SelectSingleNode("@University").Value))
                comboBoxUniversity.Items.Add(node.SelectSingleNode("@University").Value);

            if (!comboBoxEducationPeriod.Items.Contains(node.SelectSingleNode("@EducationPeriod").Value))
                comboBoxEducationPeriod.Items.Add(node.SelectSingleNode("@EducationPeriod").Value);
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {
            richTextBox1.Text = "";
            Employees employee = new Employees();

            if (CheckBoxFullName.Checked)
                employee.FullName = comboBoxFullName.SelectedItem.ToString();

            if (CheckBoxFaculty.Checked)
                employee.Faculty = comboBoxFaculty.SelectedItem.ToString();

            if (CheckBoxDepartment.Checked)
                employee.Department = comboBoxDepartment.SelectedItem.ToString();

            if (CheckBoxEducation.Checked)
                employee.Education = comboBoxEducation.SelectedItem.ToString();

            if (CheckBoxUniversity.Checked)
                employee.University = comboBoxUniversity.SelectedItem.ToString();

            if (CheckBoxEducationPeriod.Checked)
                employee.EducationPeriod = comboBoxEducationPeriod.SelectedItem.ToString();

            IAnalizatorStrategy analizator = new AnalizatorSAXStrategy();

            if (radioButtonDOM.Checked)
                analizator = new AnalizatorDOMStrategy();
            if (radioButtonSAX.Checked)
                analizator = new AnalizatorSAXStrategy();
            if (radioButtonLINQtoXML.Checked)
                analizator = new AnalizatorLINQtoXMLStrategy();

            List<Employees> result = analizator.Search(employee);

            foreach(Employees emp in result)
            {
                richTextBox1.Text += "Повне ім'я: " + emp.FullName + "\n";
                richTextBox1.Text += "Факультет: " + emp.Faculty + "\n";
                richTextBox1.Text += "Кафедра: " + emp.Department + "\n";
                richTextBox1.Text += "Тип освіти: " + emp.Education + "\n";
                richTextBox1.Text += "Університет: " + emp.University + "\n";
                richTextBox1.Text += "Період освіти: " + emp.EducationPeriod + "\n";
                richTextBox1.Text += "\n\n\n\n";
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }

        private void buttonTransformation_Click(object sender, EventArgs e)
        {
            Transform();
        }

        private void Transform()
        {
            XslCompiledTransform xsl = new XslCompiledTransform();
            xsl.Load(@"D:\OOP\LAB2\XMLFileLab2.xsl");
            string XML = @"D:\OOP\LAB2\XMLFileLab2.xml";
            string HTML = @"D:\OOP\LAB2\XMLFileLab2.html";
            xsl.Transform(XML, HTML);
        }
    }

   
}
