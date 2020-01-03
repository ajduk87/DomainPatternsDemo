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




-- CUSTOMER --