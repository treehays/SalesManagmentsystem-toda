CREATE TABLE `admin` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `StaffId` varchar(25) NOT NULL,
  `FirstName` varchar(255) NOT NULL,
  `LastName` varchar(255) NOT NULL,
  `Email` varchar(100) NOT NULL,
  `PhoneNumber` varchar(25) NOT NULL,
  `Pin` varchar(50) DEFAULT '0000',
  `Post` varchar(50) DEFAULT 'Attendant',
  PRIMARY KEY (`ID`,`StaffId`),
  UNIQUE KEY `StaffId` (`StaffId`),
  UNIQUE KEY `Email` (`Email`),
  UNIQUE KEY `PhoneNumber` (`PhoneNumber`)
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `attendant` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `StaffId` varchar(25) NOT NULL,
  `FirstName` varchar(255) NOT NULL,
  `LastName` varchar(255) NOT NULL,
  `Email` varchar(100) NOT NULL,
  `PhoneNumber` varchar(25) NOT NULL,
  `Pin` varchar(50) DEFAULT '0000',
  `Post` varchar(50) DEFAULT 'Attendant',
  PRIMARY KEY (`ID`,`StaffId`),
  UNIQUE KEY `StaffId` (`StaffId`),
  UNIQUE KEY `Email` (`Email`),
  UNIQUE KEY `PhoneNumber` (`PhoneNumber`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;


CREATE TABLE `product` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Barcode` varchar(50) NOT NULL,
  `productname` varchar(255) NOT NULL,
  `price` decimal(15,2) NOT NULL,
  `productquantity` int NOT NULL,
  PRIMARY KEY (`ID`,`Barcode`)
) ENGINE=InnoDB AUTO_INCREMENT=434 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;


CREATE TABLE `transaction` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `receiptNo` varchar(100) NOT NULL,
  `Barcode` varchar(50) NOT NULL,
  `productname` varchar(255) NOT NULL,
  `price` decimal(15,2) NOT NULL,
  `quantity` int NOT NULL,
  `total` decimal(20,2) NOT NULL,
  `customerid` varchar(100) DEFAULT 'Customer',
  `cashtender` decimal(20,2) NOT NULL,
  `datetimes` varchar(100) NOT NULL,
  `withdraw` decimal(20,2) NOT NULL DEFAULT '0.00',
  `staffId` varchar(45) NOT NULL,
  PRIMARY KEY (`ID`,`receiptNo`),
  UNIQUE KEY `receiptNo` (`receiptNo`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;


