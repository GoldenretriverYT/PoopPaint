using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoopPaint
{
    public class PoopCursor
    {
        private static bool _CursorShown = true;
        public static bool CursorShown
        {
            get
            {
                return _CursorShown;
            }
            set
            {
                if (value == _CursorShown)
                {
                    return;
                }

                if (value)
                {
                    System.Windows.Forms.Cursor.Show();
                }
                else
                {
                    System.Windows.Forms.Cursor.Hide();
                }

                _CursorShown = value;
            }
        }
    }
}
