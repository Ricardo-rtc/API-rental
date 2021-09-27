USE M_Rental;
GO

INSERT INTO Empresas(NomeEmpresa)
VALUES				('Unidas')
				   ,('Localiza');
GO

INSERT INTO Marcas(NomeMarca)
VALUES			  ('Ford')
				 ,('GM')
				 ,('Fiat');
GO

INSERT INTO Modelos (Descricao, IdMarca)
VALUES			    ('Fiesta', 1)
				   ,('Onix', 2)
				   ,('Argo', 3);
GO

INSERT INTO Veiculos (IdModelo, Placa, IdEmpresa)
VALUES				 (1, 'HEL1805', 1)
					,(2, 'FER1010', 1)
					,(3, 'POR1978', 2)
					,(1, 'LEM9876', 2);
GO

INSERT INTO Clientes(Nome,Sobrenome, CPF)
VALUES				('Saulo','Santos', '99999999999')
				   ,('Caique','Zanneti', '88888888888');
GO

INSERT INTO Alugueis (IdCliente, IdVeiculo, DataInicio, DataFim)
VALUES				 (1, 1, '2019-01-19', '2019-01-20')
					,(1, 2, '2019-01-20', '2019-01-21')
					,(2, 3, '2019-01-21', '2019-01-21')
					,(2, 2, '2019-01-22', '2019-01-22');
GO