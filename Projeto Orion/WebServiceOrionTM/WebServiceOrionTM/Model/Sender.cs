using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServicesOrionTM.Model;

namespace WebServicesOrionTM.Model
{
    [Serializable()]
    public class Sender : Orion
    {
        private int printSequence;
        private short prshrStatusLink;
        private short prshrLinkSize;
        private short[] prshrFrequency = new short[24];
        private int[] printBufferSize = new int[24];
        private int[] printDelay = new int[24];

        public Sender()
        {
        }

        public Sender(Orion paobjOrion)
        {
            this.PublicToken = paobjOrion.PublicToken;
            this.PrivateToken = paobjOrion.PrivateToken;
            this.IdEquipment = paobjOrion.IdEquipment;
            this.Task = paobjOrion.Task;
            this.IdTask = paobjOrion.IdTask;
            this.Message = paobjOrion.Message;
            this.Status = paobjOrion.Status;
            this.Version = paobjOrion.Version;
        }

        public Sender(RetornoOrion paobjRetornoOrion)
        {
            this.IdEquipment = paobjRetornoOrion.IdEquipment;
            this.Task = paobjRetornoOrion.Task;
            this.IdTask = paobjRetornoOrion.IdTask;
            this.Message = paobjRetornoOrion.Message;
            this.Status = paobjRetornoOrion.Status;
        }

        public int Sequence
        {
            get
            {
                return printSequence;
            }
            set
            {
                printSequence = value;
            }
        }

        public short StatusLink
        {
            get
            {
                return prshrStatusLink;
            }
            set
            {
                prshrStatusLink = value;
            }
        }

        public short LinkSize
        {
            get
            {
                return prshrLinkSize;
            }
            set
            {
                prshrLinkSize = value;
            }
        }

        public short[] Frequency
        {
            get
            {
                return prshrFrequency;
            }
            set
            {
                prshrFrequency = value;
            }
        }

        public int[] BufferSize
        {
            get
            {
                return printBufferSize;
            }
            set
            {
                printBufferSize = value;
            }
        }

        public int[] Delay
        {
            get
            {
                return printDelay;
            }
            set
            {
                printDelay = value;
            }
        }
    }
}


