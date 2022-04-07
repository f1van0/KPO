using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_image_preview
{
    struct DBRow
	{
		//команда
		public string Command;

		//контекст команды
		public string Context;

		//длительность действия
		public int ProceedTime;

		//дата и время произошедшего действия
		public DateTime Date;


		public DBRow(string command, string context, TimeSpan time)
		{
			Command = command;
			Context = context;
			ProceedTime = (int)time.TotalMilliseconds;
			Date = DateTime.Now;
		}

		public override string ToString()
		{
			return $"[{Date}] {Command} - {Context}: {ProceedTime} мс.";
		}
	}
}
