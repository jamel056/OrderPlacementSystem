namespace O.Common
{
    public class Routes
    {
        public const string Root = "api";

        public static class Orders
        {
            public const string Base = Root + "/orders";

            public const string Place = Base;

            public const string Edit = Base + "/{id}";

            public const string Delete = Base + "/{id}";

            public const string Find = Base + "/{id}";

            public const string FindByName = Base;
        }
    }
}
