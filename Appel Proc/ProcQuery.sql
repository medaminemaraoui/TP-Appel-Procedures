create database TestProc;
use TestProc;
create table stagiaire(
Num int primary key,
Nom varchar(20),
Prenom varchar(20),
Age int
);
--Afficher
create proc Affichage 
as 
begin
  select * from stagiaire
end

exec affichage
--Ajouter
create proc Insertion @num int,@nom varchar(20),@prenom varchar(20),@age int
as
begin 
  insert into stagiaire values(@num,@nom,@prenom,@age);
end

exec insertion 1,'kassimi','ayoub',19 
--Modifier
create proc Modifier @num int,@nom varchar(20),@prenom varchar(20),@age int
as
begin 
  update stagiaire 
  set Nom= @nom,Prenom = @prenom,Age = @age
  where num = @num
end

exec Modifier 1,'kassim','abdo',22 
--Supprimer
create proc supprimer @num int
as
begin 
  delete from  stagiaire where num = @num
end

exec supprimer 1
--rechercher
create proc Rechercher @num int
as
begin 
  select * from  stagiaire where num = @num
end

exec Rechercher 1
