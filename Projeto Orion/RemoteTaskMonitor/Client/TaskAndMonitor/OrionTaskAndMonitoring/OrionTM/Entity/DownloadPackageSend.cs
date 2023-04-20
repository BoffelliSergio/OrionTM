using System;

namespace OrionTMClient.Entity
{
    [Serializable()]
    public class DownloadPackageSend
    {
        private int printSequence;
        private string prstrStatus;
        private bool prStartSending;
        private bool prEndedFileSend;
        private byte[] prFileData;
        private string prstrFileName;
        private long prstrTotalSize;
        private long prstrCRCFile;
        private Int64 prlngInitialPosition;


        private int printSizeBuffer;
        private int printDelay;

        public DownloadPackageSend()
        {
        }

        public DownloadPackageSend(int paSequence, string paStatus)
        {
            this.Sequence = paSequence;
            this.Status = paStatus;
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

        public string Status
        {
            get
            {
                return prstrStatus;
            }
            set
            {
                prstrStatus = value;
            }
        }

        public bool StartSending
        {
            get
            {
                return prStartSending;
            }
            set
            {
                prStartSending = value;
            }
        }

        public byte[] FileData
        {
            get
            {
                return prFileData;
            }
            set
            {
                prFileData = value;
            }
        }

        public string FileName
        {
            get
            {
                return prstrFileName;
            }
            set
            {
                prstrFileName = value;
            }
        }

        public long TotalSize
        {
            get
            {
                return prstrTotalSize;
            }
            set
            {
                prstrTotalSize = value;
            }
        }

        public long CRCFile
        {
            get
            {
                return prstrCRCFile;
            }
            set
            {
                prstrCRCFile = value;
            }
        }

        public int SizeBuffer
        {
            get
            {
                return printSizeBuffer;
            }
            set
            {
                printSizeBuffer = value;
            }
        }

        public int Delay
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

        public bool EndedFileSend
        {
            get
            {
                return prEndedFileSend;
            }
            set
            {
                prEndedFileSend = value;
            }
        }


        public long InitialPosition
        {
            get
            {
                return prlngInitialPosition;
            }
            set
            {
                prlngInitialPosition = value;
            }
        }

    }
}
