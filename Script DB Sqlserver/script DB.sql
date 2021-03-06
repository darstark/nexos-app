USE [libros]
GO
/****** Object:  Table [dbo].[autor]    Script Date: 13/04/2022 10:19:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[autor](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](250) NOT NULL,
	[fecha_nacimiento] [date] NULL,
	[ciudad_procedencia] [varchar](50) NULL,
	[correo] [varchar](100) NOT NULL,
 CONSTRAINT [PK_autor] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[libro]    Script Date: 13/04/2022 10:19:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[libro](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[titulo] [varchar](100) NOT NULL,
	[fecha] [date] NOT NULL,
	[genero] [varchar](50) NOT NULL,
	[paginas] [int] NOT NULL,
	[id_autor] [int] NOT NULL,
 CONSTRAINT [PK_libro] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[autor] ON 

INSERT [dbo].[autor] ([id], [nombre], [fecha_nacimiento], [ciudad_procedencia], [correo]) VALUES (8, N'J.R.R. Tolkien', CAST(N'1892-01-03' AS Date), N'Sudafrica', N'prueba@prueba.com')
INSERT [dbo].[autor] ([id], [nombre], [fecha_nacimiento], [ciudad_procedencia], [correo]) VALUES (9, N'J.K. Rowling', CAST(N'1996-02-08' AS Date), N'Yate (reino unido)', N'prueba@rowling.com')
INSERT [dbo].[autor] ([id], [nombre], [fecha_nacimiento], [ciudad_procedencia], [correo]) VALUES (10, N'Anna frank', CAST(N'1929-05-12' AS Date), N'Francfort de meno', N'prueba@anna.com')
SET IDENTITY_INSERT [dbo].[autor] OFF
GO
SET IDENTITY_INSERT [dbo].[libro] ON 

INSERT [dbo].[libro] ([id], [titulo], [fecha], [genero], [paginas], [id_autor]) VALUES (28, N'El señor de los anillos', CAST(N'2022-04-11' AS Date), N'Fantasia', 200, 8)
INSERT [dbo].[libro] ([id], [titulo], [fecha], [genero], [paginas], [id_autor]) VALUES (29, N'Harry Potter', CAST(N'2022-04-11' AS Date), N'Fantasia', 300, 9)
INSERT [dbo].[libro] ([id], [titulo], [fecha], [genero], [paginas], [id_autor]) VALUES (30, N'El diario de anna frank', CAST(N'1945-05-23' AS Date), N'Diario ', 150, 10)
SET IDENTITY_INSERT [dbo].[libro] OFF
GO
ALTER TABLE [dbo].[libro]  WITH CHECK ADD  CONSTRAINT [FK_libro_autor] FOREIGN KEY([id_autor])
REFERENCES [dbo].[autor] ([id])
GO
ALTER TABLE [dbo].[libro] CHECK CONSTRAINT [FK_libro_autor]
GO
