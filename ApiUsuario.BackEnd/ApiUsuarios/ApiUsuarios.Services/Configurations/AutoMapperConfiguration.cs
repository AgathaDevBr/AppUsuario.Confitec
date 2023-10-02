namespace ApiUsuarios.Services.Configurations
{
    public class AutoMapperConfiguration
    {
        public static void AddAutoMapper(WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
