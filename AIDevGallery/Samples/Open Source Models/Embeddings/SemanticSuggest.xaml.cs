// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AIDevGallery.Models;
using AIDevGallery.Samples.Attributes;
using AIDevGallery.Samples.SharedCode;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AIDevGallery.Samples.OpenSourceModels.SentenceEmbeddings.Embeddings
{
    [GallerySample(
        Name = "Semantic Combo Box",
        Model1Types = [ModelType.EmbeddingModel],
        Scenario = ScenarioType.SmartControlsSemanticComboBox,
        SharedCode = [
            SharedCodeEnum.SemanticComboBoxCs,
            SharedCodeEnum.SemanticComboBoxXaml,
            SharedCodeEnum.EmbeddingGenerator,
            SharedCodeEnum.EmbeddingModelInput,
            SharedCodeEnum.TokenizerExtensions,
            SharedCodeEnum.DeviceUtils,
            SharedCodeEnum.StringData
        ],
        NugetPackageReferences = [
            "System.Numerics.Tensors",
            "Microsoft.ML.Tokenizers",
            "Microsoft.ML.OnnxRuntime.DirectML",
            "Microsoft.Extensions.AI.Abstractions",
            "Microsoft.SemanticKernel.Connectors.InMemory"
        ],
        Id = "c0d6c4f1-8daa-409f-a686-3de388edbf91",
        Icon = "\uE8D4")]
    internal sealed partial class SemanticSuggest : BaseSamplePage
    {
        public SemanticSuggest()
        {
            this.InitializeComponent();
        }

        protected override Task LoadModelAsync(SampleNavigationParameters sampleParams)
        {
            this.MySemanticComboBox.EmbeddingGenerator = new EmbeddingGenerator(sampleParams.ModelPath, sampleParams.HardwareAccelerator);
            sampleParams.NotifyCompletion();
            return Task.CompletedTask;
        }

        public List<string> ShoppingCategories { get; } =
        [
            "Antiques & Collectibles",
            "Apparel",
            "Apparel > Athletic Apparel",
            "Apparel > Casual Apparel",
            "Apparel > Children's Clothing",
            "Apparel > Clothing Accessories",
            "Apparel > Costumes",
            "Apparel > Eyewear",
            "Apparel > Footwear",
            "Apparel > Formal Wear",
            "Apparel > Headwear",
            "Apparel > Men's Clothing",
            "Apparel > Swimwear",
            "Apparel > Undergarments",
            "Apparel > Women's Clothing",
            "Arts & Entertainment",
            "Arts & Entertainment > Comics & Animation",
            "Arts & Entertainment > Comics & Animation > Anime & Manga",
            "Arts & Entertainment > Comics & Animation > Cartoons",
            "Arts & Entertainment > Comics & Animation > Comics",
            "Arts & Entertainment > Concerts & Music Festivals",
            "Arts & Entertainment > Humor",
            "Arts & Entertainment > Movies",
            "Arts & Entertainment > Music & Audio",
            "Arts & Entertainment > Music & Audio > Classical Music",
            "Arts & Entertainment > Music & Audio > Country Music",
            "Arts & Entertainment > Music & Audio > Dance & Electronic Music",
            "Arts & Entertainment > Music & Audio > Jazz & Blues",
            "Arts & Entertainment > Music & Audio > Music Education & Instruction",
            "Arts & Entertainment > Music & Audio > Music Equipment & Technology",
            "Arts & Entertainment > Music & Audio > Music Reference",
            "Arts & Entertainment > Music & Audio > Pop Music",
            "Arts & Entertainment > Music & Audio > Radio & Podcast",
            "Arts & Entertainment > Music & Audio > Religious Music",
            "Arts & Entertainment > Music & Audio > Rock Music",
            "Arts & Entertainment > Music & Audio > Urban & Hip-Hop",
            "Arts & Entertainment > Performing Arts",
            "Arts & Entertainment > Performing Arts > Acting & Theater",
            "Arts & Entertainment > Performing Arts > Circus",
            "Arts & Entertainment > Performing Arts > Dance",
            "Arts & Entertainment > Performing Arts > Magic",
            "Arts & Entertainment > TV Shows & Programs",
            "Arts & Entertainment > Visual Art & Design",
            "Arts & Entertainment > Visual Art & Design > Architecture",
            "Arts & Entertainment > Visual Art & Design > Art Museums & Galleries",
            "Arts & Entertainment > Visual Art & Design > Design",
            "Arts & Entertainment > Visual Art & Design > Painting",
            "Attractions",
            "Attractions > Regional Parks & Gardens",
            "Attractions > Theme Parks",
            "Attractions > Zoos Aquariums & Preserves",
            "Autos & Vehicles",
            "Autos & Vehicles > Boats & Watercraft",
            "Autos & Vehicles > Campers & RVs",
            "Autos & Vehicles > Classic Vehicles",
            "Autos & Vehicles > Motor Vehicles",
            "Autos & Vehicles > Motor Vehicles > Electric & Alternative",
            "Autos & Vehicles > Motor Vehicles > Motorcycles & Scooters",
            "Autos & Vehicles > Motor Vehicles > Off-Road",
            "Autos & Vehicles > Motor Vehicles > Trucks & SUVs",
            "Autos & Vehicles > Parts & Services",
            "Autos & Vehicles > Repair & Maintenance",
            "Autos & Vehicles > Safety",
            "Beauty & Fitness",
            "Beauty & Fitness > Body Art",
            "Beauty & Fitness > Cosmetic Procedures",
            "Beauty & Fitness > Face & Body Care",
            "Beauty & Fitness > Face & Body Care > Hygiene & Toiletries",
            "Beauty & Fitness > Face & Body Care > Make-Up & Cosmetics",
            "Beauty & Fitness > Face & Body Care > Perfumes & Fragrances",
            "Beauty & Fitness > Face & Body Care > Shaving & Hair Removal",
            "Beauty & Fitness > Face & Body Care > Skin & Nail Care",
            "Beauty & Fitness > Fitness",
            "Beauty & Fitness > Hair Care",
            "Beauty & Fitness > Hair Care > Hair Loss",
            "Beauty & Fitness > Spas & Beauty Services",
            "Beauty & Fitness > Spas & Beauty Services > Massage Therapy",
            "Beauty & Fitness > Weight Loss",
            "Books & Literature",
            "Books & Literature > Calendars",
            "Books & Literature > Children's Literature",
            "Books & Literature > E-Books",
            "Books & Literature > Geographic Reference",
            "Books & Literature > Language",
            "Books & Literature > Notebooks & Planners",
            "Books & Literature > Poetry",
            "Books & Literature > Writers Resources",
            "Business & Industrial",
            "Business & Industrial > Advertising & Marketing",
            "Business & Industrial > Advertising & Marketing > Public Relations",
            "Business & Industrial > Agriculture & Forestry",
            "Business & Industrial > Agriculture & Forestry > Agricultural Equipment",
            "Business & Industrial > Agriculture & Forestry > Beekeeping",
            "Business & Industrial > Agriculture & Forestry > Livestock",
            "Business & Industrial > Agriculture & Forestry > Wood & Forestry",
            "Business & Industrial > Business Finance",
            "Business & Industrial > Business Operations",
            "Business & Industrial > Business Services",
            "Business & Industrial > Business Services > Consulting",
            "Business & Industrial > Business Services > Corporate Events",
            "Business & Industrial > Business Services > E-Commerce Services",
            "Business & Industrial > Business Services > Office Services",
            "Business & Industrial > Business Services > Office Supplies",
            "Business & Industrial > Business Services > Writing & Editing Services",
            "Business & Industrial > Chemicals Industry",
            "Business & Industrial > Chemicals Industry > Plastics & Polymers",
            "Business & Industrial > Construction & Maintenance",
            "Business & Industrial > Industrial Materials & Equipment",
            "Business & Industrial > Industrial Materials & Equipment > Heavy Machinery",
            "Business & Industrial > Mail & Package Delivery",
            "Business & Industrial > Manufacturing",
            "Business & Industrial > Metals & Mining",
            "Business & Industrial > Metals & Mining > Precious Metals",
            "Business & Industrial > Moving & Relocation",
            "Business & Industrial > Packaging",
            "Business & Industrial > Pharmaceuticals & Biotech",
            "Business & Industrial > Printing & Publishing",
            "Business & Industrial > Renewable & Alternative Energy",
            "Business & Industrial > Retail Equipment & Technology",
            "Computers",
            "Computers > CAD & CAM",
            "Computers > Computer Hardware",
            "Computers > Computer Hardware > Computer Components",
            "Computers > Computer Hardware > Computer Drives & Storage",
            "Computers > Computer Hardware > Computer Peripherals",
            "Computers > Computer Hardware > Desktop Computers",
            "Computers > Computer Hardware > Laptops & Notebooks",
            "Computers > Computer Security",
            "Computers > Computer Security > Hacking & Cracking",
            "Computers > Electronics & Electrical",
            "Computers > Electronics & Electrical > Electronic Components",
            "Computers > Electronics & Electrical > Power Supplies",
            "Computers > Game Systems & Consoles",
            "Computers > Networking",
            "Computers > Software",
            "Computers > Software > Business & Productivity Software",
            "Computers > Software > Multimedia Software",
            "Consumer Electronics",
            "Consumer Electronics > Audio Equipment",
            "Consumer Electronics > Camera & Photo Equipment",
            "Consumer Electronics > Car Electronics",
            "Consumer Electronics > Drones & RC Aircraft",
            "Consumer Electronics > GPS & Navigation",
            "Consumer Electronics > Mobile & Wireless",
            "Consumer Electronics > Mobile & Wireless > Mobile & Wireless Accessories",
            "Consumer Electronics > Mobile & Wireless > Mobile Apps & Add-Ons",
            "Consumer Electronics > Mobile & Wireless > Mobile Phones",
            "Consumer Electronics > Radio & Communications",
            "Consumer Electronics > TV & Video Equipment",
            "Coupons & Discounts",
            "Finance",
            "Finance > Accounting & Auditing",
            "Finance > Investing",
            "Finance > Investing > Currencies & Foreign Exchange",
            "Finance > Investing > Stocks & Bonds",
            "Firearms & Weapons",
            "Food & Drink",
            "Food & Drink > Beverages",
            "Food & Drink > Beverages > Alcoholic Beverages",
            "Food & Drink > Beverages > Coffee & Tea",
            "Food & Drink > Beverages > Juice",
            "Food & Drink > Beverages > Soft Drinks",
            "Food & Drink > Food",
            "Food & Drink > Food > BBQ & Grilling",
            "Food & Drink > Food > Baked Goods & Dessert",
            "Food & Drink > Food > Baked Goods & Desserts",
            "Food & Drink > Food > Breakfast Foods",
            "Food & Drink > Food > Candy & Sweets",
            "Food & Drink > Food > Grains & Pasta",
            "Food & Drink > Food > Meat & Seafood",
            "Food & Drink > Food > Pizza",
            "Food & Drink > Food > Snack Foods",
            "Food & Drink > Food > Soups & Stews",
            "Games",
            "Games > Arcade & Coin-Op Games",
            "Games > Board Games",
            "Games > Board Games > Chess & Abstract Strategy Games",
            "Games > Board Games > Miniatures & Wargaming",
            "Games > Card Games",
            "Games > Card Games > Collectible Card Games",
            "Games > Card Games > Poker & Casino Games",
            "Games > Computer & Video Games",
            "Games > Computer & Video Games > Shooter Games",
            "Games > Computer & Video Games > Simulation Games",
            "Games > Computer & Video Games > Sports Games",
            "Games > Puzzles & Brainteasers",
            "Games > Roleplaying Games",
            "Games > Table Games",
            "Games > Table Games > Billiards",
            "Gifts & Special Events",
            "Gifts & Special Events > Cards & Greetings",
            "Gifts & Special Events > Flowers",
            "Health",
            "Health > Aging & Geriatrics",
            "Health > Health Conditions",
            "Health > Health Conditions > AIDS & HIV",
            "Health > Health Conditions > Allergies",
            "Health > Health Conditions > Arthritis",
            "Health > Health Conditions > Cancer",
            "Health > Health Conditions > Diabetes",
            "Health > Health Conditions > Ear Nose & Throat",
            "Health > Health Conditions > Heart & Hypertension",
            "Health > Health Conditions > Pain Management",
            "Health > Health Conditions > Respiratory Conditions",
            "Health > Health Conditions > Skin Conditions",
            "Health > Health Conditions > Sleep Disorders",
            "Health > Health Education & Medical Training",
            "Health > Medical Devices & Equipment",
            "Health > Medical Services",
            "Health > Medical Services > Physical Therapy",
            "Health > Men's Health",
            "Health > Mental Health",
            "Health > Mental Health > Anxiety & Stress",
            "Health > Nursing",
            "Health > Nursing > Assisted Living & Long Term Care",
            "Health > Nutrition",
            "Health > Nutrition > Special & Restricted Diets",
            "Health > Nutrition > Vitamins & Supplements",
            "Health > Occupational Health & Safety",
            "Health > Oral & Dental Care",
            "Health > Pharmacy",
            "Health > Pharmacy > Drugs & Medications",
            "Health > Reproductive Health",
            "Health > Social Services",
            "Health > Substance Abuse",
            "Health > Substance Abuse > Drug & Alcohol Testing",
            "Health > Substance Abuse > Drug & Alcohol Treatment",
            "Health > Vision Care",
            "Health > Vision Care > Eyeglasses & Contacts",
            "Health > Women's Health",
            "Holidays & Seasonal",
            "Home & Garden",
            "Home & Garden > Bed & Bath",
            "Home & Garden > Bed & Bath > Bathroom",
            "Home & Garden > Cleaning",
            "Home & Garden > Gardening & Landscaping",
            "Home & Garden > HVAC & Climate Control",
            "Home & Garden > HVAC & Climate Control > Fireplaces & Stoves",
            "Home & Garden > Home & Interior Decor",
            "Home & Garden > Home Appliances",
            "Home & Garden > Home Furnishings",
            "Home & Garden > Home Furnishings > Curtains & Window Treatments",
            "Home & Garden > Home Furnishings > Kitchen & Dining Furniture",
            "Home & Garden > Home Furnishings > Lamps & Lighting",
            "Home & Garden > Home Furnishings > Living Room Furniture",
            "Home & Garden > Home Furnishings > Rugs & Carpets",
            "Home & Garden > Home Improvement",
            "Home & Garden > Home Improvement > Construction & Power Tools",
            "Home & Garden > Home Improvement > Doors & Windows",
            "Home & Garden > Home Improvement > Flooring",
            "Home & Garden > Home Improvement > House Painting & Finishing",
            "Home & Garden > Home Improvement > Plumbing",
            "Home & Garden > Home Safety & Security",
            "Home & Garden > Home Storage & Shelving",
            "Home & Garden > Home Swimming Pools Saunas & Spas",
            "Home & Garden > Kitchen & Dining",
            "Home & Garden > Kitchen & Dining > Cookware & Diningware",
            "Home & Garden > Kitchen & Dining > Small Kitchen Appliances",
            "Home & Garden > Laundry",
            "Home & Garden > Nursery & Playroom",
            "Home & Garden > Pest Control",
            "Home & Garden > Yard & Patio",
            "Internet",
            "Internet > Voice & Video Chat",
            "Internet > Web Services",
            "Internet > Web Services > Web Design & Development",
            "Jobs & Education",
            "Jobs & Education > Business",
            "Jobs & Education > Education",
            "Jobs & Education > Education > Colleges & Universities",
            "Jobs & Education > Education > Distance Learning",
            "Jobs & Education > Education > Homeschooling",
            "Jobs & Education > Education > Languages",
            "Jobs & Education > Education > Legal Education",
            "Jobs & Education > Education > Primary & Secondary Schooling (K-12)",
            "Jobs & Education > Education > Standardized & Admissions Tests",
            "Jobs & Education > Education > Teaching & Classroom Resources",
            "Jobs & Education > Education > Training & Certification",
            "Jobs & Education > Education > Vocational & Continuing Education",
            "Jobs & Education > Health",
            "Jobs & Education > Jobs",
            "Jobs & Education > Jobs > Career Resources & Planning",
            "Jobs & Education > Jobs > Job Listings",
            "Jobs & Education > Jobs > Resumes & Portfolios",
            "Legal Services",
            "Legal Services > Visa & Immigration",
            "Libraries & Museums",
            "Mass Merchants & Department Stores",
            "People & Society",
            "People & Society > Family & Relationships",
            "People & Society > Family & Relationships > Family",
            "People & Society > Family & Relationships > Marriage",
            "People & Society > Family & Relationships > Troubled Relationships",
            "People & Society > Kids & Teens",
            "People & Society > Politics",
            "People & Society > Religion & Belief",
            "People & Society > Social Issues & Advocacy",
            "People & Society > Social Issues & Advocacy > Charity & Philanthropy",
            "People & Society > Social Issues & Advocacy > Green Living & Environmental Issues",
            "People & Society > Social Networks",
            "People & Society > Subcultures & Niche Interests",
            "Pets & Animals",
            "Pets & Animals > Birds",
            "Pets & Animals > Cats",
            "Pets & Animals > Dogs",
            "Pets & Animals > Exotic Pets",
            "Pets & Animals > Fish & Aquaria",
            "Pets & Animals > Horses",
            "Pets & Animals > Pet Food & Supplies",
            "Pets & Animals > Rabbits & Rodents",
            "Pets & Animals > Reptiles & Amphibians",
            "Pets & Animals > Veterinary & Health",
            "Photo & Video Services",
            "Safety & Survival",
            "Safety & Survival > Military",
            "Safety & Survival > Safety",
            "Safety & Survival > Safety > Law Enforcement",
            "Safety & Survival > Safety > Rescue & Emergency",
            "Safety & Survival > Safety > Security Products",
            "Science",
            "Science > Astronomy",
            "Science > Biological Sciences",
            "Science > Biological Sciences > Neuroscience",
            "Science > Chemistry",
            "Science > Computer Science",
            "Science > Earth Sciences",
            "Science > Earth Sciences > Geology",
            "Science > Ecology & Environment",
            "Science > Engineering & Technology",
            "Science > Engineering & Technology > Robotics",
            "Science > Mathematics",
            "Science > Mathematics > Statistics",
            "Smoking & Vaping",
            "Smoking & Vaping > Cannabis",
            "Sports",
            "Sports > Animal Sports",
            "Sports > College Sports",
            "Sports > Combat Sports",
            "Sports > Combat Sports > Boxing",
            "Sports > Combat Sports > Martial Arts",
            "Sports > Combat Sports > Wrestling",
            "Sports > Extreme Sports",
            "Sports > Extreme Sports > Drag & Street Racing",
            "Sports > Fantasy Sports",
            "Sports > Individual Sports",
            "Sports > Individual Sports > Cycling",
            "Sports > Individual Sports > Golf",
            "Sports > Individual Sports > Gymnastics",
            "Sports > Individual Sports > Racquet Sports",
            "Sports > Individual Sports > Skate Sports",
            "Sports > Individual Sports > Track & Field",
            "Sports > Motor Sports",
            "Sports > Sporting Goods",
            "Sports > Sporting Goods > Fishing",
            "Sports > Sporting Goods > Hiking & Camping",
            "Sports > Sporting Goods > Outdoors",
            "Sports > Sporting Goods > Sports Memorabilia",
            "Sports > Sports Coaching & Training",
            "Sports > Team Sports",
            "Sports > Team Sports > American Football",
            "Sports > Team Sports > Australian Football",
            "Sports > Team Sports > Baseball",
            "Sports > Team Sports > Basketball",
            "Sports > Team Sports > Cheerleading",
            "Sports > Team Sports > Cricket",
            "Sports > Team Sports > Hockey",
            "Sports > Team Sports > Rugby",
            "Sports > Team Sports > Soccer",
            "Sports > Team Sports > Volleyball",
            "Sports > Trophies and Awards",
            "Sports > Water Sports",
            "Sports > Water Sports > Surfing",
            "Sports > Water Sports > Swimming",
            "Sports > Winter Sports",
            "Sports > Winter Sports > Ice Skating",
            "Sports > Winter Sports > Skiing & Snowboarding",
            "Toys & Hobbies",
            "Toys & Hobbies > Arts & Crafts",
            "Toys & Hobbies > Arts & Crafts > Fiber & Textile Arts",
            "Toys & Hobbies > Building Toys",
            "Toys & Hobbies > Die-cast & Toy Vehicles",
            "Toys & Hobbies > Dolls",
            "Toys & Hobbies > Drawing & Coloring",
            "Toys & Hobbies > Radio Control & Modeling",
            "Toys & Hobbies > Radio Control & Modeling > Model Trains & Railroads",
            "Toys & Hobbies > Ride-On Toys",
            "Toys & Hobbies > Stuffed Toys",
            "Travel",
            "Travel > Air Travel",
            "Travel > Air Travel > Airport Parking & Transportation",
            "Travel > Bags & Luggage",
            "Travel > Bus & Rail",
            "Travel > Car Rental & Taxi Services",
            "Travel > Cruises & Charters",
            "Travel > Hotels & Accommodations",
            "Wedding"
        ];
    }
}