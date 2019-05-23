-- MySQL dump 10.13  Distrib 5.6.43, for Linux (x86_64)
--
-- Host: localhost    Database: BlogDatabase
-- ------------------------------------------------------
-- Server version	5.6.43

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `Articles`
--

DROP TABLE IF EXISTS `Articles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Articles` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Auther` varchar(50) CHARACTER SET utf8 NOT NULL,
  `Title` varchar(50) CHARACTER SET utf8 DEFAULT NULL,
  `Context` varchar(5000) CHARACTER SET utf8 DEFAULT NULL,
  `Date` datetime NOT NULL,
  `LastModify` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  `Remark` text,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Articles`
--

LOCK TABLES `Articles` WRITE;
/*!40000 ALTER TABLE `Articles` DISABLE KEYS */;
INSERT INTO `Articles` VALUES (7,'admin','???????','??????????!','2019-04-23 18:17:22','0001-01-01 00:00:00',NULL),(8,'admin','添加了翻页功能','成功增加了分页的功能！','2019-04-23 18:53:42','0001-01-01 00:00:00',NULL),(9,'admin','完善了翻页功能','给分页功能添加了分页数据，包括当前页、总页数、总条数、前后页URL等','2019-04-23 21:42:57','0001-01-01 00:00:00',NULL),(10,'admin','完善了翻页功能','给分页功能添加了分页数据，包括当前页、总页数、总条数、前后页URL等','2019-04-24 14:05:07','0001-01-01 00:00:00',NULL),(11,'admin','Test Patch Api','HELLOOOOOOOppppppppppppppppppppppoooooooooooooooooooooooooooO','2019-05-14 13:57:53','2019-05-14 18:03:54',NULL),(12,'admin','New Post text',NULL,'2019-05-13 16:34:21','0001-01-01 00:00:00',NULL),(13,'admin','New Post text','```````````````````````````````````','2019-05-13 16:42:48','0001-01-01 00:00:00',NULL),(14,'admin','New Post text','```````````````````````````````````','2019-05-13 16:46:38','0001-01-01 00:00:00',NULL),(15,'admin','New Post text','```````````````````````````````````','2019-05-13 16:47:35','0001-01-01 00:00:00',NULL),(16,'admin','New Post text','```````````````````````````````````','2019-05-13 16:48:32','0001-01-01 00:00:00',NULL),(17,'admin','测试属性验证t','`````````````````````````````````···························································································``','2019-05-13 17:02:49','0001-01-01 00:00:00',NULL);
/*!40000 ALTER TABLE `Articles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `__EFMigrationsHistory`
--

DROP TABLE IF EXISTS `__EFMigrationsHistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `__EFMigrationsHistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__EFMigrationsHistory`
--

LOCK TABLES `__EFMigrationsHistory` WRITE;
/*!40000 ALTER TABLE `__EFMigrationsHistory` DISABLE KEYS */;
INSERT INTO `__EFMigrationsHistory` VALUES ('20190411070353_intial','2.2.4-servicing-10062'),('20190411070508_SetSeed','2.2.4-servicing-10062'),('20190423094146_addSeed','2.2.4-servicing-10062'),('20190514054549_AddModifyTimieAndRemark','2.2.4-servicing-10062');
/*!40000 ALTER TABLE `__EFMigrationsHistory` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-05-23 15:33:57
