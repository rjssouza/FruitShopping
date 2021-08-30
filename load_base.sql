USE [fruitshoppingdb]

INSERT [dbo].[Fruit] ([Id], [Description], [InventoryId], [Name], [Price]) VALUES (N'ef4b53aa-1c5d-4ea9-8b0d-075112f5baff', N'Banana', NULL, N'Banana', CAST(10.00 AS Decimal(18, 2)));
INSERT [dbo].[Fruit] ([Id], [Description], [InventoryId], [Name], [Price]) VALUES (N'7b5c35a7-1138-4635-ab7a-7a80107123db', N'Maçã', NULL, N'Maçã', CAST(5.00 AS Decimal(18, 2)));
INSERT [dbo].[Fruit] ([Id], [Description], [InventoryId], [Name], [Price]) VALUES (N'2401516f-9ccc-4617-aae5-acbcc716d46d', N'Morango', NULL, N'Morango', CAST(10.00 AS Decimal(18, 2)));
INSERT [dbo].[Fruit] ([Id], [Description], [InventoryId], [Name], [Price]) VALUES (N'a2ee67ed-1607-4833-b4dd-ff8fca23c14c', N'Mamão', NULL, N'Mamão', CAST(5.00 AS Decimal(18, 2)));

INSERT [dbo].[FruitInventory] ([Id], [FruitId], [Quantity]) VALUES (N'1f005f10-89fa-4b32-b0a5-22237b4170f5', N'7b5c35a7-1138-4635-ab7a-7a80107123db', 10);
INSERT [dbo].[FruitInventory] ([Id], [FruitId], [Quantity]) VALUES (N'3d77c06a-be0a-49c8-9dc3-53defb2b281d', N'a2ee67ed-1607-4833-b4dd-ff8fca23c14c', 10);
INSERT [dbo].[FruitInventory] ([Id], [FruitId], [Quantity]) VALUES (N'980a45ca-470b-41ae-a27e-543740f5739d', N'ef4b53aa-1c5d-4ea9-8b0d-075112f5baff', 10);
INSERT [dbo].[FruitInventory] ([Id], [FruitId], [Quantity]) VALUES (N'a0d03e43-c1ae-4f2b-aeef-a122c2a7866a', N'2401516f-9ccc-4617-aae5-acbcc716d46d', 10);

Update [dbo].[Fruit]set [InventoryId] = N'1f005f10-89fa-4b32-b0a5-22237b4170f5' where id = N'7b5c35a7-1138-4635-ab7a-7a80107123db';
Update [dbo].[Fruit]set [InventoryId] = N'3d77c06a-be0a-49c8-9dc3-53defb2b281d' where id = N'a2ee67ed-1607-4833-b4dd-ff8fca23c14c';
Update [dbo].[Fruit]set [InventoryId] = N'980a45ca-470b-41ae-a27e-543740f5739d' where id = N'ef4b53aa-1c5d-4ea9-8b0d-075112f5baff';
Update [dbo].[Fruit]set [InventoryId] = N'a0d03e43-c1ae-4f2b-aeef-a122c2a7866a' where id = N'2401516f-9ccc-4617-aae5-acbcc716d46d';

INSERT [dbo].[FruitPicture] ([Id], [FruitId], [Name], [PictureUrl]) VALUES (N'e241b9a6-26af-48f0-8f39-0a504254e505', N'a2ee67ed-1607-4833-b4dd-ff8fca23c14c', N'Mamão', N'https://www.confianca.com.br/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/1/1/114514-2.jpg')
INSERT [dbo].[FruitPicture] ([Id], [FruitId], [Name], [PictureUrl]) VALUES (N'85be4532-438a-40bf-a8c2-4bb93562f665', N'2401516f-9ccc-4617-aae5-acbcc716d46d', N'Morango', N'https://www.aen.pr.gov.br/modules/galeria/uploads/65329/news_interna_morango_porto_amazonas20120610_0030.jpg')
INSERT [dbo].[FruitPicture] ([Id], [FruitId], [Name], [PictureUrl]) VALUES (N'4a3d67ea-94cc-415f-a697-6ff1e0c46ad6', N'ef4b53aa-1c5d-4ea9-8b0d-075112f5baff', N'Banana', N'https://www.infoescola.com/wp-content/uploads/2010/04/banana_600797891.jpg')
INSERT [dbo].[FruitPicture] ([Id], [FruitId], [Name], [PictureUrl]) VALUES (N'28c72caa-4854-4ea9-b63b-e0910f60229e', N'7b5c35a7-1138-4635-ab7a-7a80107123db', N'Maçã', N'https://cdn.awsli.com.br/600x450/914/914004/produto/36119861/a951cfba84.jpg')