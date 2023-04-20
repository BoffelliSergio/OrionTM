using System;
using System.IO;
using System.Collections;


namespace OrionTMClient.Infra
{
    public struct FileInfoOrion
    {

        public string fileName;
        public DateTime changeDate;
        public bool range;

    }
    public class FindFileByDate
    {
        private string prfolder;
        private ArrayList readyInfo = new ArrayList();
        public string extensionInfo = "*.txt";
        FileInfo fi;
        private bool bolrange = false;
        private DateTime prChangeDate;

        public FindFileByDate()
        {
            prfolder = "";
        }

        public FindFileByDate(string folderinfo)
        {
            prfolder = folderinfo;
        }
        public FileInfoOrion[] returnFileList(string data, string starthour, string Stophour)
        {
            DateTime startDate = new DateTime(Convert.ToInt32(data.Substring(0, 4)), Convert.ToInt32(data.Substring(4, 2)), Convert.ToInt32(data.Substring(6, 2)), Convert.ToInt32(starthour.Substring(0, 2)), Convert.ToInt32(starthour.Substring(2, 2)), Convert.ToInt32(starthour.Substring(4, 2)));
            DateTime stopDate = new DateTime(Convert.ToInt32(data.Substring(0, 4)), Convert.ToInt32(data.Substring(4, 2)), Convert.ToInt32(data.Substring(6, 2)), Convert.ToInt32(Stophour.Substring(0, 2)), Convert.ToInt32(Stophour.Substring(2, 2)), Convert.ToInt32(Stophour.Substring(4, 2)));
            
            foreach (string fs in Directory.GetFiles(prfolder, extensionInfo))
            {
                string returnInfo = fileName(fs, startDate, stopDate);
                
                if (returnInfo != "")
                {
                    FileInfoOrion temp = new FileInfoOrion();
                    temp.fileName = returnInfo;
                    temp.range = bolrange;
                    temp.changeDate = prChangeDate;
                    readyInfo.Add(temp);
                }

            }

            if (readyInfo.Count > 0)
            {
                FileInfoOrion[] item = new FileInfoOrion[readyInfo.Count];

                for (int i = 0; i < readyInfo.Count; i++)
                {
                    item[i] = (FileInfoOrion)readyInfo[i];
                }
                return item;
            }
            else
            {
                FileInfoOrion[] item = new FileInfoOrion[1];
                item[0].fileName = "notfound";
                return item;
            }
        }

        private string fileName(string fileinfo, DateTime startDate, DateTime stopDate)
        {
            fi = new FileInfo(fileinfo);

            if (fi.LastWriteTime >= startDate && fi.LastWriteTime < stopDate)
            {
                prChangeDate = fi.LastWriteTime;
                bolrange = true;
                return fileinfo;
            }
            if (fi.LastWriteTime.ToString("ddMMyyyy") == stopDate.ToString("ddMMyyyy"))
            {

                if (fi.LastWriteTime >= stopDate)
                {
                    if (MinusReturn(fi.LastWriteTime, fi.Name))
                    {
                        return "";
                    }

                    else
                    {
                        prChangeDate = fi.LastWriteTime;
                        bolrange = false;
                        return fileinfo;
                    }
                }
            }
            return "";
        }

        private bool MinusReturn(DateTime datelastwrite, string fileName)
        {
            bool found = false;

            for (int i = 0; i < readyInfo.Count; i++)
            {
                FileInfoOrion tempFileInfo = (FileInfoOrion)readyInfo[i];
                if (!tempFileInfo.range)
                {
                    if (tempFileInfo.changeDate > datelastwrite)
                    {
                        tempFileInfo.fileName = Path.Combine(prfolder, fileName);
                        tempFileInfo.range = false;
                        tempFileInfo.changeDate = datelastwrite;

                        readyInfo[i] = tempFileInfo;
                    }

                    found = true;
                }
            }

            return found;
        }
    }
}

