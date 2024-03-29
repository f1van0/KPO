﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPO_Lab4
	{
	struct DBRow
		{
		public string Name;
		public string Path;
		public DateTime Saved;
		public int FilteringWorkerID;
		public int ResizingWorkerID;
		public int ProceedTime;

		public DBRow (string name, string path, int filteringWorkerID, int resizingWorkerID, TimeSpan time)
			{
			Name = name;
			Path = path;
			Saved = DateTime.Now;
			FilteringWorkerID = filteringWorkerID;
			ResizingWorkerID = resizingWorkerID;
			ProceedTime = (int)time.TotalMilliseconds;
			}

		public override string ToString ()
			{
			return $"{Name} применял фильтр: {FilteringWorkerID} изменял размер:  {ResizingWorkerID} за {ProceedTime} мс";
			}
		}
	}
