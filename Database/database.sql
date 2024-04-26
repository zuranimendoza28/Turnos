CREATE TABLE Asesores (
    Id INTEGER PRIMARY KEY AUTO_INCREMENT NOT NULL,
    NIT VARCHAR(20) UNIQUE NOT NULL,
    Nombre VARCHAR(50) NOT NULL,
    Apellido VARCHAR(50) NOT NULL,
    Password VARCHAR(20) NOT NULL,
    Estado VARCHAR(20) NOT NULL, /* Activo e Inactivo */
    Acceso INTEGER NOT NULL /*nivel acceso 1.Asesor 2.Administrador*/
);

CREATE TABLE Turnos (
    ID INTEGER PRIMARY KEY AUTO_INCREMENT NOT NULL,
    NIT_Asesor VARCHAR(20)  NOT NULL,
    Servicio Varchar(2) NOT NULL, /*IG AM PF CM*/
    NumeroTurno INTEGER NOT NULL,
    FechaSolicitud DateTime NOT NULL,
    FechaInicioAtencion DateTime NULL,
    FechaFinAtencion DateTime NULL,
    FOREIGN KEY (NIT_Asesor) REFERENCES Asesores(NIT)
);

SHOW TABLES;

DROP TABLE Turnos;

SELECT * from Turnos;

alter table Turnos add column TipoDocumento varchar(40) after NumeroTurno;

alter Table Turnos ADD COLUMN Documento varchar(20) AFTER TipoDocumento;

insert into Asesores(NIT, Nombre, Apellido, Password, Estado, Acceso) values 
("77777", "Zurani", "Villada", "1234", "Activo", 1);

insert into Turnos(NIT_Asesor, Servicio, `NumeroTurno`, `TipoDocumento`, `Documento`,`FechaSolicitud`, `FechaInicioAtencion`, `FechaFinAtencion`) values 
("77777", "IG", 2, "Visa", "940131393", "2024-03-06 12:20:00", "2024-03-06 12:30:00", "2024-03-06 12:35:00"),
("77777", "IG", 3, "Visa", "940131393", "2024-03-06 12:20:00", "2024-03-06 12:30:00", "2024-03-06 12:35:00"),
("77777", "PF", 4, "Visa", "940131393", "2024-03-06 12:20:00", "2024-03-06 12:30:00", "2024-03-06 12:35:00"),
("77777", "IG", 5, "Visa", "940131393", "2024-03-06 12:20:00", "2024-03-06 12:30:00", "2024-03-06 12:35:00"),
("77777", "AM", 6, "Visa", "940131393", "2024-03-06 12:20:00", "2024-03-06 12:30:00", "2024-03-06 12:35:00"),
("77777", "IG", 7, "Visa", "940131393", "2024-03-06 12:20:00", "2024-03-06 12:30:00", "2024-03-06 12:35:00"),
("77777", "IG", 8, "Visa", "940131393", "2024-03-06 12:20:00", "2024-03-06 12:30:00", "2024-03-06 12:35:00"),
("77777", "CM", 9, "Visa", "940131393", "2024-03-06 12:20:00", "2024-03-06 12:30:00", "2024-03-06 12:35:00");
