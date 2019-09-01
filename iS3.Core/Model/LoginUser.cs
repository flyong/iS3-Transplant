using iS3.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iS3.Core.Model
{
    public partial class LoginUser
    {

        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsRememberMe { get; set; }
    }

    public enum LoginResultEnum {
        Success, UserNameUnExists, VerifyCodeError, UserNameOrPasswordError

    }
    public class EnumExtension {
        public static string GetEnumDescription(LoginResultEnum result)
        {
            switch (result){
                case LoginResultEnum.Success:return "登录成功";
                case LoginResultEnum.UserNameUnExists: return "用户名不存在";
                case LoginResultEnum.VerifyCodeError: return "验证码错误";
                case LoginResultEnum.UserNameOrPasswordError: return "用户名或密码错误";
                default:return "";
            }
        }
    }


}
