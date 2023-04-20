using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Net;
using System.Security.Cryptography.X509Certificates;


namespace OrionTMClient.Infra.Certificate
{
    public enum CertificateProblem : long
    {
        CertEXPIRED = 0x800B0101,
        CertVALIDITYPERIODNESTING = 0x800B0102,
        CertROLE = 0x800B0103,
        CertPATHLENCONST = 0x800B0104,
        CertCRITICAL = 0x800B0105,
        CertPURPOSE = 0x800B0106,
        CertISSUERCHAINING = 0x800B0107,
        CertMALFORMED = 0x800B0108,
        CertUNTRUSTEDROOT = 0x800B0109,
        CertCHAINING = 0x800B010A,
        CertREVOKED = 0x800B010C,
        CertUNTRUSTEDTESTROOT = 0x800B010D,
        CertREVOCATION_FAILURE = 0x800B010E,
        CertCN_NO_MATCH = 0x800B010F,
        CertWRONG_USAGE = 0x800B0110,
        CertUNTRUSTEDCA = 0x800B0112,
        CertOTHERPROBLEM = 0x800c010f
    }

    public class CertificateValidation : ICertificatePolicy
    {
        public static string DescriptionError = "";

        public bool CheckValidationResult(ServicePoint paobjServicePoint, X509Certificate objCert, WebRequest objWebRequest, int paintCodProblem)
        {
            GetProblemMessage((CertificateProblem)paintCodProblem);

            if (paintCodProblem == 0)
                return true;

            if (ConfigParameters.ReturnClientConfig("CertificateNotValid") == "true")
                return true;
            else
                return false;
        }

        private void GetProblemMessage(CertificateProblem paenumError)
        {
            if ((long)paenumError == 0)
                DescriptionError = "Valid Certificate";
            else
            {
                CertificateProblem problemList = new CertificateProblem();
                String strErrorName = Enum.GetName(problemList.GetType(), paenumError);

                if (strErrorName != null)
                {
                    DescriptionError = string.Concat("Certificate whith error:", strErrorName, "  error code=", paenumError.ToString());
                }
                else
                {
                    DescriptionError = string.Concat("Certificate whith error:", "An error occured", "  error code=", paenumError.ToString());
                }    
            }
        }
    }
}
