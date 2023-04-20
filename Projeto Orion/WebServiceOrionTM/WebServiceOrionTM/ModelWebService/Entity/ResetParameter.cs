using System;

namespace WebServicesOrionTM.ModelWebService.Entity
{
    [Serializable()]
    public class ResetParameter
    {
        private int prSequence;
        private string prStatus;
        private int prTypeReset;

        public ResetParameter()
        {
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

        public int TypeReset
        {
            get
            {
                return prTypeReset;
            }
            set
            {
                prTypeReset = value;
            }
        }
    }
}





