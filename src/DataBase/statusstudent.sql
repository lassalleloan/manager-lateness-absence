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
-- Structure de la table `statusstudent`
--

CREATE TABLE IF NOT EXISTS `statusstudent` (
  `idStudent` int(11) NOT NULL,
  `idCourse` int(11) NOT NULL,
  `Lateness` tinyint(1) DEFAULT NULL,
  `Absent` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`idStudent`,`idCourse`),
  KEY `fk_PresenceRetardAbsence_Eleve1_idx` (`idStudent`),
  KEY `fk_PresenceRetardAbsence_Cours1_idx` (`idCourse`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Contenu de la table `statusstudent`
--

INSERT INTO `statusstudent` (`idStudent`, `idCourse`, `Lateness`, `Absent`) VALUES
(2, 332, 1, 0),
(3, 332, 0, 0),
(5, 331, 0, 0),
(5, 332, 0, 0),
(5, 334, 0, 0),
(6, 331, 0, 0),
(6, 332, 0, 0),
(7, 332, 0, 1),
(8, 332, 0, 1),
(10, 332, 0, 1),
(12, 332, 0, 0),
(13, 332, 0, 1),
(14, 338, 0, 0),
(16, 338, 0, 1),
(17, 337, 1, 0),
(17, 338, 0, 0),
(19, 338, 0, 0),
(20, 338, 0, 1),
(21, 338, 0, 1),
(22, 338, 0, 0),
(24, 338, 0, 1),
(25, 338, 0, 1),
(26, 338, 0, 0),
(32, 327, 0, 0),
(40, 318, 0, 1),
(40, 321, 0, 1),
(41, 323, 0, 0),
(43, 321, 0, 0),
(44, 318, 1, 0),
(49, 318, 0, 1),
(53, 318, 1, 0),
(58, 341, 0, 0),
(76, 44, 0, 0),
(109, 301, 0, 0),
(109, 305, 0, 0),
(109, 311, 1, 0),
(110, 301, 0, 0),
(111, 301, 0, 0),
(111, 305, 0, 0),
(111, 311, 0, 1),
(111, 314, 0, 0),
(112, 301, 0, 0),
(113, 301, 0, 0),
(113, 305, 0, 0),
(113, 311, 0, 1),
(114, 305, 0, 0),
(118, 305, 0, 0),
(119, 311, 0, 1);

--
-- Contraintes pour les tables exportées
--

--
-- Contraintes pour la table `statusstudent`
--
ALTER TABLE `statusstudent`
  ADD CONSTRAINT `fk_PresenceRetardAbsence_Cours1` FOREIGN KEY (`idCourse`) REFERENCES `course` (`idCourse`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_PresenceRetardAbsence_Eleve1` FOREIGN KEY (`idStudent`) REFERENCES `student` (`idStudent`) ON DELETE NO ACTION ON UPDATE NO ACTION;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
