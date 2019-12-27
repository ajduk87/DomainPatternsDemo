CREATE SCHEMA commercialapplication;



DROP SEQUENCE IF EXISTS commercialapplication.location_id_seq;

DROP SEQUENCE IF EXISTS commercialapplication.commercialist_id_seq;

DROP SEQUENCE IF EXISTS commercialapplication.product_id_seq;

DROP SEQUENCE IF EXISTS commercialapplication.storage_id_seq;

DROP SEQUENCE IF EXISTS commercialapplication.customer_id_seq;

DROP SEQUENCE IF EXISTS commercialapplication.contact_id_seq;

DROP SEQUENCE IF EXISTS commercialapplication.sellingprogram_id_seq;

DROP SEQUENCE IF EXISTS commercialapplication.action_id_seq;

DROP SEQUENCE IF EXISTS commercialapplication.orderitem_id_seq;

DROP SEQUENCE IF EXISTS commercialapplication.orderitemmodified_id_seq;

DROP SEQUENCE IF EXISTS commercialapplication.orderitemrejected_id_seq;

DROP SEQUENCE IF EXISTS commercialapplication.orders_id_seq;

DROP SEQUENCE IF EXISTS commercialapplication.invoiceitem_id_seq;

DROP SEQUENCE IF EXISTS commercialapplication.invoices_id_seq;

DROP SEQUENCE IF EXISTS commercialapplication.events_id_seq;

DROP SEQUENCE IF EXISTS commercialapplication.eventstransaction_id_seq;

DROP SEQUENCE IF EXISTS commercialapplication.eventsother_id_seq;

DROP SEQUENCE IF EXISTS commercialapplication.saleschannel_id_seq;

CREATE SEQUENCE commercialapplication.location_id_seq INCREMENT 1 START 1;

CREATE SEQUENCE commercialapplication.commercialist_id_seq INCREMENT 1 START 1;

CREATE SEQUENCE commercialapplication.product_id_seq INCREMENT 1 START 1;

CREATE SEQUENCE commercialapplication.storage_id_seq INCREMENT 1 START 1;

CREATE SEQUENCE commercialapplication.customer_id_seq INCREMENT 1 START 1;

CREATE SEQUENCE commercialapplication.contact_id_seq INCREMENT 1 START 1;

CREATE SEQUENCE commercialapplication.sellingprogram_id_seq INCREMENT 1 START 1;

CREATE SEQUENCE commercialapplication.action_id_seq INCREMENT 1 START 1;

CREATE SEQUENCE commercialapplication.orderitem_id_seq INCREMENT 1 START 1;

CREATE SEQUENCE commercialapplication.orderitemmodified_id_seq INCREMENT 1 START 1;

CREATE SEQUENCE commercialapplication.orderitemrejected_id_seq INCREMENT 1 START 1;

CREATE SEQUENCE commercialapplication.orders_id_seq INCREMENT 1 START 1;

CREATE SEQUENCE commercialapplication.invoiceitem_id_seq INCREMENT 1 START 1;

CREATE SEQUENCE commercialapplication.invoices_id_seq INCREMENT 1 START 1;

CREATE SEQUENCE commercialapplication.events_id_seq INCREMENT 1 START 1;

CREATE SEQUENCE commercialapplication.eventstransaction_id_seq INCREMENT 1 START 1;

CREATE SEQUENCE commercialapplication.eventsother_id_seq INCREMENT 1 START 1;

CREATE SEQUENCE commercialapplication.saleschannel_id_seq INCREMENT 1 START 1;




DROP TABLE IF EXISTS commercialapplication.location CASCADE;

CREATE TABLE commercialapplication.location
(
	Id integer NOT NULL   DEFAULT NEXTVAL(('commercialapplication."location_id_seq"'::text)::regclass),
	MarketplaceName varchar(500) UNIQUE NOT NULL,
	SiteName varchar(500) NULL,
	Address varchar(500) NULL,
	Postalcode varchar(500) NULL,
	Pib varchar(500) NULL,
	IdNumber varchar(500) NULL,
	Work varchar(500) NULL,
	DomicileBankAccount varchar(500) NULL,
	ChanelSales varchar(500) NULL,
	IsAvailableForSelling  boolean NULL,
	IsContainHyphen boolean NULL
);
ALTER TABLE commercialapplication.location ADD CONSTRAINT PK_Location
	PRIMARY KEY (Id);
	


DROP TABLE IF EXISTS commercialapplication.commercialist CASCADE;

CREATE TABLE commercialapplication.commercialist
(
	Id integer NOT NULL   DEFAULT NEXTVAL(('commercialapplication."commercialist_id_seq"'::text)::regclass),
	Username varchar(500) UNIQUE NOT NULL,
	FirstName varchar(500) NULL,
	LastName varchar(500) NULL,
	Password varchar(500) NULL
);
ALTER TABLE commercialapplication.commercialist ADD CONSTRAINT PK_Commercialist
	PRIMARY KEY (Id);


-- create table connection BEGIN
DROP TABLE IF EXISTS commercialapplication.commercialistlocation CASCADE;

CREATE TABLE commercialapplication.commercialistlocation
(
	CommercialistId integer NOT NULL,
	LocationId integer NOT NULL
);

ALTER TABLE commercialapplication.commercialistlocation ADD CONSTRAINT PK_CommercialistLocation
	PRIMARY KEY (CommercialistId,LocationId);

CREATE INDEX IXFK_CommercialistLocation_Commercialist ON commercialapplication.commercialistlocation (CommercialistId ASC);

CREATE INDEX IXFK_CommercialistLocation_Location ON commercialapplication.commercialistlocation (LocationId ASC);

ALTER TABLE commercialapplication.commercialistlocation ADD CONSTRAINT FK_CommercialistLocation_Location
	FOREIGN KEY (LocationId) REFERENCES commercialapplication.location (Id) ON DELETE No Action ON UPDATE No Action;
ALTER TABLE commercialapplication.commercialistlocation ADD CONSTRAINT FK_CommercialistLocation_Commercialist
	FOREIGN KEY (CommercialistId) REFERENCES commercialapplication.commercialist (Id) ON DELETE No Action ON UPDATE No Action;
-- create table connection END




DROP TABLE IF EXISTS commercialapplication.product CASCADE;

CREATE TABLE commercialapplication.product
(
	Id integer NOT NULL   DEFAULT NEXTVAL(('commercialapplication."product_id_seq"'::text)::regclass),
	Name varchar(500) UNIQUE NOT NULL,
	UnitCost varchar(500) NOT NULL,
	Description varchar(500) NULL,
	ImageUrl varchar(500) NULL,
	VideoLink varchar(500) NULL,
	SerialNumber varchar(500) NULL
);
ALTER TABLE commercialapplication.product ADD CONSTRAINT PK_Product
	PRIMARY KEY (Id);
	
	
	

DROP TABLE IF EXISTS commercialapplication.storage CASCADE;

CREATE TABLE commercialapplication.storage
(
	Id integer NOT NULL   DEFAULT NEXTVAL(('commercialapplication."storage_id_seq"'::text)::regclass),
	Name varchar(500) NULL,
	Location varchar(500) NULL
);
ALTER TABLE commercialapplication.storage ADD CONSTRAINT PK_Storage
	PRIMARY KEY (Id);



-- create table connection BEGIN
DROP TABLE IF EXISTS commercialapplication.productstorage CASCADE;

CREATE TABLE commercialapplication.productstorage
(
	ProductId integer NOT NULL,
	StorageId integer NOT NULL,
	AmountOfProduct integer NOT NULL
);

ALTER TABLE commercialapplication.productstorage ADD CONSTRAINT PK_ProductStorage
	PRIMARY KEY (ProductId,StorageId);

CREATE INDEX IXFK_ProductStorage_Product ON commercialapplication.productstorage (ProductId ASC);

CREATE INDEX IXFK_ProductStorage_Storage ON commercialapplication.productstorage (StorageId ASC);

ALTER TABLE commercialapplication.productstorage ADD CONSTRAINT FK_ProductStorage_Product
	FOREIGN KEY (ProductId) REFERENCES commercialapplication.product (Id) ON DELETE No Action ON UPDATE No Action;
ALTER TABLE commercialapplication.productstorage ADD CONSTRAINT FK_ProductStorage_Storage
	FOREIGN KEY (StorageId) REFERENCES commercialapplication.storage (Id) ON DELETE No Action ON UPDATE No Action;
-- create table connection END



DROP TABLE IF EXISTS commercialapplication.customer CASCADE;

CREATE TABLE commercialapplication.customer
(
	Id integer NOT NULL   DEFAULT NEXTVAL(('commercialapplication."customer_id_seq"'::text)::regclass),
	Name varchar(500) UNIQUE NOT NULL
);
ALTER TABLE commercialapplication.customer ADD CONSTRAINT PK_Customer
	PRIMARY KEY (Id);
	


DROP TABLE IF EXISTS commercialapplication.contact CASCADE;

CREATE TABLE commercialapplication.contact
(
	Id integer NOT NULL   DEFAULT NEXTVAL(('commercialapplication."contact_id_seq"'::text)::regclass),
	Phone varchar(500) NULL,
	Email varchar(500) NULL
);
ALTER TABLE commercialapplication.contact ADD CONSTRAINT PK_Contact
	PRIMARY KEY (Id);
	
	
	
	
-- create table connection BEGIN
DROP TABLE IF EXISTS commercialapplication.customercontact CASCADE;

CREATE TABLE commercialapplication.customercontact
(
	CustomerId integer NOT NULL,
	ContactId integer NOT NULL
);

ALTER TABLE commercialapplication.customercontact ADD CONSTRAINT PK_CustomerContact
	PRIMARY KEY (CustomerId,ContactId);

CREATE INDEX IXFK_CustomerContact_Customer ON commercialapplication.customercontact (CustomerId ASC);

CREATE INDEX IXFK_CustomerContact_Contact ON commercialapplication.customercontact (ContactId ASC);

ALTER TABLE commercialapplication.customercontact ADD CONSTRAINT FK_CustomerContact_Customer
	FOREIGN KEY (CustomerId) REFERENCES commercialapplication.customer (Id) ON DELETE No Action ON UPDATE No Action;
ALTER TABLE commercialapplication.customercontact ADD CONSTRAINT FK_CustomerContact_Contact
	FOREIGN KEY (ContactId) REFERENCES commercialapplication.contact (Id) ON DELETE No Action ON UPDATE No Action;
-- create table connection END




-- create table connection BEGIN
DROP TABLE IF EXISTS commercialapplication.customerlocation CASCADE;

CREATE TABLE commercialapplication.customerlocation
(
	CustomerId integer NOT NULL,
	LocationId integer NOT NULL
);

ALTER TABLE commercialapplication.customerlocation ADD CONSTRAINT PK_CustomerLocation
	PRIMARY KEY (CustomerId,LocationId);

CREATE INDEX IXFK_CustomerLocation_Customer ON commercialapplication.customerlocation (CustomerId ASC);

CREATE INDEX IXFK_CustomerLocation_Location ON commercialapplication.customerlocation (LocationId ASC);

ALTER TABLE commercialapplication.customerlocation ADD CONSTRAINT FK_CustomerLocation_Customer
	FOREIGN KEY (CustomerId) REFERENCES commercialapplication.customer (Id) ON DELETE No Action ON UPDATE No Action;
ALTER TABLE commercialapplication.customerlocation ADD CONSTRAINT FK_CustomerLocation_Location
	FOREIGN KEY (LocationId) REFERENCES commercialapplication.location (Id) ON DELETE No Action ON UPDATE No Action;
-- create table connection END




DROP TABLE IF EXISTS commercialapplication.sellingprogram CASCADE;

CREATE TABLE commercialapplication.sellingprogram
(
	Id integer NOT NULL   DEFAULT NEXTVAL(('commercialapplication."sellingprogram_id_seq"'::text)::regclass),
	SellingProgram varchar(500) NOT NULL,
	SellingCondition varchar(500) NOT NULL,
	DayForPaying integer NOT NULL
);
ALTER TABLE commercialapplication.sellingprogram ADD CONSTRAINT PK_SellingProgram
	PRIMARY KEY (Id);
	
	
	
	
	
DROP TABLE IF EXISTS commercialapplication.action CASCADE;

CREATE TABLE commercialapplication.action
(
	Id integer NOT NULL   DEFAULT NEXTVAL(('commercialapplication."action_id_seq"'::text)::regclass),
	Productid integer NOT NULL,
	Discount numeric NOT NULL,
	ThresholdAmount integer NOT NULL,
	CustomerId integer NOT NULL
);
ALTER TABLE commercialapplication.action ADD CONSTRAINT PK_Action
	PRIMARY KEY (Id);
ALTER TABLE commercialapplication.action ADD CONSTRAINT FK_Action_Product
	FOREIGN KEY (Productid) REFERENCES commercialapplication.product (Id) ON DELETE No Action ON UPDATE No Action;
ALTER TABLE commercialapplication.action ADD CONSTRAINT FK_Action_Customer
	FOREIGN KEY (CustomerId) REFERENCES commercialapplication.customer (Id) ON DELETE No Action ON UPDATE No Action;
	
	
DROP TABLE IF EXISTS commercialapplication.orderitem CASCADE;

CREATE TABLE commercialapplication.orderitem
(
	Id integer NOT NULL   DEFAULT NEXTVAL(('commercialapplication."orderitem_id_seq"'::text)::regclass),
	Productid integer NOT NULL,
	Amount integer NOT NULL,
	Value NUMERIC(8,2) NOT NULL,
	DiscountBasic numeric NOT NULL,
	ActionId integer NOT NULL
);
ALTER TABLE commercialapplication.orderitem ADD CONSTRAINT PK_Orderitem
	PRIMARY KEY (Id);
ALTER TABLE commercialapplication.orderitem ADD CONSTRAINT FK_Orderitem_Product
	FOREIGN KEY (Productid) REFERENCES commercialapplication.product (Id) ON DELETE No Action ON UPDATE No Action;
ALTER TABLE commercialapplication.orderitem ADD CONSTRAINT FK_Orderitem_Action
	FOREIGN KEY (ActionId) REFERENCES commercialapplication.action (Id) ON DELETE No Action ON UPDATE No Action;
	
	
DROP TABLE IF EXISTS commercialapplication.orderitemmodified CASCADE;

CREATE TABLE commercialapplication.orderitemmodified
(
	Id integer NOT NULL   DEFAULT NEXTVAL(('commercialapplication."orderitemmodified_id_seq"'::text)::regclass),
	OrderItemid integer NOT NULL,
	Productid integer NOT NULL,
	AmountAccepted integer NOT NULL,
	AmountOrdered integer NOT NULL
);
ALTER TABLE commercialapplication.orderitemmodified ADD CONSTRAINT PK_OrderItemModified
	PRIMARY KEY (Id);
ALTER TABLE commercialapplication.orderitemmodified ADD CONSTRAINT FK_OrderItemModified_Orderitem
	FOREIGN KEY (OrderItemid) REFERENCES commercialapplication.orderitem (Id) ON DELETE No Action ON UPDATE No Action;	
	
DROP TABLE IF EXISTS commercialapplication.orderitemrejected CASCADE;
	
CREATE TABLE commercialapplication.orderitemrejected
(
	Id integer NOT NULL   DEFAULT NEXTVAL(('commercialapplication."orderitemrejected_id_seq"'::text)::regclass),
	OrderItemid integer NOT NULL,
	Productid integer NOT NULL,
	AmountOrdered integer NOT NULL
);
ALTER TABLE commercialapplication.orderitemrejected ADD CONSTRAINT PK_OrderItemRejected
	PRIMARY KEY (Id);
ALTER TABLE commercialapplication.orderitemrejected ADD CONSTRAINT FK_OrderItemRejected_Orderitem
	FOREIGN KEY (OrderItemid) REFERENCES commercialapplication.orderitem (Id) ON DELETE No Action ON UPDATE No Action;	
	



DROP TABLE IF EXISTS commercialapplication.orders CASCADE;

CREATE TABLE commercialapplication.orders
(
	Id integer NOT NULL   DEFAULT NEXTVAL(('commercialapplication."orderitem_id_seq"'::text)::regclass),
	IsSynchronized boolean NOT NULL
);
ALTER TABLE commercialapplication.orders ADD CONSTRAINT PK_Orders
	PRIMARY KEY (Id);
	
	
	
	
	
-- create table connection BEGIN
DROP TABLE IF EXISTS commercialapplication.orderitemorders CASCADE;

CREATE TABLE commercialapplication.orderitemorders
(
	OrderItemId integer NOT NULL,
	OrderId integer NOT NULL
);

ALTER TABLE commercialapplication.orderitemorders ADD CONSTRAINT PK_OrderItemOrders
	PRIMARY KEY (OrderItemId,OrderId);

CREATE INDEX IXFK_OrderItemOrders_OrderItem ON commercialapplication.orderitemorders (OrderItemId ASC);

CREATE INDEX IXFK_OrderItemOrders_Order ON commercialapplication.orderitemorders (OrderId ASC);

ALTER TABLE commercialapplication.orderitemorders ADD CONSTRAINT FK_OrderItemOrders_OrderItem
	FOREIGN KEY (OrderItemId) REFERENCES commercialapplication.orderitem (Id) ON DELETE No Action ON UPDATE No Action;
ALTER TABLE commercialapplication.orderitemorders ADD CONSTRAINT FK_OrderItemOrders_Orders
	FOREIGN KEY (OrderId) REFERENCES commercialapplication.orders (Id) ON DELETE No Action ON UPDATE No Action;
-- create table connection END


-- create table connection BEGIN
DROP TABLE IF EXISTS commercialapplication.orderscustomer CASCADE;

CREATE TABLE commercialapplication.orderscustomer
(
	OrderId integer NOT NULL,
	CustomerId integer NOT NULL
);

ALTER TABLE commercialapplication.orderscustomer ADD CONSTRAINT PK_OrdersCustomer
	PRIMARY KEY (OrderId,CustomerId);

CREATE INDEX IXFK_OrdersCustomer_Orders ON commercialapplication.orderscustomer (OrderId ASC);

CREATE INDEX IXFK_OrdersCustomer_Customer ON commercialapplication.orderscustomer (CustomerId ASC);

ALTER TABLE commercialapplication.orderscustomer ADD CONSTRAINT FK_OrdersCustomer_Orders
	FOREIGN KEY (OrderId) REFERENCES commercialapplication.orders (Id) ON DELETE No Action ON UPDATE No Action;
ALTER TABLE commercialapplication.orderscustomer ADD CONSTRAINT FK_OrdersCustomer_Customer
	FOREIGN KEY (CustomerId) REFERENCES commercialapplication.customer (Id) ON DELETE No Action ON UPDATE No Action;
-- create table connection END


-- create table connection BEGIN
DROP TABLE IF EXISTS commercialapplication.orderscommercialist CASCADE;
CREATE TABLE commercialapplication.orderscommercialist
(
	OrderId integer NOT NULL,
	CommercialistId integer NOT NULL
);

ALTER TABLE commercialapplication.orderscommercialist ADD CONSTRAINT PK_OrdersCommercialist
	PRIMARY KEY(OrderId,CommercialistId);

CREATE INDEX IXFK_OrdersCommercialist_Orders ON commercialapplication.orderscommercialist (OrderId ASC);

CREATE INDEX IXFK_OrdersCommercialist_Commercialist ON commercialapplication.orderscommercialist (CommercialistId ASC);

ALTER TABLE commercialapplication.orderscommercialist ADD CONSTRAINT FK_OrderCommercialist_Orders
	FOREIGN KEY (OrderId) REFERENCES commercialapplication.orders (Id) ON DELETE No Action ON UPDATE No Action;

ALTER TABLE commercialapplication.orderscommercialist ADD CONSTRAINT FK_Orders_Commercialist_Commercialist
	FOREIGN KEY (CommercialistId) REFERENCES commercialapplication.commercialist (Id) ON DELETE No Action ON UPDATE No Action;
-- create table connection END 

DROP TABLE IF EXISTS commercialapplication.invoiceitem CASCADE;

CREATE TABLE commercialapplication.invoiceitem
(
	Id integer NOT NULL   DEFAULT NEXTVAL(('commercialapplication."invoiceitem_id_seq"'::text)::regclass),
	Productid integer NOT NULL,
	Amount integer NOT NULL,
	Value NUMERIC(8,2) NOT NULL,
	DiscountBasic numeric NOT NULL,
	ActionId integer NOT NULL
);
ALTER TABLE commercialapplication.invoiceitem ADD CONSTRAINT PK_InvoiceItem
	PRIMARY KEY (Id);
ALTER TABLE commercialapplication.invoiceitem ADD CONSTRAINT FK_InvoiceItem_Product
	FOREIGN KEY (Productid) REFERENCES commercialapplication.product (Id) ON DELETE No Action ON UPDATE No Action;
ALTER TABLE commercialapplication.invoiceitem ADD CONSTRAINT FK_InvoiceItem_Action
	FOREIGN KEY (ActionId) REFERENCES commercialapplication.action (Id) ON DELETE No Action ON UPDATE No Action;
	
	

DROP TABLE IF EXISTS commercialapplication.invoices CASCADE;

CREATE TABLE commercialapplication.invoices
(
	Id integer NOT NULL   DEFAULT NEXTVAL(('commercialapplication."invoices_id_seq"'::text)::regclass),
	SellingProgramId integer NOT NULL
);
ALTER TABLE commercialapplication.invoices ADD CONSTRAINT PK_Invoices
	PRIMARY KEY (Id);
ALTER TABLE commercialapplication.invoices ADD CONSTRAINT FK_Invoices_SellingProgram
	FOREIGN KEY (SellingProgramId) REFERENCES commercialapplication.sellingprogram (Id) ON DELETE No Action ON UPDATE No Action;

-- create table connection BEGIN
DROP TABLE IF EXISTS commercialapplication.invoiceiteminvoices CASCADE;

CREATE TABLE commercialapplication.invoiceiteminvoices
(
	InvoiceId integer NOT NULL,
	InvoiceItemId integer NOT NULL
);

ALTER TABLE commercialapplication.invoiceiteminvoices ADD CONSTRAINT PK_InvoiceItemInvoices
	PRIMARY KEY (InvoiceItemId,InvoiceId);

CREATE INDEX IXFK_InvoiceItemInvoices_Invoices ON commercialapplication.invoices (Id ASC);

CREATE INDEX IXFK_InvoiceItemInvoices_InvoiceItem ON commercialapplication.invoiceitem (Id ASC);

ALTER TABLE commercialapplication.invoiceiteminvoices ADD CONSTRAINT FK_InvoiceItemInvoices_Invoices
	FOREIGN KEY (InvoiceId) REFERENCES commercialapplication.invoices (Id) ON DELETE No Action ON UPDATE No Action;
ALTER TABLE commercialapplication.invoiceiteminvoices ADD CONSTRAINT FK_InvoiceItemInvoices_InvoiceItem
	FOREIGN KEY (InvoiceItemId) REFERENCES commercialapplication.invoiceitem (Id) ON DELETE No Action ON UPDATE No Action;
-- create table connection END	
	
-- create table connection BEGIN
DROP TABLE IF EXISTS commercialapplication.invoicescustomer CASCADE;

CREATE TABLE commercialapplication.invoicescustomer
(
	InvoiceId integer NOT NULL,
	CustomerId integer NOT NULL
);

ALTER TABLE commercialapplication.invoicescustomer ADD CONSTRAINT PK_InvoicesItemCustomer
	PRIMARY KEY (CustomerId,InvoiceId);

CREATE INDEX IXFK_InvoicesCustomer_Invoices ON commercialapplication.invoicescustomer (InvoiceId ASC);

CREATE INDEX IXFK_InvoicesCustomer_Customer ON commercialapplication.invoicescustomer (CustomerId ASC);

ALTER TABLE commercialapplication.invoicescustomer ADD CONSTRAINT FK_InvoicesCustomer_Invoices
	FOREIGN KEY (InvoiceId) REFERENCES commercialapplication.invoices (Id) ON DELETE No Action ON UPDATE No Action;
ALTER TABLE commercialapplication.invoicescustomer ADD CONSTRAINT FK_InvoicesCustomer_Customer
	FOREIGN KEY (CustomerId) REFERENCES commercialapplication.customer (Id) ON DELETE No Action ON UPDATE No Action;
-- create table connection END


-- create table connection BEGIN
DROP TABLE IF EXISTS commercialapplication.invoicescommercialist CASCADE;

CREATE TABLE commercialapplication.invoicescommercialist
(
	InvoiceId integer NOT NULL,
	CommercialistId integer NOT NULL
);

ALTER TABLE commercialapplication.invoicescommercialist ADD CONSTRAINT PK_Invoices_Commercialist
	PRIMARY KEY (CommercialistId, InvoiceId);

CREATE INDEX IXFK_InvoicesCommercialist_Invoices ON commercialapplication.invoicescommercialist (InvoiceId ASC);

CREATE INDEX IXFK_InvoicesCommercialist_Commercialist ON commercialapplication.invoicescommercialist (CommercialistId ASC);

ALTER TABLE commercialapplication.invoicescommercialist ADD CONSTRAINT FK_InvoicesCommercialist_Invoices
	FOREIGN KEY (InvoiceId) REFERENCES commercialapplication.invoices (Id) ON DELETE No Action ON UPDATE No Action;

ALTER TABLE commercialapplication.invoicescommercialist ADD CONSTRAINT FK_InvoicesCommercialist_Commercialist
	FOREIGN KEY (CommercialistId) REFERENCES commercialapplication.commercialist (Id) ON DELETE No Action ON UPDATE No Action;
-- create table connection END


DROP TABLE IF EXISTS commercialapplication.events CASCADE;

CREATE TABLE commercialapplication.events
(
	Id integer NOT NULL   DEFAULT NEXTVAL(('commercialapplication."events_id_seq"'::text)::regclass),
	IsOutputFromStorages boolean NOT NULL,
	IsInputFromStorages boolean NOT NULL,
	Description varchar(500) NOT NULL
);
ALTER TABLE commercialapplication.events ADD CONSTRAINT PK_Events
	PRIMARY KEY (Id);
	
	
	
	
DROP TABLE IF EXISTS commercialapplication.eventstransaction CASCADE;

CREATE TABLE commercialapplication.eventstransaction
(
	Id integer NOT NULL   DEFAULT NEXTVAL(('commercialapplication."eventstransaction_id_seq"'::text)::regclass),
	EventId integer NOT NULL,
	DateTime timestamp without time zone NOT NULL
);
ALTER TABLE commercialapplication.eventstransaction ADD CONSTRAINT PK_EventsTransaction
	PRIMARY KEY (Id);
ALTER TABLE commercialapplication.eventstransaction ADD CONSTRAINT FK_EventsTransaction_Events
	FOREIGN KEY (EventId) REFERENCES commercialapplication.events (Id) ON DELETE No Action ON UPDATE No Action;
	
	
	
DROP TABLE IF EXISTS commercialapplication.eventsother CASCADE;

CREATE TABLE commercialapplication.eventsother
(
	Id integer NOT NULL   DEFAULT NEXTVAL(('commercialapplication."eventsother_id_seq"'::text)::regclass),
	EventId integer NOT NULL,
	DateTime timestamp without time zone NOT NULL
);
ALTER TABLE commercialapplication.eventsother ADD CONSTRAINT PK_EventsOther
	PRIMARY KEY (Id);
ALTER TABLE commercialapplication.eventsother ADD CONSTRAINT FK_EventsOther_Events
	FOREIGN KEY (EventId) REFERENCES commercialapplication.events (Id) ON DELETE No Action ON UPDATE No Action;



DROP TABLE IF EXISTS commercialapplication.saleschannel CASCADE;

CREATE TABLE commercialapplication.saleschannel
(
	Id integer NOT NULL DEFAULT NEXTVAL(('commercialapplication."saleschannel_id_seq"'::text)::regclass),
	Name varchar(500) UNIQUE NOT NULL,
	Description varchar(500) NOT NULL
);

ALTER TABLE commercialapplication.saleschannel ADD CONSTRAINT PK_SalesChannel
	PRIMARY KEY (ID);



DROP TABLE IF EXISTS commercialapplication.customersaleschannel

CREATE TABLE commercialapplication.customersaleschannel
(
	CustomerId integer NOT NULL,
	SalesChannelId integer NOT NULL
);

ALTER TABLE commercialapplication.customersaleschannel ADD CONSTRAINT PK_CustomerSalesChannel
	PRIMARY KEY(CustomerId);
ALTER TABLE commercialapplication.customersaleschannel ADD CONSTRAINT FK_CustomerSalesChannel_SalesChannel
	FOREIGN KEY (SalesChannelId) REFERENCES commercialapplication.saleschannel (Id) ON DELETE No Action ON UPDATE No Action;
ALTER TABLE commercialapplication.customersaleschannel ADD CONSTRAINT FK_CustomerSalesChannel_Customer
	FOREIGN KEY(CustomerId) REFERENCES commercialapplication.customer (Id) ON DELETE No Action ON UPDATE No Action;