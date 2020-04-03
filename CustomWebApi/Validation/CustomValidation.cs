using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomWebApi.Model;
using FluentValidation;

namespace CustomWebApi.Validation
{
    public class CustomValidation:AbstractValidator<Custom>
    {
        //验证
        public CustomValidation()
        {
            RuleFor(p => p.CustomName).NotNull().WithMessage("姓名不能为空");
            RuleFor(p => p.CustomPhone).NotNull().Length(11).WithMessage("电话必须是11位");
            RuleFor(p => p.CustomSex)
                .NotNull()
                .WithMessage("性别为空或者格式错误");
            RuleFor(p => p.CustomIdCrad)
                .NotNull()
                .WithMessage("身份证为15位或者18位");
        }   
    }
}
