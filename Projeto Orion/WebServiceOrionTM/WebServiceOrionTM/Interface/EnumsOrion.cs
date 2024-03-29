﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServicesOrionTM.Interface
{
    [Flags()]
    public enum EquipmentStatusService : short
    {
        EquipmentNotRegistered = 1,
        UnidentifiedEquipment = 2,
        SessionInvalid = 3,
        GeneralParamNotRegistered = 4,
        FailedtoAccessRegistration = 5,
        NonexistentDownload = 6,
        NotFoundPackageFiles = 7,
        PackageFileNotFound = 8,
        NonexistentDailyUpload = 9,
        NonexistentOnLineUpload = 10,
        NonexistentOnLineCommand = 11,
        SuccessfullyFileWritten = 300,
        UnexpectedError = 999
    };

    [Flags()]
    public enum TypeReset : short
    {
        ShutDown = 0,
        Application = 1
    }

    [Flags()]
    public enum Status 
    {
        Start = 0,
        Send = 1,
        ExecuteOk = 2,
        ExecuteError = 3,
        ExecuteCRCError = 4,
        ExecuteCRCOk = 5
    }

    [Flags()]
    public enum Tasks
    {
        Default = 0,
        HeartBit = 1,
        VerificaTask = 2,
        UploadOnline = 3,
        UploadDiario = 4,
        ExecutaScript = 5,
        ExecutaComandoReset = 6,
        DownloadPackage = 7
    }

    [Flags()]
    public enum Messages
    {
        Ok = 1,
        Error = 2,
        UnknownTask = 3,
        ErrorValidationPrivateToken = 4,
        ErrorValidationPublicToken = 5,
        ConnectionDBError = 3
    }

    [Flags()]
    public enum EquipmentServiceStatus : short
    {
        EquipmentNotRegistered = 1,
        EquipmentNotIdentified = 2,
        InvalidSession = 3,
        GeneralParametersNotRegistered = 4,
        FileSavedSuccessfully = 300,
        UnexpectedError = 999
    };

    [Flags()]
    public enum TypeUpdateUpload : short
    {
        Status = 1,
        StartUpload = 2,
        Sending = 3,
        EndUpload = 4
    };


    [Flags()]
    public enum SendingStatus : short
    {
        ExecutingProcessLoad = 0,
        ExecutingWaitingStart = 1,
        ExecutingAwaitingLink = 2,
        ExecutingSendingProbe = 3,
        ExecutingEquipmentFindFile = 4,
        RunningOnUpload = 5,
        RunningOnDownload = 6,
        RunningAvailableFile = 7,
        ExecutingCommand = 8,
        ExecutingWaitingSequence = 9,
        WaitingExecutionLog = 10,
        FinishedEndUpload = 50,
        FinishedEndDownload = 51,
        LogAvailableExecution = 52,
        WaitingSendingInactiveService = 100,
        WaitingConnunicationErrorDownload = 101,
        WaitingEquipmentNoReplied = 102,
        WaitingEquipmentStopSending = 103,
        WaitingInvalidCRC = 104,
        WaitingLinkBlocked = 105,
        WaitingEquipmentUploading = 106,
        WaitingEquipmentDownloading = 107,
        WaitingErrorDuringUpload = 108,
        WaitingFailedOpenFTP = 109,
        WaitingFailedFTPOpenFile = 110,
        WaitingFailedInternetWriteFile = 111,
        WaitingFailedInternetReadFile = 112,
        WaitingBlockedPackage = 113,
        WaitingFileAvailableError = 114,
        WaitingLocationBlocked = 115,
        WaitingEquipmentBlocked = 116,
        waitingBlockedPackageInThisEquipment = 117,
        WaitingExceededNumThreads = 118,
        WaitingUnexpectedError = 199,
        CanceledRequestDateNotExists = 200,
        CanceledFailedBCCP = 201,
        CanceledFailedFileCopy = 202,
        CanceledEquipmentNotFoundFile = 203,
        CanceledDateLimit = 204,
        CanceledServerNotFoundFileRes = 209,
        CanceledCRCServerRoutineFailure = 210,
        CanceledRoutineCRCEquipment = 211,
        CanceledPackageNotFound = 212,
        CanceledPackageCanceledByUser = 213,
        CanceledInvalidLink = 214,
        CanceledInvalidLocal = 215,
        CanceledInvalidEquipment = 216,
        CanceledByUser = 217,
        UnexpectedCondition = 999
    };
}