-- MySQL dump 10.13  Distrib 8.0.30, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: media_marker
-- ------------------------------------------------------
-- Server version	8.0.30

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `genre_types`
--

DROP TABLE IF EXISTS `genre_types`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `genre_types` (
  `genre_id` int NOT NULL AUTO_INCREMENT,
  `genre_name` varchar(80) NOT NULL,
  PRIMARY KEY (`genre_id`),
  UNIQUE KEY `genre_id_UNIQUE` (`genre_id`),
  UNIQUE KEY `genre_name_UNIQUE` (`genre_name`)
) ENGINE=InnoDB AUTO_INCREMENT=41 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `genre_types`
--

LOCK TABLES `genre_types` WRITE;
/*!40000 ALTER TABLE `genre_types` DISABLE KEYS */;
INSERT INTO `genre_types` VALUES (2,'action'),(29,'adventure'),(17,'animation'),(26,'beat-em-up'),(6,'biographical'),(3,'comedy'),(30,'comic'),(10,'detective fiction'),(33,'documentary'),(13,'drama'),(7,'educational'),(14,'fantasy'),(37,'fighting'),(28,'flight sim'),(21,'fps'),(25,'hack-and-slash'),(11,'historical fiction'),(8,'history'),(1,'horror'),(39,'jrpg'),(31,'manga'),(23,'mecha'),(34,'musical'),(12,'mystery'),(32,'non fiction'),(9,'philosophy'),(24,'platforming'),(40,'puzzle'),(5,'romance'),(19,'rpg'),(15,'science fiction'),(16,'short story'),(27,'stealth'),(22,'strategy'),(20,'survival'),(38,'third-person shooter'),(35,'thriller'),(4,'tragedy'),(36,'turn-based rpg'),(18,'western');
/*!40000 ALTER TABLE `genre_types` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-06-04 22:22:51
