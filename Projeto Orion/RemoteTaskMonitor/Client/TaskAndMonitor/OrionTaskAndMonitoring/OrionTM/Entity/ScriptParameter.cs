using System;

namespace OrionTMClient.Entity
{
    [Serializable()]
    public class ScriptParameter
    {
        private int prSequence;
        private string prStatus;
        private string prTextScript;

        public ScriptParameter()
        {
        }

        public ScriptParameter(int paSequence, string paStatus, string paTextScript)
        {
            this.Sequence = paSequence;
            this.Status = paStatus;
            this.prTextScript = paTextScript;
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

        public string TextScript
        {
            get
            {
                return prTextScript;
            }
            set
            {
                prTextScript = value;
            }
        }
    }
}






