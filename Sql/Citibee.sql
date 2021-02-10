--
-- PostgreSQL database dump
--

-- Dumped from database version 10.13
-- Dumped by pg_dump version 10.13

-- Started on 2021-02-10 17:16:35
CREATE SCHEMA IF NOT EXISTS citibee


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
-- TOC entry 2835 (class 0 OID 0)
-- Dependencies: 1
-- Name: EXTENSION plpgsql; Type: COMMENT; Schema: -; Owner: 
--

COMMENT ON EXTENSION plpgsql IS 'PL/pgSQL procedural language';


SET default_tablespace = '';

SET default_with_oids = false;

--
-- TOC entry 196 (class 1259 OID 279222)
-- Name: gebruiker; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.gebruiker (
    id integer NOT NULL,
    gebruikersnaam character varying NOT NULL,
    voornaam character varying NOT NULL,
    familienaam character varying NOT NULL,
    email character varying NOT NULL,
    wachtwoord character varying NOT NULL
);


ALTER TABLE public.gebruiker OWNER TO postgres;

--
-- TOC entry 200 (class 1259 OID 279300)
-- Name: gereserveerde_item; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.gereserveerde_item (
    id integer NOT NULL,
    startdatum timestamp without time zone NOT NULL,
    einddatum timestamp without time zone NOT NULL,
    gebruiker_id integer NOT NULL,
    reservering_item_id integer NOT NULL
);


ALTER TABLE public.gereserveerde_item OWNER TO postgres;

--
-- TOC entry 197 (class 1259 OID 279238)
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
-- TOC entry 199 (class 1259 OID 279267)
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
-- TOC entry 198 (class 1259 OID 279246)
-- Name: reservering_item_type; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.reservering_item_type (
    id integer NOT NULL,
    naam character varying NOT NULL
);


ALTER TABLE public.reservering_item_type OWNER TO postgres;

--
-- TOC entry 2823 (class 0 OID 279222)
-- Dependencies: 196
-- Data for Name: gebruiker; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.gebruiker (id, gebruikersnaam, voornaam, familienaam, email, wachtwoord) FROM stdin;
0	soufian	soufian	elb	soefian15@hotmail.com	test
\.


--
-- TOC entry 2827 (class 0 OID 279300)
-- Dependencies: 200
-- Data for Name: gereserveerde_item; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.gereserveerde_item (id, startdatum, einddatum, gebruiker_id, reservering_item_id) FROM stdin;
\.


--
-- TOC entry 2824 (class 0 OID 279238)
-- Dependencies: 197
-- Data for Name: parkeergarage; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.parkeergarage (id, naam, geolocatie, adres, lng, lat) FROM stdin;
1	Citibee-Morkensplein	51.2134133,4.4312913,17	Morkensplein, Antwerpen Borgerhout	4.4312913,17	51.2134133
\.


--
-- TOC entry 2826 (class 0 OID 279267)
-- Dependencies: 199
-- Data for Name: reservering_item; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.reservering_item (id, barcode, item_type_id, parkeergarage_id, parkingnr) FROM stdin;
1	056565	1	1	1f-01
2	01000255	1	1	1f-02
3	04457213	1	1	1f-03
\.


--
-- TOC entry 2825 (class 0 OID 279246)
-- Dependencies: 198
-- Data for Name: reservering_item_type; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.reservering_item_type (id, naam) FROM stdin;
1	Parking
2	Elektrischelaadpaal
3	Elektrischestep
4	Elektrischefiets
\.


--
-- TOC entry 2689 (class 2606 OID 279229)
-- Name: gebruiker gebruiker_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.gebruiker
    ADD CONSTRAINT gebruiker_pkey PRIMARY KEY (id);


--
-- TOC entry 2697 (class 2606 OID 279304)
-- Name: gereserveerde_item gereserveerde_item_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.gereserveerde_item
    ADD CONSTRAINT gereserveerde_item_pkey PRIMARY KEY (id);


--
-- TOC entry 2691 (class 2606 OID 279245)
-- Name: parkeergarage pargeergarage_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.parkeergarage
    ADD CONSTRAINT pargeergarage_pkey PRIMARY KEY (id);


--
-- TOC entry 2695 (class 2606 OID 279274)
-- Name: reservering_item reservering_item_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.reservering_item
    ADD CONSTRAINT reservering_item_pkey PRIMARY KEY (id);


--
-- TOC entry 2693 (class 2606 OID 279253)
-- Name: reservering_item_type reservering_item_type_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.reservering_item_type
    ADD CONSTRAINT reservering_item_type_pkey PRIMARY KEY (id);


--
-- TOC entry 2700 (class 2606 OID 279305)
-- Name: gereserveerde_item fk_gebruiker_id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.gereserveerde_item
    ADD CONSTRAINT fk_gebruiker_id FOREIGN KEY (gebruiker_id) REFERENCES public.gebruiker(id) ON DELETE CASCADE;


--
-- TOC entry 2698 (class 2606 OID 279275)
-- Name: reservering_item fk_item_type_id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.reservering_item
    ADD CONSTRAINT fk_item_type_id FOREIGN KEY (item_type_id) REFERENCES public.reservering_item_type(id) ON DELETE CASCADE;


--
-- TOC entry 2699 (class 2606 OID 279280)
-- Name: reservering_item fk_parkeergarage_id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.reservering_item
    ADD CONSTRAINT fk_parkeergarage_id FOREIGN KEY (parkeergarage_id) REFERENCES public.parkeergarage(id) ON DELETE CASCADE;


--
-- TOC entry 2701 (class 2606 OID 279310)
-- Name: gereserveerde_item fk_reservering_item_id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.gereserveerde_item
    ADD CONSTRAINT fk_reservering_item_id FOREIGN KEY (reservering_item_id) REFERENCES public.reservering_item(id) ON DELETE CASCADE;


-- Completed on 2021-02-10 17:16:39

--
-- PostgreSQL database dump complete
--

