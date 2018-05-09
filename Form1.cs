using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace IskiaLife
{
    public partial class Form1 : Form
    {
        static OpenFileDialog ofd = new OpenFileDialog();
        String path = @"C:\Program Files\Steam\steamapps\common\arma 3\arma3launcher.exe";
        String dir = AppDomain.CurrentDomain.BaseDirectory;
        String FileName = "Iskia-Settings.json";
        User user = new User();

        public Form1()
        {
            InitializeComponent();
            if(File.Exists(dir + FileName))
            {
                loadSettings();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveSettings();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Réalisé par AntDev+");
            if (result == DialogResult.OK)
            {
                System.Diagnostics.Process.Start("https://github.com/AntDevPlus");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (File.Exists(path) && rdexist.Checked)
            {
            Process.Start(path,
                "-connect=54.36.12.55:2302 -password=iskia "+ @"-mod=!Workshop\@IskiaLife;");
            }
            else
            {
                MessageBox.Show("Vous n'avez pas signifiez un arma3launcher.exe valide ou vous ne possedez pas les mods !");
                System.Diagnostics.Process.Start("https://steamcommunity.com/sharedfiles/filedetails/?id=1348440043");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog(this) == DialogResult.OK)
            {
                path = ofd.InitialDirectory + ofd.FileName;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://iskia.fr/");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("ts3server://ts.iskia.fr");
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Process.Start("task_force_radio.ts3_plugin");
        }

        public class User
        {
            public string name { get; set; }
            public string path { get; set; }
            public bool ischecked { get; set; }
        }

        private void saveSettings()
        {
            user.name = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            user.path = path;
            if (rdexist.Checked)
            {
                user.ischecked = true;
            }

            File.WriteAllText(dir + FileName, JsonConvert.SerializeObject(user));
        }

        private void loadSettings()
        {
            user = JsonConvert.DeserializeObject<User>(File.ReadAllText(dir + FileName));
            path = user.path;
            if(user.ischecked == true)
            {
                rdexist.Checked = true;
            }
        }

    }
}
