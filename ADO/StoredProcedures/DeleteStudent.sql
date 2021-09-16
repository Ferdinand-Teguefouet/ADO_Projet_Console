CREATE PROCEDURE [dbo].[DeleteStudent]
	@Id int
AS
Begin
	Delete From Student where Id = @Id;
End
