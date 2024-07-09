using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.implementation
{
    public class UnityService : IUnityService
    {
        public string getMessage(string result)
        {
            string message = "";
           switch (result)
            {
                case "success": {
                        message = " thành công"; break; 
                }
                case "error":
                    {
                        message = "Lỗi không xác định"; break;
                    }
                case "error_empty":
                    {
                        message = "Lỗi do đối tượng là null"; break;
                    }
                case "error_create":
                    {
                        message = "Tạo phần tử thất bại"; break;
                    }
                case "error_edit":
                    {
                        message = "Sửa phần tử thất bại"; break;
                    }
                case "error_delete":
                    {
                        message = "Xóa phần tử thất bại"; break;
                    }
            }
            return message;
        }
    }
}
