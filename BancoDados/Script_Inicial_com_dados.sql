USE [OtmDataBase]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 10/02/2023 11:32:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 10/02/2023 11:32:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 10/02/2023 11:32:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 10/02/2023 11:32:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 10/02/2023 11:32:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 10/02/2023 11:32:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 10/02/2023 11:32:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 10/02/2023 11:32:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categorias]    Script Date: 10/02/2023 11:32:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorias](
	[CategoriaId] [int] IDENTITY(1,1) NOT NULL,
	[CategoriaNome] [nvarchar](100) NOT NULL,
	[Descricao] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_Categorias] PRIMARY KEY CLUSTERED 
(
	[CategoriaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comando]    Script Date: 10/02/2023 11:32:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comando](
	[ComandoId] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](10) NOT NULL,
	[Descricao] [nvarchar](50) NOT NULL,
	[Caminho] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_Comando] PRIMARY KEY CLUSTERED 
(
	[ComandoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Configuracao]    Script Date: 10/02/2023 11:32:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Configuracao](
	[ConfiguracaoId] [int] IDENTITY(1,1) NOT NULL,
	[Campo] [nvarchar](25) NOT NULL,
	[Valor] [nvarchar](25) NOT NULL,
 CONSTRAINT [PK_Configuracao] PRIMARY KEY CLUSTERED 
(
	[ConfiguracaoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalheListaEnvio]    Script Date: 10/02/2023 11:32:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalheListaEnvio](
	[DetalheListaEnvioId] [int] IDENTITY(1,1) NOT NULL,
	[ListaEnvioId] [int] NOT NULL,
	[TerminalId] [int] NOT NULL,
 CONSTRAINT [PK_DetalheListaEnvio] PRIMARY KEY CLUSTERED 
(
	[DetalheListaEnvioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Download]    Script Date: 10/02/2023 11:32:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Download](
	[Id_sequencia] [int] IDENTITY(1,1) NOT NULL,
	[TerminalId] [int] NOT NULL,
	[StatusId] [int] NOT NULL,
	[PacoteId] [int] NOT NULL,
	[DataInstalacao] [varchar](50) NULL,
	[HoraInstalacao] [varchar](50) NOT NULL,
	[DataCadastro] [datetime] NOT NULL,
	[DataAtualizacao] [datetime] NOT NULL,
	[StrLog] [varchar](500) NULL,
 CONSTRAINT [PK_Download] PRIMARY KEY CLUSTERED 
(
	[Id_sequencia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FilaTasks]    Script Date: 10/02/2023 11:32:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FilaTasks](
	[FilaTasksId] [int] IDENTITY(1,1) NOT NULL,
	[TerminalId] [int] NOT NULL,
	[DtAtualizacao] [datetime2](7) NOT NULL,
	[TasksId] [int] NOT NULL,
	[ComandoId] [int] NULL,
	[LogId] [int] NULL,
	[PacoteId] [int] NULL,
	[StatusId] [int] NOT NULL,
 CONSTRAINT [PK_FilaTasks] PRIMARY KEY CLUSTERED 
(
	[FilaTasksId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Link]    Script Date: 10/02/2023 11:32:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Link](
	[LinkId] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](10) NOT NULL,
	[Capacidade] [int] NOT NULL,
 CONSTRAINT [PK_Link] PRIMARY KEY CLUSTERED 
(
	[LinkId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ListaEnvio]    Script Date: 10/02/2023 11:32:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ListaEnvio](
	[ListaEnvioId] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](20) NOT NULL,
	[Descricao] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ListaEnvio] PRIMARY KEY CLUSTERED 
(
	[ListaEnvioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Local]    Script Date: 10/02/2023 11:32:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Local](
	[LocalId] [int] IDENTITY(1,1) NOT NULL,
	[LinkId] [int] NOT NULL,
	[Codigo] [nvarchar](10) NOT NULL,
	[Nome] [nvarchar](25) NOT NULL,
	[Endereco] [nvarchar](50) NULL,
	[Numero] [nvarchar](5) NULL,
	[Cidade] [nvarchar](25) NULL,
	[Estado] [nvarchar](25) NULL,
	[Cep] [nvarchar](8) NULL,
	[Telefone] [nvarchar](15) NULL,
	[Contato] [nvarchar](15) NULL,
 CONSTRAINT [PK_Local] PRIMARY KEY CLUSTERED 
(
	[LocalId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Log]    Script Date: 10/02/2023 11:32:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Log](
	[LogId] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](100) NULL,
	[Descricao] [nvarchar](100) NOT NULL,
	[Caminho] [nvarchar](200) NOT NULL,
	[TipoArquivo] [nvarchar](20) NOT NULL,
	[DataMascara] [nvarchar](100) NULL,
 CONSTRAINT [PK_Log] PRIMARY KEY CLUSTERED 
(
	[LogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LogAuditoria]    Script Date: 10/02/2023 11:32:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LogAuditoria](
	[LogAuditoriaId] [int] IDENTITY(1,1) NOT NULL,
	[Modulo] [nvarchar](max) NULL,
	[Detalhe] [nvarchar](max) NULL,
	[Data] [datetime2](7) NOT NULL,
	[Usuario] [nvarchar](max) NULL,
 CONSTRAINT [PK_LogAuditoria] PRIMARY KEY CLUSTERED 
(
	[LogAuditoriaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Modelo]    Script Date: 10/02/2023 11:32:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Modelo](
	[ModeloId] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](10) NOT NULL,
	[Descricao] [nvarchar](20) NOT NULL,
	[Fabricante] [nvarchar](20) NOT NULL,
	[SistemaOperacional] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Modelo] PRIMARY KEY CLUSTERED 
(
	[ModeloId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pacote]    Script Date: 10/02/2023 11:32:04 ******/
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
/****** Object:  Table [dbo].[Reset]    Script Date: 10/02/2023 11:32:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reset](
	[Id_sequencia] [int] IDENTITY(1,1) NOT NULL,
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
/****** Object:  Table [dbo].[Script]    Script Date: 10/02/2023 11:32:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Script](
	[Id_sequencia] [int] IDENTITY(1,1) NOT NULL,
	[NomeComando] [varchar](50) NULL,
	[TerminalId] [int] NOT NULL,
	[StatusId] [int] NOT NULL,
	[ScrConteudo] [varchar](8000) NOT NULL,
	[DataCadastro] [datetime] NOT NULL,
	[DataAtualizacao] [datetime] NOT NULL,
	[StrLog] [varchar](500) NULL,
 CONSTRAINT [PK_Script] PRIMARY KEY CLUSTERED 
(
	[Id_sequencia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 10/02/2023 11:32:04 ******/
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
/****** Object:  Table [dbo].[Tasks]    Script Date: 10/02/2023 11:32:04 ******/
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
/****** Object:  Table [dbo].[Terminal]    Script Date: 10/02/2023 11:32:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Terminal](
	[TerminalId] [int] IDENTITY(1,1) NOT NULL,
	[ModeloId] [int] NOT NULL,
	[Codigo] [nvarchar](10) NOT NULL,
	[LocalId] [int] NOT NULL,
	[IP] [nvarchar](15) NOT NULL,
	[DNS] [nvarchar](15) NOT NULL,
	[DefaultGateway] [nvarchar](15) NOT NULL,
	[DtAtualizaao] [datetime2](7) NOT NULL,
	[Vrs_Distribuida] [int] NOT NULL,
	[Vrs_Instalada] [int] NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Terminal] PRIMARY KEY CLUSTERED 
(
	[TerminalId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UpLoadOnLine]    Script Date: 10/02/2023 11:32:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UpLoadOnLine](
	[Id_sequencia] [int] IDENTITY(1,1) NOT NULL,
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
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221021210531_init-sql', N'6.0.9')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221021213741_ListaEnvio', N'6.0.9')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221021214004_ListaEnvio1', N'6.0.9')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221024215052_pedidodet', N'6.0.9')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221107183448_pacote', N'6.0.9')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221208023025_filatask', N'6.0.9')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'934993ab-e229-4ca8-9565-d3744c8017f3', N'Usuario', N'USUARIO', N'e840f1f5-ecaf-49a7-b398-7339e5dc6bf9')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'e35d005e-eb70-410e-bba6-81175b87793d', N'Admin', N'ADMIN', N'dd63f698-b798-4ba4-a313-4a5a0588f556')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'1248c976-1452-4693-a4ae-39701f0ac498', N'e35d005e-eb70-410e-bba6-81175b87793d')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'14622ef4-7181-4ffa-bce5-9890a7121c8f', N'934993ab-e229-4ca8-9565-d3744c8017f3')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'21159f10-5398-43da-97ed-128ffd8be9f8', N'934993ab-e229-4ca8-9565-d3744c8017f3')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'3ac8be8b-d7d4-4206-b3d9-2d7bb34fc69e', N'e35d005e-eb70-410e-bba6-81175b87793d')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'578b0e03-7c31-434e-90f5-e9cfa0d10dbf', N'e35d005e-eb70-410e-bba6-81175b87793d')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'6a9d7e32-aeb3-413a-b02f-82e86c1b5dbc', N'e35d005e-eb70-410e-bba6-81175b87793d')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'1248c976-1452-4693-a4ae-39701f0ac498', N'Agnaldo', N'AGNALDO', N'ag_himoro@hotmail.com', N'AG_HIMORO@HOTMAIL.COM', 0, N'AQAAAAEAACcQAAAAEAtFW+GcqPUPjyGa5tAQ6JxHAhG1fAwjgjcPfDCeejDBsjuiC827IdNrMYmqsNaq/w==', N'WXGLJR2MCZODJS434LDEV4G3IJSDCJWC', N'5b000c12-6cbf-461b-9c05-99928228ec9e', N'88888888', 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'14622ef4-7181-4ffa-bce5-9890a7121c8f', N'Jose', N'JOSE', N'fff@sss.com', N'FFF@SSS.COM', 0, N'AQAAAAEAACcQAAAAEL3NhXOBFuEyqhdy9znTG52PCxcNk2J2feFZzAvhDIbAmS1QqkMVBHb409l4vVIRWA==', N'7SHRWVD2L5BMA7YCLPZLYCTCCMHLZEAG', N'e2bab3a9-e0be-4b6b-b6a9-47d3655fe588', N'999005175', 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'21159f10-5398-43da-97ed-128ffd8be9f8', N'Joao', N'JOAO', N'ffeeecccf@sss.com', N'FFEEECCCF@SSS.COM', 0, N'AQAAAAEAACcQAAAAEFZic/nc8xvDxRIeEU7UtK5lzgDBdiZXrTyKbWdnBIdZAfT6Zo+ARM20/pDkqcTY/w==', N'V4HPAPMGDKNK52SDGZBGQ4QBEQ352GY2', N'eba3a170-e856-481d-9002-cff5cea44101', N'999005175', 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'3ac8be8b-d7d4-4206-b3d9-2d7bb34fc69e', N'orion@admin', N'ORION@ADMIN', N'orion@admin', N'ORION@ADMIN', 1, N'AQAAAAEAACcQAAAAEDMFQSWqegFV9roqLobc3CCLeZB4cLskneQm66ZFk5HbqBb5eyMxfrWwY++tENfKog==', N'XHKUWXYJ4QOV7MFRJF6XQNUR4LPXB3A7', N'2ad740a8-9b69-4b57-a4c1-21a6b9348794', NULL, 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'578b0e03-7c31-434e-90f5-e9cfa0d10dbf', N'Sergio', N'SERGIO', N'boffell.sergio@gmail.com', N'BOFFELL.SERGIO@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEJe6Bm9TORyIIfrdXWsuGjNeQoWqcdQQfVBDGE1rdWPRz1u5DGkFVjn6++513mnXww==', N'T7TPWGTUPYMBYQ6H2LRCK35XY34CGKKE', N'c2320d39-93d1-48ae-9d00-26ca11dfa2a8', N'999005175', 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'6a9d7e32-aeb3-413a-b02f-82e86c1b5dbc', N'Boffelli', N'BOFFELLI', N'ffeeesscccf@sss.com', N'FFEEESSCCCF@SSS.COM', 0, N'AQAAAAEAACcQAAAAEPLFJTlS0yKLGuomRVOVT2AkaM+Xf7oyxlfPJJjel/0POSgw/WWMBznGp6kZIznWzQ==', N'XRD2V3SHDD2FBMS3XZ6ACH5XLGHBVXKB', N'9a13e089-9258-4bfb-bef0-b9d3979cbcff', N'999005175', 0, 0, NULL, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[Comando] ON 
GO
INSERT [dbo].[Comando] ([ComandoId], [Nome], [Descricao], [Caminho]) VALUES (9, N'teste1', N'testa abc', N'dir c:\aplic
cd\aplic
start aplic.exe
exit




')
GO
INSERT [dbo].[Comando] ([ComandoId], [Nome], [Descricao], [Caminho]) VALUES (10, N'script2', N'script2', N'cls
dir c:\aplic
')
GO
SET IDENTITY_INSERT [dbo].[Comando] OFF
GO
SET IDENTITY_INSERT [dbo].[Configuracao] ON 
GO
INSERT [dbo].[Configuracao] ([ConfiguracaoId], [Campo], [Valor]) VALUES (1, N'Img_IF', N'/images/nubank.png')
GO
INSERT [dbo].[Configuracao] ([ConfiguracaoId], [Campo], [Valor]) VALUES (2, N'Numero_IF', N'0260')
GO
INSERT [dbo].[Configuracao] ([ConfiguracaoId], [Campo], [Valor]) VALUES (3, N'Tolerancia_Status', N'5')
GO
SET IDENTITY_INSERT [dbo].[Configuracao] OFF
GO
SET IDENTITY_INSERT [dbo].[DetalheListaEnvio] ON 
GO
INSERT [dbo].[DetalheListaEnvio] ([DetalheListaEnvioId], [ListaEnvioId], [TerminalId]) VALUES (153, 9, 13)
GO
INSERT [dbo].[DetalheListaEnvio] ([DetalheListaEnvioId], [ListaEnvioId], [TerminalId]) VALUES (154, 12, 11)
GO
INSERT [dbo].[DetalheListaEnvio] ([DetalheListaEnvioId], [ListaEnvioId], [TerminalId]) VALUES (155, 12, 12)
GO
INSERT [dbo].[DetalheListaEnvio] ([DetalheListaEnvioId], [ListaEnvioId], [TerminalId]) VALUES (156, 12, 13)
GO
INSERT [dbo].[DetalheListaEnvio] ([DetalheListaEnvioId], [ListaEnvioId], [TerminalId]) VALUES (157, 12, 14)
GO
INSERT [dbo].[DetalheListaEnvio] ([DetalheListaEnvioId], [ListaEnvioId], [TerminalId]) VALUES (158, 12, 15)
GO
INSERT [dbo].[DetalheListaEnvio] ([DetalheListaEnvioId], [ListaEnvioId], [TerminalId]) VALUES (166, 11, 11)
GO
INSERT [dbo].[DetalheListaEnvio] ([DetalheListaEnvioId], [ListaEnvioId], [TerminalId]) VALUES (167, 11, 13)
GO
INSERT [dbo].[DetalheListaEnvio] ([DetalheListaEnvioId], [ListaEnvioId], [TerminalId]) VALUES (168, 11, 14)
GO
SET IDENTITY_INSERT [dbo].[DetalheListaEnvio] OFF
GO
SET IDENTITY_INSERT [dbo].[Download] ON 
GO
INSERT [dbo].[Download] ([Id_sequencia], [TerminalId], [StatusId], [PacoteId], [DataInstalacao], [HoraInstalacao], [DataCadastro], [DataAtualizacao], [StrLog]) VALUES (1, 12, 0, 1, N'IMED', N'IMED', CAST(N'2023-02-10T11:03:53.740' AS DateTime), CAST(N'2023-02-10T11:03:53.740' AS DateTime), N'')
GO
INSERT [dbo].[Download] ([Id_sequencia], [TerminalId], [StatusId], [PacoteId], [DataInstalacao], [HoraInstalacao], [DataCadastro], [DataAtualizacao], [StrLog]) VALUES (2, 12, 0, 1, N'IMED', N'IMED', CAST(N'2023-02-10T11:04:05.440' AS DateTime), CAST(N'2023-02-10T11:04:05.440' AS DateTime), N'')
GO
INSERT [dbo].[Download] ([Id_sequencia], [TerminalId], [StatusId], [PacoteId], [DataInstalacao], [HoraInstalacao], [DataCadastro], [DataAtualizacao], [StrLog]) VALUES (3, 11, 0, 3, N'21/02/2023', N'11:06', CAST(N'2023-02-10T11:04:16.347' AS DateTime), CAST(N'2023-02-10T11:04:16.347' AS DateTime), N'')
GO
INSERT [dbo].[Download] ([Id_sequencia], [TerminalId], [StatusId], [PacoteId], [DataInstalacao], [HoraInstalacao], [DataCadastro], [DataAtualizacao], [StrLog]) VALUES (4, 11, 0, 1, N'IMED', N'IMED', CAST(N'2023-02-10T11:04:38.743' AS DateTime), CAST(N'2023-02-10T11:04:38.743' AS DateTime), N'')
GO
INSERT [dbo].[Download] ([Id_sequencia], [TerminalId], [StatusId], [PacoteId], [DataInstalacao], [HoraInstalacao], [DataCadastro], [DataAtualizacao], [StrLog]) VALUES (5, 12, 0, 1, N'IMED', N'IMED', CAST(N'2023-02-10T11:04:38.757' AS DateTime), CAST(N'2023-02-10T11:04:38.757' AS DateTime), N'')
GO
INSERT [dbo].[Download] ([Id_sequencia], [TerminalId], [StatusId], [PacoteId], [DataInstalacao], [HoraInstalacao], [DataCadastro], [DataAtualizacao], [StrLog]) VALUES (6, 14, 0, 1, N'IMED', N'IMED', CAST(N'2023-02-10T11:04:38.760' AS DateTime), CAST(N'2023-02-10T11:04:38.760' AS DateTime), N'')
GO
INSERT [dbo].[Download] ([Id_sequencia], [TerminalId], [StatusId], [PacoteId], [DataInstalacao], [HoraInstalacao], [DataCadastro], [DataAtualizacao], [StrLog]) VALUES (7, 13, 0, 1, N'28/02/2023', N'15:08', CAST(N'2023-02-10T11:05:05.073' AS DateTime), CAST(N'2023-02-10T11:05:05.073' AS DateTime), N'')
GO
INSERT [dbo].[Download] ([Id_sequencia], [TerminalId], [StatusId], [PacoteId], [DataInstalacao], [HoraInstalacao], [DataCadastro], [DataAtualizacao], [StrLog]) VALUES (8, 11, 0, 1, N'21/02/2023', N'14:08', CAST(N'2023-02-10T11:05:30.293' AS DateTime), CAST(N'2023-02-10T11:05:30.293' AS DateTime), N'')
GO
INSERT [dbo].[Download] ([Id_sequencia], [TerminalId], [StatusId], [PacoteId], [DataInstalacao], [HoraInstalacao], [DataCadastro], [DataAtualizacao], [StrLog]) VALUES (9, 13, 0, 1, N'21/02/2023', N'14:08', CAST(N'2023-02-10T11:05:30.300' AS DateTime), CAST(N'2023-02-10T11:05:30.300' AS DateTime), N'')
GO
INSERT [dbo].[Download] ([Id_sequencia], [TerminalId], [StatusId], [PacoteId], [DataInstalacao], [HoraInstalacao], [DataCadastro], [DataAtualizacao], [StrLog]) VALUES (10, 14, 0, 1, N'21/02/2023', N'14:08', CAST(N'2023-02-10T11:05:30.303' AS DateTime), CAST(N'2023-02-10T11:05:30.303' AS DateTime), N'')
GO
SET IDENTITY_INSERT [dbo].[Download] OFF
GO
SET IDENTITY_INSERT [dbo].[FilaTasks] ON 
GO
INSERT [dbo].[FilaTasks] ([FilaTasksId], [TerminalId], [DtAtualizacao], [TasksId], [ComandoId], [LogId], [PacoteId], [StatusId]) VALUES (157, 11, CAST(N'2023-02-10T01:12:08.0539209' AS DateTime2), 5, 10, 0, 0, 0)
GO
INSERT [dbo].[FilaTasks] ([FilaTasksId], [TerminalId], [DtAtualizacao], [TasksId], [ComandoId], [LogId], [PacoteId], [StatusId]) VALUES (158, 13, CAST(N'2023-02-10T01:12:08.4403174' AS DateTime2), 5, 10, 0, 0, 0)
GO
INSERT [dbo].[FilaTasks] ([FilaTasksId], [TerminalId], [DtAtualizacao], [TasksId], [ComandoId], [LogId], [PacoteId], [StatusId]) VALUES (159, 14, CAST(N'2023-02-10T01:12:08.4477951' AS DateTime2), 5, 10, 0, 0, 0)
GO
SET IDENTITY_INSERT [dbo].[FilaTasks] OFF
GO
SET IDENTITY_INSERT [dbo].[Link] ON 
GO
INSERT [dbo].[Link] ([LinkId], [Nome], [Capacidade]) VALUES (2, N'Link02', 50)
GO
INSERT [dbo].[Link] ([LinkId], [Nome], [Capacidade]) VALUES (3, N'Link03', 20)
GO
SET IDENTITY_INSERT [dbo].[Link] OFF
GO
SET IDENTITY_INSERT [dbo].[ListaEnvio] ON 
GO
INSERT [dbo].[ListaEnvio] ([ListaEnvioId], [Nome], [Descricao]) VALUES (9, N'Pre-Piloto', N'Equipamentos Pré-Piloto')
GO
INSERT [dbo].[ListaEnvio] ([ListaEnvioId], [Nome], [Descricao]) VALUES (11, N'Piloto', N'Equipamentos Pilotos')
GO
INSERT [dbo].[ListaEnvio] ([ListaEnvioId], [Nome], [Descricao]) VALUES (12, N'Producao', N'Equipamentos  Produção')
GO
SET IDENTITY_INSERT [dbo].[ListaEnvio] OFF
GO
SET IDENTITY_INSERT [dbo].[Local] ON 
GO
INSERT [dbo].[Local] ([LocalId], [LinkId], [Codigo], [Nome], [Endereco], [Numero], [Cidade], [Estado], [Cep], [Telefone], [Contato]) VALUES (2, 2, N'0202', N'Agencia Ceasa', N'Av Eiras Garcia', N'12345', N'São Paulo', NULL, N'8888888', N'88888888', N'Jose')
GO
INSERT [dbo].[Local] ([LocalId], [LinkId], [Codigo], [Nome], [Endereco], [Numero], [Cidade], [Estado], [Cep], [Telefone], [Contato]) VALUES (3, 3, N'0101', N'Ag Paulista', NULL, N'777', NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Local] ([LocalId], [LinkId], [Codigo], [Nome], [Endereco], [Numero], [Cidade], [Estado], [Cep], [Telefone], [Contato]) VALUES (4, 2, N'0303', N'Ag Jaguare', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Local] OFF
GO
SET IDENTITY_INSERT [dbo].[Log] ON 
GO
INSERT [dbo].[Log] ([LogId], [Nome], [Descricao], [Caminho], [TipoArquivo], [DataMascara]) VALUES (14, N'c:\log', N'conteudo da pasta log', N'c:\log\', N'Pasta', NULL)
GO
INSERT [dbo].[Log] ([LogId], [Nome], [Descricao], [Caminho], [TipoArquivo], [DataMascara]) VALUES (15, N'atm_[]', N'log da ATM', N'c:\log\', N'Log', N'yyyy_mm_dd')
GO
INSERT [dbo].[Log] ([LogId], [Nome], [Descricao], [Caminho], [TipoArquivo], [DataMascara]) VALUES (16, N'teste01', N'log de teste ', N'C:\temp\', N'Xml', NULL)
GO
SET IDENTITY_INSERT [dbo].[Log] OFF
GO
SET IDENTITY_INSERT [dbo].[LogAuditoria] ON 
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (1, N'Links', N'Criou -> Link01', CAST(N'2022-10-21T21:19:31.2836547' AS DateTime2), N'orion@admin')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (2, N'Links', N'Criou -> Link02', CAST(N'2022-10-21T21:19:41.9900748' AS DateTime2), N'orion@admin')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (3, N'Links', N'Criou -> Link03', CAST(N'2022-10-21T21:20:02.7627332' AS DateTime2), N'orion@admin')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (4, N'Local', N'Criou -> Agencia Ceasa', CAST(N'2022-10-21T21:20:32.0693907' AS DateTime2), N'orion@admin')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (5, N'Local', N'Criou -> Agencia Ceasa', CAST(N'2022-10-21T21:20:49.7527986' AS DateTime2), N'orion@admin')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (6, N'Local', N'Editou -> sergio boffelli', CAST(N'2022-10-21T21:21:08.8930053' AS DateTime2), N'orion@admin')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (7, N'Local', N'Editou -> Agencia Ceasa', CAST(N'2022-10-21T21:21:25.1101606' AS DateTime2), N'orion@admin')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (8, N'Modelos', N'Criou -> ATM FULL', CAST(N'2022-10-21T21:21:45.7819181' AS DateTime2), N'orion@admin')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (9, N'Modelos', N'Criou -> ATM SLIN', CAST(N'2022-10-21T21:22:01.2961694' AS DateTime2), N'orion@admin')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (10, N'Modelos', N'Criou -> CAIXA', CAST(N'2022-10-21T21:22:16.4840513' AS DateTime2), N'orion@admin')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (11, N'Terminais', N'Criou -> 10001000', CAST(N'2022-10-21T21:22:49.6320120' AS DateTime2), N'orion@admin')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (12, N'Terminais', N'Criou -> 10001001', CAST(N'2022-10-21T21:23:06.7953207' AS DateTime2), N'orion@admin')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (13, N'Terminais', N'Criou -> 10001000A', CAST(N'2022-10-21T21:23:27.3441299' AS DateTime2), N'orion@admin')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (14, N'Terminais', N'Criou -> 10001000B', CAST(N'2022-10-21T21:23:44.5606824' AS DateTime2), N'orion@admin')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (15, N'Local', N'Editou -> Agencia Butanta', CAST(N'2022-10-21T21:24:22.0907671' AS DateTime2), N'orion@admin')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (16, N'Terminais', N'Editou -> 10001001', CAST(N'2022-10-21T21:24:32.2169217' AS DateTime2), N'orion@admin')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (17, N'Terminais', N'Editou -> 10001000A', CAST(N'2022-10-21T21:24:37.0415299' AS DateTime2), N'orion@admin')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (18, N'Configurações', N'Criou -> Img_IF', CAST(N'2022-10-21T21:24:58.5185853' AS DateTime2), N'orion@admin')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (19, N'Configurações', N'Criou -> Numero_IF', CAST(N'2022-10-21T21:25:09.1864958' AS DateTime2), N'orion@admin')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (20, N'ListaEnvio', N'Excluiu -> teste', CAST(N'2022-10-23T22:41:22.0721222' AS DateTime2), N'Jose')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (21, N'ListaEnvio', N'Excluiu -> Teste', CAST(N'2022-10-23T22:42:47.2159401' AS DateTime2), N'Jose')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (22, N'ListaEnvio', N'Excluiu -> Pre-Piloto', CAST(N'2022-10-23T22:42:50.7858776' AS DateTime2), N'Jose')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (23, N'ListaEnvio', N'Excluiu -> Piloto', CAST(N'2022-10-23T22:42:53.5050775' AS DateTime2), N'Jose')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (24, N'ListaEnvio', N'Excluiu -> Teste', CAST(N'2022-10-23T23:47:20.5491368' AS DateTime2), N'Jose')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (25, N'ListaEnvio', N'Excluiu -> Producao', CAST(N'2022-10-23T23:47:22.3832443' AS DateTime2), N'Jose')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (26, N'ListaEnvio', N'Excluiu -> Pre-Piloto', CAST(N'2022-10-23T23:47:24.1477506' AS DateTime2), N'Jose')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (27, N'ListaEnvio', N'Excluiu -> Piloto', CAST(N'2022-10-23T23:47:25.8487194' AS DateTime2), N'Jose')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (28, N'ListaEnvio', N'Editou -> Piloto', CAST(N'2022-10-23T23:59:47.0558832' AS DateTime2), N'orion@admin')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (29, N'ListaEnvio', N'Editou -> Pre-Piloto', CAST(N'2022-10-24T00:00:33.7179861' AS DateTime2), N'orion@admin')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (30, N'ListaEnvio', N'Editou -> Pre-Piloto', CAST(N'2022-10-24T00:00:45.8127318' AS DateTime2), N'orion@admin')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (31, N'Terminais', N'Criou -> 20001001', CAST(N'2022-10-28T20:25:58.8228443' AS DateTime2), N'orion@admin')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (32, N'Terminais', N'Criou -> 30010001', CAST(N'2022-10-28T20:26:13.0033564' AS DateTime2), N'orion@admin')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (33, N'Terminais', N'Criou -> 56781000', CAST(N'2022-10-28T20:26:26.5216031' AS DateTime2), N'orion@admin')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (34, N'Links', N'Excluiu -> Link01', CAST(N'2022-11-03T15:13:12.3703477' AS DateTime2), N'orion@admin')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (35, N'Links', N'Criou -> Link01', CAST(N'2022-11-03T15:13:34.4801651' AS DateTime2), N'orion@admin')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (36, N'Local', N'Criou -> Ag Paulista', CAST(N'2022-11-03T15:14:06.4711485' AS DateTime2), N'orion@admin')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (37, N'Terminais', N'Criou -> 20001002', CAST(N'2022-11-03T15:14:27.5545551' AS DateTime2), N'orion@admin')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (38, N'Links', N'Excluiu -> Link01', CAST(N'2022-11-03T17:34:54.9046065' AS DateTime2), N'orion@admin')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (39, N'Modelos', N'Criou -> Atm', CAST(N'2022-11-07T19:34:27.4169228' AS DateTime2), N'orion@admin')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (40, N'Comando', N'Criou -> Resetar', CAST(N'2022-11-07T20:30:03.3140372' AS DateTime2), N'orion@admin')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (41, N'Logs', N'Editou -> Atm', CAST(N'2022-11-08T14:58:46.6052084' AS DateTime2), N'orion@admin')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (42, N'Logs', N'Editou -> Atm', CAST(N'2022-11-08T14:58:53.8965793' AS DateTime2), N'orion@admin')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (43, N'Logs', N'Criou -> teste', CAST(N'2022-11-08T15:07:50.9923325' AS DateTime2), N'orion@admin')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (44, N'Logs', N'Excluiu -> teste', CAST(N'2022-11-08T15:08:11.1184378' AS DateTime2), N'orion@admin')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (45, N'Comandos', N'Editou -> Resetar', CAST(N'2022-11-08T21:18:57.9775268' AS DateTime2), N'orion@admin')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (46, N'Comando', N'Criou -> rrr', CAST(N'2022-11-08T21:22:58.3264418' AS DateTime2), N'orion@admin')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (47, N'Comandos', N'Editou -> rrr', CAST(N'2022-11-08T21:23:12.4103905' AS DateTime2), N'orion@admin')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (48, N'Comandos', N'Excluiu -> rrr', CAST(N'2022-11-08T21:23:15.4595447' AS DateTime2), N'orion@admin')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (49, N'Logs', N'Editou -> Atm', CAST(N'2022-11-12T17:21:24.7329685' AS DateTime2), N'orion@admin')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (50, N'Logs', N'Criou -> atmInter', CAST(N'2022-11-12T17:22:08.9094054' AS DateTime2), N'orion@admin')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (51, N'ListaEnvio', N'Editou -> Piloto', CAST(N'2022-11-17T00:25:38.5365624' AS DateTime2), N'orion@admin')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (52, N'ListaEnvio', N'Editou -> Pre-Piloto', CAST(N'2022-11-17T00:25:48.9619470' AS DateTime2), N'orion@admin')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (53, N'ListaEnvio', N'Editou -> Producao', CAST(N'2022-11-17T00:25:52.9453311' AS DateTime2), N'orion@admin')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (54, N'ListaEnvio', N'Editou -> Teste', CAST(N'2022-11-17T00:25:57.3728867' AS DateTime2), N'orion@admin')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (55, N'Lista de Envios', N'Criou -> teste2', CAST(N'2022-11-18T22:28:47.0404269' AS DateTime2), N'orion@admin')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (56, N'ListaEnvio', N'Excluiu -> teste2', CAST(N'2022-12-06T21:38:15.3637488' AS DateTime2), N'orion@admin')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (57, N'ListaEnvio', N'Excluiu -> Teste', CAST(N'2022-12-06T21:38:18.6467245' AS DateTime2), N'orion@admin')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (58, N'Lista de Envios', N'Criou -> teste', CAST(N'2022-12-06T21:40:42.2748396' AS DateTime2), N'orion@admin')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (59, N'Lista de Envios', N'Criou -> xxxx', CAST(N'2022-12-06T22:40:02.8646711' AS DateTime2), N'orion@admin')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (60, N'Terminais', N'Criou -> 50005001', CAST(N'2022-12-07T22:44:19.6713712' AS DateTime2), N'orion@admin')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (61, N'Local', N'Editou -> Ag Paulista', CAST(N'2022-12-07T23:27:24.6615370' AS DateTime2), N'Agnaldo')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (62, N'Local', N'Editou -> Ag Paulista', CAST(N'2022-12-07T23:27:54.3088148' AS DateTime2), N'Agnaldo')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (63, N'Comando', N'Criou -> LimpaLog', CAST(N'2022-12-08T01:10:00.5001553' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (64, N'ListaEnvio', N'Excluiu -> xxxx', CAST(N'2022-12-08T02:17:53.2431295' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (65, N'Lista de Envios', N'Criou -> xxxx', CAST(N'2022-12-08T23:07:33.1228995' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (66, N'Terminais', N'Criou -> 11112222', CAST(N'2022-12-08T23:08:14.6666350' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (67, N'Comando', N'Criou -> teste', CAST(N'2022-12-14T01:38:10.8132283' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (68, N'Comando', N'Criou -> 2', CAST(N'2022-12-16T00:21:52.5365886' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (69, N'Comando', N'Criou -> 3', CAST(N'2022-12-16T00:22:04.1944350' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (70, N'Comando', N'Criou -> 4', CAST(N'2022-12-16T00:22:09.0881516' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (71, N'Comando', N'Criou -> 5', CAST(N'2022-12-16T00:22:14.2284048' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (72, N'Comando', N'Criou -> 6', CAST(N'2022-12-16T00:22:21.2800614' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (73, N'Comando', N'Criou -> 77', CAST(N'2022-12-16T00:22:29.3162058' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (74, N'Comando', N'Criou -> 766', CAST(N'2022-12-16T00:22:38.3954358' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (75, N'Comando', N'Criou -> 666', CAST(N'2022-12-16T00:22:51.6180196' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (76, N'Comando', N'Criou -> 66666', CAST(N'2022-12-16T00:23:06.7724097' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (77, N'Comandos', N'Excluiu -> 2', CAST(N'2022-12-16T00:23:22.4594247' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (78, N'Lista de Envios', N'Criou -> 2', CAST(N'2022-12-16T03:00:15.4055454' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (79, N'Lista de Envios', N'Criou -> 3', CAST(N'2022-12-16T03:00:19.7276218' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (80, N'Lista de Envios', N'Criou -> 4', CAST(N'2022-12-16T03:00:24.1907682' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (81, N'Lista de Envios', N'Criou -> 5', CAST(N'2022-12-16T03:00:28.4919465' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (82, N'Lista de Envios', N'Criou -> 6', CAST(N'2022-12-16T03:00:33.5071284' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (83, N'Lista de Envios', N'Criou -> 67', CAST(N'2022-12-16T03:00:39.4899870' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (84, N'Lista de Envios', N'Criou -> 9', CAST(N'2022-12-16T03:00:45.8852082' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (85, N'ListaEnvio', N'Excluiu -> 2', CAST(N'2022-12-16T03:00:58.5813190' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (86, N'ListaEnvio', N'Excluiu -> 3', CAST(N'2022-12-16T03:01:00.4669252' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (87, N'ListaEnvio', N'Excluiu -> 4', CAST(N'2022-12-16T03:01:02.4747346' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (88, N'ListaEnvio', N'Excluiu -> 5', CAST(N'2022-12-16T03:01:04.2503654' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (89, N'ListaEnvio', N'Excluiu -> 6', CAST(N'2022-12-16T03:01:05.6765005' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (90, N'ListaEnvio', N'Excluiu -> 67', CAST(N'2022-12-16T03:01:07.0111050' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (91, N'ListaEnvio', N'Excluiu -> 9', CAST(N'2022-12-16T03:01:08.7178199' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (92, N'Comandos', N'Excluiu -> 3', CAST(N'2022-12-17T04:08:26.7520092' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (93, N'Comandos', N'Excluiu -> 4', CAST(N'2022-12-17T04:08:29.1987052' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (94, N'Comandos', N'Excluiu -> 5', CAST(N'2022-12-17T04:08:31.3753956' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (95, N'Comandos', N'Excluiu -> 6', CAST(N'2022-12-17T04:08:33.4745973' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (96, N'Comandos', N'Excluiu -> 666', CAST(N'2022-12-17T04:08:35.7829709' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (97, N'Comandos', N'Excluiu -> 66666', CAST(N'2022-12-17T04:08:37.9493628' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (98, N'Comandos', N'Excluiu -> 766', CAST(N'2022-12-17T04:08:39.9085651' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (99, N'Comandos', N'Excluiu -> 77', CAST(N'2022-12-17T04:08:42.3201783' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (100, N'Comandos', N'Envio Comando Por Lista', CAST(N'2022-12-19T18:41:05.0368663' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (101, N'Comandos', N'Envio Comando Por Lista', CAST(N'2022-12-19T23:51:04.8354665' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (102, N'Comandos', N'Envio Comando Por Local', CAST(N'2022-12-19T23:51:37.8724545' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (103, N'Comandos', N'Envio Reset Por Terminal', CAST(N'2022-12-19T23:51:49.7347191' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (104, N'Comandos', N'Envio Comando Por Termianal', CAST(N'2022-12-19T23:52:43.8005043' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (105, N'Comandos', N'Envio Reset Por Terminal', CAST(N'2022-12-19T23:52:52.3812528' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (106, N'Comandos', N'Envio Comando Por Lista', CAST(N'2022-12-19T23:52:58.0189870' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (107, N'Comandos', N'Envio Comando Por Lista', CAST(N'2022-12-20T00:00:39.5099051' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (108, N'Comandos', N'Envio Comando Por Local', CAST(N'2022-12-20T00:01:58.7233054' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (109, N'Comandos', N'Envio Comando Por Local', CAST(N'2022-12-20T00:05:50.2315372' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (110, N'Comandos', N'Envio Comando Por Lista', CAST(N'2022-12-20T00:06:07.9712808' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (111, N'Configurações', N'Criou -> Tolerancia_Status', CAST(N'2022-12-26T22:28:40.5753346' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (112, N'Configurações', N'Editou -> Tolerancia_Status', CAST(N'2022-12-26T22:39:57.4894916' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (113, N'Comandos', N'Envio Comando Por Local', CAST(N'2023-01-03T12:41:26.7211286' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (114, N'Comandos', N'Envio Comando Por Local', CAST(N'2023-01-03T12:43:42.3944122' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (115, N'Comandos', N'Envio Comando Por Local', CAST(N'2023-01-03T12:43:51.8422223' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (116, N'Comandos', N'Envio Comando Por Lista', CAST(N'2023-01-03T13:44:00.4924908' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (117, N'Comandos', N'Excluiu -> Resetar', CAST(N'2023-01-03T13:45:29.6409693' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (118, N'Comandos', N'Envio Comando Por Local', CAST(N'2023-01-03T13:54:52.8913625' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (119, N'Comandos', N'Envio Comando Por Local', CAST(N'2023-01-03T13:55:00.6187558' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (120, N'Reset', N'Reset Por Termianal', CAST(N'2023-01-03T14:29:15.6453054' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (121, N'Comandos', N'Reset Por Lista', CAST(N'2023-01-03T14:30:55.8901800' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (122, N'Reset', N'Reset Por Local', CAST(N'2023-01-03T14:31:03.4692768' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (123, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-01-03T16:26:17.3662720' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (124, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-01-03T16:27:59.8487854' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (125, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-01-03T16:50:15.1060774' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (126, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-01-03T16:55:29.8739214' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (127, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-01-03T16:58:02.8143078' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (128, N'Comandos', N'Reset Por Lista', CAST(N'2023-01-03T21:50:56.1042051' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (129, N'Reset', N'Reset Por Local', CAST(N'2023-01-03T21:51:02.8315591' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (130, N'Reset', N'Reset Por Termianal', CAST(N'2023-01-03T21:51:54.0796110' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (131, N'Reset', N'Reset Por Local', CAST(N'2023-01-03T21:54:26.6081976' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (132, N'Reset', N'Reset Por Local', CAST(N'2023-01-03T21:54:41.3526667' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (133, N'Comandos', N'Reset Por Lista', CAST(N'2023-01-03T21:58:52.1813242' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (134, N'Reset', N'Reset Por Local', CAST(N'2023-01-03T21:58:59.1135453' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (135, N'Reset', N'Reset Por Termianal', CAST(N'2023-01-03T21:59:03.7769090' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (136, N'Comandos', N'Envio Comando Por Lista', CAST(N'2023-01-03T22:16:23.0301665' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (137, N'Comandos', N'Envio Comando Por Lista', CAST(N'2023-01-03T22:17:34.9788010' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (138, N'Comandos', N'Envio Comando Por Lista', CAST(N'2023-01-03T22:18:09.5345824' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (139, N'Comandos', N'Envio Comando Por Local', CAST(N'2023-01-03T22:20:28.8825315' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (140, N'Comandos', N'Envio Comando Por Termianal', CAST(N'2023-01-03T22:20:38.5407025' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (141, N'Reset', N'Reset Por Local', CAST(N'2023-01-03T22:23:53.8404360' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (142, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-01-03T22:24:26.1084479' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (143, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-01-03T22:27:29.8596927' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (144, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-01-03T22:27:38.3900415' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (145, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-01-03T22:27:46.5368259' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (146, N'Comandos', N'Envio Comando Por Local', CAST(N'2023-01-03T22:30:26.1018614' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (147, N'Comandos', N'Reset Por Lista', CAST(N'2023-01-03T22:30:35.9334768' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (148, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-01-03T22:34:58.7672642' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (149, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-01-03T22:35:21.8999494' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (150, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-01-03T22:35:33.8244969' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (151, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-01-03T22:35:52.4525489' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (152, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-01-03T22:36:18.6355965' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (153, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-01-03T22:36:25.1696710' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (154, N'Comandos', N'Envio Comando Por Termianal', CAST(N'2023-01-03T22:38:10.6998191' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (155, N'Comandos', N'Envio Comando Por Local', CAST(N'2023-01-03T22:38:18.0628303' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (156, N'Reset', N'Reset Por Termianal', CAST(N'2023-01-03T22:39:23.5103447' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (157, N'Reset', N'Reset Por Local', CAST(N'2023-01-03T22:39:32.4794374' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (158, N'Comandos', N'Reset Por Lista', CAST(N'2023-01-03T22:39:39.2079826' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (159, N'Terminais', N'Excluiu -> 10001000A', CAST(N'2023-01-11T21:30:13.6642603' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (160, N'Terminais', N'Excluiu -> 10001001', CAST(N'2023-01-11T21:30:16.1403412' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (161, N'Terminais', N'Excluiu -> 11112222', CAST(N'2023-01-11T21:30:18.6361806' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (162, N'Terminais', N'Excluiu -> 20001002', CAST(N'2023-01-11T21:30:21.1464220' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (163, N'Terminais', N'Excluiu -> 30010001', CAST(N'2023-01-11T21:30:23.3921835' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (164, N'Terminais', N'Excluiu -> 50005001', CAST(N'2023-01-11T21:30:25.7142515' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (165, N'Terminais', N'Excluiu -> 56781000', CAST(N'2023-01-11T21:30:28.0260081' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (166, N'Local', N'Criou -> Ag Jaguare', CAST(N'2023-01-11T21:30:57.2055595' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (167, N'Local', N'Editou -> Ag Jaguare', CAST(N'2023-01-11T21:31:07.0310321' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (168, N'Terminais', N'Criou -> 10010001', CAST(N'2023-01-11T21:49:12.3382936' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (169, N'Terminais', N'Criou -> 20010002', CAST(N'2023-01-11T22:01:23.9768914' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (170, N'Terminais', N'Criou -> 30010001', CAST(N'2023-01-11T22:01:42.6816294' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (171, N'Terminais', N'Criou -> 40010004', CAST(N'2023-01-11T22:02:11.3464425' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (172, N'Terminais', N'Criou -> 50005777', CAST(N'2023-01-11T22:03:54.9638313' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (173, N'Terminais', N'Editou -> 50005777', CAST(N'2023-01-11T22:04:01.5220870' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (174, N'Terminais', N'Editou -> 20010002', CAST(N'2023-01-11T22:04:07.9088491' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (175, N'ListaEnvio', N'Excluiu -> teste', CAST(N'2023-01-11T22:07:17.4665424' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (176, N'ListaEnvio', N'Excluiu -> xxxx', CAST(N'2023-01-11T22:07:19.0769613' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (177, N'Comandos', N'Reset Por Lista', CAST(N'2023-01-11T22:10:09.1455922' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (178, N'Comandos', N'Envio Comando Por Local', CAST(N'2023-01-11T22:10:20.3747949' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (179, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-01-11T22:10:37.4194258' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (180, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-01-11T22:10:44.3894811' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (181, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-01-11T22:10:51.5171675' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (182, N'Modelos', N'Criou -> ATM_FULL', CAST(N'2023-01-12T01:48:33.9085996' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (183, N'Modelos', N'Criou -> Parcial', CAST(N'2023-01-12T01:56:03.7802930' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (184, N'Pacotes', N'Editou -> ATM_FULL', CAST(N'2023-01-12T02:29:31.3071732' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (185, N'Pacotes', N'Editou -> ATM_FULL', CAST(N'2023-01-12T02:29:38.0993822' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (186, N'Pacotes', N'Editou -> ATM_FULL', CAST(N'2023-01-12T02:31:06.2102920' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (187, N'Pacotes', N'Editou -> Parcial', CAST(N'2023-01-12T02:31:11.2313299' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (188, N'Pacotes', N'Editou -> ATM_FULL', CAST(N'2023-01-12T02:31:17.6708786' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (189, N'Pacotes', N'Editou -> ATM_FULL', CAST(N'2023-01-12T02:31:22.2387239' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (190, N'Pacotes', N'Editou -> Parcial', CAST(N'2023-01-12T02:34:01.2422855' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (191, N'Pacotes', N'Editou -> Parcial', CAST(N'2023-01-12T02:34:07.7323909' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (192, N'Pacotes', N'Editou -> Parcial', CAST(N'2023-01-12T02:34:53.1787788' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (193, N'Pacotes', N'Editou -> ATM_FULL', CAST(N'2023-01-12T21:03:05.0905903' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (194, N'Pacotes', N'Editou -> ATM_FULL', CAST(N'2023-01-12T21:03:15.7845606' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (195, N'Pacotes', N'Excluiu -> Parcial', CAST(N'2023-01-12T21:17:12.8686342' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (196, N'Modelos', N'Criou -> Atm Parcia', CAST(N'2023-01-12T21:17:54.1594081' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (197, N'Pacotes', N'Editou -> Atm Parcia', CAST(N'2023-01-12T21:18:03.3011200' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (198, N'Pacotes', N'Editou -> Atm Parcia', CAST(N'2023-01-12T21:19:33.3720896' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (199, N'Pacotes', N'Editou -> Atm Parcia', CAST(N'2023-01-12T22:19:39.8879002' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (200, N'Comandos', N'Envio Pacotes Por Lista', CAST(N'2023-01-12T22:24:25.9698548' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (201, N'Comandos', N'Envio Pacotes Por Lista', CAST(N'2023-01-12T22:24:33.4680236' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (202, N'Comandos', N'Envio Pacotes Por Lista', CAST(N'2023-01-18T18:11:35.6968872' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (203, N'Pacotes', N'Envio Pacotes Por Termianal', CAST(N'2023-01-18T18:13:48.8269227' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (204, N'Pacotes', N'Envio Pacotes Por Local', CAST(N'2023-01-18T18:17:17.1004712' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (205, N'ListaEnvio', N'Editou -> Piloto', CAST(N'2023-01-18T18:46:34.5238121' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (206, N'Lista de Envios', N'Criou -> fff', CAST(N'2023-01-18T18:46:45.7118875' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (207, N'ListaEnvio', N'Excluiu -> fff', CAST(N'2023-01-18T18:46:51.4465002' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (208, N'Comandos', N'Envio Pacotes Por Lista', CAST(N'2023-01-18T18:49:22.1533427' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (209, N'Pacotes', N'Envio Pacotes Por Local', CAST(N'2023-01-18T18:51:06.9249575' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (210, N'Pacotes', N'Envio Pacotes Por Termianal', CAST(N'2023-01-18T18:51:22.1650000' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (211, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-01-18T18:55:29.2546521' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (212, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-01-18T18:55:50.7729714' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (213, N'Comandos', N'Envio Comando Por Lista', CAST(N'2023-01-18T19:26:44.5588071' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (214, N'Reset', N'Reset Por Termianal', CAST(N'2023-02-08T13:17:48.4099585' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (215, N'Reset', N'Reset Por Termianal', CAST(N'2023-02-08T13:17:53.4714596' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (216, N'Reset', N'Reset Por Local', CAST(N'2023-02-08T13:26:48.1604083' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (217, N'Reset', N'Reset Por Lista', CAST(N'2023-02-08T13:26:54.6879634' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (218, N'Logs', N'Criou -> teste1', CAST(N'2023-02-08T11:57:13.6329194' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (219, N'Logs', N'Criou -> teste01_[]', CAST(N'2023-02-08T11:58:22.5762328' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (220, N'Logs', N'Criou -> aplic', CAST(N'2023-02-08T14:29:39.3762987' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (221, N'Logs', N'Criou -> c', CAST(N'2023-02-08T14:34:42.4310647' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (222, N'Logs', N'Excluiu -> c', CAST(N'2023-02-08T14:34:58.0666966' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (223, N'Logs', N'Criou -> ATM FULL', CAST(N'2023-02-08T17:02:28.0818042' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (224, N'Logs', N'Criou -> ATM FULL44', CAST(N'2023-02-08T17:22:03.9641693' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (225, N'Logs', N'Criou -> fff', CAST(N'2023-02-08T17:45:37.2025172' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (226, N'Logs', N'Criou -> Agencia Ceasa', CAST(N'2023-02-08T18:03:07.4761381' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (227, N'Logs', N'Excluiu -> Agencia Ceasa', CAST(N'2023-02-08T18:03:13.2524146' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (228, N'Logs', N'Excluiu -> aplic', CAST(N'2023-02-09T09:57:40.3732984' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (229, N'Logs', N'Excluiu -> ATM FULL', CAST(N'2023-02-09T09:57:42.8139678' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (230, N'Logs', N'Excluiu -> ATM FULL44', CAST(N'2023-02-09T09:57:45.2482710' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (231, N'Logs', N'Excluiu -> fff', CAST(N'2023-02-09T09:57:47.5767101' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (232, N'Logs', N'Excluiu -> teste01_[]', CAST(N'2023-02-09T09:57:50.8701627' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (233, N'Logs', N'Excluiu -> teste1', CAST(N'2023-02-09T09:57:53.1135376' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (234, N'Logs', N'Criou -> Atm_[]', CAST(N'2023-02-09T10:00:44.7217073' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (235, N'Logs', N'Criou -> ATM FULL44', CAST(N'2023-02-09T10:45:27.3557591' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (236, N'Logs', N'Excluiu -> ATM FULL44', CAST(N'2023-02-09T10:45:44.3958925' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (237, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-09T14:35:14.8994535' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (238, N'Logs', N'Criou -> ATM FULL44', CAST(N'2023-02-09T11:38:19.9592269' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (239, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-09T14:44:36.9464397' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (240, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-09T14:45:24.2211647' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (241, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-09T14:46:52.2810355' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (242, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-09T15:13:19.1155598' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (243, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-09T15:21:50.1265842' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (244, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-09T15:23:55.2479339' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (245, N'Logs', N'Criou -> ATM FULL', CAST(N'2023-02-09T12:24:44.8832106' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (246, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-09T15:24:52.3251221' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (247, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-09T15:25:49.5514571' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (248, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-09T15:25:50.7155917' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (249, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-09T15:25:59.6946059' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (250, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-09T15:28:43.8214610' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (251, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-09T15:33:02.1178776' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (252, N'Logs', N'Excluiu -> ATM FULL', CAST(N'2023-02-09T12:33:45.3603997' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (253, N'Logs', N'Excluiu -> ATM FULL44', CAST(N'2023-02-09T12:33:47.4044276' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (254, N'Logs', N'Excluiu -> Atm_[]', CAST(N'2023-02-09T12:33:49.4520934' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (255, N'Logs', N'Criou -> c:\log', CAST(N'2023-02-09T12:34:24.7996936' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (256, N'Logs', N'Criou -> atm_[]', CAST(N'2023-02-09T12:35:02.9966507' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (257, N'Logs', N'Criou -> teste01', CAST(N'2023-02-09T12:35:58.1832959' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (258, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-09T15:40:43.2629700' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (259, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-09T15:42:17.1429641' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (260, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-09T15:43:31.6382275' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (261, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-09T15:56:54.0905769' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (262, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-09T16:47:19.8281201' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (263, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-09T16:51:25.6258852' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (264, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-09T16:53:27.4372672' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (265, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-09T16:54:01.5298340' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (266, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-09T16:56:50.8109070' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (267, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-09T17:03:17.7018864' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (268, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-09T17:04:44.2959825' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (269, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-09T17:41:05.0681915' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (270, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-09T17:42:47.7576458' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (271, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-09T17:43:02.6859468' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (272, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-09T17:43:45.6751258' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (273, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-09T17:44:04.6202038' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (274, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-09T17:44:24.8358945' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (275, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-09T17:47:41.8711041' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (276, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-09T17:48:30.2782034' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (277, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-09T17:49:04.2565850' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (278, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-09T19:00:36.4325775' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (279, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-09T19:00:59.5978627' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (280, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-09T19:01:31.3774365' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (281, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-09T19:02:32.8770041' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (282, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-09T19:03:29.4592551' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (283, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-09T19:08:38.2246054' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (284, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-09T19:08:59.4511932' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (285, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-09T19:09:25.4298923' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (286, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-09T19:10:44.8074473' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (287, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-09T19:11:23.6815174' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (288, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-09T19:12:29.8138619' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (289, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-09T19:25:07.5257199' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (290, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-09T19:27:00.3637856' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (291, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-09T19:27:25.0046112' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (292, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-09T19:39:24.1204410' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (293, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-09T19:39:43.0630498' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (294, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-09T19:41:41.1156418' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (295, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-09T19:42:04.7819567' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (296, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-09T19:42:44.6482917' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (297, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-09T19:42:58.3067288' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (298, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-09T19:43:28.4931767' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (299, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-09T19:43:49.7478413' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (300, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-09T19:44:23.5870234' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (301, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-09T19:45:02.6561626' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (302, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-09T19:45:31.7621060' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (303, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-09T19:45:56.7142934' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (304, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-09T19:46:24.3440402' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (305, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-09T19:46:50.1997992' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (306, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-09T19:47:13.5558345' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (307, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-09T19:53:27.1885843' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (308, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-09T19:54:30.1272028' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (309, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-09T19:56:15.4986549' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (310, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-09T19:56:22.8611772' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (311, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-09T19:56:32.3254334' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (312, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-09T19:56:43.4274022' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (313, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-09T20:36:01.7000224' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (314, N'Reset', N'Reset Por Termianal', CAST(N'2023-02-10T00:47:47.4327630' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (315, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-10T00:48:26.4542368' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (316, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-10T00:48:36.0083780' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (317, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-10T00:48:46.5860818' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (318, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-10T00:55:26.3930363' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (319, N'Links', N'Criou -> Link', CAST(N'2023-02-09T22:39:44.0930118' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (320, N'Links', N'Excluiu -> Link', CAST(N'2023-02-09T22:39:54.2653566' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (321, N'Logs', N'Editou -> teste01', CAST(N'2023-02-09T22:43:20.1423730' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (322, N'Logs', N'Editou -> teste01', CAST(N'2023-02-09T22:43:33.9993826' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (323, N'Logs', N'Editou -> teste01', CAST(N'2023-02-09T22:43:41.1982195' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (324, N'Logs', N'Editou -> atm_[]', CAST(N'2023-02-09T22:43:51.4710714' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (325, N'Logs', N'Editou -> atm_[]', CAST(N'2023-02-09T22:43:58.6383008' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (326, N'Logs', N'Editou -> c:\log', CAST(N'2023-02-09T22:44:04.8276625' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (327, N'Logs', N'Editou -> c:\log', CAST(N'2023-02-09T22:44:10.7163876' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (328, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-10T01:44:49.2026853' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (329, N'Comando', N'Criou -> aaa', CAST(N'2023-02-09T23:14:15.4040693' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (330, N'Comandos', N'Excluiu -> aaa', CAST(N'2023-02-09T23:14:21.0429661' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (331, N'Comando', N'Criou -> fff', CAST(N'2023-02-09T23:14:39.8671897' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (332, N'Comando', N'Criou -> d', CAST(N'2023-02-09T23:20:08.0395777' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (333, N'Comandos', N'Editou -> d', CAST(N'2023-02-09T23:29:49.5501380' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (334, N'Comandos', N'Editou -> d', CAST(N'2023-02-09T23:30:48.9684033' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (335, N'Comandos', N'Excluiu -> d', CAST(N'2023-02-09T23:31:09.7802955' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (336, N'Comandos', N'Editou -> fff', CAST(N'2023-02-09T23:32:29.6026450' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (337, N'Comandos', N'Excluiu -> fff', CAST(N'2023-02-09T23:32:43.6565233' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (338, N'Comandos', N'Excluiu -> LimpaLog', CAST(N'2023-02-10T00:34:14.3234706' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (339, N'Comandos', N'Excluiu -> teste', CAST(N'2023-02-10T00:34:16.6739652' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (340, N'Comando', N'Criou -> teste1', CAST(N'2023-02-10T00:36:28.6349701' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (341, N'Comandos', N'Editou -> teste1', CAST(N'2023-02-10T00:37:39.5984043' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (342, N'Comandos', N'Editou -> teste1', CAST(N'2023-02-10T00:37:50.4132289' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (343, N'Comandos', N'Envio Comando Por Termianal', CAST(N'2023-02-10T04:02:26.9844854' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (344, N'Comandos', N'Envio Comando Por Termianal', CAST(N'2023-02-10T04:02:51.7145477' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (345, N'Comando', N'Criou -> script2', CAST(N'2023-02-10T01:03:30.7195892' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (346, N'Comandos', N'Envio Comando Por Termianal', CAST(N'2023-02-10T04:03:42.9387418' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (347, N'Comandos', N'Envio Comando Por Local', CAST(N'2023-02-10T04:08:56.3592054' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (348, N'Comandos', N'Envio Comando Por Local', CAST(N'2023-02-10T04:09:34.8218830' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (349, N'Comandos', N'Envio Comando Por Local', CAST(N'2023-02-10T04:09:56.1017759' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (350, N'Comandos', N'Envio Comando Por Lista', CAST(N'2023-02-10T04:12:08.4529535' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (351, N'Comandos', N'Envio Comando Por Lista', CAST(N'2023-02-10T04:12:55.9996505' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (352, N'Comandos', N'Envio Comando Por Lista', CAST(N'2023-02-10T04:14:04.5489753' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (353, N'Comandos', N'Envio Comando Por Termianal', CAST(N'2023-02-10T04:39:11.9928356' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (354, N'Comandos', N'Envio Comando Por Local', CAST(N'2023-02-10T04:39:21.0783855' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (355, N'Comandos', N'Envio Comando Por Lista', CAST(N'2023-02-10T04:39:27.9147038' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (356, N'Comandos', N'Envio Comando Por Lista', CAST(N'2023-02-10T04:42:04.9505733' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (357, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-10T11:54:17.7155032' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (358, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-10T11:56:11.2820653' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (359, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-10T11:56:30.9551509' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (360, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-10T12:07:16.6854991' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (361, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-10T12:11:12.7285462' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (362, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-10T12:12:03.1532301' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (363, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-10T12:12:19.0509889' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (364, N'Busca Logs', N'Busca Por Termianal', CAST(N'2023-02-10T12:12:40.0864023' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (365, N'Pacotes', N'Envio Pacotes Por Termianal', CAST(N'2023-02-10T12:44:11.6612394' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (366, N'Pacotes', N'Envio Pacotes Por Termianal', CAST(N'2023-02-10T13:03:54.0663462' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (367, N'Pacotes', N'Envio Pacotes Por Termianal', CAST(N'2023-02-10T13:29:09.7600912' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (368, N'Pacotes', N'Envio Pacotes Por Termianal', CAST(N'2023-02-10T13:40:12.1123812' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (369, N'Pacotes', N'Envio Pacotes Por Termianal', CAST(N'2023-02-10T13:40:32.8601034' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (370, N'Pacotes', N'Envio Pacotes Por Termianal', CAST(N'2023-02-10T13:40:56.6287986' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (371, N'Pacotes', N'Envio Pacotes Por Termianal', CAST(N'2023-02-10T13:54:39.2574390' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (372, N'Pacotes', N'Envio Pacotes Por Termianal', CAST(N'2023-02-10T13:55:59.9919262' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (373, N'Pacotes', N'Envio Pacotes Por Termianal', CAST(N'2023-02-10T13:56:30.2513020' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (374, N'Pacotes', N'Envio Pacotes Por Termianal', CAST(N'2023-02-10T14:03:54.1507025' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (375, N'Pacotes', N'Envio Pacotes Por Termianal', CAST(N'2023-02-10T14:04:05.4470321' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (376, N'Pacotes', N'Envio Pacotes Por Termianal', CAST(N'2023-02-10T14:04:16.3505677' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (377, N'Pacotes', N'Envio Pacotes Por Local', CAST(N'2023-02-10T14:04:38.7635949' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (378, N'Pacotes', N'Envio Pacotes Por Local', CAST(N'2023-02-10T14:05:05.0803042' AS DateTime2), N'Boffelli')
GO
INSERT [dbo].[LogAuditoria] ([LogAuditoriaId], [Modulo], [Detalhe], [Data], [Usuario]) VALUES (379, N'Comandos', N'Envio Pacotes Por Lista', CAST(N'2023-02-10T14:05:30.3099699' AS DateTime2), N'Boffelli')
GO
SET IDENTITY_INSERT [dbo].[LogAuditoria] OFF
GO
SET IDENTITY_INSERT [dbo].[Modelo] ON 
GO
INSERT [dbo].[Modelo] ([ModeloId], [Nome], [Descricao], [Fabricante], [SistemaOperacional]) VALUES (1, N'ATM FULL', N'ATM FUL FUNCTION', N'PERTO', N'Win10')
GO
INSERT [dbo].[Modelo] ([ModeloId], [Nome], [Descricao], [Fabricante], [SistemaOperacional]) VALUES (2, N'ATM SLIN', N'atm', N'Diebold', N'Win10')
GO
INSERT [dbo].[Modelo] ([ModeloId], [Nome], [Descricao], [Fabricante], [SistemaOperacional]) VALUES (3, N'CAIXA', N'caixa agencia', N'PERTO', N'win8')
GO
SET IDENTITY_INSERT [dbo].[Modelo] OFF
GO
SET IDENTITY_INSERT [dbo].[Pacote] ON 
GO
INSERT [dbo].[Pacote] ([PacoteId], [Nome], [Descricao], [Caminho], [Versao], [Prod]) VALUES (1, N'ATM_FULL', N'ATM FUL FUNCTION', N'C:\aplic\teste', 101, 1)
GO
INSERT [dbo].[Pacote] ([PacoteId], [Nome], [Descricao], [Caminho], [Versao], [Prod]) VALUES (3, N'Atm Parcia', N'Versão parcial', N'C:\aplic', 102, 1)
GO
SET IDENTITY_INSERT [dbo].[Pacote] OFF
GO
SET IDENTITY_INSERT [dbo].[Reset] ON 
GO
INSERT [dbo].[Reset] ([Id_sequencia], [TerminalId], [StatusId], [TipoReset], [DataCadastro], [DataAtualizacao], [StrLog]) VALUES (1, 11, 1, 1, CAST(N'2023-02-08T10:17:48.167' AS DateTime), CAST(N'2023-02-08T10:17:48.167' AS DateTime), NULL)
GO
INSERT [dbo].[Reset] ([Id_sequencia], [TerminalId], [StatusId], [TipoReset], [DataCadastro], [DataAtualizacao], [StrLog]) VALUES (2, 12, 2, 0, CAST(N'2023-02-08T10:17:53.463' AS DateTime), CAST(N'2023-02-08T10:17:53.463' AS DateTime), NULL)
GO
INSERT [dbo].[Reset] ([Id_sequencia], [TerminalId], [StatusId], [TipoReset], [DataCadastro], [DataAtualizacao], [StrLog]) VALUES (3, 13, 3, 1, CAST(N'2023-02-08T10:26:48.150' AS DateTime), CAST(N'2023-02-08T10:26:48.150' AS DateTime), NULL)
GO
INSERT [dbo].[Reset] ([Id_sequencia], [TerminalId], [StatusId], [TipoReset], [DataCadastro], [DataAtualizacao], [StrLog]) VALUES (4, 11, 4, 0, CAST(N'2023-02-08T10:26:54.670' AS DateTime), CAST(N'2023-02-08T10:26:54.670' AS DateTime), NULL)
GO
INSERT [dbo].[Reset] ([Id_sequencia], [TerminalId], [StatusId], [TipoReset], [DataCadastro], [DataAtualizacao], [StrLog]) VALUES (5, 12, 0, 0, CAST(N'2023-02-08T10:26:54.673' AS DateTime), CAST(N'2023-02-08T10:26:54.673' AS DateTime), NULL)
GO
INSERT [dbo].[Reset] ([Id_sequencia], [TerminalId], [StatusId], [TipoReset], [DataCadastro], [DataAtualizacao], [StrLog]) VALUES (6, 13, 0, 0, CAST(N'2023-02-08T10:26:54.677' AS DateTime), CAST(N'2023-02-08T10:26:54.677' AS DateTime), NULL)
GO
INSERT [dbo].[Reset] ([Id_sequencia], [TerminalId], [StatusId], [TipoReset], [DataCadastro], [DataAtualizacao], [StrLog]) VALUES (7, 14, 0, 0, CAST(N'2023-02-08T10:26:54.680' AS DateTime), CAST(N'2023-02-08T10:26:54.680' AS DateTime), NULL)
GO
INSERT [dbo].[Reset] ([Id_sequencia], [TerminalId], [StatusId], [TipoReset], [DataCadastro], [DataAtualizacao], [StrLog]) VALUES (8, 15, 0, 0, CAST(N'2023-02-08T10:26:54.683' AS DateTime), CAST(N'2023-02-08T10:26:54.683' AS DateTime), NULL)
GO
INSERT [dbo].[Reset] ([Id_sequencia], [TerminalId], [StatusId], [TipoReset], [DataCadastro], [DataAtualizacao], [StrLog]) VALUES (9, 11, 0, 0, CAST(N'2023-02-09T21:47:47.110' AS DateTime), CAST(N'2023-02-09T21:47:47.110' AS DateTime), NULL)
GO
SET IDENTITY_INSERT [dbo].[Reset] OFF
GO
SET IDENTITY_INSERT [dbo].[Script] ON 
GO
INSERT [dbo].[Script] ([Id_sequencia], [NomeComando], [TerminalId], [StatusId], [ScrConteudo], [DataCadastro], [DataAtualizacao], [StrLog]) VALUES (1, N'script2', 11, 1, N'cls
dir c:\aplic
', CAST(N'2023-02-10T01:39:11.607' AS DateTime), CAST(N'2023-02-10T01:39:11.607' AS DateTime), N'')
GO
INSERT [dbo].[Script] ([Id_sequencia], [NomeComando], [TerminalId], [StatusId], [ScrConteudo], [DataCadastro], [DataAtualizacao], [StrLog]) VALUES (2, N'script2', 12, 2, N'cls
dir c:\aplic
', CAST(N'2023-02-10T01:39:11.987' AS DateTime), CAST(N'2023-02-10T01:39:11.987' AS DateTime), N'')
GO
INSERT [dbo].[Script] ([Id_sequencia], [NomeComando], [TerminalId], [StatusId], [ScrConteudo], [DataCadastro], [DataAtualizacao], [StrLog]) VALUES (3, N'teste1', 11, 3, N'dir c:\aplic
cd\aplic
start aplic.exe
exit




', CAST(N'2023-02-10T01:39:21.053' AS DateTime), CAST(N'2023-02-10T01:39:21.053' AS DateTime), N'')
GO
INSERT [dbo].[Script] ([Id_sequencia], [NomeComando], [TerminalId], [StatusId], [ScrConteudo], [DataCadastro], [DataAtualizacao], [StrLog]) VALUES (4, N'teste1', 12, 4, N'dir c:\aplic
cd\aplic
start aplic.exe
exit




', CAST(N'2023-02-10T01:39:21.070' AS DateTime), CAST(N'2023-02-10T01:39:21.070' AS DateTime), N'')
GO
INSERT [dbo].[Script] ([Id_sequencia], [NomeComando], [TerminalId], [StatusId], [ScrConteudo], [DataCadastro], [DataAtualizacao], [StrLog]) VALUES (5, N'teste1', 14, 0, N'dir c:\aplic
cd\aplic
start aplic.exe
exit




', CAST(N'2023-02-10T01:39:21.077' AS DateTime), CAST(N'2023-02-10T01:39:21.077' AS DateTime), N'')
GO
INSERT [dbo].[Script] ([Id_sequencia], [NomeComando], [TerminalId], [StatusId], [ScrConteudo], [DataCadastro], [DataAtualizacao], [StrLog]) VALUES (6, N'teste1', 11, 0, N'dir c:\aplic
cd\aplic
start aplic.exe
exit




', CAST(N'2023-02-10T01:39:27.900' AS DateTime), CAST(N'2023-02-10T01:39:27.900' AS DateTime), N'')
GO
INSERT [dbo].[Script] ([Id_sequencia], [NomeComando], [TerminalId], [StatusId], [ScrConteudo], [DataCadastro], [DataAtualizacao], [StrLog]) VALUES (7, N'teste1', 13, 0, N'dir c:\aplic
cd\aplic
start aplic.exe
exit




', CAST(N'2023-02-10T01:39:27.907' AS DateTime), CAST(N'2023-02-10T01:39:27.907' AS DateTime), N'')
GO
INSERT [dbo].[Script] ([Id_sequencia], [NomeComando], [TerminalId], [StatusId], [ScrConteudo], [DataCadastro], [DataAtualizacao], [StrLog]) VALUES (8, N'teste1', 14, 0, N'dir c:\aplic
cd\aplic
start aplic.exe
exit




', CAST(N'2023-02-10T01:39:27.910' AS DateTime), CAST(N'2023-02-10T01:39:27.910' AS DateTime), N'')
GO
INSERT [dbo].[Script] ([Id_sequencia], [NomeComando], [TerminalId], [StatusId], [ScrConteudo], [DataCadastro], [DataAtualizacao], [StrLog]) VALUES (9, N'script2', 11, 0, N'cls
dir c:\aplic
', CAST(N'2023-02-10T01:42:04.937' AS DateTime), CAST(N'2023-02-10T01:42:04.937' AS DateTime), N'')
GO
INSERT [dbo].[Script] ([Id_sequencia], [NomeComando], [TerminalId], [StatusId], [ScrConteudo], [DataCadastro], [DataAtualizacao], [StrLog]) VALUES (10, N'script2', 13, 0, N'cls
dir c:\aplic
', CAST(N'2023-02-10T01:42:04.943' AS DateTime), CAST(N'2023-02-10T01:42:04.943' AS DateTime), N'')
GO
INSERT [dbo].[Script] ([Id_sequencia], [NomeComando], [TerminalId], [StatusId], [ScrConteudo], [DataCadastro], [DataAtualizacao], [StrLog]) VALUES (11, N'script2', 14, 0, N'cls
dir c:\aplic
', CAST(N'2023-02-10T01:42:04.947' AS DateTime), CAST(N'2023-02-10T01:42:04.947' AS DateTime), N'')
GO
SET IDENTITY_INSERT [dbo].[Script] OFF
GO
SET IDENTITY_INSERT [dbo].[Status] ON 
GO
INSERT [dbo].[Status] ([StatusId], [StsDescricao]) VALUES (0, N'Start')
GO
INSERT [dbo].[Status] ([StatusId], [StsDescricao]) VALUES (1, N'Send')
GO
INSERT [dbo].[Status] ([StatusId], [StsDescricao]) VALUES (2, N'ExecuteOk')
GO
INSERT [dbo].[Status] ([StatusId], [StsDescricao]) VALUES (3, N'ExecuteError')
GO
INSERT [dbo].[Status] ([StatusId], [StsDescricao]) VALUES (4, N'ExecuteCRCError')
GO
SET IDENTITY_INSERT [dbo].[Status] OFF
GO
SET IDENTITY_INSERT [dbo].[Tasks] ON 
GO
INSERT [dbo].[Tasks] ([TasksId], [TasksDescricao]) VALUES (0, N'Default')
GO
INSERT [dbo].[Tasks] ([TasksId], [TasksDescricao]) VALUES (1, N'HeartBit')
GO
INSERT [dbo].[Tasks] ([TasksId], [TasksDescricao]) VALUES (2, N'VerificaTask')
GO
INSERT [dbo].[Tasks] ([TasksId], [TasksDescricao]) VALUES (3, N'UploadOnline')
GO
INSERT [dbo].[Tasks] ([TasksId], [TasksDescricao]) VALUES (4, N'UploadDiario')
GO
INSERT [dbo].[Tasks] ([TasksId], [TasksDescricao]) VALUES (5, N'ExecutaScript')
GO
INSERT [dbo].[Tasks] ([TasksId], [TasksDescricao]) VALUES (6, N'ExecutaComandoReset')
GO
INSERT [dbo].[Tasks] ([TasksId], [TasksDescricao]) VALUES (7, N'DownloadPackage')
GO
SET IDENTITY_INSERT [dbo].[Tasks] OFF
GO
SET IDENTITY_INSERT [dbo].[Terminal] ON 
GO
INSERT [dbo].[Terminal] ([TerminalId], [ModeloId], [Codigo], [LocalId], [IP], [DNS], [DefaultGateway], [DtAtualizaao], [Vrs_Distribuida], [Vrs_Instalada], [Status]) VALUES (11, 1, N'10010001', 2, N'100.100.100.100', N'100.100.100.101', N'100.100.100.333', CAST(N'2023-01-11T21:49:11.5538864' AS DateTime2), 100, 0, 0)
GO
INSERT [dbo].[Terminal] ([TerminalId], [ModeloId], [Codigo], [LocalId], [IP], [DNS], [DefaultGateway], [DtAtualizaao], [Vrs_Distribuida], [Vrs_Instalada], [Status]) VALUES (12, 2, N'20010002', 2, N'100.100.100.333', N'100.100.100.100', N'100.100.100.333', CAST(N'2023-01-11T22:04:07.8935935' AS DateTime2), 0, 0, 0)
GO
INSERT [dbo].[Terminal] ([TerminalId], [ModeloId], [Codigo], [LocalId], [IP], [DNS], [DefaultGateway], [DtAtualizaao], [Vrs_Distribuida], [Vrs_Instalada], [Status]) VALUES (13, 2, N'30010001', 3, N'100.100.100.100', N'100.100.100.100', N'100.100.100.100', CAST(N'2023-01-11T22:01:42.6534965' AS DateTime2), 0, 0, 0)
GO
INSERT [dbo].[Terminal] ([TerminalId], [ModeloId], [Codigo], [LocalId], [IP], [DNS], [DefaultGateway], [DtAtualizaao], [Vrs_Distribuida], [Vrs_Instalada], [Status]) VALUES (14, 1, N'40010004', 2, N'100.100.100.555', N'100.100.100.333', N'100.100.100.100', CAST(N'2023-01-11T22:02:11.3225056' AS DateTime2), 0, 0, 0)
GO
INSERT [dbo].[Terminal] ([TerminalId], [ModeloId], [Codigo], [LocalId], [IP], [DNS], [DefaultGateway], [DtAtualizaao], [Vrs_Distribuida], [Vrs_Instalada], [Status]) VALUES (15, 1, N'50005777', 4, N'100.100.100.333', N'100.100.100.100', N'100.100.100.101', CAST(N'2023-01-11T22:04:01.4789558' AS DateTime2), 0, 0, 1)
GO
SET IDENTITY_INSERT [dbo].[Terminal] OFF
GO
SET IDENTITY_INSERT [dbo].[UpLoadOnLine] ON 
GO
INSERT [dbo].[UpLoadOnLine] ([Id_sequencia], [TerminalId], [StatusId], [NomeArquivo], [PathArquivo], [TipoArquivo], [DataArquivo], [MascaraArquivo], [TipoUpload], [DataCadastro], [DataAtualizacao], [StrLog]) VALUES (92, 11, 0, N'atm_[]', N'c:\log\', N'Log', N'10/02/2023', N'yyyy_mm_dd', N'ByDate', CAST(N'2023-02-10T09:12:03.150' AS DateTime), CAST(N'2023-02-10T09:12:03.150' AS DateTime), N'')
GO
INSERT [dbo].[UpLoadOnLine] ([Id_sequencia], [TerminalId], [StatusId], [NomeArquivo], [PathArquivo], [TipoArquivo], [DataArquivo], [MascaraArquivo], [TipoUpload], [DataCadastro], [DataAtualizacao], [StrLog]) VALUES (93, 12, 0, N'atm_[]', N'c:\log\', N'Log', N'17/02/2023', N'yyyy_mm_dd', N'ByDate', CAST(N'2023-02-10T09:12:19.043' AS DateTime), CAST(N'2023-02-10T09:12:19.043' AS DateTime), N'')
GO
INSERT [dbo].[UpLoadOnLine] ([Id_sequencia], [TerminalId], [StatusId], [NomeArquivo], [PathArquivo], [TipoArquivo], [DataArquivo], [MascaraArquivo], [TipoUpload], [DataCadastro], [DataAtualizacao], [StrLog]) VALUES (94, 13, 0, N'atm_[]', N'c:\log\', N'Log', N'10/02/2023|22/02/2023', N'yyyy_mm_dd', N'ByRangeDate', CAST(N'2023-02-10T09:12:40.080' AS DateTime), CAST(N'2023-02-10T09:12:40.080' AS DateTime), N'')
GO
SET IDENTITY_INSERT [dbo].[UpLoadOnLine] OFF
GO
ALTER TABLE [dbo].[DetalheListaEnvio] ADD  DEFAULT ((0)) FOR [TerminalId]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[DetalheListaEnvio]  WITH CHECK ADD  CONSTRAINT [FK_DetalheListaEnvio_ListaEnvio_ListaEnvioId] FOREIGN KEY([ListaEnvioId])
REFERENCES [dbo].[ListaEnvio] ([ListaEnvioId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DetalheListaEnvio] CHECK CONSTRAINT [FK_DetalheListaEnvio_ListaEnvio_ListaEnvioId]
GO
ALTER TABLE [dbo].[DetalheListaEnvio]  WITH CHECK ADD  CONSTRAINT [FK_DetalheListaEnvio_Terminal_TerminalId] FOREIGN KEY([TerminalId])
REFERENCES [dbo].[Terminal] ([TerminalId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DetalheListaEnvio] CHECK CONSTRAINT [FK_DetalheListaEnvio_Terminal_TerminalId]
GO
ALTER TABLE [dbo].[FilaTasks]  WITH CHECK ADD  CONSTRAINT [FK_FilaTasks_Status_StatusId] FOREIGN KEY([StatusId])
REFERENCES [dbo].[Status] ([StatusId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FilaTasks] CHECK CONSTRAINT [FK_FilaTasks_Status_StatusId]
GO
ALTER TABLE [dbo].[FilaTasks]  WITH CHECK ADD  CONSTRAINT [FK_FilaTasks_Tasks_TasksId] FOREIGN KEY([TasksId])
REFERENCES [dbo].[Tasks] ([TasksId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FilaTasks] CHECK CONSTRAINT [FK_FilaTasks_Tasks_TasksId]
GO
ALTER TABLE [dbo].[FilaTasks]  WITH CHECK ADD  CONSTRAINT [FK_FilaTasks_Terminal_TerminalId] FOREIGN KEY([TerminalId])
REFERENCES [dbo].[Terminal] ([TerminalId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FilaTasks] CHECK CONSTRAINT [FK_FilaTasks_Terminal_TerminalId]
GO
ALTER TABLE [dbo].[Local]  WITH CHECK ADD  CONSTRAINT [FK_Local_Link_LinkId] FOREIGN KEY([LinkId])
REFERENCES [dbo].[Link] ([LinkId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Local] CHECK CONSTRAINT [FK_Local_Link_LinkId]
GO
ALTER TABLE [dbo].[Terminal]  WITH CHECK ADD  CONSTRAINT [FK_Terminal_Local_LocalId] FOREIGN KEY([LocalId])
REFERENCES [dbo].[Local] ([LocalId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Terminal] CHECK CONSTRAINT [FK_Terminal_Local_LocalId]
GO
ALTER TABLE [dbo].[Terminal]  WITH CHECK ADD  CONSTRAINT [FK_Terminal_Modelo_ModeloId] FOREIGN KEY([ModeloId])
REFERENCES [dbo].[Modelo] ([ModeloId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Terminal] CHECK CONSTRAINT [FK_Terminal_Modelo_ModeloId]
GO
