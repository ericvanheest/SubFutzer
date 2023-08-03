using System;
using System.Drawing;

namespace SubFutzer
{
	/// <summary>
	/// Summary description for Subtitle.
	/// </summary>
    public class Subtitle
    {
        public int Index;
        public DateTime StartTime;
        public DateTime StopTime;
        public string Text;
        public bool Valid;
		public Rectangle rcBound;

        public Subtitle()
        {
            Index = 1;
            Text = "";
            Valid = false;
			rcBound = new Rectangle(0,0,0,0);
		}

        public Subtitle(Subtitle sub)
        {
            Index = sub.Index;
            StartTime = sub.StartTime;
            StopTime = sub.StopTime;
            Text = sub.Text;
            Valid = sub.Valid;
			rcBound = sub.rcBound;
        }

        public void Offset(double ms)
        {
            try
            {
                StartTime = StartTime.AddMilliseconds(ms);
            }
            catch (Exception)
            {
                StartTime = new DateTime(1, 1, 1, 0, 0, 0, 0);
            }
            try
            {
                StopTime = StopTime.AddMilliseconds(ms);
            }
            catch (Exception)
            {
                StopTime = new DateTime(1, 1, 1, 0, 0, 0, 0);
            }
        }

        public Subtitle AddMS(double ms)
        {
            Subtitle newSub = new Subtitle(this);
            newSub.StartTime = StartTime.AddMilliseconds(ms);
            newSub.StopTime = StopTime.AddMilliseconds(ms);
            return newSub;
        }

        public Subtitle SubtractMS(long lMS)
        {
            return AddMS(-lMS);
        }

		public TimeSpan Duration
		{
			get
			{
				return StopTime - StartTime;
			}
			set
			{
				StopTime = StartTime + value;
			}
		}
    }
}
