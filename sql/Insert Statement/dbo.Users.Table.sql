USE [ASPNETDB]
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserID], [UserEmail], [Password], [FirstName], [LastName], [Active], [role]) VALUES (2, N'deepak@deerwalk.edu.np', N'abc', N'Deepak', N'Lama', 1, N'User')
INSERT [dbo].[Users] ([UserID], [UserEmail], [Password], [FirstName], [LastName], [Active], [role]) VALUES (20, N'anil_0101@deerwalk.edu.np', N'abc', N'Anil', N'Shrestha', 1, N'Admin')
INSERT [dbo].[Users] ([UserID], [UserEmail], [Password], [FirstName], [LastName], [Active], [role]) VALUES (22, N'skarna@deerwalk.com', N'9cQ5D', N'Sweta', N'Karna', 1, N'User')
INSERT [dbo].[Users] ([UserID], [UserEmail], [Password], [FirstName], [LastName], [Active], [role]) VALUES (24, N'bhawana_0105@deerwalk.edu.np', N'z!QmU', N'Bhawana', N'Dahal', 1, N'User')
INSERT [dbo].[Users] ([UserID], [UserEmail], [Password], [FirstName], [LastName], [Active], [role]) VALUES (25, N'pratibh_0104@deerwalk.edu.np', N'mTYyN', N'Pratibh', N'Acharya', 1, N'User')
INSERT [dbo].[Users] ([UserID], [UserEmail], [Password], [FirstName], [LastName], [Active], [role]) VALUES (26, N'sameer_0102@deerwalk.edu.np', N'Le9wB', N'Sameer', N'Shrestha', 1, N'User')
INSERT [dbo].[Users] ([UserID], [UserEmail], [Password], [FirstName], [LastName], [Active], [role]) VALUES (34, N'arun_0103@deerwalk.edu.np', N'M5oUf', N'Arun', N'Amatya', 1, N'User')
SET IDENTITY_INSERT [dbo].[Users] OFF
