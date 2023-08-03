using System;
using System.IO;
using System.Windows.Forms;

namespace SubFutzer
{
	/// <summary>
	/// Summary description for CommandProcessor.
	/// </summary>
	public class CommandProcessor
	{
        StreamReader m_reader = null;
        SubFutzerForm m_form = null;

		public CommandProcessor(SubFutzerForm sff)
		{
            m_form = sff;
		}

        public bool SetFile(string sFile)
        {
            if (!File.Exists(sFile))
                return false;

            m_reader = new StreamReader(sFile);

            string sDirectory = Path.GetDirectoryName(sFile);
            if (sDirectory != "")
                Environment.CurrentDirectory = sDirectory;

            return true;
        }

        public void Run()
        {
            if (m_reader == null)
                return;

            string sLine;

            while (m_reader.Peek() != -1)
            {
                sLine = m_reader.ReadLine();
                if (!ProcessLine(sLine))
                    break;
            }
        }

        private bool ProcessLine(string sLine)
        {
            string sCommand;
            string sArgs = "";
            string[] args;

            int iCommand = sLine.IndexOf(' ');
            if (iCommand == -1)
            {
                sCommand = sLine;
            }
            else
            {
                sCommand = sLine.Substring(0, iCommand);
                sArgs = sLine.Substring(iCommand + 1);
            }

            sCommand = sCommand.ToLower();

            switch(sCommand)
            {
                case "close":
                    m_form.ClearCurrentFile();
                    break;
                case "open":
                    m_form.ClearCurrentFile();
                    if (!m_form.ReadSubtitleFile(sArgs))
                        return false;
                    break;
                case "merge":
                    m_form.MergeSubtitleFile(sArgs);
                    break;
                case "save":
                    if (sArgs == "")
                    {
                        m_form.SaveFile(false);
                    }
                    else
                    {
                        m_form.SaveFile(sArgs, false);
                    }
                    break;
                case "quit":
                    Environment.Exit(0);
                    break;
                case "jobs":
                    m_form.ProcessJobs(sArgs);
                    break;
                case "shiftback":
                    m_form.OffsetSubtitles(-Global.TimeSpanFromString(sArgs));
                    break;
                case "shiftfwd":
                    m_form.OffsetSubtitles(Global.TimeSpanFromString(sArgs));
                    break;
                case "setfirst":
                    m_form.SetFirstItem(Global.TimeSpanFromString(sArgs));
                    break;
                case "expandlast":
                    m_form.ExpandLastItem(Global.TimeSpanFromString(sArgs));
                    break;
                case "expandby":
                    m_form.ExpandSubtitles(Global.TimeSpanFromString(sArgs));
                    break;
                case "contractby":
                    m_form.ExpandSubtitles(-Global.TimeSpanFromString(sArgs));
                    break;
                case "lengthenby":
                    m_form.ChangeDuration(Global.TimeSpanFromString(sArgs));
                    break;
                case "shortenby":
                    m_form.ChangeDuration(-Global.TimeSpanFromString(sArgs));
                    break;
                case "extract":
                    args = sArgs.Split(new char[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    if (args.Length > 1)
                        m_form.DeleteRange(Global.TimeSpanFromString(args[0]), Global.TimeSpanFromString(args[1]), true);
                    else
                        m_form.ExtractByFile(args[0]);
                    break;
                default:
                    MessageBox.Show("Unknown command: " + sCommand, "Unknown command", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;

            }
            return true;
        }
	}
}
