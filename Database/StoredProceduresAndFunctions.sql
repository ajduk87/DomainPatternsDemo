-- ACTION --

CREATE FUNCTION insert_action(productid integer, discount numeric, thresholdAmount integer, customerId integer)
RETURNS BOOLEAN AS $$
BEGIN
        INSERT INTO commercialapplication.action(productid, discount, thresholdamount, customerid)
										  VALUES(productid, discount, thresholdamount, customerid);

        RETURN true;
END;
$$  LANGUAGE plpgsql
    SECURITY DEFINER
    -- Set a secure search_path: trusted schema(s), then 'pg_temp'.
    SET search_path = admin, pg_temp;
	
	
CREATE FUNCTION update_action(criteriaid integer, productid integer, discount numeric, thresholdAmount integer, customerId integer)
RETURNS BOOLEAN AS $$
BEGIN
        UPDATE INTO commercialapplication.action(productid, discount, thresholdamount, customerid)
										  VALUES(productid, discount, thresholdamount, customerid)
										  WHERE id = criteriaId;;

        RETURN true;
END;
$$  LANGUAGE plpgsql
    SECURITY DEFINER
    -- Set a secure search_path: trusted schema(s), then 'pg_temp'.
    SET search_path = admin, pg_temp;
	
CREATE FUNCTION update_action_bycustomerid(productid integer, discount numeric, thresholdAmount integer, customerCriteriaId integer)
RETURNS BOOLEAN AS $$
BEGIN
        UPDATE INTO commercialapplication.action(productid, discount, thresholdamount)
										  VALUES(productid, discount, thresholdamount)
										  WHERE customerid = customerCriteriaId;

        RETURN true;
END;
$$  LANGUAGE plpgsql
    SECURITY DEFINER
    -- Set a secure search_path: trusted schema(s), then 'pg_temp'.
    SET search_path = admin, pg_temp;
	
CREATE FUNCTION delete_action(criteriaid integer)
RETURNS BOOLEAN AS $$
BEGIN
        DELETE FROM commercialapplication.action WHERE id = criteriaid

        RETURN true;
END;
$$  LANGUAGE plpgsql
    SECURITY DEFINER
    -- Set a secure search_path: trusted schema(s), then 'pg_temp'.
    SET search_path = admin, pg_temp;
	
	
CREATE OR REPLACE FUNCTION select_action() RETURNS refcursor AS $$
    DECLARE
      ref refcursor;                                                     -- Declare a cursor variable
    BEGIN
      OPEN ref FOR SELECT * FROM commercialapplication.action;   -- Open a cursor
      RETURN ref;                                                       -- Return the cursor to the caller
    END;
    $$ LANGUAGE plpgsql;

CREATE OR REPLACE FUNCTION select_action_byid(criteriaid integer) RETURNS refcursor AS $$
    DECLARE
      ref refcursor;                                                     -- Declare a cursor variable
    BEGIN
      OPEN ref FOR SELECT * FROM commercialapplication.action WHERE id = criteriaid;   -- Open a cursor
      RETURN ref;                                                       -- Return the cursor to the caller
    END;
    $$ LANGUAGE plpgsql;	
-- ACTION --





-- CUSTOMER --

CREATE FUNCTION insert_customer(name varchar(500))
RETURNS BOOLEAN AS $$
BEGIN
        INSERT INTO commercialapplication.customer(name)
										  VALUES(name);

        RETURN true;
END;
$$  LANGUAGE plpgsql
    SECURITY DEFINER
    -- Set a secure search_path: trusted schema(s), then 'pg_temp'.
    SET search_path = admin, pg_temp;
	
	
CREATE FUNCTION update_customer(name varchar(500), criteriaId integer)
RETURNS BOOLEAN AS $$
BEGIN
        UPDATE INTO commercialapplication.customer(name)
										  VALUES(name)
										  WHERE id = criteriaId;

        RETURN true;
END;
$$  LANGUAGE plpgsql
    SECURITY DEFINER
    -- Set a secure search_path: trusted schema(s), then 'pg_temp'.
    SET search_path = admin, pg_temp;	
	
CREATE FUNCTION delete_customer(criteriaid integer)
RETURNS BOOLEAN AS $$
BEGIN
        DELETE FROM commercialapplication.customer WHERE id = criteriaid

        RETURN true;
END;
$$  LANGUAGE plpgsql
    SECURITY DEFINER
    -- Set a secure search_path: trusted schema(s), then 'pg_temp'.
    SET search_path = admin, pg_temp;	


CREATE OR REPLACE FUNCTION select_customer() RETURNS refcursor AS $$
    DECLARE
      ref refcursor;                                                     -- Declare a cursor variable
    BEGIN
      OPEN ref FOR SELECT * FROM commercialapplication.customer;   -- Open a cursor
      RETURN ref;                                                       -- Return the cursor to the caller
    END;
    $$ LANGUAGE plpgsql;

CREATE OR REPLACE FUNCTION select_customer_byid(criteriaid integer) RETURNS refcursor AS $$
    DECLARE
      ref refcursor;                                                     -- Declare a cursor variable
    BEGIN
      OPEN ref FOR SELECT * FROM commercialapplication.customer WHERE id = criteriaid;   -- Open a cursor
      RETURN ref;                                                       -- Return the cursor to the caller
    END;
    $$ LANGUAGE plpgsql;


-- CUSTOMER --


-- PRODUCT --

CREATE OR REPLACE FUNCTION select_product() RETURNS refcursor AS $$
    DECLARE
      ref refcursor;                                                     -- Declare a cursor variable
    BEGIN
      OPEN ref FOR SELECT id, name, unitcost, description, imageurl, videolink
	  FROM commercialapplication.product;   -- Open a cursor
      RETURN ref;                                                       -- Return the cursor to the caller
    END;
    $$ LANGUAGE plpgsql;
	
CREATE OR REPLACE FUNCTION select_product_byid(criteriaid integer) RETURNS refcursor AS $$
    DECLARE
      ref refcursor;                                                     -- Declare a cursor variable
    BEGIN
      OPEN ref FOR SELECT * FROM commercialapplication.product WHERE id = criteriaid;   -- Open a cursor
      RETURN ref;                                                       -- Return the cursor to the caller
    END;
    $$ LANGUAGE plpgsql;
	
CREATE OR REPLACE FUNCTION select_product_byname(criterianame varchar(500)) RETURNS refcursor AS $$
    DECLARE
      ref refcursor;                                                     -- Declare a cursor variable
    BEGIN
      OPEN ref FOR SELECT * FROM commercialapplication.product WHERE name = criterianame;   -- Open a cursor
      RETURN ref;                                                       -- Return the cursor to the caller
    END;
    $$ LANGUAGE plpgsql;
	
CREATE OR REPLACE FUNCTION select_fruits(criterianame varchar(500)) RETURNS refcursor AS $$
    DECLARE
      ref refcursor;                                                     -- Declare a cursor variable
    BEGIN
      OPEN ref FOR SELECT * FROM commercialapplication.product WHERE kindofproduct = 'fruit';   -- Open a cursor
      RETURN ref;                                                       -- Return the cursor to the caller
    END;
    $$ LANGUAGE plpgsql;
	
CREATE OR REPLACE FUNCTION select_vegetables(criterianame varchar(500)) RETURNS refcursor AS $$
    DECLARE
      ref refcursor;                                                     -- Declare a cursor variable
    BEGIN
      OPEN ref FOR SELECT * FROM commercialapplication.product WHERE kindofproduct = 'vegetable';   -- Open a cursor
      RETURN ref;                                                       -- Return the cursor to the caller
    END;
    $$ LANGUAGE plpgsql;
	
CREATE FUNCTION delete_product(criteriaid integer)
RETURNS BOOLEAN AS $$
BEGIN
        DELETE FROM commercialapplication.product WHERE id = criteriaid

        RETURN true;
END;
$$  LANGUAGE plpgsql
    SECURITY DEFINER
    -- Set a secure search_path: trusted schema(s), then 'pg_temp'.
    SET search_path = admin, pg_temp;

CREATE FUNCTION delete_product_fromstorage(criteriaproductid integer, criteriastorageid integer)
RETURNS BOOLEAN AS $$
BEGIN
        DELETE FROM commercialapplication.productstorage
		WHERE productid = criteriaproductid AND storageid = criteriastorageid

        RETURN true;
END;
$$  LANGUAGE plpgsql
    SECURITY DEFINER
    -- Set a secure search_path: trusted schema(s), then 'pg_temp'.
    SET search_path = admin, pg_temp;
	
CREATE OR REPLACE FUNCTION select_products_fromstorage(criteriastorageid integer) RETURNS refcursor AS $$
    DECLARE
      ref refcursor;                                                     -- Declare a cursor variable
    BEGIN
      OPEN ref FOR SELECT * FROM commercialapplication.productstorage WHERE storageid = criteriastorageid;   -- Open a cursor
      RETURN ref;                                                       -- Return the cursor to the caller
    END;
    $$ LANGUAGE plpgsql;
	
	
CREATE OR REPLACE FUNCTION select_product_fromallstorages(criteriaproductid integer) RETURNS refcursor AS $$
    DECLARE
      ref refcursor;                                                     -- Declare a cursor variable
    BEGIN
      OPEN ref FOR SELECT * FROM commercialapplication.productstorage WHERE productid = criteriaproductid;   -- Open a cursor
      RETURN ref;                                                       -- Return the cursor to the caller
    END;
    $$ LANGUAGE plpgsql;
	
	
CREATE FUNCTION insert_product(name varchar(500), unitcost varchar(500), description varchar(500), imageurl varchar(500), videolink varchar(500), serialnumber varchar(500), state varchar(500))
RETURNS BOOLEAN AS $$
BEGIN
        INSERT INTO commercialapplication.product(name, unitcost, description, imageurl, videolink, serialnumber, state)
										  VALUES (name, unitcost, description, imageurl, videolink, serialnumber, state);

        RETURN true;
END;
$$  LANGUAGE plpgsql
    SECURITY DEFINER
    -- Set a secure search_path: trusted schema(s), then 'pg_temp'.
    SET search_path = admin, pg_temp;
	
CREATE FUNCTION update_product(criteriaid integer, name varchar(500), unitcost varchar(500), description varchar(500), imageurl varchar(500), videolink varchar(500), serialnumber varchar(500), state varchar(500))
RETURNS BOOLEAN AS $$
BEGIN
        UPDATE commercialapplication.product
		SET name = name, unitcost = unitcost, description = description, imageurl = imageurl, videolink = videolink, state = state
		WHERE id = criteriaid;

        RETURN true;
END;
$$  LANGUAGE plpgsql
    SECURITY DEFINER
    -- Set a secure search_path: trusted schema(s), then 'pg_temp'.
    SET search_path = admin, pg_temp;
	
CREATE FUNCTION update_fruits(percent numeric(8,2))
DECLARE 
   fruit RECORD;
   numberOfFruits integer;
RETURNS BOOLEAN AS $$
BEGIN
		numberOfFruits := SELECT COUNT(*) FROM commercialapplication.product WHERE kindofproduct = 'fruit';
        FOR fruit IN SELECT id.unitcost 
         FROM commercialapplication.product 
         LIMIT numberOfFruits 
		 LOOP 
			UPDATE commercialapplication.product
			SET unitcost = (fruit.unitcost * percent/100)
			WHERE id = fruit.id;
		 END LOOP;
       

        RETURN true;
END;
$$  LANGUAGE plpgsql
    SECURITY DEFINER
    -- Set a secure search_path: trusted schema(s), then 'pg_temp'.
    SET search_path = admin, pg_temp;
	
	
CREATE FUNCTION update_vegetables(percent numeric(8,2))
DECLARE 
   vegetable RECORD;
   numberOfFruits integer;
RETURNS BOOLEAN AS $$
BEGIN
		numberOfFruits := SELECT COUNT(*) FROM commercialapplication.product WHERE kindofproduct = 'fruit';
        FOR vegetable IN SELECT id.unitcost 
         FROM commercialapplication.product 
         LIMIT numberOfFruits 
		 LOOP 
			UPDATE commercialapplication.product
			SET unitcost = (vegetable.unitcost * percent/100)
			WHERE id = vegetable.id;
		 END LOOP;
       

        RETURN true;
END;

CREATE FUNCTION update_product_state(criterianame varchar(500), newstate varchar(500),)
DECLARE 
   vegetable RECORD;
   numberOfFruits integer;
RETURNS BOOLEAN AS $$
BEGIN
		numberOfFruits := SELECT COUNT(*) FROM commercialapplication.product WHERE kindofproduct = 'fruit';
        FOR vegetable IN SELECT id.unitcost 
         FROM commercialapplication.product 
         LIMIT numberOfFruits 
		 LOOP 
			UPDATE commercialapplication.product
			SET state = newstate
			WHERE name = criterianame;
		 END LOOP;
       

        RETURN true;
END;
	
	
CREATE FUNCTION insert_storageitem(productId integer, storageid integer, amountofproduct integer)
RETURNS BOOLEAN AS $$
BEGIN
        INSERT INTO commercialapplication.productstorage(productId, storageid, amountofproduct)
												 VALUES (productid, storageid, amountofproduct)

        RETURN true;
END;
$$  LANGUAGE plpgsql
    SECURITY DEFINER
    -- Set a secure search_path: trusted schema(s), then 'pg_temp'.
    SET search_path = admin, pg_temp;
	
-- PRODUCT --


-- STORAGE --

CREATE OR REPLACE FUNCTION select_storage() RETURNS refcursor AS $$
    DECLARE
      ref refcursor;                                                     -- Declare a cursor variable
    BEGIN
      OPEN ref FOR SELECT * FROM commercialapplication.storage;   -- Open a cursor
      RETURN ref;                                                       -- Return the cursor to the caller
    END;
    $$ LANGUAGE plpgsql;
	
CREATE OR REPLACE FUNCTION select_storage_byname(criterianame varchar(500)) RETURNS refcursor AS $$
    DECLARE
      ref refcursor;                                                     -- Declare a cursor variable
    BEGIN
      OPEN ref FOR SELECT id, name, location
	  FROM commercialapplication.storage
	  WHERE name = criterianame   -- Open a cursor
      RETURN ref;                                                       -- Return the cursor to the caller
    END;
    $$ LANGUAGE plpgsql;
	
CREATE FUNCTION insert_storage(name varchar(500), location varchar(500))
RETURNS BOOLEAN AS $$
BEGIN
       INSERT INTO commercialapplication.storage(name, location)
										 VALUES (name, location)

        RETURN true;
END;
$$  LANGUAGE plpgsql
    SECURITY DEFINER
    -- Set a secure search_path: trusted schema(s), then 'pg_temp'.
    SET search_path = admin, pg_temp;
	
	
CREATE FUNCTION update_storage(criteriaid integer,name varchar(500), location varchar(500))
RETURNS BOOLEAN AS $$
BEGIN
        UPDATE commercialapplication.storage
		SET name = name, location = location
		WHERE id = criteriaid

        RETURN true;
END;
$$  LANGUAGE plpgsql
    SECURITY DEFINER
    -- Set a secure search_path: trusted schema(s), then 'pg_temp'.
    SET search_path = admin, pg_temp;
	
CREATE FUNCTION delete_storage(criteriaid integer)
RETURNS BOOLEAN AS $$
BEGIN
        DELETE FROM commercialapplication.storage WHERE id = criteriaid

        RETURN true;
END;
$$  LANGUAGE plpgsql
    SECURITY DEFINER
    -- Set a secure search_path: trusted schema(s), then 'pg_temp'.
    SET search_path = admin, pg_temp;

-- STORAGE --

-- ORDER --

CREATE FUNCTION delete_orderitem_byid(criteriaid integer)
RETURNS BOOLEAN AS $$
BEGIN
        DELETE FROM commercialapplication.orderitem
		WHERE id = criteriaid;
END;
$$  LANGUAGE plpgsql
    SECURITY DEFINER
    -- Set a secure search_path: trusted schema(s), then 'pg_temp'.
    SET search_path = admin, pg_temp;
	
	
CREATE FUNCTION delete_orderitem_byids(criteriaids integer[])
RETURNS BOOLEAN AS $$
BEGIN
		FOR criteriaid IN criteriaids 
		 LOOP 
			DELETE FROM commercialapplication.orderitem
		    WHERE id = criteriaid;
		 END LOOP;

        
END;
$$  LANGUAGE plpgsql
    SECURITY DEFINER
    -- Set a secure search_path: trusted schema(s), then 'pg_temp'.
    SET search_path = admin, pg_temp;
	
	
CREATE OR REPLACE FUNCTION select_orderitem_byid(criteriaid integer) RETURNS refcursor AS $$
    DECLARE
      ref refcursor;                                                     -- Declare a cursor variable
    BEGIN
      OPEN ref FOR SELECT * FROM commercialapplication.orderitem WHERE id = criteriaid;   -- Open a cursor
      RETURN ref;                                                       -- Return the cursor to the caller
    END;
    $$ LANGUAGE plpgsql;
	
CREATE OR REPLACE FUNCTION select_orderitem_byids(criteriaids integer[]) RETURNS refcursor AS $$
    DECLARE
      ref refcursor;                                                     -- Declare a cursor variable
    BEGIN
	  OPEN ref FOR criteriaid IN criteriaids 
		 LOOP 
			SELECT * FROM commercialapplication.orderitem 
			WHERE id = criteriaid; 
		 END LOOP;
      RETURN ref;                                                       -- Return the cursor to the caller
    END;
    $$ LANGUAGE plpgsql;
	
CREATE TYPE OrderItem AS (Id integer, ProductId integer, Amount integer, Value varchar(500), DiscountBasic numeric(8,2), ActionId integer);

CREATE FUNCTION include_discount_for_paying(orderitems OrderItem[])
RETURNS BOOLEAN AS $$
BEGIN
       FOR orderitem IN orderitems 
		 LOOP 
		    unitCost := (SELECT unitCost FROM commercialapplication.product WHERE id = orderitem.ProductId; );
		    orderitem.Value = orderitem.Amount * unitCost * (orderitem.DiscountBasic/100);
			thresholdAmount := (SELECT thresholdAmount FROM commercialapplication.action WHERE id = orderitem.ActionId; );
			discountAction  := (SELECT discount FROM commercialapplication.action WHERE id = orderitem.ActionId; );
			IF(orderitem.Amount >= thresholdAmount)
				orderitem.Value = orderitem.Value * (discountAction/100);
			END IF
		END LOOP;

        RETURN true;
END;
$$  LANGUAGE plpgsql
    SECURITY DEFINER
    -- Set a secure search_path: trusted schema(s), then 'pg_temp'.
    SET search_path = admin, pg_temp;
	
CREATE FUNCTION insert_orderitem(orderitem OrderItem)
RETURNS BOOLEAN AS $$
BEGIN
        INSERT INTO commercialapplication.orderitem(productId, amount, value, discountbasic, actionId)
										    VALUES (orderitem.ProductId, orderitem.Amount, orderitem.Value, orderitem.DiscountBasic, orderitem.ActionId)

        RETURN true;
END;
$$  LANGUAGE plpgsql
    SECURITY DEFINER
    -- Set a secure search_path: trusted schema(s), then 'pg_temp'.
    SET search_path = admin, pg_temp;
	
CREATE FUNCTION insertlist_orderitem(orderitems OrderItem[])
RETURNS BOOLEAN AS $$
BEGIN
		FOR orderitem IN orderitems 
		LOOP 
		    INSERT INTO commercialapplication.orderitem(productId, amount, value, discountbasic, actionId)
			                              VALUES (orderitem.ProductId, orderitem.Amount, orderitem.Value, orderitem.DiscountBasic, orderitem.ActionId);
		END LOOP;


        RETURN true;
END;
$$  LANGUAGE plpgsql
    SECURITY DEFINER
    -- Set a secure search_path: trusted schema(s), then 'pg_temp'.
    SET search_path = admin, pg_temp;
	
CREATE FUNCTION update_orderitem(orderitem OrderItem)
RETURNS BOOLEAN AS $$
BEGIN
        UPDATE commercialapplication.orderitem
		SET productId = orderitem.ProductId, amount = orderitem.Amount, value = orderitem.Value, discountbasic = orderitem.DiscountBasic, actionId = orderitem.ActionId
		WHERE id = orderitem.Id;

        RETURN true;
END;
$$  LANGUAGE plpgsql
    SECURITY DEFINER
    -- Set a secure search_path: trusted schema(s), then 'pg_temp'.
    SET search_path = admin, pg_temp;
	
	
CREATE FUNCTION updatelist_orderitem(orderitems OrderItem[])
RETURNS BOOLEAN AS $$
BEGIN
		FOR orderitem IN orderitems 
		LOOP 
		    UPDATE commercialapplication.orderitem
		    SET productId = orderitem.ProductId, amount = orderitem.Amount, value = orderitem.Value, discountbasic = orderitem.DiscountBasic, actionId = orderitem.ActionId
		    WHERE id = orderitem.Id;
		END LOOP;
        

        RETURN true;
END;
$$  LANGUAGE plpgsql
    SECURITY DEFINER
    -- Set a secure search_path: trusted schema(s), then 'pg_temp'.
    SET search_path = admin, pg_temp;
	
	
CREATE FUNCTION delete_orderitemoder_byorderid(criteriaid integer)
RETURNS BOOLEAN AS $$
BEGIN
		DELETE FROM commercialapplication.orderitemorders
		WHERE orderid = criteriaid;        
END;
$$  LANGUAGE plpgsql
    SECURITY DEFINER
    -- Set a secure search_path: trusted schema(s), then 'pg_temp'.
    SET search_path = admin, pg_temp;


CREATE OR REPLACE FUNCTION select_orderitemids_byorderid(criteriaid integer) RETURNS refcursor AS $$
    DECLARE
      ref refcursor;                                                     -- Declare a cursor variable
    BEGIN
      OPEN ref FOR SELECT orderitemid
					FROM commercialapplication.orderitemorders
					WHERE orderid = @orderid   -- Open a cursor
      RETURN ref;                                                       -- Return the cursor to the caller
    END;
    $$ LANGUAGE plpgsql;

CREATE TYPE OrderItem AS (Id integer, OrderItemId integer);

CREATE FUNCTION connect_orderitem_with_order(orderitems OrderItem[], long orderId)
RETURNS BOOLEAN AS $$
BEGIN
		FOR orderitem IN orderitems 
		LOOP 
		    INSERT INTO commercialapplication.orderitemorders(orderid, orderitemid)
			VALUES (orderId, orderitem.orderitemid)
		END LOOP;


        RETURN true;
END;
$$  LANGUAGE plpgsql
    SECURITY DEFINER
    -- Set a secure search_path: trusted schema(s), then 'pg_temp'.
    SET search_path = admin, pg_temp;
	
CREATE FUNCTION delete_ordercustomer(criteriaid integer)
RETURNS BOOLEAN AS $$
BEGIN
        DELETE FROM commercialapplication.orderscustomer
		WHERE orderid = criteriaid

        RETURN true;
END;
$$  LANGUAGE plpgsql
    SECURITY DEFINER
    -- Set a secure search_path: trusted schema(s), then 'pg_temp'.
    SET search_path = admin, pg_temp;
	
CREATE TYPE OrderCustomer AS (orderId integer, customerId integer);
	
CREATE FUNCTION insert_ordercustomer(orderCustomer OrderCustomer)
RETURNS BOOLEAN AS $$
BEGIN
        INSERT INTO commercialapplication.orderscustomer (orderid, customerid)
												  VALUES (orderCustomer.orderid, orderCustomer.customerid)

        RETURN true;
END;
$$  LANGUAGE plpgsql
    SECURITY DEFINER
    -- Set a secure search_path: trusted schema(s), then 'pg_temp'.
    SET search_path = admin, pg_temp;
	
CREATE FUNCTION update_ordercustomer(orderCustomer OrderCustomer)
RETURNS BOOLEAN AS $$
BEGIN
        UPDATE commercialapplication.orderscustomer
		SET customerid = orderCustomer.customerid
		WHERE orderid = orderCustomer.orderid

        RETURN true;
END;
$$  LANGUAGE plpgsql
    SECURITY DEFINER
    -- Set a secure search_path: trusted schema(s), then 'pg_temp'.
    SET search_path = admin, pg_temp;
	
CREATE OR REPLACE FUNCTION select_ordercustomer_byorderid(criteriaid integer) RETURNS refcursor AS $$
    DECLARE
      ref refcursor;                                                     -- Declare a cursor variable
    BEGIN
      OPEN ref FOR SELECT * FROM commercialapplication.orderscustomer 
							WHERE orderId = criteriaid;   -- Open a cursor
      RETURN ref;                                                       -- Return the cursor to the caller
    END;
    $$ LANGUAGE plpgsql;
	
	
CREATE TYPE Order AS (id integer, state varchar(500), creationDate varchar(500));

CREATE FUNCTION delete_order(criteriaid integer)
RETURNS BOOLEAN AS $$
BEGIN
        DELETE FROM commercialapplication.orders
		WHERE id = criteriaid;

        RETURN true;
END;
$$  LANGUAGE plpgsql
    SECURITY DEFINER
    -- Set a secure search_path: trusted schema(s), then 'pg_temp'.
    SET search_path = admin, pg_temp;
	
CREATE FUNCTION insert_order(order Order)
RETURNS BOOLEAN AS $$
BEGIN
        INSERT INTO commercialapplication.orders(state, creationDate)
		VALUES(order.state, order.creationDate);

        RETURN true;
END;
$$  LANGUAGE plpgsql
    SECURITY DEFINER
    -- Set a secure search_path: trusted schema(s), then 'pg_temp'.
    SET search_path = admin, pg_temp;
	
CREATE FUNCTION update_order(order Order)
RETURNS BOOLEAN AS $$
BEGIN
        UPDATE commercialapplication.orders
		SET state = order.state, creationDate = order.creationDate
		WHERE id = orderid

        RETURN true;
END;
$$  LANGUAGE plpgsql
    SECURITY DEFINER
    -- Set a secure search_path: trusted schema(s), then 'pg_temp'.
    SET search_path = admin, pg_temp;
	
CREATE OR REPLACE FUNCTION select_order_byid(criteriaid integer) RETURNS refcursor AS $$
    DECLARE
      ref refcursor;                                                     -- Declare a cursor variable
    BEGIN
      OPEN ref FOR SELECT * FROM commercialapplication.orders WHERE id = criteriaid;   -- Open a cursor
      RETURN ref;                                                       -- Return the cursor to the caller
    END;
    $$ LANGUAGE plpgsql;
	
CREATE OR REPLACE FUNCTION select_orders_byday(criteriaday integer) RETURNS refcursor AS $$
    DECLARE
      ref refcursor;                                                     -- Declare a cursor variable
    BEGIN
      OPEN ref FOR SELECT * FROM commercialapplication.orders WHERE creationDate = criteriaday;   -- Open a cursor
      RETURN ref;                                                       -- Return the cursor to the caller
    END;
    $$ LANGUAGE plpgsql;

-- ORDER --