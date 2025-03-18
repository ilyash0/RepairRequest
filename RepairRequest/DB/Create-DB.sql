CREATE TABLE IF NOT EXISTS problem_type (
    problem_type_id SERIAL PRIMARY KEY,
    problem_type_name VARCHAR(50) NOT NULL
);

CREATE TABLE IF NOT EXISTS status (
    status_id SERIAL PRIMARY KEY,
    status_name VARCHAR(50) NOT NULL
);

CREATE TABLE IF NOT EXISTS spare_part_type (
    spare_part_type_id SERIAL PRIMARY KEY,
    spare_part_type_name VARCHAR(50) NOT NULL
);

CREATE TABLE IF NOT EXISTS spare_part (
    spare_part_id SERIAL PRIMARY KEY,
    spare_part_name VARCHAR(100) NOT NULL,
    spare_part_type_id INTEGER REFERENCES spare_part_type(spare_part_type_id) NOT NULL,
    spare_part_cost NUMERIC(10, 2) NOT NULL
);

CREATE TABLE IF NOT EXISTS client (
    client_id SERIAL PRIMARY KEY,
    client_name VARCHAR(100) NOT NULL,
    phone_number VARCHAR(20) NOT NULL
);

CREATE TABLE IF NOT EXISTS request (
    request_id SERIAL PRIMARY KEY,
    date_added DATE NOT NULL,
    date_closed DATE,
    equipment VARCHAR(100) NOT NULL,
    problem_type_id INTEGER REFERENCES problem_type(problem_type_id) NOT NULL,
    description TEXT,
    client_id INTEGER REFERENCES client(client_id) NOT NULL,
    status_id INTEGER REFERENCES status(status_id) NOT NULL
);

CREATE TABLE IF NOT EXISTS spare_part_request (
    spare_part_request_id SERIAL PRIMARY KEY,
    request_id INTEGER REFERENCES request(request_id) NOT NULL,
    spare_part_id INTEGER REFERENCES spare_part(spare_part_id) NOT NULL,
    quantity NUMERIC(10, 3) NOT NULL
);