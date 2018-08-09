SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';


-- -----------------------------------------------------
-- Table `managementLatenessAbsence`.`Discipline`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `managementLatenessAbsence`.`Discipline` (
  `idDiscipline` INT NOT NULL AUTO_INCREMENT ,
  `Name` VARCHAR(45) NULL ,
  `Description` VARCHAR(255) NULL ,
  PRIMARY KEY (`idDiscipline`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `managementLatenessAbsence`.`Period`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `managementLatenessAbsence`.`Period` (
  `idPeriod` INT NOT NULL ,
  `StartTime` TIME NULL ,
  `EndTime` TIME NULL ,
  PRIMARY KEY (`idPeriod`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `managementLatenessAbsence`.`Teacher`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `managementLatenessAbsence`.`Teacher` (
  `idTeacher` INT NOT NULL AUTO_INCREMENT ,
  `Name` VARCHAR(45) NULL ,
  `FirstName` VARCHAR(45) NULL ,
  `Username` VARCHAR(45) NULL ,
  `Password` VARCHAR(45) NULL ,
  PRIMARY KEY (`idTeacher`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `managementLatenessAbsence`.`Class`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `managementLatenessAbsence`.`Class` (
  `idClass` INT NOT NULL AUTO_INCREMENT ,
  `Name` VARCHAR(45) NULL ,
  PRIMARY KEY (`idClass`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `managementLatenessAbsence`.`Student`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `managementLatenessAbsence`.`Student` (
  `idStudent` INT NOT NULL AUTO_INCREMENT ,
  `Name` VARCHAR(45) NULL ,
  `FirstName` VARCHAR(45) NULL ,
  `NumberLateness` INT NULL ,
  `NumberAbsence` INT NULL ,
  `idClass` INT NOT NULL ,
  PRIMARY KEY (`idStudent`) ,
  INDEX `fk_Eleve_Classe_idx` (`idClass` ASC) ,
  CONSTRAINT `fk_Eleve_Classe`
    FOREIGN KEY (`idClass` )
    REFERENCES `managementLatenessAbsence`.`Class` (`idClass` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `managementLatenessAbsence`.`Course`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `managementLatenessAbsence`.`Course` (
  `idCourse` INT NOT NULL AUTO_INCREMENT ,
  `idPeriod` INT NOT NULL ,
  `Date` DATE NULL ,
  `idTeacher` INT NOT NULL ,
  `idDiscipline` INT NOT NULL ,
  `idClass` INT NOT NULL ,
  PRIMARY KEY (`idCourse`, `idPeriod`) ,
  INDEX `fk_Cours_Enseignant1_idx` (`idTeacher` ASC) ,
  INDEX `fk_Cours_Matiere1_idx` (`idDiscipline` ASC) ,
  INDEX `fk_Cours_Periode1_idx` (`idPeriod` ASC) ,
  INDEX `fk_Course_Class1_idx` (`idClass` ASC) ,
  CONSTRAINT `fk_Cours_Enseignant1`
    FOREIGN KEY (`idTeacher` )
    REFERENCES `managementLatenessAbsence`.`Teacher` (`idTeacher` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Cours_Matiere1`
    FOREIGN KEY (`idDiscipline` )
    REFERENCES `managementLatenessAbsence`.`Discipline` (`idDiscipline` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Cours_Periode1`
    FOREIGN KEY (`idPeriod` )
    REFERENCES `managementLatenessAbsence`.`Period` (`idPeriod` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Course_Class1`
    FOREIGN KEY (`idClass` )
    REFERENCES `managementLatenessAbsence`.`Class` (`idClass` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `managementLatenessAbsence`.`StatusStudent`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `managementLatenessAbsence`.`StatusStudent` (
  `idStudent` INT NOT NULL ,
  `idCourse` INT NOT NULL ,
  `Lateness` TINYINT(1) NULL ,
  `Absent` TINYINT(1) NULL ,
  PRIMARY KEY (`idStudent`, `idCourse`) ,
  INDEX `fk_PresenceRetardAbsence_Eleve1_idx` (`idStudent` ASC) ,
  INDEX `fk_PresenceRetardAbsence_Cours1_idx` (`idCourse` ASC) ,
  CONSTRAINT `fk_PresenceRetardAbsence_Eleve1`
    FOREIGN KEY (`idStudent` )
    REFERENCES `managementLatenessAbsence`.`Student` (`idStudent` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_PresenceRetardAbsence_Cours1`
    FOREIGN KEY (`idCourse` )
    REFERENCES `managementLatenessAbsence`.`Course` (`idCourse` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;



SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
