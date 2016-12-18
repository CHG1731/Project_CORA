using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace Module_Configuration_Tool
{
    public partial class ModuleConfigurator : Form
    {
        ModuleLib moduleLib = new ModuleLib();

        public ModuleConfigurator()
        {
            InitializeComponent();
            this.FormClosing += UserInterface_FormClosing;
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ModuleLib));
                FileStream stream = new FileStream("ModuleLib.xml", FileMode.Open);
                moduleLib = (ModuleLib)
                    serializer.Deserialize(stream);
                stream.Close();
            }
            catch (FileNotFoundException f){}
            updateModuleList();
        }

        private void UserInterface_FormClosing(object sender, FormClosingEventArgs e)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ModuleLib));
            System.IO.StreamWriter writer = new System.IO.StreamWriter("ModuleLib.xml");
            serializer.Serialize(writer, moduleLib);
            writer.Close();
        }

        private void updateModuleList()
        {
            moduleListBox.Items.Clear();
            for (int i = 0; i < moduleLib.nameList.Count; i++)
            {
                moduleListBox.Items.Add(moduleLib.nameList.ElementAt(i));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(moduleNameBox.TextLength > 2 && moduleDescriptionBox.TextLength > 2)
            {
                moduleLib.nameList.Add(moduleNameBox.Text);
                moduleLib.descriptionList.Add(moduleDescriptionBox.Text);
            }
            moduleNameBox.Clear();
            moduleDescriptionBox.Clear();
            updateModuleList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for(int i = 0; i<moduleListBox.Items.Count; i++)
            {
                moduleListBox.SelectedIndex = i;
                if (moduleListBox.CheckedIndices.Contains(i))
                {
                    int descriptionIndex = moduleLib.nameList.IndexOf((string)moduleListBox.SelectedItem);
                    moduleLib.nameList.Remove((string)moduleListBox.SelectedItem);
                    moduleLib.descriptionList.RemoveAt(descriptionIndex);
                }
            }
            updateModuleList();
        }
    }
}
