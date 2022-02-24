using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PoopPaint
{
    public abstract class ToolSetting
    {
        public abstract int ptr { get; }
        public abstract object GetValue();
        public abstract Control AddControl(GroupBox gp);
    }
}
