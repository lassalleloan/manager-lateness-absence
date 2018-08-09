-- phpMyAdmin SQL Dump
-- version 4.1.14
-- http://www.phpmyadmin.net
--
-- Client :  127.0.0.1
-- Généré le :  Ven 20 Juin 2014 à 09:37
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
-- Structure de la table `teacher`
--

CREATE TABLE IF NOT EXISTS `teacher` (
  `idTeacher` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) DEFAULT NULL,
  `FirstName` varchar(45) DEFAULT NULL,
  `Username` varchar(45) CHARACTER SET latin1 COLLATE latin1_bin DEFAULT NULL,
  `Password` varchar(45) CHARACTER SET latin1 COLLATE latin1_bin DEFAULT NULL,
  PRIMARY KEY (`idTeacher`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=11 ;

--
-- Contenu de la table `teacher`
--

INSERT INTO `teacher` (`idTeacher`, `Name`, `FirstName`, `Username`, `Password`) VALUES
(1, 'Regamey', 'Christophe', 'CRY', 'cry'),
(2, 'Mottier', 'André', 'AMR', 'amr'),
(3, 'Girardier', 'François', 'FGR', 'fgr'),
(4, 'Hurni', 'Pascal', 'PHI', 'phi'),
(5, 'Dafflon', 'Marc', 'MDN', 'mdn'),
(6, 'Chavey', 'Jean-Philippe', 'JCY', 'jcy'),
(7, 'Sigrist', 'Phillipe', 'PST', 'pst'),
(8, 'Toussaint', 'Bertrand', 'TBD', 'tbd'),
(9, 'Altieri', 'Patrick', 'PAI', 'pai'),
(10, 'Benzonana', 'Pascal', 'PBA', 'pba');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
