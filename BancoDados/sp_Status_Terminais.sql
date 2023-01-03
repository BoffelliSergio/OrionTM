USE [OtmDataBase]
GO
/****** Object:  StoredProcedure [dbo].[sp_Status_Terminais]    Script Date: 26/12/2022 19:57:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER Procedure [dbo].[sp_Status_Terminais]
 
as

begin

DECLARE @tolerancia int

SET @tolerancia = (select Valor from Configuracao where campo = 'Tolerancia_Status');

select 
t.codigo,
m.Nome,
l.Nome,
t.ip,
t.DtAtualizaao,
case
when DATEADD(MI,@tolerancia,t.DtAtualizaao) > getdate() then '1'
else '0'
end as status

from Terminal t
inner join Modelo m on t.ModeloId = m.ModeloId
inner join Local l on t.LocalId = l.LocalId

end



