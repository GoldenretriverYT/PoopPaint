using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SkiaSharp;
using SkiaSharp.Views.Desktop;

namespace PoopPaint
{
    public partial class Form1 : Form
    {

        public Tool selectedTool;
        public static SKBitmap bmp;
        public static SKCanvas canvas;

        public static SKBitmap bmpOverlay;
        public static SKCanvas canvasOverlay;

        public static SKPoint mousePos;
        public static SKColor color;

        public static Random rng = new Random();

        public static Dictionary<int, Control> settingControls = new Dictionary<int, Control>();

        public Form1()
        {
            InitializeComponent();

            mainLayerBox.Controls.Add(overlayBox);
            overlayBox.Location = new Point(0, 0);
            overlayBox.BackColor = Color.Transparent;

            bmp = new SKBitmap(mainLayerBox.Size.Width, mainLayerBox.Size.Height);
            canvas = new SKCanvas(bmp);

            bmpOverlay = new SKBitmap(overlayBox.Size.Width, mainLayerBox.Size.Height, false);
            canvasOverlay = new SKCanvas(bmp);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            mainLayerBox.Image = bmp.ToBitmap();
            overlayBox.Image = bmpOverlay.ToBitmap();
            mousePos = new SKPoint(mainLayerBox.PointToClient(Cursor.Position).X, mainLayerBox.PointToClient(Cursor.Position).Y);
            color = new SKColor(colorDialog1.Color.R, colorDialog1.Color.G, colorDialog1.Color.B, colorDialog1.Color.A);
            colorPanel.BackColor = colorDialog1.Color;

            if (selectedTool == null) return;
            selectedTool.Update();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            selectedTool = new PenTool();
            UpdateSelectedTool();
        }

        private void UpdateSelectedTool()
        {
            toolStripStatusLabel1.Text = "Selected Tool: " + selectedTool.ToolName;
            UpdateSettings();
        }

        private void UpdateSettings()
        {
            toolGroupBoxes.Controls.Clear();
            settingControls.Clear();

            int xOff = 10;
            foreach(KeyValuePair<string, ToolSetting> setting in selectedTool.PublicSettings)
            {
                Control ctrl = setting.Value.AddControl(toolGroupBoxes);
                settingControls.Add(setting.Value.ptr, ctrl);

                Label lbl = new Label();
                toolGroupBoxes.Controls.Add(lbl);

                lbl.Text = setting.Key;
                lbl.Location = new Point(xOff, 17);
                
                ctrl.Location = new Point(xOff, 34);

                xOff += ctrl.Width + 10;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (selectedTool == null)
            {
                MessageBox.Show("Please select a tool first");
                return;
            }

            selectedTool.StartUsing();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (selectedTool == null)
            {
                MessageBox.Show("Please select a tool first");
                return;
            }

            selectedTool.StopUsing();
        }

        private void overlayBox_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox1_MouseDown(sender, e);
        }

        private void overlayBox_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox1_MouseUp(sender, e);
        }

        private void overlayBox_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
        }
    }
}
