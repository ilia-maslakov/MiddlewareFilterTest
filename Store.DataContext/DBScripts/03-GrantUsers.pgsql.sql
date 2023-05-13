-- Дать права на базу данных для StoreDBAdmin
GRANT ALL ON DATABASE "storebase" TO "StoreDBAdmin";

-- Дать права на базу данных для StoreDBUser
GRANT TEMPORARY, CONNECT ON DATABASE "storebase" TO "StoreDBUser";

-- Изменить владельца схемы на админа базы
ALTER SCHEMA public OWNER TO "StoreDBAdmin";

-- Установить владельцы базы как текущую роль 
SET ROLE "StoreDBAdmin";

-- Дать авто права на схему данных для StoreDBUser
ALTER DEFAULT PRIVILEGES IN SCHEMA public GRANT ALL ON TABLES TO "StoreDBUser";
ALTER DEFAULT PRIVILEGES IN SCHEMA public GRANT ALL ON SEQUENCES TO "StoreDBUser";
ALTER DEFAULT PRIVILEGES IN SCHEMA public GRANT EXECUTE ON FUNCTIONS TO "StoreDBUser";

-- Создать схему логирования
CREATE SCHEMA IF NOT EXISTS "logs";

-- Дать авто права на схему данных logs
ALTER DEFAULT PRIVILEGES IN SCHEMA logs GRANT ALL ON TABLES TO "StoreDBUser";
ALTER DEFAULT PRIVILEGES IN SCHEMA logs GRANT ALL ON SEQUENCES TO "StoreDBUser";
ALTER DEFAULT PRIVILEGES IN SCHEMA logs GRANT EXECUTE ON FUNCTIONS TO "StoreDBUser";



