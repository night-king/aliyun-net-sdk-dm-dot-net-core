using System;
using System.ComponentModel.DataAnnotations;

namespace Deepleo.Aliyun.DM.Models
{
    public class SendMailModel
    {
        [Display(Name = "收件人")]
        public string Email { get; set; }

        [Display(Name ="发件人称呼")]
        public string FromAlias { get; set; }

        [Display(Name = "邮件主题")]
        public string Subject { get; set; }

        [Display(Name = "邮件内容")]
        public string Content { get; set; }
    }
}