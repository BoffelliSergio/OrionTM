
USE [OtmDataBase]
GO

Drop Table FilaTasks

/****** Object:  Table [dbo].[FilaTasks]    Script Date: 16/12/2022 23:06:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[FilaTasks](
	[FilaTasksId] [int] IDENTITY(1,1) NOT NULL,
	[TerminalId] [int] NOT NULL,
	[DtAtualizacao] [datetime2](7) NOT NULL,
	[TaskId] [int] NOT NULL,
	[ComandoId] [int] NOT NULL,
	[StatusId] [int] NOT NULL,
 CONSTRAINT [PK_FilaTasks] PRIMARY KEY CLUSTERED 
(
	[FilaTasksId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[FilaTasks]  WITH CHECK ADD  CONSTRAINT [FK_FilaTasks_Terminal_TerminalId] FOREIGN KEY([TerminalId])
REFERENCES [dbo].[Terminal] ([TerminalId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FilaTasks] CHECK CONSTRAINT [FK_FilaTasks_Terminal_TerminalId]
GO

ALTER TABLE [dbo].[FilaTasks]  WITH CHECK ADD  CONSTRAINT [FK_FilaTasks_Status_StatusId] FOREIGN KEY([StatusId])
REFERENCES [dbo].[Status] ([StatusId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FilaTasks] CHECK CONSTRAINT [FK_FilaTasks_Status_StatusId]
GO

ALTER TABLE [dbo].[FilaTasks]  WITH CHECK ADD  CONSTRAINT [FK_FilaTasks_Comando_ComandoId] FOREIGN KEY([ComandoId])
REFERENCES [dbo].[Comando] ([ComandoId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FilaTasks] CHECK CONSTRAINT [FK_FilaTasks_Comando_ComandoId]
GO

ALTER TABLE [dbo].[FilaTasks]  WITH CHECK ADD  CONSTRAINT [FK_FilaTasks_Task_TaskId] FOREIGN KEY([TaskId])
REFERENCES [dbo].[Task] ([TaskId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FilaTasks] CHECK CONSTRAINT [FK_FilaTasks_Task_TaskId]
GO

