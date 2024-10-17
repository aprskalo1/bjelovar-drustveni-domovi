INSERT INTO CommunityCenters (Id, Name, Address, Settlement, Description, Capacity, Price, CreatedAt)
VALUES (NEWID(), 'Dom kulture Bjelovar', 'Trg Hrvatskih Branitelja 12', 'Bjelovar', 'Veliki dom za kulturna okupljanja u Bjelovaru', 200, 500.00, GETDATE()),
       (NEWID(), 'Gradska kuća Bjelovar', 'Ul. Ivana Gundulića 23', 'Bjelovar', 'Glavna gradska kuća za svečane događaje', 150, 300.00, GETDATE()),
       (NEWID(), 'Kulturni centar Stari Grad', 'Kralja Tomislava 5', 'Bjelovar', 'Centar za kulturne i umjetničke događaje u Starom Gradu', 250, 450.00, GETDATE()),
       (NEWID(), 'Društveni dom Borik', 'Borik 21', 'Bjelovar', 'Društveni dom u naselju Borik za sportske i kulturne aktivnosti', 180, 350.00, GETDATE()),
       (NEWID(), 'Kulturni dom Bilogora', 'Bilogorska ulica 9', 'Bjelovar', 'Dom na Bilogori za okupljanje lokalnih zajednica', 220, 400.00, GETDATE()),
       (NEWID(), 'Gradski centar Nova Rača', 'Nova Rača 14', 'Bjelovar', 'Gradski centar za događanja i manifestacije u Novoj Rači', 120, 300.00, GETDATE()),
       (NEWID(), 'Centar za mlade Bjelovar', 'Ul. Matice Hrvatske 17', 'Bjelovar', 'Moderno opremljeni centar za mlade', 100, 200.00, GETDATE()),
       (NEWID(), 'Dom sportova Bjelovar', 'Sportska 3', 'Bjelovar', 'Sportski centar s prostorima za kulturna događanja', 500, 800.00, GETDATE()),
       (NEWID(), 'Društveni centar Ždralovi', 'Ulica Ždralovi 25', 'Bjelovar', 'Društveni centar u naselju Ždralovi', 130, 250.00, GETDATE()),
       (NEWID(), 'Kulturni dom Rovišće', 'Rovišće 2A', 'Bjelovar', 'Dom za kulturne manifestacije u naselju Rovišće', 170, 320.00, GETDATE()),
       (NEWID(), 'Dom mladih Bjelovar', 'Ul. Alojzija Stepinca 19', 'Bjelovar', 'Dom mladih s modernim sadržajima za radionice', 200, 450.00, GETDATE()),
       (NEWID(), 'Gradski paviljon Bjelovar', 'Paviljonska 4', 'Bjelovar', 'Središnji gradski paviljon za kulturna događanja', 300, 600.00, GETDATE()),
       (NEWID(), 'Kulturni centar Korenovo', 'Korenovo 7', 'Bjelovar', 'Kulturni centar u naselju Korenovo', 150, 280.00, GETDATE()),
       (NEWID(), 'Društveni centar Gornje Plavnice', 'Plavnice 11', 'Bjelovar', 'Centar za društvene i kulturne aktivnosti', 140, 290.00, GETDATE()),
       (NEWID(), 'Gradski centar Veliko Trojstvo', 'Veliko Trojstvo 8', 'Bjelovar', 'Gradski centar u naselju Veliko Trojstvo', 160, 330.00, GETDATE()),
       (NEWID(), 'Dom kulture Centar', 'Ul. Petra Preradovića 10', 'Bjelovar', 'Glavni dom kulture u centru Bjelovara', 250, 500.00, GETDATE()),
       (NEWID(), 'Društveni centar Severin', 'Severin 15', 'Bjelovar', 'Društveni centar za lokalna okupljanja', 110, 210.00, GETDATE()),
       (NEWID(), 'Kulturni dom Sjever', 'Sjeverna ulica 4', 'Bjelovar', 'Kulturni dom u sjevernom dijelu grada', 180, 350.00, GETDATE()),
       (NEWID(), 'Dom zajednice Bjelovar', 'Zajednička ulica 6', 'Bjelovar', 'Dom za okupljanje lokalne zajednice', 220, 420.00, GETDATE()),
       (NEWID(), 'Kulturni centar Prgomelje', 'Prgomelje 12', 'Bjelovar', 'Centar za kulturne manifestacije u naselju Prgomelje', 130, 260.00, GETDATE());

-- More INSERTs can follow similar to the ones above for other community centers

DECLARE
@userId UNIQUEIDENTIFIER;
SET
@userId = '37428B7B-C778-431A-B9FD-0B17C7EFA711';

INSERT INTO Reservations (Id, UserId, CommunityCenterId, ReservationFrom, ReservationTo, ExpectedNumberOfPeople, AdditionalNotes, CreatedAt)
SELECT NEWID(),
       @userId,
       c.Id,
       DATEADD(DAY, FLOOR(RAND(CHECKSUM(NEWID())) * 30) - 15, GETDATE()),
       DATEADD(DAY, FLOOR(RAND(CHECKSUM(NEWID())) * 5) + 1, DATEADD(DAY, FLOOR(RAND(CHECKSUM(NEWID())) * 30) - 15, GETDATE())),
       FLOOR(RAND(CHECKSUM(NEWID())) * 100) + 10,
       'Rezervacija za lokalni događaj',
       GETDATE()
FROM (SELECT TOP 25 Id FROM CommunityCenters ORDER BY NEWID()) c;
