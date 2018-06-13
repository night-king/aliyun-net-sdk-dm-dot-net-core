using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Core.Profile;
using Aliyun.Acs.Dm.Transform.Model.V20151123;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deepleo.Aliyun.DM
{
    public interface IEmailSender
    {
        bool SendEmail(string email, string fromAlias, string subject, string message,out string err);
    }

    // This class is used by the application to send email for account confirmation and password reset.
    // For more details see https://go.microsoft.com/fwlink/?LinkID=532713
    public class EmailSender : IEmailSender
    {
        private AppSettings _appSettings { get; set; }

        public EmailSender(IOptions<AppSettings> settings)
        {
            _appSettings = settings.Value;
        }
        public bool SendEmail(string email,string fromAlias, string subject, string message, out string err)
        {
            var isSuccessful = false;
            var regionID = _appSettings.RegionID;
            var aliAccessKey = _appSettings.AliAccessKey;
            var aliAccessKeySecret = _appSettings.AliAccessKeySecret;
            var aliMailAccount = _appSettings.AliMailAccount;

            IClientProfile profile = DefaultProfile.GetProfile(regionID, aliAccessKey, aliAccessKeySecret);
            IAcsClient client = new DefaultAcsClient(profile);
            SingleSendMailRequest request = new SingleSendMailRequest();
            try
            {
                request.AccountName = aliMailAccount;
                request.FromAlias = fromAlias;
                request.AddressType = 1;
                request.ReplyToAddress = true;
                request.ToAddress = email;
                request.Subject = subject;
                request.HtmlBody = message;
                SingleSendMailResponse httpResponse = client.GetAcsResponse(request);
                if (httpResponse.HttpResponse.Status == 200)
                {
                    err = "send email successfully";
                    isSuccessful = true;
                }
                else
                {
                    err = "failed, status code:" + httpResponse.HttpResponse.Status.ToString();
                    isSuccessful = false;
                }
            }
            catch (ServerException ex)
            {
                err = ex.Message;
                isSuccessful = false;
            }
            catch (ClientException ex)
            {
                err = ex.Message;
                isSuccessful = false;
            }
            return isSuccessful;
        }
    }
}
