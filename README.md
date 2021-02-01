## E-voting-System-with-Asp.NET-MVC
An online voting system has been designed using encryption algorithms. MVC pattern was used in the ASP.Net project.

Most of the e-voting technologies found in the literature are based on cryptography. An e-voting system can be quite complex and requires multiple cryptographic methods,
these methods have different structures to suit different needs and characteristics. In this study, a web-based e-voting system has been developed that meets security requirements
by using various encryption algorithms.

![System](images/System.png)


**METHODOLOGY**

- A website that has both an interface for voters and an administration panel has been developed. Design department was established with HTML, CSS, JS and Bootstrap libraries.
- Entity Framework is used for operations such as CRUD processing on the system. Data was added with JQuery, a JS library.
- Voters' passwords used in system login are encrypted with Crypto Helpers and MD5 encryption helps encryption. The votes used were recorded in the database with the RSA encryption algorithm.
- Voter information, candidate information, ballot papers, election results are stored in a relational database.

- System Screenshots:

![Admin](images/Admin.png)

![VoteScreen](images/VoteScreen.png)

![Results](images/Results.png)

- Encrypted data in MsSQL Tables:

![admintable](images/admintable.png)

![VoteScreen](images/result.png)
