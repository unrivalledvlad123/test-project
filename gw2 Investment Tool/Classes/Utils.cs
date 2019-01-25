using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace gw2_Investment_Tool.Classes
{
	public static class Utils
	{
		public static IEnumerable<Control> GetAllControls(Control control, Type type)
		{
			var controls = control.Controls.Cast<Control>();

			return controls.SelectMany(ctrl => GetAllControls(ctrl, type))
				.Concat(controls)
				.Where(c => c.GetType() == type);
		}
		
	}
}
