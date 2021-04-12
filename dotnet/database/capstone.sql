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
	email varchar(100),
	DOB date,
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
	user_id int,
	logo varchar(4000),
	CONSTRAINT PK_brewery PRIMARY KEY (brewery_id),
	
);
CREATE TABLE operation (
	id int IDENTITY(1,1),
	monday varchar(50),
	tuesday varchar(50),
	wednesday varchar(50),
	thursday varchar(50),
	friday varchar(50),
	saturday varchar(50),
	sunday varchar(50),
	brewery_id int,
	CONSTRAINT PK_hours PRIMARY KEY(id),
);

CREATE TABLE beers (
	beer_id int IDENTITY(1,1),
	name varchar(100),
	description varchar(500),
	img varchar(500),
	abv decimal(18,1),
	brewery_id int,
	beer_type varchar(50),
	active_beer bit,
	

	CONSTRAINT PK_beer PRIMARY KEY (beer_id),

);
CREATE TABLE ratings(
	rating_id int IDENTITY(2500,3),
	rating int,
	title varchar(500),
	review varchar(1000),
	user_id int,
	beer_id int,



);
ALTER TABLE brewery
	ADD FOREIGN KEY(user_id) REFERENCES users(user_id);

ALTER TABLE beers
	ADD FOREIGN KEY(brewery_id) REFERENCES brewery(brewery_id);

ALTER TABLE operation 
	ADD FOREIGN KEY(brewery_id) REFERENCES brewery(brewery_id);

ALTER TABLE ratings
	ADD FOREIGN KEY(user_id) REFERENCES users(user_id);
ALTER TABLE ratings
	ADD FOREIGN KEY(beer_id) REFERENCES beers(beer_id);




INSERT INTO users(username,password_hash,salt,user_role,first_name,last_name,email,DOB)
VALUES('jonnien','fJnUh2pOEqhWhCqi5yvJ/CHV6GE=','A6osdPJs1uk=','Beer Lover','Jonnie','Niesz','startrekfan89@gmail.com','01/19/1995');

INSERT INTO users(username,password_hash,salt,user_role,first_name,last_name,email,DOB)
VALUES('christ','s/q71yQeDo2A3Gx1FrSrThAUYqA=','+4wB449eXoE=','Brewer','Chris','Templeton','loser@yahoo.com','01/19/1995');

INSERT INTO users(username,password_hash,salt,user_role,first_name,last_name,email,DOB)
VALUES('test','YhV94SHg0bgikouwOQFLg4404U4=','h5I+1EZqAog=','Admin','Test','Test','Test@email.com','01/19/1995');

INSERT INTO users(username,password_hash,salt,user_role,first_name,last_name,email,DOB)
VALUES('ratneshb','LuzmsyWVc5m7Y4ZyWNXnkSlEkVI=','fCRe2YcPIYw=','Admin','ratnesh','bhattacharya','mrmr@email.com','01/19/1995');

INSERT INTO brewery(name,phone_number,brewery_email,address,history,active,brewery_img,user_id,logo)
VALUES('Northern Row','(513)321-1234','northernrow@gmail.com','123 beer st','began as a brewery',1,'https://cdn.citybeat.com/files/base/scomm/cb/image/2019/05/960w/NorthernRowBrewing_HB_15.5cdb2e7194008.jpg',2,'https://lh3.googleusercontent.com/cQQsD35yTmfZEBun6AYlkD9c_o5EdOtaA_3_1bU8V2iq5xq1BABgYbAMHNI52WopAUjXG4SCSUzhLDQZcfJdJVKuNbad1w=s750');

INSERT INTO brewery(name,phone_number,brewery_email,address,history,active,brewery_img,user_id,logo)
VALUES('Mad Tree','(312)123-4567','madtree@gmail.com','456 pint st','this is a brewery',0,'https://ohiomagazine.imgix.net/sitefinity/images/default-source/articles/2019/02---february-2019/madtree-interior-2.jpg?sfvrsn=74d9a938_2&w=960&auto=compress%2Cformat',2,'https://d2pxm94gkd1wuq.cloudfront.net/BreweryLogos/Standard/568634387.madtree.logo.green-squarepng.png');

INSERT INTO brewery(name,phone_number,brewery_email,address,history,active,brewery_img,user_id,logo)
VALUES('Streetside','(513)454-6544','streetside@gmail.com','593 wow st','began as a street car and then became a brewery',1,'https://2blxhf2wgxaolzlxi2xuosnn-wpengine.netdna-ssl.com/wp-content/uploads/2019/10/Streetside-Brewery-Patio.jpg',2,'https://i0.wp.com/www.craftbeerjoe.com/wp-content/uploads/2017/09/streetside-logo-lrg.png?fit=400%2C152&ssl=1');

INSERT INTO brewery(name,phone_number,brewery_email,address,history,active,brewery_img,user_id,logo)
VALUES('Wiedemann Brewery','(345)333-5555','wiedemann@gmail.com','321 Ross st','used to be a cool place',1,'https://www.gannett-cdn.com/presto/2020/08/03/PCIN/aa09ec77-343e-4668-8974-7bcfe29701f4-Wiedemanns_Exterior_Front.jpg',2,'https://wiedemannsfinebeer.com/wp-content/uploads/2018/01/logoWhiteTransBG.png');

INSERT INTO brewery(name,phone_number,brewery_email,address,history,active,brewery_img,user_id,logo)
VALUES('North High Brewing','(614)876-9119','northhigh@gmail.com','321 North High St','told him this would never work, eating crow now',1,'https://www.breakfastwithnick.com/wp-content/uploads/img_9803.jpg',2,'https://shortnorth.org/wp-content/uploads/2015/04/north-high-logo.jpg');

INSERT INTO brewery(name,phone_number,brewery_email,address,history,active,brewery_img,user_id,logo)
VALUES('Brooklyn Brewery','(718)222-6666','info@brooklynbrewery.com','321 Main Ave','Our team stretches around the planet, ensuring our beer is delicious, adventurous, and available to all. Walk through our Packaging Hall in Brooklyn and you�ll meet people from over a dozen countries, speaking more than twenty languages.',1,'https://api.time.com/wp-content/uploads/2016/10/161013_em_brooklynbrewery.jpg?w=800&quality=85',2,'https://upload.wikimedia.org/wikipedia/commons/thumb/0/05/Brookylnbrewery.svg/800px-Brookylnbrewery.svg.png');

INSERT INTO brewery(name,phone_number,brewery_email,address,history,active,brewery_img,user_id,logo)
VALUES('Smokehouse Brewing Co','(614)592-9686','Smokehouse@gmail.com','5454 Olentangy River Road','Smokehouse Brewing Company is a community place where one feels at home, no matter where home happens to be',1,'https://cdn.usarestaurants.info/assets/uploads/4f321f244a78f98b0668d589891e5c20_-united-states-ohio-franklin-county-columbus-414133-smokehouse-brewing-companyhtm.jpg',1,'https://www.smokehousebrewing.com/images/home_header1.jpg');

INSERT INTO brewery(name,phone_number,brewery_email,address,history,active,brewery_img,user_id,logo)
VALUES('Doolally Taproom','01191(022)48931314','DoolallyTaproom@gmail.com','10A Road Number 3','The first microbrewery in India, with three outlets in Mumbai',1,'https://imgmediagumlet.lbb.in/media/2017/08/599470d03e05710dff4c8621_56aad8b4dae5d95f37743284_1502900432931.jpg?fm=webp&w=750&h=500&dpr=2',1,'https://doolally.in/asset/images/splashLogo.png');

INSERT INTO beers(name,description,img,abv,brewery_id,beer_type,active_beer)
VALUES('Mango Cider','A cider made with kesar mangoes','https://images.indianexpress.com/2016/02/doolallycider-pint-with-mango_759_mumbai-pune.jpg',4,8,'Cider',1);

INSERT INTO beers(name,description,img,abv,brewery_id,beer_type,active_beer)
VALUES('Smoked Porter','Few words in the dictionary can describe the smoky, woody flavours of this beer. Even Shashi Tharoor would struggle.','https://untappd.akamaized.net/photos/2020_09_17/c23ef6952fa4c7477fe581a3d9ed1d26_raw.jpg',5.7,8,'Porter',1);

INSERT INTO beers(name,description,img,abv,brewery_id,beer_type,active_beer)
VALUES('Preacher','Golden ale with a fresh addition of peach and apricot puree','https://untappd.akamaized.net/site/beer_logos_hd/beer-3256736_c500c_hd.jpeg',5.5,1,'Lager',1);

INSERT INTO beers(name,description,img,abv,brewery_id,beer_type,active_beer)
VALUES('Heckler','Not just hops! Juicy citrus aroma with a pronounced bitter touch - Mosaic and Citra hops.','https://images.squarespace-cdn.com/content/v1/58b449258419c27c67294376/1584892296298-F33WSFGS8CSVERPQPIYX/ke17ZwdGBToddI8pDm48kK3svdqmw2prsPjqjcUJoBVZw-zPPgdn4jUwVcJE1ZvWEtT5uBSRWt4vQZAgTJucoTqqXjS3CfNDSuuf31e0tVF7RmyLDtJHBhtEIo-X_TAce22u6AHy1bdwsvc5E9QtZgBFgVkekprcylsdk2tFZ18/Northern+Row+Beer+Shot+Peach+Hi+Res+%2825%29.jpg?format=300w',6,1,'IPA',1);

INSERT INTO beers(name,description,img,abv,brewery_id,beer_type,active_beer)
VALUES('Shade','Have it made with Shade and add a splash of color to any occasion. With real blackberries, this fruit ales versatility compliments a day of relaxation to a fun, vibrant happy hour get together.','https://untappd.akamaized.net/site/beer_logos_hd/beer-1156045_e8d85_hd.jpeg',4.6,2,'Fruit Beer',1)

INSERT INTO beers(name,description,img,abv,brewery_id,beer_type,active_beer)
VALUES('Rubus Cacao','Sweet chocolate notes lead as raspberry tartness follows in unison resembling a perfectly executed dance. The result is a blend of flavors even more spectacular together than apart. It�s love at first sip.','https://untappd.akamaized.net/site/beer_logos_hd/beer-493755_f2ee6_hd.jpeg',7,2,'Stout',1)

INSERT INTO beers(name,description,img,abv,brewery_id,beer_type,active_beer)
VALUES('Java Mama','Cousin to our wildly popular Wake Me Up coffee stout. Java Mama starts off with a strong kick of coffee complemented by mild hop bitterness and a rich French vanilla finish!','https://untappd.akamaized.net/site/beer_logos_hd/beer-4017492_c838e_hd.jpeg',4,4,'Blonde Ale',1)

INSERT INTO beers(name,description,img,abv,brewery_id,beer_type,active_beer)
VALUES('Monkeys Dunkle','German-style Munich Dunkel with a flavorful melding of roasted, slightly nutty mal','https://untappd.akamaized.net/photos/2020_11_07/b970e63e9f9dbe984bf78cf1b88a32a7_640x640.jpg',5,4,'Lager',1)

INSERT INTO beers(name,description,img,abv,brewery_id,beer_type,active_beer)
VALUES('John Lemon','Based on the homebrew recipe of our buddies Brandon Lomax and Kory Roaden, scaled up for production, John Lemon is a tasty treat hopped generously with Citra for delightful citrus flavors. Lemon juice and vanilla add the perfect lemon meringue and whipped cream flavors, while a smooth milkshake mouthfeel, complemented by our heavy handed oat-filled grist bill, caresses the palate. We hope you enjoy this beer as much as we enjoyed brewing it with our friends!','https://untappd.akamaized.net/site/beer_logos_hd/beer-2552524_041ad_hd.jpeg',6.2,3,'IPA',1)

INSERT INTO beers(name,description,img,abv,brewery_id,beer_type,active_beer)
VALUES('Suh,Brah','Starting with an intense nose of stone, fruit, grapefruit, and light pineapple, Suh, Brah?''s aromatics are created by piney dank notes from our double dry hop of Simcoe hopes. Suh, Brah?''s flavor leads with soft mango and pineapple, peach, and light dankness and then is rounded out by a soft, fluffy, almost creamy body.','https://untappd.akamaized.net/site/beer_logos_hd/beer-1805650_a88d6_hd.jpeg',6.7,3,'IPA',1)

INSERT INTO beers(name,description,img,abv,brewery_id,beer_type,active_beer)
VALUES('Filthy McNasty','A big, bold stout showcasing layers of chocolate, coffee and roast character.','https://untappd.akamaized.net/photos/2021_04_07/578fd9a7aa00758dc658d777860fe074_raw.jpg',9,5,'Stout',1);

INSERT INTO beers(name,description,img,abv,brewery_id,beer_type,active_beer)
VALUES('Cover Crop','An easy drinking ale brewed with all Ohio malt and hops','https://www.porchdrinking.com/wp-content/uploads/2019/01/North-High-Cover-Crop-Beer-4-700x325.jpg',4.5,5,'Stout',1);

INSERT INTO beers(name,description,img,abv,brewery_id,beer_type,active_beer)
VALUES('Black Chocolate Stout','Rich roasted malts come together to create an unmistakable dark chocolate flavor perfect for special occasions and late nights by the fire.','https://brooklynbrewery.com/wp-content/uploads/2019/10/beer-1@3x-2-828x1024.jpg',10,6,'Stout',1);

INSERT INTO beers(name,description,img,abv,brewery_id,beer_type,active_beer)
VALUES('Oktoberfest','Our take on the classic M�rzen lager style with sweet, bready malts and German noble hops.', 'https://brooklynbrewery.com/wp-content/uploads/2019/10/beer-1@2x-5-828x1024.jpg',5.5,6,'Stout',1);

INSERT INTO beers(name,description,img,abv,brewery_id,beer_type,active_beer)
VALUES('Alexanders Russian Imperial Stout','The result is a roasty, fruity beer that you might be tempted to eat with a spoon.', 'https://untappd.akamaized.net/photos/2020_12_10/c0c1b69da11bbb208154192a6fb4b919_640x640.jpg',7.6,7,'Stout',1);

INSERT INTO beers(name,description,img,abv,brewery_id,beer_type,active_beer)
VALUES('Centennial India Pale Ale','First brewed to celebrate our 100th batch, this IPA is a British-style IPA. Whole hop additions add a citrus fruitness.', 'https://untappd.akamaized.net/photos/2021_01_24/b2c252cc70466da4fab2c61c9360bee9_raw.jpg',7.6,7,'IPA',1);

INSERT INTO operation(monday,tuesday,wednesday,thursday,friday,saturday,sunday,brewery_id)
VALUES ('10-5','10-5','10-5','10-5','10-5','10-9','10-9',1)

INSERT INTO operation(monday,tuesday,wednesday,thursday,friday,saturday,sunday,brewery_id)
VALUES ('10-5','10-5','10-5','10-5','10-5','10-9','10-9',2)

INSERT INTO operation(monday,tuesday,wednesday,thursday,friday,saturday,sunday,brewery_id)
VALUES ('10-5','10-5','10-5','10-5','10-5','10-9','10-9',3)

INSERT INTO operation(monday,tuesday,wednesday,thursday,friday,saturday,sunday,brewery_id)
VALUES ('10-5','10-5','10-5','10-5','10-5','10-9','10-9',4)

INSERT INTO operation(monday,tuesday,wednesday,thursday,friday,saturday,sunday,brewery_id)
VALUES ('10-5','10-5','10-5','10-5','10-5','10-9','10-9',5)

INSERT INTO operation(monday,tuesday,wednesday,thursday,friday,saturday,sunday,brewery_id)
VALUES ('10-5','10-5','10-5','10-5','10-5','10-9','10-9',6)

INSERT INTO operation(monday,tuesday,wednesday,thursday,friday,saturday,sunday,brewery_id)
VALUES ('10-5','10-5','10-5','10-5','10-5','10-9','10-9',7)

INSERT INTO operation(monday,tuesday,wednesday,thursday,friday,saturday,sunday,brewery_id)
VALUES ('10-5','10-5','10-5','10-5','10-5','10-9','10-9',8)

INSERT INTO ratings(title,rating,review,user_id,beer_id)
VALUES('Great beer',5,'The mango cider is a tart reminder of a perfect vacation, bringing the summer of a coastal beach town to your lips.','3','1')

INSERT INTO ratings(title,rating,review,user_id,beer_id)
VALUES('meh all around',3,'I found this to look like a porter but not as viscous as I would think. An excellent first try.','3','2')

INSERT INTO ratings(title,rating,review,user_id,beer_id)
VALUES('pretty darn good',4,'Wow. Make sure you get a buddy to drive you home after this one. The only knock is that you can taste the high ABV.','3','11')

INSERT INTO ratings(title,rating,review,user_id,beer_id)
VALUES('The best around',5,'The mango cider is a tart reminder of a perfect vacation, bringing the summer of a coastal beach town to your lips.','3','1')

INSERT INTO ratings(title,rating,review,user_id,beer_id)
VALUES('It is okay',3,'I found this to look like a porter but not as viscous as I would think. An excellent first try.','3','2')

INSERT INTO ratings(title,rating,review,user_id,beer_id)
VALUES('No flavor',3,'Tasted light and sweet, with a bit of tanginess.','3','12')

INSERT INTO ratings(title,rating,review,user_id,beer_id)
VALUES('yuck',2,'This one is full of hops, creating a very bitter aftertaste.','3','14')

INSERT INTO ratings(title,rating,review,user_id,beer_id)
VALUES('woof',3,'Possibly my most favorite beer ever, tastes like a dessert','3','13')

INSERT INTO ratings(title,rating,review,user_id,beer_id)
VALUES('Great beer yo',5,'This is the perfectly crafted imperial stout','3','15')

INSERT INTO ratings(title,rating,review,user_id,beer_id)
VALUES('yeah, you know, not good',1,'Not really an IPA guy. Struggled to accept its bitterness.','3','16')