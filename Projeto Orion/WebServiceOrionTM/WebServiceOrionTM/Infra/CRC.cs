using System;
using System.Collections;
using System.IO;
using System.Text;

namespace WebServicesOrionTM.Infra
{
    public class CRC
    {
        public Exception Error;

        private Int64 prlngOriginalSize;
        private long prlngCRC32;

        public CRC()
        {
        }

        ~CRC()
        {
        }

        public long CRC32
        {
            get
            {
                return this.prlngCRC32;
            }
        }

        public string CRC32Hex
        {
            get
            {
                return Convert.ToString(this.prlngCRC32, 16);
            }
        }

        public bool CRC32File(string pastrFile)
        {
            FileStream objFileStream;
            BinaryReader objBinaryReader;

            try
            {
                Ionic.Crc.CRC32 objCrc32 = new Ionic.Crc.CRC32();

                FileInfo objFile = new FileInfo(pastrFile);
                this.prlngOriginalSize = objFile.Length;

                objFileStream = new FileStream(pastrFile, FileMode.Open, FileAccess.Read, FileShare.Read);
                objBinaryReader = new BinaryReader(objFileStream);

                foreach (byte b in objBinaryReader.ReadBytes((int)objFile.Length))
                {
                    objCrc32.UpdateCRC(b);
                }

                objBinaryReader.Close();
                objFileStream.Close();

                this.prlngCRC32 = (uint)objCrc32.Crc32Result;
                return true;
            }
            catch (Exception Ex)
            {
                this.Error = Ex;
                return false;
            }
        }
    }
}






