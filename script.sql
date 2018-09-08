use ServicioAndroid;
go
create table ContactosMaviDiegoSait
([id_contacto] int identity(1,1) not null constraint pk_id primary key
,[Nombre] nvarchar(150) not null
,[Tipo Contacto] nchar(1) not null
,[Telefono Fijo] nvarchar(15)
,[Telefono Movil] nvarchar(15) not null
,[Fecha de Nacimiento] date 
,[Sexo] nchar(1) not null
,[Estado Civil] nchar(1) not null
);

GO
use ServicioAndroid
GO
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE sp_contactos_add
	@nombre nvarchar(150),
	@tipo_contacto nchar(1),
	@telefono_movil nvarchar(15),
	@telefono_fijo nvarchar(15),
	@fecha_nacimiento date,
	@sexo nchar(1),
	@estado_civil nchar(1)
AS
BEGIN
INSERT INTO ContactosMaviDiegoSait
           ([Nombre]
           ,[Tipo Contacto]
           ,[Telefono Fijo]
           ,[Telefono Movil]
           ,[Fecha de Nacimiento]
           ,[Sexo]
           ,[Estado Civil])
     VALUES
           (@nombre
           ,@tipo_contacto
           ,@telefono_fijo
           ,@telefono_movil
           ,@fecha_nacimiento
           ,@sexo
           ,@estado_civil)
END


GO
use ServicioAndroid
GO
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE sp_contactos_update
	@nombre nvarchar(150),
	@tipo_contacto nchar(1),
	@telefono_movil nvarchar(15),
	@telefono_fijo nvarchar(15),
	@fecha_nacimiento date,
	@sexo nchar(1),
	@estado_civil nchar(1),
	@id_contacto int
AS
BEGIN
	UPDATE ContactosMaviDiegoSait
	   SET [Nombre] = @nombre
		  ,[Tipo Contacto] = @tipo_contacto
		  ,[Telefono Fijo] = @telefono_fijo
		  ,[Telefono Movil] = @telefono_movil
		  ,[Fecha de Nacimiento] = @fecha_nacimiento
		  ,[Sexo] = @sexo
		  ,[Estado Civil] = @estado_civil
	 WHERE id_contacto=@id_contacto
END



GO
use ServicioAndroid
GO
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE sp_contactos_delete
	@id_contacto int
AS
BEGIN
	DELETE FROM ContactosMaviDiegoSait
		  WHERE id_contacto=@id_contacto
END



GO
use ServicioAndroid
GO
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE sp_contactos_getall
AS
BEGIN
	SET NOCOUNT ON;
	SELECT id_contacto
		  ,Nombre
		  ,[Tipo Contacto]
		  ,[Telefono Fijo]
		  ,[Telefono Movil]
		  ,[Fecha de Nacimiento]
		  ,Sexo
		  ,[Estado Civil]
	  FROM ContactosMaviDiegoSait
END


GO
use ServicioAndroid
GO
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE sp_contactos_getbyid
	@id_contacto int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT id_contacto
		  ,Nombre
		  ,[Tipo Contacto]
		  ,[Telefono Fijo]
		  ,[Telefono Movil]
		  ,[Fecha de Nacimiento]
		  ,Sexo
		  ,[Estado Civil]
	  FROM ContactosMaviDiegoSait
	  where id_contacto=@id_contacto
END

GO
use ServicioAndroid
GO
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE sp_contactos_get_nombre
	@nombre nvarchar(150)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT id_contacto
		  ,Nombre
		  ,[Tipo Contacto]
		  ,[Telefono Fijo]
		  ,[Telefono Movil]
		  ,[Fecha de Nacimiento]
		  ,Sexo
		  ,[Estado Civil]
	  FROM ContactosMaviDiegoSait
	  where Nombre like '%'+@nombre+'%'
END


