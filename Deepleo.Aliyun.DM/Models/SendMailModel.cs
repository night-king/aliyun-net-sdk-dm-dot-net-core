using System;
using System.ComponentModel.DataAnnotations;

namespace Deepleo.Aliyun.DM.Models
{
    public class SendMailModel
    {
        [Display(Name = "�ռ���")]
        public string Email { get; set; }

        [Display(Name ="�����˳ƺ�")]
        public string FromAlias { get; set; }

        [Display(Name = "�ʼ�����")]
        public string Subject { get; set; }

        [Display(Name = "�ʼ�����")]
        public string Content { get; set; }
    }
}