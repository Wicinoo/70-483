CREATE TABLE  Applicants(
Id INT IDENTITY(1,1), 
Name varchar(100),
IsActive BIT
)

ALTER TABLE Applicants ADD CONSTRAINT [PK_Applicants] PRIMARY KEY CLUSTERED ([Id])
GO
INSERT INTO[dbo].[Applicants] ([Name], [IsActive]) VALUES(N'Michal Imlauf', 1)
INSERT INTO[dbo].[Applicants] ([Name], [IsActive]) VALUES(N'Viktor Jablonsky', 0)
INSERT INTO[dbo].[Applicants] ([Name], [IsActive]) VALUES(N'Tomas Hanus', 1)
INSERT INTO[dbo].[Applicants] ([Name], [IsActive]) VALUES(N'Maria Dolgikh', 1)
INSERT INTO[dbo].[Applicants] ([Name], [IsActive]) VALUES(N'Alexander Shurupov', 1)
INSERT INTO[dbo].[Applicants] ([Name], [IsActive]) VALUES(N'Jozef Senko', 1)
INSERT INTO[dbo].[Applicants] ([Name], [IsActive]) VALUES(N'Jiri Prochazka', 1)
INSERT INTO[dbo].[Applicants] ([Name], [IsActive]) VALUES(N'Anton Nagy', 1)
INSERT INTO[dbo].[Applicants] ([Name], [IsActive]) VALUES(N'Frantisek Skandera', 1)
INSERT INTO[dbo].[Applicants] ([Name], [IsActive]) VALUES(N'Antonin Kyselak', 1)
INSERT INTO[dbo].[Applicants] ([Name], [IsActive]) VALUES(N'David Mlnarik', 1)
INSERT INTO[dbo].[Applicants] ([Name], [IsActive]) VALUES(N'Martin Gavora', 1)
INSERT INTO[dbo].[Applicants] ([Name], [IsActive]) VALUES(N'Peter Korpel', 1)
INSERT INTO[dbo].[Applicants] ([Name], [IsActive]) VALUES(N'Dusan Kladivik', 1)
INSERT INTO[dbo].[Applicants] ([Name], [IsActive]) VALUES(N'Bedrich Bubik', 1)
INSERT INTO[dbo].[Applicants] ([Name], [IsActive]) VALUES(N'Petr Pospisil', 1)
INSERT INTO[dbo].[Applicants] ([Name], [IsActive]) VALUES(N'Jan Vala', 1)
INSERT INTO[dbo].[Applicants] ([Name], [IsActive]) VALUES(N'Michal Tkacik', 1)
INSERT INTO[dbo].[Applicants] ([Name], [IsActive]) VALUES(N'Dominika Koroncziova', 1)
INSERT INTO[dbo].[Applicants] ([Name], [IsActive]) VALUES(N'Dusan Kajan', 1)
INSERT INTO[dbo].[Applicants] ([Name], [IsActive]) VALUES(N'Michal Spacek', 1)
INSERT INTO[dbo].[Applicants] ([Name], [IsActive]) VALUES(N'Jakub Smolik', 0)
INSERT INTO[dbo].[Applicants] ([Name], [IsActive]) VALUES(N'Martin Habr', 0)
INSERT INTO[dbo].[Applicants] ([Name], [IsActive]) VALUES(N'Michal Kolcarek', 1)
INSERT INTO[dbo].[Applicants] ([Name], [IsActive]) VALUES(N'Radim Honzirek', 1)
INSERT INTO[dbo].[Applicants] ([Name], [IsActive]) VALUES(N'Roman Konecny', 1)
INSERT INTO[dbo].[Applicants] ([Name], [IsActive]) VALUES(N'Robert Dresler', 0)

ALTER TABLE Applicants ADD CONSTRAINT [AK_Applicants] UNIQUE ([Name])
GO