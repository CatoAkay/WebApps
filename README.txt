L�sningen bruker EnTur sin api for � s�ke etter stoppesteder/stasjoner. Finner faktiske togreiser og tider gjennom sp�rringer mot Vy sin api.

Vy logo er hentet fra Vy sine hjemmesider: https://www.vy.no/web-assets/favicons/favicon-512x512.png

Innlogging informasjon for admin (hovedadmin): 
Brukernavn: "admin"
Passord: "admin" 

Alle passord blir hashet i databasen. Alle endringer som admin/admins gj�r i databasen, som endringer p� reise,pris etc, vil loggf�res i "Logging" tabell i databasen. 
Det er satt opp exception "catcher" der vi aksesserer databasen. Ved feil, skrives disse til fil med beskrivelse (C:\Logg\). 

For � teste programmet m� man age en reise eller flere, deretter logge in som admin for � kunne manipulere disse. 

** Hvis programmet kr�sjer grunnet CreateDatabaseIfNotExist -> slett filene i App_Data i prosjektmappen

@Sven Daneel, Cato Akay, Bao Duy Nguyen, Bj�rnar Hoff