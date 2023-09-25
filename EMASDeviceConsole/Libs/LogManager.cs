using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
namespace EMASDeviceConsole.Libs
{

    public class LogManager
    {
        private int _Row = 1000;
        private Color _InfoColor = System.Drawing.Color.White;
        private Color _WarningColor = System.Drawing.Color.Khaki;
        private Color _ErrorColor = System.Drawing.Color.LightCoral;





        public LogManager()
        {

        }
        public enum LogType
        {
            INFORMATION,
            WARNING,
            ERROR,
            UNKNOWN
        };

        private static string LogTypeString(LogType type)
        {

            switch (type)
            {
                case LogType.ERROR:
                    return "Error";
                case LogType.INFORMATION:
                    return "Information";
                case LogType.UNKNOWN:
                    return "Unknown";
                case LogType.WARNING:
                    return "Warning";
                default:
                    return "Unknown";

            }
        }

        public Color InFoColor
        {
            get { return _InfoColor; }
        }

        public Color WarningColor
        {
            get { return _WarningColor; }
        }

        public Color ErrorColor
        {
            get { return _ErrorColor; }
        }

        public int RowSize
        {
            get { return _Row; }
            set { _Row = value; }
        }

        public string LogFile
        {
            get
            {
                return LogFolder + "\\" + getlogName();

            }
        }

        public string LogFolder
        {
            get
            {

                string log = AppSettings.Read("Log_Folder");
                if (string.IsNullOrEmpty(log))
                    log = Environment.CurrentDirectory;

                return log;
            }
        }

        public bool IsLogging
        {
            get
            {
                return Convert.ToBoolean(AppSettings.Read("logging"));
            }
        }
        public static string getlogName()
        {
            return DateTime.Now.Year + "" + fix(DateTime.Now.Month) + "" + fix(DateTime.Now.Day) + ".log";

        }

        private static string fix(int val)
        {
            if (val.ToString().Length < 2)
                return "0" + val;
            else
                return val.ToString();
        }

        public int getImageID(string type)
        {
            if (type.ToLower().Trim() == "warning")
            {
                return 0;
            }
            else if (type.ToLower().Trim() == "information")
            {

                return 1;
            }
            else
            {

                return 2;
            }
        }

        public void setBackColor(ListViewItem lst, string type)
        {
            if (type.ToLower().Trim() == "warning")
            {
                lst.BackColor = WarningColor;
            }
            else if (type.ToLower().Trim() == "information")
            {

                lst.BackColor = InFoColor;
            }
            else
            {

                lst.BackColor = ErrorColor;
            }

        }

        public Color getBackColor(string type)
        {
            if (type.ToLower() == "warning")
            {
                return WarningColor;
            }
            else if (type.ToLower() == "information")
            {

                return InFoColor;
            }
            else
            {

                return ErrorColor;
            }

        }

        public static void CreateLogFile()
        {
            if (File.Exists(new LogManager().LogFile))
                return;
            else
            {
                if (!Directory.Exists(new LogManager().LogFolder))
                    Directory.CreateDirectory(new LogManager().LogFolder);

                File.Create(new LogManager().LogFile).Close();
            }
        }

        public static void Writelog(string type, string Message, bool SectionBreak)
        {
            if (!new LogManager().IsLogging)
                return;

            CreateLogFile();
            Message = Message.Replace("\n", "").Replace("\r", "");
            try
            {
                using (FileStream log = new FileStream(new LogManager().LogFile, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
                {
                    using (StreamWriter streamWriter = new StreamWriter(log))
                    {

                        if (!SectionBreak)
                            streamWriter.WriteLine(DateTime.Now + " (" + DateTime.Now.Millisecond + ") | " + type + " | " + Message);
                        else
                        {
                            streamWriter.WriteLine("______________________________________________________________________________________________________________");
                            streamWriter.WriteLine(DateTime.Now + " (" + DateTime.Now.Millisecond + ") | " + type + " | " + Message);
                            // logwriter.WriteLine("______________________________________________________________________________________________________________");
                        }

                    }


                }
            }
            catch { }
        }

        public static void Log(string Message)
        {
            Writelog("Information", Message, false);

        }

        public static void Log(string Message, string type)
        {
            Writelog(type, Message, false);

        }
        public static void Log(string Message, LogType type)
        {
            Writelog(LogTypeString(type), Message, false);

        }
        public static void Log(string Message, bool sectionBreak)
        {
            Writelog("Information", Message, sectionBreak);

        }
        public static void Log(string Message, string type, bool sectionBreak)
        {
            Writelog(type, Message, sectionBreak);
        }
        public static void Log(string Message, LogType type, bool sectionBreak)
        {
            Writelog(LogTypeString(type), Message, sectionBreak);
        }

    }
}
