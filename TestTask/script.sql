USE [F:\USERS\ROCKB\SOURCE\REPOS\TESTTASK\TESTTASK\LOCALDB.MDF]
GO
/****** Object:  Table [dbo].[DataTable]    Script Date: 06.07.2024 20:16:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DataTable](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Word] [nvarchar](50) NOT NULL,
	[Counts] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[InsertProcedure]    Script Date: 06.07.2024 20:16:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertProcedure]
	@word nvarchar(50),
	@count int
AS
	INSERT INTO DataTable VALUES (@word, @count)
GO
/****** Object:  StoredProcedure [dbo].[UpdateProcedure]    Script Date: 06.07.2024 20:16:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateProcedure]
	@word nvarchar(50),
	@count int
AS
	UPDATE DataTable SET Counts = @count WHERE Word = @word
GO
