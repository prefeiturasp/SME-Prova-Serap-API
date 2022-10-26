CREATE TABLE if not exists tipo_curriculo_periodo_ano (
	tcp_id int8 NOT NULL,
	ano varchar(1) NOT NULL,
	modalidade_codigo int4 NOT NULL,
	etapa_eja int4 NULL,
	CONSTRAINT tipo_curriculum_periodo_ano_pk PRIMARY KEY (tcp_id)
);

INSERT INTO tipo_curriculo_periodo_ano (tcp_id,ano,modalidade_codigo,etapa_eja) VALUES
	 (41,'1',3,0),
	 (126,'1',3,0),
	 (114,'2',3,0),
	 (42,'2',3,0),
	 (43,'3',3,0),
	 (115,'3',3,0),
	 (116,'4',3,0),
	 (44,'4',3,0),
	 (45,'1',3,1),
	 (46,'1',3,1);
INSERT INTO tipo_curriculo_periodo_ano (tcp_id,ano,modalidade_codigo,etapa_eja) VALUES
	 (47,'1',3,2),
	 (48,'1',3,2),
	 (75,'1',3,1),
	 (83,'1',3,1),
	 (84,'1',3,2),
	 (76,'1',3,2),
	 (49,'2',3,1),
	 (50,'2',3,1),
	 (51,'2',3,2),
	 (52,'2',3,2);
INSERT INTO tipo_curriculo_periodo_ano (tcp_id,ano,modalidade_codigo,etapa_eja) VALUES
	 (77,'2',3,1),
	 (85,'2',3,1),
	 (86,'2',3,2),
	 (78,'2',3,2),
	 (53,'3',3,1),
	 (54,'3',3,1),
	 (55,'3',3,2),
	 (56,'3',3,2),
	 (79,'3',3,1),
	 (87,'3',3,1);
INSERT INTO tipo_curriculo_periodo_ano (tcp_id,ano,modalidade_codigo,etapa_eja) VALUES
	 (88,'3',3,2),
	 (80,'3',3,2),
	 (120,'1',3,1),
	 (130,'1',3,1),
	 (121,'1',3,2),
	 (118,'1',3,2),
	 (119,'2',3,1),
	 (129,'2',3,1),
	 (122,'2',3,2),
	 (109,'2',3,2);
INSERT INTO tipo_curriculo_periodo_ano (tcp_id,ano,modalidade_codigo,etapa_eja) VALUES
	 (113,'3',3,1),
	 (123,'3',3,1),
	 (112,'3',3,2),
	 (117,'3',3,2),
	 (110,'4',3,1),
	 (124,'4',3,1),
	 (128,'4',3,1),
	 (125,'4',3,2),
	 (111,'4',3,2),
	 (127,'4',3,2);
INSERT INTO tipo_curriculo_periodo_ano (tcp_id,ano,modalidade_codigo,etapa_eja) VALUES
	 (131,'4',3,2),
	 (57,'4',3,1),
	 (58,'4',3,1),
	 (59,'4',3,2),
	 (60,'4',3,2),
	 (81,'4',3,1),
	 (89,'4',3,1),
	 (90,'4',3,2),
	 (82,'4',3,2),
	 (62,'1',4,0);
INSERT INTO tipo_curriculo_periodo_ano (tcp_id,ano,modalidade_codigo,etapa_eja) VALUES
	 (63,'2',4,0),
	 (64,'3',4,0),
	 (65,'4',4,0),
	 (105,'1',4,0),
	 (106,'2',4,0),
	 (107,'3',4,0),
	 (108,'4',4,0);