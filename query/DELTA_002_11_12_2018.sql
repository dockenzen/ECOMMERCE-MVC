--ACOMODO LA RELACION ENTRE USUARIO Y DATOS PERSONALES

GO
alter table DatosPersonales
drop FK_DatosPersonales_Usuario
GO
alter table DatosPersonales
drop column idUsuario
GO
alter table Usuario
add idDatosPersonales int not null default 1
GO
alter table Usuario
add constraint FK_Usuario_DatosPersonales foreign key (idDatosPersonales) references DatosPersonales(datosPersonalesId)
GO
alter table DatosPersonales
add telefono varchar(50) not null default '44445555'
GO
--FIN ACOMODE


--CREO TABLAS BANCO Y TARJETA

GO
create table Banco(
	idBanco int not null primary key identity,
	nombre varchar(50) not null,
    descuento int null
)
GO
create table Tarjeta(
	idTarjeta int not null primary key identity,
	idBanco int not null,
	numero varchar(50) not null,
	vencimiento date not null,
	codigo int not null,
	saldo numeric
)
GO
alter table Tarjeta
add constraint FK_Tarjeta_Banco foreign key (idBanco) references Banco(idBanco)

alter table Tarjeta
add constraint UC_Numero unique (numero)
GO

--END BANCO TARJETA


--CREO TABLA RELACION USUARIO TARJETA

GO
create table TarjetaUsuario(
	idTarjetaUsuario int not null primary key identity,
	idTarjeta int not null,
	idUsuario int not null
)
GO
alter table TarjetaUsuario
add constraint FK_Tarjeta_TarjetaUsuario foreign key (idTarjeta) references Tarjeta(idTarjeta)

alter table TarjetaUsuario
add constraint FK_Usuario_TarjetaUsuario foreign key (idUsuario) references Usuario(idUsuario)
GO
alter table TarjetaUsuario
add constraint UC_Usuario_Tarjeta unique (idUsuario,idTarjeta)
GO

--END USUARIO TARJETA