USE [OtmDataBase]
GO

/****** Object:  Table [dbo].[Status]    Script Date: 16/12/2022 23:21:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Status](
	[StatusId] [int] IDENTITY(0,1) NOT NULL,
	[StsDescricao] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[StatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
	
	insert into Status values ('Start');
	insert into Status values ('Starting');
	insert into Status values ('Executing');
	insert into Status values ('ExecuteOk');
	insert into Status values ('ExecuteError');
	insert into Status values ('FinishError');
	insert into Status values ('FinishOk');
	insert into Status values ('DBError');
	insert into Status values ('InvalidToken');
	
        