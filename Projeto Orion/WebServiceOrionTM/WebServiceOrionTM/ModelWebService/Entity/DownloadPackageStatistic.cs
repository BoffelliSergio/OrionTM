using System;

namespace WebServicesOrionTM.ModelWebService.Entity
{
    [Serializable()]
    public class DownloadPackageStatistic
    {
        private int prSequence;
        private string prStatus;

        public DownloadPackageStatistic()
        {
        }

        public DownloadPackageStatistic(int paSequence, string paStatus)
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
    }
}

