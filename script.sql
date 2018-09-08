use ServicioAndroid;
go
create table ContatosMaviDiegoSait
([id_contacto] int identity(1,1) not null constraint pk_id primary key
,[Tipo Contacto] nchar(1) not null
,[Telefono Fijo] nvarchar(15)
,[Telefono Movil] nvarchar(15) not null
,[Fecha de Nacimiento] date 
,[Sexo] nchar(1) not null
,[Estado Civil] nchar(1) not null
);