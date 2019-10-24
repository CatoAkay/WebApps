Løsningen bruker EnTur sin api for å søke etter stoppesteder/stasjoner. Finner faktiske togreiser og tider gjennom spørringer mot Vy sin api.

Vy logo er hentet fra Vy sine hjemmesider: https://www.vy.no/web-assets/favicons/favicon-512x512.png

Innlogging informasjon for admin (hovedadmin): 
Brukernavn: "admin"
Passord: "admin" 

Alle passord blir hashet i databasen. Alle endringer som admin/admins gjør i databasen, som endringer på reise,pris etc, vil loggføres i "Logging" tabell i databasen. 
Det er satt opp exception "catcher" der vi aksesserer databasen. Ved feil, skrives disse til fil med beskrivelse (C:\Logg\). 

For å teste programmet må man age en reise eller flere, deretter logge in som admin for å kunne manipulere disse. 

** Hvis programmet kræsjer grunnet CreateDatabaseIfNotExist -> slett filene i App_Data i prosjektmappen

@Sven Daneel, Cato Akay, Bao Duy Nguyen, Bjørnar Hoff