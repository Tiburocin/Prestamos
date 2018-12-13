create database Prestamos;
use Prestamos;

create table Caja(id_caja integer identity(1,1) primary key not null, capital float not null, limite float not null);
create table Usuario(id_usuario integer identity(1,1) primary key not null, identificacion nvarchar(20) not null, nombre nvarchar(30) not null, apellido nvarchar(40) not null,tel_movil nvarchar(14) not null, tel_casa nvarchar(14) not null);
create table Prestamo(id_prestamo integer identity(1,1) primary key not null, interes float not null, cantidad float not null, fecha_reg date not null, fecha_auth date not null, fecha_entrega date not null, meses int not null, id_usuario integer foreign key references Usuario(id_usuario));
create table Fecha_Pago(id_fecha_pago integer identity(1,1) primary key not null, fecha_1 date not null, fecha_2 date, fecha_3 date, fecha_4 date, fecha_5 date, fecha_6 date, id_prestamo integer foreign key references Prestamo(id_prestamo));

--Establecer caja
insert into Caja(capital,limite) values(10000000,100000);

select * from Caja;