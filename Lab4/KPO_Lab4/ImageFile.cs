﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace KPO_Lab4
{
	struct ImageFile
	{
		public Bitmap Image;
		public string Name;
		public TimeSpan ProceedTime;
		public int FilteringWorkerID;
		public int ResizingWorkerID;


		public ImageFile (Bitmap img, string name, int filteringWorkerID, int resizingWorkerID)
		{
			Image = img;
			Name = name + ".bmp";
			ProceedTime = new TimeSpan(0);
			foreach ( var c in Path.GetInvalidFileNameChars() )
				Name = Name.Replace(c, '_');

			FilteringWorkerID = filteringWorkerID;
			ResizingWorkerID = resizingWorkerID;
		}

		public void Save (string path)
		{
			string fullPath = Path.Combine(path, Name);
			fullPath = fullPath.Replace(" ", @" ");
			Image.Save(fullPath, ImageFormat.Bmp);
		}
	}
}
