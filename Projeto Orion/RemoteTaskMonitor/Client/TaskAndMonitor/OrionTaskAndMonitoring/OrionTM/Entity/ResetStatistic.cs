using System;

namespace OrionTMClient.Entity
{
    [Serializable()]
    public class ResetStatistic
    {
        private int prSequence;
        private string prStatus;

        public ResetStatistic()
        {
        }

        public ResetStatistic(int paSequence, string paStatus)
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

