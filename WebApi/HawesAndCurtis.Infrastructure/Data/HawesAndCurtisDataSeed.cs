using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using HawesAndCurtis.Core.Entities;

namespace HawesAndCurtis.Infrastructure.Data
{
    public class HawesAndCurtisDataSeed
    {
        public static async Task SeedAsync(HawesAndCurtisDataContext hawesAndCurtisDataContext, bool migrateDatabase = false)
        {
            // TODO: Only run this if using a real database
            if (migrateDatabase)
                hawesAndCurtisDataContext.Database.Migrate();
            hawesAndCurtisDataContext.Database.EnsureCreated();

            // categories - specifications
            await SeedProductTypesAsync(hawesAndCurtisDataContext);

            // products
            await SeedProductsAsync(hawesAndCurtisDataContext);

            // product recommendations
            await SeedProductRecommendationsAsync(hawesAndCurtisDataContext);
            
            // product specifications
            await SeedProductSpecificationAsync(hawesAndCurtisDataContext);
            // users
            await SeedUsersAsync(hawesAndCurtisDataContext);
        }
        private static async Task SeedProductTypesAsync(HawesAndCurtisDataContext dataContext)
        {
            if (!dataContext.ProductTypes.Any())
            {
                var categories = new List<ProductType>
                {
                    new ProductType() { Name = "Shirt", Description= "Shirt", IsDeleted=false, CreatedBy="admin", CreatedDate=DateTime.Now}, // 1
                    new ProductType() { Name = "Ties", Description= "Ties", IsDeleted=false, CreatedBy="admin", CreatedDate=DateTime.Now}, // 2
                    new ProductType() { Name = "Cufflinks", Description= "Cufflinks", IsDeleted=false, CreatedBy="admin", CreatedDate=DateTime.Now}, // 3
                };

                await dataContext.ProductTypes.AddRangeAsync(categories);
                await dataContext.SaveChangesAsync();
            }
        }
        private static async Task SeedProductsAsync(HawesAndCurtisDataContext dataContext)
        {
            if (!dataContext.Products.Any())
            {
                 var products = new List<Product>
                {
                    // Phone
                    new Product()
                    {
                        Code = "SHIRT0001",
                        Name = "Cutaway Collar Non-Iron Tyrwhitt Cool Poplin Check Shirt - Blue & Pink",
                        Description = "This shirt is part of our Tyrwhitt Cool range: featuring our innovative finish designed to wick away moisture and keep you feeling cool and fresh all day. Made from 100% cotton poplin, it’s lightweight and versatile in an easy-to-wear range of colours and designs, and non-iron for a crease-free look.",
                        ImageFile = "shirt-0001.jpg",
                        Price = 25,
                        ProductTypeId = dataContext.ProductTypes.FirstOrDefault(c => c.Name == "Shirt").ProductTypeId,
                        IsDeleted=false, CreatedBy="admin", CreatedDate=DateTime.Now
                    },
                    new Product()
                    {
                        Code = "SHIRT0002",
                        Name = "Non-Iron Twill Shirt - White",
                        Description = "This shirt is part of our Tyrwhitt Cool range: featuring our innovative finish designed to wick away moisture and keep you feeling cool and fresh all day. Made from 100% cotton poplin, it’s lightweight and versatile in an easy-to-wear range of colours and designs, and non-iron for a crease-free look.",
                        ImageFile = "shirt-0002.jpg",
                        Price = 28,
                        ProductTypeId = dataContext.ProductTypes.FirstOrDefault(c => c.Name == "Shirt").ProductTypeId,
                        IsDeleted=false, CreatedBy="admin", CreatedDate=DateTime.Now
                    },
                    new Product()
                    {
                        Code = "SHIRT0003",
                        Name = "Cutaway Collar Non-Iron Twill Shirt - White",
                        Description = "This Tyrwhitt Icon underpins business outfits around the world. Our much-loved staple shirt is crafted from soft and breathable cotton. A distinctive diagonal weave gives the fabric a subtle sheen and excellent drape, as well as making it wonderfully hard-wearing. For ease of care, we've added our non-iron finish.In classic, crisp white, this shirt easily coordinates with any shade or pattern. Its cutaway collar is suited to a relaxed, open-neck look, or you can add a Windsor-knot tie for a more formal ensemble. Complimentary brass collar stays ensure your collar holds the perfect shape.",
                        ImageFile = "shirt-0003.jpg",
                        Price = 30,
                        ProductTypeId = dataContext.ProductTypes.FirstOrDefault(c => c.Name == "Shirt").ProductTypeId,
                        IsDeleted=false, CreatedBy="admin", CreatedDate=DateTime.Now
                    },
                    new Product()
                    {
                        Code = "SHIRT0004",
                        Name = "Semi-Cutaway Collar Egyptian Cotton Poplin Shirt - Blue",
                        Description = "This formal shirt is cut from refined end-on-end poplin, which is woven using the finest Egyptian cotton. For depth and subtle criss-cross detailing, this type of fabric has two more coloured yarns alternated in the weave.The high-quality fibres not only add interest to your look, but are naturally breathable and feel soft next to your skin. For a sharp finish, this shirt comes with complimentary brass collar stays",
                        ImageFile = "shirt-0004.jpg",
                        Price = 20,
                        ProductTypeId = dataContext.ProductTypes.FirstOrDefault(c => c.Name == "Shirt").ProductTypeId,
                        IsDeleted=false, CreatedBy="admin", CreatedDate=DateTime.Now
                    },
                    // Camera                
                    new Product()
                    {
                        Code = "SHIRT0005",
                        Name = "Semi-Cutaway Collar Egyptian Cotton Poplin Shirt - Lilac",
                        Description = "This formal shirt is cut from refined end-on-end poplin, which is woven using the finest Egyptian cotton. For depth and subtle criss-cross detailing, this type of fabric has two more coloured yarns alternated in the weave.The high-quality fibres not only add interest to your look, but are naturally breathable and feel soft next to your skin. For a sharp finish, this shirt comes with complimentary brass collar stays",
                        ImageFile = "shirt-0005.jpg",
                        Price = 20,
                        ProductTypeId = dataContext.ProductTypes.FirstOrDefault(c => c.Name == "Shirt").ProductTypeId,
                        IsDeleted=false, CreatedBy="admin", CreatedDate=DateTime.Now
                    },
                    new Product()
                    {
                        Code = "SHIRT0006",
                        Name = "Semi-Cutaway Collar Egyptian Cotton Poplin Shirt - Yellow",
                        Description = "This formal shirt is cut from refined end-on-end poplin, which is woven using the finest Egyptian cotton. For depth and subtle criss-cross detailing, this type of fabric has two more coloured yarns alternated in the weave.The high-quality fibres not only add interest to your look, but are naturally breathable and feel soft next to your skin. For a sharp finish, this shirt comes with complimentary brass collar stays",
                        ImageFile = "shirt-0006.jpg",
                        Price = 19,
                        ProductTypeId = dataContext.ProductTypes.FirstOrDefault(c => c.Name == "Shirt").ProductTypeId,
                        IsDeleted=false, CreatedBy="admin", CreatedDate=DateTime.Now
                    },
                    new Product()
                    {
                        Code = "TIE0001",
                        Name = "Slim Silk Knitted Tie - Navy",
                        Description = "To meet our superior standards, this silk tie has been finished by hand. The fabric has excellent drape, while a subtle sheen adds an eye-catching element to your look. A recovery loop, hidden in the tail end, lets you gently reshape this piece after wearing.With a narrow construction and a pointed blade that measures 6.5cm across, this tie has a streamlined shape that works well with contemporary, slim-fitting suits.",
                        ImageFile = "tie0001.jpg",
                        Price = 12,
                        ProductTypeId = dataContext.ProductTypes.FirstOrDefault(c => c.Name == "Ties").ProductTypeId,
                        IsDeleted=false, CreatedBy="admin", CreatedDate=DateTime.Now
                    },
                    new Product()
                    {
                        Code = "TIE0002",
                        Name = "Silk Linen Stripe Tie - Blue & White",
                        Description = "Add a splash of brightness to your wardrobe with our classic striped tie. Crafted from a fine blend of linen and silk, this design has an elegant sheen and a supple feel. Thoughtful details include a keeper loop for securing the tail end and a secret recovery loop. This allows the fabric to move when knotted and helps to maintain the shape of the tie. Team this piece with a crisp white shirt to let the pattern really stand out.",
                        ImageFile = "tie0002.jpg",
                        Price = 15,
                        ProductTypeId = dataContext.ProductTypes.FirstOrDefault(c => c.Name == "Ties").ProductTypeId,
                        IsDeleted=false, CreatedBy="admin", CreatedDate=DateTime.Now
                    },
                    new Product()
                    {
                        Code = "TIE0003",
                        Name = "Silk Chain Print Tie - Blue",
                        Description = "These silk ties feature discreet motifs that grow in charm the closer you look. Each design proudly showcases the expert craftsmanship of our in-house textile designer. They have the luxurious softness and lasting quality that you'd expect from pure silk fibres. Wear your tie with a dark wool three-piece suit for a dashing ensemble.",
                        ImageFile = "tie0003.jpg",
                        Price = 16,
                        ProductTypeId = dataContext.ProductTypes.FirstOrDefault(c => c.Name == "Ties").ProductTypeId,
                        IsDeleted=false, CreatedBy="admin", CreatedDate=DateTime.Now
                    },
                    // Accessories
                    new Product()
                    {
                        Code = "CUFFLINKS0001",
                        Name = "Enamel Fleur-de-Lys Round Cufflinks - Navy",
                        Description = "This pair of elegant cufflinks, perfect for securing double cuffs, has a secure fixed back fastening for ease of use. The enamel insert, in a design exclusive to Charles Tyrwhitt, adds a touch of sophistication to any formal look. They are ideal for special occasions, a distinguished daily work outfit, or as a gift - presented in a cufflink tin. They are also plated with rhodium, a hypoallergenic metal that resists tarnishing over time.",
                        ImageFile = "cufflinks0001.jpg",
                        Price = 7,
                        ProductTypeId = dataContext.ProductTypes.FirstOrDefault(c => c.Name == "Cufflinks").ProductTypeId,
                        IsDeleted=false, CreatedBy="admin", CreatedDate=DateTime.Now
                    },
                    new Product()
                    {
                        Code = "CUFFLINKS0002",
                        Name = "Knot Cufflinks - Silver",
                        Description = "This pair of luxury cufflinks, perfect for securing double cuffs, has a secure swivel back fastening for ease of use. The knot design, exclusive to Charles Tyrwhitt, adds a touch of sophistication to any formal look. They are ideal for special occasions, smartening up your daily shirts, or as a luxurious gift - presented in a cufflink tin. They are also rhodium-plated, a hypoallergenic metal that resists tarnishing over time.",
                        ImageFile = "cufflinks0002.jpg",
                        Price = 5,
                        ProductTypeId = dataContext.ProductTypes.FirstOrDefault(c => c.Name == "Cufflinks").ProductTypeId,
                        IsDeleted=false, CreatedBy="admin", CreatedDate=DateTime.Now
                    },
                    new Product()
                    {
                        Code = "CUFFLINKS0003",
                        Name = "Acorn Cufflinks - Gold",
                        Description = "Bring personality to your outfits with these characterful cufflinks. Striking the balance between playfulness and polished refinement, they make an eye-catching addition to smart shirts that's sure to spark conversation.  We've plated them in robust metal for longevity and added modern swivel-back closures, so securing them takes moments. Presented in one of our Charles Tyrwhitt tins, these cufflinks are made with stylish gift-giving in mind",
                        ImageFile = "cufflinks0003.jpg",
                        Price = 8,
                        ProductTypeId = dataContext.ProductTypes.FirstOrDefault(c => c.Name == "Cufflinks").ProductTypeId,
                        IsDeleted=false, CreatedBy="admin", CreatedDate=DateTime.Now
                    }
                };

                await dataContext.AddRangeAsync(products);
                await dataContext.SaveChangesAsync();
            }
        }
        private static async Task SeedProductRecommendationsAsync(HawesAndCurtisDataContext dataContext)
        {
            
            if (!dataContext.ProductRecommendations.Any())
            {
                var shirt = dataContext.Products.FirstOrDefault(s => s.ProductType.Name == "Shirt");
                var ties = dataContext.Products.Where(t => t.ProductType.Name == "Ties").ToList();
                var cufflinks = dataContext.Products.Where(c => c.ProductType.Name == "Cufflinks").ToList();

                var productRecommendations = new List<ProductRecommendation>()
                {
                    new ProductRecommendation
                    {
                        ProductId = shirt.ProductId,
                        RecommendedProductId = ties[0].ProductId,
                        IsDeleted=false, CreatedBy="admin", CreatedDate=DateTime.Now
                    },
                    new ProductRecommendation
                    {
                        ProductId = shirt.ProductId,
                        RecommendedProductId = ties[1].ProductId,
                        IsDeleted=false, CreatedBy="admin", CreatedDate=DateTime.Now
                    },
                    new ProductRecommendation
                    {
                        ProductId = shirt.ProductId,
                        RecommendedProductId = ties[2].ProductId,
                        IsDeleted=false, CreatedBy="admin", CreatedDate=DateTime.Now
                    },
                    new ProductRecommendation
                    {
                        ProductId = shirt.ProductId,
                        RecommendedProductId = cufflinks[0].ProductId,
                        IsDeleted=false, CreatedBy="admin", CreatedDate=DateTime.Now
                    },
                    new ProductRecommendation
                    {
                        ProductId = shirt.ProductId,
                        RecommendedProductId = cufflinks[1].ProductId,
                        IsDeleted=false, CreatedBy="admin", CreatedDate=DateTime.Now
                    },
                    new ProductRecommendation
                    {
                        ProductId = shirt.ProductId,
                        RecommendedProductId = cufflinks[2].ProductId,
                        IsDeleted=false, CreatedBy="admin", CreatedDate=DateTime.Now
                    }
                };
                await dataContext.AddRangeAsync(productRecommendations);
                await dataContext.SaveChangesAsync();
            }
        }
        private static async Task SeedProductSpecificationAsync(HawesAndCurtisDataContext dataContext)
        {
            if (!dataContext.ProductSpecifications.Any())
            {
                var tieSpecs = new string[] { "100% silk", "Stain-resistant finish", "Dry clean only", "Hand finished" };
                var cufflinksSpecs = new string[] { "Gold plated", "Swivel back", "Supplied in a cufflink tin" };

                var ties = dataContext.Products.Where(p => p.ProductType.Name == "Ties").ToList();
                var cufflinks = dataContext.Products.Where(p => p.ProductType.Name == "Cufflinks").ToList();

                var productSpecifications = new List<ProductSpecification>()
                {
                    new ProductSpecification
                    {
                        ProductId = ties[0].ProductId,
                        Specification = tieSpecs[0],
                        IsDeleted=false, CreatedBy="admin", CreatedDate=DateTime.Now
                    },
                    new ProductSpecification
                    {
                        ProductId = ties[0].ProductId,
                        Specification = tieSpecs[1],
                        IsDeleted=false, CreatedBy="admin", CreatedDate=DateTime.Now
                    },
                    new ProductSpecification
                    {
                        ProductId = ties[0].ProductId,
                        Specification = tieSpecs[2],
                        IsDeleted=false, CreatedBy="admin", CreatedDate=DateTime.Now
                    },
                    new ProductSpecification
                    {
                        ProductId = ties[0].ProductId,
                        Specification = tieSpecs[3],
                        IsDeleted=false, CreatedBy="admin", CreatedDate=DateTime.Now
                    },
                    new ProductSpecification
                    {
                        ProductId = ties[1].ProductId,
                        Specification = tieSpecs[0],
                        IsDeleted=false, CreatedBy="admin", CreatedDate=DateTime.Now
                    },
                    new ProductSpecification
                    {
                        ProductId = ties[1].ProductId,
                        Specification = tieSpecs[1],
                        IsDeleted=false, CreatedBy="admin", CreatedDate=DateTime.Now
                    },
                    new ProductSpecification
                    {
                        ProductId = ties[1].ProductId,
                        Specification = tieSpecs[2],
                        IsDeleted=false, CreatedBy="admin", CreatedDate=DateTime.Now
                    },
                    new ProductSpecification
                    {
                        ProductId = ties[1].ProductId,
                        Specification = tieSpecs[3],
                        IsDeleted=false, CreatedBy="admin", CreatedDate=DateTime.Now
                    },
                    new ProductSpecification
                    {
                        ProductId = ties[2].ProductId,
                        Specification = tieSpecs[0],
                        IsDeleted=false, CreatedBy="admin", CreatedDate=DateTime.Now
                    },
                    new ProductSpecification
                    {
                        ProductId = ties[2].ProductId,
                        Specification = tieSpecs[1],
                        IsDeleted=false, CreatedBy="admin", CreatedDate=DateTime.Now
                    },
                    new ProductSpecification
                    {
                        ProductId = ties[2].ProductId,
                        Specification = tieSpecs[3],
                        IsDeleted=false, CreatedBy="admin", CreatedDate=DateTime.Now
                    },
                    new ProductSpecification
                    {
                        ProductId = cufflinks[0].ProductId,
                        Specification = cufflinksSpecs[0],
                        IsDeleted=false, CreatedBy="admin", CreatedDate=DateTime.Now
                    },
                    new ProductSpecification
                    {
                        ProductId = cufflinks[0].ProductId,
                        Specification = cufflinksSpecs[1],
                        IsDeleted=false, CreatedBy="admin", CreatedDate=DateTime.Now
                    },
                    new ProductSpecification
                    {
                        ProductId = cufflinks[0].ProductId,
                        Specification = cufflinksSpecs[2],
                        IsDeleted=false, CreatedBy="admin", CreatedDate=DateTime.Now
                    },
                    new ProductSpecification
                    {
                        ProductId = cufflinks[1].ProductId,
                        Specification = cufflinksSpecs[0],
                        IsDeleted=false, CreatedBy="admin", CreatedDate=DateTime.Now
                    },
                    new ProductSpecification
                    {
                        ProductId = cufflinks[1].ProductId,
                        Specification = cufflinksSpecs[1],
                        IsDeleted=false, CreatedBy="admin", CreatedDate=DateTime.Now
                    },
                    new ProductSpecification
                    {
                        ProductId = cufflinks[1].ProductId,
                        Specification = cufflinksSpecs[2],
                        IsDeleted=false, CreatedBy="admin", CreatedDate=DateTime.Now
                    },
                    new ProductSpecification
                    {
                        ProductId = cufflinks[2].ProductId,
                        Specification = cufflinksSpecs[0],
                        IsDeleted=false, CreatedBy="admin", CreatedDate=DateTime.Now
                    },
                    new ProductSpecification
                    {
                        ProductId = cufflinks[2].ProductId,
                        Specification = cufflinksSpecs[1],
                        IsDeleted=false, CreatedBy="admin", CreatedDate=DateTime.Now
                    },
                    new ProductSpecification
                    {
                        ProductId = cufflinks[2].ProductId,
                        Specification = cufflinksSpecs[2],
                        IsDeleted=false, CreatedBy="admin", CreatedDate=DateTime.Now
                    }
                };

                await dataContext.AddRangeAsync(productSpecifications);
                await dataContext.SaveChangesAsync();
            }
        }
        private static async Task SeedUsersAsync(HawesAndCurtisDataContext dataContext)
        {
            if (!dataContext.Users.Any())
            {
                await Adduser(dataContext, "admin", "Welcome@123");
                await Adduser(dataContext, "isaac", "Welcome@123");
                //await dataContext.SaveChangesAsync();
            }
        }
        private static async Task Adduser(HawesAndCurtisDataContext dataContext, string userName, string password)
        {
            var user = dataContext.Users.FirstOrDefault(u => u.UserName == userName);
            if (user == null)
            {
                var hmac = new HMACSHA512();
                var passwordSaltHash = Tuple.Create(hmac.Key, hmac.ComputeHash(Encoding.UTF8.GetBytes(password)));

                User newUser = new User() { UserName = userName, PasswordHash = passwordSaltHash.Item2, PasswordSalt = passwordSaltHash.Item1, IsDeleted = false, CreatedBy = "admin", CreatedDate = DateTime.Now };

                var result = await dataContext.Users.AddAsync(newUser);
                await dataContext.SaveChangesAsync();
            }
        }
    }
}
