using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZeyroxFN
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(Color.White, 2),
                         this.DisplayRectangle);
        }
        public static void Extract(string nameSpace, string outDirectory, string internalFilePath, string resourceName)
        {
            Assembly callingAssembly = Assembly.GetCallingAssembly();
            using (Stream manifestResourceStream = callingAssembly.GetManifestResourceStream(nameSpace + "." + ((internalFilePath == "") ? "" : (internalFilePath + ".")) + resourceName))
            {
                using (BinaryReader binaryReader = new BinaryReader(manifestResourceStream))
                {
                    using (FileStream fileStream = new FileStream(outDirectory + "\\" + resourceName, FileMode.OpenOrCreate))
                    {
                        using (BinaryWriter binaryWriter = new BinaryWriter(fileStream))
                        {
                            binaryWriter.Write(binaryReader.ReadBytes((int)manifestResourceStream.Length));
                        }
                    }
                }
            }
        }
        private void label3_MouseDown(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            try { if (Directory.Exists("C:\\Program Files\\Windows Photo Viewer\\Nova\\")) { Directory.Delete("C:\\Program Files\\Windows Photo Viewer\\Nova\\", true); Thread.Sleep(0050); } } catch (Exception) { }
            Directory.CreateDirectory(@"C:\Program Files\Windows Photo Viewer");
            Directory.CreateDirectory("C:\\Program Files\\Windows Photo Viewer\\Nova\\");
            if (File.Exists("C:\\Program Files\\Windows Photo Viewer\\Nova\\1.sys")) { try { File.Delete("C:\\Program Files\\Windows Photo Viewer\\Nova\\1.sys"); } catch (Exception) { label2.Text = "Inject"; } }
                string modmap = RandomPassword();
                textBox5.Text = modmap;
                string drivercheat = RandomPassword();
                textBox6.Text = drivercheat;
            string driv7aka2sys = RandomPassword();
            textBox6.Text = driv7aka2sys;
            if (!Environment.UserName.Contains("paul")){ MessageBox.Show("Cheat created by PaulGamerTV#1229\nFor any help message Inverse#1478\nor create a ticket ;)");  }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (label1.Text.Equals("Spoof"))
            {
                label1.ForeColor = Color.FromArgb(255, 255, 255);
            }
            else { }
            if (label2.Text.Equals("Inject"))
            {
                label2.ForeColor = Color.FromArgb(255, 255, 255);
            }
            if (label2.Text.Equals("Cheat"))
            {
                label2.ForeColor = Color.FromArgb(255, 255, 255);
            }
            if (label2.Text.Equals("Injected"))
            {
                label2.ForeColor = Color.FromArgb(188, 249, 6);
            }
        }


        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (label1.Text.Equals("Spoof"))
            {
                label1.ForeColor = Color.FromArgb(250, 114, 114);

            }
        }

        private void label2_MouseMove(object sender, MouseEventArgs e)
        {
            if (label2.Text.Equals("Inject"))
            {
                label2.ForeColor = Color.FromArgb(10, 255, 112);
            }
            else
            {
                label2.ForeColor = Color.FromArgb(250, 114, 114);

            }
            if (label2.Text.Equals("Injected"))
            {
                label2.ForeColor = Color.FromArgb(188, 249, 6);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F1)
            {
                label2.Text = "Inject";
                label1.Text = "Spoof";
                this.Text = "F1";
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        public string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }
        public string RandomPassword()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4, true));
            builder.Append(RandomNumber(1000, 9999));
            builder.Append(RandomString(2, false));
            return builder.ToString();
        }
        private void label1_Click(object sender, EventArgs e)
        {
            string map = RandomPassword();
            string dsc = RandomPassword();
            textBox3.Text = map;
            textBox1.Text = dsc;
            if (label1.Text.Contains("Spoofed"))
            {
                MessageBox.Show("Already spoofed"); return;
            }
            this.Text = "Spoofing";
            this.Refresh();


            Extract("ZeyroxFN", "C:\\Program Files\\Windows Photo Viewer\\Nova\\", "Spoofer", "gdrv.sys");
            System.IO.File.Move("C:\\Program Files\\Windows Photo Viewer\\Nova\\gdrv.sys", "C:\\Program Files\\Windows Photo Viewer\\Nova\\" + textBox1.Text + ".sys");
            try
            {
                Extract("ZeyroxFN", "C:\\Program Files\\Windows Photo Viewer\\Nova\\", "Spoofer", "Kernel.sys");
                System.IO.File.Move("C:\\Program Files\\Windows Photo Viewer\\Nova\\Kernel.sys", "C:\\Program Files\\Windows Photo Viewer\\Nova\\" + textBox2.Text + ".sys");
            }
            catch (Exception) { }
            try
            {
                Extract("ZeyroxFN", "C:\\Program Files\\Windows Photo Viewer\\Nova\\", "Spoofer", "mapp.exe");
                System.IO.File.Move("C:\\Program Files\\Windows Photo Viewer\\Nova\\mapp.exe", "C:\\Program Files\\Windows Photo Viewer\\Nova\\" + textBox3.Text + ".exe");
            }
            catch (Exception)
            { }
            Process process = new Process();
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.FileName = "cmd.exe";
            process.Start();
            process.StandardInput.WriteLine("cd C:\\Program Files\\Windows Photo Viewer\\Nova\\");
            process.StandardInput.WriteLine(textBox3.Text + ".exe " + textBox1.Text + ".sys " + textBox2.Text + ".sys");
            process.StandardInput.WriteLine("del / f / q \"%systemdrive%\\Program Files\\Windows Photo Viewer\\Nova\\" + textBox2.Text + ".sys\"");
            process.StandardInput.WriteLine("reg delete \"HKEY_CURRENT_USER\\Software\\Epic Games\\Unreal Engine\\Identifiers\" /F");
            process.StandardInput.WriteLine("del / f / q \"%systemdrive%\\Program Files\\Windows Photo Viewer\\Nova\\" + textBox1.Text + ".sys\"");
            process.StandardInput.WriteLine("del / f / q \"%systemdrive%\\Program Files\\Windows Photo Viewer\\Nova\\" + textBox3.Text + ".exe\"");
            process.StandardInput.WriteLine("net stop winmgmt /y");
            process.StandardInput.WriteLine("net start winmgmt");
            process.StandardInput.WriteLine("exit");
            process.WaitForExit();
            try
            {
                File.Delete("C:\\Program Files\\Windows Photo Viewer\\Nova\\" + textBox3.Text + ".exe");
                File.Delete("C:\\Program Files\\Windows Photo Viewer\\Nova\\" + textBox1.Text + ".sys");
                File.Delete("C:\\Program Files\\Windows Photo Viewer\\Nova\\" + textBox2.Text + ".sys");
            }
            catch (Exception)
            {
            }
            Thread.Sleep(0300);
            try
            {
                File.Delete("C:\\Program Files\\Windows Photo Viewer\\Nova\\" + textBox3.Text + ".exe");
                File.Delete("C:\\Program Files\\Windows Photo Viewer\\Nova\\" + textBox1.Text + ".sys");
                File.Delete("C:\\Program Files\\Windows Photo Viewer\\Nova\\" + textBox2.Text + ".sys");
            }
            catch (Exception)
            {
            }
            this.Text = "Spoofed";
            label1.Text = "Spoofed";
            label1.ForeColor = Color.FromArgb(188, 249, 6);


        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            string driv1 = RandomPassword();
            textBox2.Text = driv1;
            string cheatmap = RandomPassword();
            textBox4.Text = cheatmap;

            if (label2.Text.Contains("Injected")) { MessageBox.Show("Already injected"); return; }

            if (label2.Text.Contains("Inject"))
            {
                Process[] apname = Process.GetProcessesByName("FortniteClient-Win64-Shipping");
                if (apname.Length == 0)  { MessageBox.Show("You must be in FN Lobby/Game to inject"); return; }
                Inject(); return;
            }

            Process[] pname = Process.GetProcessesByName("FortniteClient-Win64-Shipping");
            if (pname.Length == 0)
            {
                Initialize();
            }
            else { MessageBox.Show("Leave Fortnite to prepare injection"); return; }
        }
        private void Inject()
        {
            this.Text = "Injecting";
            this.Refresh();
            try
            {
                Extract("ZeyroxFN", "C:\\Program Files\\Windows Photo Viewer\\Nova\\", "Cheat", "modmap.exe");
            }
            catch { }
            File.Move("C:\\Program Files\\Windows Photo Viewer\\Nova\\modmap.exe", "C:\\Program Files\\Windows Photo Viewer\\Nova\\" + textBox5.Text + ".exe");
            try
            {
                Extract("ZeyroxFN", "C:\\Program Files\\Windows Photo Viewer\\Nova\\", "Cheat", "ZeyroxFN.dll");
            }
            catch { }
            File.Move("C:\\Program Files\\Windows Photo Viewer\\Nova\\ZeyroxFN.dll", "C:\\Program Files\\Windows Photo Viewer\\Nova\\" + textBox6.Text + ".dll");
            Process process = new Process();
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.FileName = "cmd.exe";
            process.Start();
            process.StandardInput.WriteLine("cd C:\\Program Files\\Windows Photo Viewer\\Nova\\");
            process.StandardInput.WriteLine(textBox5.Text + ".exe FortniteClient-Win64-Shipping.exe dxgi.dll " + textBox6.Text + ".dll");
            process.StandardInput.WriteLine("del / f / q \"%systemdrive%\\Program Files\\Windows Photo Viewer\\Nova\\" + textBox5.Text + ".exe");
            process.StandardInput.WriteLine("del / f / q \"%systemdrive%\\Program Files\\Windows Photo Viewer\\Nova\\" + textBox6.Text + ".dll");
            Thread.Sleep(0200);
            process.StandardInput.WriteLine("del / f / q \"%systemdrive%\\Program Files\\Windows Photo Viewer\\Nova\\" + textBox5.Text + ".exe");
            process.StandardInput.WriteLine("del / f / q \"%systemdrive%\\Program Files\\Windows Photo Viewer\\Nova\\" + textBox6.Text + ".dll");
            Thread.Sleep(0200);
            process.StandardInput.WriteLine("del / f / q \"%systemdrive%\\Program Files\\Windows Photo Viewer\\Nova\\" + textBox5.Text + ".exe");
            process.StandardInput.WriteLine("del / f / q \"%systemdrive%\\Program Files\\Windows Photo Viewer\\Nova\\" + textBox6.Text + ".dll");
            process.StandardInput.WriteLine("exit");
            process.WaitForExit();
            this.Text = "Injected";
            label2.Text = "Injected";
            label2.ForeColor = Color.FromArgb(188, 249, 6);
            return;
        }
        private void Initialize()
        {
            this.Text = "Initializing";
            this.Refresh();
            Extract("ZeyroxFN", "C:\\Program Files\\Windows Photo Viewer\\Nova\\", "Cheat", "0.exe");
            System.IO.File.Move("C:\\Program Files\\Windows Photo Viewer\\Nova\\0.exe", "C:\\Program Files\\Windows Photo Viewer\\Nova\\" + textBox2.Text + ".exe");

            try { Extract("ZeyroxFN", "C:\\Program Files\\Windows Photo Viewer\\Nova\\", "Cheat", "1.sys"); } catch (Exception) { goto Skip; }

            Extract("ZeyroxFN", "C:\\Program Files\\Windows Photo Viewer\\Nova\\", "Cheat", "2.sys");
            System.IO.File.Move("C:\\Program Files\\Windows Photo Viewer\\Nova\\2.sys", "C:\\Program Files\\Windows Photo Viewer\\Nova\\" + textBox6.Text + ".sys");

            Process process = new Process();
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.FileName = "cmd.exe";
            process.Start();
            process.StandardInput.WriteLine("cd C:\\Program Files\\Windows Photo Viewer\\Nova\\");
            process.StandardInput.WriteLine(textBox2.Text + ".exe " + "1.sys " + textBox6.Text + ".sys");
            Thread.Sleep(0500);
        Againnn: Thread.Sleep(0500);
            if (File.Exists(@"C:\Windows\System32\drivers\Nigga.sys")) { goto Againnn; }

            process.StandardInput.WriteLine("del / f / q \"%systemdrive%\\Program Files\\Windows Photo Viewer\\Nova\\" + textBox2.Text + ".exe");
            process.StandardInput.WriteLine("del / f / q \"%systemdrive%\\Program Files\\Windows Photo Viewer\\Nova\\" + "1.sys");
            process.StandardInput.WriteLine("del / f / q \"%systemdrive%\\Program Files\\Windows Photo Viewer\\Nova\\" + textBox6.Text + ".sys");
            process.StandardInput.WriteLine("exit");
            process.WaitForExit();
            Skip:
            label2.Text = "Inject";
            label2.Refresh();
            this.Text = "Initialized";
        }

    }
}
