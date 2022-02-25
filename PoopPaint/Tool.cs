using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoopPaint
{
    public abstract class Tool
    {
        public abstract string ToolName { get; }
        public abstract string ToolDescription { get; }
        public abstract Dictionary<string, ToolSetting> PublicSettings { get; }
        public abstract void StartUsing();
        public abstract void StopUsing();
        public abstract void Update();
        public abstract void UpdateOverlay();
    }
}
