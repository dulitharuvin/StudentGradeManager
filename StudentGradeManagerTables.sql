--/////////////////////Student Table Schema//////////////////

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'Student')
BEGIN
    CREATE TABLE dbo.Student (
        [StudentID] UNIQUEIDENTIFIER NOT NULL,
        [FirstName] NVARCHAR(200) NOT NULL,
        [LastName] NVARCHAR(250) NOT NULL,
        [Email] NVARCHAR(320) NOT NULL,
        [Nic] NVARCHAR(100) NOT NULL,
		[UserName] NVARCHAR(200) NOT NULL,
		[Password] NVARCHAR(300) NOT NULL,
        [CreatedDate] DATETIME2(7) NULL,
        [UpdatedDate] DATETIME2(7) NULL,
        [Expired] INT NULL,
        CONSTRAINT PK_StudentID PRIMARY KEY (StudentID))
END
 
GO

--/////////////////////Course Table Schema//////////////////

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'Course')
BEGIN
    CREATE TABLE dbo.Course (
        [CourseID] UNIQUEIDENTIFIER NOT NULL,
		[StudentID] UNIQUEIDENTIFIER NOT NULL,
        [CourseTitle] NVARCHAR(300) NOT NULL,
        [CourseDescription] NVARCHAR(350) NULL,
        [CreatedDate] DATETIME2(7) NULL,
        [UpdatedDate] DATETIME2(7) NULL,
        [Expired] INT NULL,
        CONSTRAINT PK_CourseID PRIMARY KEY (CourseID))
END
 
GO

IF NOT EXISTS (SELECT * FROM SYS.FOREIGN_KEYS WHERE OBJECT_ID = OBJECT_ID(N'dbo.FK_Course_Student') AND PARENT_OBJECT_ID = OBJECT_ID(N'dbo.Course'))
BEGIN
    ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_Student] FOREIGN KEY([StudentID])
    REFERENCES [dbo].[Student] ([StudentID])
END
 
GO

--/////////////////////CourseModule Table Schema//////////////////

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'CourseModule')
BEGIN
    CREATE TABLE dbo.CourseModule (
        [CourseModuleID] UNIQUEIDENTIFIER NOT NULL,
		[CourseID] UNIQUEIDENTIFIER NOT NULL,
        [CourseModuleTitle] NVARCHAR(300) NOT NULL,
		[CourseModuleCode] NVARCHAR(200) NOT NULL,
		[CourseModuleCreditValue] FLOAT NOT NULL,
        [CourseModuleDescription] NVARCHAR(350) NULL,
		[ModuleType] INT NOT NULL,
		[Level] INT NOT NULL,
		[ContributedToFinal] BIT NULL,
        [CreatedDate] DATETIME2(7) NULL,
        [UpdatedDate] DATETIME2(7) NULL,
        [Expired] INT NULL,
        CONSTRAINT PK_CourseModuleID PRIMARY KEY (CourseModuleID))
END
 
GO

IF NOT EXISTS (SELECT * FROM SYS.FOREIGN_KEYS WHERE OBJECT_ID = OBJECT_ID(N'dbo.FK_CourseModule_Course') AND PARENT_OBJECT_ID = OBJECT_ID(N'dbo.CourseModule'))
BEGIN
    ALTER TABLE [dbo].[CourseModule]  WITH CHECK ADD  CONSTRAINT [FK_CourseModule_Course] FOREIGN KEY([CourseID])
    REFERENCES [dbo].[Course] ([CourseID])
END
 
GO

--/////////////////////ModuleAssessment Table Schema//////////////////

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'ModuleAssessment')
BEGIN
    CREATE TABLE dbo.ModuleAssessment (
        [ModuleAssessmentID] UNIQUEIDENTIFIER NOT NULL,
		[CourseModuleID] UNIQUEIDENTIFIER NOT NULL,
        [ModuleAssessmentTitle] NVARCHAR(300) NOT NULL,
        [ModuleAssessmentDescription] NVARCHAR(350) NULL,
		[PassingMark] FLOAT NOT NULL,
		[Weighting] FLOAT NOT NULL,
		[AssessmentType] INT NULL,
        [CreatedDate] DATETIME2(7) NULL,
        [UpdatedDate] DATETIME2(7) NULL,
        [Expired] INT NULL,
        CONSTRAINT PK_ModuleAssessmentID PRIMARY KEY (ModuleAssessmentID))
END
 
GO

IF NOT EXISTS (SELECT * FROM SYS.FOREIGN_KEYS WHERE OBJECT_ID = OBJECT_ID(N'dbo.FK_ModuleAssessment_CourseModule') AND PARENT_OBJECT_ID = OBJECT_ID(N'dbo.ModuleAssessment'))
BEGIN
    ALTER TABLE [dbo].[ModuleAssessment]  WITH CHECK ADD  CONSTRAINT [FK_ModuleAssessment_CourseModule] FOREIGN KEY([CourseModuleID])
    REFERENCES [dbo].[CourseModule] ([CourseModuleID])
END
 
GO

--/////////////////////Result Table Schema//////////////////

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'Result')
BEGIN
    CREATE TABLE dbo.Result (
        [ResultID] UNIQUEIDENTIFIER NOT NULL,
		[ModuleAssessmentID] UNIQUEIDENTIFIER NOT NULL,
		[Mark] FLOAT NOT NULL,
		[PredictedMark] FLOAT NOT NULL,
		[Grade] INT NULL,
        [CreatedDate] DATETIME2(7) NULL,
        [UpdatedDate] DATETIME2(7) NULL,
        [Expired] INT NULL,
        CONSTRAINT PK_ResultID PRIMARY KEY (ResultID))
END
 
GO

IF NOT EXISTS (SELECT * FROM SYS.FOREIGN_KEYS WHERE OBJECT_ID = OBJECT_ID(N'dbo.FK_Result_ModuleAssessment') AND PARENT_OBJECT_ID = OBJECT_ID(N'dbo.Result'))
BEGIN
    ALTER TABLE [dbo].[Result]  WITH CHECK ADD  CONSTRAINT [FK_Result_ModuleAssessment] FOREIGN KEY([ModuleAssessmentID])
    REFERENCES [dbo].[ModuleAssessment] ([ModuleAssessmentID])
END
 
GO
