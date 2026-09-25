-- ==========================================
-- CompLab MFR/T MVP
-- PostgreSQL Schema
-- ==========================================

CREATE TABLE users
(
    user_id UUID PRIMARY KEY,

    email VARCHAR(200) NOT NULL UNIQUE,

    password_hash VARCHAR(1000) NOT NULL,

    role VARCHAR(50) NOT NULL
);

CREATE TABLE mixtures
(
    mixture_id UUID PRIMARY KEY,

    code VARCHAR(100) NOT NULL UNIQUE,

    polymer_percent NUMERIC(5,2) NOT NULL,

    quartzite_percent NUMERIC(5,2) NOT NULL
);

CREATE TABLE samples
(
    sample_id UUID PRIMARY KEY,

    mixture_id UUID NOT NULL,

    sample_number VARCHAR(100) NOT NULL UNIQUE,

    production_date DATE NOT NULL,

    CONSTRAINT fk_samples_mixtures
        FOREIGN KEY (mixture_id)
        REFERENCES mixtures(mixture_id)
        ON DELETE RESTRICT
);

CREATE TABLE tests
(
    test_id UUID PRIMARY KEY,

    sample_id UUID NOT NULL,

    test_type VARCHAR(50) NOT NULL,

    measurement_value NUMERIC(18,4) NOT NULL,

    created_at TIMESTAMP NOT NULL,

    CONSTRAINT fk_tests_samples
        FOREIGN KEY (sample_id)
        REFERENCES samples(sample_id)
        ON DELETE CASCADE
);

CREATE INDEX idx_samples_mixture_id
ON samples(mixture_id);

CREATE INDEX idx_tests_sample_id
ON tests(sample_id);
