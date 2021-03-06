CREATE DATABASE DB_BIBLIOTECA_UTN;
GO

USE DB_BIBLIOTECA_UTN;
GO

CREATE TABLE Socios
(dni bigint primary key,
nombre varchar(50) not null,
apellido varchar(60) not null,
email varchar(150) not null,
es_estudiante bit not null,
genero int not null,
fecha_nacimiento date not null);
GO

CREATE TABLE Prestamos
(id varchar(10) primary key,
fecha_prestamo date not null,
dni_socio bigint not null,
titulo varchar(150) not null);
GO

insert into Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) values ('1033011746', 'Konstantin', 'Normadell', 'knormadell0@so-net.ne.jp', '7/26/1943', 1, 0);
insert into Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) values ('9461044437', 'Peadar', 'Whysall', 'pwhysall1@apple.com', '3/3/1940', 2, 0);
insert into Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) values ('0680015256', 'Washington', 'Heister', 'wheister2@constantcontact.com', '6/23/1969', 2, 0);
insert into Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) values ('7159516184', 'Shoshanna', 'Pancoast', 'spancoast3@comsenz.com', '5/11/2001', 1, 1);
insert into Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) values ('2662003456', 'Kalil', 'Klais', 'kklais4@samsung.com', '6/28/1963', 0, 1);
insert into Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) values ('9389803926', 'Cchaddie', 'Baudet', 'cbaudet5@icio.us', '7/2/1947', 2, 0);
insert into Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) values ('2191860567', 'Ingeborg', 'Wigzell', 'iwigzell6@guardian.co.uk', '2/17/1941', 1, 0);
insert into Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) values ('5911791226', 'Reinhold', 'Cowhig', 'rcowhig7@go.com', '11/21/1947', 0, 1);
insert into Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) values ('6772131517', 'Stefano', 'Linster', 'slinster8@lycos.com', '4/26/1969', 0, 0);
insert into Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) values ('2931987476', 'Arnuad', 'McKeurtan', 'amckeurtan9@blinklist.com', '7/28/1954', 2, 1);
insert into Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) values ('1897739095', 'Hussein', 'Brawson', 'hbrawsona@senate.gov', '10/30/1997', 0, 0);
insert into Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) values ('9714914795', 'Margit', 'Graveney', 'mgraveneyb@theatlantic.com', '12/10/1938', 1, 1);
insert into Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) values ('7423920835', 'Judye', 'McKinnon', 'jmckinnonc@seattletimes.com', '3/29/1989', 1, 0);
insert into Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) values ('9450207291', 'Lorelei', 'Gillard', 'lgillardd@cornell.edu', '9/3/1976', 0, 1);
insert into Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) values ('1415913498', 'Shanna', 'Howship', 'showshipe@nationalgeographic.com', '8/29/1957', 1, 1);
insert into Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) values ('5838786345', 'Shani', 'Surmeir', 'ssurmeirf@drupal.org', '3/30/2000', 2, 1);
insert into Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) values ('7182317028', 'Hollis', 'Wycherley', 'hwycherleyg@aboutads.info', '9/9/1951', 0, 0);
insert into Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) values ('8269700231', 'Adelaide', 'Tolworth', 'atolworthh@ftc.gov', '2/26/1939', 0, 1);
insert into Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) values ('8854680974', 'Tera', 'Davitti', 'tdavittii@europa.eu', '6/15/1980', 2, 0);
insert into Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) values ('2699547646', 'Eb', 'St Leger', 'estlegerj@aol.com', '3/14/1962', 2, 1);
insert into Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) values ('3614579964', 'Torre', 'Tattersfield', 'ttattersfieldk@sohu.com', '6/22/1956', 1, 0);
insert into Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) values ('0894910094', 'Maren', 'Penquet', 'mpenquetl@devhub.com', '4/3/1963', 0, 1);
insert into Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) values ('5720705473', 'Cesya', 'Sherston', 'csherstonm@shinystat.com', '4/28/1986', 0, 1);
insert into Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) values ('1885945922', 'Nanine', 'Balcon', 'nbalconn@youku.com', '8/7/1983', 2, 0);
insert into Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) values ('6399950880', 'Arluene', 'Sloss', 'aslosso@army.mil', '6/12/1975', 2, 0);
insert into Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) values ('9793571179', 'Niels', 'Allwood', 'nallwoodp@house.gov', '5/8/2004', 0, 1);
insert into Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) values ('9807932297', 'Traci', 'Chubb', 'tchubbq@people.com.cn', '10/16/1934', 2, 1);
insert into Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) values ('6276983411', 'Dyna', 'Tull', 'dtullr@printfriendly.com', '4/20/2001', 2, 0);
insert into Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) values ('2200220030', 'Lana', 'Godfree', 'lgodfrees@joomla.org', '3/1/1943', 0, 0);
insert into Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) values ('4442246351', 'Zandra', 'Entwistle', 'zentwistlet@blogspot.com', '12/3/1957', 1, 0);
insert into Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) values ('5764461715', 'Vita', 'McCleverty', 'vmcclevertyu@prnewswire.com', '7/10/1982', 0, 0);
insert into Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) values ('2324363224', 'Carolan', 'Grinikhinov', 'cgrinikhinovv@posterous.com', '1/6/1963', 0, 0);
insert into Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) values ('9503336996', 'Jarrad', 'Grishenkov', 'jgrishenkovw@blinklist.com', '12/15/1958', 0, 0);
insert into Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) values ('6202109009', 'Lorita', 'Hebblewhite', 'lhebblewhitex@mit.edu', '9/29/1956', 1, 0);
insert into Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) values ('8060076485', 'Lorne', 'Stearn', 'lstearny@oracle.com', '10/3/1957', 1, 1);
insert into Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) values ('3541886773', 'Nissy', 'Enticknap', 'nenticknapz@pinterest.com', '12/8/1988', 2, 1);
insert into Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) values ('0453095704', 'Modestia', 'Imos', 'mimos10@zdnet.com', '7/14/1998', 2, 1);
insert into Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) values ('0650907043', 'Mattheus', 'Ragborne', 'mragborne11@wiley.com', '9/21/2004', 0, 1);
insert into Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) values ('0042314283', 'Maudie', 'Beardsworth', 'mbeardsworth12@nationalgeographic.com', '8/17/1961', 2, 1);
insert into Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) values ('6109095982', 'Billy', 'Wyatt', 'bwyatt13@washington.edu', '2/8/1959', 1, 0);
insert into Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) values ('5100640960', 'Toddy', 'Ferreras', 'tferreras14@ucla.edu', '9/28/1984', 2, 0);
insert into Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) values ('9769855952', 'Phelia', 'Angell', 'pangell15@opera.com', '6/27/1932', 1, 0);
insert into Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) values ('5135442812', 'Alessandro', 'Philipsson', 'aphilipsson16@xing.com', '6/22/1952', 0, 0);
insert into Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) values ('1709471263', 'Poppy', 'Asipenko', 'pasipenko17@constantcontact.com', '11/24/1955', 0, 1);
insert into Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) values ('3498967207', 'Barr', 'Keigher', 'bkeigher18@scribd.com', '4/3/1984', 1, 0);
insert into Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) values ('4491135509', 'Mayor', 'Spurdens', 'mspurdens19@acquirethisname.com', '4/7/1988', 1, 0);
insert into Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) values ('4915415678', 'Wenda', 'Batchan', 'wbatchan1a@odnoklassniki.ru', '2/3/2004', 1, 0);
insert into Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) values ('1407062247', 'Jocelin', 'Jonah', 'jjonah1b@europa.eu', '8/7/1981', 1, 1);
insert into Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) values ('6762538673', 'Bink', 'Bartak', 'bbartak1c@meetup.com', '12/6/1951', 2, 0);
insert into Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) values ('4823048598', 'Linoel', 'Tackett', 'ltackett1d@usa.gov', '7/3/1994', 2, 1);
insert into Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) values ('0293100233', 'Chandler', 'Bellis', 'cbellis1e@cnet.com', '7/30/1930', 1, 1);
insert into Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) values ('9202235228', 'Lenee', 'Matessian', 'lmatessian1f@google.pl', '4/19/1960', 1, 1);
insert into Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) values ('5386956353', 'Kevin', 'Aloshikin', 'kaloshikin1g@nbcnews.com', '9/14/1976', 2, 0);
insert into Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) values ('9460682782', 'Rosette', 'Clamp', 'rclamp1h@wunderground.com', '6/21/1973', 1, 1);
insert into Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) values ('9530905947', 'Sheffield', 'Fairlie', 'sfairlie1i@1und1.de', '8/8/1940', 2, 1);
insert into Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) values ('0796455481', 'Kathe', 'Nibley', 'knibley1j@mapquest.com', '6/9/1977', 0, 0);
insert into Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) values ('6663430920', 'Minnaminnie', 'Voyce', 'mvoyce1k@seesaa.net', '1/30/1994', 1, 1);
insert into Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) values ('9879561627', 'Lynda', 'Shipsey', 'lshipsey1l@google.ru', '9/15/1945', 0, 1);
insert into Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) values ('7857116491', 'Melba', 'Andell', 'mandell1m@desdev.cn', '8/13/1955', 0, 1);
insert into Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) values ('3333122677', 'Rubetta', 'Cockrem', 'rcockrem1n@ucla.edu', '11/16/1996', 2, 0);
insert into Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) values ('6390049145', 'Blakelee', 'Raffeorty', 'braffeorty0@china.com.cn', '11/4/1986', 1, 0);
insert into Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) values ('8899662398', 'Conn', 'Seater', 'cseater1@tinyurl.com', '12/28/2003', 0, 0);
insert into Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) values ('7447615269', 'Carolina', 'Oylett', 'coylett2@addthis.com', '8/19/1984', 0, 1);
insert into Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) values ('4012748793', 'Tove', 'Furnival', 'tfurnival3@cdc.gov', '6/17/2000', 1, 0);
insert into Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) values ('6565861269', 'Harper', 'Alanbrooke', 'halanbrooke4@answers.com', '7/7/1993', 1, 1);
insert into Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) values ('6080332752', 'Andrus', 'Grigsby', 'agrigsby5@dion.ne.jp', '10/22/2001', 0, 1);
insert into Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) values ('6952498672', 'Jo-ann', 'Hekkert', 'jhekkert6@bbb.org', '5/26/1994', 1, 0);
insert into Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) values ('9540721792', 'Pippa', 'Keyte', 'pkeyte7@vkontakte.ru', '5/7/1995', 1, 0);
insert into Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) values ('1861438486', 'Reggi', 'Litel', 'rlitel8@kickstarter.com', '5/15/1999', 0, 1);
insert into Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) values ('1534035524', 'Paloma', 'Balnaves', 'pbalnaves9@prweb.com', '10/1/1988', 1, 1);
insert into Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) values ('2902707924', 'Bride', 'Simonson', 'bsimonsona@utexas.edu', '12/28/2000', 1, 1);
insert into Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) values ('8625313264', 'Idelle', 'Rydings', 'irydingsb@smugmug.com', '9/25/2002', 0, 0);
insert into Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) values ('5373029181', 'Ricardo', 'Craydon', 'rcraydonc@eventbrite.com', '1/11/1984', 1, 0);
insert into Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) values ('5307678495', 'Marjorie', 'Kimmons', 'mkimmonsd@webmd.com', '12/11/1982', 1, 1);
insert into Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) values ('6761219345', 'Rani', 'Glayzer', 'rglayzere@icio.us', '11/25/1982', 0, 1);
insert into Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) values ('8408534432', 'Fitz', 'Tillman', 'ftillmanf@jiathis.com', '8/30/1983', 1, 0);
insert into Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) values ('7666378505', 'Neely', 'Amos', 'namosg@domainmarket.com', '1/29/1993', 1, 1);
insert into Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) values ('7885196399', 'Kevin', 'Axtonne', 'kaxtonneh@cisco.com', '12/31/1994', 0, 1);
insert into Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) values ('6652673126', 'Hanna', 'Habbin', 'hhabbini@angelfire.com', '7/9/1977', 1, 0);
insert into Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) values ('3576571434', 'Barbe', 'Hogsden', 'bhogsdenj@unesco.org', '1/14/2004', 0, 0);
