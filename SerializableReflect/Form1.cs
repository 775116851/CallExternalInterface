using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace SerializableReflect
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Person p = new Person();
            p.Name = "战三";
            p.Age = 22;

            //FileStream fs = new FileStream("ps.txy", FileMode.Create);
            //BinaryFormatter formatter = new BinaryFormatter();
            //formatter.Serialize(fs, p);
            //Person pp = (Person)formatter.Deserialize(fs);

            //string seString = string.Empty;
            //XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));
            //using(MemoryStream ms = new MemoryStream())
            //{
            //    xmlSerializer.Serialize(ms, p);
            //    seString = Encoding.UTF8.GetString(ms.ToArray());
            //}

            //string seJson = string.Empty;
            //DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(Person));
            //using (MemoryStream stream = new MemoryStream())
            //{
            //    json.WriteObject(stream, p);
            //    seJson = Encoding.UTF8.GetString(stream.ToArray());
            //}
            //using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(seJson)))
            //{
            //    DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Person));
            //    Person ppp = (Person)serializer.ReadObject(ms);
            //}

            Man man = new Man();
            man.Height = 165;
            List<Man> listMan = new List<Man>();
            Man mann1 = new Man();
            mann1.Height = 182;
            listMan.Add(mann1);
            Man mann2 = new Man();
            mann2.Height = 178;
            listMan.Add(mann2);

            p.Mans = man;
            p.ManList = listMan;
            string mf = Show(p);
            MessageBox.Show(mf);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("ps.txy", FileMode.Open);
            //BinaryFormatter formatter = new BinaryFormatter();
            //Person pp = (Person)formatter.Deserialize(fs);

            //string m = getProperties(pp);
            //MessageBox.Show(m);
        }

        public string Show(object t)
        {
            string tStr = string.Empty;
            if (t == null)
            {
                return tStr;
            }
            System.Reflection.PropertyInfo[] properties = t.GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);

            if (properties.Length <= 0)
            {
                return tStr;
            }
            tStr += "{"+t.GetType().Name+" :[";
            foreach (System.Reflection.PropertyInfo item in properties)
            {
                string name = item.Name;
                object value = item.GetValue(t, null);
                if (item.PropertyType.IsGenericType)//List集合
                {
                    Type objType = value.GetType();
                    int count = Convert.ToInt32(objType.GetProperty("Count").GetValue(value, null));

                    for (int i = 0; i < count; i++)
                    {
                        object listItem = objType.GetProperty("Item").GetValue(value, new object[] { i });
                        tStr += Show(listItem);
                    }
                }
                else if (item.PropertyType.IsValueType || item.PropertyType.Name.StartsWith("String"))//字段
                {
                    tStr += string.Format("{0}:{1},", name, value);
                }
                else//对象
                {
                    tStr += Show(value);
                }
            }
            tStr += " ]}";
            return tStr;
        }

        public string getProperties<T>(T t)
        {
            string tStr = string.Empty;
            if (t == null)
            {
                return tStr;
            }
            System.Reflection.PropertyInfo[] properties = t.GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);

            if (properties.Length <= 0)
            {
                return tStr;
            }
            foreach (System.Reflection.PropertyInfo item in properties)
            {
                string name = item.Name;
                object value = item.GetValue(t, null);
                if (item.PropertyType.IsValueType || item.PropertyType.Name.StartsWith("String"))
                {
                    tStr += string.Format("{0}:{1},", name, value);
                }
                else
                {
                    getProperties(value);
                }
            }
            return tStr;
        }
    }

    [System.Runtime.Serialization.DataContract]
    [Serializable]
    public class Person
    {
        public Person()
        {
            Init();
        }

        private string _Name;
        private int _Age;

        [DataMember]
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        [DataMember]
        public int Age
        {
            get { return _Age; }
            set { _Age = value; }
        }

        [DataMember]
        public Man Mans{get;set;}
        [DataMember]
        public List<Man> ManList{get;set;}

        [System.Runtime.Serialization.OnDeserializing]
        private void OnDeserializing(StreamingContext ctx)
        {
            Init();
        }

        public void Init()
        {
            Name = string.Empty;
            Age = -9999;
            Mans = new Man();
            ManList = new List<Man>();
        }

        public int CompareTo(Person other)
        {
            return Age.CompareTo(other.Age);
        }
    }

    [Serializable]
    public class Man
    {
        public Man()
        {
            Init();
        }

        private int _Height;
        [DataMember]
        public int Height
        {
            get { return _Height; }
            set { _Height = value; }
        }

        public void Init()
        {
            Height = -9999;
        }
    }

}
