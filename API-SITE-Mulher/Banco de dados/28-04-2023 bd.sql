
create database nao_se_cale_mulher_db;

DROP TABLE IF EXISTS `__efmigrationshistory`;

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProductVersion` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

LOCK TABLES `__efmigrationshistory` WRITE;
INSERT INTO `__efmigrationshistory` VALUES ('20230425135351_inicial','6.0.15');
UNLOCK TABLES;


DROP TABLE IF EXISTS `tb_categoria_de_posteres`;

CREATE TABLE `tb_categoria_de_posteres` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name_categoria` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `nome_tag` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

LOCK TABLES `tb_categoria_de_posteres` WRITE;
UNLOCK TABLES;


DROP TABLE IF EXISTS `tb_categoria_de_posterestb_poster`;

CREATE TABLE `tb_categoria_de_posterestb_poster` (
  `tbCategoriaDePosteresId` int NOT NULL,
  `tbPostersId` int NOT NULL,
  PRIMARY KEY (`tbCategoriaDePosteresId`,`tbPostersId`),
  KEY `IX_tb_categoria_de_posterestb_poster_tbPostersId` (`tbPostersId`),
  CONSTRAINT `FK_tb_categoria_de_posterestb_poster_tb_categoria_de_posteres_t~` FOREIGN KEY (`tbCategoriaDePosteresId`) REFERENCES `tb_categoria_de_posteres` (`id`) ON DELETE CASCADE,
  CONSTRAINT `FK_tb_categoria_de_posterestb_poster_tb_poster_tbPostersId` FOREIGN KEY (`tbPostersId`) REFERENCES `tb_poster` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

LOCK TABLES `tb_categoria_de_posterestb_poster` WRITE;
UNLOCK TABLES;


DROP TABLE IF EXISTS `tb_poster`;

CREATE TABLE `tb_poster` (
  `id` int NOT NULL AUTO_INCREMENT,
  `id_usuario` int DEFAULT NULL,
  `data_de_publicacao` datetime(6) NOT NULL,
  `titulo` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `descricao` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `conteudo` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `tbUsuariosId` int DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `IX_tb_poster_tbUsuariosId` (`tbUsuariosId`),
  CONSTRAINT `FK_tb_poster_tb_usuario_tbUsuariosId` FOREIGN KEY (`tbUsuariosId`) REFERENCES `tb_usuario` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

LOCK TABLES `tb_poster` WRITE;
INSERT INTO `tb_poster` VALUES (1,NULL,'2023-04-25 10:58:20.987540','sdflakjasjf','ksldjfkasjflsdajnull','<h1>Lorem ipsum dolor sit amet consectetur</h1><p>Lorem ipsum dolor sit, amet consectetur adipisicing elit. Et distinctio ad veritatis consequuntur quidem! Blanditiis iure in aliquam. Ex eos doloribus beatae fugiat ducimus provident, earum in vel omnis tempora!</p><p>    Lorem ipsum dolor sit amet consectetur adipisicing elit. Labore, quis veniam architecto facere, dicta nostrum magnam unde quisquam, eius qui veritatis eum soluta saepe eveniet culpa earum rem officiis? Officiis.</p><p>    Lorem ipsum dolor sit amet consectetur, adipisicing elit. Esse, a rem velit consequatur in tenetur blanditiis, nemo eveniet soluta nam hic facilis iusto, provident doloremque nobis cumque voluptatum voluptas! A.</p><p>    Lorem ipsum dolor sit amet consectetur adipisicing elit. Aperiam vero laudantium architecto officiis corporis! Quod ipsum consequatur quaerat assumenda iure, id corporis repudiandae eaque hic repellat rerum laboriosam, quisquam eveniet.</p>',1),(2,NULL,'2023-04-28 17:14:01.182308','sdflakjasjf02','ksldjfkasjflsdajnull02','<h1>Lorem ipsum dolor sit amet consectetur</h1><p>Lorem ipsum dolor sit, amet consectetur adipisicing elit. Et distinctio ad veritatis consequuntur quidem! Blanditiis iure in aliquam. Ex eos doloribus beatae fugiat ducimus provident, earum in vel omnis tempora!</p><p>    Lorem ipsum dolor sit amet consectetur adipisicing elit. Labore, quis veniam architecto facere, dicta nostrum magnam unde quisquam, eius qui veritatis eum soluta saepe eveniet culpa earum rem officiis? Officiis.</p><p>    Lorem ipsum dolor sit amet consectetur, adipisicing elit. Esse, a rem velit consequatur in tenetur blanditiis, nemo eveniet soluta nam hic facilis iusto, provident doloremque nobis cumque voluptatum voluptas! A.</p><p>    Lorem ipsum dolor sit amet consectetur adipisicing elit. Aperiam vero laudantium architecto officiis corporis! Quod ipsum consequatur quaerat assumenda iure, id corporis repudiandae eaque hic repellat rerum laboriosam, quisquam eveniet.</p>',1);
UNLOCK TABLES;

DROP TABLE IF EXISTS `tb_usuario`;

CREATE TABLE `tb_usuario` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nome_completo` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `email` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `senhar` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `apelido` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `roles` int NOT NULL,
  `refresh_token` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `refresh_token_expiry_time` datetime(6) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;


LOCK TABLES `tb_usuario` WRITE;
INSERT INTO `tb_usuario` VALUES (1,'Arthur Cavalcante Gomes da Silva','arthurbig12@gmail.com','AE-10-C8-DA-FE-DE-BC-2A-6F-F0-05-24-E8-88-13-C6-77-1A-FC-8C-60-A2-1D-5A-D2-5C-99-F2-4C-F9-3B-AA',NULL,1,'JHjw5Nd5ORcWLshl+7Hdg+8VIZxiTI/N1hBcxTUge4Q=','2023-05-05 17:06:14.662331');
UNLOCK TABLES;

