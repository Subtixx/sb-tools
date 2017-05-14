using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ObjectCreator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            /*var objectText = File.ReadAllText(
                                   @"D:\Program Files (x86)\Steam\steamapps\common\Starbound\moddev\extratransportation\objects\transport\hopper\hopper.object");

            ITraceWriter traceWriter = new MemoryTraceWriter();
            dynamic obj = JsonConvert.DeserializeObject(objectText);*/
            //StarboundObject obj = JsonConvert.DeserializeObject<StarboundObject>(objectText, new JsonSerializerSettings { TraceWriter = traceWriter });
            //Debug.WriteLine(obj);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == ""){ MessageBox.Show("Object name is required."); return; }

            StarboundObject obj = new StarboundObject(textBox1.Text);
            if (comboBox1.SelectedItem != null)
                obj.rarity = (string) comboBox1.SelectedItem;
            if(listBox1.Items.Count > 0)
                obj.colonyTags.AddRange(listBox1.Items.Cast<string>());
            if (textBox2.Text != "")
                obj.description = textBox2.Text;
            if (textBox3.Text != "")
                obj.shortdescription = textBox3.Text;
            if (comboBox3.SelectedItem != null)
                obj.race = (string)comboBox3.SelectedItem;
            obj.price = (int)Math.Round(numericUpDown1.Value);
            obj.printable = checkBox1.Checked;

            File.WriteAllText(textBox1.Text + ".object", JsonConvert.SerializeObject(obj, Formatting.Indented));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem == null) return;
            if (listBox1.Items.Contains(comboBox2.SelectedItem)) return;

            listBox1.Items.Add((string)comboBox2.SelectedItem);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedItem != null)
                listBox1.Items.Remove(listBox1.SelectedItem);
        }
    }
}