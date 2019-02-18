# AccentureCodeChallenge
e-Health Application aimed for user registration and unique QR code generator based on user profile.

# How to run the codes
1. Create sql database named PatientDB with table named Registration using the below sql query.

          CREATE DATABASE PatientDB;
          Go

          CREATE TABLE testing3.dbo.Registration(
              FirstName varchar(255),
              LastName varchar(255),
              Email varchar(255),Password varchar(255),
              Gender varchar(255),
              Birthday varchar(255),
              PhoneNo int,
              Address1 varchar(255),
              Address2 varchar(255),
              Postcode int, 
              State varchar(255));
              
2. It is important to create the database and table according to the given name.
3. Run the code as administrator. 
4. Manage Nuget on reference tab and install QRCoder.1.3.5  
5. On the app start by clicking Home button on right corner.
6. Once the code running, play around with the application and notice the interaction between each function.
