CREATE TABLE [dbo].[Products](
	[ProductID] [int] NOT NULL,
	[ProductName] [varchar](50) NULL,
	[ProductDesc] [varchar](100) NULL,
	[ProductPrice] [float] NULL,
	[ProductImage] [varchar](50) NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

INSERT INTO Products VALUES(1,'PC 1','HP Personal computer',1000,'pc1.jpg')
INSERT INTO Products VALUES(2,'PC 2','Dell Personal computer',1200,'pc2.jpg')
INSERT INTO Products VALUES(3,'PC 3','Apple Mac 1',1400,'pc3.jpg')
INSERT INTO Products VALUES(4,'PC 4','Apple Mac 2',1800,'pc4.jpg')
