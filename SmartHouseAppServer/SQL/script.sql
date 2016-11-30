CREATE SEQUENCE public.light_device_interface_id_seq
  INCREMENT 1
  MINVALUE 1
  MAXVALUE 9223372036854775807
  START 1
  CACHE 1;
ALTER TABLE public.light_device_interface_id_seq
  OWNER TO postgres;

    CREATE SEQUENCE public.light_device_domain_device_id_seq
  INCREMENT 1
  MINVALUE 1
  MAXVALUE 9223372036854775807
  START 1
  CACHE 1;
ALTER TABLE public.light_device_domain_device_id_seq
  OWNER TO postgres;

  CREATE SEQUENCE public.device_category_domain_id_seq
  INCREMENT 1
  MINVALUE 1
  MAXVALUE 9223372036854775807
  START 1
  CACHE 1;
ALTER TABLE public.device_category_domain_id_seq
  OWNER TO postgres;

  CREATE SEQUENCE public.user_possition_id_seq
  INCREMENT 1
  MINVALUE 1
  MAXVALUE 9223372036854775807
  START 1
  CACHE 1;
ALTER TABLE public.user_possition_id_seq
  OWNER TO postgres;


--light_device_interface
CREATE TABLE public.light_device_interface
(
    id integer NOT NULL DEFAULT nextval('light_device_interface_id_seq'::regclass),
    visible_name character varying(100) COLLATE pg_catalog."default" NOT NULL,
    interface_class_name character varying(100) COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT light_device_interface_pkey PRIMARY KEY (id)
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public.light_device_interface
    OWNER to postgres;

--device_category_domain
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

--light_device_domain
CREATE TABLE public.light_device_domain
(
    device_id integer NOT NULL DEFAULT nextval('light_device_domain_device_id_seq'::regclass),
    visible_name character varying COLLATE pg_catalog."default" NOT NULL,
    ip character varying(100) COLLATE pg_catalog."default" NOT NULL,
    port character varying(8) COLLATE pg_catalog."default" NOT NULL,
    min_percentage_power integer,
    max_percentage_power integer,
    coordinate_x numeric(15, 2) NOT NULL,
    coordinate_y numeric(15, 2) NOT NULL,
    coordinate_z numeric(15, 2) NOT NULL,
    interface_id integer,
    active boolean NOT NULL DEFAULT true,
    CONSTRAINT "light_Device_Domain_pkey" PRIMARY KEY (device_id),
    CONSTRAINT light_device_interface_fkey FOREIGN KEY (interface_id)
        REFERENCES public.light_device_interface (id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public.light_device_domain
    OWNER to postgres;

--user_possition
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
  
--router_type;
CREATE TABLE public.router_type
(
  id integer NOT NULL DEFAULT nextval('router_type_id_seq'::regclass),
  visible_name character varying(100),
  CONSTRAINT gdg PRIMARY KEY (id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE public.router_type
  OWNER TO postgres;
  
--static_router_info;
CREATE TABLE public.static_router_info
(
  id integer NOT NULL DEFAULT nextval('static_router_info_id_seq'::regclass),
  ssid character varying(100),
  transmitter_power numeric(15,2),
  antenna_gain numeric(15,2),
  fade_margin numeric(15,2),
  coordinate_x numeric(15,2),
  coordinate_y numeric(15,2),
  coordinate_z numeric(15,2),
  weight integer,
  router_type_id integer,
  CONSTRAINT fgd PRIMARY KEY (id),
  CONSTRAINT hfnh FOREIGN KEY (router_type_id)
      REFERENCES public.router_type (id) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION
)
WITH (
  OIDS=FALSE
);
ALTER TABLE public.static_router_info
  OWNER TO postgres;
  
--system_user;
CREATE TABLE public.system_user
(
  id integer NOT NULL DEFAULT nextval('system_user_id_seq'::regclass),
  mac character varying(100),
  user_weight integer DEFAULT 1,
  visible_name character varying(100) NOT NULL DEFAULT 'Guest'::character varying,
  CONSTRAINT sdf PRIMARY KEY (id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE public.system_user
  OWNER TO postgres;