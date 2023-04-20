# OrionTM
site
usuario orion@admin
senha Orion#Admin1

Banco
 "DefaultConnection": "Data Source=STFSAOJVDXK93-L\\SQLEXPRESS; Initial Catalog=OtmDataBase; Integrated Security=true"
 
 
ENUMS DE STATUS|TASKS|MESSAGES

public enum Status
        {
            Start = 0,
            Starting = 1,
            Executing = 2,
            ExecuteOk = 3,
            ExecuteError = 4,
            FinishError = 5,
            FinishOk = 6,
            DBError = 7,
            InvalidToken = 8
        }

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

public enum Messages
        {
            Ok = 1,
            Error = 2,
            UnknownTask = 3,
            ErrorValidationPrivateToken = 4,
            ErrorValidationPublicToken = 5
        }
