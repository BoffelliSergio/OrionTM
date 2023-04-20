using System;

namespace OrionTMClient.Entity
{
    [Serializable()]
    public class UploadOnLineStatistic 
    {
        private int prSequence;
        private string prStatus;
        
        public UploadOnLineStatistic()
        {
        }

        public UploadOnLineStatistic(int paSequence, string paStatus)
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
