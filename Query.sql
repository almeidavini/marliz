insert into Clientes values ('Vinicius', 'Rua Coruripe', '15', 'M', 'vinicius20216@gmail.com', GETDATE());
select * from Clientes;

insert into Enderecos values ('03551020', 'Rua Coruripe', '15', 'Casa 2', 'Cidade Patriarca', 'São Paulo', 'SP', 1);
select * from Enderecos;

insert into Telefones values ('11', '962230911', 1);
select * from Telefones;

insert into Status values('Aguardando produção');
select * from Status;

insert into Pedidos values (GETDATE(), '2022-01-06 19:02:00.000', 1, 1);
select * from Pedidos;

insert into Produtos values ('Bolo de pote', 9.50, 1);
select * from Produtos;

insert into TpUnidades values ('PT', 'Pote');
select * from TpUnidades;

insert into ProdutosPedido values (2, 1, 3);
select * from ProdutosPedido;


select c.Nome, ppp.Descricao, pp.Quantidade from Clientes c
inner join Pedidos p on c.IdCliente = p.ClienteId
inner join ProdutosPedido pp on pp.PedidoId = p.IdPedido
inner join Produtos ppp on ppp.IdProduto = pp.ProdutoId;
