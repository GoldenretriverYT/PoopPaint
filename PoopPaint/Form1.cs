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

            ResetCanvas();
        }

        public void ResetCanvas()
        {
            bmp = new SKBitmap(mainLayerBox.Size.Width, mainLayerBox.Size.Height);
            canvas = new SKCanvas(bmp);

            bmpOverlay = new SKBitmap(overlayBox.Size.Width, mainLayerBox.Size.Height, false);
            canvasOverlay = new SKCanvas(bmpOverlay);
        }

        public void ResizeCanvas()
        {
            SKBitmap oldBmp = bmp;
            bmp = new SKBitmap(mainLayerBox.Size.Width, mainLayerBox.Size.Height);
            oldBmp.ScalePixels(bmp, SKFilterQuality.High);
            canvas = new SKCanvas(bmp);

            bmpOverlay = new SKBitmap(overlayBox.Size.Width, mainLayerBox.Size.Height, false);
            canvasOverlay = new SKCanvas(bmpOverlay);
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

            Form1.canvasOverlay.Clear(new SKColor(255, 255, 255, 0));

            if (selectedTool == null) return;
            selectedTool.UpdateOverlay();
            selectedTool.Update();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            selectedTool = new PenTool();
            UpdateSelectedTool();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            selectedTool = new EraserTool();
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

        private void DrawingZoneMouseEnter(object sender, EventArgs e)
        {
            Console.WriteLine("Mouse enter");
            if (selectedTool != null)
            {
                Console.WriteLine("Hide mouse");
                PoopCursor.CursorShown = false;
            }
        }

        private void DrawingZoneMouseLeave(object sender, EventArgs e)
        {
            PoopCursor.CursorShown = true;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void createNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetCanvas();
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            SKBitmap.Decode(openFileDialog1.OpenFile()).ScalePixels(bmp, SKFilterQuality.High);
        }

        private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            if (saveFileDialog1.FileName.EndsWith(".bmp"))
            {
                bmp.ToBitmap().Save(saveFileDialog1.FileName);
            }
            else if(saveFileDialog1.FileName.EndsWith(".png"))
            {
                bmp.Encode(SKEncodedImageFormat.Png, 100).SaveTo(saveFileDialog1.OpenFile());
            }
            else if(saveFileDialog1.FileName.EndsWith(".jpg") || saveFileDialog1.FileName.EndsWith(".jpeg"))
            {
                bmp.Encode(SKEncodedImageFormat.Jpeg, 100).SaveTo(saveFileDialog1.OpenFile());
            }
        }

        private void mainLayerBox_SizeChanged(object sender, EventArgs e)
        {
            overlayBox.Size = mainLayerBox.Size;
            ResizeCanvas();
        }
    }
}
