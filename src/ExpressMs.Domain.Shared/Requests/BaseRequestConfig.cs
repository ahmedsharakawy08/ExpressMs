using JsonSubTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ExpressMs.Requests
{
    public abstract class BaseRequestConfig
    {
        public abstract RequestsTypes RequestsTypes { get; }
        public Guid UserId { set; get; }
        public string? UserName { set; get; }
    }
    public  class VacationRequestConfiguration: BaseRequestConfig
    {
        public override RequestsTypes RequestsTypes => RequestsTypes.Vacation;
        public DateTime From { set; get; }
        public DateTime To { set; get; }
        public VacationType VacationType {  set; get; }
        public double NoOfDays { set; get; }
       
    }
    public class HiringRequestConfiguration : BaseRequestConfig
    {
        public override RequestsTypes RequestsTypes => RequestsTypes.Hiring;
        public Guid PositionId { set; get; }
        public string DepartmentName { set; get; }
        public string? PositionName { set; get; }
        public HiringRequestJobType HiringRequestJobType { set; get; }
        public Guid  DirectSupervisor { set; get; }
        public string? DirectSupervisorName { set; get; }
        public string? JobTitle { set; get; }
        public DateTime StartingData { set; get; }
        public string? JobRequirment { set; get; }

    }

    public static class AddDataFlowJsonConverterBuilderExtension
    {
        private static JsonConverter jsonConverter;
        public static JsonConverter DFJsonConverter
        {
            get
            {
                if (jsonConverter == null)
                {
                    jsonConverter = DataFlowJsonConverterProvider.CreateConverter();
                }
                return jsonConverter;
            }
        }

        public static JsonSerializerSettings AddDataFlowJsonConverter(this JsonSerializerSettings settings)
        {
            settings.Converters.Add(DFJsonConverter);
            settings.NullValueHandling = NullValueHandling.Ignore;

            return settings;

        }

    }
    public static class DataFlowJsonConverterProvider
    {
        public static JsonConverter CreateConverter()
        {
            var converterBuilder = JsonSubtypesConverterBuilder
                                  .Of<BaseRequestConfig>(nameof(BaseRequestConfig.RequestsTypes));

            var types = typeof(BaseRequestConfig).GetInheritingClasses();

            foreach (var type in types)
            {

                var instance = (BaseRequestConfig)Activator.CreateInstance(type);
                converterBuilder = converterBuilder
                                  .RegisterSubtype(type, instance.RequestsTypes);
            }
            return converterBuilder.Build();
        }


    }
    public static class TypeExtensionGetInheriting
    {
        public static IEnumerable<Type> GetInheritingClasses(this Type MyType)
        {
            return Assembly.GetAssembly(MyType)
                           .GetTypes()
                           .Where(TheType => TheType.IsClass
                              && !TheType.IsAbstract && TheType.IsSubclassOf(MyType));
        }
    }
}
