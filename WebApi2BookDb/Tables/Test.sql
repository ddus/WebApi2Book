CREATE TABLE [dbo].[Test]
(
	[TestId] BIGINT IDENTITY (1, 1) NOT NULL,
	[Subject] NVARCHAR (100) NOT NULL,
	[StatusId] BIGINT NOT NULL,
	[CreatedDate] DATETIME2 (7) NOT NULL,
	[ts] rowversion NOT NULL,
	PRIMARY KEY CLUSTERED ([TestId] ASC),
	FOREIGN KEY ([StatusId]) REFERENCES [dbo].[Status] ([StatusId])
)
