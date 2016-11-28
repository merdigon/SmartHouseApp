CREATE TABLE device_category_domain
(
  id serial NOT NULL,
  name character varying(100),
  CONSTRAINT ddd PRIMARY KEY (id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE device_category_domain
  OWNER TO postgres;


CREATE TABLE light_device_domain
(
  device_id serial NOT NULL,
  visible_name character varying(100),
  ip character varying(100),
  port character varying(100),
  min_percentage_power integer,
  max_percentage_power integer,
  coordinate_x numeric(15,2),
  coordinate_y numeric(15,2),
  coordinate_z numeric(15,2),
  CONSTRAINT aaa PRIMARY KEY (device_id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE light_device_domain
  OWNER TO postgres;


CREATE TABLE user_possition
(
  id serial NOT NULL,
  mac character varying(100),
  coordinate_x numeric(15,2),
  coordinate_y numeric(15,2),
  coordinate_z numeric(15,2),
  date timestamp with time zone,
  CONSTRAINT fsdf PRIMARY KEY (id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE user_possition
  OWNER TO postgres;