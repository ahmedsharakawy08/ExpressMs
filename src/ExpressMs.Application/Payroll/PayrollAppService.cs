using ExpressMs.HtmlConverter;
using ExpressMs.Messages;
using ExpressMs.Payroll.Dtos;
using ExpressMs.PayrollEntities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace ExpressMs.Payroll
{
    public class PayrollAppService:ExpressMsAppService
    {
        public readonly IPayrollPayslipRepository _payrollPaySlipRepo;
        private readonly IWhatsAppMessageSender _whatsAppMessageSender;
        public PayrollAppService(IPayrollPayslipRepository payrollPaySlipRepo, 
                                 IWhatsAppMessageSender whatsAppMessageSender)
        {
            _payrollPaySlipRepo = payrollPaySlipRepo;
            _whatsAppMessageSender = whatsAppMessageSender;
        }
        public async Task<List<PayrollPaySlip>> SendMonthyPayroll(List<PayrollPayslipDto> input,string month)
        {
            var dic = input.ToDictionary(obj => obj.MobileNumber, obj => obj.HtmlContent);
            var urlNumberDic=HtmlToImageConverter.ConvertandSaveToFolder(dic, month);

            var payrollPayslip = ObjectMapper.Map<List<PayrollPayslipDto>, List<PayrollPaySlip>>(input);
            await _payrollPaySlipRepo.InsertManyAsync(payrollPayslip);

            foreach (var data in urlNumberDic)
            {
                _whatsAppMessageSender.SendMultimediaMesssage(data.Value, data.Key, "PaySlip of month"+ month);
            }
            return payrollPayslip;

        }
    }
 
}
