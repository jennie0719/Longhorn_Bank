using Microsoft.AspNetCore.Identity;



using Team3_FinalProject.Models;
using Team3_FinalProject.Utilities;
using Team3_FinalProject.DAL;


namespace Team3_FinalProject.Seeding
{
    public static class SeedUsers
    {
        public async static Task<IdentityResult> SeedAllUsers(UserManager<AppUser> userManager, AppDbContext context)
        {
            //Create a list of AddUserModels
            List<AddUserModel> AllUsers = new List<AddUserModel>();
            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "cbaker@freezing.co.uk",
                    Email = "cbaker@freezing.co.uk",
                    PhoneNumber = "5125571146",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Christopher",
                    MI = "L",
                    LastName = "Baker",
                    Disabled = false,
                    Address = "1245 Lake Austin Blvd.",
                    City = "Austin",
                    State = "TX",
                    ZipCode = 78733,
                    DOB = new DateTime(1991, 2, 7)

                },
                Password = "gazing",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "mb@aool.com",
                    Email = "mb@aool.com",
                    PhoneNumber = "2102678873",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Michelle",
                    MI = "",
                    LastName = "Banks",
                    Disabled = false,
                    Address = "1300 Tall Pine Lane",
                    City = "San Antonio",
                    State = "TX",
                    ZipCode = 78261,
                    DOB = new DateTime(1990, 6, 23)

                },
                Password = "banquet",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "fd@aool.com",
                    Email = "fd@aool.com",
                    PhoneNumber = "8175659699",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Franco",
                    MI = "V",
                    LastName = "Broccolo",
                    Disabled = false,
                    Address = "62 Browning Rd",
                    City = "Houston",
                    State = "TX",
                    ZipCode = 77019,
                    DOB = new DateTime(1986, 5, 6)

                },
                Password = "666666",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "wendy@ggmail.com",
                    Email = "wendy@ggmail.com",
                    PhoneNumber = "5125943222",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Wendy",
                    MI = "L",
                    LastName = "Chang",
                    Disabled = false,
                    Address = "202 Bellmont Hall",
                    City = "Austin",
                    State = "TX",
                    ZipCode = 78713,
                    DOB = new DateTime(1964, 12, 21)

                },
                Password = "clover",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "limchou@yaho.com",
                    Email = "limchou@yaho.com",
                    PhoneNumber = "2107724599",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Lim",
                    MI = "",
                    LastName = "Chou",
                    Disabled = false,
                    Address = "1600 Teresa Lane",
                    City = "San Antonio",
                    State = "TX",
                    ZipCode = 78266,
                    DOB = new DateTime(1964, 6, 14)

                },
                Password = "austin",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "Dixon@aool.com",
                    Email = "Dixon@aool.com",
                    PhoneNumber = "2142643255",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Shan",
                    MI = "D",
                    LastName = "Dixon",
                    Disabled = false,
                    Address = "234 Holston Circle",
                    City = "Dallas",
                    State = "TX",
                    ZipCode = 75208,
                    DOB = new DateTime(1990, 5, 9)

                },
                Password = "mailbox",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "louann@ggmail.com",
                    Email = "louann@ggmail.com",
                    PhoneNumber = "8172556749",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Lou Ann",
                    MI = "K",
                    LastName = "Feeley",
                    Disabled = false,
                    Address = "600 S 8th Street W",
                    City = "Houston",
                    State = "TX",
                    ZipCode = 77010,
                    DOB = new DateTime(1990, 2, 24)

                },
                Password = "aggies",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "tfreeley@minntonka.ci.state.mn.us",
                    Email = "tfreeley@minntonka.ci.state.mn.us",
                    PhoneNumber = "8173255687",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Tesa",
                    MI = "P",
                    LastName = "Freeley",
                    Disabled = false,
                    Address = "4448 Fairview Ave",
                    City = "Houston",
                    State = "TX",
                    ZipCode = 77009,
                    DOB = new DateTime(1935, 9, 1)

                },
                Password = "raiders",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "mgar@aool.com",
                    Email = "mgar@aool.com",
                    PhoneNumber = "8176593544",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Margaret",
                    MI = "L",
                    LastName = "Garcia",
                    Disabled = false,
                    Address = "594 Longview",
                    City = "Houston",
                    State = "TX",
                    ZipCode = 77003,
                    DOB = new DateTime(1990, 7, 3)

                },
                Password = "mustangs",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "chaley@thug.com",
                    Email = "chaley@thug.com",
                    PhoneNumber = "2148475583",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Charles",
                    MI = "E",
                    LastName = "Haley",
                    Disabled = false,
                    Address = "One Cowboy Pkwy",
                    City = "Dallas",
                    State = "TX",
                    ZipCode = 75261,
                    DOB = new DateTime(1985, 9, 17)

                },
                Password = "region",
                RoleName = "Customer"
            });


            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "jeff@ggmail.com",
                    Email = "jeff@ggmail.com",
                    PhoneNumber = "5126978613",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Jeffrey",
                    MI = "T",
                    LastName = "Hampton",
                    Disabled = false,
                    Address = "337 38th St.",
                    City = "Austin",
                    State = "TX",
                    ZipCode = 78705,
                    DOB = new DateTime(1995, 2, 23)

                },
                Password = "hungry",
                RoleName = "Customer"
            });


            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "wjhearniii@umch.edu",
                    Email = "wjhearniii@umch.edu",
                    PhoneNumber = "2148965621",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "John",
                    MI = "B",
                    LastName = "Hearn",
                    Disabled = false,
                    Address = "4225 North First",
                    City = "Dallas",
                    State = "TX",
                    ZipCode = 75237,
                    DOB = new DateTime(1994, 1, 8)

                },
                Password = "logicon",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "hicks43@ggmail.com",
                    Email = "hicks43@ggmail.com",
                    PhoneNumber = "2105788965",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Anthony",
                    MI = "J",
                    LastName = "Hicks",
                    Disabled = false,
                    Address = "32 NE Garden Ln., Ste 910",
                    City = "San Antonio",
                    State = "TX",
                    ZipCode = 78239,
                    DOB = new DateTime(1990, 10, 6)

                },
                Password = "doofus",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "bradsingram@mall.utexas.edu",
                    Email = "bradsingram@mall.utexas.edu",
                    PhoneNumber = "5124678821",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Brad",
                    MI = "S",
                    LastName = "Ingram",
                    Disabled = false,
                    Address = "6548 La Posada Ct.",
                    City = "Austin",
                    State = "TX",
                    ZipCode = 78736,
                    DOB = new DateTime(1984, 4, 12)

                },
                Password = "mother",
                RoleName = "Customer"
            });
            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "mother.Ingram@aool.com",
                    Email = "mother.Ingram@aool.com",
                    PhoneNumber = "5124653365",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Todd",
                    MI = "L",
                    LastName = "Jacobs",
                    Disabled = false,
                    Address = "4564 Elm St.",
                    City = "Austin",
                    State = "TX",
                    ZipCode = 78731,
                    DOB = new DateTime(1983, 4, 4)

                },
                Password = "whimsical",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "victoria@aool.com",
                    Email = "victoria@aool.com",
                    PhoneNumber = "5129457399",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Victoria",
                    MI = "M",
                    LastName = "Lawrence",
                    Disabled = false,
                    Address = "6639 Butterfly Ln.",
                    City = "Austin",
                    State = "TX",
                    ZipCode = 78761,
                    DOB = new DateTime(1961, 2, 3)

                },
                Password = "nothing",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "lineback@flush.net",
                    Email = "lineback@flush.net",
                    PhoneNumber = "2102449976",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Erik",
                    MI = "W",
                    LastName = "Lineback",
                    Disabled = false,
                    Address = "1300 Netherland St.",
                    City = "San Antonio",
                    State = "TX",
                    ZipCode = 78293,
                    DOB = new DateTime(1990, 9, 3)

                },
                Password = "GoodFellow",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "elowe@netscrape.net",
                    Email = "lelowe@netscrape.net",
                    PhoneNumber = "2105344627",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Ernest",
                    MI = "S",
                    LastName = "Lowe",
                    Disabled = false,
                    Address = "3201 Pine Drive",
                    City = "San Antonio",
                    State = "TX",
                    ZipCode = 78279,
                    DOB = new DateTime(1922, 2, 7)

                },
                Password = "impede",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "luce_chuck@ggmail.com",
                    Email = "luce_chuck@ggmail.com",
                    PhoneNumber = "2106983548",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Chuck",
                    MI = "B",
                    LastName = "Luce",
                    Disabled = false,
                    Address = "2345 Rolling Clouds",
                    City = "San Antonio",
                    State = "TX",
                    ZipCode = 78268,
                    DOB = new DateTime(1942, 10, 25)

                },
                Password = "LuceyDucey",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "mackcloud@pimpdaddy.com",
                    Email = "mackcloud@pimpdaddy.com",
                    PhoneNumber = "5124748138",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Jennifer",
                    MI = "D",
                    LastName = "MacLeod",
                    Disabled = false,
                    Address = "2504 Far West Blvd.",
                    City = "Austin",
                    State = "TX",
                    ZipCode = 78731,
                    DOB = new DateTime(1965, 8, 6)

                },
                Password = "cloudyday",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "liz@ggmail.com",
                    Email = "liz@ggmail.com",
                    PhoneNumber = "5124579845",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Elizabeth",
                    MI = "P",
                    LastName = "Markham",
                    Disabled = false,
                    Address = "7861 Chevy Chase",
                    City = "Austin",
                    State = "TX",
                    ZipCode = 78732,
                    DOB = new DateTime(1959, 4, 13)

                },
                Password = "emarkbark",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "mclarence@aool.com",
                    Email = "mclarence@aool.com",
                    PhoneNumber = "8174955201",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Clarence",
                    MI = "A",
                    LastName = "Martin",
                    Disabled = false,
                    Address = "87 Alcedo St.",
                    City = "Houston",
                    State = "TX",
                    ZipCode = 77045,
                    DOB = new DateTime(1990, 1, 6)

                },
                Password = "smartinmartin",
                RoleName = "Customer"
            });
            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "smartinmartin.Martin@aool.com",
                    Email = "smartinmartin.Martin@aool.com",
                    PhoneNumber = "8178746718",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Gregory",
                    MI = "R",
                    LastName = "Martinez",
                    Disabled = false,
                    Address = "8295 Sunset Blvd.",
                    City = "Houston",
                    State = "TX",
                    ZipCode = 77030,
                    DOB = new DateTime(1987, 10, 9)

                },
                Password = "looter",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "cmiller@mapster.com",
                    Email = "cmiller@mapster.com",
                    PhoneNumber = "8177458615",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Charles",
                    MI = "R",
                    LastName = "Miller",
                    Disabled = false,
                    Address = " 8962 Main St.",
                    City = "Houston",
                    State = "TX",
                    ZipCode = 77031,
                    DOB = new DateTime(1984, 7, 21)

                },
                Password = "chucky33",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "nelson.Kelly@aool.com",
                    Email = "nelson.Kelly@aool.com",
                    PhoneNumber = "5122926966",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Kelly",
                    MI = "T",
                    LastName = "Nelson",
                    Disabled = false,
                    Address = "2601 Red River",
                    City = "Austin",
                    State = "TX",
                    ZipCode = 78703,
                    DOB = new DateTime(1956, 7, 4)

                },
                Password = "orange",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "jojoe@ggmail.com",
                    Email = "jojoe@ggmail.com",
                    PhoneNumber = "2143125897",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Joe",
                    MI = "C",
                    LastName = "Nguyen",
                    Disabled = false,
                    Address = "1249 4th SW St.",
                    City = "Dallas",
                    State = "TX",
                    ZipCode = 75238,
                    DOB = new DateTime(1963, 1, 29)

                },
                Password = "victorious",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "orielly@foxnets.com",
                    Email = "orielly@foxnets.com",
                    PhoneNumber = "2103450925",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = " Bill",
                    MI = "T",
                    LastName = "O'Reilly",
                    Disabled = false,
                    Address = "8800 Gringo Drive",
                    City = "San Antonio",
                    State = "TX",
                    ZipCode = 78260,
                    DOB = new DateTime(1983, 1, 7)

                },
                Password = "billyboy",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "or@aool.com",
                    Email = "or@aool.com",
                    PhoneNumber = "2142345566",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Anka",
                    MI = "L",
                    LastName = "Radkovich",
                    Disabled = false,
                    Address = "1300 Elliott Pl",
                    City = "Dallas",
                    State = "TX",
                    ZipCode = 75260,
                    DOB = new DateTime(1980, 3, 31)

                },
                Password = "radicalone",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "megrhodes@freezing.co.uk",
                    Email = "megrhodes@freezing.co.uk",
                    PhoneNumber = "5123744746",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Megan",
                    MI = "C",
                    LastName = "Rhodes",
                    Disabled = false,
                    Address = "4587 Enfield Rd.",
                    City = "Austin",
                    State = "TX",
                    ZipCode = 78707,
                    DOB = new DateTime(1944, 8, 12)

                },
                Password = "gohorns",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "erynrice@aool.com",
                    Email = "erynrice@aool.com",
                    PhoneNumber = "5123876657",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Eryn",
                    MI = "M",
                    LastName = "Rice",
                    Disabled = false,
                    Address = "3405 Rio Grande",
                    City = "Austin",
                    State = "TX",
                    ZipCode = 78705,
                    DOB = new DateTime(1934, 8, 2)

                },
                Password = "iloveme",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "jorge@hootmail.com",
                    Email = "jorge@hootmail.com",
                    PhoneNumber = "8178904374",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Jorge",
                    MI = "",
                    LastName = "Rodriguez",
                    Disabled = false,
                    Address = "6788 Cotter Street",
                    City = "Houston",
                    State = "TX",
                    ZipCode = 77057,
                    DOB = new DateTime(1989, 8, 11)

                },
                Password = "greedy",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "ra@aoo.com",
                    Email = "ra@aoo.com",
                    PhoneNumber = "5128752943",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Allen",
                    MI = "B",
                    LastName = "Rogers",
                    Disabled = false,
                    Address = "4965 Oak HillAustin",
                    City = "Houston",
                    State = "TX",
                    ZipCode = 78732,
                    DOB = new DateTime(1967, 8, 27)

                },
                Password = "familiar",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "st-jean@home.com",
                    Email = "st-jean@home.com",
                    PhoneNumber = "2104145678",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Olivier",
                    MI = "M",
                    LastName = "Saint-Jean",
                    Disabled = false,
                    Address = "255 Toncray Dr.",
                    City = "San Antonio",
                    State = "TX",
                    ZipCode = 78292,
                    DOB = new DateTime(1950, 7, 8)

                },
                Password = "historical",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "ss34@ggmail.com",
                    Email = "ss34@ggmail.com",
                    PhoneNumber = "5123497810",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Sarah",
                    MI = "J",
                    LastName = "Saunders",
                    Disabled = false,
                    Address = "332 Avenue C",
                    City = "Austin",
                    State = "TX",
                    ZipCode = 78705,
                    DOB = new DateTime(1977, 10, 29)

                },
                Password = "guiltless",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "willsheff@email.com",
                    Email = "willsheff@email.com",
                    PhoneNumber = "5124510084",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "William",
                    MI = "T",
                    LastName = "Sewell",
                    Disabled = false,
                    Address = "2365 51st St.",
                    City = "Austin",
                    State = "TX",
                    ZipCode = 78709,
                    DOB = new DateTime(1941, 4, 21)

                },
                Password = "frequent",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "sheff44@ggmail.com",
                    Email = "sheff44@ggmail.com",
                    PhoneNumber = "5125479167",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Martin",
                    MI = "J",
                    LastName = "Sheffield",
                    Disabled = false,
                    Address = "3886 Avenue A",
                    City = "Austin",
                    State = "TX",
                    ZipCode = 78705,
                    DOB = new DateTime(1937, 11, 10)

                },
                Password = "history",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "johnsmith187@aool.com",
                    Email = "johnsmith187@aool.com",
                    PhoneNumber = "2108321888",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "John",
                    MI = "A",
                    LastName = "Smith",
                    Disabled = false,
                    Address = " 23 Hidden Forge Dr.",
                    City = "San Antonio",
                    State = "TX",
                    ZipCode = 78280,
                    DOB = new DateTime(1954, 10, 26)

                },
                Password = "squirrel",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "dustroud@mail.com",
                    Email = "dustroud@mail.com",
                    PhoneNumber = "2142346667",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Dustin",
                    MI = "P",
                    LastName = "Stroud",
                    Disabled = false,
                    Address = "1212 Rita Rd",
                    City = "Dallas",
                    State = "TX",
                    ZipCode = 75221,
                    DOB = new DateTime(1932, 9, 1)

                },
                Password = "snakes",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "ericstuart@aool.com",
                    Email = "ericstuart@aool.com",
                    PhoneNumber = "5128178335",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Eric",
                    MI = "D",
                    LastName = "Stuart",
                    Disabled = false,
                    Address = "5576 Toro Ring",
                    City = "Austin",
                    State = "TX",
                    ZipCode = 78746,
                    DOB = new DateTime(1938, 12, 28)

                },
                Password = "landus",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "peterstump@hootmail.com",
                    Email = "peterstump@hootmail.com",
                    PhoneNumber = "8174560903",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Peter",
                    MI = "L",
                    LastName = "Stump",
                    Disabled = false,
                    Address = "1300 Kellen Circle",
                    City = " Houston",
                    State = "TX",
                    ZipCode = 77018,
                    DOB = new DateTime(1989, 8, 13)

                },
                Password = "rhythm",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "tanner@ggmail.com",
                    Email = "tanner@ggmail.com",
                    PhoneNumber = "8174590929",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Jeremy",
                    MI = "S",
                    LastName = "Tanner",
                    Disabled = false,
                    Address = "4347 Almstead",
                    City = "Houston",
                    State = "TX",
                    ZipCode = 77044,
                    DOB = new DateTime(1982, 5, 21)

                },
                Password = "kindly",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "taylordjay@aool.com",
                    Email = "taylordjay@aool.com",
                    PhoneNumber = "5124748452",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Allison",
                    MI = "R",
                    LastName = "Taylor",
                    Disabled = false,
                    Address = "467 Nueces St.",
                    City = "Austin",
                    State = "TX",
                    ZipCode = 78705,
                    DOB = new DateTime(1960, 1, 8)

                },
                Password = "instrument",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "TayTaylor@aool.com",
                    Email = "TayTaylor@aool.com",
                    PhoneNumber = "5124512631",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Rachel",
                    MI = "K",
                    LastName = "Taylor",
                    Disabled = false,
                    Address = "345 Longview Dr.",
                    City = " Austin",
                    State = "TX",
                    ZipCode = 78705,
                    DOB = new DateTime(1975, 7, 27)

                },
                Password = "arched",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "teefrank@hootmail.com",
                    Email = "teefrank@hootmail.com",
                    PhoneNumber = "8178765543",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Frank",
                    MI = "J",
                    LastName = "Tee",
                    Disabled = false,
                    Address = "5590 Lavell Dr.",
                    City = " Houston",
                    State = "TX",
                    ZipCode = 77004,
                    DOB = new DateTime(1968, 4, 6)

                },
                Password = "median",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "tuck33@ggmail.com",
                    Email = "tuck33@ggmail.com",
                    PhoneNumber = "2148471154",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Clent",
                    MI = "J",
                    LastName = "Tucker",
                    Disabled = false,
                    Address = "312 Main St.",
                    City = "Dallas",
                    State = "TX",
                    ZipCode = 75315,
                    DOB = new DateTime(1978, 5, 19)

                },
                Password = "approval",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "avelasco@yaho.com",
                    Email = "avelasco@yaho.com",
                    PhoneNumber = "2143985638",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Allen",
                    MI = "G",
                    LastName = "Velasco",
                    Disabled = false,
                    Address = "679 W. 4th",
                    City = "Dallas",
                    State = "TX",
                    ZipCode = 75207,
                    DOB = new DateTime(1963, 6, 18)

                },
                Password = "decorate",
                RoleName = "Customer"
            });
            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "westj@pioneer.net",
                    Email = "westj@pioneer.net",
                    PhoneNumber = "2148475244",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Jake",
                    MI = "T",
                    LastName = "West",
                    Disabled = false,
                    Address = "RR 3287",
                    City = "Dallas",
                    State = "TX",
                    ZipCode = 75323,
                    DOB = new DateTime(1993, 10, 14)

                },
                Password = "grover",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "louielouie@aool.com",
                    Email = "louielouie@aool.com",
                    PhoneNumber = "2145650098",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Louis",
                    MI = "L",
                    LastName = "Winthorpe",
                    Disabled = false,
                    Address = "2500 Padre Blvd",
                    City = "Dallas",
                    State = "TX",
                    ZipCode = 75220,
                    DOB = new DateTime(1952, 5, 31)

                },
                Password = "sturdy",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "rwood@voyager.net",
                    Email = "rwood@voyager.net",
                    PhoneNumber = "5124545242",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Reagan",
                    MI = "B",
                    LastName = "Wood",
                    Disabled = false,
                    Address = "447 Westlake Dr.",
                    City = "Austin",
                    State = "TX",
                    ZipCode = 78746,
                    DOB = new DateTime(1992, 4, 24)

                },
                Password = "decorous",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "dman@wdwebsolutions.com",
                    Email = "dman@wdwebsolutions.com",
                    PhoneNumber = "5556409287",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Derek",
                    MI = "",
                    LastName = "Dreibrodt",
                    Disabled = false,
                    Address = "423 Brentwood Dr.",
                    City = "Austin",
                    State = "TX",
                    ZipCode = 78705,
                    DOB = new DateTime(2001, 1, 1)

                },
                Password = "nasus123",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "jman@outlook.com",
                    Email = "jman@outlook.com",
                    PhoneNumber = "5558471234",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Jacob",
                    MI = "",
                    LastName = "Foster",
                    Disabled = false,
                    Address = "700 Fancy St.",
                    City = "Austin",
                    State = "TX",
                    ZipCode = 78705,
                    DOB = new DateTime(2000, 9, 1)

                },
                Password = "pres4baseball",
                RoleName = "Customer"
            });
            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "t.jacobs@longhornbank.neet",
                    Email = "t.jacobs@longhornbank.neet",
                    PhoneNumber = "8176593544",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Todd",
                    MI = "L",
                    LastName = "Jacobs",
                    Disabled = false,
                    Address = "4564 Elm St.",
                    City = "Houston",
                    State = "TX",
                    ZipCode = 77003,
                    DOB = new DateTime(1999, 11, 11)

                },
                Password = "society",
                RoleName = "Employee"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "e.rice@longhornbank.neet",
                    Email = "e.rice@longhornbank.neet",
                    PhoneNumber = "2148475583",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Eryn",
                    MI = "M",
                    LastName = "Rice",
                    Disabled = false,
                    Address = "3405 Rio Grande",
                    City = "Dallas",
                    State = "TX",
                    ZipCode = 75261,
                    DOB = new DateTime(2000, 10, 20)

                },
                Password = "ricearoni",
                RoleName = "Employee"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "b.ingram@longhornbank.neet",
                    Email = "b.ingram@longhornbank.neet",
                    PhoneNumber = "5126978613",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Brad",
                    MI = "S",
                    LastName = "Ingram",
                    Disabled = false,
                    Address = "6548 La Posada Ct.",
                    City = "Austin",
                    State = "TX",
                    ZipCode = 78705,
                    DOB = new DateTime(1996, 1, 29)

                },
                Password = "ingram45",
                RoleName = "Employee"
            });
            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "a.taylor@longhornbank.neet",
                    Email = "a.taylor@longhornbank.neet",
                    PhoneNumber = "2148965621",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Allison",
                    MI = "R",
                    LastName = "Taylor",
                    Disabled = false,
                    Address = "467 Nueces St.",
                    City = "Dallas",
                    State = "TX",
                    ZipCode = 75237,
                    DOB = new DateTime(1989, 12, 24)

                },
                Password = "nostalgic",
                RoleName = "Admin"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "g.martinez@longhornbank.neet",
                    Email = "g.martinez@longhornbank.neet",
                    PhoneNumber = "2105788965",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Gregory",
                    MI = "R",
                    LastName = "Martinez",
                    Disabled = false,
                    Address = "8295 Sunset Blvd.",
                    City = "San Antonio",
                    State = "TX",
                    ZipCode = 78239,
                    DOB = new DateTime(1990, 9, 10)

                },
                Password = "fungus",
                RoleName = "Employee"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "m.sheffield@longhornbank.neet",
                    Email = "m.sheffield@longhornbank.neet",
                    PhoneNumber = "5124678821",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Martin",
                    MI = "J",
                    LastName = "Sheffield",
                    Disabled = false,
                    Address = "3886 Avenue A",
                    City = "Austin",
                    State = "TX",
                    ZipCode = 78736,
                    DOB = new DateTime(1998, 4, 19)

                },
                Password = "longhorns",
                RoleName = "Admin"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "j.macleod@longhornbank.neet",
                    Email = "j.macleod@longhornbank.neet",
                    PhoneNumber = "5124653365",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Jennifer",
                    MI = "D",
                    LastName = "MacLeod",
                    Disabled = false,
                    Address = "2504 Far West Blvd.",
                    City = "Austin",
                    State = "TX",
                    ZipCode = 78731,
                    DOB = new DateTime(1998, 4, 19)

                },
                Password = "smitty",
                RoleName = "Admin"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "j.tanner@longhornbank.neet",
                    Email = "j.tanner@longhornbank.neet",
                    PhoneNumber = "5129457399",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Jeremy",
                    MI = "S",
                    LastName = "Tanner",
                    Disabled = false,
                    Address = "4347 Almstead",
                    City = "Austin",
                    State = "TX",
                    ZipCode = 78761,
                    DOB = new DateTime(1997, 2, 23)

                },
                Password = "tanman",
                RoleName = "Employee"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "m.rhodes@longhornbank.neet",
                    Email = "m.rhodes@longhornbank.neet",
                    PhoneNumber = "2102449976",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Megan",
                    MI = "C",
                    LastName = "Rhodes",
                    Disabled = false,
                    Address = "4587 Enfield Rd.",
                    City = "San Antonio",
                    State = "TX",
                    ZipCode = 78293,
                    DOB = new DateTime(1978, 11, 24)

                },
                Password = "countryrhodes",
                RoleName = "Admin"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "e.stuart@longhornbank.neet",
                    Email = "e.stuart@longhornbank.neet",
                    PhoneNumber = "2105344627",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Eric",
                    MI = "F",
                    LastName = "Stuart",
                    Disabled = false,
                    Address = "5576 Toro Ring",
                    City = "San Antonio",
                    State = "TX",
                    ZipCode = 78279,
                    DOB = new DateTime(1993, 7, 4)

                },
                Password = "stewboy",
                RoleName = "Admin"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "l.chung@longhornbank.neet",
                    Email = "l.chung@longhornbank.neet",
                    PhoneNumber = "2106983548",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Lisa",
                    MI = "N",
                    LastName = "Chung",
                    Disabled = false,
                    Address = "234 RR 12",
                    City = "San Antonio",
                    State = "TX",
                    ZipCode = 78268,
                    DOB = new DateTime(1983, 8, 17)

                },
                Password = "lisssa",
                RoleName = "Employee"
            });

        

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "w.loter@longhornbank.neet",
                    Email = "w.loter@longhornbank.neet",
                    PhoneNumber = "5124579845",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Wanda",
                    MI = "K",
                    LastName = "Loter",
                    Disabled = false,
                    Address = "3453 RR 3235",
                    City = "Austin",
                    State = "TX",
                    ZipCode = 78732,
                    DOB = new DateTime(1988, 2, 14)

                },
                Password = "lottery",
                RoleName = "Employee"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "j.white@longhornbank.neet",
                    Email = "j.white@longhornbank.neet",
                    PhoneNumber = "8174955201",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Jason",
                    MI = "M",
                    LastName = "White",
                    Disabled = false,
                    Address = "12 Valley View",
                    City = "Houston",
                    State = "TX",
                    ZipCode = 77045,
                    DOB = new DateTime(1991, 12, 13)

                },
                Password = "evanescent",
                RoleName = "Admin"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "w.montgomery@longhornbank.neet",
                    Email = "w.montgomery@longhornbank.neet",
                    PhoneNumber = "8178746718",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Wilda",
                    MI = "K",
                    LastName = "Montgomery",
                    Disabled = false,
                    Address = "210 Blanco Dr",
                    City = "Houston",
                    State = "TX",
                    ZipCode = 77030,
                    DOB = new DateTime(1984, 10, 29)

                },
                Password = "monty3",
                RoleName = "Admin"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "h.morales@longhornbank.neet",
                    Email = "h.morales@longhornbank.neet",
                    PhoneNumber = "8177458615",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Hector",
                    MI = "N",
                    LastName = "Morales",
                    Disabled = false,
                    Address = "4501 RR 140",
                    City = "Houston",
                    State = "TX",
                    ZipCode = 77031,
                    DOB = new DateTime(1990, 10, 30)

                },
                Password = "hecktour",
                RoleName = "Employee"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "m.rankin@longhornbank.neet",
                    Email = "m.rankin@longhornbank.neet",
                    PhoneNumber = "5122926966",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Mary",
                    MI = "T",
                    LastName = "Rankin",
                    Address = "340 Second St",
                    Disabled = false,
                    City = "Austin",
                    State = "TX",
                    ZipCode = 78703,
                    DOB = new DateTime(1978, 7, 18)

                },
                Password = "rankmary",
                RoleName = "Employee"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "l.walker@longhornbank.neet",
                    Email = "l.walker@longhornbank.neet",
                    PhoneNumber = "2143125897",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Larry",
                    MI = "G",
                    LastName = "Walker",
                    Disabled = false,
                    Address = "9 Bison Circle",
                    City = "Dallas",
                    State = "TX",
                    ZipCode = 75238,
                    DOB = new DateTime(1985, 5, 20)

                },
                Password = "walkamile",
                RoleName = "Admin"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "g.chang@longhornbank.neet",
                    Email = "g.chang@longhornbank.neet",
                    PhoneNumber = "2103450925",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "George",
                    MI = "M",
                    LastName = "Chang",
                    Disabled = false,
                    Address = "9003 Joshua St",
                    City = "San Antonio",
                    State = "TX",
                    ZipCode = 78260,
                    DOB = new DateTime(1975, 6, 22)

                },
                Password = "changalang",
                RoleName = "Admin"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "g.gonzalez@longhornbank.neet",
                    Email = "g.gonzalez@longhornbank.neet",
                    PhoneNumber = "2142345566",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Gwen",
                    MI = "J",
                    LastName = "Gonzalez",
                    Disabled = false,
                    Address = "103 Manor Rd",
                    City = "Dallas",
                    State = "TX",
                    ZipCode = 75260,
                    DOB = new DateTime(1997, 1, 12)

                },
                Password = "offbeat",
                RoleName = "Employee"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "dman@longhornbank.neet",
                    Email = "dman@longhornbank.neet",
                    PhoneNumber = "5556409287",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Derek",
                    MI = " ",
                    LastName = "Dreibrodt",
                    Disabled = false,
                    Address = "423 Brentwood Dr",
                    City = "Austin",
                    State = "TX",
                    ZipCode = 78705,
                    DOB = new DateTime(1984, 12, 19)

                },
                Password = "nasus123",
                RoleName = "Admin"
            });

          


















            //create flag to help with errors
            String errorFlag = "Start";

            //create an identity result
            IdentityResult result = new IdentityResult();
            //call the method to seed the user
            try
            {
                foreach (AddUserModel aum in AllUsers)
                {
                    errorFlag = aum.User.Email;
                    result = await Utilities.AddUser.AddUserWithRoleAsync(aum, userManager, context);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("There was a problem adding the user with email: " 
                    + errorFlag, ex);
            }

            return result;
        }
    }
}
