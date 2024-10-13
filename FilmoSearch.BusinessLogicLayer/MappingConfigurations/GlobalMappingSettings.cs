using Mapster;

namespace FilmoSearch.BusinessLogicLayer.MappingConfigurations
{
    public class GlobalMappingSettings : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            TypeAdapterConfig.GlobalSettings.Default.MaxDepth(2);
            TypeAdapterConfig.GlobalSettings.Default.PreserveReference(true);
        }
    }
}
