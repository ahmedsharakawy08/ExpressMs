using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Volo.Abp.DependencyInjection;

namespace ExpressMs.Messages
{
    public class WhatsAppMessageSender : IWhatsAppMessageSender,ITransientDependency
    {
        TwilioConfig TwilioConfig = null;
        public WhatsAppMessageSender(IOptions<TwilioConfig> options)
        {
            TwilioConfig = options.Value;
        }
        public void SendMultimediaMesssage(string reciever, string Url, string messageBody)
        {
            Url = "https://upload.wikimedia.org/wikipedia/commons/4/47/PNG_transparency_demonstration_1.png";
            TwilioClient.Init(TwilioConfig.Accountsid, TwilioConfig.AccountSecret);
            var twiliioclient = TwilioClient.GetRestClient;
            var mes = MessageResource.Create(to: new PhoneNumber("whatsapp:2+" + reciever),
                   from: new PhoneNumber(TwilioConfig.FromNumber),
                   mediaUrl: new List<Uri> { new Uri(Url) },
                   body: messageBody
                   );
        }

        public void SendTextMessage(string reciever, string message)
        {
            TwilioClient.Init(TwilioConfig.Accountsid, TwilioConfig.AccountSecret);
            var twiliioclient = TwilioClient.GetRestClient;
            var mess = MessageResource.Create(to: new PhoneNumber("whatsapp:"+ reciever),
                from: new PhoneNumber(TwilioConfig.FromNumber),
                body: message);
        }
    }
}
