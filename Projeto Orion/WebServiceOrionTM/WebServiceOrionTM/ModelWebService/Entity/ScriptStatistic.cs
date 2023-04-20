using System;


namespace WebServicesOrionTM.ModelWebService.Entity
{
    [Serializable()]
    public class ScriptStatistic
    {
        private int prSequence;
        private string prStatus;

        public ScriptStatistic()
        {
        }

        public ScriptStatistic(int paSequence, string paStatus)
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

