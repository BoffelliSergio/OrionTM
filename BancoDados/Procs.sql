Create proc dbo.ReturnIdTask (@TerminalId int)
As
Begin
	--declare @TerminalId int
	--Set @TerminalId = 11

	set nocount on;

	Create table #temp_taskId
	(
		Id_sequencia int,
		Type_task varchar(100),
		DataCadastro Datetime 
	)
		
	If((Select Count(Id_sequencia) From dbo.UpLoadOnLine Where TerminalId  = @TerminalId and StatusId = 0) > 0)
	Begin
		Insert into #temp_taskId 
		SELECT top 1 Id_sequencia, 'uploadonline', DataCadastro FROM dbo.UpLoadOnLine Where TerminalId  = @TerminalId and StatusId = 0 Order by DataCadastro asc;
	End 

	If((Select Count(Id_sequencia) From dbo.Script Where TerminalId  = @TerminalId and StatusId = 0) > 0)
	Begin
		Insert into #temp_taskId 
		SELECT top 1 Id_sequencia, 'executascript', DataCadastro FROM dbo.Script Where TerminalId  = @TerminalId and StatusId = 0 Order by DataCadastro asc;
	End 

	If((Select Count(Id_sequencia) From dbo.[Reset] Where TerminalId  = @TerminalId and StatusId = 0) > 0)
	Begin
		Insert into #temp_taskId 
		SELECT top 1 Id_sequencia, 'executacomandoreset', DataCadastro FROM dbo.[Reset] Where TerminalId  = @TerminalId and StatusId = 0 Order by DataCadastro asc;
	End 

	If((Select Count(Id_sequencia) From dbo.Download Where TerminalId  = @TerminalId and StatusId = 0) > 0)
	Begin
		Insert into #temp_taskId 
		SELECT top 1 Id_sequencia, 'downloadpackage', DataCadastro FROM dbo.Download Where TerminalId  = @TerminalId and StatusId = 0 Order by DataCadastro asc;
	End 
	
	Select top 1 0 as [Status], Id_sequencia as IdTask, Type_task as Task, 1 as Message  From #temp_taskId Order by DataCadastro;

	drop table #temp_taskId

	set nocount off;
End
GO


Create proc dbo.ReturnReset (@Id_Sequencia int)
As
Begin
	Select TipoReset From dbo.[Reset] Where Id_Sequencia = @Id_Sequencia;
End
GO

Create proc dbo.ReturnScript (@Id_Sequencia int)
As
Begin
	Select ScrConteudo as TextScript From dbo.[Script] Where Id_Sequencia = @Id_Sequencia;
End
GO

Create proc dbo.ReturnUploadOnLine (@Id_Sequencia int)
As
Begin
	Select NomeArquivo, PathArquivo, TipoArquivo, DataArquivo, MascaraArquivo, TipoUpload from [dbo].[UpLoadOnLine] Where Id_Sequencia = @Id_Sequencia;
End
GO

Create proc dbo.ReturnDownloadPackage (@Id_Sequencia int)
As
Begin
	Select p.Nome, d.DataInstalacao from [dbo].[Download] d
	Inner Join [dbo].[Pacote] p on p.PacoteId = d.PacoteId
	Where d.Id_Sequencia = @Id_Sequencia;
End
GO

Create proc dbo.UpdateStatus(@Id_Sequencia int, @Tipo_Oper varchar(50), @Status_Id int)
As
Begin
	set nocount on;
	
	if (@Tipo_Oper = 'uploadonline')
	Begin
		Update dbo.UpLoadOnLine set StatusId =  @Status_Id, DataAtualizacao = getDate()  Where Id_sequencia = @Id_Sequencia;
	End
	
	if (@Tipo_Oper = 'executascript')
	Begin
		Update dbo.Script set StatusId =  @Status_Id, DataAtualizacao = getDate() Where Id_sequencia = @Id_Sequencia;
	End

	if (@Tipo_Oper = 'executacomandoreset')
	Begin
		Update dbo.[Reset] set StatusId =  @Status_Id, DataAtualizacao = getDate() Where Id_sequencia = @Id_Sequencia;
	End

	if (@Tipo_Oper = 'downloadpackage')
	Begin
		Update dbo.Download set StatusId =  @Status_Id, DataAtualizacao = getDate() Where Id_sequencia = @Id_Sequencia;
	End

	set nocount off;
End
GO


Create proc dbo.UpdateHeartBeat(@TerminalId int, @Version varchar(50))
As
Begin
	set nocount on;
	Update dbo.Terminal set DtAtualizaao = getDate()  Where TerminalId = @TerminalId;
	set nocount off;
End
go



CREATE PROCEDURE dbo.GetStatusTerminais
AS
BEGIN
Select
    -- Terminal
    t.TerminalId,
	t.Codigo,
	m.Nome as NmModelo,
	l.Nome as NmLocal,
	IP,
	CASE
     WHEN (DATEDIFF(second,  GETDATE(), DtAtualizaao)*-1) <= 35 THEN 1
	 WHEN (DATEDIFF(second,  GETDATE(), DtAtualizaao)*-1) > 35 THEN 0
    END AS Status,
	DtAtualizaao, 
	(select count(*) from terminal )  as CtTerTot,
	(select count(*) from terminal where (DATEDIFF(second,  GETDATE(), DtAtualizaao)*-1) <= 35) as CtTerOn,
	(select count(*) from terminal where (DATEDIFF(second,  GETDATE(), DtAtualizaao)*-1) > 35) as CtTerOff
	

	FROM Terminal t
	inner join modelo m on m.ModeloId = t.ModeloId
	inner join Local l on l.LocalId = t.LocalId

	order by Status Desc, t.Codigo;
	   	 



END
go


