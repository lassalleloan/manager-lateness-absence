-- phpMyAdmin SQL Dump
-- version 4.1.14
-- http://www.phpmyadmin.net
--
-- Client :  127.0.0.1
-- Généré le :  Mer 18 Juin 2014 à 23:27
-- Version du serveur :  5.6.17
-- Version de PHP :  5.5.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Base de données :  `managementlatenessabsence`
--

-- --------------------------------------------------------

--
-- Structure de la table `period`
--

CREATE TABLE IF NOT EXISTS `period` (
  `idPeriod` int(11) NOT NULL,
  `StartTime` time DEFAULT NULL,
  `EndTime` time DEFAULT NULL,
  PRIMARY KEY (`idPeriod`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Contenu de la table `period`
--

INSERT INTO `period` (`idPeriod`, `StartTime`, `EndTime`) VALUES
(1, '08:00:00', '08:45:00'),
(2, '08:50:00', '09:35:00'),
(3, '09:50:00', '10:35:00'),
(4, '10:40:00', '11:25:00'),
(5, '11:30:00', '12:15:00'),
(6, '12:15:00', '13:30:00'),
(7, '13:30:00', '14:15:00'),
(8, '14:20:00', '15:05:00'),
(9, '15:20:00', '16:05:00'),
(10, '16:10:00', '16:55:00');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
