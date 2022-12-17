USE [OtmDataBase]
GO

drop table tasks

/****** Object:  Table [dbo].[Task]    Script Date: 16/12/2022 23:21:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Tasks](
	[TasksId] [int] IDENTITY(0,1) NOT NULL,
	[TasksDescricao] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Tasks] PRIMARY KEY CLUSTERED 
(
	[TasksId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
	
	insert into Tasks values ('Default');
	insert into Tasks values ('HeartBit');
	insert into Tasks values ('VerificaTask');
	insert into Tasks values ('UploadOnline');
	insert into Tasks values ('UploadDiario');
	insert into Tasks values ('ExecutaScript');
	insert into Tasks values ('ExecutaComandoReset');
	insert into Tasks values ('DownloadPackage');
	