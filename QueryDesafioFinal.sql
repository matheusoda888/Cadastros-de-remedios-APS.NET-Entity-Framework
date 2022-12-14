
create database AtosEntity8

create login AtosEntity8 with password='Atos_Entity_8';
create user AtosEntity8 from login AtosEntity8;



exec sp_addrolemember 'DB_DATAREADER', 'AtosEntity8';
exec sp_addrolemember 'DB_DATAWRITER', 'AtosEntity8';


create table Remedios(
	id integer primary key identity,
	nome varchar(30) unique not null,
	
)



create table Pacientes(
	id integer primary key identity,
	nome varchar(30) unique not null,

)




create table Horarios(
	id integer primary key identity,
	nomeRemedio varchar(30) not null,
	nomePaciente varchar(30) not null,
	tempo integer not null,
	horario time not null,
	foreign key (nomeRemedio) references Remedios(nome),
	foreign key (nomePaciente) references Pacientes(nome)


)


drop table Remedios

delete from Horarios