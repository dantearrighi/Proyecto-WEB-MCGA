drop database GCI_Auditoria

create database GCI_Auditoria

use GCI_Auditoria

ALTER TABLE Auditorias_Log ALTER COLUMN fecha DATETIME2
ALTER TABLE Auditorias_Cuotas ALTER COLUMN fecha DATETIME2