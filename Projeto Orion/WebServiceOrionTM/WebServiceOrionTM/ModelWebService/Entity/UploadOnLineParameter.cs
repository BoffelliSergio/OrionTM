using System;

namespace WebServicesOrionTM.ModelWebService.Entity
{
    [Serializable()]
    public class UploadOnLineParameter 
    {
        private int prSequence;
        private string prStatus;
        private string prFileName;
        private string prFilePath;
        private string prFileType;
        private string prFileDate;
        private string prFileMask;
        private string prFileByType;
        public UploadOnLineParameter()
        {
        }

        public UploadOnLineParameter(int paSequence, string paStatus)
        {
            this.Sequence = paSequence;
            this.Status = paStatus;
        }

        public int Sequence
        {
            get
            {
                return prSequence;
            }
            set
            {
                prSequence = value;
            }
        }

        public string Status
        {
            get
            {
                return prStatus;
            }
            set
            {
                prStatus = value;
            }
        }

        public string FileName
        {
            get
            {
                return prFileName;
            }
            set
            {
                prFileName = value;
            }
        }

        public string FilePath
        {
            get
            {
                return prFilePath;
            }
            set
            {
                prFilePath = value;
            }
        }

        public string FileType
        {
            get
            {
                return prFileType;
            }
            set
            {
                prFileType = value;
            }
        }

        public string FileDate
        {
            get
            {
                return prFileDate;
            }
            set
            {
                prFileDate = value;
            }
        }

        public string FileMask
        {
            get
            {
                return prFileMask;
            }
            set
            {
                prFileMask = value;
            }
        }

        public string FileByType
        {
            get
            {
                return prFileByType;
            }
            set
            {
                prFileByType = value;
            }
        }
    }
}




