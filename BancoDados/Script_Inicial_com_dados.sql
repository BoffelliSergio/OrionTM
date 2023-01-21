USE [OtmDataBase]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 21/01/2023 15:18:21 ******/
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
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 21/01/2023 15:18:21 ******/
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
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 21/01/2023 15:18:21 ******/
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
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 21/01/2023 15:18:21 ******/
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
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 21/01/2023 15:18:21 ******/
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
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 21/01/2023 15:18:21 ******/
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
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 21/01/2023 15:18:21 ******/
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
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 21/01/2023 15:18:21 ******/
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
/****** Object:  Table [dbo].[Categorias]    Script Date: 21/01/2023 15:18:21 ******/
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
/****** Object:  Table [dbo].[Comando]    Script Date: 21/01/2023 15:18:21 ******/
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
/****** Object:  Table [dbo].[Configuracao]    Script Date: 21/01/2023 15:18:21 ******/
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
/****** Object:  Table [dbo].[DetalheListaEnvio]    Script Date: 21/01/2023 15:18:21 ******/
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
/****** Object:  Table [dbo].[FilaTasks]    Script Date: 21/01/2023 15:18:21 ******/
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
/****** Object:  Table [dbo].[Link]    Script Date: 21/01/2023 15:18:21 ******/
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
/****** Object:  Table [dbo].[ListaEnvio]    Script Date: 21/01/2023 15:18:21 ******/
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
/****** Object:  Table [dbo].[Local]    Script Date: 21/01/2023 15:18:21 ******/
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
/****** Object:  Table [dbo].[Log]    Script Date: 21/01/2023 15:18:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Log](
	[LogId] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](10) NOT NULL,
	[Descricao] [nvarchar](50) NOT NULL,
	[Caminho] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_Log] PRIMARY KEY CLUSTERED 
(
	[LogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LogAuditoria]    Script Date: 21/01/2023 15:18:21 ******/
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
/****** Object:  Table [dbo].[Modelo]    Script Date: 21/01/2023 15:18:21 ******/
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
/****** Object:  Table [dbo].[Pacote]    Script Date: 21/01/2023 15:18:21 ******/
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
/****** Object:  Table [dbo].[Status]    Script Date: 21/01/2023 15:18:21 ******/
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
/****** Object:  Table [dbo].[Tasks]    Script Date: 21/01/2023 15:18:21 ******/
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
/****** Object:  Table [dbo].[Terminal]    Script Date: 21/01/2023 15:18:21 ******/
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
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'14622ef4-7181-4ffa-bce5-9890a7121c8f', N'934993ab-e229-4ca8-9565-d3744c8017f3')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'21159f10-5398-43da-97ed-128ffd8be9f8', N'934993ab-e229-4ca8-9565-d3744c8017f3')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'1248c976-1452-4693-a4ae-39701f0ac498', N'e35d005e-eb70-410e-bba6-81175b87793d')
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
INSERT [dbo].[Comando] ([ComandoId], [Nome], [Descricao], [Caminho]) VALUES (3, N'LimpaLog', N'Limpar a pasta de logs', N'c:\aplic\LimpaLog.bat')
GO
INSERT [dbo].[Comando] ([ComandoId], [Nome], [Descricao], [Caminho]) VALUES (4, N'teste', N'tesr', N'sssss')
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
SET IDENTITY_INSERT [dbo].[FilaTasks] ON 
GO
INSERT [dbo].[FilaTasks] ([FilaTasksId], [TerminalId], [DtAtualizacao], [TasksId], [ComandoId], [LogId], [PacoteId], [StatusId]) VALUES (114, 11, CAST(N'2023-01-11T19:10:08.4785616' AS DateTime2), 6, 0, 0, 0, 0)
GO
INSERT [dbo].[FilaTasks] ([FilaTasksId], [TerminalId], [DtAtualizacao], [TasksId], [ComandoId], [LogId], [PacoteId], [StatusId]) VALUES (115, 13, CAST(N'2023-01-11T19:10:09.1370162' AS DateTime2), 6, 0, 0, 0, 0)
GO
INSERT [dbo].[FilaTasks] ([FilaTasksId], [TerminalId], [DtAtualizacao], [TasksId], [ComandoId], [LogId], [PacoteId], [StatusId]) VALUES (116, 15, CAST(N'2023-01-11T19:10:20.3437338' AS DateTime2), 5, 3, 0, 0, 0)
GO
INSERT [dbo].[FilaTasks] ([FilaTasksId], [TerminalId], [DtAtualizacao], [TasksId], [ComandoId], [LogId], [PacoteId], [StatusId]) VALUES (117, 11, CAST(N'2023-01-11T19:10:37.4082772' AS DateTime2), 3, 0, 1, 0, 0)
GO
INSERT [dbo].[FilaTasks] ([FilaTasksId], [TerminalId], [DtAtualizacao], [TasksId], [ComandoId], [LogId], [PacoteId], [StatusId]) VALUES (118, 11, CAST(N'2023-01-11T19:10:44.3786591' AS DateTime2), 3, 0, 1, 0, 0)
GO
INSERT [dbo].[FilaTasks] ([FilaTasksId], [TerminalId], [DtAtualizacao], [TasksId], [ComandoId], [LogId], [PacoteId], [StatusId]) VALUES (119, 11, CAST(N'2023-01-11T19:10:51.5016604' AS DateTime2), 3, 0, 3, 0, 0)
GO
INSERT [dbo].[FilaTasks] ([FilaTasksId], [TerminalId], [DtAtualizacao], [TasksId], [ComandoId], [LogId], [PacoteId], [StatusId]) VALUES (120, 12, CAST(N'2023-01-11T19:10:51.5077947' AS DateTime2), 3, 0, 3, 0, 0)
GO
INSERT [dbo].[FilaTasks] ([FilaTasksId], [TerminalId], [DtAtualizacao], [TasksId], [ComandoId], [LogId], [PacoteId], [StatusId]) VALUES (121, 14, CAST(N'2023-01-11T19:10:51.5123634' AS DateTime2), 3, 0, 3, 0, 0)
GO
INSERT [dbo].[FilaTasks] ([FilaTasksId], [TerminalId], [DtAtualizacao], [TasksId], [ComandoId], [LogId], [PacoteId], [StatusId]) VALUES (133, 13, CAST(N'2023-01-18T15:11:35.1592670' AS DateTime2), 7, 0, 0, 1, 0)
GO
INSERT [dbo].[FilaTasks] ([FilaTasksId], [TerminalId], [DtAtualizacao], [TasksId], [ComandoId], [LogId], [PacoteId], [StatusId]) VALUES (134, 11, CAST(N'2023-01-18T15:13:48.8013461' AS DateTime2), 7, 0, 0, 3, 0)
GO
INSERT [dbo].[FilaTasks] ([FilaTasksId], [TerminalId], [DtAtualizacao], [TasksId], [ComandoId], [LogId], [PacoteId], [StatusId]) VALUES (135, 15, CAST(N'2023-01-18T15:13:48.8211595' AS DateTime2), 7, 0, 0, 3, 0)
GO
INSERT [dbo].[FilaTasks] ([FilaTasksId], [TerminalId], [DtAtualizacao], [TasksId], [ComandoId], [LogId], [PacoteId], [StatusId]) VALUES (138, 11, CAST(N'2023-01-18T15:17:14.6007348' AS DateTime2), 7, 0, 0, 1, 0)
GO
INSERT [dbo].[FilaTasks] ([FilaTasksId], [TerminalId], [DtAtualizacao], [TasksId], [ComandoId], [LogId], [PacoteId], [StatusId]) VALUES (139, 12, CAST(N'2023-01-18T15:17:16.0518733' AS DateTime2), 7, 0, 0, 1, 0)
GO
INSERT [dbo].[FilaTasks] ([FilaTasksId], [TerminalId], [DtAtualizacao], [TasksId], [ComandoId], [LogId], [PacoteId], [StatusId]) VALUES (140, 14, CAST(N'2023-01-18T15:17:17.0945667' AS DateTime2), 7, 0, 0, 1, 0)
GO
INSERT [dbo].[FilaTasks] ([FilaTasksId], [TerminalId], [DtAtualizacao], [TasksId], [ComandoId], [LogId], [PacoteId], [StatusId]) VALUES (141, 13, CAST(N'2023-01-18T15:49:22.0666366' AS DateTime2), 7, 0, 0, 1, 0)
GO
INSERT [dbo].[FilaTasks] ([FilaTasksId], [TerminalId], [DtAtualizacao], [TasksId], [ComandoId], [LogId], [PacoteId], [StatusId]) VALUES (142, 13, CAST(N'2023-01-18T15:51:06.8994845' AS DateTime2), 7, 0, 0, 1, 0)
GO
INSERT [dbo].[FilaTasks] ([FilaTasksId], [TerminalId], [DtAtualizacao], [TasksId], [ComandoId], [LogId], [PacoteId], [StatusId]) VALUES (143, 11, CAST(N'2023-01-18T15:51:22.1337837' AS DateTime2), 7, 0, 0, 3, 0)
GO
INSERT [dbo].[FilaTasks] ([FilaTasksId], [TerminalId], [DtAtualizacao], [TasksId], [ComandoId], [LogId], [PacoteId], [StatusId]) VALUES (144, 12, CAST(N'2023-01-18T15:51:22.1522623' AS DateTime2), 7, 0, 0, 3, 0)
GO
INSERT [dbo].[FilaTasks] ([FilaTasksId], [TerminalId], [DtAtualizacao], [TasksId], [ComandoId], [LogId], [PacoteId], [StatusId]) VALUES (145, 13, CAST(N'2023-01-18T15:51:22.1586349' AS DateTime2), 7, 0, 0, 3, 0)
GO
INSERT [dbo].[FilaTasks] ([FilaTasksId], [TerminalId], [DtAtualizacao], [TasksId], [ComandoId], [LogId], [PacoteId], [StatusId]) VALUES (146, 12, CAST(N'2023-01-18T15:55:29.2393721' AS DateTime2), 3, 0, 3, 0, 0)
GO
INSERT [dbo].[FilaTasks] ([FilaTasksId], [TerminalId], [DtAtualizacao], [TasksId], [ComandoId], [LogId], [PacoteId], [StatusId]) VALUES (147, 11, CAST(N'2023-01-18T15:55:50.7516106' AS DateTime2), 3, 0, 1, 0, 0)
GO
INSERT [dbo].[FilaTasks] ([FilaTasksId], [TerminalId], [DtAtualizacao], [TasksId], [ComandoId], [LogId], [PacoteId], [StatusId]) VALUES (148, 12, CAST(N'2023-01-18T15:55:50.7594270' AS DateTime2), 3, 0, 1, 0, 0)
GO
INSERT [dbo].[FilaTasks] ([FilaTasksId], [TerminalId], [DtAtualizacao], [TasksId], [ComandoId], [LogId], [PacoteId], [StatusId]) VALUES (149, 14, CAST(N'2023-01-18T15:55:50.7663656' AS DateTime2), 3, 0, 1, 0, 0)
GO
INSERT [dbo].[FilaTasks] ([FilaTasksId], [TerminalId], [DtAtualizacao], [TasksId], [ComandoId], [LogId], [PacoteId], [StatusId]) VALUES (150, 13, CAST(N'2023-01-18T16:26:44.5499793' AS DateTime2), 5, 3, 0, 0, 0)
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
INSERT [dbo].[Log] ([LogId], [Nome], [Descricao], [Caminho]) VALUES (1, N'Atm', N'log aplicação atm', N'c:\aplic\atm.txt')
GO
INSERT [dbo].[Log] ([LogId], [Nome], [Descricao], [Caminho]) VALUES (3, N'atmInter', N'kjhjkhkjhkj', N'C:\interface\dsa.txt')
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
SET IDENTITY_INSERT [dbo].[Status] ON 
GO
INSERT [dbo].[Status] ([StatusId], [StsDescricao]) VALUES (0, N'Start')
GO
INSERT [dbo].[Status] ([StatusId], [StsDescricao]) VALUES (1, N'Starting')
GO
INSERT [dbo].[Status] ([StatusId], [StsDescricao]) VALUES (2, N'Executing')
GO
INSERT [dbo].[Status] ([StatusId], [StsDescricao]) VALUES (3, N'ExecuteOk')
GO
INSERT [dbo].[Status] ([StatusId], [StsDescricao]) VALUES (4, N'ExecuteError')
GO
INSERT [dbo].[Status] ([StatusId], [StsDescricao]) VALUES (5, N'FinishError')
GO
INSERT [dbo].[Status] ([StatusId], [StsDescricao]) VALUES (6, N'FinishOk')
GO
INSERT [dbo].[Status] ([StatusId], [StsDescricao]) VALUES (7, N'DBError')
GO
INSERT [dbo].[Status] ([StatusId], [StsDescricao]) VALUES (8, N'InvalidToken')
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
