--inserts tabela STSTUS
	
	insert into Status values ('Start');
	insert into Status values ('Starting');
	insert into Status values ('Executing');
	insert into Status values ('ExecuteOk');
	insert into Status values ('ExecuteError');
	insert into Status values ('FinishError');
	insert into Status values ('FinishOk');
	insert into Status values ('DBError');
	insert into Status values ('InvalidToken');
	
-- insertes tabela TASKS

	insert into Tasks values ('Default');
	insert into Tasks values ('HeartBit');
	insert into Tasks values ('VerificaTask');
	insert into Tasks values ('UploadOnline');
	insert into Tasks values ('UploadDiario');
	insert into Tasks values ('ExecutaScript');
	insert into Tasks values ('ExecutaComandoReset');
	insert into Tasks values ('DownloadPackage');
	
	insert into comando values ("Resetar","Resetar Equipamento","c:\aplic\reseta1.bat");
	
	
