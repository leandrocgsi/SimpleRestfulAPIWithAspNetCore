CREATE TABLE IF NOT EXISTS `contacts` (
  `id` varchar(127) NOT NULL,
  `AnniversaryDate` datetime(6) NOT NULL,
  `Company` longtext,
  `DateOfBirth` datetime(6) NOT NULL,
  `Email` longtext,
  `FirstName` longtext,
  `IsFamilyMember` bit(1) NOT NULL,
  `JobTitle` longtext,
  `LastName` longtext,
  `MobilePhone` longtext,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

CREATE TABLE IF NOT EXISTS `films` (
  `id` varchar(127) NOT NULL,
  `Description` longtext,
  `Length` int(11) NOT NULL,
  `Rating` longtext,
  `ReleaseYear` int(11) NOT NULL,
  `Title` longtext,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;