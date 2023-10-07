USE [EmployeeDb]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 10/6/2023 5:11:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[EmployeeId] [int] NOT NULL,
	[PayPerHour] [decimal](5, 2) NOT NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Managers]    Script Date: 10/6/2023 5:11:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Managers](
	[ManagerId] [int] NOT NULL,
	[AnnualSalary] [decimal](10, 2) NOT NULL,
	[MaxExpenseAmount] [decimal](10, 2) NOT NULL,
 CONSTRAINT [PK_Managers] PRIMARY KEY CLUSTERED 
(
	[ManagerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supervisors]    Script Date: 10/6/2023 5:11:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supervisors](
	[SupervisorId] [int] NOT NULL,
	[AnnualSalary] [decimal](10, 2) NOT NULL,
 CONSTRAINT [PK_Supervisors] PRIMARY KEY CLUSTERED 
(
	[SupervisorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Workers]    Script Date: 10/6/2023 5:11:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Workers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](30) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Address1] [nvarchar](100) NOT NULL,
	[WorkerTypeId] [int] NOT NULL,
 CONSTRAINT [PK_Workers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorkerTypes]    Script Date: 10/6/2023 5:11:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkerTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_WorkerTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Workers_EmployeeId] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Workers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Workers_EmployeeId]
GO
ALTER TABLE [dbo].[Managers]  WITH CHECK ADD  CONSTRAINT [FK_Managers_Workers_ManagerId] FOREIGN KEY([ManagerId])
REFERENCES [dbo].[Workers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Managers] CHECK CONSTRAINT [FK_Managers_Workers_ManagerId]
GO
ALTER TABLE [dbo].[Supervisors]  WITH CHECK ADD  CONSTRAINT [FK_Supervisors_Workers_SupervisorId] FOREIGN KEY([SupervisorId])
REFERENCES [dbo].[Workers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Supervisors] CHECK CONSTRAINT [FK_Supervisors_Workers_SupervisorId]
GO
ALTER TABLE [dbo].[Workers]  WITH CHECK ADD  CONSTRAINT [FK_Workers_WorkerTypes_WorkerTypeId] FOREIGN KEY([WorkerTypeId])
REFERENCES [dbo].[WorkerTypes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Workers] CHECK CONSTRAINT [FK_Workers_WorkerTypes_WorkerTypeId]
GO
