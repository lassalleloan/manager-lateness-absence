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
-- Structure de la table `student`
--

CREATE TABLE IF NOT EXISTS `student` (
  `idStudent` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) DEFAULT NULL,
  `FirstName` varchar(45) DEFAULT NULL,
  `NumberLateness` int(11) DEFAULT NULL,
  `NumberAbsence` int(11) DEFAULT NULL,
  `idClass` int(11) NOT NULL,
  PRIMARY KEY (`idStudent`),
  KEY `fk_Eleve_Classe_idx` (`idClass`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=120 ;

--
-- Contenu de la table `student`
--

INSERT INTO `student` (`idStudent`, `Name`, `FirstName`, `NumberLateness`, `NumberAbsence`, `idClass`) VALUES
(1, 'Antonini', 'Eric', 0, 0, 1),
(2, 'Carnal', 'Damien', 1, 0, 1),
(3, 'Kang-A-Birang', 'Camille', 0, 0, 1),
(4, 'Kreis', 'Cédric', 0, 1, 1),
(5, 'Lassalle', 'Loan', 15, 125, 1),
(6, 'Malerba', 'Gianluca', 0, 0, 1),
(7, 'Martignier', 'Stéphane', 0, 1, 1),
(8, 'Meier', 'Christopher', 0, 1, 1),
(9, 'Moreira', 'Erwan', 0, 0, 1),
(10, 'Mulone', 'Damien', 35, 115, 1),
(11, 'Palumbo', 'Daniel', 0, 0, 1),
(12, 'Ribeiro-Mendonca', 'Roberto', 0, 1, 1),
(13, 'Valente-Calado', 'César', 0, 1, 1),
(14, 'Apputhurai', 'Sujevan', 0, 0, 2),
(15, 'Bagnoud', 'Keren', 0, 0, 2),
(16, 'Benallal', 'Nadir', 0, 1, 2),
(17, 'Cavin', 'Jimmy', 1, 0, 2),
(18, 'Curchod', 'Xavier', 0, 0, 2),
(19, 'Jribi', 'Wissem', 0, 0, 2),
(20, 'Megevand', 'Nathalie', 0, 1, 2),
(21, 'Pagliaro', 'Alexandre', 0, 1, 2),
(22, 'Rafidimalala', 'Iando', 0, 0, 2),
(23, 'Rinderknecht', 'Stephane', 0, 0, 2),
(24, 'Ruberto', 'Adriano', 26, 72, 2),
(25, 'Rui', 'Mario', 0, 1, 2),
(26, 'Truong', 'Hoang-Nghia', 0, 0, 2),
(27, 'Villard', 'Matthieu', 13, 12, 2),
(28, 'Assayah', 'Jordan', 0, 0, 3),
(29, 'Audibert', 'Julien', 0, 0, 3),
(30, 'Desire', 'Loris', 0, 0, 3),
(31, 'Estoppey', 'Marco', 0, 0, 3),
(32, 'Goncalves', 'Bruno', 0, 0, 3),
(33, 'Guignard', 'Sarah', 0, 0, 3),
(34, 'Krattinger', 'Joel', 0, 0, 3),
(35, 'Mettraux', 'Audrey', 132, 64, 3),
(36, 'Rajkovic', 'Aleksandar', 0, 0, 3),
(37, 'Redondo-Colls', 'Genesis', 0, 0, 3),
(38, 'Sipala', 'Alessandro', 0, 0, 3),
(39, 'Tharmalingam', 'Kabinan', 0, 0, 3),
(40, 'Avci', 'Murat', 0, 2, 4),
(41, 'Bader', 'Mike', 0, 0, 4),
(42, 'Baer', 'Bastien', 0, 0, 4),
(43, 'Bamogo', 'Krisyam-Yves', 0, 0, 4),
(44, 'Bornoz', 'Raphael', 1, 0, 4),
(45, 'Debetaz', 'Jonathan', 0, 0, 4),
(46, 'Durussel', 'Quentin', 0, 0, 4),
(47, 'Fluckiger', 'Joel', 0, 0, 4),
(48, 'Guinamant', 'Xavier', 0, 0, 4),
(49, 'Heintz', 'Camille', 58, 35, 4),
(50, 'Le', 'Jean-Yves', 0, 0, 4),
(51, 'Pereira-Pinto', 'Filipe', 0, 0, 4),
(52, 'Platrier', 'Elie', 0, 0, 4),
(53, 'Rossier', 'Quentin', 1, 0, 4),
(54, 'Bousbaa', 'Eric', 0, 0, 5),
(55, 'Cruz', 'Ruben', 0, 0, 5),
(56, 'Dubey', 'Abigael', 0, 0, 5),
(57, 'Gasche', 'Isabelle', 0, 0, 5),
(58, 'Gillet', 'Paul', 0, 0, 5),
(59, 'Gonnet', 'Aurelien', 0, 0, 5),
(60, 'Haldi', 'Steven', 0, 0, 5),
(61, 'Marendaz', 'Gregory', 0, 0, 5),
(62, 'Neves', 'Quentin', 0, 0, 5),
(63, 'Ribagnac', 'Yann', 0, 0, 5),
(64, 'Ricci', 'Thomas', 0, 0, 5),
(65, 'Uhan', 'Melodie', 254, 78, 5),
(66, 'Acuna-Ramirez', 'Camilo', 0, 0, 5),
(67, 'Cardillo', 'Fabio', 0, 0, 6),
(68, 'Combremont', 'Gael', 0, 0, 6),
(69, 'Fidalgo', 'Leonardo', 0, 1, 6),
(70, 'Giordano', 'Antonio', 0, 0, 6),
(71, 'Grisel', 'Saber', 0, 0, 6),
(72, 'Pierre', 'Aloys', 0, 0, 6),
(73, 'Silva-Marques', 'Fabio-Manuel', 134, 94, 6),
(74, 'Charmey', 'Melissa', 0, 0, 7),
(75, 'Fagone', 'Marco', 0, 0, 7),
(76, 'Fries', 'Gillian', 0, 0, 7),
(77, 'Grand', 'Benjamin', 0, 0, 7),
(78, 'Ivanovic', 'Miroljub', 0, 0, 7),
(79, 'Jaques', 'Dany', 0, 0, 7),
(80, 'Jovic', 'Nenad', 0, 0, 7),
(81, 'Micco', 'Lionel', 0, 0, 7),
(82, 'Perret', 'Yannick', 0, 0, 7),
(83, 'Rossi', 'Steve', 0, 0, 7),
(84, 'Rousseaux', 'Nicolas', 58, 115, 7),
(85, 'Ansermoz', 'Jeremy', 0, 0, 8),
(86, 'Colaco', 'Yann', 0, 0, 8),
(87, 'Gilalmeida', 'Joaocarlos', 0, 0, 8),
(88, 'Goujgali', 'Ilias', 0, 0, 8),
(89, 'Nagaratnam', 'Jaciban', 0, 0, 8),
(90, 'Pichonnat', 'Alain', 0, 0, 8),
(91, 'Staffieri', 'Loris', 0, 0, 8),
(92, 'Veiga-Ferreira', 'Andre', 0, 0, 8),
(93, 'Wolf', 'Gabriel', 0, 0, 8),
(94, 'Beauverd', 'Yann', 0, 0, 9),
(95, 'Blanco', 'Guillaume', 8, 115, 9),
(96, 'Clerc', 'Alexis', 0, 0, 9),
(97, 'Ferreira', 'Kevin', 0, 0, 9),
(98, 'Geinoz', 'Loic', 0, 0, 9),
(99, 'Gnanasekaram', 'Tharsshan', 345, 36, 9),
(100, 'Graf', 'Mael', 58, 42, 9),
(101, 'Guibert', 'Chris', 0, 0, 9),
(102, 'Hussein', 'Aqil', 0, 0, 9),
(103, 'Karoui', 'Saif', 0, 0, 9),
(104, 'Leeser', 'Lionel', 0, 0, 9),
(105, 'Martin', 'Nikita', 0, 0, 9),
(106, 'Shanmuganathan	', 'Suveeshan', 0, 0, 9),
(107, 'Vonsiebenthal', 'Leo', 0, 0, 9),
(108, 'Baumgartner', 'Eric', 0, 0, 10),
(109, 'Buchmann', 'Maxime', 1, 0, 10),
(110, 'Clemente', 'Lucas', 0, 0, 10),
(111, 'Kryeziu', 'Nebih', 0, 1, 10),
(112, 'Marquis', 'Joel', 0, 0, 10),
(113, 'Montet', 'Vincent', 67, 154, 10),
(114, 'Othenin-girard', 'Gaetan', 0, 0, 10),
(115, 'Reka', 'Mentor', 156, 115, 10),
(116, 'Scherwey', 'Matthias', 0, 0, 10),
(117, 'Tagirov', 'Erik', 0, 0, 10),
(118, 'Vulliens', 'Maxime', 0, 0, 10),
(119, 'Wenger', 'Joris', 0, 1, 10);

--
-- Contraintes pour les tables exportées
--

--
-- Contraintes pour la table `student`
--
ALTER TABLE `student`
  ADD CONSTRAINT `fk_Eleve_Classe` FOREIGN KEY (`idClass`) REFERENCES `class` (`idClass`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Student_Class` FOREIGN KEY (`idClass`) REFERENCES `class` (`idClass`) ON DELETE NO ACTION ON UPDATE NO ACTION;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
