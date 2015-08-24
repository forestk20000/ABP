﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Abp.Application.Services.Dto;
using Abp.Text.RegularExpressions;
using Abp.Web.Mvc.Localized;
using CMS.Domain.User;

namespace CMS.Application.User.Dto
{
    
    public class UserEditDto : IDoubleWayDto
    {
        public const int MinPasswordLength = 6;
        public const int MaxPasswordLength = 20;

        public Guid Id { get; set; }

        [LocalizedDisplay("Dto.UserName")]
        [Required]
        [StringLength(UserEntity.MaxUserNameLength)]
        [LocalizedRemote("CheckUserName", "Users", ErrorMessage = "Dto.DuplicateUserName")]
        public virtual string UserName { get; set; }

        [LocalizedDisplay("Dto.Password")]
        [StringLength(MaxPasswordLength, MinimumLength = MinPasswordLength)]
        public virtual string Password { get; set; }

        [LocalizedDisplay("Dto.ReenterPassword")]
        [StringLength(MaxPasswordLength, MinimumLength = MinPasswordLength)]
        [System.ComponentModel.DataAnnotations.Compare("Password")]
        public virtual string ConfimPassword { get; set; }

        [LocalizedDisplay("Dto.Email")]
        [Required]
        [LocalizedRegularExpression(RegexUtils.EmailPattern, ErrorMessage="Dto.InvaildEmail")]
        [StringLength(UserEntity.MaxEmailLength)]
        public virtual string Email { get; set; }

        [LocalizedDisplay("Dto.FirstName")]
        [Required]
        [StringLength(UserEntity.MaxFirstNameLength)]
        public virtual string FirstName { get; set; }

        [LocalizedDisplay("Dto.LastName")]
        [Required]
        [StringLength(UserEntity.MaxLastNameLength)]
        public virtual string LastName { get; set; }

        public virtual bool IsActive { get; set; }

        public virtual ICollection<UserRoleDto> UserRoles { get; set; }
    }
}
