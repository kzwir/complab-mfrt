-- ==========================================
-- Users
-- ==========================================

INSERT INTO users
(
    user_id,
    email,
    password_hash,
    role
)
VALUES
(
    '11111111-1111-1111-1111-111111111111',
    'admin@complab.local',
    'AQAAAAEAACcQAAAAEOREPLACE_WITH_HASH',
    'Administrator'
);

INSERT INTO users
(
    user_id,
    email,
    password_hash,
    role
)
VALUES
(
    '22222222-2222-2222-2222-222222222222',
    'operator@complab.local',
    'AQAAAAEAACcQAAAAEOREPLACE_WITH_HASH',
    'Operator'
);

-- ==========================================
-- Mixtures
-- ==========================================

INSERT INTO mixtures
(
    mixture_id,
    code,
    polymer_percent,
    quartzite_percent
)
VALUES
(
    '10000000-0000-0000-0000-000000000001',
    'MIX-001',
    40.00,
    60.00
);

INSERT INTO mixtures
(
    mixture_id,
    code,
    polymer_percent,
    quartzite_percent
)
VALUES
(
    '10000000-0000-0000-0000-000000000002',
    'MIX-002',
    35.00,
    65.00
);

-- ==========================================
-- Samples
-- ==========================================

INSERT INTO samples
(
    sample_id,
    mixture_id,
    sample_number,
    production_date
)
VALUES
(
    '20000000-0000-0000-0000-000000000001',
    '10000000-0000-0000-0000-000000000001',
    'SMP-001',
    CURRENT_DATE
);

INSERT INTO samples
(
    sample_id,
    mixture_id,
    sample_number,
    production_date
)
VALUES
(
    '20000000-0000-0000-0000-000000000002',
    '10000000-0000-0000-0000-000000000002',
    'SMP-002',
    CURRENT_DATE
);

-- ==========================================
-- Tests
-- ==========================================

INSERT INTO tests
(
    test_id,
    sample_id,
    test_type,
    measurement_value,
    created_at
)
VALUES
(
    '30000000-0000-0000-0000-000000000001',
    '20000000-0000-0000-0000-000000000001',
    'MFR',
    12.50,
    NOW()
);

INSERT INTO tests
(
    test_id,
    sample_id,
    test_type,
    measurement_value,
    created_at
)
VALUES
(
    '30000000-0000-0000-0000-000000000002',
    '20000000-0000-0000-0000-000000000002',
    'STRENGTH',
    45.80,
    NOW()
);
