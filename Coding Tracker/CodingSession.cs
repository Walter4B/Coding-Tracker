using System;

namespace Coding_Tracker
{
	internal class CodingSession
	{
		private int id;
		public int Id
		{
			get { return id; }
			set { id = value; }
		}

		private string startTime;
		public string StartTime
		{
			get { return startTime; }
			set { startTime = value; }
		}

		private string endTime;
		public string EndTime
		{
			get { return endTime; }
			set { endTime = value; }
		}

		private string duration;
		public string Duration
		{
			get { return duration; }
			set { duration = value; }
		}
}

}