namespace IOCExtension
{
    public static class IOCExtension
    {
        public static IServiceCollection AddHumanTypes(this IServiceCollection services)
        => services.AddSingleton<>();
    }
}
