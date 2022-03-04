using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SkiaSharp;
using System.Threading.Tasks;

namespace PoopPaint
{
    public class PenTool : Tool
    {
        public bool isBeingUsed = false;
        public SKPoint previousPos;
        public SKPaint skPaint = new SKPaint();
        public SKPaint skPaintOverlay = new SKPaint();

        public override string ToolName => "Pen";

        public override string ToolDescription => "Pen draws simple dot";

        public override Dictionary<string, ToolSetting> PublicSettings => settings;

        private Dictionary<string, ToolSetting> settings = new Dictionary<string, ToolSetting>
        {
            {"size", new NumericToolSetting(1, 250, (int)GlobalStore.Get("size", 5)) }
        };

        public PenTool()
        {
            skPaintOverlay.Color = new SKColor(0, 0, 0);
            skPaintOverlay.Style = SKPaintStyle.Stroke;
            skPaintOverlay.StrokeWidth = 2;
        }

        public override void StartUsing()
        {
            isBeingUsed = true;
            previousPos = new SKPoint(-1, -1);
        }

        public override void StopUsing()
        {
            isBeingUsed = false;
        }

        public override void Update()
        {
            GlobalStore.Set("size", Decimal.ToInt32((decimal)settings["size"].GetValue()));

            if (!isBeingUsed) return;

            if (previousPos != null && previousPos.X != -1)
            {
                skPaint.Color = Form1.color;
                Line line = new Line(previousPos, Form1.mousePos);
                SKPoint[] points = line.GetPoints(Math.Max(2, (int)SKPoint.Distance(line.p1, line.p2)));

                foreach(SKPoint point in points) {
                    Form1.canvas.DrawCircle(point, Decimal.ToInt32((decimal)settings["size"].GetValue()), skPaint);
                }
            }
            else {
                Form1.canvas.DrawCircle(Form1.mousePos, Decimal.ToInt32((decimal)settings["size"].GetValue()), skPaint);
            }

            previousPos = Form1.mousePos;
        }

        public override void UpdateOverlay()
        {
            Form1.canvasOverlay.DrawCircle(Form1.mousePos, Decimal.ToInt32((decimal)settings["size"].GetValue()), skPaintOverlay);
        }
    }
}
