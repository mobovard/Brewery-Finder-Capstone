USE master
GO

--drop database if it exists
IF DB_ID('final_capstone') IS NOT NULL
BEGIN
	ALTER DATABASE final_capstone SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE final_capstone;
END

CREATE DATABASE final_capstone
GO

USE final_capstone
GO

--create tables
CREATE TABLE users (
	user_id int IDENTITY(1,1) NOT NULL,
	username varchar(50) NOT NULL,
	password_hash varchar(200) NOT NULL,
	salt varchar(200) NOT NULL,
	user_role varchar(50) NOT NULL,
	first_name varchar(50),
	last_name varchar(50),
	email varchar(100) 
	CONSTRAINT PK_user PRIMARY KEY (user_id)
);

CREATE TABLE brewery (
	brewery_id int IDENTITY(1,1) NOT NULL,
	name varchar(50) NOT NULL,
	phone_number varchar(60),
	brewery_email varchar(100),
	address varchar(200),
	history varchar(1000),
	active bit,
	brewery_img varchar(7000),
	hours_of_operation varchar(200),
	user_id int,
	CONSTRAINT PK_brewery PRIMARY KEY (brewery_id),
	
);
ALTER TABLE brewery
	ADD FOREIGN KEY(user_id) REFERENCES users(user_id);




INSERT INTO users(username,password_hash,salt,user_role)
VALUES('jonnien','fJnUh2pOEqhWhCqi5yvJ/CHV6GE=','A6osdPJs1uk=','user');

INSERT INTO users(username,password_hash,salt,user_role)
VALUES('christ','s/q71yQeDo2A3Gx1FrSrThAUYqA=','+4wB449eXoE=','brewer');


INSERT INTO users(username,password_hash,salt,user_role)
VALUES('ratneshb','LuzmsyWVc5m7Y4ZyWNXnkSlEkVI=','fCRe2YcPIYw=','admin');

INSERT INTO brewery(name,phone_number,brewery_email,address,history,active,brewery_img,hours_of_operation,user_id)
VALUES('Northern Row','(513)321-1234','northernrow@gmail.com','123 beer st','began as a brewery',1,'https://cdn.citybeat.com/files/base/scomm/cb/image/2019/05/960w/NorthernRowBrewing_HB_15.5cdb2e7194008.jpg','Monday-friday 12-5',2);

INSERT INTO brewery(name,phone_number,brewery_email,address,history,active,brewery_img,hours_of_operation,user_id)
VALUES('Mad Tree','(312)123-4567','madtree@gmail.com','456 pint st','this is a brewery',0,'https://ohiomagazine.imgix.net/sitefinity/images/default-source/articles/2019/02---february-2019/madtree-interior-2.jpg?sfvrsn=74d9a938_2&w=960&auto=compress%2Cformat','Monday-Sunday 2-12',2);









