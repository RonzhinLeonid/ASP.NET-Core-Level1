using Bogus;
using DataLayer;
using static Bogus.DataSets.Name;

namespace WebStore.Services.Data
{
    public class TestData
    {
        static Faker faker = new Faker("ru");

        public static ICollection<Employee> Employees { get; } = new List<Employee>
        {
            new() { Id = 1, LastName = "Иванов", FirstName = "Иван", Patronymic = "Иванович", Age = 23 },
            new() { Id = 2, LastName = "Петров", FirstName = "Пётр", Patronymic = "Петрович", Age = 27 },
            new() { Id = 3, LastName = "Сидоров", FirstName = "Сидор", Patronymic = "Сидорович", Age = 18 },
            new() { Id = 0, LastName = faker.Name.LastName(Gender.Male), FirstName = faker.Name.FirstName(Gender.Male), Age = faker.Random.Int(18, 120) },
            new() { Id = 0, LastName = faker.Name.LastName(Gender.Female), FirstName = faker.Name.FirstName(Gender.Female), Age = faker.Random.Int(18, 120) },
            new() { Id = 0, LastName = faker.Name.LastName(Gender.Male), FirstName = faker.Name.FirstName(Gender.Male), Age = faker.Random.Int(18, 120) },
            new() { Id = 0, LastName = faker.Name.LastName(Gender.Female), FirstName = faker.Name.FirstName(Gender.Female), Age = faker.Random.Int(18, 120) },
            new() { Id = 0, LastName = faker.Name.LastName(Gender.Male), FirstName = faker.Name.FirstName(Gender.Male), Age = faker.Random.Int(18, 120) },
            new() { Id = 0, LastName = faker.Name.LastName(Gender.Female), FirstName = faker.Name.FirstName(Gender.Female), Age = faker.Random.Int(18, 120) },
            new() { Id = 0, LastName = faker.Name.LastName(Gender.Male), FirstName = faker.Name.FirstName(Gender.Male), Age = faker.Random.Int(18, 120) },
            new() { Id = 0, LastName = faker.Name.LastName(Gender.Female), FirstName = faker.Name.FirstName(Gender.Female), Age = faker.Random.Int(18, 120) },
            new() { Id = 0, LastName = faker.Name.LastName(Gender.Male), FirstName = faker.Name.FirstName(Gender.Male), Age = faker.Random.Int(18, 120) },
            new() { Id = 0, LastName = faker.Name.LastName(Gender.Female), FirstName = faker.Name.FirstName(Gender.Female), Age = faker.Random.Int(18, 120) },
            new() { Id = 0, LastName = faker.Name.LastName(Gender.Male), FirstName = faker.Name.FirstName(Gender.Male), Age = faker.Random.Int(18, 120) },
            new() { Id = 0, LastName = faker.Name.LastName(Gender.Female), FirstName = faker.Name.FirstName(Gender.Female), Age = faker.Random.Int(18, 120) },
            new() { Id = 0, LastName = faker.Name.LastName(Gender.Male), FirstName = faker.Name.FirstName(Gender.Male), Age = faker.Random.Int(18, 120) },
            new() { Id = 0, LastName = faker.Name.LastName(Gender.Female), FirstName = faker.Name.FirstName(Gender.Female), Age = faker.Random.Int(18, 120) },
            new() { Id = 0, LastName = faker.Name.LastName(Gender.Male), FirstName = faker.Name.FirstName(Gender.Male), Age = faker.Random.Int(18, 120) },
            new() { Id = 0, LastName = faker.Name.LastName(Gender.Female), FirstName = faker.Name.FirstName(Gender.Female), Age = faker.Random.Int(18, 120) },
            new() { Id = 0, LastName = faker.Name.LastName(Gender.Male), FirstName = faker.Name.FirstName(Gender.Male), Age = faker.Random.Int(18, 120) },
            new() { Id = 0, LastName = faker.Name.LastName(Gender.Female), FirstName = faker.Name.FirstName(Gender.Female), Age = faker.Random.Int(18, 120) },
            new() { Id = 0, LastName = faker.Name.LastName(Gender.Male), FirstName = faker.Name.FirstName(Gender.Male), Age = faker.Random.Int(18, 120) },
            new() { Id = 0, LastName = faker.Name.LastName(Gender.Female), FirstName = faker.Name.FirstName(Gender.Female), Age = faker.Random.Int(18, 120) },
            new() { Id = 0, LastName = faker.Name.LastName(Gender.Male), FirstName = faker.Name.FirstName(Gender.Male), Age = faker.Random.Int(18, 120) },
            new() { Id = 0, LastName = faker.Name.LastName(Gender.Female), FirstName = faker.Name.FirstName(Gender.Female), Age = faker.Random.Int(18, 120) },
            new() { Id = 0, LastName = faker.Name.LastName(Gender.Male), FirstName = faker.Name.FirstName(Gender.Male), Age = faker.Random.Int(18, 120) },
            new() { Id = 0, LastName = faker.Name.LastName(Gender.Female), FirstName = faker.Name.FirstName(Gender.Female), Age = faker.Random.Int(18, 120) },
            new() { Id = 0, LastName = faker.Name.LastName(Gender.Male), FirstName = faker.Name.FirstName(Gender.Male), Age = faker.Random.Int(18, 120) },
            new() { Id = 0, LastName = faker.Name.LastName(Gender.Female), FirstName = faker.Name.FirstName(Gender.Female), Age = faker.Random.Int(18, 120) },
            new() { Id = 0, LastName = faker.Name.LastName(Gender.Male), FirstName = faker.Name.FirstName(Gender.Male), Age = faker.Random.Int(18, 120) },
            new() { Id = 0, LastName = faker.Name.LastName(Gender.Female), FirstName = faker.Name.FirstName(Gender.Female), Age = faker.Random.Int(18, 120) },
            new() { Id = 0, LastName = faker.Name.LastName(Gender.Male), FirstName = faker.Name.FirstName(Gender.Male), Age = faker.Random.Int(18, 120) },
            new() { Id = 0, LastName = faker.Name.LastName(Gender.Female), FirstName = faker.Name.FirstName(Gender.Female), Age = faker.Random.Int(18, 120) },
            new() { Id = 0, LastName = faker.Name.LastName(Gender.Male), FirstName = faker.Name.FirstName(Gender.Male), Age = faker.Random.Int(18, 120) },
            new() { Id = 0, LastName = faker.Name.LastName(Gender.Female), FirstName = faker.Name.FirstName(Gender.Female), Age = faker.Random.Int(18, 120) },
        };
        /// <summary>Секции</summary>
        public static IEnumerable<Section> Sections { get; } = new Section[]
        {
          new() { Id = 01, Name = "Спорт", Order = 0 },
          new() { Id = 02, Name = "Nike", Order = 0, ParentId = 1 },
          new() { Id = 03, Name = "Under Armour", Order = 1, ParentId = 1 },
          new() { Id = 04, Name = "Adidas", Order = 2, ParentId = 1 },
          new() { Id = 05, Name = "Puma", Order = 3, ParentId = 1 },
          new() { Id = 06, Name = "ASICS", Order = 4, ParentId = 1 },
          new() { Id = 07, Name = "Для мужчин", Order = 1 },
          new() { Id = 08, Name = "Fendi", Order = 0, ParentId = 7 },
          new() { Id = 09, Name = "Guess", Order = 1, ParentId = 7 },
          new() { Id = 10, Name = "Valentino", Order = 2, ParentId = 7 },
          new() { Id = 11, Name = "Диор", Order = 3, ParentId = 7 },
          new() { Id = 12, Name = "Версачи", Order = 4, ParentId = 7 },
          new() { Id = 13, Name = "Армани", Order = 5, ParentId = 7 },
          new() { Id = 14, Name = "Prada", Order = 6, ParentId = 7 },
          new() { Id = 15, Name = "Дольче и Габбана", Order = 7, ParentId = 7 },
          new() { Id = 16, Name = "Шанель", Order = 8, ParentId = 7 },
          new() { Id = 17, Name = "Гуччи", Order = 9, ParentId = 7 },
          new() { Id = 18, Name = "Для женщин", Order = 2 },
          new() { Id = 19, Name = "Fendi", Order = 0, ParentId = 18 },
          new() { Id = 20, Name = "Guess", Order = 1, ParentId = 18 },
          new() { Id = 21, Name = "Valentino", Order = 2, ParentId = 18 },
          new() { Id = 22, Name = "Dior", Order = 3, ParentId = 18 },
          new() { Id = 23, Name = "Versace", Order = 4, ParentId = 18 },
          new() { Id = 24, Name = "Для детей", Order = 3 },
          new() { Id = 25, Name = "Мода", Order = 4 },
          new() { Id = 26, Name = "Для дома", Order = 5 },
          new() { Id = 27, Name = "Интерьер", Order = 6 },
          new() { Id = 28, Name = "Одежда", Order = 7 },
          new() { Id = 29, Name = "Сумки", Order = 8 },
          new() { Id = 30, Name = "Обувь", Order = 9 },
        };

        /// <summary>Бренды</summary>
        public static IEnumerable<Brand> Brands { get; } = new Brand[]
        {
        new() { Id = 1, Name = "Acne", Order = 0 },
        new() { Id = 2, Name = "Grune Erde", Order = 1 },
        new() { Id = 3, Name = "Albiro", Order = 2 },
        new() { Id = 4, Name = "Ronhill", Order = 3 },
        new() { Id = 5, Name = "Oddmolly", Order = 4 },
        new() { Id = 6, Name = "Boudestijn", Order = 5 },
        new() { Id = 7, Name = "Rosch creative culture", Order = 6 },
        };

        public static IEnumerable<Product> Products { get; } = new Product[]
        {
        new() { Id = 1, Name = "Белое платье", Price = 1025, ImageUrl = "product1.jpg", Order = 0, SectionId = 2, BrandId = 1 },
        new() { Id = 2, Name = "Розовое платье", Price = 1025, ImageUrl = "product2.jpg", Order = 1, SectionId = 2, BrandId = 1 },
        new() { Id = 3, Name = "Красное платье", Price = 1025, ImageUrl = "product3.jpg", Order = 2, SectionId = 2, BrandId = 1 },
        new() { Id = 4, Name = "Джинсы", Price = 1025, ImageUrl = "product4.jpg", Order = 3, SectionId = 2, BrandId = 1 },
        new() { Id = 5, Name = "Лёгкая майка", Price = 1025, ImageUrl = "product5.jpg", Order = 4, SectionId = 2, BrandId = 2 },
        new() { Id = 6, Name = "Лёгкое голубое поло", Price = 1025, ImageUrl = "product6.jpg", Order = 5, SectionId = 2, BrandId = 1 },
        new() { Id = 7, Name = "Платье белое", Price = 1025, ImageUrl = "product7.jpg", Order = 6, SectionId = 2, BrandId = 1 },
        new() { Id = 8, Name = "Костюм кролика", Price = 1025, ImageUrl = "product8.jpg", Order = 7, SectionId = 25, BrandId = 1 },
        new() { Id = 9, Name = "Красное китайское платье", Price = 1025, ImageUrl = "product9.jpg", Order = 8, SectionId = 25, BrandId = 1 },
        new() { Id = 10, Name = "Женские джинсы", Price = 1025, ImageUrl = "product10.jpg", Order = 9, SectionId = 25, BrandId = 3 },
        new() { Id = 11, Name = "Джинсы женские", Price = 1025, ImageUrl = "product11.jpg", Order = 10, SectionId = 25, BrandId = 3 },
        new() { Id = 12, Name = "Летний костюм", Price = 1025, ImageUrl = "product12.jpg", Order = 11, SectionId = 25, BrandId = 3 },
        };

        public static ICollection<Blog> Blogs { get; } = new Blog[]
        {
        new() { Id = 1, Name = "Блог №1", User = "Блогер №1" , Date = new DateTime(2015, 7, 20, 18, 30, 25), Rating = 4.5, ImageUrl = "blog-one.jpg", Text = "Содержимое блога №1" },
        new() { Id = 2, Name = "Блог №2", User = "Блогер №2" , Date = new DateTime(2016, 6, 21, 11, 30, 25), Rating = 3.5, ImageUrl = "blog-two.jpg", Text = "Содержимое блога №2" },
        new() { Id = 3, Name = "Блог №3", User = "Блогер №3" , Date = new DateTime(2017, 5, 19, 8, 30, 25), Rating = 5, ImageUrl = "blog-three.jpg", Text = "Содержимое блога №3" },
        new() { Id = 4, Name = "Блог №4", User = "Блогер №4" , Date = new DateTime(2018, 7, 10, 15, 30, 25), Rating = 2, ImageUrl = "man-one.jpg", Text = "Содержимое блога №4" },
        new() { Id = 5, Name = "Блог №5", User = "Блогер №5" , Date = new DateTime(2019, 8, 10, 15, 30, 25), Rating = 2.3, ImageUrl = "man-two.jpg", Text = "Содержимое блога №5" },
        new() { Id = 6, Name = "Блог №6", User = "Блогер №6" , Date = new DateTime(2020, 1, 10, 15, 30, 25), Rating = 2.8, ImageUrl = "man-three.jpg", Text = "Содержимое блога №6" },
        new() { Id = 1, Name = "Блог №7", User = "Блогер №7" , Date = new DateTime(2011, 12, 10, 15, 30, 25), Rating = 2, ImageUrl = "man-four.jpg", Text = "Содержимое блога №7" },
        };
    }
}
