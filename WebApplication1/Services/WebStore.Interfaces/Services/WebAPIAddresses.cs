namespace WebStore.Interfaces.Services
{
    public static class WebAPIAddresses
    {
        public static class V1
        {
            public const string Employees = "api/employees";
            public const string Orders = "api/orders";
            public const string Products = "api/products";
            public const string Values = "api/values";
            public const string Blogs = "api/blogs";

            public static class Identity
            {
                public const string Users = "api/v1/identity/users";
                public const string Roles = "api/v1/identity/roles";
            }
        }
    }
}
