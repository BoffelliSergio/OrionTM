USE [OtmDataBase]
GO

CREATE TABLE [dbo].[UpLoadOnLine](
	[Id_sequencia][int] identity(1,1) NOT NULL,
	[TerminalId] [int] NOT NULL,
	[StatusId] [int] NOT NULL,
	[NomeArquivo] [varchar](4000) NULL,
	[PathArquivo] [varchar](4000) NULL,
	[TipoArquivo] [varchar](4000) NULL,
	[DataArquivo] [varchar](4000) NULL,
	[MascaraArquivo] [varchar](4000) NULL,
	[TipoUpload] [varchar](4000) NULL,
	[DataCadastro] [datetime] NOT NULL,
	[DataAtualizacao] [datetime] NOT NULL,
	[StrLog] [varchar](500) NULL,
 CONSTRAINT [PK_UpoadOnLine] PRIMARY KEY CLUSTERED 
(
	[Id_sequencia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Reset](
	[Id_sequencia][int] identity(1,1) NOT NULL,
	[TerminalId] [int] NOT NULL,
	[StatusId] [int] NOT NULL,
	[TipoReset] [int] NOT NULL,
	[DataCadastro] [datetime] NOT NULL,
	[DataAtualizacao] [datetime] NOT NULL,
	[StrLog] [varchar](500) NULL,
 CONSTRAINT [PK_Reset] PRIMARY KEY CLUSTERED 
(
	[Id_sequencia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Script](
	[Id_sequencia][int] identity(1,1) NOT NULL,
	[NomeComando] [varchar](50) NULL,
	[TerminalId] [int] NOT NULL,
	[StatusId] [int] NOT NULL,
	[ScrConteudo] varchar(8000) NOT NULL, 
	[DataCadastro] [datetime] NOT NULL,
	[DataAtualizacao] [datetime] NOT NULL,
	[StrLog] [varchar](500) NULL,
 CONSTRAINT [PK_Script] PRIMARY KEY CLUSTERED 
(
	[Id_sequencia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Download](
	[Id_sequencia][int] identity(1,1) NOT NULL,
	[TerminalId] [int] NOT NULL,
	[StatusId] [int] NOT NULL,
	[PacoteId] [int] NOT NULL, 
	[DataInstalacao] [varchar](50) NULL,
	[HotaInstalacao] [varchar](50) NULL,
	[DataCadastro] [datetime] NOT NULL,
	[DataAtualizacao] [datetime] NOT NULL,
	[StrLog] [varchar](500) NULL,
 CONSTRAINT [PK_Download] PRIMARY KEY CLUSTERED 
(
	[Id_sequencia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


