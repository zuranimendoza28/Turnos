CREATE TABLE Asesores (
    ID INTEGER PRIMARY KEY AUTO_INCREMENT NOT NULL,
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
    Turno INTEGER NOT NULL,
    FechaSolicitud DateTime NOT NULL,
    FechaInicioAtencion DateTime NULL,
    FechaFinAtencion DateTime NULL,
    FOREIGN KEY (NIT_Asesor) REFERENCES Asesores(NIT)
);

SELECT * from Asesores;
alter Table Turnos RENAME COLUMN Turno to NumeroTurno;

alter Table Turnos ADD COLUMN TipoDocumento varchar(2) AFTER ID;

insert into Asesores(NIT, Nombre, Apellido, Password, Estado, Acceso) values 
("77777", "Zurani", "Villada", "1234", "Activo", 1);

insert into Turnos(NIT_Asesor, Servicio, `Turno`, `FechaSolicitud`, `FechaInicioAtencion`, `FechaFinAtencion`) values 
("77777", "IG", 1, "2024-03-06 12:20:00", "2024-03-06 12:30:00", "2024-03-06 12:35:00");