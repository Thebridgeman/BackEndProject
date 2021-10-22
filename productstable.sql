Create database if not exists Sales;
Use sales;

CREATE TABLE IF NOT EXISTS sales (
sale_id bigint auto_increment,
product_name varchar(64),
sale_quantity int unique Not Null,
item_price decimal Not Null,
sale_date datetime,
primary key(sale_id)
);

select * from sales;
drop table sales;

/* products sold in a year*/
select * from sales where year(sale_date) = 2021;

/* products sold in a month*/
select * from sales where month(sale_date) = 02 and year(sale_date) = 2021;

/* total sales in a year */
select sum(item_price) from sales where year(sale_date) = 2021; 
select sum(item_price * sale_quantity) from sales where year(sale_date) = 2021;

/* sales from a month of a year */
select sun (item_price) from sales where month(sale_date) = 01 and year(sale_date) = 2021;
select sun(item_price * sale_quantity) from sales where month(sale_date) = 01 and year(sale_date) = 2021;







