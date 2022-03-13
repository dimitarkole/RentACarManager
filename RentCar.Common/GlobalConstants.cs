namespace RentCar.Common
{
    public static class GlobalConstants
    {
        public const string SystemName = "RentCar";
        public const string AdministrationArea = "Administration";

        public const string LongDateFormat = "dd/MM/yyyy HH:mm";
        public const int PaginationOffset = 5;
        public const int DefaultPage = 1;
        public const int DefaultItemPerPage = 10;
        public const string QueryStringDelimiter = "&";
        public const string PageKey = "page";
        public const string ItemsPerPageKey = "itemsPerPage";

        public static class Roles
        {
            public const string Administrator = "Administrator";

            public const string Client = "Client";
        }

        public static class Email
        {
            public const string SystemEmail = "RentCar@gmail.com";

            public const string ApiKey = "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";
        }
    }
}
