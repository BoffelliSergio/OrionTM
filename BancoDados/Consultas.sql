--select * from ListaEnvio;
--select * from Terminal;
--select * from DetalheListaEnvio order by ListaEnvioId;

select d.DetalheListaEnvioId
      ,l.ListaEnvioId , l.Nome 
      ,t.TerminalId , t.Codigo
  from DetalheListaEnvio as d
  left join ListaEnvio as l on d.ListaEnvioId = l.ListaEnvioId
  left join Terminal as t on t.TerminalId = d.TerminalId
where d.ListaEnvioId = 11
order by l.Nome , t.Codigo asc
;

--delete from DetalheListaEnvio where ListaEnvioId = 14

