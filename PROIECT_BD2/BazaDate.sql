CREATE TABLE Serviciu (
Tip_serviciu VARCHAR(20) PRIMARY KEY,
An_infiintare INT,
Nr_tari_acoperire INT
);



INSERT INTO Serviciu
VALUES ('Internet', 1996, 5);
INSERT INTO Serviciu
VALUES ('Televiziune', 1975, 1);
INSERT INTO Serviciu
VALUES ('Telefonie mobila', 1999, 3);
INSERT INTO Serviciu
VALUES ('Cloud', 2013, 3);
INSERT INTO Serviciu
VALUES ('Telefonie fixa', 1980, 1);


CREATE TABLE Abonament (
ID_Abonament INT PRIMARY KEY,
Pret INT,
Durata_contract INT ,
Tip_abonament VARCHAR(20) NOT NULL,
CONSTRAINT CHK_Abon CHECK (Durata_contract>0 AND Pret>0)
);


INSERT INTO Abonament
VALUES (1,30, 1, 'Phone_everywhere');
INSERT INTO Abonament
VALUES (2,60,2,'Net_unlimited');
INSERT INTO Abonament
VALUES (3, 20, 2, 'CanaleHD');
INSERT INTO Abonament
VALUES (4, 15, 1, '100Canale');
INSERT INTO Abonament
VALUES (5, 50, 1, '1Terra');
INSERT INTO Abonament
VALUES (6, 85, 1, '3Terra');
INSERT INTO Abonament
VALUES (7, 110, 1, '5Terra');
INSERT INTO Abonament
VALUES (8, 45, 1, 'Phone+Net');
INSERT INTO Abonament
VALUES (9, 15, 1, 'Cable_Phone');




CREATE TABLE Angajat (
ID_Angajat INT PRIMARY KEY,
Nume VARCHAR(20) NOT NULL,
Prenume VARCHAR(20) NOT NULL,
Salariu INT,
Functie VARCHAR(20),
Id_infrastructura INT,
CONSTRAINT CHK_Sal CHECK(Salariu>0),
CONSTRAINT FK_ANGAJAT FOREIGN KEY (Id_infrastructura) REFERENCES Infrastructura (ID_Infrastructura) ON DELETE CASCADE
);



INSERT INTO Angajat
VALUES (1, 'Antochi', 'Ana', 8000, 'Inginer', 1);
INSERT INTO Angajat
VALUES (2, 'Paduraru', 'Dan', 9000, 'Manager', 2);
INSERT INTO Angajat
VALUES (3, 'Petru', 'Ion', 7800, 'Contabil', 4);
INSERT INTO Angajat
VALUES (4, 'Ionescu', 'Laura', 6780, 'Inginer telecomunicatii', 3);
INSERT INTO Angajat
VALUES (5, 'Pop', 'Mara', 7600, 'Inginer-IT', 3);
INSERT INTO Angajat
VALUES (6, 'Sofrone', 'Radu', 6000, 'Relatii clienti', 3);
INSERT INTO Angajat
VALUES (7, 'Dolis', 'Ioana', 5900, 'HR', 5);



CREATE TABLE Proiect(
Nr_proiect INT PRIMARY KEY,
Nume VARCHAR(40) NOT NULL,
Suma_alocata INT,
Data_incepere DATE,
Data_finalizare DATE,
Infrastructura_primita INT,
CONSTRAINT verifica_date check(Data_incepere<Data_finalizare),
CONSTRAINT CHK_PR CHECK(Suma_alocata>0),
CONSTRAINT FK_PROIECT FOREIGN KEY (Infrastructura_primita) REFERENCES Infrastructura (ID_Infrastructura) ON DELETE CASCADE
);



INSERT INTO Proiect
VALUES (1, 'Untold', 2000,'2020-08-04', '2020-08-09', 1 );
INSERT INTO Proiect
VALUES (2, 'Colegiul Mihai Eminescu', 1000, '2019-01-01',  '2022-12-30', 3);
INSERT INTO Proiect
VALUES (3, 'Primarie Bacau', 5000, '2018-01-01', '2030-12-31', 6);
INSERT INTO Proiect
VALUES (4, 'Primarie Suceava', 2000, '2015-01-10', '2021-01-01', 2);
INSERT INTO Proiect
VALUES (5, 'Gradinita 10', 3000, '2018-01-01','2025-01-01', 2);





CREATE TABLE Partener(
Nume VARCHAR(30) PRIMARY KEY,
Durata_contract INT,
Infrastructura_impartita INT NOT NULL,
CONSTRAINT FK_PAR FOREIGN KEY (Infrastructura_impartita) REFERENCES Infrastructura (ID_Infrastructura) ON DELETE CASCADE
);


INSERT INTO Partener
VALUES ('Orange Communications', 5, 1);
INSERT INTO Partener
VALUES ('Digi', 7, 2);
INSERT INTO Partener
VALUES ('Telekom', 3, 3);
INSERT INTO Partener
VALUES ('StoreIn', 5, 3);
INSERT INTO Partener
VALUES ('Contakt', 5, 4);




CREATE TABLE Infrastructura (
ID_Infrastructura INT PRIMARY KEY,
Nume VARCHAR(30) NOT NULL,
Serviciu_asociat VARCHAR(20),
Costuri_totale INT,
CONSTRAINT FK_INFR FOREIGN KEY (Serviciu_asociat) REFERENCES Serviciu(Tip_serviciu) ON DELETE CASCADE
);


INSERT INTO Infrastructura
VALUES (1,'Fibra optica' , 'Internet', 40000);
INSERT INTO Infrastructura
VALUES (2,'Cablu coaxial', 'Televiziune', 10);
INSERT INTO Infrastructura
VALUES (3,'Data center', 'Cloud', 400);
INSERT INTO Infrastructura
VALUES (4,'Radio relee', 'Telefonie mobila', 10000);
INSERT INTO Infrastructura
VALUES (5,'Fibra optica' , 'Televiziune', 35000);
INSERT INTO Infrastructura
VALUES (6,'Cablu coaxial', 'Telefonie fixa', 15);
INSERT INTO Infrastructura
VALUES (7,'Cablu coaxial', 'Internet', 10);




CREATE TABLE Client(
ID_client INT PRIMARY KEY,
Data_subscriere DATE,
Nume VARCHAR(20) NOT NULL,
Prenume VARCHAR(20),
Tip_client VARCHAR(20) NOT NULL,
Cod_unic_identificare VARCHAR(14) UNIQUE NOT NULL,
CONSTRAINT CHK_TIP CHECK ( UPPER(Tip_client) = 'PERSOANA FIZICA' OR UPPER(Tip_client) = 'PERSOANA JURIDICA' ),
CONSTRAINT CHK_COD CHECK (UPPER(Tip_client) = 'PERSOANA FIZICA' and len(Cod_unic_identificare)=13 OR  UPPER(Tip_client) = 'PERSOANA JURIDICA' and len(Cod_unic_identificare)=7)
);




INSERT INTO Client
VALUES (1, '2012-10-10', 'Popescu' , 'Mihai', 'Persoana fizica', 5020405046221);
INSERT INTO Client
VALUES (2, '2013-12-12', 'Ionescu', 'Dan', 'Persoana fizica', 5020405046222);
INSERT INTO Client
VALUES (3, '2014-12-19', 'Tanase', 'Laura', 'Persoana fizica', 6020705046225);
INSERT INTO Client
VALUES (4, '2015-01-12', 'Georgescu', 'Ioana', 'Persoana fizica', 6020405045222);
INSERT INTO Client
VALUES (5, '2019-08-12', 'Marin', 'Tudor', 'Persoana fizica', 5020405044222);
INSERT INTO Client
VALUES (6, '2019-03-03', 'Doja', 'Radu', 'Persoana fizica', 5020405041111);
INSERT INTO Client
VALUES (7, '2019-11-11','Dobre', 'Ana', 'Persoana fizica', 6020405040022);
INSERT INTO Client
VALUES (8, '2020-10-10', 'Marelbo', NULL, 'Persoana juridica', 6859662);
INSERT INTO Client
VALUES (9, '2017-04-04', 'Microsoft', NULL, 'Persoana juridica', 6859663);
INSERT INTO Client
VALUES (10,'2018-03-03', 'Luxoft', NULL, 'Persoana juridica', 6859664);
INSERT INTO Client
VALUES (11, '2020-01-01', 'Thales', NULL, 'Persoana juridica', 6859665);
INSERT INTO Client
VALUES (12, '2020-05-05', 'NXP', NULL, 'Persoana juridica', 6859666);

CREATE TABLE Subscriptii (
ID_Abonament INT,
ID_client INT,
CONSTRAINT PK_SUB PRIMARY KEY(ID_Abonament, ID_client),
CONSTRAINT FK_SUB FOREIGN KEY (ID_Abonament) REFERENCES Abonament (ID_Abonament) ON DELETE CASCADE,
CONSTRAINT FK_SUB2 FOREIGN KEY(ID_client) REFERENCES Client (ID_client) ON DELETE CASCADE

);


INSERT INTO Subscriptii
VALUES (1,3);
INSERT INTO Subscriptii
VALUES (1,5);
INSERT INTO Subscriptii
VALUES (2,3);
INSERT INTO Subscriptii
VALUES (3,2);
INSERT INTO Subscriptii
VALUES (5,3);
INSERT INTO Subscriptii
VALUES (6,4);
INSERT INTO Subscriptii
VALUES (7,5);
INSERT INTO Subscriptii
Values (4,1);

INSERT INTO Subscriptii
Values (5,6);
INSERT INTO Subscriptii
Values (4,7);
INSERT INTO Subscriptii
Values (7,8);
INSERT INTO Subscriptii
Values (7,9);
INSERT INTO Subscriptii

Values (7,10);
INSERT INTO Subscriptii
Values (7,11);
INSERT INTO Subscriptii
Values (7,12);



CREATE TABLE Abonamente_servicii (
Tip_serviciu VARCHAR(20),
ID_Abonament INT,
Serviciu_limitat VARCHAR(3)
CONSTRAINT PK_AbonSer PRIMARY KEY (Tip_serviciu, ID_Abonament),
CONSTRAINT FK_AS FOREIGN KEY (Tip_serviciu) REFERENCES Serviciu (Tip_serviciu) ON DELETE CASCADE,
CONSTRAINT FK_AS2 FOREIGN KEY (ID_Abonament) REFERENCES Abonament (ID_Abonament) ON DELETE CASCADE,
CONSTRAINT CHK_AS CHECK ( UPPER(Serviciu_limitat) = 'DA' OR UPPER(Serviciu_limitat) = 'NU' )  
);



INSERT INTO Abonamente_servicii
VALUES ('Internet',2, 'NU');
INSERT INTO Abonamente_servicii
VALUES ('Internet',8,'NU');
INSERT INTO Abonamente_servicii
VALUES ('Telefonie',8,'DA');
INSERT INTO Abonamente_servicii
VALUES ('Cloud', 5,'DA');
INSERT INTO Abonamente_servicii
VALUES ('Cloud', 6, 'DA');
INSERT INTO Abonamente_servicii
VALUES ('Cloud', 7, 'NU');
INSERT INTO Abonamente_servicii
VALUES ('Telefonie', 1, 'NU');
INSERT INTO Abonamente_servicii
VALUES ('Televiziune', 3, 'NU');
INSERT INTO Abonamente_servicii
VALUES ('Televiziune', 4, 'NU');

 
use PROIECT;
delete from Infrastructura where ID_Infrastructura=3;

SELECT * FROM Infrastructura;