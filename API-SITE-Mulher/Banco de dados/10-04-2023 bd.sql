create database nao_se_cale_mulher_db;

use nao_se_cale_mulher_db;

create table tb_usuario (
	id int not null primary key auto_increment,
    nome_completo varchar(90) not null,
    email  varchar(40) not null,
    senhar varchar(50) not null,
    apelido varchar(30),
    roles int default 1,
    refresh_token VARCHAR(500) NULL DEFAULT '0',
	refresh_token_expiry_time DATETIME NULL DEFAULT NULL
);

create table tb_poster(
	id int not null primary key auto_increment,
    id_usuario int not null,
    data_de_publicacao datetime,
    titulo varchar(50),
    descricao varchar(100),
	conteudo MEDIUMTEXT,
    foreign key (id_usuario) REFERENCES tb_usuario(id)
);

create table detalhes_do_poster (
	id_poster int null,
    id_categoria_de_posteres int null,
    foreign key (id_poster) REFERENCES tb_poster(id),
    foreign key (id_categoria_de_posteres) REFERENCES tb_categoria_de_posteres(id)
);

create table tb_categoria_de_posteres(
	id int primary key auto_increment,
    `name_categoria` varchar(40) not null,
    nome_tag varchar(40) not null,
    link_page varchar(200)
);