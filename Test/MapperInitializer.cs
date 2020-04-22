namespace TestingLiftInfo.Services.Data.Common
{
    using System.Reflection;
    using TestingLiftInfo.Services.Mapping;
    using TestingLiftInfo.Web.ViewModels.Administration.Cities;

    public static class MapperInitializer
    {
        public static void InitializeMapper()
        {
            AutoMapperConfig.RegisterMappings(
                typeof(CitiesService).GetTypeInfo().Assembly,
                typeof(CityDetailViewModel).GetTypeInfo().Assembly);
        }
    }
}
