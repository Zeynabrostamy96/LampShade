namespace _01_Farmework.Application
{
    public static class Roles
    {
        public const string Adminstrator = "1";
        public const string User = "2";
        public const string CurrentUploader = "3";
        public static string GetRoleBy(long id)
        {
            switch (id)
            {
                case 1:
                    return "مدیرسیستم";
                case 3:
                    return "محتوا گذار";
                default:
                    return "";
            }
        }
    }
}
