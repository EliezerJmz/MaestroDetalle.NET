
	USE master ;  
	GO  
	CREATE DATABASE MaestroDetalle  
	ON   
	( NAME = MaestroDetalle_dat,  
	    FILENAME = 'C:\Users\Ego\Documents\ARCHIVOS HP SYNC\CURSO ASP.NET C#\CURSO COMPLETO ASP MVC 5 C#\MaestroDetalle\MaestroDetalle.mdf',
		SIZE = 10,  
		MAXSIZE = 50,  
		FILEGROWTH = 5 )  
	LOG ON  
	( NAME = MaestroDetalle_log,  
		 FILENAME = 'C:\Users\Ego\Documents\ARCHIVOS HP SYNC\CURSO ASP.NET C#\CURSO COMPLETO ASP MVC 5 C#\MaestroDetalle\MaestroDetalle.ldf', 
		SIZE = 5MB,  
		MAXSIZE = 25MB,  
		FILEGROWTH = 5MB ) ;  
	GO 

	
--CREAR LAS TABLAS
USE MaestroDetalle;
GO
	CREATE TABLE Venta(
		Id INT PRIMARY KEY IDENTITY(1,1),
		Fecha DATETIME,
		Cliente VARCHAR(50),	
	)

	CREATE TABLE Concepto(
	Id INT PRIMARY KEY IDENTITY(1,1),
	IdVenta INT,
	Cantidad INT,
	Nombre VARCHAR(50),
	PrecioUnitario DECIMAL(18,2),
	Total DECIMAL(18,2)
	)
