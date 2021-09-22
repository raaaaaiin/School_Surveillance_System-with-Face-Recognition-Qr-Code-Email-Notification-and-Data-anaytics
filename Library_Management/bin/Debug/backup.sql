-- MySqlBackup.NET 2.0.9.2
-- Dump Time: 2019-11-05 23:51:58
-- --------------------------------------
-- Server version 5.0.24a-community-nt MySQL Community Edition (GPL)


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES latin1 */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- 
-- Definition of book
-- 

DROP TABLE IF EXISTS `book`;
CREATE TABLE IF NOT EXISTS `book` (
  `ID` int(11) NOT NULL auto_increment,
  `Title` varchar(50) default NULL,
  `Author` varchar(50) default NULL,
  `Page` varchar(255) default NULL,
  `Information` varchar(255) default NULL,
  `Quantity` varchar(255) default NULL,
  PRIMARY KEY  (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table book
-- 

/*!40000 ALTER TABLE `book` DISABLE KEYS */;
INSERT INTO `book`(`ID`,`Title`,`Author`,`Page`,`Information`,`Quantity`) VALUES
(18,'Friends Forever ','Adti Das Bhowmilk','354',NULL,'100'),
(19,'A Personal Essay of Childhood ','Spirit of the Stars','339',NULL,'100'),
(20,'Romeo and Juliet','William Shakespeare','54',NULL,'100'),
(22,'With Eyes Closed','Jason Miranda','100',NULL,'32'),
(23,'Hush','Jess Wygle','120',NULL,'43'),
(25,'A Christmas Eve Love','Charlie J. Black','32',NULL,'14'),
(26,'A Reason To Rain','Donna M. Young','321',NULL,'51'),
(27,'Forever Yours','The Stroryteller','31',NULL,'232'),
(28,'Hamlet','William Shakespeare','312',NULL,'123'),
(29,'Pride and Prejudice','Jane Austen','512',NULL,'412'),
(30,'The Secret of the House on Dead-End Lane ','Lazarus','233',NULL,'64'),
(31,'Pack Gems','Kuro Kusai and White Wolf Aura','312',NULL,'12'),
(33,'Wish it, want it, do it','Alexander Carillo','123',NULL,'124'),
(34,'Communicative Competence in English','Dr. Ramesh','3412',NULL,'12'),
(35,'Bloody Mary','Jessica Pham','31',NULL,'21'),
(36,'The Meaning of Life','Marc Jablonski','324',NULL,'25'),
(37,'She Fell For The Boy Next Door','Lissie Sales','412',NULL,'34'),
(38,'Masked Love','Victoria Benson','312',NULL,'11'),
(39,'Those Who Cannot Die','Levi Bible','312',NULL,'41'),
(40,'Chrysanthemum','Zarqa','512',NULL,'32'),
(41,'My Wolf, My Mate','FurBaby','112',NULL,'43'),
(42,'Forever','Trina T','321',NULL,'32'),
(43,'Lucky Guy','Lucky Guy','53',NULL,'123'),
(44,'When Siren Calls','Demitria Angel','412',NULL,'321'),
(45,'Bitter Love','Angelika Serafin','31',NULL,'231'),
(46,'Garfield','Andrew','412',NULL,'21'),
(47,'I Hate You','Krystal','321',NULL,'51'),
(48,'A Very Short Action','Lauren','23',NULL,'50'),
(49,'The House of Dies Drear','BabiiBut','112','A back family tries to unravel the secrets of their new home, which was once a stop on their Underground Railroad.','43'),
(50,'Tears and Rain','Angel Altamirano','142','A new high school freshmen named Rain makes friends with a outgoing party seeker. Rain confronts the thrills of high school and risk it all.','31');
/*!40000 ALTER TABLE `book` ENABLE KEYS */;

-- 
-- Definition of book_categ
-- 

DROP TABLE IF EXISTS `book_categ`;
CREATE TABLE IF NOT EXISTS `book_categ` (
  `Category` varchar(255) default NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table book_categ
-- 

/*!40000 ALTER TABLE `book_categ` DISABLE KEYS */;
INSERT INTO `book_categ`(`Category`) VALUES
('Horror'),
('Commedy'),
('Drama'),
('Action'),
('English'),
('Math'),
('Filipino');
/*!40000 ALTER TABLE `book_categ` ENABLE KEYS */;

-- 
-- Definition of book_categ_data
-- 

DROP TABLE IF EXISTS `book_categ_data`;
CREATE TABLE IF NOT EXISTS `book_categ_data` (
  `book_id` varchar(255) default NULL,
  `Category` varchar(255) default ''
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table book_categ_data
-- 

/*!40000 ALTER TABLE `book_categ_data` DISABLE KEYS */;

/*!40000 ALTER TABLE `book_categ_data` ENABLE KEYS */;

-- 
-- Definition of book_info
-- 

DROP TABLE IF EXISTS `book_info`;
CREATE TABLE IF NOT EXISTS `book_info` (
  `ID` int(11) default NULL,
  `Latest_borrowed` varchar(255) default NULL,
  `Latest_returned` varchar(255) default NULL,
  `Date_borrowed` varchar(255) default NULL,
  `Date_returned` varchar(255) default NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table book_info
-- 

/*!40000 ALTER TABLE `book_info` DISABLE KEYS */;
INSERT INTO `book_info`(`ID`,`Latest_borrowed`,`Latest_returned`,`Date_borrowed`,`Date_returned`) VALUES
(13,'Rere','oct 27','oct 20','oct 27');
/*!40000 ALTER TABLE `book_info` ENABLE KEYS */;

-- 
-- Definition of book_records
-- 

DROP TABLE IF EXISTS `book_records`;
CREATE TABLE IF NOT EXISTS `book_records` (
  `Order_number` int(11) NOT NULL auto_increment,
  `Student_id` int(11) default NULL,
  `Borrowed_book` varchar(255) default NULL,
  `Expected_return` varchar(255) default NULL,
  `borrow_duration` varchar(255) default NULL,
  `isReturned` varchar(255) default NULL,
  `Borrowed_date` varchar(255) default NULL,
  `book_id` varchar(255) default NULL,
  PRIMARY KEY  (`Order_number`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table book_records
-- 

/*!40000 ALTER TABLE `book_records` DISABLE KEYS */;
INSERT INTO `book_records`(`Order_number`,`Student_id`,`Borrowed_book`,`Expected_return`,`borrow_duration`,`isReturned`,`Borrowed_date`,`book_id`) VALUES
(1,28,'Masked Love','11/17/2019','12','true','11/5/2019','38'),
(2,28,'A Christmas Eve Love','11/17/2019','12','true','11/5/2019','25'),
(3,28,'A Very Short Action','11/17/2019','12','false','11/5/2019','48');
/*!40000 ALTER TABLE `book_records` ENABLE KEYS */;

-- 
-- Definition of borrow_duration
-- 

DROP TABLE IF EXISTS `borrow_duration`;
CREATE TABLE IF NOT EXISTS `borrow_duration` (
  `creditscore` varchar(255) NOT NULL,
  `duration` decimal(65,0) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table borrow_duration
-- 

/*!40000 ALTER TABLE `borrow_duration` DISABLE KEYS */;
INSERT INTO `borrow_duration`(`creditscore`,`duration`) VALUES
('90',10),
('85',8),
('80',6),
('75',4),
('70',2),
('100',12);
/*!40000 ALTER TABLE `borrow_duration` ENABLE KEYS */;

-- 
-- Definition of collection
-- 

DROP TABLE IF EXISTS `collection`;
CREATE TABLE IF NOT EXISTS `collection` (
  `Order_number` int(11) NOT NULL,
  `Student_ID` varchar(255) default NULL,
  `Recent_search` varchar(255) default NULL,
  `Recent_categ` varchar(255) default NULL,
  PRIMARY KEY  (`Order_number`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table collection
-- 

/*!40000 ALTER TABLE `collection` DISABLE KEYS */;

/*!40000 ALTER TABLE `collection` ENABLE KEYS */;

-- 
-- Definition of stud_info
-- 

DROP TABLE IF EXISTS `stud_info`;
CREATE TABLE IF NOT EXISTS `stud_info` (
  `UID` int(10) NOT NULL auto_increment,
  `First_Name` varchar(50) default NULL,
  `Middle_name` varchar(255) default NULL,
  `Last_Name` varchar(50) default NULL,
  `suffix` varchar(255) default NULL,
  `stud_level` varchar(255) default NULL,
  `stud_section` varchar(255) default NULL,
  `stud_sy` varchar(255) default NULL,
  `user_prvlg` varchar(255) default NULL,
  `stud_program` varchar(255) default NULL,
  PRIMARY KEY  (`UID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table stud_info
-- 

/*!40000 ALTER TABLE `stud_info` DISABLE KEYS */;
INSERT INTO `stud_info`(`UID`,`First_Name`,`Middle_name`,`Last_Name`,`suffix`,`stud_level`,`stud_section`,`stud_sy`,`user_prvlg`,`stud_program`) VALUES
(1,'Aldrin','Garcia','Dian','','2','301','19-20','Student','BSCS'),
(2,'Sanvitores ','Romero','Aina ','','1','101','19-20','Student','BSMA'),
(3,'Aj','Cruz','Berja','','1','101','19-20','Student','BSCS'),
(4,'Aldwyn ','Salazar','Ylo','','2','301','19-20','Student','BSCPE'),
(5,'Andrew ','Aguilar','Gascon ','','2','401','19-20','Student','BSCPE'),
(6,'Angel','Cruz','Etrata','','2','301','19-20','Student','BSHM'),
(8,'Angela ','Rosario','Soriano','','G11','203','19-20','Student','MAWD'),
(9,'Annica','Cruz','Barrios','','2','301','19-20','Student','BSCPE'),
(10,'Bran','Rosario','Ramos','','2','301','19-20','Student','BSHM'),
(11,'Charles','Cruz','Vallestero','','G11','201','19-20','Student','STEM'),
(12,'Chris','Sanvictores','Alegre','','G11','101','19-20','Student','ABM'),
(13,'Crystal','Basilios','Bangang','','G12','301','19-20','Student','STEM'),
(14,'Cure','Garcia','Banzuela','','G12','401','19-20','Student','ABM'),
(15,'Danette Mae','Frias','Vinluan','','1','101','19-20','Student','BSCPE'),
(16,'Daniella','Crus','Boromeo','','2','301','19-20','Student','BSHM'),
(17,'David John ','Avila','Geiger','','2','301','19-20','Student','BSMA'),
(18,'Alex ','Cruz','Domingo','','2','301','19-20','Student','BSCPE'),
(19,'Dustyn','Panuncio','Dimaguila','','1','101','19-20','Student','BSMA'),
(20,'Earl','Gilboy','Dela Cruz','','1','101','19-20','Student','BSHM'),
(21,'Eljay','Go','Pedrido','','2','301','19-20','Student','BSCPE'),
(22,'Ella May','Sanvivtores','De Castro','','2','301','19-20','Student','BSMA'),
(23,'Tricia','Cruz','Florendo','','G11','101','19-20','Student','MAWD'),
(24,'Hazel','Lois','De Alday','','G11','201','19-20','Student','STEM'),
(25,'Kathleen Anne ','Avila','Mariscotes','','2','301','19-20','Student','BSCS'),
(26,'Lia','Cruz','Reyes','','2','401','19-20','Student','BSCPE'),
(27,'Mae','Avila','Yamson ','','G11','201','19-20','Student','STEM'),
(28,'Mark ','Cruz','Ala ','','G11','101','19-20','Student','STEM'),
(29,'Marvin','De Asis','Barro','','G12','401','19-20','Student','ABM'),
(30,'Matthew','Jerez','Esteva','','G12','301','19-20','Student','MAWD');
/*!40000 ALTER TABLE `stud_info` ENABLE KEYS */;

-- 
-- Definition of stud_program
-- 

DROP TABLE IF EXISTS `stud_program`;
CREATE TABLE IF NOT EXISTS `stud_program` (
  `year` varchar(255) default NULL,
  `program` varchar(255) default NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table stud_program
-- 

/*!40000 ALTER TABLE `stud_program` DISABLE KEYS */;
INSERT INTO `stud_program`(`year`,`program`) VALUES
('G12','STEM'),
('G12','ABM'),
('G11','MAWD'),
('G11','STEM'),
('G11','ABM'),
('2','BSCS'),
('2','BSCPE'),
('2','BSHM'),
('2','BSMA'),
('1','BSCS'),
('1','BSCPE'),
('1','BSHM'),
('1','BSMA'),
('G12','MAWD');
/*!40000 ALTER TABLE `stud_program` ENABLE KEYS */;

-- 
-- Definition of stud_return
-- 

DROP TABLE IF EXISTS `stud_return`;
CREATE TABLE IF NOT EXISTS `stud_return` (
  `Date_Borrow` varchar(255) default NULL,
  `Max_Date` varchar(255) default NULL,
  `Duration` varchar(255) default NULL,
  `Date_of_rreturn` varchar(255) default NULL,
  `Title` longtext,
  `Quantity` int(11) default NULL,
  `Rate` varchar(255) default NULL,
  `Student_ID` int(11) default NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table stud_return
-- 

/*!40000 ALTER TABLE `stud_return` DISABLE KEYS */;

/*!40000 ALTER TABLE `stud_return` ENABLE KEYS */;

-- 
-- Definition of stud_sec
-- 

DROP TABLE IF EXISTS `stud_sec`;
CREATE TABLE IF NOT EXISTS `stud_sec` (
  `Section` varchar(255) default NULL,
  `Year` varchar(255) default NULL,
  `Sy` varchar(255) default NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=COMPACT;

-- 
-- Dumping data for table stud_sec
-- 

/*!40000 ALTER TABLE `stud_sec` DISABLE KEYS */;
INSERT INTO `stud_sec`(`Section`,`Year`,`Sy`) VALUES
('STEM','Grade 11','17-18'),
('ABM','Grade 12','18-19'),
('ICT','1st Year','19-20'),
('HUMS','2nd Year','20-21'),
('BSCS','3rd Year','21-22'),
('BSIT','4th Year','22-23'),
('BSCPE','5th Year','23-24'),
('BSMMA',NULL,'24-25'),
('BSHM',NULL,'25-26');
/*!40000 ALTER TABLE `stud_sec` ENABLE KEYS */;

-- 
-- Definition of stud_section
-- 

DROP TABLE IF EXISTS `stud_section`;
CREATE TABLE IF NOT EXISTS `stud_section` (
  `Section` varchar(255) default NULL,
  `Year` varchar(255) default NULL,
  `Program` varchar(255) default NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table stud_section
-- 

/*!40000 ALTER TABLE `stud_section` DISABLE KEYS */;
INSERT INTO `stud_section`(`Section`,`Year`,`Program`) VALUES
('301','G12','STEM'),
('302','G12','STEM'),
('303','G12','STEM'),
('402','G12','STEM'),
('403','G12','STEM'),
('401','G12','STEM'),
('301','G12','MAWD'),
('302','G12','MAWD'),
('303','G12','MAWD'),
('401','G12','MAWD'),
('402','G12','MAWD'),
('203','G11','MAWD'),
('101','G11','ABM'),
('102','G11','ABM'),
('103','G11','ABM'),
('201','G11','ABM'),
('201','G11','ABM'),
('401','G12','ABM'),
('101','G11','MAWD'),
('102','G11','MAWD'),
('103','G11','MAWD'),
('201','G11','MAWD'),
('202','G11','MAWD'),
('201','G11','STEM'),
('101','G11','STEM'),
('102','G11','STEM'),
('103','G11','STEM'),
('202','G11','STEM'),
('203','G11','STEM'),
('403','G12','MAWD'),
('301','G12','ABM'),
('302','G12','ABM'),
('303','G12','ABM'),
('401','G12','ABM'),
('401','G12','ABM'),
('201','G11','ABM'),
('301','2','BSCPE'),
('401','2','BSCPE'),
('403','2','BSMA'),
('302','2','BSCPE'),
('303','2','BSCPE'),
('203','1','BSCPE'),
('301','2','BSCS'),
('302','2','BSCS'),
('303','2','BSCS'),
('401','2','BSCS'),
('402','2','BSCS'),
('403','2','BSCS'),
('301','2','BSHM'),
('302','2','BSHM'),
('303','2','BSHM'),
('401','2','BSHM'),
('402','2','BSHM'),
('403','2','BSHM'),
('301','2','BSMA'),
('302','2','BSMA'),
('303','2','BSMA'),
('401','2','BSMA'),
('402','2','BSMA'),
('101','1','BSCS'),
('101','1','BSCS'),
('101','1','BSCS'),
('201','1','BSCS'),
('202','1','BSCS'),
('203','1','BSCS'),
('101','1','BSHM'),
('101','1','BSHM'),
('101','1','BSHM'),
('201','1','BSHM'),
('202','1','BSHM'),
('203','1','BSHM'),
('101','1','BSMA'),
('101','1','BSMA'),
('101','1','BSMA'),
('201','1','BSMA'),
('202','1','BSMA'),
('203','1','BSMA'),
('201','1','BSCPE'),
('402','2','BSCPE'),
('202','1','BSCPE'),
('402','2','BSCPE'),
('101','1','BSCPE'),
('102','1','BSCPE'),
('103','1','BSCPE');
/*!40000 ALTER TABLE `stud_section` ENABLE KEYS */;

-- 
-- Definition of stud_status
-- 

DROP TABLE IF EXISTS `stud_status`;
CREATE TABLE IF NOT EXISTS `stud_status` (
  `Id` varchar(255) NOT NULL,
  `isLegible` varchar(255) default NULL,
  `credit_score` varchar(255) default NULL,
  `returned_quantity` varchar(255) default NULL,
  `Hours_borrowed` varchar(255) default NULL,
  `borrowed_book_quan` int(11) default NULL,
  PRIMARY KEY  (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table stud_status
-- 

/*!40000 ALTER TABLE `stud_status` DISABLE KEYS */;
INSERT INTO `stud_status`(`Id`,`isLegible`,`credit_score`,`returned_quantity`,`Hours_borrowed`,`borrowed_book_quan`) VALUES
('1','True','90','0','0',0),
('10','True','100','0','0',0),
('11','True','100','0','0',0),
('12','True','100','0','0',0),
('13','True','100','0','0',0),
('14','True','100','0','0',0),
('15','True','100','0','0',0),
('16','True','100','0','0',0),
('17','True','100','0','0',0),
('18','True','100','0','0',0),
('19','True','100','0','0',0),
('2','True','100','0','0',0),
('20','True','100','0','0',0),
('21','True','100','0','0',0),
('22','True','100','0','0',0),
('23','True','100','0','0',0),
('24','True','100','0','0',0),
('25','True','100','0','0',0),
('26','True','100','0','0',0),
('27','True','100','0','0',0),
('28','True','100','0','0',0),
('29','True','100','0','0',0),
('3','True','100','0','0',0),
('30','True','100','0','0',0),
('4','True','100','0','0',0),
('5','True','100','0','0',0),
('6','True','100','0','0',0),
('8','True','100','0','0',0),
('9','True','100','0','0',0);
/*!40000 ALTER TABLE `stud_status` ENABLE KEYS */;

-- 
-- Definition of stud_year
-- 

DROP TABLE IF EXISTS `stud_year`;
CREATE TABLE IF NOT EXISTS `stud_year` (
  `year` varchar(255) default NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table stud_year
-- 

/*!40000 ALTER TABLE `stud_year` DISABLE KEYS */;
INSERT INTO `stud_year`(`year`) VALUES
('G11'),
('G12'),
('1'),
('2'),
('3');
/*!40000 ALTER TABLE `stud_year` ENABLE KEYS */;

-- 
-- Definition of user_acc
-- 

DROP TABLE IF EXISTS `user_acc`;
CREATE TABLE IF NOT EXISTS `user_acc` (
  `UID` varchar(255) default NULL,
  `Username` varchar(255) default NULL,
  `Password` varchar(255) default NULL,
  `role` varchar(255) default NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table user_acc
-- 

/*!40000 ALTER TABLE `user_acc` DISABLE KEYS */;
INSERT INTO `user_acc`(`UID`,`Username`,`Password`,`role`) VALUES
('0','admin','admin','Admin'),
('1','Dian','AldrinDian101','Student'),
('2','Aina ','Sanvitores Aina 101','Student'),
('3','Berja','AjBerja101','Student'),
('4','Ylo','Aldwyn Ylo401','Student'),
('5','Gascon ','Andrew Gascon 401','Student'),
('6','Etrata','Angla Etrata401','Student'),
('8','Soriano','Angela Soriano203','Student'),
('9','Barrios','AnnicaBarrios301','Student'),
('10','Ramos','BranRamos301','Student'),
('11','Vallestero','CharlesVallestero201','Student'),
('12','Alegre','ChrisAlegre101','Student'),
('13','Bangang','CrystalBangang301','Student'),
('14','Banzuela','CureBanzuela401','Student'),
('15','Vinluan','Danette MaeVinluan101','Student'),
('16','Boromeo','DaniellaBoromeo301','Student'),
('17','Geiger','David John Geiger301','Student'),
('18','Domingo','Alex Domingo301','Student'),
('19','Dimaguila','DustynDimaguila101','Student'),
('20','Dela Cruz','EarlDela Cruz101','Student'),
('21','Pedrido','EljayPedrido301','Student'),
('22','De Castro','Ella MayDe Castro301','Student'),
('23','Florendo','TriciaFlorendo101','Student'),
('24','De Alday','HazelDe Alday201','Student'),
('25','Mariscotes','Kathleen Anne Mariscotes301','Student'),
('26','Reyes','LiaReyes401','Student'),
('27','Yamson ','MaeYamson 201','Student'),
('28','Ala ','Alae','STD'),
('29','Barro','MarvinBarro401','Student'),
('30','Esteva','MatthewEsteva301','Student');
/*!40000 ALTER TABLE `user_acc` ENABLE KEYS */;


/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;


-- Dump completed on 2019-11-05 23:51:58
-- Total time: 0:0:0:0:124 (d:h:m:s:ms)
