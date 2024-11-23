﻿CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241115212934_EnderecoECorrecoes') THEN
    CREATE TABLE "Enderecos" (
        "Id" serial GENERATED BY DEFAULT AS IDENTITY,
        "Logradouro" character varying(100) NOT NULL,
        "Complemento" character varying(100) NOT NULL,
        "Bairro" character varying(100) NOT NULL,
        "Estado" character varying(50) NOT NULL,
        "Cidade" character varying(100) NOT NULL,
        "Cep" text NOT NULL,
        "Num" integer NOT NULL,
        CONSTRAINT "PK_Enderecos" PRIMARY KEY ("Id")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241115212934_EnderecoECorrecoes') THEN
    CREATE TABLE "Fornecedores" (
        "Id" integer GENERATED BY DEFAULT AS IDENTITY,
        "RazaoSocial" character varying(100) NOT NULL,
        "NomeFantasia" character varying(150) NOT NULL,
        "Cnpj" text NOT NULL,
        "Email" text NOT NULL,
        "Estado" character varying(50) NOT NULL,
        "Cidade" character varying(100) NOT NULL,
        "Bairro" character varying(100) NOT NULL,
        "Numero" integer NOT NULL,
        "Complemento" character varying(100) NOT NULL,
        "Cep" text NOT NULL,
        "TelefoneFornecedor" text NOT NULL,
        CONSTRAINT "PK_Fornecedores" PRIMARY KEY ("Id")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241115212934_EnderecoECorrecoes') THEN
    CREATE TABLE "Funcionarios" (
        "Id" integer GENERATED BY DEFAULT AS IDENTITY,
        "Nome" character varying(100) NOT NULL,
        "Cpf" text NOT NULL,
        "DataNascimento" timestamp with time zone NOT NULL,
        "Email" text NOT NULL,
        "Estado" character varying(50) NOT NULL,
        "Cidade" character varying(100) NOT NULL,
        "Bairro" character varying(100) NOT NULL,
        "Numero" integer NOT NULL,
        "Complemento" character varying(100) NOT NULL,
        "Cep" text NOT NULL,
        "Salario" numeric NOT NULL,
        "Login" character varying(50) NOT NULL,
        "Senha" character varying(100) NOT NULL,
        "TelefoneFuncionario" text NOT NULL,
        CONSTRAINT "PK_Funcionarios" PRIMARY KEY ("Id")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241115212934_EnderecoECorrecoes') THEN
    CREATE TABLE "Produtos" (
        "IdProduto" integer GENERATED BY DEFAULT AS IDENTITY,
        "Nome" character varying(100) NOT NULL,
        "Qtd" integer NOT NULL,
        "Validade" timestamp NOT NULL,
        "Preco" numeric NOT NULL,
        "Descricao" character varying(500) NOT NULL,
        CONSTRAINT "PK_Produtos" PRIMARY KEY ("IdProduto")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241115212934_EnderecoECorrecoes') THEN
    CREATE TABLE "Vendas" (
        "IdVenda" integer GENERATED BY DEFAULT AS IDENTITY,
        "PrecoUnit" real NOT NULL,
        "DtVenda" timestamp with time zone NOT NULL,
        "FormaPag" character varying(20) NOT NULL,
        "Qtd" integer NOT NULL,
        CONSTRAINT "PK_Vendas" PRIMARY KEY ("IdVenda")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241115212934_EnderecoECorrecoes') THEN
    CREATE TABLE "Clientes" (
        "Id" integer GENERATED BY DEFAULT AS IDENTITY,
        "Nome" character varying(100) NOT NULL,
        "Telefone" text NOT NULL,
        "Email" text NOT NULL,
        "Cpf" bigint NOT NULL,
        "Cnpj" bigint NOT NULL,
        "Sexo" character(1) NOT NULL,
        "DtNasc" timestamp with time zone NOT NULL,
        "EnderecoId" integer NOT NULL,
        "TipoPessoa" boolean NOT NULL,
        CONSTRAINT "PK_Clientes" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_Clientes_Enderecos_EnderecoId" FOREIGN KEY ("EnderecoId") REFERENCES "Enderecos" ("Id") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241115212934_EnderecoECorrecoes') THEN
    CREATE INDEX "IX_Clientes_EnderecoId" ON "Clientes" ("EnderecoId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241115212934_EnderecoECorrecoes') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20241115212934_EnderecoECorrecoes', '8.0.10');
    END IF;
END $EF$;
COMMIT;

START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241115221935_AlteracaoDeDependenciasDeEndereco') THEN
    DROP INDEX "IX_Clientes_EnderecoId";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241115221935_AlteracaoDeDependenciasDeEndereco') THEN
    ALTER TABLE "Funcionarios" DROP COLUMN "Bairro";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241115221935_AlteracaoDeDependenciasDeEndereco') THEN
    ALTER TABLE "Funcionarios" DROP COLUMN "Cep";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241115221935_AlteracaoDeDependenciasDeEndereco') THEN
    ALTER TABLE "Funcionarios" DROP COLUMN "Cidade";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241115221935_AlteracaoDeDependenciasDeEndereco') THEN
    ALTER TABLE "Funcionarios" DROP COLUMN "Complemento";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241115221935_AlteracaoDeDependenciasDeEndereco') THEN
    ALTER TABLE "Funcionarios" DROP COLUMN "Estado";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241115221935_AlteracaoDeDependenciasDeEndereco') THEN
    ALTER TABLE "Fornecedores" DROP COLUMN "Bairro";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241115221935_AlteracaoDeDependenciasDeEndereco') THEN
    ALTER TABLE "Fornecedores" DROP COLUMN "Cep";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241115221935_AlteracaoDeDependenciasDeEndereco') THEN
    ALTER TABLE "Fornecedores" DROP COLUMN "Cidade";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241115221935_AlteracaoDeDependenciasDeEndereco') THEN
    ALTER TABLE "Fornecedores" DROP COLUMN "Complemento";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241115221935_AlteracaoDeDependenciasDeEndereco') THEN
    ALTER TABLE "Fornecedores" DROP COLUMN "Estado";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241115221935_AlteracaoDeDependenciasDeEndereco') THEN
    ALTER TABLE "Funcionarios" RENAME COLUMN "Numero" TO "EnderecoId";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241115221935_AlteracaoDeDependenciasDeEndereco') THEN
    ALTER TABLE "Fornecedores" RENAME COLUMN "Numero" TO "EnderecoId";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241115221935_AlteracaoDeDependenciasDeEndereco') THEN
    CREATE UNIQUE INDEX "IX_Funcionarios_EnderecoId" ON "Funcionarios" ("EnderecoId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241115221935_AlteracaoDeDependenciasDeEndereco') THEN
    CREATE UNIQUE INDEX "IX_Fornecedores_EnderecoId" ON "Fornecedores" ("EnderecoId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241115221935_AlteracaoDeDependenciasDeEndereco') THEN
    CREATE UNIQUE INDEX "IX_Clientes_EnderecoId" ON "Clientes" ("EnderecoId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241115221935_AlteracaoDeDependenciasDeEndereco') THEN
    ALTER TABLE "Fornecedores" ADD CONSTRAINT "FK_Fornecedores_Enderecos_EnderecoId" FOREIGN KEY ("EnderecoId") REFERENCES "Enderecos" ("Id") ON DELETE CASCADE;
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241115221935_AlteracaoDeDependenciasDeEndereco') THEN
    ALTER TABLE "Funcionarios" ADD CONSTRAINT "FK_Funcionarios_Enderecos_EnderecoId" FOREIGN KEY ("EnderecoId") REFERENCES "Enderecos" ("Id") ON DELETE CASCADE;
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241115221935_AlteracaoDeDependenciasDeEndereco') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20241115221935_AlteracaoDeDependenciasDeEndereco', '8.0.10');
    END IF;
END $EF$;
COMMIT;

START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241115231928_AtualizacaoDeCliente') THEN
    ALTER TABLE "Clientes" ALTER COLUMN "Cnpj" DROP NOT NULL;
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241115231928_AtualizacaoDeCliente') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20241115231928_AtualizacaoDeCliente', '8.0.10');
    END IF;
END $EF$;
COMMIT;

START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241115232126_AtualizacaoDeCliente2') THEN
    ALTER TABLE "Clientes" ALTER COLUMN "Cpf" TYPE text;
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241115232126_AtualizacaoDeCliente2') THEN
    ALTER TABLE "Clientes" ALTER COLUMN "Cnpj" TYPE text;
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241115232126_AtualizacaoDeCliente2') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20241115232126_AtualizacaoDeCliente2', '8.0.10');
    END IF;
END $EF$;
COMMIT;

START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241116002650_RestrictDeletion') THEN
    ALTER TABLE "Clientes" DROP CONSTRAINT "FK_Clientes_Enderecos_EnderecoId";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241116002650_RestrictDeletion') THEN
    ALTER TABLE "Fornecedores" DROP CONSTRAINT "FK_Fornecedores_Enderecos_EnderecoId";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241116002650_RestrictDeletion') THEN
    ALTER TABLE "Funcionarios" DROP CONSTRAINT "FK_Funcionarios_Enderecos_EnderecoId";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241116002650_RestrictDeletion') THEN
    ALTER TABLE "Clientes" ADD CONSTRAINT "FK_Clientes_Enderecos_EnderecoId" FOREIGN KEY ("EnderecoId") REFERENCES "Enderecos" ("Id") ON DELETE RESTRICT;
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241116002650_RestrictDeletion') THEN
    ALTER TABLE "Fornecedores" ADD CONSTRAINT "FK_Fornecedores_Enderecos_EnderecoId" FOREIGN KEY ("EnderecoId") REFERENCES "Enderecos" ("Id") ON DELETE RESTRICT;
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241116002650_RestrictDeletion') THEN
    ALTER TABLE "Funcionarios" ADD CONSTRAINT "FK_Funcionarios_Enderecos_EnderecoId" FOREIGN KEY ("EnderecoId") REFERENCES "Enderecos" ("Id") ON DELETE RESTRICT;
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241116002650_RestrictDeletion') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20241116002650_RestrictDeletion', '8.0.10');
    END IF;
END $EF$;
COMMIT;

START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241120231559_Correcoes') THEN
    ALTER TABLE "Vendas" DROP COLUMN "PrecoUnit";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241120231559_Correcoes') THEN
    ALTER TABLE "Vendas" RENAME COLUMN "Qtd" TO "Quantidade";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241120231559_Correcoes') THEN
    ALTER TABLE "Vendas" RENAME COLUMN "FormaPag" TO "FormaDePagamento";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241120231559_Correcoes') THEN
    ALTER TABLE "Produtos" RENAME COLUMN "Qtd" TO "Quantidade";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241120231559_Correcoes') THEN
    ALTER TABLE "Funcionarios" RENAME COLUMN "Cpf" TO "CPF";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241120231559_Correcoes') THEN
    ALTER TABLE "Enderecos" RENAME COLUMN "Cep" TO "CEP";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241120231559_Correcoes') THEN
    ALTER TABLE "Enderecos" RENAME COLUMN "Num" TO "Numero";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241120231559_Correcoes') THEN
    ALTER TABLE "Clientes" RENAME COLUMN "Cpf" TO "CPF";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241120231559_Correcoes') THEN
    ALTER TABLE "Clientes" RENAME COLUMN "Cnpj" TO "CNPJ";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241120231559_Correcoes') THEN
    ALTER TABLE "Clientes" RENAME COLUMN "DtNasc" TO "DataNascimento";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241120231559_Correcoes') THEN
    ALTER TABLE "Vendas" ADD "PrecoUnitario" numeric NOT NULL DEFAULT 0.0;
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241120231559_Correcoes') THEN
    ALTER TABLE "Produtos" ALTER COLUMN "Descricao" DROP NOT NULL;
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241120231559_Correcoes') THEN
    ALTER TABLE "Funcionarios" ALTER COLUMN "Senha" TYPE text;
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241120231559_Correcoes') THEN
    ALTER TABLE "Funcionarios" ALTER COLUMN "Login" TYPE text;
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241120231559_Correcoes') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20241120231559_Correcoes', '8.0.10');
    END IF;
END $EF$;
COMMIT;

START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241121002804_Atualiazacoes') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20241121002804_Atualiazacoes', '8.0.10');
    END IF;
END $EF$;
COMMIT;

START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241121005459_Atualiazacoes2') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20241121005459_Atualiazacoes2', '8.0.10');
    END IF;
END $EF$;
COMMIT;

START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241121012131_Atualiazacoes1') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20241121012131_Atualiazacoes1', '8.0.10');
    END IF;
END $EF$;
COMMIT;

START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241122035138_AtualizaçãoDeUsuario') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20241122035138_AtualizaçãoDeUsuario', '8.0.10');
    END IF;
END $EF$;
COMMIT;

START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241123202457_atualizacliente') THEN
    ALTER TABLE "Clientes" DROP COLUMN "Sexo";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241123202457_atualizacliente') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20241123202457_atualizacliente', '8.0.10');
    END IF;
END $EF$;
COMMIT;

