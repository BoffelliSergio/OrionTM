USE [OtmDataBase]
GO

/****** Object:  Table [dbo].[FilaTasks]    Script Date: 08/12/2022 14:33:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[FilaTasks](
	[FilaTasksId] [int] IDENTITY(1,1) NOT NULL,
	[EquipmentId] [int] NOT NULL,
	[DtAtualizacao] [datetime2](7) NOT NULL,
	[Task] [int] NOT NULL,
	[TaskID] [int] NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_FilaTasks] PRIMARY KEY CLUSTERED 
(
	[FilaTasksId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


