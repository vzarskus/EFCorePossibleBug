# EFCorePossibleBug  
### EF Core possible bug reproduction mini project.  

**Prerequisites:**  
.NET 5.0  

Project uses an SQLite database. If you wish to inspect it, I recommend downloading DB Browser for SQLite https://sqlitebrowser.org/dl/

**Install dotnet-ef CLI if you do not have it already:**  
`dotnet tool install --global dotnet-ef` 

**Please follow these steps to reproduce the issue:**  
1. Run these commands:  
    `dotnet ef migrations add InitialMigration`  
    `dotnet ef database update`  
    `dotnet run` - this will insert one item into db.  
    The state of the *Offers* table should be:  

    | Id         | Score_Score |  
    |------------|-------------|  
    | *someGuid* | 14.0        |  
2. Comment out the code marked with "! Comment out (step 2)"  
3. Uncomment the code marked with "! Uncomment (step 3)".  
4. Run:  
    `dotnet ef migrations add ScoreComponents`  
    `dotnet ef database update`  
    The state of the *Offers* table should now be:  

    | Id         | Score_Score | Score_DeliveryTypeScore | Score_RandomScore | Score_RatingScore |  
    |------------|-------------|-------------------------|-------------------|-------------------|  
    | *someGuid* | 14.0        | NULL                    | NULL              | NULL              |  
5. Run `dotnet run` or debug the project and you should recieve the error resulting from the whole  
*Score* owned entity being **null**, although one of its properties *Score_Score* has value.  

This issue can be reproduced with any number of properties that have some value - as long as one of them is **null**,
the whole owned entity object is returned as **null**.