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

		private DateTime startTime;
		public DateTime StartTime
		{
			get { return startTime; }
			set { startTime = value; }
		}

		private DateTime endTime;
		public DateTime EndTime
		{
			get { return endTime; }
			set { endTime = value; }
		}

		private TimeSpan duration;
		public TimeSpan Duration
		{
			get { return duration; }
			set { duration = value; }
		}
	}

}