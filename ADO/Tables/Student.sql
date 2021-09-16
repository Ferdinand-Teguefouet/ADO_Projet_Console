CREATE TABLE [dbo].[Student]
(
	[Id] INT NOT NULL IDENTITY , 
    [FirstName] VARCHAR(50) NOT NULL, 
    [LastName] VARCHAR(50) NOT NULL, 
    [BirthDate] DATETIME2 NOT NULL, 
    [YearResult] INT NOT NULL, 
    [SectionId] INT NOT NULL, 
    [Active] BIT NOT NULL CONSTRAINT DF_Student_Active DEFAULT (1), 
    CONSTRAINT [PK_Student] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_Student_Section] FOREIGN KEY (SectionId) REFERENCES Section(Id), 
    CONSTRAINT [CK_Student_YearResult] CHECK (YearResult between 0 and 20), 
    CONSTRAINT [CK_Student_BirthDate] CHECK (BirthDate > '1930-01-01')
)

GO

CREATE TRIGGER [dbo].TR_OnDeleteStudent
    ON [dbo].[Student]
    INSTEAD OF DELETE
    AS
    BEGIN
        SET NoCount ON
		Update Student Set Active = 0 where Id in (select Id from deleted);
    END