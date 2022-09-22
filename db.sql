--
-- PostgreSQL database dump
--

-- Dumped from database version 14.5
-- Dumped by pg_dump version 14.5

-- Started on 2022-09-22 02:30:50

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

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 210 (class 1259 OID 16583)
-- Name: category; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.category (
    id integer NOT NULL,
    categoryname character varying(50) NOT NULL
);


ALTER TABLE public.category OWNER TO postgres;

--
-- TOC entry 211 (class 1259 OID 16588)
-- Name: offer; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.offer (
    id integer NOT NULL,
    userid integer NOT NULL,
    offer_user integer,
    productid integer NOT NULL,
    offer_product integer,
    price numeric(19,5) NOT NULL,
    isapproved boolean NOT NULL
);


ALTER TABLE public.offer OWNER TO postgres;

--
-- TOC entry 212 (class 1259 OID 16593)
-- Name: product; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.product (
    id integer NOT NULL,
    product_user integer,
    supplierid integer NOT NULL,
    product_category integer,
    categoryid integer NOT NULL,
    productname character varying(100) NOT NULL,
    description character varying(500) NOT NULL,
    brand character varying(50) NOT NULL,
    color character varying(50) NOT NULL,
    price numeric(19,2) NOT NULL,
    issold boolean NOT NULL,
    isofferable boolean NOT NULL
);


ALTER TABLE public.product OWNER TO postgres;

--
-- TOC entry 209 (class 1259 OID 16578)
-- Name: sold; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.sold (
    id integer NOT NULL,
    user_sold integer,
    customerid integer NOT NULL,
    productid integer NOT NULL,
    dateofpurchase timestamp without time zone NOT NULL
);


ALTER TABLE public.sold OWNER TO postgres;

--
-- TOC entry 213 (class 1259 OID 16600)
-- Name: user; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."user" (
    id integer NOT NULL,
    username character varying(50) NOT NULL,
    password character varying(100) NOT NULL,
    email character varying(50) NOT NULL
);


ALTER TABLE public."user" OWNER TO postgres;

--
-- TOC entry 3334 (class 0 OID 16583)
-- Dependencies: 210
-- Data for Name: category; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.category (id, categoryname) FROM stdin;
1	etek
2	gömlek
3	pantalon
4	şort
5	tshirt
\.


--
-- TOC entry 3335 (class 0 OID 16588)
-- Dependencies: 211
-- Data for Name: offer; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.offer (id, userid, offer_user, productid, offer_product, price, isapproved) FROM stdin;
2	2	\N	2	\N	100.00000	f
1	1	\N	1	\N	2.50000	f
\.


--
-- TOC entry 3336 (class 0 OID 16593)
-- Dependencies: 212
-- Data for Name: product; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.product (id, product_user, supplierid, product_category, categoryid, productname, description, brand, color, price, issold, isofferable) FROM stdin;
1	\N	1	\N	1	kırmızı etek	shdjsdhjdhjshd	x	kırmızı	20.50	f	t
2	\N	2	\N	2	test ürün	sdkjdkjskdjkdjs	x	mavi	10.50	f	t
\.


--
-- TOC entry 3333 (class 0 OID 16578)
-- Dependencies: 209
-- Data for Name: sold; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.sold (id, user_sold, customerid, productid, dateofpurchase) FROM stdin;
1	\N	1	1	2022-09-22 02:19:41.198278
\.


--
-- TOC entry 3337 (class 0 OID 16600)
-- Dependencies: 213
-- Data for Name: user; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."user" (id, username, password, email) FROM stdin;
1	string	279FB854EB9FA001B4629518A45C921CFAD6D697	user@example.com
2	test	D5996B25E580C95B90CFC8A69898B31EE8EDB66BEA003AC99801B8CAB34C2BB4	user@example.com
3	nazli,	D2D02EA74DE2C9FAB1D802DB969C18D409A8663A9697977BB1C98CCDD9DE4372	user@example.com
4	test	534A4A8EAFCD8489AF32356D5A7A25F88C70CFE0448539A7C42964C1B897A359	user@example.com
\.


--
-- TOC entry 3182 (class 2606 OID 16587)
-- Name: category category_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.category
    ADD CONSTRAINT category_pkey PRIMARY KEY (id);


--
-- TOC entry 3184 (class 2606 OID 16592)
-- Name: offer offer_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.offer
    ADD CONSTRAINT offer_pkey PRIMARY KEY (id);


--
-- TOC entry 3186 (class 2606 OID 16599)
-- Name: product product_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.product
    ADD CONSTRAINT product_pkey PRIMARY KEY (id);


--
-- TOC entry 3180 (class 2606 OID 16582)
-- Name: sold sold_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.sold
    ADD CONSTRAINT sold_pkey PRIMARY KEY (id);


--
-- TOC entry 3188 (class 2606 OID 16604)
-- Name: user user_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."user"
    ADD CONSTRAINT user_pkey PRIMARY KEY (id);


--
-- TOC entry 3190 (class 2606 OID 16610)
-- Name: offer fk_224ae4f2; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.offer
    ADD CONSTRAINT fk_224ae4f2 FOREIGN KEY (offer_user) REFERENCES public."user"(id);


--
-- TOC entry 3189 (class 2606 OID 16605)
-- Name: sold fk_337237be; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.sold
    ADD CONSTRAINT fk_337237be FOREIGN KEY (user_sold) REFERENCES public."user"(id);


--
-- TOC entry 3192 (class 2606 OID 16620)
-- Name: product fk_5ffd683c; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.product
    ADD CONSTRAINT fk_5ffd683c FOREIGN KEY (product_user) REFERENCES public."user"(id);


--
-- TOC entry 3191 (class 2606 OID 16615)
-- Name: offer fk_c313c508; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.offer
    ADD CONSTRAINT fk_c313c508 FOREIGN KEY (offer_product) REFERENCES public.product(id);


--
-- TOC entry 3193 (class 2606 OID 16625)
-- Name: product fk_e3cbf530; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.product
    ADD CONSTRAINT fk_e3cbf530 FOREIGN KEY (product_category) REFERENCES public.category(id);


-- Completed on 2022-09-22 02:30:50

--
-- PostgreSQL database dump complete
--

