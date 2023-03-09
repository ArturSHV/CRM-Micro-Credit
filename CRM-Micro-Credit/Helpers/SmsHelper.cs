using CRM_Micro_Credit.Entity.Models;
using CRM_Micro_Credit.Entity;

namespace CRM_Micro_Credit.Helpers
{
    public class SmsHelper
    {
        private string CodeGenerator()
        {
            return "334";
        }


        public string SendSMS(string mobile, DataContext dataContext)
        {
            string code = string.Empty;

            var message = dataContext.ValidationCodes.Where(x => (x.Mobile == mobile)
            && (x.Date.Day == DateTime.Now.Day) && (x.Date.Hour == DateTime.Now.Hour)
            && ((DateTime.Now.Minute - x.Date.Minute) > 1)).FirstOrDefault();

            if (message == null)
            {
                code = CodeGenerator();
                dataContext.ValidationCodes.Add(
                new ValidationCode()
                {
                    Code = code,
                    Date = DateTime.Now,
                    Mobile = mobile
                });
                dataContext.SaveChanges();
                //далее отправка смс на телефон
            }
            else
            {
                code = message.Code;
            }

            return code;
        }
    }
}
