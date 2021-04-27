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