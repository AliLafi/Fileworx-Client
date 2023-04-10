USE [Fileworx]
GO

/****** Object:  Table [dbo].[T_Contact]    Script Date: 4/10/2023 9:50:09 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[T_Contact](
	[ID] [int] NOT NULL,
	[C_receive_file_path] [varchar](255) NULL,
	[C_send_file_path] [varchar](255) NULL,
	[C_last_file_reception_date] [date] NULL,
	[C_is_read_file] [bit] NULL,
	[C_is_write_file] [bit] NULL,
	[C_is_read_ftp] [bit] NULL,
	[C_is_write_ftp] [bit] NULL,
	[C_send_ftp_path] [varchar](255) NULL,
	[C_receive_ftp_path] [varchar](255) NULL,
	[C_last_ftp_reception_date] [date] NULL,
	[C_host] [varchar](50) NULL,
	[C_password] [varchar](50) NULL,
	[C_username] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

