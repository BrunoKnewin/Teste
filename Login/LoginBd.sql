/****** Object:  Schema [LGM]    Script Date: 25/04/2021 13:47:00 ******/
CREATE SCHEMA [LGM]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [LGM].[Tokens](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CodigoToken] [nvarchar](max) NULL,
	[LocalidadeId] [bigint] NULL,
	[Ativo] [bit] NOT NULL,
	[DataSecao] [datetime] NOT NULL,
CONSTRAINT [PK_LGM_Tokens] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [LGM].[TokensUsuarios]    Script Date: 25/04/2021 13:47:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [LGM].[TokensUsuarios](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UsuarioId] [bigint] NOT NULL,
	[TokenId] [bigint] NOT NULL,
 CONSTRAINT [PK_LGM.TokensUsuarios] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [LGM].[Usuarios]    Script Date: 25/04/2021 13:47:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [LGM].[Usuarios](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](max) NULL,
	[Senha] [nvarchar](max) NULL,
	[DataUltimaAlteracao] [datetime] NULL,
 CONSTRAINT [PK_LGM.Usuarios] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [LGM].[UsuariosProcessos]    Script Date: 25/04/2021 13:47:00 ******/

ALTER TABLE [LGM].[TokensUsuarios]  WITH CHECK ADD  CONSTRAINT [FK_LGM.Tokens.TokenId] FOREIGN KEY([TokenId])
REFERENCES [LGM].[Tokens] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [LGM].[TokensUsuarios] CHECK CONSTRAINT [FK_LGM.Tokens.TokenId]
GO
ALTER TABLE [LGM].[TokensUsuarios]  WITH CHECK ADD  CONSTRAINT [FK_LGM.TokensUsuarios.UsuarioId] FOREIGN KEY([UsuarioId])
REFERENCES [LGM].[Usuarios] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [LGM].[TokensUsuarios] CHECK CONSTRAINT [FK_LGM.TokensUsuarios.UsuarioId]
GO