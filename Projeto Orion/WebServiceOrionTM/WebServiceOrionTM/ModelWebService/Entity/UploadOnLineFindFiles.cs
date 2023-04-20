using System;
using WebServicesOrionTM.ModelWebService.Entity;

namespace WebServicesOrionTM.ModelWebService.Entity
{
    [Serializable()]
    public class UploadOnLineFindFiles 
    {
        private string prFileName;
        private string prSendFileName;
        private string prFileExtension;
        private string prFileList;
        private string prPathEquipment;
        private string prFindMask;
        private DateTime prRequestDate;


        public UploadOnLineFindFiles()
        {
        }

        public string FileName
        {
            get
            {
                return prFileName;
            }
            set
            {
                prFileName = value.Trim();
            }
        }

        public string SendFileName
        {
            get
            {
                return prSendFileName;
            }
            set
            {
                prSendFileName = value.Trim();
            }
        }


        public string FileExtension
        {
            get
            {
                return prFileExtension;
            }
            set
            {
                prFileExtension = value.Trim();
            }
        }

        public string FileList
        {
            get
            {
                return prFileList;
            }
            set
            {
                prFileList = value.Trim();
            }
        }

        public string PathEquipment
        {
            get
            {
                return prPathEquipment;
            }
            set
            {
                prPathEquipment = value.Trim();
            }
        }

        public string FindMask
        {
            get
            {
                return prFindMask;
            }
            set
            {
                prFindMask = value.Trim();
            }
        }

        public DateTime RequestDate
        {
            get
            {
                return prRequestDate;
            }
            set
            {
                prRequestDate = value;
            }
        }

    }
}




