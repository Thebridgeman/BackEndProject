

CREATE TABLE IF NOT EXISTS sales (
sale_id bigint auto_increment,
product_name varchar(64),
sale_quantity int unique Not Null,
item_price decimal Not Null,
sale_date datetime,
primary key(sale_id)
);

describe sales;