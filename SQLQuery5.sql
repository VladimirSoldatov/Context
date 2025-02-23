DBCC CHECKIDENT ('dbo.Author', RESEED, 0)
DBCC CHECKIDENT ('dbo.Book', RESEED, 0)
DBCC CHECKIDENT ('dbo.Publisher', RESEED, 0)

delete dbo.Author;
delete dbo.Book
delete dbo.Publisher
