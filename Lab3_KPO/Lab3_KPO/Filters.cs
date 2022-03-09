using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Lab3_KPO
{
    class Filters
    {
		List<Filter> filters = new List<Filter>();
		FlowLayoutPanel panel;
		int selectedButton;

		private Button CreateButtonByFilter(Filter filter, int index)
        {
			Button newButton = new Button();
			newButton.Height = 30;
			newButton.Width = 200;
			newButton.Name = filter.Name;
			newButton.Text = filter.Name;
			newButton.Tag = index;
			newButton.Click += ChooseFilter;

			return newButton;
		}

		public Filters(FlowLayoutPanel panel)
		{
			this.panel = panel;
			Filter newFilter;
			newFilter = new Filter("Без фильтра", (byte[] array, int length) => array);
			filters.Add(newFilter);

			panel.Controls.Add(CreateButtonByFilter(newFilter, 0));
			selectedButton = 0;

			int i = 1;
			string[] allfiles = Directory.GetFiles("Plugins//", "*.dll");
			foreach (string filename in allfiles)
			{
				newFilter = new Filter(filename);
				if (newFilter.Name != null)
				{
					filters.Add(newFilter);
					panel.Controls.Add(CreateButtonByFilter(newFilter, i));
					i++;
				}
			}
		}

		public void ChooseFilter(object sender, EventArgs e)
        {
			selectedButton = (int)((Button)sender).Tag;
        }

		public byte[] ApplyFilter(byte[] array)
		{
			return filters[selectedButton].filterFunc(array, array.Length);
		}
	}
}
