CREATE TABLE users(
id_user int primary key identity(1,1),
names varchar(255),
email varchar(255),
pwd varchar(255),
type_user int,
active int
)

CREATE TABLE user_type(
id_type int primary key identity(1,1),
name_type varchar(255),
description varchar(255),
active int
)

INSERT INTO user_type VALUES ('Administrador','Tendrá acceso a todas las opciones, crear y modificar usuarios, estatus de envíos, liquidaciones, etc',1), 
('Jefe de Sucursal',' Podrá agregar envíos y revisar estados de pedidos, generar reporte de facturación por cliente/pedido, generar orden de traslados para bodega central',1), 
('Cliente', 'Podrá agregar guías, y revisar estado de paquetes (en bodega, entregado, liquidado etc.',1), 
('Mensajero', ' Agregar envíos sin modificarlos (sólo jefe de sucursal y administrador puede modificar algún campo de los envíos)',1), 
('Colaborador', 'Se podrán crear usuario por cada colaborador que trabaja para nuestro empresa, labor que realiza, código de trabajador, sucursal asignada, datos de sueldo. etc',1)

CREATE TABLE branch_office(
id_branch int primary key identity(1,1),
name_branch varchar(255),
id_warehouse int,
active int
)

CREATE TABLE payment_type(
id_pay int primary key identitY(1,1),
name_pay varchar(255),
active int
)
INSERT INTO payment_type VALUES ('En efectivo',1), ('Con tarjeta',1), ('Transferencia',1),
('Ya pagado (solo entregar)',1)

CREATE TABLE warehouse(
id_warehouse int primary key identity(1,1),
name_warehouse varchar(255),
ware_type int,
department int,
warehouse_address varchar(255),
active int,
)


CREATE TABLE department(
id_department int primary key identity(1,1),
department_name varchar(255),
prefix varchar(255),
active int
)
INSERT INTO department VALUES ('San Salvador', 'SLV',1), ('La Libertad', 'LIB',1), ('San Miguel', 'SNM',1)

CREATE TABLE warehouse_type(
id_ware int primary key identity(1,1),
ware_type varchar(255),
active int
)
INSERT INTO warehouse_type values ('Bodega Central',1), ('Bodega de ingreso de paquetes',1),
('Bodega de paquetes entregados',1), ('Bodega de devoluciones',1)

CREATE TABLE transport_dist(
id_transport int primary key identity(1,1),
id_branch int,
id_transport_type int,
quantity int,
active int,
)
CREATE TABLE transport_type(
id_transport_type int primary key identity(1,1),
transport_type varchar(255),
active int
)
INSERT INTO transport_type values ('Moto',1), ('Panel',1), ('Camion',1)

CREATE TABLE clients(
id_client int primary key identity(1,1),
id_user int,
client_type int,
ship_quantity int,
active int
)

CREATE TABLE client_type(
id_client_type int primary key identity(1,1),
name_type varchar(255),
package_capacity int,
active int
)
INSERT INTO client_type VALUES ('Emprendedor', 75 ,1) , ('Pyme', 200,1), ('Premium', 50000,1)

CREATE TABLE zone_type(
id_zone_type int primary key identity(1,1),
zone_name varchar(255),
active int
)

INSERT INTO zone_type VALUES ('Ciudad',1), ('Municipio',1), ('Interior del pais',1)

CREATE TABLE client_pricing(
id_client_pricing int primary key identity(1,1),
client_type int,
transport_type int,
zone_type int,
price float,
active int
)

CREATE TABLE shipment_status(
id_shipment_status int primary key identity(1,1),
shipment_status_name varchar(255),
active int
)
INSERT INTO shipment_status VALUES ('En proceso',1),('En camino a bodega',1), ('En bodega',1),('En camino a sucursal',1),('Ingreso a sucursal',1),('Salida de bodega',1),
('En ruta para entrega',1),('Entregado',1),('Liquidado',1),('Cancelado',1), ('Devolucion',1)

CREATE TABLE shipments(
id_shipment int primary key identity(1,1),
id_client int,
shipment_status int,
tracking_number varchar(255),
id_warehouse_dest int,
arrival_warehouse_date datetime,
id_branchoffice int,
arrival_branchoffice datetime,
client_send_date datetime,
id_department int,
prefix varchar(255),
payment_type int,
failed_attempt int,
active int
)

CREATE TABLE shipments_report(
id_shipment_report int primary key identity(1,1),
id_shipment int,
shipment_status int,
description_report varchar(255),
active int
)

/*
PROCEDIMIENTOS ---
*/

/**** START - USER TABLE PROCEDURE *****/
CREATE PROCEDURE PR_create_user(
@names varchar(255),
@email varchar(255),
@pwd varchar(255),
@type_user varchar(255)
)
as
begin
insert into users values(@names,
@email,
@pwd,
@type_user , 1)
END

CREATE PROCEDURE PR_login_user(
@email varchar(255),
@pwd varchar(255)
)
as
begin
SELECT id_user, names, email, type_user, T.name_type as name_type_user, U.active FROM users U LEFT JOIN user_type T ON U.type_user = T.id_type
WHERE email = @email AND pwd = @pwd
END

CREATE PROCEDURE PR_get_users
as
BEGIN
SELECT id_user, names, email, type_user, T.name_type as name_type_user, U.active FROM users U LEFT JOIN user_type T ON U.type_user = T.id_type
END

CREATE PROCEDURE PR_get_users_only(@id_user int)
as
BEGIN
SELECT id_user, names, email, type_user, T.name_type as name_type_user, U.active FROM users U 
LEFT JOIN user_type T ON U.type_user = T.id_type
WHERE U.id_user = @id_user
END

create procedure PR_set_user(
@id_user int,
@names varchar(255),
@email varchar(255),
@type_user varchar(255),
@active int
)
as
begin
UPDATE users SET names = @names, email = @email, type_user = @type_user, active = @active WHERE id_user = @id_user  
END

create procedure PR_set_password(
@id_user int,
@pwd varchar(255)
)
as
begin
UPDATE users SET pwd = @pwd WHERE id_user = @id_user  
END

create procedure PR_drop_user(
@id_user int)
as
begin
UPDATE users SET active = 0 WHERE id_user = @id_user  
END

EXEC PR_login_user @email = "ronni2@gmail.com", @pwd = "123456"
/**** END - USER TABLE PROCEDURE *****/


/**** START - BRANCH OFFICE TABLE PROCEDURE *****/
CREATE PROCEDURE PR_create_branch_office(
@name_branch varchar(255),
@id_warehouse int
)
as
begin
insert into branch_office values(@name_branch, @id_warehouse ,1)
END

CREATE PROCEDURE PR_get_branch_office
as
BEGIN
SELECT id_branch, name_branch, active, id_warehouse FROM branch_office
END

CREATE PROCEDURE PR_get_branch_office_only
(@id_branch int)
as
BEGIN
SELECT id_branch, name_branch, id_warehouse ,active FROM branch_office WHERE id_branch = @id_branch
END


CREATE procedure PR_set_branch_office(
@id_branch int,
@name_branch varchar(255),
@id_warehouse int,
@active int
)
as
begin
UPDATE branch_office SET name_branch = @name_branch, active = @active, id_warehouse = @id_warehouse WHERE id_branch = @id_branch
END

create procedure PR_drop_branch_office(
@id_branch int
)
as
begin
UPDATE branch_office SET active = 0 WHERE id_branch = @id_branch
END

/**** END - Branch office TABLE PROCEDURE *****/

/**** START - Client Pricing TABLE PROCEDURE *****/
CREATE PROCEDURE PR_create_client_pricing(
@client_type int,
@transport_type int,
@zona_type int,
@price float
)
as
begin
insert into client_pricing values(@client_type,
@transport_type,
@zona_type,
@price, 1)
END

CREATE PROCEDURE PR_get_client_pricing
as
BEGIN
SELECT P.id_client_pricing, P.client_type, P.transport_type, P.zone_type, P.price, P.active,
C.name_type, C.package_capacity, TC.transport_type as transport_name, Z.zone_name
FROM client_pricing P 
JOIN client_type C ON P.client_type = C.id_client_type
JOIN transport_type TC ON P.transport_type = TC.id_transport_type
JOIN zone_type Z ON P.zone_type = Z.id_zone_type
END

create procedure PR_set_client_pricing(
@id_client_pricing int,
@client_type int,
@transport_type int,
@zona_type int,
@price float,
@active int
)
as
begin
UPDATE client_pricing SET client_type = @client_type , transport_type = @transport_type, zone_type = @zona_type, price = @price , @active = active WHERE id_client_pricing = @id_client_pricing
END

create procedure PR_drop_client_pricing(
@id_client_pricing int)
as
begin
UPDATE client_pricing SET active = 0 WHERE id_client_pricing = @id_client_pricing
END

/**** END - CLIENT PRICING TABLE PROCEDURE *****/

/**** START - Client Type TABLE PROCEDURE *****/
CREATE PROCEDURE PR_create_client_type(
@name_type varchar(255),
@package_capacity int
)
as
begin
insert into client_type values(@name_type, @package_capacity, 1)
END

CREATE PROCEDURE PR_get_client_type
as
BEGIN
SELECT * FROM client_type
END

create procedure PR_set_client_type(
@id_client_type int,
@name_type varchar(255),
@package_capacity int,
@active int
)
as
begin
UPDATE client_type SET name_type = @name_type, package_capacity = @package_capacity , @active = active WHERE id_client_type = @id_client_type
END

create procedure PR_drop_client_type(
@id_client_type int)
as
begin
UPDATE client_type SET active = 0 WHERE id_client_type = @id_client_type
END

/**** END - CLIENT TYPE TABLE PROCEDURE *****/

/**** START - Clients TABLE PROCEDURE *****/
create PROCEDURE PR_create_client(
@id_user int,
@client_type int,
@ship_quantity int
)
as
begin
insert into clients values(@id_user, @client_type, @ship_quantity, 1)
END

CREATE PROCEDURE PR_get_clients
as
BEGIN
SELECT C.id_client, C.id_user, C.client_type, C.active, U.names, U.email, T.name_type, T.package_capacity FROM clients C
JOIN users U ON C.id_user = U.id_user
JOIN client_type T ON C.client_type = T.id_client_type
WHERE U.type_user = 3
END

create procedure PR_set_client(
@id_client int,
@client_type int,
@active int
)
as
begin
UPDATE clients SET client_type = @client_type , @active = active WHERE id_client = @id_client
END

create procedure PR_drop_client(
@id_client int)
as
begin
UPDATE clients SET active = 0 WHERE id_client = @id_client
END

/**** END - CLIENTS TABLE PROCEDURE *****/

/**** START - Department TABLE PROCEDURE *****/
CREATE PROCEDURE PR_create_department(
@department_name varchar(255),
@prefix varchar(255)
)
as
begin
insert into department values(@department_name, @prefix, 1)
END

CREATE PROCEDURE PR_get_departments
as
BEGIN
SELECT * FROM department
END

create procedure PR_set_department(
@id_department int,
@department_name varchar(255),
@prefix varchar(255),
@active int
)
as
begin
UPDATE department SET department_name = @department_name, prefix = @prefix, @active = active WHERE id_department = @id_department
END

create procedure PR_drop_department(
@id_department int)
as
begin
UPDATE department SET active = 0 WHERE id_department = @id_department
END

/**** END - CLIENTS TABLE PROCEDURE *****/

/**** START - Shipping TABLE PROCEDURE *****/
CREATE PROCEDURE PR_create_shipping(
@id_client int,
@id_warehouse_dest int,
@id_branchoffice int,
@tracking_number varchar(255),
@id_department int,
@active int											 
)
as
begin
DECLARE @client_send_date as date
SET @client_send_date = GetDate()
DECLARE @shipment_quantity_r as INT = 1 + (SELECT ship_quantity FROM clients WHERE id_client = @id_client)
INSERT INTO shipments VALUES (@id_client,1,@tracking_number,@id_warehouse_dest,null,@id_branchoffice, null ,@client_send_date ,@id_department, null ,0 , 0,@active); 
UPDATE clients SET ship_quantity = @shipment_quantity_r WHERE id_client = @id_client
END

CREATE PROCEDURE PR_get_shipments
as
BEGIN
SELECT S.active,S.arrival_warehouse_date,s.client_send_date,S.failed_attempt,S.id_client,S.id_shipment,S.id_warehouse_dest,S.payment_type,S.prefix,S.shipment_status,S.tracking_number,S.id_branchoffice,S.arrival_branchoffice, S.id_department,
U.names as client_name, Ct.name_type as client_type_name , CT.package_capacity, ST.shipment_status_name , W.name_warehouse as warehouse_name_dest,
PT.name_pay AS payment_type_n, D.prefix as department_prefix, D.department_name, BO.name_branch, C.ship_quantity
FROM shipments S 
JOIN clients C ON S.id_client = C.id_client
JOIN users U ON C.id_user = U.id_user
JOIN client_type CT ON C.client_type = CT.id_client_type
JOIN shipment_status ST ON S.shipment_status = ST.id_shipment_status
JOIN warehouse W ON S.id_warehouse_dest = W.id_warehouse
LEFT JOIN payment_type PT ON S.payment_type = PT.id_pay
JOIN department D ON S.id_department = D.id_department
JOIN branch_office BO ON S.id_branchoffice = BO.id_branch
END

CREATE PROCEDURE PR_get_shipments_only(
@id_shipment int
)
as
BEGIN
SELECT S.active,S.arrival_warehouse_date,s.client_send_date,S.failed_attempt,S.id_client,S.id_shipment,S.id_warehouse_dest,S.payment_type,S.prefix,S.shipment_status,S.tracking_number,S.id_branchoffice,S.arrival_branchoffice, S.id_department,
U.names as client_name, Ct.name_type as client_type_name , CT.package_capacity, ST.shipment_status_name , W.name_warehouse as warehouse_name_dest,
PT.name_pay AS payment_type_n, D.prefix as department_prefix, D.department_name, BO.name_branch
FROM shipments S JOIN clients C ON S.id_client = C.id_client
JOIN users U ON C.id_user = U.id_user
JOIN client_type CT ON C.client_type = CT.id_client_type
JOIN shipment_status ST ON S.shipment_status = ST.id_shipment_status
JOIN warehouse W ON S.id_warehouse_dest = W.id_warehouse
LEFT JOIN payment_type PT ON S.payment_type = PT.id_pay
JOIN department D ON S.id_department = D.id_department
JOIN branch_office BO ON S.id_branchoffice = BO.id_branch
WHERE S.id_shipment = @id_shipment
END

CREATE procedure PR_set_shipment(
@id_shipment int,
@id_client int,
@shipment_status int,
@id_warehouse_dest int,
@arrival_warehouse_dest datetime,
@id_branchoffice int,
@arrival_branchoffice datetime,
@client_send_date datetime,
@id_department int,
@payment_type int,
@failed_attempt int,
@active int	
)
as
begin
UPDATE shipments SET id_client = @id_client, shipment_status = @shipment_status,  
id_warehouse_dest = @id_warehouse_dest, arrival_warehouse_date = @arrival_warehouse_dest, client_send_date = @client_send_date,
 payment_type = @payment_type , failed_attempt = @failed_attempt, active = @active, id_branchoffice = @id_branchoffice,
arrival_branchoffice = @arrival_branchoffice, id_department = @id_department
WHERE id_shipment = @id_shipment
END



create procedure PR_drop_shipment(
@id_shipment int)
as
begin
UPDATE shipments SET active = 0 WHERE id_shipment = @id_shipment
END

CREATE PROCEDURE PR_get_tracking_shipment
(
@tracking_number varchar(255)
)
as
BEGIN
SELECT S.active,S.arrival_warehouse_date,s.client_send_date,S.failed_attempt,S.id_client,S.id_shipment,S.id_warehouse_dest,S.payment_type,S.prefix,S.shipment_status,S.tracking_number,S.id_branchoffice,S.arrival_branchoffice, S.id_department,
U.names as client_name, Ct.name_type as client_type_name , CT.package_capacity, ST.shipment_status_name , W.name_warehouse as warehouse_name_dest,
PT.name_pay AS payment_type_n, D.prefix as department_prefix, D.department_name, BO.name_branch, C.ship_quantity
FROM shipments S 
JOIN clients C ON S.id_client = C.id_client
JOIN users U ON C.id_user = U.id_user
JOIN client_type CT ON C.client_type = CT.id_client_type
JOIN shipment_status ST ON S.shipment_status = ST.id_shipment_status
JOIN warehouse W ON S.id_warehouse_dest = W.id_warehouse
LEFT JOIN payment_type PT ON S.payment_type = PT.id_pay
JOIN department D ON S.id_department = D.id_department
JOIN branch_office BO ON S.id_branchoffice = BO.id_branch
WHERE S.tracking_number LIKE @tracking_number
END

/**** END - Shipping TABLE PROCEDURE *****/

/**** START - Warehouse TABLE PROCEDURE *****/


CREATE PROCEDURE PR_get_warehouse
as
BEGIN
SELECT W.id_warehouse, W.name_warehouse, W.ware_type, W.department, W.warehouse_address, W.active 
,WT.ware_type as ware_type_n , D.department_name, D.prefix
FROM warehouse W
JOIN warehouse_type WT ON W.ware_type = WT.id_ware
JOIN department D ON W.department = D.id_department
END

/**** END - Shipping TABLE PROCEDURE *****/

/**** START - Shipping STATUS TABLE PROCEDURE *****/

CREATE PROCEDURE PR_get_shipments_status
as
BEGIN
SELECT S.shipment_status_name, S.id_shipment_status, S.active FROM shipment_status S
END

/**** END - Shipping STATUS TABLE PROCEDURE *****/


/**** START - Payment Type TABLE PROCEDURE *****/

CREATE PROCEDURE PR_get_payment_type
as
BEGIN
SELECT P.id_pay, P.name_pay, P.active FROM payment_type P
END

/**** END - Payment Type TABLE PROCEDURE *****/

/**** START - User Type TABLE PROCEDURE *****/

CREATE PROCEDURE PR_get_user_type
as
BEGIN
SELECT U.id_type, U.name_type, U.description, U.active FROM user_type U
END

/**** END - User Type TABLE PROCEDURE *****/

INSERT INTO users VALUES ('Cliente pobre', 'clientepobre@gmail.com', '123456', 3, 1)

INSERT INTO clients values(2, 1, 0, 1)

SELECT * FROM users


INSERT INTO warehouse VALUES ('Bodega San Salvador', 2, 1, 'Ahi en algun lugar de San salvador', 1)

INSERT INTO branch_office VALUES ('Sucursal San salvador', 1, 1)

EXEC PR_get_tracking_shipment @tracking_number = '179336132SAN'

EXEC PR_get_users_only @id_user = 1