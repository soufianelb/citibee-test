--
-- PostgreSQL database dump
--

-- Dumped from database version 10.13
-- Dumped by pg_dump version 10.13

-- Started on 2021-02-12 15:30:07
 CREATE DATABASE IF NOT EXISTS citibee
SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 1 (class 3079 OID 12924)
-- Name: plpgsql; Type: EXTENSION; Schema: -; Owner: 
--

CREATE EXTENSION IF NOT EXISTS plpgsql WITH SCHEMA pg_catalog;


--
-- TOC entry 2843 (class 0 OID 0)
-- Dependencies: 1
-- Name: EXTENSION plpgsql; Type: COMMENT; Schema: -; Owner: 
--

COMMENT ON EXTENSION plpgsql IS 'PL/pgSQL procedural language';


--
-- TOC entry 201 (class 1259 OID 287334)
-- Name: gebruiker_id_sequances; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.gebruiker_id_sequances
    START WITH 9999
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.gebruiker_id_sequances OWNER TO postgres;

SET default_tablespace = '';

SET default_with_oids = false;

--
-- TOC entry 196 (class 1259 OID 287277)
-- Name: gebruiker; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.gebruiker (
    id integer DEFAULT nextval('public.gebruiker_id_sequances'::regclass) NOT NULL,
    gebruikersnaam character varying NOT NULL,
    voornaam character varying NOT NULL,
    familienaam character varying NOT NULL,
    email character varying NOT NULL,
    wachtwoord character varying NOT NULL
);


ALTER TABLE public.gebruiker OWNER TO postgres;

--
-- TOC entry 202 (class 1259 OID 287337)
-- Name: gereserveerde_item_id_secuence; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.gereserveerde_item_id_secuence
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.gereserveerde_item_id_secuence OWNER TO postgres;

--
-- TOC entry 197 (class 1259 OID 287283)
-- Name: gereserveerde_item; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.gereserveerde_item (
    id integer DEFAULT nextval('public.gereserveerde_item_id_secuence'::regclass) NOT NULL,
    startdatum timestamp without time zone NOT NULL,
    einddatum timestamp without time zone NOT NULL,
    gebruiker_id integer NOT NULL,
    reservering_item_id integer NOT NULL
);


ALTER TABLE public.gereserveerde_item OWNER TO postgres;

--
-- TOC entry 198 (class 1259 OID 287286)
-- Name: parkeergarage; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.parkeergarage (
    id integer NOT NULL,
    naam character varying NOT NULL,
    geolocatie character varying NOT NULL,
    adres character varying,
    lng character varying,
    lat character varying
);


ALTER TABLE public.parkeergarage OWNER TO postgres;

--
-- TOC entry 199 (class 1259 OID 287292)
-- Name: reservering_item; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.reservering_item (
    id integer NOT NULL,
    barcode character varying NOT NULL,
    item_type_id integer NOT NULL,
    parkeergarage_id integer NOT NULL,
    parkingnr character varying
);


ALTER TABLE public.reservering_item OWNER TO postgres;

--
-- TOC entry 200 (class 1259 OID 287298)
-- Name: reservering_item_type; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.reservering_item_type (
    id integer NOT NULL,
    naam character varying NOT NULL
);


ALTER TABLE public.reservering_item_type OWNER TO postgres;

--
-- TOC entry 2829 (class 0 OID 287277)
-- Dependencies: 196
-- Data for Name: gebruiker; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.gebruiker (id, gebruikersnaam, voornaam, familienaam, email, wachtwoord) FROM stdin;
1	soufian	soufian	elb	soefian15@hotmail.com	test
0	hjb	vhbn	vhb	trertevhbj	nvghbn
9999	gdfgnhbjn	sdfgvbn,	sdfghbj	dgcgvnbjnn;	fgdfgh
10000	gdfgnhbjn	sdfgvbn,	sdfghbj	dgcgvnbjnn;bn,;	fgdfgh
10001	gvhbjn	vghbjn	vhbn ,	fsgdfgh	vghbn 
\.


--
-- TOC entry 2830 (class 0 OID 287283)
-- Dependencies: 197
-- Data for Name: gereserveerde_item; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.gereserveerde_item (id, startdatum, einddatum, gebruiker_id, reservering_item_id) FROM stdin;
1	2021-02-11 10:00:04.51	2021-02-11 23:00:04.51	1	1
2	2021-02-10 23:50:00	2021-02-10 23:59:00	1	1
3	2021-02-12 02:02:00	2021-02-12 02:04:00	1	2
\.


--
-- TOC entry 2831 (class 0 OID 287286)
-- Dependencies: 198
-- Data for Name: parkeergarage; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.parkeergarage (id, naam, geolocatie, adres, lng, lat) FROM stdin;
1	Citibee-Morkensplein	51.2134133,4.4312913,17	Morkensplein Antwerpen Borgerhout	4.4312913,17	51.2134133
\.


--
-- TOC entry 2832 (class 0 OID 287292)
-- Dependencies: 199
-- Data for Name: reservering_item; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.reservering_item (id, barcode, item_type_id, parkeergarage_id, parkingnr) FROM stdin;
1	032031	1	1	1f-01
2	256532	1	1	1f-02
3	584654	1	1	2f-01
\.


--
-- TOC entry 2833 (class 0 OID 287298)
-- Dependencies: 200
-- Data for Name: reservering_item_type; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.reservering_item_type (id, naam) FROM stdin;
1	Parking
2	Elektrischelaadpaal
3	Elektrischestep
4	Elektrischefiets
\.


--
-- TOC entry 2844 (class 0 OID 0)
-- Dependencies: 201
-- Name: gebruiker_id_sequances; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.gebruiker_id_sequances', 10001, true);


--
-- TOC entry 2845 (class 0 OID 0)
-- Dependencies: 202
-- Name: gereserveerde_item_id_secuence; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.gereserveerde_item_id_secuence', 3, true);


--
-- TOC entry 2695 (class 2606 OID 287305)
-- Name: gebruiker gebruiker_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.gebruiker
    ADD CONSTRAINT gebruiker_pkey PRIMARY KEY (id);


--
-- TOC entry 2697 (class 2606 OID 287307)
-- Name: gereserveerde_item gereserveerde_item_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.gereserveerde_item
    ADD CONSTRAINT gereserveerde_item_pkey PRIMARY KEY (id);


--
-- TOC entry 2699 (class 2606 OID 287309)
-- Name: parkeergarage pargeergarage_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.parkeergarage
    ADD CONSTRAINT pargeergarage_pkey PRIMARY KEY (id);


--
-- TOC entry 2701 (class 2606 OID 287311)
-- Name: reservering_item reservering_item_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.reservering_item
    ADD CONSTRAINT reservering_item_pkey PRIMARY KEY (id);


--
-- TOC entry 2703 (class 2606 OID 287313)
-- Name: reservering_item_type reservering_item_type_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.reservering_item_type
    ADD CONSTRAINT reservering_item_type_pkey PRIMARY KEY (id);


--
-- TOC entry 2704 (class 2606 OID 287314)
-- Name: gereserveerde_item fk_gebruiker_id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.gereserveerde_item
    ADD CONSTRAINT fk_gebruiker_id FOREIGN KEY (gebruiker_id) REFERENCES public.gebruiker(id) ON DELETE CASCADE;


--
-- TOC entry 2706 (class 2606 OID 287319)
-- Name: reservering_item fk_item_type_id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.reservering_item
    ADD CONSTRAINT fk_item_type_id FOREIGN KEY (item_type_id) REFERENCES public.reservering_item_type(id) ON DELETE CASCADE;


--
-- TOC entry 2707 (class 2606 OID 287324)
-- Name: reservering_item fk_parkeergarage_id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.reservering_item
    ADD CONSTRAINT fk_parkeergarage_id FOREIGN KEY (parkeergarage_id) REFERENCES public.parkeergarage(id) ON DELETE CASCADE;


--
-- TOC entry 2705 (class 2606 OID 287329)
-- Name: gereserveerde_item fk_reservering_item_id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.gereserveerde_item
    ADD CONSTRAINT fk_reservering_item_id FOREIGN KEY (reservering_item_id) REFERENCES public.reservering_item(id) ON DELETE CASCADE;


-- Completed on 2021-02-12 15:30:09

--
-- PostgreSQL database dump complete
--

