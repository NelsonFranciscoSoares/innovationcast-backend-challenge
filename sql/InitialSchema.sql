CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;

CREATE TABLE "Entidades" (
    "Id" uuid NOT NULL,
    "TipoComentario" text NOT NULL,
    "DataInsercao" timestamp without time zone NOT NULL,
    "DataEdicao" timestamp without time zone NULL,
    CONSTRAINT "PK_Entidades" PRIMARY KEY ("Id")
);

CREATE TABLE "Utilizadores" (
    "Id" uuid NOT NULL,
    "Username" varchar(100) NOT NULL,
    "Email" varchar(200) NOT NULL,
    "DataInsercao" timestamp without time zone NOT NULL,
    "DataEdicao" timestamp without time zone NULL,
    CONSTRAINT "PK_Utilizadores" PRIMARY KEY ("Id")
);

CREATE TABLE "Comentarios" (
    "Id" uuid NOT NULL,
    "EntidadeId" uuid NOT NULL,
    "Texto" character varying(5000) NOT NULL,
    "Autor" character varying(200) NOT NULL,
    "DataPublicacao" timestamp with time zone NOT NULL,
    "DataInsercao" timestamp without time zone NOT NULL,
    "DataEdicao" timestamp without time zone NULL,
    CONSTRAINT "PK_Comentarios" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Comentarios_Entidades_EntidadeId" FOREIGN KEY ("EntidadeId") REFERENCES "Entidades" ("Id") ON DELETE RESTRICT
);

CREATE TABLE "ComentarioEntityUtilizadorEntity" (
    "ComentariosVisualizadosId" uuid NOT NULL,
    "UtilizadoresVisualizaramId" uuid NOT NULL,
    CONSTRAINT "PK_ComentarioEntityUtilizadorEntity" PRIMARY KEY ("ComentariosVisualizadosId", "UtilizadoresVisualizaramId"),
    CONSTRAINT "FK_ComentarioEntityUtilizadorEntity_Comentarios_ComentariosVis~" FOREIGN KEY ("ComentariosVisualizadosId") REFERENCES "Comentarios" ("Id") ON DELETE RESTRICT,
    CONSTRAINT "FK_ComentarioEntityUtilizadorEntity_Utilizadores_UtilizadoresV~" FOREIGN KEY ("UtilizadoresVisualizaramId") REFERENCES "Utilizadores" ("Id") ON DELETE RESTRICT
);

INSERT INTO "Entidades" ("Id", "DataEdicao", "DataInsercao", "TipoComentario")
VALUES ('06406200-c8ee-44e1-bf86-bc5827048705', NULL, TIMESTAMP '0001-01-01 00:00:00', 'IDEIA');
INSERT INTO "Entidades" ("Id", "DataEdicao", "DataInsercao", "TipoComentario")
VALUES ('21738160-0178-42c6-8b9e-c60f8fab459d', NULL, TIMESTAMP '0001-01-01 00:00:00', 'SINAIS');

INSERT INTO "Utilizadores" ("Id", "DataEdicao", "DataInsercao", "Email", "Username")
VALUES ('abea8a1e-d8e2-47f7-b7e7-6dd6cfe48ac4', NULL, TIMESTAMP '0001-01-01 00:00:00', 'fake.nfsoares@gmail.com', 'nfsoares');
INSERT INTO "Utilizadores" ("Id", "DataEdicao", "DataInsercao", "Email", "Username")
VALUES ('2d4305a4-0481-4ced-85dc-2d2a09a99431', NULL, TIMESTAMP '0001-01-01 00:00:00', 'fake.teste01@gmail.com', 'teste01');

CREATE INDEX "IX_ComentarioEntityUtilizadorEntity_UtilizadoresVisualizaramId" ON "ComentarioEntityUtilizadorEntity" ("UtilizadoresVisualizaramId");

CREATE INDEX "IX_Comentarios_EntidadeId" ON "Comentarios" ("EntidadeId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20211025200555_InitialSchema', '5.0.11');

COMMIT;

