Drop table Pacote

USE [OtmDataBase]
GO

/****** Object:  Table [dbo].[Pacote]    Script Date: 09/01/2023 20:23:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Pacote](
	[PacoteId] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](10) NOT NULL,
	[Descricao] [nvarchar](50) NOT NULL,
	[Caminho] [nvarchar](200) NOT NULL,
	[Versao] [int] NOT NULL,
	[Prod] [bit] NOT NULL,
	
	
 CONSTRAINT [PK_Pacote] PRIMARY KEY CLUSTERED 
(
	[PacoteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

