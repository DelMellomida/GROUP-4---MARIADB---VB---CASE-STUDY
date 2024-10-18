-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Oct 18, 2024 at 04:42 PM
-- Server version: 10.4.28-MariaDB
-- PHP Version: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `cs_hotel_reservation`
--

CREATE Database cs_hotel_reservation;

use cs_hotel_reservation;

-- --------------------------------------------------------

--
-- Table structure for table `bed`
--

CREATE TABLE `bed` (
  `BED_REFERENCES_ID` int(11) NOT NULL,
  `BED_REFERENCES` varchar(255) NOT NULL,
  `BED_RATE` decimal(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `bed`
--

INSERT INTO `bed` (`BED_REFERENCES_ID`, `BED_REFERENCES`, `BED_RATE`) VALUES
(1, 'Single', 0.00),
(2, 'Double', 100.00),
(3, 'Queen', 250.00);

-- --------------------------------------------------------

--
-- Stand-in structure for view `expenses`
-- (See below for the actual view)
--
CREATE TABLE `expenses` (
`Amount` decimal(10,2)
,`GUESTID` int(11)
);

-- --------------------------------------------------------

--
-- Table structure for table `guest`
--

CREATE TABLE `guest` (
  `GUESTID` int(11) NOT NULL,
  `GENDER` enum('Male','Female') NOT NULL,
  `NAME` varchar(255) NOT NULL,
  `ADDRESS` varchar(255) NOT NULL,
  `COUNTRY` varchar(255) NOT NULL,
  `CONTACT` varchar(255) NOT NULL,
  `EMAIL` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `guest`
--

INSERT INTO `guest` (`GUESTID`, `GENDER`, `NAME`, `ADDRESS`, `COUNTRY`, `CONTACT`, `EMAIL`) VALUES
(1234, 'Female', 'Emily Johnson', '123 Main Street, City Ville', 'United States', '+1 555-1234', 'emily.j@example.com'),
(7345, 'Female', 'Alice Johnson', '789 Sunny Love', 'Canada', '+1 (123) 456-7890', 'alice.j@example.com'),
(12345, 'Male', 'Jhondel Mellomida', 'Pasig City', 'America', '09618960028', 'mellomida0224@gmail.com'),
(13579, 'Male', 'Alex Rodriguez', '789 Pine Avenue, Sonneville', 'Spain', '+34 123-456-789', 'alex.r@example.com'),
(24680, 'Female', 'Sarah Thompson', '101 Maple Lane, Greenfield', 'Australia', '+61 9876-5432', 'sarah.t@example.com'),
(36912, 'Male', 'Daniel Smith', '222 Willow Street, Riverdale', 'United Kingdom', '+44 20 1234-5678', 'daniel.s@example.com'),
(67890, 'Male', 'Michael Davis', '456 Oak Street, Townsville', 'Canada', '+1 555-5678', 'michael.d@example.com'),
(74894, 'Male', 'Jan Doe', '456 Resort Avenue', 'Philippines', '+63 987-654-3210', 'jan.d@example.com'),
(94872, 'Male', 'John Smith', '123 Main Street, Januvia', 'United States', '+1 (555) 123-4567', 'john.s@example.com');

-- --------------------------------------------------------

--
-- Table structure for table `hotel`
--

CREATE TABLE `hotel` (
  `HOTEL_CHOICE_ID` int(11) NOT NULL,
  `HOTEL_CHOICE` varchar(255) NOT NULL,
  `HOTEL_TYPE_ID` int(11) NOT NULL,
  `ADDRESS` varchar(255) NOT NULL,
  `CONTACT` varchar(255) NOT NULL,
  `EMAIL` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `hotel`
--

INSERT INTO `hotel` (`HOTEL_CHOICE_ID`, `HOTEL_CHOICE`, `HOTEL_TYPE_ID`, `ADDRESS`, `CONTACT`, `EMAIL`) VALUES
(1, 'Luxe Haven Hotel', 1, '123 Luxury Street, Luxeville', '+1 123-456-7890', 'luxe.haven@example.com'),
(2, 'Serene Suites', 3, '456 Tranquil Avenue, Tranquil Town', '+1 987-654-3210', 'Serence.suites@example.com'),
(3, 'Tranquil Residences', 4, '789 Calm Street, Calm City', '+34 987-654-321', 'Tranquil.residences@example.com'),
(4, 'Seaside Retreat', 2, '101 Oceanfront Road, Coastal Viilage', '+61 1234-5678', 'Seaside.retreat@example.com');

-- --------------------------------------------------------

--
-- Table structure for table `hotel_type`
--

CREATE TABLE `hotel_type` (
  `HOTEL_TYPE_ID` int(11) NOT NULL,
  `HOTEL_TYPE_NAME` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `hotel_type`
--

INSERT INTO `hotel_type` (`HOTEL_TYPE_ID`, `HOTEL_TYPE_NAME`) VALUES
(1, 'Casino'),
(2, 'Resort'),
(3, 'Motels'),
(4, 'Pet-Friendly');

-- --------------------------------------------------------

--
-- Table structure for table `payment`
--

CREATE TABLE `payment` (
  `PAYMENTID` int(11) NOT NULL,
  `RESERVATIONID` int(11) NOT NULL,
  `PAYMENT_METHOD` enum('VISA','CASH') NOT NULL,
  `CARD_HOLDER_NAME` varchar(255) DEFAULT NULL,
  `CREDIT_CARD_NUMBER` varchar(255) DEFAULT NULL,
  `CVV` varchar(3) DEFAULT NULL,
  `AMOUNT` decimal(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `payment`
--

INSERT INTO `payment` (`PAYMENTID`, `RESERVATIONID`, `PAYMENT_METHOD`, `CARD_HOLDER_NAME`, `CREDIT_CARD_NUMBER`, `CVV`, `AMOUNT`) VALUES
(220100, 55614, 'VISA', 'Emily Johnson', '3214423442343123', '456', 41250.00),
(220101, 29642, 'CASH', NULL, NULL, NULL, 32585.00),
(220102, 46753, 'VISA', 'Alex Rodriguez', '3232423456753421', '789', 66990.00),
(220103, 23674, 'CASH', NULL, NULL, NULL, 41250.00),
(220104, 64367, 'VISA', 'Daniel Smith', '8904784612349573', '432', 32585.00),
(220105, 23808, 'VISA', 'John Smith', '12340987698377281', '876', 26335.00),
(220106, 56820, 'CASH', NULL, NULL, NULL, 42000.00),
(220107, 56821, 'CASH', NULL, NULL, NULL, 34385.00),
(220108, 74558, 'VISA', 'Alice Johnson', '3435847582919375', '498', 42000.00),
(220109, 74559, 'VISA', 'Alice Johnson', '3435847582919375', '498', 42000.00),
(220110, 74560, 'VISA', 'Alice Johnson', '3435847582919375', '498', 55640.00),
(220111, 74561, 'VISA', 'Jhondel', '276435756433', '123', 54542.00);

-- --------------------------------------------------------

--
-- Stand-in structure for view `refresh`
-- (See below for the actual view)
--
CREATE TABLE `refresh` (
`RESERVATIONID` int(11)
,`GUESTID` int(11)
,`FIRST_CHOICE_HOTEL` varchar(255)
,`SECOND_CHOICE_HOTEL` varchar(255)
,`HOTEL_CHOICE_ID` int(11)
,`CHECK_IN_TIME` time
,`CHECK_OUT_TIME` time
,`CHECK_IN_DATE` date
,`CHECK_OUT_DATE` date
,`NO_OF_NIGHTS` int(11)
,`ROOM_TYPE_ID` int(11)
,`BED_REFERENCES_ID` int(11)
,`NO_OF_ROOMS` int(11)
,`EXTRA` set('pillows','towels','snacks','blankets')
,`NO_OF_CHILDREN` int(11)
,`NO_OF_ADULTS` int(11)
,`TOTAL_NO_GUESTS` int(11)
,`GID` int(11)
,`GENDER` enum('Male','Female')
,`NAME` varchar(255)
,`ADDRESS` varchar(255)
,`COUNTRY` varchar(255)
,`CONTACT` varchar(255)
,`EMAIL` varchar(255)
,`PAYMENTID` int(11)
,`P_RESERVATIONID` int(11)
,`PAYMENT_METHOD` enum('VISA','CASH')
,`CARD_HOLDER_NAME` varchar(255)
,`CREDIT_CARD_NUMBER` varchar(255)
,`CVV` varchar(3)
,`AMOUNT` decimal(10,2)
);

-- --------------------------------------------------------

--
-- Table structure for table `reservation`
--

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
  `TOTAL_NO_GUESTS` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `reservation`
--

INSERT INTO `reservation` (`RESERVATIONID`, `GUESTID`, `FIRST_CHOICE_HOTEL`, `SECOND_CHOICE_HOTEL`, `HOTEL_CHOICE_ID`, `CHECK_IN_TIME`, `CHECK_OUT_TIME`, `CHECK_IN_DATE`, `CHECK_OUT_DATE`, `NO_OF_NIGHTS`, `ROOM_TYPE_ID`, `BED_REFERENCES_ID`, `NO_OF_ROOMS`, `EXTRA`, `NO_OF_CHILDREN`, `NO_OF_ADULTS`, `TOTAL_NO_GUESTS`) VALUES
(23674, 24680, 'Seaside Retreat', 'Luxe Haven Hotel', 4, '09:00:00', '16:00:00', '2023-08-15', '2023-08-20', 5, 2, 2, 1, 'pillows', 0, 2, 2),
(23808, 94872, 'Seaside Retreat', 'Luxe Haven Hotel', 4, '05:00:00', '11:00:00', '2023-03-14', '2023-03-18', 4, 1, 2, 1, '', 0, 1, 1),
(29642, 67890, 'Serene Suites', 'Tranquil Residences', 2, '16:00:00', '09:00:00', '2023-06-10', '2023-06-15', 5, 1, 1, 1, 'pillows,towels', 1, 2, 3),
(46753, 13579, 'Tranquil Residences', 'Seaside Retreat', 3, '06:00:00', '16:00:00', '2023-07-01', '2023-07-07', 6, 3, 3, 1, 'pillows,towels,snacks', 2, 2, 4),
(55614, 1234, 'Luxe Haven Hotel', 'Serene Suites', 1, '09:00:00', '22:00:00', '2023-05-15', '2023-05-20', 5, 2, 2, 1, '', 0, 2, 2),
(56820, 74894, 'Seaside Retreat', '', 4, '04:00:00', '00:00:00', '2023-04-29', '2023-05-04', 5, 2, 3, 1, 'blankets', 0, 2, 2),
(56821, 74894, 'Seaside Retreat', '', 4, '04:00:00', '00:00:00', '2023-04-29', '2023-05-04', 5, 1, 2, 1, 'pillows,snacks', 4, 4, 8),
(64367, 36912, 'Luxe Haven Hotel', 'Tranquil Residences', 1, '19:00:00', '09:00:00', '2023-09-10', '2023-09-15', 5, 1, 1, 1, '', 0, 1, 1),
(74558, 7345, 'Luxe Haven Hotel', 'Black Monkey Hotel', 1, '19:00:00', '09:00:00', '2023-08-15', '2023-08-20', 5, 2, 3, 1, 'blankets', 0, 2, 2),
(74559, 7345, 'Luxe Haven Hotel', 'Black Monkey Hotel', 1, '19:00:00', '09:00:00', '2023-08-15', '2023-08-20', 5, 2, 3, 1, '', 0, 2, 2),
(74560, 7345, 'Luxe Haven Hotel', 'Black Monkey Hotel', 1, '19:00:00', '09:00:00', '2023-08-15', '2023-08-20', 5, 3, 3, 1, '', 0, 2, 2),
(74561, 7345, 'Luxe Haven Hotel', 'Seaside Retreat', 1, '19:00:00', '09:00:00', '2023-08-15', '2023-08-20', 5, 3, 3, 2, '', 1, 1, 2);

--
-- Triggers `reservation`
--
DELIMITER $$
CREATE TRIGGER `calculate_guests` BEFORE INSERT ON `reservation` FOR EACH ROW SET NEW.TOTAL_NO_GUESTS = NEW.NO_OF_CHILDREN + NEW.NO_OF_ADULTS
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `calculate_nights` BEFORE INSERT ON `reservation` FOR EACH ROW SET NEW.NO_OF_NIGHTS = DATEDIFF(NEW.CHECK_OUT_DATE, NEW.CHECK_IN_DATE)
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `set_hotel_choice` BEFORE INSERT ON `reservation` FOR EACH ROW BEGIN
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

  
  
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `room`
--

CREATE TABLE `room` (
  `ROOM_TYPE_ID` int(11) NOT NULL,
  `ROOM_TYPE` varchar(255) NOT NULL,
  `ROOM_RATE` decimal(10,2) NOT NULL,
  `DOWNPAYMENT` decimal(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `room`
--

INSERT INTO `room` (`ROOM_TYPE_ID`, `ROOM_TYPE`, `ROOM_RATE`, `DOWNPAYMENT`) VALUES
(1, 'Standard', 6650.00, 665.00),
(2, 'Deluxe', 8320.00, 850.00),
(3, 'Suites', 11100.00, 1110.00);

-- --------------------------------------------------------

--
-- Stand-in structure for view `totaldata`
-- (See below for the actual view)
--
CREATE TABLE `totaldata` (
`GUESTID` int(11)
,`GENDER` enum('Male','Female')
,`NAME` varchar(255)
,`ADDRESS` varchar(255)
,`COUNTRY` varchar(255)
,`CONTACT` varchar(255)
,`EMAIL` varchar(255)
,`RESERVATIONID` int(11)
,`FIRST_CHOICE_HOTEL` varchar(255)
,`SECOND_CHOICE_HOTEL` varchar(255)
,`HOTEL_CHOICE_ID` int(11)
,`CHECK_IN_TIME` time
,`CHECK_OUT_TIME` time
,`CHECK_IN_DATE` date
,`CHECK_OUT_DATE` date
,`NO_OF_NIGHTS` int(11)
,`ROOM_TYPE_ID` int(11)
,`BED_REFERENCES_ID` int(11)
,`NO_OF_ROOMS` int(11)
,`EXTRA` set('pillows','towels','snacks','blankets')
,`NO_OF_CHILDREN` int(11)
,`NO_OF_ADULTS` int(11)
,`TOTAL_NO_GUESTS` int(11)
,`PAYMENTID` int(11)
,`PAYMENT_METHOD` enum('VISA','CASH')
,`CARD_HOLDER_NAME` varchar(255)
,`CREDIT_CARD_NUMBER` varchar(255)
,`CVV` varchar(3)
,`AMOUNT` decimal(10,2)
,`BED_REFERENCES` varchar(255)
,`BED_RATE` decimal(10,2)
,`ROOM_TYPE` varchar(255)
,`ROOM_RATE` decimal(10,2)
,`DOWNPAYMENT` decimal(10,2)
,`HOTEL_CHOICE` varchar(255)
,`HOTEL_TYPE_ID` int(11)
,`HOTEL_ADDRESS` varchar(255)
,`HOTEL_CONTACT` varchar(255)
,`HOTEL_EMAIL` varchar(255)
,`HOTEL_TYPE_NAME` varchar(255)
);

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `cashier_id` int(11) NOT NULL,
  `username` varchar(50) NOT NULL,
  `password` varchar(255) NOT NULL,
  `last_login` datetime DEFAULT NULL,
  `isActive` tinyint(1) DEFAULT 1,
  `email` varchar(100) NOT NULL,
  `name` varchar(100) NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  `updated_at` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `role` enum('cashier','admin') NOT NULL DEFAULT 'cashier'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`cashier_id`, `username`, `password`, `last_login`, `isActive`, `email`, `name`, `created_at`, `updated_at`, `role`) VALUES
(1, 'OkayNoice', '3180cc4bbe5b7fffe0fd53d7384eec3f837f5a3d270ac03fdb07282961981437', '2024-10-05 11:29:49', 1, '', 'Jhondel Mellomida', '2024-10-05 03:04:10', '2024-10-05 03:29:49', 'cashier');

-- --------------------------------------------------------

--
-- Structure for view `expenses`
--
DROP TABLE IF EXISTS `expenses`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `expenses`  AS SELECT `p`.`AMOUNT` AS `Amount`, `g`.`GUESTID` AS `GUESTID` FROM ((`reservation` `r` join `guest` `g` on(`r`.`GUESTID` = `g`.`GUESTID`)) join `payment` `p` on(`r`.`RESERVATIONID` = `p`.`RESERVATIONID`)) ;

-- --------------------------------------------------------

--
-- Structure for view `refresh`
--
DROP TABLE IF EXISTS `refresh`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `refresh`  AS SELECT `r`.`RESERVATIONID` AS `RESERVATIONID`, `r`.`GUESTID` AS `GUESTID`, `r`.`FIRST_CHOICE_HOTEL` AS `FIRST_CHOICE_HOTEL`, `r`.`SECOND_CHOICE_HOTEL` AS `SECOND_CHOICE_HOTEL`, `r`.`HOTEL_CHOICE_ID` AS `HOTEL_CHOICE_ID`, `r`.`CHECK_IN_TIME` AS `CHECK_IN_TIME`, `r`.`CHECK_OUT_TIME` AS `CHECK_OUT_TIME`, `r`.`CHECK_IN_DATE` AS `CHECK_IN_DATE`, `r`.`CHECK_OUT_DATE` AS `CHECK_OUT_DATE`, `r`.`NO_OF_NIGHTS` AS `NO_OF_NIGHTS`, `r`.`ROOM_TYPE_ID` AS `ROOM_TYPE_ID`, `r`.`BED_REFERENCES_ID` AS `BED_REFERENCES_ID`, `r`.`NO_OF_ROOMS` AS `NO_OF_ROOMS`, `r`.`EXTRA` AS `EXTRA`, `r`.`NO_OF_CHILDREN` AS `NO_OF_CHILDREN`, `r`.`NO_OF_ADULTS` AS `NO_OF_ADULTS`, `r`.`TOTAL_NO_GUESTS` AS `TOTAL_NO_GUESTS`, `g`.`GUESTID` AS `GID`, `g`.`GENDER` AS `GENDER`, `g`.`NAME` AS `NAME`, `g`.`ADDRESS` AS `ADDRESS`, `g`.`COUNTRY` AS `COUNTRY`, `g`.`CONTACT` AS `CONTACT`, `g`.`EMAIL` AS `EMAIL`, `p`.`PAYMENTID` AS `PAYMENTID`, `p`.`RESERVATIONID` AS `P_RESERVATIONID`, `p`.`PAYMENT_METHOD` AS `PAYMENT_METHOD`, `p`.`CARD_HOLDER_NAME` AS `CARD_HOLDER_NAME`, `p`.`CREDIT_CARD_NUMBER` AS `CREDIT_CARD_NUMBER`, `p`.`CVV` AS `CVV`, `p`.`AMOUNT` AS `AMOUNT` FROM ((`guest` `g` left join `reservation` `r` on(`g`.`GUESTID` = `r`.`GUESTID`)) left join `payment` `p` on(`r`.`RESERVATIONID` = `p`.`RESERVATIONID`)) ;

-- --------------------------------------------------------

--
-- Structure for view `totaldata`
--
DROP TABLE IF EXISTS `totaldata`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `totaldata`  AS SELECT `guest`.`GUESTID` AS `GUESTID`, `guest`.`GENDER` AS `GENDER`, `guest`.`NAME` AS `NAME`, `guest`.`ADDRESS` AS `ADDRESS`, `guest`.`COUNTRY` AS `COUNTRY`, `guest`.`CONTACT` AS `CONTACT`, `guest`.`EMAIL` AS `EMAIL`, `reservation`.`RESERVATIONID` AS `RESERVATIONID`, `reservation`.`FIRST_CHOICE_HOTEL` AS `FIRST_CHOICE_HOTEL`, `reservation`.`SECOND_CHOICE_HOTEL` AS `SECOND_CHOICE_HOTEL`, `reservation`.`HOTEL_CHOICE_ID` AS `HOTEL_CHOICE_ID`, `reservation`.`CHECK_IN_TIME` AS `CHECK_IN_TIME`, `reservation`.`CHECK_OUT_TIME` AS `CHECK_OUT_TIME`, `reservation`.`CHECK_IN_DATE` AS `CHECK_IN_DATE`, `reservation`.`CHECK_OUT_DATE` AS `CHECK_OUT_DATE`, `reservation`.`NO_OF_NIGHTS` AS `NO_OF_NIGHTS`, `reservation`.`ROOM_TYPE_ID` AS `ROOM_TYPE_ID`, `reservation`.`BED_REFERENCES_ID` AS `BED_REFERENCES_ID`, `reservation`.`NO_OF_ROOMS` AS `NO_OF_ROOMS`, `reservation`.`EXTRA` AS `EXTRA`, `reservation`.`NO_OF_CHILDREN` AS `NO_OF_CHILDREN`, `reservation`.`NO_OF_ADULTS` AS `NO_OF_ADULTS`, `reservation`.`TOTAL_NO_GUESTS` AS `TOTAL_NO_GUESTS`, `payment`.`PAYMENTID` AS `PAYMENTID`, `payment`.`PAYMENT_METHOD` AS `PAYMENT_METHOD`, `payment`.`CARD_HOLDER_NAME` AS `CARD_HOLDER_NAME`, `payment`.`CREDIT_CARD_NUMBER` AS `CREDIT_CARD_NUMBER`, `payment`.`CVV` AS `CVV`, `payment`.`AMOUNT` AS `AMOUNT`, `bed`.`BED_REFERENCES` AS `BED_REFERENCES`, `bed`.`BED_RATE` AS `BED_RATE`, `room`.`ROOM_TYPE` AS `ROOM_TYPE`, `room`.`ROOM_RATE` AS `ROOM_RATE`, `room`.`DOWNPAYMENT` AS `DOWNPAYMENT`, `hotel`.`HOTEL_CHOICE` AS `HOTEL_CHOICE`, `hotel`.`HOTEL_TYPE_ID` AS `HOTEL_TYPE_ID`, `hotel`.`ADDRESS` AS `HOTEL_ADDRESS`, `hotel`.`CONTACT` AS `HOTEL_CONTACT`, `hotel`.`EMAIL` AS `HOTEL_EMAIL`, `hotel_type`.`HOTEL_TYPE_NAME` AS `HOTEL_TYPE_NAME` FROM ((((((`guest` join `reservation` on(`guest`.`GUESTID` = `reservation`.`GUESTID`)) join `payment` on(`reservation`.`RESERVATIONID` = `payment`.`RESERVATIONID`)) join `bed` on(`reservation`.`BED_REFERENCES_ID` = `bed`.`BED_REFERENCES_ID`)) join `room` on(`reservation`.`ROOM_TYPE_ID` = `room`.`ROOM_TYPE_ID`)) join `hotel` on(`reservation`.`HOTEL_CHOICE_ID` = `hotel`.`HOTEL_CHOICE_ID`)) join `hotel_type` on(`hotel`.`HOTEL_TYPE_ID` = `hotel_type`.`HOTEL_TYPE_ID`)) ;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `bed`
--
ALTER TABLE `bed`
  ADD PRIMARY KEY (`BED_REFERENCES_ID`);

--
-- Indexes for table `guest`
--
ALTER TABLE `guest`
  ADD PRIMARY KEY (`GUESTID`),
  ADD UNIQUE KEY `EMAIL` (`EMAIL`);

--
-- Indexes for table `hotel`
--
ALTER TABLE `hotel`
  ADD PRIMARY KEY (`HOTEL_CHOICE_ID`),
  ADD UNIQUE KEY `EMAIL` (`EMAIL`),
  ADD KEY `HOTEL_TYPE_ID` (`HOTEL_TYPE_ID`);

--
-- Indexes for table `hotel_type`
--
ALTER TABLE `hotel_type`
  ADD PRIMARY KEY (`HOTEL_TYPE_ID`);

--
-- Indexes for table `payment`
--
ALTER TABLE `payment`
  ADD PRIMARY KEY (`PAYMENTID`),
  ADD KEY `RESERVATIONID` (`RESERVATIONID`);

--
-- Indexes for table `reservation`
--
ALTER TABLE `reservation`
  ADD PRIMARY KEY (`RESERVATIONID`),
  ADD KEY `GUESTID` (`GUESTID`),
  ADD KEY `HOTEL_CHOICE_ID` (`HOTEL_CHOICE_ID`),
  ADD KEY `ROOM_TYPE_ID` (`ROOM_TYPE_ID`),
  ADD KEY `BED_REFERENCES_ID` (`BED_REFERENCES_ID`);

--
-- Indexes for table `room`
--
ALTER TABLE `room`
  ADD PRIMARY KEY (`ROOM_TYPE_ID`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`cashier_id`),
  ADD UNIQUE KEY `username` (`username`),
  ADD UNIQUE KEY `email` (`email`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `bed`
--
ALTER TABLE `bed`
  MODIFY `BED_REFERENCES_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `hotel`
--
ALTER TABLE `hotel`
  MODIFY `HOTEL_CHOICE_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT for table `hotel_type`
--
ALTER TABLE `hotel_type`
  MODIFY `HOTEL_TYPE_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `room`
--
ALTER TABLE `room`
  MODIFY `ROOM_TYPE_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `cashier_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `hotel`
--
ALTER TABLE `hotel`
  ADD CONSTRAINT `hotel_ibfk_1` FOREIGN KEY (`HOTEL_TYPE_ID`) REFERENCES `hotel_type` (`HOTEL_TYPE_ID`) ON DELETE CASCADE;

--
-- Constraints for table `payment`
--
ALTER TABLE `payment`
  ADD CONSTRAINT `payment_ibfk_1` FOREIGN KEY (`RESERVATIONID`) REFERENCES `reservation` (`RESERVATIONID`) ON DELETE CASCADE;

--
-- Constraints for table `reservation`
--
ALTER TABLE `reservation`
  ADD CONSTRAINT `reservation_ibfk_1` FOREIGN KEY (`GUESTID`) REFERENCES `guest` (`GUESTID`) ON DELETE CASCADE,
  ADD CONSTRAINT `reservation_ibfk_2` FOREIGN KEY (`HOTEL_CHOICE_ID`) REFERENCES `hotel` (`HOTEL_CHOICE_ID`) ON DELETE CASCADE,
  ADD CONSTRAINT `reservation_ibfk_3` FOREIGN KEY (`ROOM_TYPE_ID`) REFERENCES `room` (`ROOM_TYPE_ID`) ON DELETE CASCADE,
  ADD CONSTRAINT `reservation_ibfk_4` FOREIGN KEY (`BED_REFERENCES_ID`) REFERENCES `bed` (`BED_REFERENCES_ID`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
