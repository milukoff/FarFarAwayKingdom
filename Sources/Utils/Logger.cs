using System;
using System.Text;
using System.IO;
using System.Globalization;
using System.Diagnostics;

namespace Utils
{
    public class Logger
    {
        private static string MainlogFileName 
        {
            get
            {
                return (Path.GetFileNameWithoutExtension(Process.GetCurrentProcess().MainModule.FileName.ToString())+".log");
            }
        }
        
        private static string log = "Log";

        public static string BaseDirectory
        {
            get
            {
                return System.AppDomain.CurrentDomain.BaseDirectory;
            }
        }

        private static string LogDirectory
        {
            get
            {
                if (log == "") log = "Log";
                return Path.Combine(BaseDirectory,log);
            }
        }

        private static bool ExistCreateLogDirectory (string _LogDirectory)
        {
            bool _exist = false;
            if (!Directory.Exists(_LogDirectory))
            {
                try
                {
                    Directory.CreateDirectory(_LogDirectory);
                }
                catch (Exception ex)
                {
                    Logger.AppendLineToLog("!!! Error in time creation directory " + ex.ToString());
                }
                finally
                {
                    if (!Directory.Exists(_LogDirectory)) Logger.AppendLineToLog("!!LOG directory not exists and can'nt be create");
                    else _exist = true;
                }
            }
            else _exist = true;
            return _exist;
        }

        private static string LogFullFileName
        {
            get
            {
                if (ExistCreateLogDirectory(Logger.LogDirectory)) return Path.Combine(Logger.LogDirectory, Logger.MainlogFileName);
                else return Path.Combine(Logger.BaseDirectory,Logger.MainlogFileName);
            }
        }

        static public void AppendLineToLog(string line)
        {
            AppendLineToLog(line, Logger.LogFullFileName);
        }
        
        static public void AppendLineToLog(string line, string filename)
        {
            if (line == "") line = ".";

            try
            {
                FileStream fs = new FileStream(filename, FileMode.Append);
                StreamWriter sw = new StreamWriter(fs, Encoding.GetEncoding(1251));
                if (line != "")
                    sw.WriteLine(DateTime.Now.ToString() + " " + line);
                else
                    sw.WriteLine("");
                sw.Flush();
                sw.Close();
                fs.Close();
            }
            catch
            {
            }
        }

        static private void renameOldLogFile(string filename)//Если дата изменения (или создания) файла менее текущей даты, то переименовываем файл по дате создания (изменения)
        {
            DateTime dtLastAccess = new FileInfo(filename).LastWriteTime.Date;
            if (new FileInfo(filename).CreationTime.Date < dtLastAccess) dtLastAccess = new FileInfo(filename).CreationTime.Date;
            DateTime dtNow = DateTime.Now.Date;
            if (dtNow > dtLastAccess)
            {
                try
                {
                    string _Path = Path.GetDirectoryName(filename);
                    string _FileNameWithDateWithoutExtension = Path.GetFileNameWithoutExtension(filename) + "_" + (dtLastAccess.Day < 10 ? "0" : "") + dtLastAccess.Day.ToString() + (dtLastAccess.Month < 10 ? "0" : "") + dtLastAccess.Month.ToString() + dtLastAccess.Year;
                    string _FileNameWithDateWithExtension = _FileNameWithDateWithoutExtension + ".log";
                    string _ZipFileName = _FileNameWithDateWithoutExtension + ".zip";
                    File.Move(filename, Path.Combine(_Path, _FileNameWithDateWithExtension));
                    FS.CompressFile(Path.Combine(_Path,_FileNameWithDateWithExtension),Path.Combine(_Path,_ZipFileName));
                    File.Delete(Path.Combine(_Path, _FileNameWithDateWithExtension));
                }
                catch (Exception ex)
                {
                //
                }
            }
        }
        
        static public void DeleteOldLog ()
        {
            var today = DateTime.Today;
            var dir = new DirectoryInfo(BaseDirectory);
            foreach (var file in dir.GetFiles())
            {
                DateTime fileDate;
                if (DateTime.TryParseExact(file.Name, "dd.MM.yyyy", null, DateTimeStyles.AssumeLocal, out fileDate) && (today - fileDate).Days > 5)
                    file.Delete();
            }
            renameOldLogFile (Path.Combine(LogDirectory,MainlogFileName));
        }
    }   
}
