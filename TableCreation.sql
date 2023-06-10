/*in db ForRidan*/
CREATE TABLE stock
(
    id INT PRIMARY KEY IDENTITY(1,1),
    name VARCHAR(30) UNIQUE CHECK(name !=''),/*уникальность имени и непустое значение*/
    address text NOT NULL	
);
CREATE TABLE product
(
    id INT PRIMARY KEY IDENTITY(1,1),
    name VARCHAR(100) UNIQUE CHECK(name !=''),/*уникальность имени и непустое значение*/
    weight FLOAT CHECK(weight > 0.0)	
);
CREATE TABLE movement
(
    id INT PRIMARY KEY IDENTITY(1,1),
    id_stock  INT,
    id_product  INT,
    сreated datetime,
    balance BigInt CHECK(balance >=0) /*неотрицательный остаток на каждый момент времени*/
    CONSTRAINT fk_movement_to_stock FOREIGN KEY (id_stock)  REFERENCES stock (id) ON DELETE CASCADE,
    CONSTRAINT fk_movement_to_product FOREIGN KEY (id_product)  REFERENCES product (id) ON DELETE CASCADE
);
