using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC5App.Models;
using PFE.Models;

namespace PFE.Data
{
    public class DbInitializer
    {
        public async Task InitializeAsync(ApplicationDbContext context)
        {
            if (int.Parse(Properties.Resources.ResourceManager.GetString("seed")) == 1)
            {
                context.Database.EnsureCreated();

                // User tags
                await CreateOrUpdateFeature(context, new Feature { Name = "Pizza" });
                await CreateOrUpdateFeature(context, new Feature { Name = "Hamburger" });
                await CreateOrUpdateFeature(context, new Feature { Name = "Hotdog" });

                await CreateOrUpdateFeature(context, new Feature { Name = "Rapport King" });
                await CreateOrUpdateFeature(context, new Feature { Name = "ETS" });
                await CreateOrUpdateFeature(context, new Feature { Name = "Last Semester" });

                await CreateOrUpdateFeature(context, new Feature { Name = "Finish Exam" });
                await CreateOrUpdateFeature(context, new Feature { Name = "Leaving Exam" });
                await CreateOrUpdateFeature(context, new Feature { Name = "Funny" });
                await CreateOrUpdateFeature(context, new Feature { Name = "ChemiNot" });

                await CreateOrUpdateFeature(context, new Feature { Name = "Tagging" }); // Only used for static tests


                await context.SaveChangesAsync();

                // User seed
                await CreateOrUpdateApplicationUser(context,
                    new ApplicationUser
                    {
                        Id = "f8954918-8232-49be-ba60-bc827f68114d",
                        AccessFailedCount = 0,
                        ConcurrencyStamp = "87568826-4200-48f1-9f5d-db010838af38",
                        Email = "test@test.com",
                        EmailConfirmed = true,
                        LockoutEnabled = true,
                        LockoutEnd = null,
                        NormalizedEmail = "TEST@TEST.COM",
                        NormalizedUserName = "TEST@TEST.COM",
                        PasswordHash = "AQAAAAEAACcQAAAAEOrEDB5St2FmnECAXPLHOfH9u6Ixk1ugI7qYGmQndjsBYQ+hvPiWiiuCnG2FKMC20g==",
                        PhoneNumber = null,
                        PhoneNumberConfirmed = false,
                        SecurityStamp = "858d03c4-7942-4dc5-abdb-8d1981d14463",
                        TwoFactorEnabled = false,
                        UserName = "test@test.com"
                    });

                await CreateOrUpdateApplicationUser(context,
                   new ApplicationUser
                   {
                       Id = "dd7c431a-cd78-42f2-bbf4-2f814b50fe97",
                       AccessFailedCount = 0,
                       ConcurrencyStamp = "ed1653a0-676e-47b5-b50e-ba6cd8b45152",
                       Email = "test1@test.com",
                       EmailConfirmed = true,
                       LockoutEnabled = true,
                       LockoutEnd = null,
                       NormalizedEmail = "TEST1@TEST.COM",
                       NormalizedUserName = "TEST1@TEST.COM",
                       PasswordHash = "AQAAAAEAACcQAAAAEOrEDB5St2FmnECAXPLHOfH9u6Ixk1ugI7qYGmQndjsBYQ+hvPiWiiuCnG2FKMC20g==",
                       PhoneNumber = null,
                       PhoneNumberConfirmed = false,
                       SecurityStamp = "a3aed994-5f9c-4ce5-97b1-1d5695383a0c",
                       TwoFactorEnabled = false,
                       UserName = "test1@test.com"
                   });

                await CreateOrUpdateApplicationUser(context,
                    new ApplicationUser
                    {
                        Id = "970de14c-a6cf-4887-b1d6-b40780c03782",
                        AccessFailedCount = 0,
                        ConcurrencyStamp = "de105995-79c2-4289-bdeb-03da4d4114dd",
                        Email = "test2@test.com",
                        EmailConfirmed = true,
                        LockoutEnabled = true,
                        LockoutEnd = null,
                        NormalizedEmail = "TEST2@TEST.COM",
                        NormalizedUserName = "TEST2@TEST.COM",
                        PasswordHash = "AQAAAAEAACcQAAAAECqHI4yfye21Bk8nhKr238OzxOgsfSkFUNAfF4Si5aS0R74tFq1w3LK8Ega9/VEQQQ==",
                        PhoneNumber = null,
                        PhoneNumberConfirmed = false,
                        SecurityStamp = "7cb2fbc6-5f22-4338-85ed-1615a5573e78",
                        TwoFactorEnabled = false,
                        UserName = "test2@test.com"
                    });

                await CreateOrUpdateApplicationUser(context,
                    new ApplicationUser
                    {
                        Id = "056ebb6b-589e-406e-be0f-bba4ddb6a21e",
                        AccessFailedCount = 0,
                        ConcurrencyStamp = "e9b85b35-540c-4873-8047-20e5f8c36e06",
                        Email = "test3@test.com",
                        EmailConfirmed = true,
                        LockoutEnabled = true,
                        LockoutEnd = null,
                        NormalizedEmail = "TEST3@TEST.COM",
                        NormalizedUserName = "TEST3@TEST.COM",
                        PasswordHash = "AQAAAAEAACcQAAAAEIVjNPFefBEMcFcrO5dnvMcUIuWMRkIDaLxnNz/LwI13bOonwWxMBGLU+gWaQ9VKnQ===",
                        PhoneNumber = null,
                        PhoneNumberConfirmed = false,
                        SecurityStamp = "da9f5e59-f0e5-4d68-8b0c-9b018c784eac",
                        TwoFactorEnabled = false,
                        UserName = "test3@test.com"
                    });

                await CreateOrUpdateApplicationUser(context,
                    new ApplicationUser
                    {
                        Id = "5a8815bb-c7d9-483d-ab3d-6f289fc0138f",
                        AccessFailedCount = 0,
                        ConcurrencyStamp = "175f9c73-ed19-415b-8f2d-4a914eaa6c4f",
                        Email = "test4@test.com",
                        EmailConfirmed = true,
                        LockoutEnabled = true,
                        LockoutEnd = null,
                        NormalizedEmail = "TEST4@TEST.COM",
                        NormalizedUserName = "TEST4@TEST.COM",
                        PasswordHash = "AQAAAAEAACcQAAAAEBwTAga0UqLk4CicIM9xI6bFGPl7VQjVb1LgoEh+1qwt39ogPsy1V6mjUJLyHzmH4A==",
                        PhoneNumber = null,
                        PhoneNumberConfirmed = false,
                        SecurityStamp = "48e66d47-f7b1-4c29-a7da-3d4c8415d65b",
                        TwoFactorEnabled = false,
                        UserName = "test4@test.com"
                    });

                await CreateOrUpdateApplicationUser(context,
                    new ApplicationUser
                    {
                        Id = "0d280c91-c2f6-47f4-990d-c554512d1d7e",
                        AccessFailedCount = 0,
                        ConcurrencyStamp = "d45efa36-639b-43a6-9d31-566c7402ff86",
                        Email = "test5@test.com",
                        EmailConfirmed = true,
                        LockoutEnabled = true,
                        LockoutEnd = null,
                        NormalizedEmail = "TEST5@TEST.COM",
                        NormalizedUserName = "TEST5@TEST.COM",
                        PasswordHash = "AQAAAAEAACcQAAAAELTKIYRZ1uTaPPStUcCAFdUeR+svrCo01ro390nA9snnygiNjF89VPa0ySOBeEg3ZA==",
                        PhoneNumber = null,
                        PhoneNumberConfirmed = false,
                        SecurityStamp = "fbb0f4ee-bba6-47b8-b63b-c1dee34af19c",
                        TwoFactorEnabled = false,
                        UserName = "test5@test.com"
                    });

                await CreateOrUpdateApplicationUser(context,
                    new ApplicationUser
                    {
                        Id = "5fd219cf-7cd4-48c5-8467-f2f8caf5b7f9",
                        AccessFailedCount = 0,
                        ConcurrencyStamp = "d32be407-7ba0-4ed2-9843-616564d20b936",
                        Email = "test6@test.com",
                        EmailConfirmed = true,
                        LockoutEnabled = true,
                        LockoutEnd = null,
                        NormalizedEmail = "TEST6@TEST.COM",
                        NormalizedUserName = "TEST6@TEST.COM",
                        PasswordHash = "AQAAAAEAACcQAAAAEGLyG2SAAEln4988EGrvcCYtJC+pziM4MvrRGsdw/FZk9qTapkNA1FPXPKuw+xyATw==",
                        PhoneNumber = null,
                        PhoneNumberConfirmed = false,
                        SecurityStamp = "0bbdff02-c899-4d77-aff3-f7343d20aa00",
                        TwoFactorEnabled = false,
                        UserName = "test6@test.com"
                    });

                await CreateOrUpdateApplicationUser(context,
                    new ApplicationUser
                    {
                        Id = "7c4b0f8b-69fa-4a65-b47b-0fbff5e74d95",
                        AccessFailedCount = 0,
                        ConcurrencyStamp = "1cd2b267-a790-4eff-a306-9b1d9bcc6db2",
                        Email = "test7@test.com",
                        EmailConfirmed = true,
                        LockoutEnabled = true,
                        LockoutEnd = null,
                        NormalizedEmail = "TEST7@TEST.COM",
                        NormalizedUserName = "TEST7@TEST.COM",
                        PasswordHash = "AQAAAAEAACcQAAAAEIOvx20uWLNPLLkMgnaKoK4YgR4pejLHOAKJYmTF1d67ESPR/vaK3K3goqzzFbnCmA==",
                        PhoneNumber = null,
                        PhoneNumberConfirmed = false,
                        SecurityStamp = "789dddf4-af5f-4074-933c-fab2952d9426",
                        TwoFactorEnabled = false,
                        UserName = "test7@test.com"
                    });

                await CreateOrUpdateApplicationUser(context,
                    new ApplicationUser
                    {
                        Id = "0b33c048-ee5b-4cbc-808c-e7040a6c69f5",
                        AccessFailedCount = 0,
                        ConcurrencyStamp = "80dbaac8-fb30-4833-ad37-b9755ee4f1a1",
                        Email = "test8@test.com",
                        EmailConfirmed = true,
                        LockoutEnabled = true,
                        LockoutEnd = null,
                        NormalizedEmail = "TEST8@TEST.COM",
                        NormalizedUserName = "TEST8@TEST.COM",
                        PasswordHash = "AQAAAAEAACcQAAAAEF+Re3b415Ik5z76Vb/sQ1vs6BXvn5VQqSc0lCttj3IJuIKUnW8heWXKVF4C5NiQnw==",
                        PhoneNumber = null,
                        PhoneNumberConfirmed = false,
                        SecurityStamp = "148b32bd-942d-4a6c-9a70-9d82eaf7fd64",
                        TwoFactorEnabled = false,
                        UserName = "test8@test.com"
                    });

                await CreateOrUpdateApplicationUser(context,
                    new ApplicationUser
                    {
                        Id = "8546db10-ea48-4ea8-b317-312436120f1c",
                        AccessFailedCount = 0,
                        ConcurrencyStamp = "c11f7aac-1c66-4b77-8855-ac6a531e61a1",
                        Email = "test9@test.com",
                        EmailConfirmed = true,
                        LockoutEnabled = true,
                        LockoutEnd = null,
                        NormalizedEmail = "TEST9@TEST.COM",
                        NormalizedUserName = "TEST9@TEST.COM",
                        PasswordHash = "AQAAAAEAACcQAAAAEIKX2xX/TKAKRqL82HzyhzN35ybguLaSx1VZEsAqVdcrZGNEWKB1SNW146AoWdX5RQ==",
                        PhoneNumber = null,
                        PhoneNumberConfirmed = false,
                        SecurityStamp = "78151141-ada8-4566-a2a9-aea8ae3a4b6a",
                        TwoFactorEnabled = false,
                        UserName = "test9@test.com"
                    });

                await CreateOrUpdateApplicationUser(context,
                    new ApplicationUser
                    {
                        Id = "7424c99f-9955-49be-8a02-608d3cf7f2bc",
                        AccessFailedCount = 0,
                        ConcurrencyStamp = "6dee39cd-a9c7-4286-9f7c-0fa297e9d8ff",
                        Email = "test10@test.com",
                        EmailConfirmed = true,
                        LockoutEnabled = true,
                        LockoutEnd = null,
                        NormalizedEmail = "TEST10@TEST.COM",
                        NormalizedUserName = "TEST10@TEST.COM",
                        PasswordHash = "AQAAAAEAACcQAAAAEMpEZKxPk1rTlW8iX/uF684IJ8YvRFVqf20h4hsGFDyESohdPXq+nFHzz9CyTqeeGg==",
                        PhoneNumber = null,
                        PhoneNumberConfirmed = false,
                        SecurityStamp = "02285b0e-b323-4ad4-980b-da6bc738bed4",
                        TwoFactorEnabled = false,
                        UserName = "test10@test.com"
                    });

                await context.SaveChangesAsync();

                Random gen = new Random();

                DateTime start = new DateTime(2010, 1, 1);
                int range = (DateTime.Today - start).Days;
                DateTime newDate = start.AddDays(gen.Next(range));

                // PdfAscquisition seed
                await CreateOrUpdatePdfAcquisition(context,
                    new PdfAcquisition
                    {
                        PdfId = 1,
                        UserId = "dd7c431a-cd78-42f2-bbf4-2f814b50fe97",
                        AcquisitionDate = newDate,
                        Price = 1.99
                    });


                newDate = start.AddDays(gen.Next(range));

                await CreateOrUpdatePdfAcquisition(context,
                    new PdfAcquisition
                    {
                        PdfId = 1,
                        UserId = "7424c99f-9955-49be-8a02-608d3cf7f2bc",
                        AcquisitionDate = newDate,
                        Price = 1.99
                    });

                newDate = start.AddDays(gen.Next(range));

                await CreateOrUpdatePdfAcquisition(context,
                    new PdfAcquisition
                    {
                        PdfId = 1,
                        UserId = "970de14c-a6cf-4887-b1d6-b40780c03782",
                        AcquisitionDate = newDate,
                        Price = 1.99
                    });

                newDate = start.AddDays(gen.Next(range));

                await CreateOrUpdatePdfAcquisition(context,
                    new PdfAcquisition
                    {
                        PdfId = 1,
                        UserId = "056ebb6b-589e-406e-be0f-bba4ddb6a21e",
                        AcquisitionDate = newDate,
                        Price = 1.99
                    });

                newDate = start.AddDays(gen.Next(range));

                await CreateOrUpdatePdfAcquisition(context,
                    new PdfAcquisition
                    {
                        PdfId = 1,
                        UserId = "5a8815bb-c7d9-483d-ab3d-6f289fc0138f",
                        AcquisitionDate = newDate,
                        Price = 1.99
                    });

                newDate = start.AddDays(gen.Next(range));

                await CreateOrUpdatePdfAcquisition(context,
                    new PdfAcquisition
                    {
                        PdfId = 1,
                        UserId = "0d280c91-c2f6-47f4-990d-c554512d1d7e",
                        AcquisitionDate = newDate,
                        Price = 1.99
                    });

                newDate = start.AddDays(gen.Next(range));

                await CreateOrUpdatePdfAcquisition(context,
                    new PdfAcquisition
                    {
                        PdfId = 1,
                        UserId = "8546db10-ea48-4ea8-b317-312436120f1c",
                        AcquisitionDate = newDate,
                        Price = 1.99
                    });

                newDate = start.AddDays(gen.Next(range));

                await CreateOrUpdatePdfAcquisition(context,
                    new PdfAcquisition
                    {
                        PdfId = 1,
                        UserId = "0b33c048-ee5b-4cbc-808c-e7040a6c69f5",
                        AcquisitionDate = newDate,
                        Price = 1.99
                    });

                newDate = start.AddDays(gen.Next(range));

                await CreateOrUpdatePdfAcquisition(context,
                    new PdfAcquisition
                    {
                        PdfId = 1,
                        UserId = "7c4b0f8b-69fa-4a65-b47b-0fbff5e74d95",
                        AcquisitionDate = newDate,
                        Price = 1.99
                    });

                newDate = start.AddDays(gen.Next(range));

                await CreateOrUpdatePdfAcquisition(context,
                    new PdfAcquisition
                    {
                        PdfId = 1,
                        UserId = "5fd219cf-7cd4-48c5-8467-f2f8caf5b7f9",
                        AcquisitionDate = newDate,
                        Price = 1.99
                    });

                newDate = start.AddDays(gen.Next(range));

                await CreateOrUpdatePdfAcquisition(context,
                    new PdfAcquisition
                    {
                        PdfId = 2,
                        UserId = "f8954918-8232-49be-ba60-bc827f68114d",
                        AcquisitionDate = newDate,
                        Price = 10.99
                    });

                newDate = start.AddDays(gen.Next(range));


                await CreateOrUpdatePdfAcquisition(context,
                    new PdfAcquisition
                    {
                        PdfId = 2,
                        UserId = "970de14c-a6cf-4887-b1d6-b40780c03782",
                        AcquisitionDate = newDate,
                        Price = 10.99
                    });

                newDate = start.AddDays(gen.Next(range));


                await CreateOrUpdatePdfAcquisition(context,
                    new PdfAcquisition
                    {
                        PdfId = 2,
                        UserId = "5a8815bb-c7d9-483d-ab3d-6f289fc0138f",
                        AcquisitionDate = newDate,
                        Price = 10.99
                    });

                newDate = start.AddDays(gen.Next(range));


                await CreateOrUpdatePdfAcquisition(context,
                    new PdfAcquisition
                    {
                        PdfId = 2,
                        UserId = "5fd219cf-7cd4-48c5-8467-f2f8caf5b7f9",
                        AcquisitionDate = newDate,
                        Price = 10.99
                    });

                newDate = start.AddDays(gen.Next(range));

                await CreateOrUpdatePdfAcquisition(context,
                    new PdfAcquisition
                    {
                        PdfId = 3,
                        UserId = "f8954918-8232-49be-ba60-bc827f68114d",
                        AcquisitionDate = newDate,
                        Price = 18.99
                    });

                newDate = start.AddDays(gen.Next(range));

                await CreateOrUpdatePdfAcquisition(context,
                     new PdfAcquisition
                     {
                         PdfId = 3,
                         UserId = "dd7c431a-cd78-42f2-bbf4-2f814b50fe97",
                         AcquisitionDate = newDate,
                         Price = 18.99
                     });

                newDate = start.AddDays(gen.Next(range));

                await CreateOrUpdatePdfAcquisition(context,
                     new PdfAcquisition
                     {
                         PdfId = 3,
                         UserId = "970de14c-a6cf-4887-b1d6-b40780c03782",
                         AcquisitionDate = newDate,
                         Price = 18.99
                     });

                newDate = start.AddDays(gen.Next(range));

                await CreateOrUpdatePdfAcquisition(context,
                     new PdfAcquisition
                     {
                         PdfId = 3,
                         UserId = "970de14c-a6cf-4887-b1d6-b40780c03782",
                         AcquisitionDate = newDate,
                         Price = 18.99
                     });

                newDate = start.AddDays(gen.Next(range));

                await CreateOrUpdatePdfAcquisition(context,
                     new PdfAcquisition
                     {
                         PdfId = 3,
                         UserId = "7c4b0f8b-69fa-4a65-b47b-0fbff5e74d95",
                         AcquisitionDate = newDate,
                         Price = 18.99
                     });

                newDate = start.AddDays(gen.Next(range));

                await CreateOrUpdatePdfAcquisition(context,
                     new PdfAcquisition
                     {
                         PdfId = 3,
                         UserId = "8546db10-ea48-4ea8-b317-312436120f1c",
                         AcquisitionDate = newDate,
                         Price = 18.99
                     });

                newDate = start.AddDays(gen.Next(range));

                await CreateOrUpdatePdfAcquisition(context,
                    new PdfAcquisition
                    {
                        PdfId = 4,
                        UserId = "dd7c431a-cd78-42f2-bbf4-2f814b50fe97",
                        AcquisitionDate = newDate,
                        Price = 20.99
                    });

                newDate = start.AddDays(gen.Next(range));

                await CreateOrUpdatePdfAcquisition(context,
                    new PdfAcquisition
                    {
                        PdfId = 4,
                        UserId = "056ebb6b-589e-406e-be0f-bba4ddb6a21e",
                        AcquisitionDate = newDate,
                        Price = 20.99
                    });

                newDate = start.AddDays(gen.Next(range));

                await CreateOrUpdatePdfAcquisition(context,
                    new PdfAcquisition
                    {
                        PdfId = 4,
                        UserId = "0d280c91-c2f6-47f4-990d-c554512d1d7e",
                        AcquisitionDate = newDate,
                        Price = 20.99
                    });

                newDate = start.AddDays(gen.Next(range));

                await CreateOrUpdatePdfAcquisition(context,
                    new PdfAcquisition
                    {
                        PdfId = 4,
                        UserId = "7c4b0f8b-69fa-4a65-b47b-0fbff5e74d95",
                        AcquisitionDate = newDate,
                        Price = 20.99
                    });

                newDate = start.AddDays(gen.Next(range));

                await CreateOrUpdatePdfAcquisition(context,
                    new PdfAcquisition
                    {
                        PdfId = 4,
                        UserId = "8546db10-ea48-4ea8-b317-312436120f1c",
                        AcquisitionDate = newDate,
                        Price = 20.99
                    });

                newDate = start.AddDays(gen.Next(range));

                await CreateOrUpdatePdfAcquisition(context,
                    new PdfAcquisition
                    {
                        PdfId = 4,
                        UserId = "7424c99f-9955-49be-8a02-608d3cf7f2bc",
                        AcquisitionDate = newDate,
                        Price = 20.99
                    });

                await context.SaveChangesAsync();

                // MetricFeature seed
                List<ApplicationUser> users = context.ApplicationUser.ToList();

                for (int i = 0; i < 0; i++)
                {
                    int userRandom = new Random().Next(11);

                    ApplicationUser user = users[userRandom];
                    int featureId = new Random().Next(1, 12);

                    gen = new Random();

                    start = new DateTime(2010, 1, 1);
                    range = (DateTime.Today - start).Days;
                    newDate = start.AddDays(gen.Next(range));

                    // MetricFeature seed
                    await CreateOrUpdateMetricFeature(context,
                        new MetricFeature
                        {
                            Date = newDate,
                            Duration = new Random().Next(20, 1000),
                            FeatureId = featureId,
                            Feature = context.Feature.Where(x => x.FeatureId == featureId).First(),
                            PdfId = new Random().Next(1, 5),
                            User = user
                        });
                }
                await context.SaveChangesAsync();
            }
        }

        public async Task CreateOrUpdateFeature(ApplicationDbContext context, Feature model)
        {
            var feature = context.Feature.FirstOrDefault(x => x.Name.Equals(model.Name));
            if (feature == null) {
                feature = model;
                await context.Feature.AddAsync(feature);
            } else {
                feature.Name = model.Name;
            }
        }

        public async Task CreateOrUpdateApplicationUser(ApplicationDbContext context, ApplicationUser model)
        {
            var applicationUser = context.ApplicationUser
                .FirstOrDefault(x => x.Id.Equals(model.Id, StringComparison.OrdinalIgnoreCase));
                    
            if (applicationUser == null) {
                applicationUser = model;
                await context.ApplicationUser.AddAsync(applicationUser);
            } else {
                applicationUser.AccessFailedCount = model.AccessFailedCount;
                applicationUser.ConcurrencyStamp = model.ConcurrencyStamp;
                applicationUser.Email = model.Email;
                applicationUser.EmailConfirmed = model.EmailConfirmed;
                applicationUser.LockoutEnabled = model.LockoutEnabled;
                applicationUser.LockoutEnd = model.LockoutEnd;
                applicationUser.NormalizedEmail = model.NormalizedEmail;
                applicationUser.NormalizedUserName = model.NormalizedUserName;
                applicationUser.PasswordHash = model.PasswordHash;
                applicationUser.PhoneNumber = model.PhoneNumber;
                applicationUser.PhoneNumberConfirmed = model.PhoneNumberConfirmed;
                applicationUser.SecurityStamp = model.SecurityStamp;
                applicationUser.TwoFactorEnabled = model.TwoFactorEnabled;
                applicationUser.UserName = model.UserName;
            }
        }

        public async Task CreateOrUpdatePdfAcquisition(ApplicationDbContext context, PdfAcquisition model)
        {
            var pdfAcquisition = context.PdfAcquisition
                .FirstOrDefault(x => x.PdfId == model.PdfId 
                    && x.UserId.Equals(model.UserId, StringComparison.OrdinalIgnoreCase));
                    
            if (pdfAcquisition == null) {
                pdfAcquisition = model;
                await context.PdfAcquisition.AddAsync(pdfAcquisition);
            } else {
                pdfAcquisition.PdfId = model.PdfId;
                pdfAcquisition.UserId = model.UserId;
                pdfAcquisition.AcquisitionDate = model.AcquisitionDate;
                pdfAcquisition.Price = model.Price;
            }
        }

        public async Task CreateOrUpdateMetricFeature(ApplicationDbContext context, MetricFeature model)
        {
            var metricFeature = context.MetricFeature
                .FirstOrDefault(x => DateTime.Compare(x.Date, model.Date) == 0
                    && x.Duration == model.Duration
                    && x.FeatureId == model.FeatureId
                    && x.PdfId == model.PdfId);
                    
            if (metricFeature == null) {
                metricFeature = model;
                await context.MetricFeature.AddAsync(metricFeature);
            }
        }

        public async Task CreateOrUpdateSummaryFeature(ApplicationDbContext context, SummaryFeature model)
        {
            var summaryFeature = context.SummaryFeature
                .FirstOrDefault(x => x.Duration == model.Duration
                    && x.FeatureId == model.FeatureId
                    && x.Frequency == model.Frequency
                    && DateTime.Compare(x.LastFeatureSeenDate, model.LastFeatureSeenDate) == 0);
                    
            if (summaryFeature == null) {
                summaryFeature = model;
                await context.SummaryFeature.AddAsync(summaryFeature);
            }
        }
    }
}