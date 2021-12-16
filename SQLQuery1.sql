/*Dette script opretter databasen*/
USE [master]
GO
/****** Object:  Database [MalgreTout]    Script Date: 16-12-2021 11:42:59 ******/
CREATE DATABASE [MalgreTout]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MalgreTout', FILENAME = N'C:\Users\malth\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\MalgreTout.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MalgreTout_log', FILENAME = N'C:\Users\malth\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\MalgreTout.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [MalgreTout] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MalgreTout].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MalgreTout] SET ANSI_NULL_DEFAULT ON 
GO
ALTER DATABASE [MalgreTout] SET ANSI_NULLS ON 
GO
ALTER DATABASE [MalgreTout] SET ANSI_PADDING ON 
GO
ALTER DATABASE [MalgreTout] SET ANSI_WARNINGS ON 
GO
ALTER DATABASE [MalgreTout] SET ARITHABORT ON 
GO
ALTER DATABASE [MalgreTout] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MalgreTout] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MalgreTout] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MalgreTout] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MalgreTout] SET CURSOR_DEFAULT  LOCAL 
GO
ALTER DATABASE [MalgreTout] SET CONCAT_NULL_YIELDS_NULL ON 
GO
ALTER DATABASE [MalgreTout] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MalgreTout] SET QUOTED_IDENTIFIER ON 
GO
ALTER DATABASE [MalgreTout] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MalgreTout] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MalgreTout] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MalgreTout] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MalgreTout] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MalgreTout] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MalgreTout] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MalgreTout] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MalgreTout] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MalgreTout] SET RECOVERY FULL 
GO
ALTER DATABASE [MalgreTout] SET  MULTI_USER 
GO
ALTER DATABASE [MalgreTout] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MalgreTout] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MalgreTout] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MalgreTout] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MalgreTout] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MalgreTout] SET QUERY_STORE = OFF
GO
USE [MalgreTout]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [MalgreTout]
GO
/****** Object:  Table [dbo].[NewAllUdleveringssted]    Script Date: 16-12-2021 11:43:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NewAllUdleveringssted](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [Person] [varchar](100) NOT NULL,
    [Tlf] [int] NOT NULL,
    [Mail] [varchar](100) NOT NULL,
    [Virksomhed] [varchar](100) NOT NULL,
    [Adresse] [varchar](100) NOT NULL,
    [Postnr] [int] NOT NULL,
    [Bynavn] [varchar](100) NOT NULL,
    PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    ) ON [PRIMARY]
    GO
    SET IDENTITY_INSERT [dbo].[NewAllUdleveringssted] ON

    INSERT [dbo].[NewAllUdleveringssted] ([Id], [Person], [Tlf], [Mail], [Virksomhed], [Adresse], [Postnr], [Bynavn]) VALUES (1, N'Svend Aage Larsen', 57935793, N'LandFritidBjerringbro@live.dk', N'Land & Fritid Bjerringbro', N'Jørgens Alle 33', 8850, N'Bjerringbro')
    INSERT [dbo].[NewAllUdleveringssted] ([Id], [Person], [Tlf], [Mail], [Virksomhed], [Adresse], [Postnr], [Bynavn]) VALUES (3, N'Camilla S. Jørgensen', 11223344, N'LandFritidBårse@live', N'Land & Fritid Bårse', N'Korndrevet 4, Bårse', 4720, N'Præstø')
    INSERT [dbo].[NewAllUdleveringssted] ([Id], [Person], [Tlf], [Mail], [Virksomhed], [Adresse], [Postnr], [Bynavn]) VALUES (4, N'Anette Alsner', 55667788, N'LandFritidGrenå@live.dk', N'Land & Fritid Grenå', N'Djurslandskajen 1', 8500, N'Grenå')
    INSERT [dbo].[NewAllUdleveringssted] ([Id], [Person], [Tlf], [Mail], [Virksomhed], [Adresse], [Postnr], [Bynavn]) VALUES (5, N'Nicholaj Simonsen ', 99001123, N'LandFritidHjørring@live.dk', N'Land & Fritid Hjørring', N'Johs. E Rasmussens Vej 1', 9800, N'Hjøring')
    INSERT [dbo].[NewAllUdleveringssted] ([Id], [Person], [Tlf], [Mail], [Virksomhed], [Adresse], [Postnr], [Bynavn]) VALUES (6, N'Nicholaj Simonsen ', 99001122, N'LandFritidHolstebro@live.dk', N'Land & Fritid Holstebro', N'Mads Bjerres Vej 2', 7500, N'Holstebro')
    INSERT [dbo].[NewAllUdleveringssted] ([Id], [Person], [Tlf], [Mail], [Virksomhed], [Adresse], [Postnr], [Bynavn]) VALUES (7, N'Ernst Bank Olesen', 13131214, N'LandFritidNrNebel@live.dk', N'Land & Fritid Nr. Nebel', N'Borkvej 63', 6830, N'Nr Nebel')
    INSERT [dbo].[NewAllUdleveringssted] ([Id], [Person], [Tlf], [Mail], [Virksomhed], [Adresse], [Postnr], [Bynavn]) VALUES (8, N'Ernst Bank Olesen', 33445567, N'LandFritidNrVium@live.dk', N'Land & Fritid Nr. Vium', N'Viumvej 42', 6920, N'Videbæk')
    INSERT [dbo].[NewAllUdleveringssted] ([Id], [Person], [Tlf], [Mail], [Virksomhed], [Adresse], [Postnr], [Bynavn]) VALUES (9, N'Lucia Olsen ', 87654321, N'LandFritidNkMors@live.dk', N'Land & Fritid Nykøbing Mors', N'Ringvejen 72', 7900, N'Nyk. Mors')
    INSERT [dbo].[NewAllUdleveringssted] ([Id], [Person], [Tlf], [Mail], [Virksomhed], [Adresse], [Postnr], [Bynavn]) VALUES (10, N'Nikolaj Linde Jensen ', 70708090, N'LandFritidOdder@live.dk', N'Land & Fritid Odder', N'Højmarksvej 1', 8300, N'Odder')
    INSERT [dbo].[NewAllUdleveringssted] ([Id], [Person], [Tlf], [Mail], [Virksomhed], [Adresse], [Postnr], [Bynavn]) VALUES (11, N'Maja Høgh', 80809070, N'LandFritidRanders@live.dk', N'Land & Fritid Randers', N'Lorentzgade 19', 8900, N'Randers')
    INSERT [dbo].[NewAllUdleveringssted] ([Id], [Person], [Tlf], [Mail], [Virksomhed], [Adresse], [Postnr], [Bynavn]) VALUES (12, N'Sofie K. Gundersen', 19198181, N'LandFritidLemvig@live.dk', N'Land & Fritid Rom, Lemvig', N'Overbyvej 4, Rom ', 7620, N'Lemvig')
    INSERT [dbo].[NewAllUdleveringssted] ([Id], [Person], [Tlf], [Mail], [Virksomhed], [Adresse], [Postnr], [Bynavn]) VALUES (13, N'Helle Jakobsen ', 11443322, N'LandFritidRudkøbing@live.dk', N'Land & Fritid Rudkøbing', N'Nørrebro 204', 5900, N'Rudkøbing')
    INSERT [dbo].[NewAllUdleveringssted] ([Id], [Person], [Tlf], [Mail], [Virksomhed], [Adresse], [Postnr], [Bynavn]) VALUES (14, N'Lenette Møller Ingvorsen', 11333224, N'LandFritidRødekro@live.dk', N'Land & Fritid Rødekro', N'Mjølsvej 60', 6230, N'Rødekro')
    INSERT [dbo].[NewAllUdleveringssted] ([Id], [Person], [Tlf], [Mail], [Virksomhed], [Adresse], [Postnr], [Bynavn]) VALUES (15, N'Keld Lund', 13131212, N'LandFritidSkive@live.dk', N'Land & Fritid Skive', N'Nordhavnsvej 10', 7800, N'Skive')
    INSERT [dbo].[NewAllUdleveringssted] ([Id], [Person], [Tlf], [Mail], [Virksomhed], [Adresse], [Postnr], [Bynavn]) VALUES (16, N'Frederik Riis ', 13131414, N'LandFritidSkjern@live.dk', N'Land & Fritid Skjern', N'Industrivej 33', 6900, N'Skjern')
    INSERT [dbo].[NewAllUdleveringssted] ([Id], [Person], [Tlf], [Mail], [Virksomhed], [Adresse], [Postnr], [Bynavn]) VALUES (17, N'Ninna Lønne Hansen', 12121121, N'LandFritidSkærbæk@live.dk', N'Land & Fritid Skærbæk', N'Industrivej 36', 6780, N'Skærbæk')
    INSERT [dbo].[NewAllUdleveringssted] ([Id], [Person], [Tlf], [Mail], [Virksomhed], [Adresse], [Postnr], [Bynavn]) VALUES (18, N'Helle Damsgaard', 12121123, N'LandFritidStagstrup@live.dk', N'Land & Fritid Stagstrup', N'Møgelvej 3, Stagstrup', 7752, N'Snedsted')
    INSERT [dbo].[NewAllUdleveringssted] ([Id], [Person], [Tlf], [Mail], [Virksomhed], [Adresse], [Postnr], [Bynavn]) VALUES (19, N'Tina Sievertsen', 12324567, N'LandFritidSundeved@live.dk', N'Land & Fritid Sundeved', N'Højsvej 1, Sundeved', 6400, N'Sønderborg')
    INSERT [dbo].[NewAllUdleveringssted] ([Id], [Person], [Tlf], [Mail], [Virksomhed], [Adresse], [Postnr], [Bynavn]) VALUES (20, N'Karsten Kærgård', 12413212, N'LandFritidSørup@live.dk', N'Land & Fritid Sørup', N'Hjedsbækvej 69, Sørup', 9530, N'Støvring')
    INSERT [dbo].[NewAllUdleveringssted] ([Id], [Person], [Tlf], [Mail], [Virksomhed], [Adresse], [Postnr], [Bynavn]) VALUES (21, N'Svend Aage Larsen', 31212312, N'LandFritidThisted@live.dk', N'Land & Fritid Thisted ', N'Tigervej 1', 7700, N'Thisted')
    INSERT [dbo].[NewAllUdleveringssted] ([Id], [Person], [Tlf], [Mail], [Virksomhed], [Adresse], [Postnr], [Bynavn]) VALUES (22, N'Anette Bang', 64552322, N'LandFritidVesterHassing@live.dk', N'Land & Fritid Vester Hassing', N'Aslundvej 42', 9310, N'Vodskov')
    INSERT [dbo].[NewAllUdleveringssted] ([Id], [Person], [Tlf], [Mail], [Virksomhed], [Adresse], [Postnr], [Bynavn]) VALUES (23, N'Lars Simonsen ', 32428742, N'LandFritidVrå@live.dk', N'Land & Fritid Vrå', N'Vestre Ringvej 21 ', 9760, N'Vrå ')
    INSERT [dbo].[NewAllUdleveringssted] ([Id], [Person], [Tlf], [Mail], [Virksomhed], [Adresse], [Postnr], [Bynavn]) VALUES (24, N'Bernhard Olesen', 12413213, N'LandFritidØlgod@live.dk', N'Land & Fritid Ølgod', N'Industrivej 11', 6870, N'Ølgod')
    INSERT [dbo].[NewAllUdleveringssted] ([Id], [Person], [Tlf], [Mail], [Virksomhed], [Adresse], [Postnr], [Bynavn]) VALUES (25, N'Annette K. Leerskov', 80809071, N'LandFritidÅbybro@live.dk', N'Land & Fritid Åbybro', N'Mølhavevej 7-9', 9440, N'Abybro')
    INSERT [dbo].[NewAllUdleveringssted] ([Id], [Person], [Tlf], [Mail], [Virksomhed], [Adresse], [Postnr], [Bynavn]) VALUES (26, N'Anne U. Jensen', 77889901, N'LandFritidAars@live.dk', N'Land & Fritid Aars', N'Nordvestvej 1', 9600, N'Års')
    INSERT [dbo].[NewAllUdleveringssted] ([Id], [Person], [Tlf], [Mail], [Virksomhed], [Adresse], [Postnr], [Bynavn]) VALUES (27, N'Lisa', 31212311, N'StHippolyt@live.dk', N'St. Hippolyt', N'Øgelundvej 7, Blåhøj', 7330, N'Brande')
    INSERT [dbo].[NewAllUdleveringssted] ([Id], [Person], [Tlf], [Mail], [Virksomhed], [Adresse], [Postnr], [Bynavn]) VALUES (28, N'Tina', 80809071, N'TIKARideudstyr@live.dk', N'TIKA Rideudstyr', N'Solbjerg Plantagevej 3', 6731, N'Tjæreborg')
    INSERT [dbo].[NewAllUdleveringssted] ([Id], [Person], [Tlf], [Mail], [Virksomhed], [Adresse], [Postnr], [Bynavn]) VALUES (29, N'Lars Andersen', 77889901, N'AbsoluteHorsetrucks@live.dk', N'Absolute Horsetrucks', N'Erhvervsparken 7', 9500, N'Hobro')
    INSERT [dbo].[NewAllUdleveringssted] ([Id], [Person], [Tlf], [Mail], [Virksomhed], [Adresse], [Postnr], [Bynavn]) VALUES (30, N'Lars Jensen', 77889902, N'VedstedMølle@live.dk', N'Vedsted Mølle', N'Tøndervej 31', 6500, N'Vojens')
    INSERT [dbo].[NewAllUdleveringssted] ([Id], [Person], [Tlf], [Mail], [Virksomhed], [Adresse], [Postnr], [Bynavn]) VALUES (31, N'Inger Marie Scavenius', 80809071, N'KlintholmApartments@live.dk', N'Klintholm Lake Apartments', N'Langebjergvej 1', 4791, N'Borre')
    INSERT [dbo].[NewAllUdleveringssted] ([Id], [Person], [Tlf], [Mail], [Virksomhed], [Adresse], [Postnr], [Bynavn]) VALUES (32, N'Phillip Vossen', 12121124, N'Equitron@live.dk', N'Equitron', N'Vestergade 3', 6823, N'Ansager')
    INSERT [dbo].[NewAllUdleveringssted] ([Id], [Person], [Tlf], [Mail], [Virksomhed], [Adresse], [Postnr], [Bynavn]) VALUES (33, N'Kongeaa Trailercenter', 31212315, N'ChevalLiberté@live.dk', N'Cheval Liberté', N'Stenbroallé 1-3', 6650, N'Brørup')
    INSERT [dbo].[NewAllUdleveringssted] ([Id], [Person], [Tlf], [Mail], [Virksomhed], [Adresse], [Postnr], [Bynavn]) VALUES (34, N'Midt Vest Trailers A/S', 12324568, N'ChevalLiberté@live.dk', N'Cheval Liberté', N'Sirvej 19', 7500, N'Holstebro')
    INSERT [dbo].[NewAllUdleveringssted] ([Id], [Person], [Tlf], [Mail], [Virksomhed], [Adresse], [Postnr], [Bynavn]) VALUES (35, N'Randers Trailer', 12121121, N'ChevalLibertéRanders@live.dk', N'Cheval Liberté', N'Platanvænget 18', 8990, N'Fårup')
    INSERT [dbo].[NewAllUdleveringssted] ([Id], [Person], [Tlf], [Mail], [Virksomhed], [Adresse], [Postnr], [Bynavn]) VALUES (36, N'jens kok', 13131211, N'Miljøfoder@live.dk', N'Miljøfoder A/S', N'Vognmagervej 21', 8800, N'Viborg')
    INSERT [dbo].[NewAllUdleveringssted] ([Id], [Person], [Tlf], [Mail], [Virksomhed], [Adresse], [Postnr], [Bynavn]) VALUES (37, N'Anette k', 77889902, N'EsbjergOmegns@live.dk', N'Esbjerg og Omegns Rideklub', N'Seljborg Kirkevej 30', 6710, N'Esbjerg')
    SET IDENTITY_INSERT [dbo].[NewAllUdleveringssted] OFF
    GO
    USE [master]
    GO
ALTER DATABASE [MalgreTout] SET  READ_WRITE 
GO
