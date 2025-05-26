-- DB作成
CREATE DATABASE test_db;

--ユーザーの作成
CREATE USER psuser WITH PASSWORD 'testpass';

-- 作成したDBに接続
\c bip_db;

CREATE TABLE users (
	user_id serial NOT NULL,
	user_no INT NULL UNIQUE,
	last_name VARCHAR(50) NOT NULL ,
	first_name VARCHAR(50) NOT NULL ,
	password VARCHAR(200) NOT NULL ,
	role INT NULL ,
	driver_id INT NULL ,
	email1 VARCHAR(256) NULL ,
	email2 VARCHAR(256) NULL ,
	del_flag BOOLEAN NULL ,
	create_user_id INT NULL ,
	create_datetime TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP ,
	update_user_id INT NULL ,
	update_datetime TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP ,
	PRIMARY KEY (user_id));

CREATE TABLE user_role (
	user_role_id serial NOT NULL,
	user_id INT NOT NULL ,
	role_id INT NOT NULL ,
	del_flag BOOLEAN NULL ,
	create_user_id INT NULL ,
	create_datetime TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP ,
	update_user_id INT NULL ,
	update_datetime TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP ,
	PRIMARY KEY (user_role_id));

CREATE TABLE mst_role (
	role_id serial NOT NULL,
	role_name VARCHAR NOT NULL ,
	priority_order INT DEFAULT 0,
	del_flag BOOLEAN NULL ,
	create_user_id INT NULL ,
	create_datetime TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP ,
	update_user_id INT NULL ,
	update_datetime TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP ,
	PRIMARY KEY (role_id));

