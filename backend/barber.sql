CREATE TABLE shops (
    id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    name VARCHAR(150) NOT NULL,
    address TEXT,
    language VARCHAR(20),
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE customers (
    id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    phone VARCHAR(10),
    name VARCHAR(150),
    no_of_visits INT DEFAULT 0,
    recent_visit_date TIMESTAMP,
    last_verified TIMESTAMP,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE barbers (
    id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    shop_id UUID NOT NULL,
    name VARCHAR(150) NOT NULL,
    user_id UUID,
    password_hash TEXT NOT NULL,
    is_active BOOLEAN DEFAULT TRUE,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE visits (
    id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    customer_id UUID NOT NULL,
    shop_id UUID NOT NULL,
    barber_id UUID NOT NULL,
    status VARCHAR(30),
    entry_time TIMESTAMP,
    start_time TIMESTAMP,
    end_time TIMESTAMP,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE queue (
    id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    visit_id UUID NOT NULL,
    shop_id UUID NOT NULL,
    position INT NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);


INSERT INTO shops (name) VALUES ('Downtown Barber') RETURNING id;

INSERT INTO barbers (name, shop_id, password_hash) VALUES
('Alex', '550e8400-e29b-41d4-a716-446655440000', 'testhash'),
('Sam', '550e8400-e29b-41d4-a716-446655440000', 'testhash')
RETURNING id;

INSERT INTO customers (name, phone)
VALUES ('John Doe', '555-1234')
RETURNING id;

INSERT INTO visits (customer_id, shop_id, barber_id)
VALUES ('8d351cd2-9f8c-4016-9236-66bd27ad95a0', '550e8400-e29b-41d4-a716-446655440000', 'ff205e56-8e52-456d-8790-66743a983759')
RETURNING id;

INSERT INTO queue (visit_id, shop_id, position)
VALUES ('4f1a2e94-f8ec-4280-9113-09bde08f5a3f', '550e8400-e29b-41d4-a716-446655440000', '1')
RETURNING *;


SELECT
  c.name AS customer_name,
  b.name AS barber_name,
  v.status AS status,
  EXTRACT(EPOCH FROM (NOW() - v.entry_time)) / 60 AS waiting_minutes
FROM queue q
JOIN visits v ON q.visit_id = v.id
JOIN customers c ON v.customer_id = c.id
JOIN barbers b ON v.barber_id = b.id
WHERE q.shop_id = '550e8400-e29b-41d4-a716-446655440000'
ORDER BY q.position;


