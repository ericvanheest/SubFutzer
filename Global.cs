using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SubFutzer
{
	/// <summary>
	/// Summary description for Global.
	/// </summary>
	public static class Global
	{
        public static Control GetActiveControl(ContainerControl container)
        {
            Control ctrl = container.ActiveControl;
            while (ctrl is ContainerControl && ctrl.HasChildren)
                ctrl = ((ContainerControl) ctrl).ActiveControl;

            return ctrl;
        }

		public static string GetVersion()
		{
			return System.Diagnostics.Process.GetCurrentProcess().MainModule.FileVersionInfo.ProductVersion;
		}

        public static TimeSpan TimeSpanFromString(string str)
        {
            str = Regex.Replace(str, "[^0-9:.]", "");   // Remove trash characters

            int iHours, iMinutes, iSeconds, iMilliseconds;
            string strRaw = GetRawTimeValues(str, out iHours, out iMinutes, out iSeconds, out iMilliseconds);
            NormalizeTimeValues(ref iHours, ref iMinutes, ref iSeconds, ref iMilliseconds);
            return new TimeSpan(0, iHours, iMinutes, iSeconds, iMilliseconds);
        }

        public static void NormalizeTimeValues(ref int iHours, ref int iMinutes, ref int iSeconds, ref int iMilliseconds)
        {
            if (iMilliseconds > 999)
            {
                iSeconds += iMilliseconds / 1000;
                iMilliseconds %= 1000;
            }
            if (iSeconds > 59)
            {
                iMinutes += iSeconds / 60;
                iSeconds %= 60;
            }
            if (iMinutes > 59)
            {
                iHours += iMinutes / 60;
                iMinutes %= 60;
            }
            if (iHours > 99)
            {
                iHours = 99;
            }
        }

        public static string NormalizeTimeString(string str)
        {
            int iSeconds, iMinutes, iHours, iMilliseconds;
            string strRaw = GetRawTimeValues(str, out iHours, out iMinutes, out iSeconds, out iMilliseconds);
            NormalizeTimeValues(ref iHours, ref iMinutes, ref iSeconds, ref iMilliseconds);
            return iHours.ToString("00") + ":" + iMinutes.ToString("00") + ":" + iSeconds.ToString("00") + "." + iMilliseconds.ToString("000");
        }

        public static string GetRawTimeValues(string strText, out int iHours, out int iMinutes, out int iSeconds, out int iMilliseconds)
        {
            int iIndex = 0;
            iMinutes = 0;
            iSeconds = 0;
            iMilliseconds = 0;

            strText = strText.Replace(",", ".");

            if (strText.StartsWith("."))
                strText = "0" + strText;

            if (strText.IndexOf(".") == -1)
                strText += ".";

            strText += "000";

            int iDot = strText.IndexOf(".");
            strText = strText.Substring(0, iDot + 4);

            int iColon = strText.IndexOf(":");
            if (iColon == -1)
            {
                strText = "00:" + strText;
                iColon = 2;
            }

            iColon = strText.IndexOf(":", iColon + 1);
            if (iColon == -1)
            {
                strText = "00:" + strText;
            }

            iHours = GetNumber(strText, ref iIndex);
            FindNextDigit(strText, ref iIndex);
            iMinutes = GetNumber(strText, ref iIndex);
            FindNextDigit(strText, ref iIndex);
            iSeconds = GetNumber(strText, ref iIndex);
            FindNextDigit(strText, ref iIndex);
            iMilliseconds = GetNumber(strText, ref iIndex);

            return strText;
        }

        public static int GetNumber(string str, ref int iIndex)
        {
            int iStart = iIndex;
            if ((iStart >= str.Length) || (iStart < 0))
            {
                iIndex = -1;
                return 0;
            }

            if (!Char.IsDigit(str[iStart]))
            {
                return 0;
            }

            while (iIndex < str.Length)
            {
                if (!Char.IsDigit(str[iIndex]))
                    break;
                iIndex++;
            }

            return Convert.ToInt32(str.Substring(iStart, iIndex - iStart));
        }

        public static char FindNextDigit(string str, ref int iIndex)
        {
            if (iIndex < 0)
                return '\0';

            while (iIndex < str.Length)
            {
                if (Char.IsDigit(str[iIndex]))
                    break;
                iIndex++;
            }

            if (iIndex >= str.Length)
                iIndex = -1;

            if (iIndex > 0)
                return str[iIndex-1];

            return '\0';
        }    
    }

    public class LVICollection
    {
        ListView.SelectedListViewItemCollection m_slvic = null;
        ListView.ListViewItemCollection m_lvic = null;

        public LVICollection(ListView.ListViewItemCollection lvic)
        {
            m_lvic = lvic;
        }

        public LVICollection(ListView.SelectedListViewItemCollection slvic)
        {
            m_slvic = slvic;
        }

        public int Count
        {
            get
            {
                if (m_lvic == null)
                    return m_slvic.Count;

                return m_lvic.Count;
            }

        }

        public ListViewItem this [int index]   // indexer declaration
        {
            get 
            {
                // Check the index limits
                if (index < 0 || index >= Count)
                    return null;
                else
                {
                    if (m_lvic == null)
                        return m_slvic[index];
                    return m_lvic[index];
                }
            }
        }
    }
}
