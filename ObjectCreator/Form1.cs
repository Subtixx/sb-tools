using System;
using System.Collections.Generic;
using System.IO;
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

            var objectText = File.ReadAllText(
                                   @"D:\Program Files (x86)\Steam\steamapps\common\Starbound\moddev\extratransportation\objects\transport\hopper\hopper.object");

            ITraceWriter traceWriter = new MemoryTraceWriter();
            dynamic obj = JsonConvert.DeserializeObject(objectText);
            //StarboundObject obj = JsonConvert.DeserializeObject<StarboundObject>(objectText, new JsonSerializerSettings { TraceWriter = traceWriter });
            //Debug.WriteLine(obj);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StarboundObject obj = new StarboundObject(textBox1.Text);
            File.WriteAllText(textBox1.Text + ".object", JsonConvert.SerializeObject(obj, Formatting.Indented));
        }
    }
}