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
-- Structure de la table `discipline`
--

CREATE TABLE IF NOT EXISTS `discipline` (
  `idDiscipline` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) DEFAULT NULL,
  `Description` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`idDiscipline`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=86 ;

--
-- Contenu de la table `discipline`
--

INSERT INTO `discipline` (`idDiscipline`, `Name`, `Description`) VALUES
(0, '', 'Pas de Cours'),
(1, 'I-CH 100', 'Distinguer, préparer et évaluer des donées'),
(2, 'I-CH 101', 'Réaliser et publier un site Web'),
(3, 'I-CH 103', 'Programmer dans un cadre prescrit(structuré)'),
(4, 'I-CH 104', 'Implémenter un modèle de données'),
(5, 'I-CH 105', 'Traiter une base de données SQL'),
(6, 'I-CH 112', 'Assurer une assistance en première instance'),
(7, 'I-CH 117', 'Mettre en place l''infrastructure infomartique d''une petite entreprise'),
(8, 'I-CH 122', 'Automatiser des procédures à l''aide de script et de macros'),
(9, 'I-CH 123', 'Activer les services d''un serveur'),
(10, 'I-CH 124', 'Sélectionner, acquérir et mettre à niveaux du matériel et du logiciel pour PC'),
(11, 'I-CH 127', 'Assurer l''exploitation de serveurs'),
(12, 'I-CH 129', 'Mettre en service des composants réseaux'),
(13, 'I-CH 132', 'Effectuer un appel d''offres et comparer les résultats'),
(14, 'I-CH 133', 'Développer des applications WEB'),
(15, 'I-CH 137', 'Prendre en charge l''assistance en 2ème et 3ème instance'),
(16, 'I-CH 138', 'AMénager des places de travail'),
(17, 'I-CH 143', 'Implémenter un système de sauvegarde et de restauration'),
(18, 'I-CH 146', 'Relier une entreprise à internet'),
(19, 'I-CH 151', 'Développer des applications WEB reliées à des bases de données'),
(20, 'I-CH 182', 'Réaliser la sécurité info d''un système'),
(21, 'I-CH 212', 'Savoir apprendre à travailler'),
(22, 'I-CH 213', 'Savoir travailler en équipe'),
(23, 'I-CH 214', 'Familiariser les utilisateurs et utilisatrices avec l''informatique'),
(24, 'I-CH 239', 'Mettre en servive un serveur WEB'),
(25, 'I-CH 301', 'Utiliser des outils bureautiques'),
(26, 'I-CH 302', 'Utiliser des fonctions avancées dans les outils bureautiques'),
(27, 'I-CH 303', 'Programmer dans un cadre préscrit(basé objets)'),
(28, 'I-CH 304', 'Installer et configurer un PC mono-poste'),
(29, 'I-CH 305', 'Installer, configurer et administrer un système mutli-utilisateurs'),
(30, 'IEL1', 'Loi d''Ohm'),
(31, 'IEL2', 'Base de l''électronique'),
(32, 'IEL3', 'Éléments électoniques'),
(33, 'IEL4', 'Pratique électronique'),
(34, 'MAH1', 'Base du numérique'),
(35, 'MAH2', 'Fonctionnement hardware d''un PC'),
(36, 'MAH3', 'Initiation à la robotique'),
(37, 'MAH4', 'Montage PC'),
(38, 'MAS1', 'Introduction à l''informatique'),
(39, 'MAS2', 'DOS'),
(40, 'MAS3', 'Analyse & logique'),
(41, 'MAS4', 'MindStorm (Lego)'),
(42, 'MAS5', 'Gestion de projet'),
(43, 'MAS6', 'Prog graphique (LabView)'),
(44, 'MAS7', 'Linux'),
(45, 'MAS8', 'Serveur BDD et Workflow'),
(46, 'MAS9', 'Technique de présentation'),
(47, 'MAS10', 'Graphisme WEB'),
(48, 'MAS11', 'Ethique et Informatique'),
(49, 'MAS12', 'Interface Macintosh'),
(50, 'MAS13', 'Recherche d''emploi'),
(51, 'MAS1.1', 'Support'),
(52, 'MAS1.2', 'Virtualisation LAN'),
(53, 'MAS2.1', 'Projet SAAS'),
(54, 'Module : POO1', 'Programmation Orienté Objet'),
(55, 'Module : POO2', 'Programmation Orienté Objet'),
(56, 'Module : POO3', 'Programmation Orienté Objet'),
(57, 'Module : SEC1', 'SEC1'),
(58, 'Module : SEC2', 'SEC2'),
(59, 'Module : RDS', 'RDS'),
(60, 'Projet (C, C#)', 'Projet'),
(61, 'Projet (Groupes)', 'Groupes'),
(62, 'Projet (Interface)', 'Interface'),
(63, 'Projet (Site web dynamique)', 'Site web'),
(64, 'Projet (Système)', 'Système'),
(65, 'Projet (Web)', 'Web'),
(66, 'Projet découvertes', 'Découvertes'),
(67, 'Projet informatique', 'Informatique'),
(68, 'Projet informatique embarquée', 'Informatique embarquée'),
(69, 'Projet interdisciplinaire', 'Interdisciplinaire'),
(70, 'Projet médiamatique', 'Médiamatique'),
(71, 'Projet Pré-TPI', 'Pré-TPI'),
(72, 'Projet Web', 'Web'),
(73, 'Projets', 'Projets'),
(74, 'Gestion et organisation', 'Gestion et organisation'),
(75, 'Gestion de classe', 'Gestion de classe'),
(76, 'Gestion de production', 'Gestion de production'),
(77, 'Gestion de projets', 'Gestion de projets'),
(78, 'Gestion de projets appliquées', 'Gestion de projets appliquées'),
(79, 'Initiation à l''info', 'Initiation à l''info'),
(80, 'Initiation à la programmation', 'Initiation à la programmation'),
(81, 'Initiation bases de données', 'Initiation bases de données'),
(82, 'Initiation bureautique', 'Initiation bureautique'),
(83, 'Initiation développement Web', 'Initiation développement Web'),
(84, 'TPI', 'Travail Personnel Individuel'),
(85, 'Gymnastique et Sport', 'Gymnastique et Sport');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
