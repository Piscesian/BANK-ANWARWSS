using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nasabah.ViewModel
{
    public class AjaxViewModel
    {
        public AjaxViewModel()
        {
        }

        public AjaxViewModel(bool isSuccess, object data, string message)
        {
            IsSuccess = isSuccess;
            Data = data;
            Message = message;
        }

        public void SetValues(bool isSuccess, object data, string message)
        {
            IsSuccess = isSuccess;
            Data = data;
            Message = message;
        }

        public AjaxViewModel(bool isSuccess, object data, string message, bool isRedirect, string redirectUrl)
        {
            IsSuccess = isSuccess;
            Data = data;
            Message = message;
            IsRedirect = isRedirect;
            RedirectUrl = redirectUrl;
        }

        public void SetValues(bool isSuccess, object data, string message, bool isRedirect, string redirectUrl)
        {
            IsSuccess = isSuccess;
            Data = data;
            Message = message;
            IsRedirect = isRedirect;
            RedirectUrl = redirectUrl;
        }

        public bool IsSuccess { get; set; }
        public object Data { get; set; }
        public int ItemsCount { get; set; }
        public string Message { get; set; }
        public string RedirectUrl { get; set; }
        public bool IsRedirect { get; set; }

    }



    public class Configuration
    {
        public AppConfiguration AppConfiguration { get; set; }
    }
    public class AppConfiguration
    {
        public string ApiServerUrl { get; set; }
    }
}
