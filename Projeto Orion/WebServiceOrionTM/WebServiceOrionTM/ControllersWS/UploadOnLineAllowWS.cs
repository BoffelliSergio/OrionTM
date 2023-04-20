using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Web;
using WebServicesOrionTM.ModelWebService.Entity;
using WebServicesOrionTM.ControllersWS;
using WebServicesOrionTM.Infra;
using WebServicesOrionTM.Interface;

namespace webServicesOrionTM.ControllersWS
{
    internal class UploadOnLineAllowWS : WSCommon
    {
        internal UploadOnLineAllowWS()
        {
        }

        //internal override object Allow(object paobjAllow)
        //{
        //    try
        //    {
        //        this.probjOrionEquipment = (OrionEquipment) paobjAllow;

        //        string intIdEquipment = "0";

        //        intIdEquipment = this.probjOrionEquipment.IdEquipment;

        //        UploadOnLineSend objAllow = (UploadOnLineSend)paobjAllow;
                                
        //        objAllow.Sequence = 1;
        //        objAllow.LinkStatus = 1;
        //        objAllow.SizeLinkKb = 1;
        //        objAllow.Frequency = 1;
        //        objAllow.SizeBuffer = 3072;
        //        objAllow.Delay = 24;

        //        return objAllow;
        //    }
        //    catch (Exception ex)
        //    {
                
        //        LocalLog.Trace.WriteLogText("UploadOnLineAllowWS.Allow() Error." + paobjAllow.GetType().Name, ex);

        //        this.probjOrionEquipment = (OrionEquipment)paobjAllow;

        //        EquipmentMsgStatus objEquipmentMsgStatus = new EquipmentMsgStatus();
        //        objEquipmentMsgStatus.Status = EquipmentServiceStatus.UnexpectedError.ToString();
        //        objEquipmentMsgStatus.Version = this.probjOrionEquipment.Version;
        //        objEquipmentMsgStatus.Message = Messages.Error.ToString();
        //        objEquipmentMsgStatus.Task = this.probjOrionEquipment.Task;
        //        objEquipmentMsgStatus.IdTask = this.probjOrionEquipment.IdTask;
        //        objEquipmentMsgStatus.IdEquipment = this.probjOrionEquipment.IdEquipment;
        //        objEquipmentMsgStatus.PublicToken = this.probjOrionEquipment.PublicToken;
        //        objEquipmentMsgStatus.PrivateToken = this.probjOrionEquipment.PrivateToken;
       
        //        return objEquipmentMsgStatus;
        //    }
        //}
    }
}
