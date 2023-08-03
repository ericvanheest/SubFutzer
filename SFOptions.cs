using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Text;
using System.Collections;
using Microsoft.Win32;
using System.Collections.Generic;

namespace SubFutzer
{
	/// <summary>
	/// Summary description for SFOptions.
	/// </summary>
	public class SFOptions
	{
        public string sVDJobsFile;
        public string sSubOutFormat;
        public int iLineLength;
        public bool bStripLanguage;
        public List<string> m_listMRU = new List<string>(10);

        public SFOptions()
        {
            sVDJobsFile = @"D:\Program Files\VirtualDub\VirtualDub.jobs";
            sSubOutFormat = "%N-ENG.srt";
            iLineLength = 50;
            bStripLanguage = true;
            ReadFromRegistry();
        }

        public void WriteToRegistry()
        {
            try
            {
                RegistryKey rk = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\\EDV Software\\SubFutzer");
                if (rk != null)
                {
                    rk.SetValue("VDJobsFile", sVDJobsFile);
                    rk.SetValue("LineLength", iLineLength.ToString());
                    rk.SetValue("SubOutFormat", sSubOutFormat);
                    rk.SetValue("StripLanguage", bStripLanguage ? 1 : 0);
                    if (m_listMRU != null)
                        rk.SetValue("MRUList", m_listMRU.ToArray());
                }
            }
            catch
            {
            }
        }

        public void ReadFromRegistry()
        {
            try
            {
                RegistryKey rk = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\\EDV Software\\SubFutzer");
                if (rk != null)
                {
                    sVDJobsFile = rk.GetValue("VDJobsFile", @"D:\Program Files\VirtualDub\VirtualDub.jobs").ToString();
                    sSubOutFormat = rk.GetValue("SubOutFormat", @"%N-ENG.srt").ToString();
                    iLineLength = Convert.ToInt32(rk.GetValue("LineLength", "50").ToString());
                    bStripLanguage = Convert.ToBoolean(rk.GetValue("StripLanguage", true));
                    m_listMRU.Clear();
                    foreach(string sFile in (string[]) rk.GetValue("MRUList", null))
                        m_listMRU.Add(sFile);
                }
            }
            catch
            {
            }
        }
    }
}
