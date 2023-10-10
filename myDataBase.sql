USE [myDataBase]
GO

/****** Object:  Table [dbo].[Prodotti]    Script Date: 26/09/2023 14:11:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Prodotti](
	[Id] [int] NOT NULL,
	[Nome] [text] NOT NULL,
	[Prezzo] [decimal](18, 2) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
