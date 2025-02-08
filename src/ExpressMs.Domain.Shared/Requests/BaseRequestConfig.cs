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
        public string? EmpCode { set; get; }
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
    public class PenalityRequestConfiguration : BaseRequestConfig
    {
        public override RequestsTypes RequestsTypes => RequestsTypes.Penality;
        public Guid PositionId { set; get; }
        public string? DepartmentName { set; get; }
        public string? PositionName { set; get; }
        public string? DirectManagerName { set; get; }
        public DateTime ViolationDate { set; get; }
        public string? ViolationDetails { set; get; }
        //for hr only
        public bool? AdminInvestigationReq { set; get; }
        public string? AdminInvestigationRecomm { set; get; }
        public string? HrRecomm { set; get; }
        public ViolationRepeatition ViolationRepeatition { set; get; }
        public double? NoOfDays { set; get; }

    }

    public class ResignRequestConfiguration : BaseRequestConfig
    {
        public override RequestsTypes RequestsTypes => RequestsTypes.Resign;
        public DateTime ResignDate { set; get; }
        public DateTime LastWorkDate { set; get; }
       //for managerApproval
       public DateTime? EditedLastWorkDate { set; get; }

    }
    public class ClearanceRequestFormConfiguration : BaseRequestConfig
    {
        public override RequestsTypes RequestsTypes => RequestsTypes.Clearance;
        public DateTime ClearanceDate { set; get; }
        public DateTime HiringDate { set; get; }
        public DateTime LastWorkDate { set; get; }
        public Guid PositionId { set; get; }
        public string DepartmentName { set; get; }
        public string? PositionName { set; get; }
    }
    public class RewardsRequestFormConfiguration : BaseRequestConfig
    {
        public override RequestsTypes RequestsTypes => RequestsTypes.Clearance;
        public int NoOfDays { set; get; }
    }
    public class OverTimeRequestFormConfiguration : BaseRequestConfig
    {
        //by manager
        public override RequestsTypes RequestsTypes => RequestsTypes.Clearance;
        public DateTime Date { set; get; }
        public string TimeFrom { set; get; }
        public string TimeTo { set; get; }
        public double Rate { set; get; } //1.35 -1.7-2
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
