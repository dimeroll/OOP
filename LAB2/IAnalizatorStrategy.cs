using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Linq;

namespace LAB2
{
    interface IAnalizatorStrategy
    {
        List<Employees> Search(Employees employee);
    }

    class AnalizatorDOMStrategy : IAnalizatorStrategy
    {
        public List<Employees> Search(Employees employee)
        {
            List<Employees> result = new List<Employees>();
            XmlDocument doc = new XmlDocument();
            doc.Load(@"D:\OOP\LAB2\XMLFileLab2.xml");

            XmlNode node = doc.DocumentElement;
            foreach (XmlNode n in node.ChildNodes)
            {
                string FullName = "";
                string Department = "";
                string Faculty = "";
                string Education = "";
                string University = "";
                string EducationPeriod = "";

                foreach (XmlAttribute attribute in n.Attributes)
                {
                    if (attribute.Name.Equals("FullName") && (attribute.Value.Equals(employee.FullName) || employee.FullName == ""))
                        FullName = attribute.Value;

                    if (attribute.Name.Equals("Faculty") && (attribute.Value.Equals(employee.Faculty) || employee.Faculty == ""))
                        Faculty = attribute.Value;

                    if (attribute.Name.Equals("Department") && (attribute.Value.Equals(employee.Department) || employee.Department == ""))
                        Department = attribute.Value;

                    if (attribute.Name.Equals("Education") && (attribute.Value.Equals(employee.Education) || employee.Education == ""))
                        Education = attribute.Value;

                    if (attribute.Name.Equals("University") && (attribute.Value.Equals(employee.University) || employee.University == ""))
                        University = attribute.Value;

                    if (attribute.Name.Equals("EducationPeriod") && (attribute.Value.Equals(employee.EducationPeriod) || employee.EducationPeriod == ""))
                        EducationPeriod = attribute.Value;
                }
                if (FullName != "" && Faculty != "" && Department != "" && Education != "" && University != "" && EducationPeriod != "")
                {

                    Employees employeeNew = new Employees();
                    employeeNew.FullName = FullName;
                    employeeNew.Faculty = Faculty;
                    employeeNew.Department = Department;
                    employeeNew.Education = Education;
                    employeeNew.University = University;
                    employeeNew.EducationPeriod = EducationPeriod;

                    result.Add(employeeNew);
                }
            }

            return result;
        }
    }

    class AnalizatorSAXStrategy : IAnalizatorStrategy
    {
        public List<Employees> Search(Employees employee)
        {
            List<Employees> result = new List<Employees>();
            var xmlReader = new XmlTextReader(@"D:\OOP\LAB2\XMLFileLab2.xml");

            while (xmlReader.Read())
            {
                if (xmlReader.HasAttributes)
                {
                    string FullName = "";
                    string Department = "";
                    string Faculty = "";
                    string Education = "";
                    string University = "";
                    string EducationPeriod = "";

                    while (xmlReader.MoveToNextAttribute())
                    {
                        if (xmlReader.Name.Equals("FullName") && (xmlReader.Value.Equals(employee.FullName) || employee.FullName == ""))
                            FullName = xmlReader.Value;

                        if (xmlReader.Name.Equals("Faculty") && (xmlReader.Value.Equals(employee.Faculty) || employee.Faculty == ""))
                            Faculty = xmlReader.Value;

                        if (xmlReader.Name.Equals("Department") && (xmlReader.Value.Equals(employee.Department) || employee.Department == ""))
                            Department = xmlReader.Value;

                        if (xmlReader.Name.Equals("Education") && (xmlReader.Value.Equals(employee.Education) || employee.Education == ""))
                            Education = xmlReader.Value;

                        if (xmlReader.Name.Equals("University") && (xmlReader.Value.Equals(employee.University) || employee.University == ""))
                            University = xmlReader.Value;

                        if (xmlReader.Name.Equals("EducationPeriod") && (xmlReader.Value.Equals(employee.EducationPeriod) || employee.EducationPeriod == ""))
                            EducationPeriod = xmlReader.Value;
                    }

                    if (FullName != "" && Faculty != "" && Department != "" && Education != "" && University != "" && EducationPeriod != "")
                    {

                        Employees employeeNew = new Employees();
                        employeeNew.FullName = FullName;
                        employeeNew.Faculty = Faculty;
                        employeeNew.Department = Department;
                        employeeNew.Education = Education;
                        employeeNew.University = University;
                        employeeNew.EducationPeriod = EducationPeriod;

                        result.Add(employeeNew);
                    }
                }
            }

            xmlReader.Close();
            return result;
        }
    }

    class AnalizatorLINQtoXMLStrategy : IAnalizatorStrategy
    {
        public List<Employees> Search(Employees employee)
        {
            List<Employees> resultlist = new List<Employees>();
            var doc = XDocument.Load(@"D:\OOP\LAB2\XMLFileLab2.xml");

            var result = from obj in doc.Descendants("Employee")
                         where (
                         (obj.Attribute("FullName").Value.Equals(employee.FullName) || employee.FullName == "") &&
                         (obj.Attribute("Faculty").Value.Equals(employee.Faculty) || employee.Faculty == "") &&
                         (obj.Attribute("Department").Value.Equals(employee.Department) || employee.Department == "") &&
                         (obj.Attribute("Education").Value.Equals(employee.Education) || employee.Education == "") &&
                         (obj.Attribute("University").Value.Equals(employee.University) || employee.University == "") &&
                         (obj.Attribute("EducationPeriod").Value.Equals(employee.EducationPeriod) || employee.EducationPeriod == ""))

                         select new
                         {
                             FullName = (string)obj.Attribute("FullName"),
                             Faculty = (string)obj.Attribute("Faculty"),
                             Department = (string)obj.Attribute("Department"),
                             Education = (string)obj.Attribute("Education"),
                             University = (string)obj.Attribute("University"),
                             EducationPeriod = (string)obj.Attribute("EducationPeriod")
                         };

            foreach (var x in result)
            {
                Employees employeeNew = new Employees();
                employeeNew.FullName = x.FullName;
                employeeNew.Faculty = x.Faculty;
                employeeNew.Department = x.Department;
                employeeNew.Education = x.Education;
                employeeNew.University = x.University;
                employeeNew.EducationPeriod = x.EducationPeriod;

                resultlist.Add(employeeNew);
            }

            return resultlist;
        }
    }
}