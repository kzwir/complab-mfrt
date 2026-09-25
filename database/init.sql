-- ==========================================
-- CompLab Database Initialization
-- ==========================================

CREATE EXTENSION IF NOT EXISTS "uuid-ossp";

-- schema
\i schema.sql

-- seed
\i seed.sql
