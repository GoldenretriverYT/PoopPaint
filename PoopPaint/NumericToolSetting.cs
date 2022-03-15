using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PoopPaint
{
    public class NumericToolSetting : ToolSetting
    {
        public decimal min = 0;
        public decimal max = 100;
        public decimal defaultValue = 5;

        public override int ptr { get => _ptr; }
        private int _ptr = 0;

        private NumericUpDown numericUpDown;

        public NumericToolSetting(decimal min, decimal max, decimal defaultValue)
        {
            Console.WriteLine("new nts instance");

            this._ptr = Form1.rng.Next(Int32.MaxValue);
            this.min = min;
            this.max = max;
            this.defaultValue = defaultValue;

            this.numericUpDown = new NumericUpDown
            {
                Size = new System.Drawing.Size(100, 30),
                Minimum = min,
                Maximum = max,
                Value = defaultValue,
            };
        }

        public override Control AddControl(GroupBox gp)
        {
            gp.Controls.Add(numericUpDown);
            return numericUpDown;
        }

        public override object GetValue()
        {
            if(!(Form1.settingControls.ContainsKey(_ptr)))
            {
                Console.WriteLine(_ptr);
                MessageBox.Show("Unable to find setting, please reselect tool.");
                return null;
            }
            return ((NumericUpDown)Form1.settingControls[_ptr]).Value;
        }
    }
}
