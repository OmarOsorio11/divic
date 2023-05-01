USE divic_data;


CREATE TABLE Delivery (
  Id INT PRIMARY KEY AUTO_INCREMENT,
  Nombre VARCHAR(255),
  FechaNacimiento DATE,
  Usuario VARCHAR(255),
  Password VARCHAR(255),
  PaquetesEntregados INT
);


CREATE TABLE Paquete (
  Id INT PRIMARY KEY AUTO_INCREMENT,
  Descripcion VARCHAR(255),
  DireccionEntrega VARCHAR(255),
  Estatus VARCHAR(255),
  Contacto VARCHAR(255)
);

CREATE TABLE PaqueteEntregado (
  Id INT PRIMARY KEY AUTO_INCREMENT,
  IdPaquete INT,
  NombreRecibe VARCHAR(255),
  TipoPersonaRecibe VARCHAR(255),
  UrlImagen VARCHAR(255),
  CURPRecibe VARCHAR(255),
  FOREIGN KEY (IdPaquete) REFERENCES Paquete(Id)
);
CREATE TABLE PaqueteEnTransito (
  Id INT PRIMARY KEY AUTO_INCREMENT,
  IdPaquete INT,
  IdDelivery INT,
  FOREIGN KEY (IdPaquete) REFERENCES Paquete(Id),
  FOREIGN KEY (IdDelivery) REFERENCES Delivery(Id)
);