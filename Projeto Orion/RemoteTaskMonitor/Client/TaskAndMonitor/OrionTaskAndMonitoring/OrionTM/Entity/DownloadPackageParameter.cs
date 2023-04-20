using System;


namespace OrionTMClient.Entity
{
    [Serializable()]
    public class DownloadPackageParameter
    {
        private int prSequence;
        private string prStatus;
        private string prFileNamePackage;
        private string prInstalationDateHour;

        public DownloadPackageParameter()
        {
        }
        public DownloadPackageParameter(int paSequence, string paStatus)
        {
            this.Sequence = paSequence;
            this.Status = paStatus;
            this.FileNamePackage = string.Empty;
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

        public string FileNamePackage
        {
            get
            {
                return prFileNamePackage;
            }
            set
            {
                prFileNamePackage = value;
            }
        }

        public string InstalationDateHour
        {
            get
            {
                return prInstalationDateHour;
            }
            set
            {
                prInstalationDateHour = value;
            }
        }
    }
}



