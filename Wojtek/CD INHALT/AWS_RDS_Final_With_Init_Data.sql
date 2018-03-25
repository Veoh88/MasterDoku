USE [HarmonizationService]
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPaneCount' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vWaterPlantPropertyMapper'

GO
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPane1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vWaterPlantPropertyMapper'

GO
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPaneCount' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vWaterPlant'

GO
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPane1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vWaterPlant'

GO
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPaneCount' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vUnit'

GO
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPane1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vUnit'

GO
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPaneCount' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vTreatmentStepType'

GO
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPane1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vTreatmentStepType'

GO
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPaneCount' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vTreatmentStep'

GO
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPane1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vTreatmentStep'

GO
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPaneCount' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vSupplier'

GO
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPane1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vSupplier'

GO
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPaneCount' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vQualityIndicatorTypeMapping'

GO
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPane1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vQualityIndicatorTypeMapping'

GO
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPaneCount' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vQualityIndicatorType'

GO
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPane1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vQualityIndicatorType'

GO
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPaneCount' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vQualityIndicator'

GO
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPane1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vQualityIndicator'

GO
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPaneCount' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vPullSource'

GO
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPane1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vPullSource'

GO
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPaneCount' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vLocation'

GO
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPane1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vLocation'

GO
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPaneCount' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vCountry'

GO
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPane1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vCountry'

GO
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPaneCount' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vBlackList'

GO
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPane1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vBlackList'

GO
/****** Object:  StoredProcedure [dbo].[SetWaterPlantMapping]    Script Date: 25.03.2018 13:55:21 ******/
DROP PROCEDURE [dbo].[SetWaterPlantMapping]
GO
/****** Object:  StoredProcedure [dbo].[SetWaterPlant]    Script Date: 25.03.2018 13:55:21 ******/
DROP PROCEDURE [dbo].[SetWaterPlant]
GO
/****** Object:  StoredProcedure [dbo].[SetUnit]    Script Date: 25.03.2018 13:55:21 ******/
DROP PROCEDURE [dbo].[SetUnit]
GO
/****** Object:  StoredProcedure [dbo].[SetTreatmentStepType]    Script Date: 25.03.2018 13:55:21 ******/
DROP PROCEDURE [dbo].[SetTreatmentStepType]
GO
/****** Object:  StoredProcedure [dbo].[SetTreatmentStep]    Script Date: 25.03.2018 13:55:21 ******/
DROP PROCEDURE [dbo].[SetTreatmentStep]
GO
/****** Object:  StoredProcedure [dbo].[SetSupplier]    Script Date: 25.03.2018 13:55:21 ******/
DROP PROCEDURE [dbo].[SetSupplier]
GO
/****** Object:  StoredProcedure [dbo].[SetQualityIndicatorTypeMapping]    Script Date: 25.03.2018 13:55:21 ******/
DROP PROCEDURE [dbo].[SetQualityIndicatorTypeMapping]
GO
/****** Object:  StoredProcedure [dbo].[SetQualityIndicatorType]    Script Date: 25.03.2018 13:55:21 ******/
DROP PROCEDURE [dbo].[SetQualityIndicatorType]
GO
/****** Object:  StoredProcedure [dbo].[SetQualityIndicator]    Script Date: 25.03.2018 13:55:21 ******/
DROP PROCEDURE [dbo].[SetQualityIndicator]
GO
/****** Object:  StoredProcedure [dbo].[SetLocation]    Script Date: 25.03.2018 13:55:21 ******/
DROP PROCEDURE [dbo].[SetLocation]
GO
/****** Object:  StoredProcedure [dbo].[SetCountry]    Script Date: 25.03.2018 13:55:21 ******/
DROP PROCEDURE [dbo].[SetCountry]
GO
/****** Object:  StoredProcedure [dbo].[SetBlackList]    Script Date: 25.03.2018 13:55:21 ******/
DROP PROCEDURE [dbo].[SetBlackList]
GO
/****** Object:  View [dbo].[vPullSource]    Script Date: 25.03.2018 13:55:21 ******/
DROP VIEW [dbo].[vPullSource]
GO
/****** Object:  Table [dbo].[PullSource]    Script Date: 25.03.2018 13:55:21 ******/
DROP TABLE [dbo].[PullSource]
GO
/****** Object:  View [dbo].[vQualityIndicatorType]    Script Date: 25.03.2018 13:55:21 ******/
DROP VIEW [dbo].[vQualityIndicatorType]
GO
/****** Object:  View [dbo].[vCountry]    Script Date: 25.03.2018 13:55:21 ******/
DROP VIEW [dbo].[vCountry]
GO
/****** Object:  View [dbo].[vLocation]    Script Date: 25.03.2018 13:55:21 ******/
DROP VIEW [dbo].[vLocation]
GO
/****** Object:  View [dbo].[vSupplier]    Script Date: 25.03.2018 13:55:21 ******/
DROP VIEW [dbo].[vSupplier]
GO
/****** Object:  View [dbo].[vQualityIndicatorTypeMapping]    Script Date: 25.03.2018 13:55:21 ******/
DROP VIEW [dbo].[vQualityIndicatorTypeMapping]
GO
/****** Object:  Table [dbo].[QualityIndicatorMapping]    Script Date: 25.03.2018 13:55:21 ******/
DROP TABLE [dbo].[QualityIndicatorMapping]
GO
/****** Object:  View [dbo].[vUnit]    Script Date: 25.03.2018 13:55:21 ******/
DROP VIEW [dbo].[vUnit]
GO
/****** Object:  View [dbo].[vTreatmentStepType]    Script Date: 25.03.2018 13:55:21 ******/
DROP VIEW [dbo].[vTreatmentStepType]
GO
/****** Object:  View [dbo].[vWaterPlantPropertyMapper]    Script Date: 25.03.2018 13:55:21 ******/
DROP VIEW [dbo].[vWaterPlantPropertyMapper]
GO
/****** Object:  Table [dbo].[WaterPlantMapping]    Script Date: 25.03.2018 13:55:21 ******/
DROP TABLE [dbo].[WaterPlantMapping]
GO
/****** Object:  View [dbo].[vBlackList]    Script Date: 25.03.2018 13:55:21 ******/
DROP VIEW [dbo].[vBlackList]
GO
/****** Object:  Table [dbo].[Blacklist]    Script Date: 25.03.2018 13:55:21 ******/
DROP TABLE [dbo].[Blacklist]
GO
/****** Object:  View [dbo].[vQualityIndicator]    Script Date: 25.03.2018 13:55:21 ******/
DROP VIEW [dbo].[vQualityIndicator]
GO
/****** Object:  Table [dbo].[QualityIndicator]    Script Date: 25.03.2018 13:55:21 ******/
DROP TABLE [dbo].[QualityIndicator]
GO
/****** Object:  Table [dbo].[Unit]    Script Date: 25.03.2018 13:55:21 ******/
DROP TABLE [dbo].[Unit]
GO
/****** Object:  Table [dbo].[IndicatorType]    Script Date: 25.03.2018 13:55:21 ******/
DROP TABLE [dbo].[IndicatorType]
GO
/****** Object:  View [dbo].[vTreatmentStep]    Script Date: 25.03.2018 13:55:21 ******/
DROP VIEW [dbo].[vTreatmentStep]
GO
/****** Object:  Table [dbo].[TreatmentStepType]    Script Date: 25.03.2018 13:55:21 ******/
DROP TABLE [dbo].[TreatmentStepType]
GO
/****** Object:  Table [dbo].[TreatmentStep]    Script Date: 25.03.2018 13:55:21 ******/
DROP TABLE [dbo].[TreatmentStep]
GO
/****** Object:  View [dbo].[vWaterPlant]    Script Date: 25.03.2018 13:55:21 ******/
DROP VIEW [dbo].[vWaterPlant]
GO
/****** Object:  Table [dbo].[WaterPlant]    Script Date: 25.03.2018 13:55:21 ******/
DROP TABLE [dbo].[WaterPlant]
GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 25.03.2018 13:55:21 ******/
DROP TABLE [dbo].[Supplier]
GO
/****** Object:  Table [dbo].[Location]    Script Date: 25.03.2018 13:55:21 ******/
DROP TABLE [dbo].[Location]
GO
/****** Object:  Table [dbo].[Country]    Script Date: 25.03.2018 13:55:21 ******/
DROP TABLE [dbo].[Country]
GO
/****** Object:  User [wwtpAdmin]    Script Date: 25.03.2018 13:55:21 ******/
DROP USER [wwtpAdmin]
GO
USE [master]
GO
/****** Object:  Login [##MS_PolicyEventProcessingLogin##]    Script Date: 25.03.2018 13:55:21 ******/
DROP LOGIN [##MS_PolicyEventProcessingLogin##]
GO
/****** Object:  Login [##MS_PolicyTsqlExecutionLogin##]    Script Date: 25.03.2018 13:55:21 ******/
DROP LOGIN [##MS_PolicyTsqlExecutionLogin##]
GO
/****** Object:  Login [LP471\admin]    Script Date: 25.03.2018 13:55:21 ******/
DROP LOGIN [LP471\admin]
GO
/****** Object:  Login [NT SERVICE\SQLWriter]    Script Date: 25.03.2018 13:55:21 ******/
DROP LOGIN [NT SERVICE\SQLWriter]
GO
/****** Object:  Login [wwtpAdmin]    Script Date: 25.03.2018 13:55:21 ******/
DROP LOGIN [wwtpAdmin]
GO
/****** Object:  Database [HarmonizationService]    Script Date: 25.03.2018 13:55:21 ******/
DROP DATABASE [HarmonizationService]
GO
/****** Object:  Database [HarmonizationService]    Script Date: 25.03.2018 13:55:21 ******/
CREATE DATABASE [HarmonizationService]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HarmonizationService', FILENAME = N'D:\RDSDBDATA\DATA\HarmonizationService.mdf' , SIZE = 23616KB , MAXSIZE = UNLIMITED, FILEGROWTH = 10%)
 LOG ON 
( NAME = N'HarmonizationService_log', FILENAME = N'D:\RDSDBDATA\DATA\HarmonizationService_log.ldf' , SIZE = 199296KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [HarmonizationService] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HarmonizationService].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HarmonizationService] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HarmonizationService] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HarmonizationService] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HarmonizationService] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HarmonizationService] SET ARITHABORT OFF 
GO
ALTER DATABASE [HarmonizationService] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HarmonizationService] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HarmonizationService] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HarmonizationService] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HarmonizationService] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HarmonizationService] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HarmonizationService] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HarmonizationService] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HarmonizationService] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HarmonizationService] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HarmonizationService] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HarmonizationService] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HarmonizationService] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HarmonizationService] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HarmonizationService] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HarmonizationService] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HarmonizationService] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HarmonizationService] SET RECOVERY FULL 
GO
ALTER DATABASE [HarmonizationService] SET  MULTI_USER 
GO
ALTER DATABASE [HarmonizationService] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HarmonizationService] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HarmonizationService] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HarmonizationService] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [HarmonizationService] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [HarmonizationService] SET QUERY_STORE = OFF
GO
USE [HarmonizationService]
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
/* For security reasons the login is created disabled and with a random password. */
/****** Object:  Login [wwtpAdmin]    Script Date: 25.03.2018 13:55:21 ******/
CREATE LOGIN [wwtpAdmin] WITH PASSWORD=N'0x6R0hNJK2lX1AeQM28534qKb5YgiDGrSwLSvPxiZlY=', DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO
ALTER LOGIN [wwtpAdmin] DISABLE
GO
/****** Object:  Login [NT SERVICE\SQLWriter]    Script Date: 25.03.2018 13:55:21 ******/
CREATE LOGIN [NT SERVICE\SQLWriter] FROM WINDOWS WITH DEFAULT_DATABASE=[master]
GO
/****** Object:  Login [LP471\admin]    Script Date: 25.03.2018 13:55:21 ******/
CREATE LOGIN [LP471\admin] FROM WINDOWS WITH DEFAULT_DATABASE=[master]
GO
/* For security reasons the login is created disabled and with a random password. */
/****** Object:  Login [##MS_PolicyTsqlExecutionLogin##]    Script Date: 25.03.2018 13:55:21 ******/
CREATE LOGIN [##MS_PolicyTsqlExecutionLogin##] WITH PASSWORD=N'ehLXdi4ZTOIg4Is+wJ6buSEtBMt1JDf51k1GojdwxVU=', DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=ON
GO
ALTER LOGIN [##MS_PolicyTsqlExecutionLogin##] DISABLE
GO
/* For security reasons the login is created disabled and with a random password. */
/****** Object:  Login [##MS_PolicyEventProcessingLogin##]    Script Date: 25.03.2018 13:55:21 ******/
CREATE LOGIN [##MS_PolicyEventProcessingLogin##] WITH PASSWORD=N'2qpU78oKyR/w4D7TXu0H90Bn6/y8Y4wOcpy++5MBs0E=', DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=ON
GO
ALTER LOGIN [##MS_PolicyEventProcessingLogin##] DISABLE
GO
ALTER AUTHORIZATION ON DATABASE::[HarmonizationService] TO [LP471\admin]
GO
ALTER SERVER ROLE [sysadmin] ADD MEMBER [wwtpAdmin]
GO
ALTER SERVER ROLE [sysadmin] ADD MEMBER [NT SERVICE\SQLWriter]
GO
ALTER SERVER ROLE [sysadmin] ADD MEMBER [LP471\admin]
GO
USE [HarmonizationService]
GO
/****** Object:  User [wwtpAdmin]    Script Date: 25.03.2018 13:55:21 ******/
CREATE USER [wwtpAdmin] FOR LOGIN [wwtpAdmin] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [wwtpAdmin]
GO
GRANT VIEW ANY COLUMN ENCRYPTION KEY DEFINITION TO [public] AS [dbo]
GO
GRANT VIEW ANY COLUMN MASTER KEY DEFINITION TO [public] AS [dbo]
GO
GRANT CONNECT TO [wwtpAdmin] AS [dbo]
GO
/****** Object:  Table [dbo].[Country]    Script Date: 25.03.2018 13:55:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[CountryId] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL
) ON [PRIMARY]

GO
ALTER AUTHORIZATION ON [dbo].[Country] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[Location]    Script Date: 25.03.2018 13:55:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Location](
	[LocationId] [int] IDENTITY(1,1) NOT NULL,
	[CountryId] [int] NOT NULL,
	[Town] [nvarchar](50) NULL
) ON [PRIMARY]

GO
ALTER AUTHORIZATION ON [dbo].[Location] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 25.03.2018 13:55:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier](
	[SupplierId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL
) ON [PRIMARY]

GO
ALTER AUTHORIZATION ON [dbo].[Supplier] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[WaterPlant]    Script Date: 25.03.2018 13:55:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WaterPlant](
	[WaterPlantId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[LocationId] [int] NOT NULL,
	[SupplierId] [int] NOT NULL
) ON [PRIMARY]

GO
ALTER AUTHORIZATION ON [dbo].[WaterPlant] TO  SCHEMA OWNER 
GO
/****** Object:  View [dbo].[vWaterPlant]    Script Date: 25.03.2018 13:55:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vWaterPlant]
AS
SELECT        dbo.waterplant.WaterPlantId AS waterPlantId, dbo.waterplant.Name AS waterPlantName, dbo.waterplant.LocationId AS locationId, dbo.waterplant.SupplierId AS supplierId, dbo.supplier.Name AS supplierName, 
                         dbo.country.CountryId AS countryId, dbo.country.Name AS countryName, dbo.location.Town AS townName
FROM            dbo.waterplant INNER JOIN
                         dbo.supplier ON dbo.waterplant.SupplierId = dbo.supplier.SupplierId INNER JOIN
                         dbo.location ON dbo.waterplant.LocationId = dbo.location.LocationId INNER JOIN
                         dbo.country ON dbo.location.CountryId = dbo.country.CountryId


GO
ALTER AUTHORIZATION ON [dbo].[vWaterPlant] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[TreatmentStep]    Script Date: 25.03.2018 13:55:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TreatmentStep](
	[TreatmentStepId] [int] IDENTITY(1,1) NOT NULL,
	[WaterPlantId] [int] NOT NULL,
	[TreatmentStepTypeId] [int] NOT NULL
) ON [PRIMARY]

GO
ALTER AUTHORIZATION ON [dbo].[TreatmentStep] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[TreatmentStepType]    Script Date: 25.03.2018 13:55:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TreatmentStepType](
	[TreatmentStepTypeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL
) ON [PRIMARY]

GO
ALTER AUTHORIZATION ON [dbo].[TreatmentStepType] TO  SCHEMA OWNER 
GO
/****** Object:  View [dbo].[vTreatmentStep]    Script Date: 25.03.2018 13:55:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vTreatmentStep]
AS
SELECT        dbo.treatmentstep.TreatmentStepId AS treatmentStepId, dbo.treatmentstep.WaterPlantId AS waterPlantId, dbo.treatmentstep.TreatmentStepTypeId AS treatmentStepTypeId, dbo.waterplant.Name AS waterPlantName, 
                         dbo.waterplant.LocationId AS locationId, dbo.waterplant.SupplierId AS supplierId, dbo.treatmentsteptype.Name AS treatmentStepTypeName
FROM            dbo.treatmentstep INNER JOIN
                         dbo.treatmentsteptype ON dbo.treatmentstep.TreatmentStepTypeId = dbo.treatmentsteptype.TreatmentStepTypeId INNER JOIN
                         dbo.waterplant ON dbo.treatmentstep.WaterPlantId = dbo.waterplant.WaterPlantId


GO
ALTER AUTHORIZATION ON [dbo].[vTreatmentStep] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[IndicatorType]    Script Date: 25.03.2018 13:55:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IndicatorType](
	[IndicatorTypeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[DefaultUnitId] [int] NULL
) ON [PRIMARY]

GO
ALTER AUTHORIZATION ON [dbo].[IndicatorType] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[Unit]    Script Date: 25.03.2018 13:55:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Unit](
	[UnitId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL
) ON [PRIMARY]

GO
ALTER AUTHORIZATION ON [dbo].[Unit] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[QualityIndicator]    Script Date: 25.03.2018 13:55:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QualityIndicator](
	[QualityIndicatorId] [int] IDENTITY(1,1) NOT NULL,
	[WaterPlantId] [int] NULL,
	[TreatmentStepId] [int] NULL,
	[IndicatorTypeId] [int] NOT NULL,
	[Value] [float] NOT NULL,
	[TimeStamp] [datetime] NOT NULL,
	[UnitId] [int] NULL
) ON [PRIMARY]

GO
ALTER AUTHORIZATION ON [dbo].[QualityIndicator] TO  SCHEMA OWNER 
GO
/****** Object:  View [dbo].[vQualityIndicator]    Script Date: 25.03.2018 13:55:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vQualityIndicator]
AS
SELECT        dbo.QualityIndicator.QualityIndicatorId AS qualityIndicatorId, dbo.QualityIndicator.WaterPlantId AS waterPlantId, dbo.QualityIndicator.TreatmentStepId AS treatmentStepId, dbo.QualityIndicator.IndicatorTypeId AS indicatorTypeId, 
                         dbo.QualityIndicator.Value AS value, dbo.QualityIndicator.TimeStamp AS timeStamp, dbo.QualityIndicator.UnitId AS unitId, dbo.Unit.Name AS unitName, dbo.IndicatorType.Name AS indicatorName
FROM            dbo.QualityIndicator INNER JOIN
                         dbo.Unit ON dbo.QualityIndicator.UnitId = dbo.Unit.UnitId INNER JOIN
                         dbo.IndicatorType ON dbo.QualityIndicator.IndicatorTypeId = dbo.IndicatorType.IndicatorTypeId


GO
ALTER AUTHORIZATION ON [dbo].[vQualityIndicator] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[Blacklist]    Script Date: 25.03.2018 13:55:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Blacklist](
	[PropertyName] [nvarchar](50) NOT NULL
) ON [PRIMARY]

GO
ALTER AUTHORIZATION ON [dbo].[Blacklist] TO  SCHEMA OWNER 
GO
/****** Object:  View [dbo].[vBlackList]    Script Date: 25.03.2018 13:55:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vBlackList]
AS
SELECT        PropertyName AS propertyName
FROM            dbo.blacklist


GO
ALTER AUTHORIZATION ON [dbo].[vBlackList] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[WaterPlantMapping]    Script Date: 25.03.2018 13:55:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WaterPlantMapping](
	[WaterPlantId] [int] NOT NULL,
	[WaterPlantName] [nvarchar](50) NOT NULL,
	[MappedName] [nvarchar](50) NOT NULL
) ON [PRIMARY]

GO
ALTER AUTHORIZATION ON [dbo].[WaterPlantMapping] TO  SCHEMA OWNER 
GO
/****** Object:  View [dbo].[vWaterPlantPropertyMapper]    Script Date: 25.03.2018 13:55:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vWaterPlantPropertyMapper]
AS
SELECT        dbo.WaterPlantMapping.WaterPlantId AS waterPlantId, dbo.WaterPlantMapping.WaterPlantName AS nameOnWaterplant, dbo.WaterPlantMapping.MappedName AS realName, dbo.WaterPlant.Name AS waterPlantName, 
                         dbo.WaterPlant.LocationId AS locationId, dbo.WaterPlant.SupplierId AS supplierId
FROM            dbo.WaterPlantMapping INNER JOIN
                         dbo.WaterPlant ON dbo.WaterPlantMapping.WaterPlantId = dbo.WaterPlant.WaterPlantId


GO
ALTER AUTHORIZATION ON [dbo].[vWaterPlantPropertyMapper] TO  SCHEMA OWNER 
GO
/****** Object:  View [dbo].[vTreatmentStepType]    Script Date: 25.03.2018 13:55:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vTreatmentStepType]
AS
SELECT        TreatmentStepTypeId AS treatmentStepId, Name AS treatmentStepTypeName
FROM            dbo.TreatmentStepType


GO
ALTER AUTHORIZATION ON [dbo].[vTreatmentStepType] TO  SCHEMA OWNER 
GO
/****** Object:  View [dbo].[vUnit]    Script Date: 25.03.2018 13:55:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vUnit]
AS
SELECT        UnitId AS unitId, Name AS unitName
FROM            dbo.unit


GO
ALTER AUTHORIZATION ON [dbo].[vUnit] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[QualityIndicatorMapping]    Script Date: 25.03.2018 13:55:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QualityIndicatorMapping](
	[IndicatorTypeId] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL
) ON [PRIMARY]

GO
ALTER AUTHORIZATION ON [dbo].[QualityIndicatorMapping] TO  SCHEMA OWNER 
GO
/****** Object:  View [dbo].[vQualityIndicatorTypeMapping]    Script Date: 25.03.2018 13:55:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vQualityIndicatorTypeMapping]
AS
SELECT        dbo.QualityIndicatorMapping.Name AS indicatorAlias, dbo.Unit.Name AS unitName, dbo.IndicatorType.IndicatorTypeId AS indicatorTypeId, dbo.IndicatorType.Name AS indicatorName, 
                         dbo.IndicatorType.DefaultUnitId AS defaultUnitId
FROM            dbo.IndicatorType INNER JOIN
                         dbo.QualityIndicatorMapping ON dbo.IndicatorType.IndicatorTypeId = dbo.QualityIndicatorMapping.IndicatorTypeId INNER JOIN
                         dbo.Unit ON dbo.IndicatorType.DefaultUnitId = dbo.Unit.UnitId


GO
ALTER AUTHORIZATION ON [dbo].[vQualityIndicatorTypeMapping] TO  SCHEMA OWNER 
GO
/****** Object:  View [dbo].[vSupplier]    Script Date: 25.03.2018 13:55:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vSupplier]
AS
SELECT        SupplierId AS supplierId, Name AS name
FROM            dbo.Supplier


GO
ALTER AUTHORIZATION ON [dbo].[vSupplier] TO  SCHEMA OWNER 
GO
/****** Object:  View [dbo].[vLocation]    Script Date: 25.03.2018 13:55:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vLocation]
AS
SELECT        dbo.Location.LocationId AS locationId, dbo.Location.CountryId AS countryId, dbo.Location.Town AS town, dbo.Country.Name AS countryName
FROM            dbo.Location INNER JOIN
                         dbo.Country ON dbo.Location.CountryId = dbo.Country.CountryId


GO
ALTER AUTHORIZATION ON [dbo].[vLocation] TO  SCHEMA OWNER 
GO
/****** Object:  View [dbo].[vCountry]    Script Date: 25.03.2018 13:55:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vCountry]
AS
SELECT        CountryId AS countryId, Name AS name
FROM            dbo.Country


GO
ALTER AUTHORIZATION ON [dbo].[vCountry] TO  SCHEMA OWNER 
GO
/****** Object:  View [dbo].[vQualityIndicatorType]    Script Date: 25.03.2018 13:55:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vQualityIndicatorType]
AS
SELECT        dbo.IndicatorType.IndicatorTypeId AS indicatorTypeId, dbo.IndicatorType.Name AS indicatorName, dbo.IndicatorType.DefaultUnitId AS defaultUnitId, dbo.Unit.Name AS unitName
FROM            dbo.IndicatorType INNER JOIN
                         dbo.Unit ON dbo.IndicatorType.DefaultUnitId = dbo.Unit.UnitId


GO
ALTER AUTHORIZATION ON [dbo].[vQualityIndicatorType] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[PullSource]    Script Date: 25.03.2018 13:55:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PullSource](
	[PullSourceId] [int] IDENTITY(1,1) NOT NULL,
	[SourcePath] [nvarchar](100) NOT NULL,
	[WaterPlantId] [int] NULL,
	[TreatmentStepTypeId] [int] NULL,
	[QualityIndicatorTypeId] [int] NULL,
	[DataType] [nvarchar](10) NOT NULL
) ON [PRIMARY]

GO
ALTER AUTHORIZATION ON [dbo].[PullSource] TO  SCHEMA OWNER 
GO
/****** Object:  View [dbo].[vPullSource]    Script Date: 25.03.2018 13:55:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vPullSource]
AS
SELECT        PullSourceId AS pullSourceId, SourcePath AS sourcePath, WaterPlantId AS waterPlantId, TreatmentStepTypeId AS treatmentStepTypeId, QualityIndicatorTypeId AS qualityIndicatortypeId, DataType AS dataType
FROM            dbo.PullSource

GO
ALTER AUTHORIZATION ON [dbo].[vPullSource] TO  SCHEMA OWNER 
GO
INSERT [dbo].[Blacklist] ([PropertyName]) VALUES (N'Password')
INSERT [dbo].[Country] ([CountryId], [Name]) VALUES (1, N'England')
INSERT [dbo].[Country] ([CountryId], [Name]) VALUES (2, N'Scottland')
INSERT [dbo].[Country] ([CountryId], [Name]) VALUES (3, N'Wales')
INSERT [dbo].[Country] ([CountryId], [Name]) VALUES (4, N'DummyCountry')
SET IDENTITY_INSERT [dbo].[IndicatorType] ON 

INSERT [dbo].[IndicatorType] ([IndicatorTypeId], [Name], [DefaultUnitId]) VALUES (1, N'Temperature', 1)
INSERT [dbo].[IndicatorType] ([IndicatorTypeId], [Name], [DefaultUnitId]) VALUES (2, N'Pressure', 2)
INSERT [dbo].[IndicatorType] ([IndicatorTypeId], [Name], [DefaultUnitId]) VALUES (3, N'Liquid Level', 6)
INSERT [dbo].[IndicatorType] ([IndicatorTypeId], [Name], [DefaultUnitId]) VALUES (4, N'Gas Flow Rate', 6)
INSERT [dbo].[IndicatorType] ([IndicatorTypeId], [Name], [DefaultUnitId]) VALUES (5, N'Liquid Flow Rate', 6)
INSERT [dbo].[IndicatorType] ([IndicatorTypeId], [Name], [DefaultUnitId]) VALUES (6, N'pH', 6)
INSERT [dbo].[IndicatorType] ([IndicatorTypeId], [Name], [DefaultUnitId]) VALUES (7, N'Conductivity', 3)
INSERT [dbo].[IndicatorType] ([IndicatorTypeId], [Name], [DefaultUnitId]) VALUES (8, N'Biomass', 4)
INSERT [dbo].[IndicatorType] ([IndicatorTypeId], [Name], [DefaultUnitId]) VALUES (9, N'Nitrate', 4)
INSERT [dbo].[IndicatorType] ([IndicatorTypeId], [Name], [DefaultUnitId]) VALUES (10, N'Nitrogen Dioxide', 4)
INSERT [dbo].[IndicatorType] ([IndicatorTypeId], [Name], [DefaultUnitId]) VALUES (11, N'Ammonium', 4)
INSERT [dbo].[IndicatorType] ([IndicatorTypeId], [Name], [DefaultUnitId]) VALUES (12, N'Reduction Potential', 5)
INSERT [dbo].[IndicatorType] ([IndicatorTypeId], [Name], [DefaultUnitId]) VALUES (13, N'Calorimetry', 1)
INSERT [dbo].[IndicatorType] ([IndicatorTypeId], [Name], [DefaultUnitId]) VALUES (14, N'Volatile Fatty Acids', 4)
INSERT [dbo].[IndicatorType] ([IndicatorTypeId], [Name], [DefaultUnitId]) VALUES (15, N'Dissolved Oxygen', 4)
INSERT [dbo].[IndicatorType] ([IndicatorTypeId], [Name], [DefaultUnitId]) VALUES (16, N'Biological Oxygen Demand', 4)
INSERT [dbo].[IndicatorType] ([IndicatorTypeId], [Name], [DefaultUnitId]) VALUES (17, N'Total Organic Carbon', 4)
INSERT [dbo].[IndicatorType] ([IndicatorTypeId], [Name], [DefaultUnitId]) VALUES (18, N'TestQualityIndicator', 5)
SET IDENTITY_INSERT [dbo].[IndicatorType] OFF
SET IDENTITY_INSERT [dbo].[Location] ON 

INSERT [dbo].[Location] ([LocationId], [CountryId], [Town]) VALUES (1, 1, N'DummyTown1')
INSERT [dbo].[Location] ([LocationId], [CountryId], [Town]) VALUES (2, 2, N'MockTown')
INSERT [dbo].[Location] ([LocationId], [CountryId], [Town]) VALUES (3, 3, N'SomeTown')
INSERT [dbo].[Location] ([LocationId], [CountryId], [Town]) VALUES (4, 4, N'Anytown')
SET IDENTITY_INSERT [dbo].[Location] OFF
INSERT [dbo].[QualityIndicatorMapping] ([IndicatorTypeId], [Name]) VALUES (1, N'Temp')
INSERT [dbo].[QualityIndicatorMapping] ([IndicatorTypeId], [Name]) VALUES (4, N'GFR')
INSERT [dbo].[QualityIndicatorMapping] ([IndicatorTypeId], [Name]) VALUES (5, N'LFR')
INSERT [dbo].[QualityIndicatorMapping] ([IndicatorTypeId], [Name]) VALUES (8, N'Suspended Solids')
INSERT [dbo].[QualityIndicatorMapping] ([IndicatorTypeId], [Name]) VALUES (8, N'Total Suspended Solids')
INSERT [dbo].[QualityIndicatorMapping] ([IndicatorTypeId], [Name]) VALUES (8, N'TSS')
INSERT [dbo].[QualityIndicatorMapping] ([IndicatorTypeId], [Name]) VALUES (9, N'NO3')
INSERT [dbo].[QualityIndicatorMapping] ([IndicatorTypeId], [Name]) VALUES (9, N'NO_3')
INSERT [dbo].[QualityIndicatorMapping] ([IndicatorTypeId], [Name]) VALUES (10, N'NO2')
INSERT [dbo].[QualityIndicatorMapping] ([IndicatorTypeId], [Name]) VALUES (10, N'NO_2')
INSERT [dbo].[QualityIndicatorMapping] ([IndicatorTypeId], [Name]) VALUES (11, N'NH4')
INSERT [dbo].[QualityIndicatorMapping] ([IndicatorTypeId], [Name]) VALUES (11, N'NH_4')
INSERT [dbo].[QualityIndicatorMapping] ([IndicatorTypeId], [Name]) VALUES (12, N'ORP')
INSERT [dbo].[QualityIndicatorMapping] ([IndicatorTypeId], [Name]) VALUES (14, N'VFA')
INSERT [dbo].[QualityIndicatorMapping] ([IndicatorTypeId], [Name]) VALUES (15, N'DO')
INSERT [dbo].[QualityIndicatorMapping] ([IndicatorTypeId], [Name]) VALUES (16, N'BOD')
INSERT [dbo].[QualityIndicatorMapping] ([IndicatorTypeId], [Name]) VALUES (17, N'TOC')
INSERT [dbo].[QualityIndicatorMapping] ([IndicatorTypeId], [Name]) VALUES (18, N'TestQualityIndicatorALIAS')
SET IDENTITY_INSERT [dbo].[Supplier] ON 

INSERT [dbo].[Supplier] ([SupplierId], [Name]) VALUES (1, N'SomeSupplier')
INSERT [dbo].[Supplier] ([SupplierId], [Name]) VALUES (2, N'AnySupplier')
INSERT [dbo].[Supplier] ([SupplierId], [Name]) VALUES (3, N'MockSupplier')
INSERT [dbo].[Supplier] ([SupplierId], [Name]) VALUES (4, N'DummySupplier')
SET IDENTITY_INSERT [dbo].[Supplier] OFF
SET IDENTITY_INSERT [dbo].[TreatmentStepType] ON 

INSERT [dbo].[TreatmentStepType] ([TreatmentStepTypeId], [Name]) VALUES (1, N'Screening')
INSERT [dbo].[TreatmentStepType] ([TreatmentStepTypeId], [Name]) VALUES (2, N'Primary Treatment')
INSERT [dbo].[TreatmentStepType] ([TreatmentStepTypeId], [Name]) VALUES (3, N'Secondary Treatment')
INSERT [dbo].[TreatmentStepType] ([TreatmentStepTypeId], [Name]) VALUES (4, N'Tertiary Treatment')
INSERT [dbo].[TreatmentStepType] ([TreatmentStepTypeId], [Name]) VALUES (5, N'Sludge Treatment')
INSERT [dbo].[TreatmentStepType] ([TreatmentStepTypeId], [Name]) VALUES (6, N'Outgoing')
INSERT [dbo].[TreatmentStepType] ([TreatmentStepTypeId], [Name]) VALUES (7, N'TestTreatmentStepType')
SET IDENTITY_INSERT [dbo].[TreatmentStepType] OFF
SET IDENTITY_INSERT [dbo].[Unit] ON 

INSERT [dbo].[Unit] ([UnitId], [Name]) VALUES (1, N'C')
INSERT [dbo].[Unit] ([UnitId], [Name]) VALUES (2, N'Pa')
INSERT [dbo].[Unit] ([UnitId], [Name]) VALUES (3, N'S/m')
INSERT [dbo].[Unit] ([UnitId], [Name]) VALUES (4, N'mg/L')
INSERT [dbo].[Unit] ([UnitId], [Name]) VALUES (5, N'mV')
INSERT [dbo].[Unit] ([UnitId], [Name]) VALUES (6, N'-')
SET IDENTITY_INSERT [dbo].[Unit] OFF
SET IDENTITY_INSERT [dbo].[WaterPlant] ON 

INSERT [dbo].[WaterPlant] ([WaterPlantId], [Name], [LocationId], [SupplierId]) VALUES (1, N'Dummy WaterPlant', 1, 1)
INSERT [dbo].[WaterPlant] ([WaterPlantId], [Name], [LocationId], [SupplierId]) VALUES (2, N'Some WaterPlant', 2, 2)
INSERT [dbo].[WaterPlant] ([WaterPlantId], [Name], [LocationId], [SupplierId]) VALUES (3, N'A WaterPlant', 3, 3)
INSERT [dbo].[WaterPlant] ([WaterPlantId], [Name], [LocationId], [SupplierId]) VALUES (4, N'Mock WaterPlant', 4, 4)
INSERT [dbo].[WaterPlant] ([WaterPlantId], [Name], [LocationId], [SupplierId]) VALUES (5, N'TestWaterPlant', 1, 1)
SET IDENTITY_INSERT [dbo].[WaterPlant] OFF
INSERT [dbo].[WaterPlantMapping] ([WaterPlantId], [WaterPlantName], [MappedName]) VALUES (1, N'TreatmentStepsALIAS', N'TreatmentSteps')
/****** Object:  StoredProcedure [dbo].[SetBlackList]    Script Date: 25.03.2018 13:55:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SetBlackList]
	-- Add the parameters for the stored procedure here
	--           ([Name]
    --      ,[LocationId]
    --       ,[SupplierId])
	@propertyName nchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

INSERT INTO [dbo].[Blacklist]
           ([PropertyName])
     VALUES
           (@propertyName)
		   
END


GO
ALTER AUTHORIZATION ON [dbo].[SetBlackList] TO  SCHEMA OWNER 
GO
/****** Object:  StoredProcedure [dbo].[SetCountry]    Script Date: 25.03.2018 13:55:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SetCountry]
	-- Add the parameters for the stored procedure here
	--           ([Name]
    --      ,[LocationId]
    --       ,[SupplierId])
	@countryName nchar(50),
	@countryId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

INSERT INTO [dbo].[Country]
           ([Name]
           ,[CountryId])
     VALUES
           (@countryName
           ,@countryId)
		   
END


GO
ALTER AUTHORIZATION ON [dbo].[SetCountry] TO  SCHEMA OWNER 
GO
/****** Object:  StoredProcedure [dbo].[SetLocation]    Script Date: 25.03.2018 13:55:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SetLocation]
	-- Add the parameters for the stored procedure here
	--           ([Name]
    --      ,[LocationId]
    --       ,[SupplierId])
	@countryId int,
	@locationId int,
	@locationName nchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

INSERT INTO [dbo].[Location]
           ([CountryId]
           ,[LocationId]
		   ,[Town])
     VALUES
           (@countryId
           ,@locationId
		   ,@locationName)
		   
END


GO
ALTER AUTHORIZATION ON [dbo].[SetLocation] TO  SCHEMA OWNER 
GO
/****** Object:  StoredProcedure [dbo].[SetQualityIndicator]    Script Date: 25.03.2018 13:55:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SetQualityIndicator]
	-- Add the parameters for the stored procedure here
	--           ([Name]
    --      ,[LocationId]
    --       ,[SupplierId])
	@waterPlantId int,
	@treatmentStepId int,
	@indicatorTypeId int,
	@value float,
	@timeStamp datetime,
	@unitId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

INSERT INTO [dbo].[QualityIndicator]
           ([WaterPlantId]
           ,[TreatmentStepId]
		   ,[IndicatorTypeId]
		   ,[Value]
		   ,[TimeStamp]
		   ,[UnitId])
     VALUES
           (@waterPlantId
           ,@treatmentStepId
		   ,@indicatorTypeId
		   ,@value
		   ,@timeStamp
		   ,@unitId)
		   
END


GO
ALTER AUTHORIZATION ON [dbo].[SetQualityIndicator] TO  SCHEMA OWNER 
GO
/****** Object:  StoredProcedure [dbo].[SetQualityIndicatorType]    Script Date: 25.03.2018 13:55:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SetQualityIndicatorType]
	-- Add the parameters for the stored procedure here
	--           ([Name]
    --      ,[LocationId]
    --       ,[SupplierId])
	@typeName nchar(50),
	@defaultUnitId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

INSERT INTO [dbo].[IndicatorType]
           ([DefaultUnitId]
           ,[Name])
     VALUES
           (@typeName
           ,@defaultUnitId)
		   
END


GO
ALTER AUTHORIZATION ON [dbo].[SetQualityIndicatorType] TO  SCHEMA OWNER 
GO
/****** Object:  StoredProcedure [dbo].[SetQualityIndicatorTypeMapping]    Script Date: 25.03.2018 13:55:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SetQualityIndicatorTypeMapping]
	-- Add the parameters for the stored procedure here
	--           ([Name]
    --      ,[LocationId]
    --       ,[SupplierId])
	@indicatorTypeId int,
	@name nchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

INSERT INTO [dbo].[QualityIndicatorMapping]
           ([IndicatorTypeId]
           ,[Name])
     VALUES
           (@indicatorTypeId
           ,@name)
		   
END


GO
ALTER AUTHORIZATION ON [dbo].[SetQualityIndicatorTypeMapping] TO  SCHEMA OWNER 
GO
/****** Object:  StoredProcedure [dbo].[SetSupplier]    Script Date: 25.03.2018 13:55:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SetSupplier]
	-- Add the parameters for the stored procedure here
	--           ([Name]
    --      ,[LocationId]
    --       ,[SupplierId])
	@supplierId int,
	@name nchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

INSERT INTO [dbo].[Supplier]
           ([Name]
           ,[SupplierId])
     VALUES
           (@supplierId
           ,@name)
		   
END


GO
ALTER AUTHORIZATION ON [dbo].[SetSupplier] TO  SCHEMA OWNER 
GO
/****** Object:  StoredProcedure [dbo].[SetTreatmentStep]    Script Date: 25.03.2018 13:55:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SetTreatmentStep]
	-- Add the parameters for the stored procedure here
	--           ([Name]
    --      ,[LocationId]
    --       ,[SupplierId])
	@treatmentStepTypeId int,
	@waterPlantId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

INSERT INTO [dbo].[TreatmentStep]
           ([TreatmentStepTypeId]
		   ,[WaterPlantId])
     VALUES
           (@treatmentStepTypeId
           ,@waterPlantId)
		   
END


GO
ALTER AUTHORIZATION ON [dbo].[SetTreatmentStep] TO  SCHEMA OWNER 
GO
/****** Object:  StoredProcedure [dbo].[SetTreatmentStepType]    Script Date: 25.03.2018 13:55:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SetTreatmentStepType]
	-- Add the parameters for the stored procedure here
	--           ([Name]
    --      ,[LocationId]
    --       ,[SupplierId])
	@name nchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

INSERT INTO [dbo].[TreatmentStepType]
           ([Name])
     VALUES
           (@name
           )
		   
END


GO
ALTER AUTHORIZATION ON [dbo].[SetTreatmentStepType] TO  SCHEMA OWNER 
GO
/****** Object:  StoredProcedure [dbo].[SetUnit]    Script Date: 25.03.2018 13:55:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SetUnit]
	-- Add the parameters for the stored procedure here
	--           ([Name]
    --      ,[LocationId]
    --       ,[SupplierId])
	@name nchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

INSERT INTO [dbo].[Unit]
           ([Name])
     VALUES
           (@name
           )
		   
END


GO
ALTER AUTHORIZATION ON [dbo].[SetUnit] TO  SCHEMA OWNER 
GO
/****** Object:  StoredProcedure [dbo].[SetWaterPlant]    Script Date: 25.03.2018 13:55:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SetWaterPlant]
	-- Add the parameters for the stored procedure here
	--           ([Name]
    --      ,[LocationId]
    --       ,[SupplierId])
	@waterPlantName nchar(50),
	@locationId int,
	@supplierId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

INSERT INTO [dbo].[WaterPlant]
           ([Name]
           ,[LocationId]
           ,[SupplierId])
     VALUES
           (@waterPlantName
           ,@locationId
           ,@supplierId)
		   
END


GO
ALTER AUTHORIZATION ON [dbo].[SetWaterPlant] TO  SCHEMA OWNER 
GO
/****** Object:  StoredProcedure [dbo].[SetWaterPlantMapping]    Script Date: 25.03.2018 13:55:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SetWaterPlantMapping]
	-- Add the parameters for the stored procedure here
	--           ([Name]
    --      ,[LocationId]
    --       ,[SupplierId])
	@waterPlantId int,
	@waterPlantName nchar(50),
	@mappedName nchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

INSERT INTO [dbo].[WaterPlantMapping]
           ([WaterPlantId]
		   ,[WaterPlantName]
		   ,[MappedName])
     VALUES
           (@waterPlantId
           ,@waterPlantName
		   ,@mappedName)
		   
END


GO
ALTER AUTHORIZATION ON [dbo].[SetWaterPlantMapping] TO  SCHEMA OWNER 
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "blacklist"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 118
               Right = 205
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vBlackList'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vBlackList'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Country"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 128
               Right = 205
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vCountry'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vCountry'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Location"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 143
               Right = 237
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Country"
            Begin Extent = 
               Top = 6
               Left = 275
               Bottom = 102
               Right = 442
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vLocation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vLocation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "PullSource"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 248
            End
            DisplayFlags = 280
            TopColumn = 2
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vPullSource'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vPullSource'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "QualityIndicator"
            Begin Extent = 
               Top = 20
               Left = 376
               Bottom = 195
               Right = 560
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "Unit"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 102
               Right = 205
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "IndicatorType"
            Begin Extent = 
               Top = 18
               Left = 589
               Bottom = 131
               Right = 761
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 2220
         Alias = 900
         Table = 1605
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vQualityIndicator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vQualityIndicator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "IndicatorType"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 153
               Right = 229
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Unit"
            Begin Extent = 
               Top = 6
               Left = 267
               Bottom = 126
               Right = 434
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vQualityIndicatorType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vQualityIndicatorType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[36] 4[33] 2[13] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "IndicatorType"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 128
               Right = 210
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "QualityIndicatorMapping"
            Begin Extent = 
               Top = 6
               Left = 248
               Bottom = 102
               Right = 420
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Unit"
            Begin Extent = 
               Top = 114
               Left = 439
               Bottom = 263
               Right = 606
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1890
         Alias = 2490
         Table = 2220
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vQualityIndicatorTypeMapping'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vQualityIndicatorTypeMapping'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Supplier"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 123
               Right = 225
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vSupplier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vSupplier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "treatmentstep"
            Begin Extent = 
               Top = 26
               Left = 323
               Bottom = 139
               Right = 526
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "waterplant"
            Begin Extent = 
               Top = 11
               Left = 566
               Bottom = 141
               Right = 733
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "treatmentsteptype"
            Begin Extent = 
               Top = 29
               Left = 67
               Bottom = 151
               Right = 270
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1980
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vTreatmentStep'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vTreatmentStep'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "TreatmentStepType"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 102
               Right = 241
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vTreatmentStepType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vTreatmentStepType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "unit"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 102
               Right = 205
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vUnit'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vUnit'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "waterplant"
            Begin Extent = 
               Top = 5
               Left = 229
               Bottom = 135
               Right = 396
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "supplier"
            Begin Extent = 
               Top = 44
               Left = 15
               Bottom = 161
               Right = 182
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "location"
            Begin Extent = 
               Top = 6
               Left = 448
               Bottom = 119
               Right = 615
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "country"
            Begin Extent = 
               Top = 6
               Left = 653
               Bottom = 102
               Right = 820
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vWaterPlant'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vWaterPlant'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "WaterPlantMapping"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 146
               Right = 217
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "WaterPlant"
            Begin Extent = 
               Top = 6
               Left = 255
               Bottom = 158
               Right = 422
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 1740
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vWaterPlantPropertyMapper'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vWaterPlantPropertyMapper'
GO
USE [master]
GO
ALTER DATABASE [HarmonizationService] SET  READ_WRITE 
GO
