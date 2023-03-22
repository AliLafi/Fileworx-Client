USE [Fileworx]
GO

/****** Object:  Table [dbo].[T_Contact]    Script Date: 3/22/2023 7:04:51 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[T_Contact](
	[ID] [int] NOT NULL,
	[C_receive_file_path] [varchar](255) NULL,
	[C_send_file_path] [varchar](255) NULL,
	[C_last_reception_date] [date] NULL,
	[C_is_read] [bit] NULL,
	[C_is_write] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

