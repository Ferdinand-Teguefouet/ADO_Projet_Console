CREATE PROCEDURE [dbo].[UpdateStudent]
	@Id int,
	@SectionId int,
	@YearResult int
AS
Begin
	Update Student Set SectionId = @SectionId, YearResult = @YearResult where Id = @Id;
End
