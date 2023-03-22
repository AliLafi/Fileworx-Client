USE [Fileworx]
GO

/****** Object:  Table [dbo].[T_BusinessObject]    Script Date: 3/22/2023 7:04:41 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[T_BusinessObject](
	[C_ID] [int] IDENTITY(1,1) NOT NULL,
	[C_description] [varchar](255) NOT NULL,
	[C_creation_date] [datetime] NOT NULL,
	[C_modify_date] [datetime] NOT NULL,
	[C_name] [varchar](255) NOT NULL,
	[C_class_id] [int] NOT NULL,
	[C_last_modifier] [int] NOT NULL,
	[C_creator] [int] NOT NULL
) ON [PRIMARY]
GO

