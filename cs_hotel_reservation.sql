-- MariaDB dump 10.19  Distrib 10.4.32-MariaDB, for Win64 (AMD64)
--
-- Host: localhost    Database: cs_hotel_reservation
-- ------------------------------------------------------
-- Server version	10.4.32-MariaDB

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `bed`
--

DROP TABLE IF EXISTS `bed`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `bed` (
  `BED_REFERENCES_ID` int(11) NOT NULL AUTO_INCREMENT,
  `BED_REFERENCES` varchar(255) NOT NULL,
  `BED_RATE` decimal(10,2) NOT NULL,
  PRIMARY KEY (`BED_REFERENCES_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `bed`
--

LOCK TABLES `bed` WRITE;
/*!40000 ALTER TABLE `bed` DISABLE KEYS */;
INSERT INTO `bed` VALUES (1,'Single',0.00),(2,'Double',100.00),(3,'Queen',250.00);
/*!40000 ALTER TABLE `bed` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary table structure for view `expenses`
--

DROP TABLE IF EXISTS `expenses`;
/*!50001 DROP VIEW IF EXISTS `expenses`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `expenses` AS SELECT
 1 AS `Amount`,
  1 AS `GUESTID` */;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `guest`
--

DROP TABLE IF EXISTS `guest`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `guest` (
  `GUESTID` int(11) NOT NULL,
  `GENDER` enum('Male','Female') NOT NULL,
  `NAME` varchar(255) NOT NULL,
  `ADDRESS` varchar(255) NOT NULL,
  `COUNTRY` varchar(255) NOT NULL,
  `CONTACT` varchar(255) NOT NULL,
  `EMAIL` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`GUESTID`),
  UNIQUE KEY `EMAIL` (`EMAIL`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `guest`
--

LOCK TABLES `guest` WRITE;
/*!40000 ALTER TABLE `guest` DISABLE KEYS */;
INSERT INTO `guest` VALUES (1234,'Female','Emily Johnson','123 Main Street, City Ville','United States','+1 555-1234','emily.j@example.com'),(7345,'Female','Alice Johnson','789 Sunny Love','Canada','+1 (123) 456-7890','alice.j@example.com'),(12345,'Male','Jhondel Mellomida','Pasig City','America','09618960028','mellomida0224@gmail.com'),(13579,'Male','Alex Rodriguez','789 Pine Avenue, Sonneville','Spain','+34 123-456-789','alex.r@example.com'),(24680,'Female','Sarah Thompson','101 Maple Lane, Greenfield','Australia','+61 9876-5432','sarah.t@example.com'),(36912,'Male','Daniel Smith','222 Willow Street, Riverdale','United Kingdom','+44 20 1234-5678','daniel.s@example.com'),(67890,'Male','Michael Davis','456 Oak Street, Townsville','Canada','+1 555-5678','michael.d@example.com'),(74894,'Male','Jan Doe','456 Resort Avenue','Philippines','+63 987-654-3210','jan.d@example.com'),(94872,'Male','John Smith','123 Main Street, Januvia','United States','+1 (555) 123-4567','john.s@example.com');
/*!40000 ALTER TABLE `guest` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `hotel`
--

DROP TABLE IF EXISTS `hotel`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `hotel` (
  `HOTEL_CHOICE_ID` int(11) NOT NULL AUTO_INCREMENT,
  `HOTEL_CHOICE` varchar(255) NOT NULL,
  `HOTEL_TYPE_ID` int(11) NOT NULL,
  `ADDRESS` varchar(255) NOT NULL,
  `CONTACT` varchar(255) NOT NULL,
  `EMAIL` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`HOTEL_CHOICE_ID`),
  UNIQUE KEY `EMAIL` (`EMAIL`),
  KEY `HOTEL_TYPE_ID` (`HOTEL_TYPE_ID`),
  CONSTRAINT `hotel_ibfk_1` FOREIGN KEY (`HOTEL_TYPE_ID`) REFERENCES `hotel_type` (`HOTEL_TYPE_ID`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `hotel`
--

LOCK TABLES `hotel` WRITE;
/*!40000 ALTER TABLE `hotel` DISABLE KEYS */;
INSERT INTO `hotel` VALUES (1,'Luxe Haven Hotel',1,'123 Luxury Street, Luxeville','+1 123-456-7890','luxe.haven@example.com'),(2,'Serene Suites',3,'456 Tranquil Avenue, Tranquil Town','+1 987-654-3210','Serence.suites@example.com'),(3,'Tranquil Residences',4,'789 Calm Street, Calm City','+34 987-654-321','Tranquil.residences@example.com'),(4,'Seaside Retreat',2,'101 Oceanfront Road, Coastal Viilage','+61 1234-5678','Seaside.retreat@example.com');
/*!40000 ALTER TABLE `hotel` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `hotel_type`
--

DROP TABLE IF EXISTS `hotel_type`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `hotel_type` (
  `HOTEL_TYPE_ID` int(11) NOT NULL AUTO_INCREMENT,
  `HOTEL_TYPE_NAME` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`HOTEL_TYPE_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `hotel_type`
--

LOCK TABLES `hotel_type` WRITE;
/*!40000 ALTER TABLE `hotel_type` DISABLE KEYS */;
INSERT INTO `hotel_type` VALUES (1,'Casino'),(2,'Resort'),(3,'Motels'),(4,'Pet-Friendly');
/*!40000 ALTER TABLE `hotel_type` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `payment`
--

DROP TABLE IF EXISTS `payment`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `payment` (
  `PAYMENTID` int(11) NOT NULL,
  `RESERVATIONID` int(11) NOT NULL,
  `PAYMENT_METHOD` enum('VISA','CASH') NOT NULL,
  `CARD_HOLDER_NAME` varchar(255) DEFAULT NULL,
  `CREDIT_CARD_NUMBER` varchar(255) DEFAULT NULL,
  `CVV` varchar(3) DEFAULT NULL,
  `AMOUNT` decimal(10,2) NOT NULL,
  PRIMARY KEY (`PAYMENTID`),
  KEY `RESERVATIONID` (`RESERVATIONID`),
  CONSTRAINT `payment_ibfk_1` FOREIGN KEY (`RESERVATIONID`) REFERENCES `reservation` (`RESERVATIONID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `payment`
--

LOCK TABLES `payment` WRITE;
/*!40000 ALTER TABLE `payment` DISABLE KEYS */;
INSERT INTO `payment` VALUES (220100,55614,'VISA','Emily Johnson','3214423442343123','456',41250.00),(220101,29642,'CASH',NULL,NULL,NULL,32585.00),(220102,46753,'VISA','Alex Rodriguez','3232423456753421','789',66990.00),(220103,23674,'CASH',NULL,NULL,NULL,41250.00),(220104,64367,'VISA','Daniel Smith','8904784612349573','432',32585.00),(220105,23808,'VISA','John Smith','12340987698377281','876',26335.00),(220106,56820,'CASH',NULL,NULL,NULL,42000.00),(220107,56821,'CASH',NULL,NULL,NULL,34385.00),(220108,74558,'VISA','Alice Johnson','3435847582919375','498',42000.00),(220109,74559,'VISA','Alice Johnson','3435847582919375','498',42000.00),(220110,74560,'VISA','Alice Johnson','3435847582919375','498',55640.00),(220111,74561,'VISA','Jhondel','276435756433','123',54542.00);
/*!40000 ALTER TABLE `payment` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary table structure for view `refresh`
--

DROP TABLE IF EXISTS `refresh`;
/*!50001 DROP VIEW IF EXISTS `refresh`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `refresh` AS SELECT
 1 AS `RESERVATIONID`,
  1 AS `GUESTID`,
  1 AS `FIRST_CHOICE_HOTEL`,
  1 AS `SECOND_CHOICE_HOTEL`,
  1 AS `HOTEL_CHOICE_ID`,
  1 AS `CHECK_IN_TIME`,
  1 AS `CHECK_OUT_TIME`,
  1 AS `CHECK_IN_DATE`,
  1 AS `CHECK_OUT_DATE`,
  1 AS `NO_OF_NIGHTS`,
  1 AS `ROOM_TYPE_ID`,
  1 AS `BED_REFERENCES_ID`,
  1 AS `NO_OF_ROOMS`,
  1 AS `EXTRA`,
  1 AS `NO_OF_CHILDREN`,
  1 AS `NO_OF_ADULTS`,
  1 AS `TOTAL_NO_GUESTS`,
  1 AS `GID`,
  1 AS `GENDER`,
  1 AS `NAME`,
  1 AS `ADDRESS`,
  1 AS `COUNTRY`,
  1 AS `CONTACT`,
  1 AS `EMAIL`,
  1 AS `PAYMENTID`,
  1 AS `P_RESERVATIONID`,
  1 AS `PAYMENT_METHOD`,
  1 AS `CARD_HOLDER_NAME`,
  1 AS `CREDIT_CARD_NUMBER`,
  1 AS `CVV`,
  1 AS `AMOUNT` */;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `reservation`
--

DROP TABLE IF EXISTS `reservation`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `reservation` (
  `RESERVATIONID` int(11) NOT NULL,
  `GUESTID` int(11) NOT NULL,
  `FIRST_CHOICE_HOTEL` varchar(255) NOT NULL,
  `SECOND_CHOICE_HOTEL` varchar(255) DEFAULT NULL,
  `HOTEL_CHOICE_ID` int(11) NOT NULL,
  `CHECK_IN_TIME` time NOT NULL,
  `CHECK_OUT_TIME` time NOT NULL,
  `CHECK_IN_DATE` date NOT NULL,
  `CHECK_OUT_DATE` date NOT NULL,
  `NO_OF_NIGHTS` int(11) NOT NULL,
  `ROOM_TYPE_ID` int(11) NOT NULL,
  `BED_REFERENCES_ID` int(11) NOT NULL,
  `NO_OF_ROOMS` int(11) NOT NULL,
  `EXTRA` set('pillows','towels','snacks','blankets') DEFAULT NULL,
  `NO_OF_CHILDREN` int(11) NOT NULL,
  `NO_OF_ADULTS` int(11) NOT NULL,
  `TOTAL_NO_GUESTS` int(11) NOT NULL,
  PRIMARY KEY (`RESERVATIONID`),
  KEY `GUESTID` (`GUESTID`),
  KEY `HOTEL_CHOICE_ID` (`HOTEL_CHOICE_ID`),
  KEY `ROOM_TYPE_ID` (`ROOM_TYPE_ID`),
  KEY `BED_REFERENCES_ID` (`BED_REFERENCES_ID`),
  CONSTRAINT `reservation_ibfk_1` FOREIGN KEY (`GUESTID`) REFERENCES `guest` (`GUESTID`) ON DELETE CASCADE,
  CONSTRAINT `reservation_ibfk_2` FOREIGN KEY (`HOTEL_CHOICE_ID`) REFERENCES `hotel` (`HOTEL_CHOICE_ID`) ON DELETE CASCADE,
  CONSTRAINT `reservation_ibfk_3` FOREIGN KEY (`ROOM_TYPE_ID`) REFERENCES `room` (`ROOM_TYPE_ID`) ON DELETE CASCADE,
  CONSTRAINT `reservation_ibfk_4` FOREIGN KEY (`BED_REFERENCES_ID`) REFERENCES `bed` (`BED_REFERENCES_ID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reservation`
--

LOCK TABLES `reservation` WRITE;
/*!40000 ALTER TABLE `reservation` DISABLE KEYS */;
INSERT INTO `reservation` VALUES (23674,24680,'Seaside Retreat','Luxe Haven Hotel',4,'09:00:00','16:00:00','2023-08-15','2023-08-20',5,2,2,1,'pillows',0,2,2),(23808,94872,'Seaside Retreat','Luxe Haven Hotel',4,'05:00:00','11:00:00','2023-03-14','2023-03-18',4,1,2,1,'',0,1,1),(29642,67890,'Serene Suites','Tranquil Residences',2,'16:00:00','09:00:00','2023-06-10','2023-06-15',5,1,1,1,'pillows,towels',1,2,3),(46753,13579,'Tranquil Residences','Seaside Retreat',3,'06:00:00','16:00:00','2023-07-01','2023-07-07',6,3,3,1,'pillows,towels,snacks',2,2,4),(55614,1234,'Luxe Haven Hotel','Serene Suites',1,'09:00:00','22:00:00','2023-05-15','2023-05-20',5,2,2,1,'',0,2,2),(56820,74894,'Seaside Retreat','',4,'04:00:00','00:00:00','2023-04-29','2023-05-04',5,2,3,1,'blankets',0,2,2),(56821,74894,'Seaside Retreat','',4,'04:00:00','00:00:00','2023-04-29','2023-05-04',5,1,2,1,'pillows,snacks',4,4,8),(64367,36912,'Luxe Haven Hotel','Tranquil Residences',1,'19:00:00','09:00:00','2023-09-10','2023-09-15',5,1,1,1,'',0,1,1),(74558,7345,'Luxe Haven Hotel','Black Monkey Hotel',1,'19:00:00','09:00:00','2023-08-15','2023-08-20',5,2,3,1,'blankets',0,2,2),(74559,7345,'Luxe Haven Hotel','Black Monkey Hotel',1,'19:00:00','09:00:00','2023-08-15','2023-08-20',5,2,3,1,'',0,2,2),(74560,7345,'Luxe Haven Hotel','Black Monkey Hotel',1,'19:00:00','09:00:00','2023-08-15','2023-08-20',5,3,3,1,'',0,2,2),(74561,7345,'Luxe Haven Hotel','Seaside Retreat',1,'19:00:00','09:00:00','2023-08-15','2023-08-20',5,3,3,2,'',1,1,2);
/*!40000 ALTER TABLE `reservation` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER calculate_guests
BEFORE INSERT ON Reservation
FOR EACH ROW
SET NEW.TOTAL_NO_GUESTS = NEW.NO_OF_CHILDREN + NEW.NO_OF_ADULTS */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER calculate_nights
BEFORE INSERT ON Reservation
FOR EACH ROW
SET NEW.NO_OF_NIGHTS = DATEDIFF(NEW.CHECK_OUT_DATE, NEW.CHECK_IN_DATE) */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER set_hotel_choice
BEFORE INSERT ON Reservation
FOR EACH ROW
BEGIN
  DECLARE first_choice_id INT;
  DECLARE second_choice_id INT;

  SELECT HOTEL_CHOICE_ID INTO first_choice_id
  FROM Hotel
  WHERE UPPER(HOTEL_CHOICE) = UPPER(NEW.FIRST_CHOICE_HOTEL);

  SELECT HOTEL_CHOICE_ID INTO second_choice_id
  FROM Hotel
  WHERE UPPER(HOTEL_CHOICE) = UPPER(NEW.SECOND_CHOICE_HOTEL);

  IF first_choice_id IS NOT NULL THEN
    SET NEW.HOTEL_CHOICE_ID = first_choice_id;
  ELSE
    SET NEW.HOTEL_CHOICE_ID = second_choice_id;
  END IF;

  
  
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `room`
--

DROP TABLE IF EXISTS `room`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `room` (
  `ROOM_TYPE_ID` int(11) NOT NULL AUTO_INCREMENT,
  `ROOM_TYPE` varchar(255) NOT NULL,
  `ROOM_RATE` decimal(10,2) NOT NULL,
  `DOWNPAYMENT` decimal(10,2) NOT NULL,
  PRIMARY KEY (`ROOM_TYPE_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `room`
--

LOCK TABLES `room` WRITE;
/*!40000 ALTER TABLE `room` DISABLE KEYS */;
INSERT INTO `room` VALUES (1,'Standard',6650.00,665.00),(2,'Deluxe',8320.00,850.00),(3,'Suites',11100.00,1110.00);
/*!40000 ALTER TABLE `room` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary table structure for view `totaldata`
--

DROP TABLE IF EXISTS `totaldata`;
/*!50001 DROP VIEW IF EXISTS `totaldata`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `totaldata` AS SELECT
 1 AS `GUESTID`,
  1 AS `GENDER`,
  1 AS `NAME`,
  1 AS `ADDRESS`,
  1 AS `COUNTRY`,
  1 AS `CONTACT`,
  1 AS `EMAIL`,
  1 AS `RESERVATIONID`,
  1 AS `FIRST_CHOICE_HOTEL`,
  1 AS `SECOND_CHOICE_HOTEL`,
  1 AS `HOTEL_CHOICE_ID`,
  1 AS `CHECK_IN_TIME`,
  1 AS `CHECK_OUT_TIME`,
  1 AS `CHECK_IN_DATE`,
  1 AS `CHECK_OUT_DATE`,
  1 AS `NO_OF_NIGHTS`,
  1 AS `ROOM_TYPE_ID`,
  1 AS `BED_REFERENCES_ID`,
  1 AS `NO_OF_ROOMS`,
  1 AS `EXTRA`,
  1 AS `NO_OF_CHILDREN`,
  1 AS `NO_OF_ADULTS`,
  1 AS `TOTAL_NO_GUESTS`,
  1 AS `PAYMENTID`,
  1 AS `PAYMENT_METHOD`,
  1 AS `CARD_HOLDER_NAME`,
  1 AS `CREDIT_CARD_NUMBER`,
  1 AS `CVV`,
  1 AS `AMOUNT`,
  1 AS `BED_REFERENCES`,
  1 AS `BED_RATE`,
  1 AS `ROOM_TYPE`,
  1 AS `ROOM_RATE`,
  1 AS `DOWNPAYMENT`,
  1 AS `HOTEL_CHOICE`,
  1 AS `HOTEL_TYPE_ID`,
  1 AS `HOTEL_ADDRESS`,
  1 AS `HOTEL_CONTACT`,
  1 AS `HOTEL_EMAIL`,
  1 AS `HOTEL_TYPE_NAME` */;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `users` (
  `cashier_id` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(50) NOT NULL,
  `password` varchar(255) NOT NULL,
  `last_login` datetime DEFAULT NULL,
  `isActive` tinyint(1) DEFAULT 1,
  `email` varchar(100) NOT NULL,
  `name` varchar(100) NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  `updated_at` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `role` enum('cashier','admin') NOT NULL DEFAULT 'cashier',
  `verification_code` varchar(255) DEFAULT NULL,
  `verification_code_expiry` datetime DEFAULT NULL,
  PRIMARY KEY (`cashier_id`),
  UNIQUE KEY `username` (`username`),
  UNIQUE KEY `email` (`email`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'OkayNoice','3180cc4bbe5b7fffe0fd53d7384eec3f837f5a3d270ac03fdb07282961981437','2024-10-05 11:29:49',1,'','Jhondel Mellomida','2024-10-05 03:04:10','2024-10-05 03:29:49','cashier',NULL,NULL),(2,'test','7b300d9433bdc0636cb5cb5f169ab82d1f917d8dc2e39f82beae37238c02da6d',NULL,1,'kumakalabukab1@gmail.com','test','2024-12-19 04:49:03','2024-12-19 04:49:08','admin','396273','2024-12-19 12:59:08');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Final view structure for view `expenses`
--

/*!50001 DROP VIEW IF EXISTS `expenses`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `expenses` AS select `p`.`AMOUNT` AS `Amount`,`g`.`GUESTID` AS `GUESTID` from ((`reservation` `r` join `guest` `g` on(`r`.`GUESTID` = `g`.`GUESTID`)) join `payment` `p` on(`r`.`RESERVATIONID` = `p`.`RESERVATIONID`)) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `refresh`
--

/*!50001 DROP VIEW IF EXISTS `refresh`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `refresh` AS select `r`.`RESERVATIONID` AS `RESERVATIONID`,`r`.`GUESTID` AS `GUESTID`,`r`.`FIRST_CHOICE_HOTEL` AS `FIRST_CHOICE_HOTEL`,`r`.`SECOND_CHOICE_HOTEL` AS `SECOND_CHOICE_HOTEL`,`r`.`HOTEL_CHOICE_ID` AS `HOTEL_CHOICE_ID`,`r`.`CHECK_IN_TIME` AS `CHECK_IN_TIME`,`r`.`CHECK_OUT_TIME` AS `CHECK_OUT_TIME`,`r`.`CHECK_IN_DATE` AS `CHECK_IN_DATE`,`r`.`CHECK_OUT_DATE` AS `CHECK_OUT_DATE`,`r`.`NO_OF_NIGHTS` AS `NO_OF_NIGHTS`,`r`.`ROOM_TYPE_ID` AS `ROOM_TYPE_ID`,`r`.`BED_REFERENCES_ID` AS `BED_REFERENCES_ID`,`r`.`NO_OF_ROOMS` AS `NO_OF_ROOMS`,`r`.`EXTRA` AS `EXTRA`,`r`.`NO_OF_CHILDREN` AS `NO_OF_CHILDREN`,`r`.`NO_OF_ADULTS` AS `NO_OF_ADULTS`,`r`.`TOTAL_NO_GUESTS` AS `TOTAL_NO_GUESTS`,`g`.`GUESTID` AS `GID`,`g`.`GENDER` AS `GENDER`,`g`.`NAME` AS `NAME`,`g`.`ADDRESS` AS `ADDRESS`,`g`.`COUNTRY` AS `COUNTRY`,`g`.`CONTACT` AS `CONTACT`,`g`.`EMAIL` AS `EMAIL`,`p`.`PAYMENTID` AS `PAYMENTID`,`p`.`RESERVATIONID` AS `P_RESERVATIONID`,`p`.`PAYMENT_METHOD` AS `PAYMENT_METHOD`,`p`.`CARD_HOLDER_NAME` AS `CARD_HOLDER_NAME`,`p`.`CREDIT_CARD_NUMBER` AS `CREDIT_CARD_NUMBER`,`p`.`CVV` AS `CVV`,`p`.`AMOUNT` AS `AMOUNT` from ((`guest` `g` left join `reservation` `r` on(`g`.`GUESTID` = `r`.`GUESTID`)) left join `payment` `p` on(`r`.`RESERVATIONID` = `p`.`RESERVATIONID`)) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `totaldata`
--

/*!50001 DROP VIEW IF EXISTS `totaldata`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `totaldata` AS select `guest`.`GUESTID` AS `GUESTID`,`guest`.`GENDER` AS `GENDER`,`guest`.`NAME` AS `NAME`,`guest`.`ADDRESS` AS `ADDRESS`,`guest`.`COUNTRY` AS `COUNTRY`,`guest`.`CONTACT` AS `CONTACT`,`guest`.`EMAIL` AS `EMAIL`,`reservation`.`RESERVATIONID` AS `RESERVATIONID`,`reservation`.`FIRST_CHOICE_HOTEL` AS `FIRST_CHOICE_HOTEL`,`reservation`.`SECOND_CHOICE_HOTEL` AS `SECOND_CHOICE_HOTEL`,`reservation`.`HOTEL_CHOICE_ID` AS `HOTEL_CHOICE_ID`,`reservation`.`CHECK_IN_TIME` AS `CHECK_IN_TIME`,`reservation`.`CHECK_OUT_TIME` AS `CHECK_OUT_TIME`,`reservation`.`CHECK_IN_DATE` AS `CHECK_IN_DATE`,`reservation`.`CHECK_OUT_DATE` AS `CHECK_OUT_DATE`,`reservation`.`NO_OF_NIGHTS` AS `NO_OF_NIGHTS`,`reservation`.`ROOM_TYPE_ID` AS `ROOM_TYPE_ID`,`reservation`.`BED_REFERENCES_ID` AS `BED_REFERENCES_ID`,`reservation`.`NO_OF_ROOMS` AS `NO_OF_ROOMS`,`reservation`.`EXTRA` AS `EXTRA`,`reservation`.`NO_OF_CHILDREN` AS `NO_OF_CHILDREN`,`reservation`.`NO_OF_ADULTS` AS `NO_OF_ADULTS`,`reservation`.`TOTAL_NO_GUESTS` AS `TOTAL_NO_GUESTS`,`payment`.`PAYMENTID` AS `PAYMENTID`,`payment`.`PAYMENT_METHOD` AS `PAYMENT_METHOD`,`payment`.`CARD_HOLDER_NAME` AS `CARD_HOLDER_NAME`,`payment`.`CREDIT_CARD_NUMBER` AS `CREDIT_CARD_NUMBER`,`payment`.`CVV` AS `CVV`,`payment`.`AMOUNT` AS `AMOUNT`,`bed`.`BED_REFERENCES` AS `BED_REFERENCES`,`bed`.`BED_RATE` AS `BED_RATE`,`room`.`ROOM_TYPE` AS `ROOM_TYPE`,`room`.`ROOM_RATE` AS `ROOM_RATE`,`room`.`DOWNPAYMENT` AS `DOWNPAYMENT`,`hotel`.`HOTEL_CHOICE` AS `HOTEL_CHOICE`,`hotel`.`HOTEL_TYPE_ID` AS `HOTEL_TYPE_ID`,`hotel`.`ADDRESS` AS `HOTEL_ADDRESS`,`hotel`.`CONTACT` AS `HOTEL_CONTACT`,`hotel`.`EMAIL` AS `HOTEL_EMAIL`,`hotel_type`.`HOTEL_TYPE_NAME` AS `HOTEL_TYPE_NAME` from ((((((`guest` join `reservation` on(`guest`.`GUESTID` = `reservation`.`GUESTID`)) join `payment` on(`reservation`.`RESERVATIONID` = `payment`.`RESERVATIONID`)) join `bed` on(`reservation`.`BED_REFERENCES_ID` = `bed`.`BED_REFERENCES_ID`)) join `room` on(`reservation`.`ROOM_TYPE_ID` = `room`.`ROOM_TYPE_ID`)) join `hotel` on(`reservation`.`HOTEL_CHOICE_ID` = `hotel`.`HOTEL_CHOICE_ID`)) join `hotel_type` on(`hotel`.`HOTEL_TYPE_ID` = `hotel_type`.`HOTEL_TYPE_ID`)) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-12-19 12:53:48
