namespace CRM_Micro_Credit.Models
{
	public class Error
	{
		public int ErrorCode { get; set; }

		private string message;
		public string Message
		{
			get
			{
				switch (ErrorCode)
				{
					case 404:
						message = "Not Found";
						break;
					case 400:
						message = "Bad Request";
						break;
					default:
						message = "Error";
						break;
				}

				return message;
			}
		}

		public Error(int ErrorCode)
		{
			this.ErrorCode = ErrorCode;
		}
	}
}
