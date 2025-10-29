using System.ComponentModel.DataAnnotations.Schema;
using DoctorAppointment.Domain.Entities.Common;
using DoctorAppointment.Domain.Entities.DoctorAppointmentEntities;
using DoctorAppointment.Domain.Entities.Enums;
using Microsoft.AspNetCore.Identity;

namespace ResumeProfile.Domain.Entities.IdentityEntities
{
    public class User : IdentityUser<long>,ICreatedEntity,IModifiedEntity, ISoftDeleted
    {
        /// <summary>
        /// نام
        /// </summary>
        public string? FirstName { get; set; }
        /// <summary>
        /// نام خانوادگی
        /// </summary>
        public string? LastName { get; set; }

        [NotMapped]
        public string FullName => $"{FirstName ?? ""} {LastName ?? ""}";
        /// <summary>
        /// جنسیت
        /// </summary>
        public EnumGenderType Gender { get; set; }
        /// <summary>
        /// کدملی
        /// </summary>
        public required string NationalCode { get; set; }
        /// <summary>
        /// تاریخ تولد
        /// </summary>
        public DateTime? BirthDate { get; set; }
        /// <summary>
        /// نام پدر
        /// </summary>
        public string? FatherName { get; set; }
        /// <summary>
        /// شماره موبایل
        /// </summary>
        public required string MobileNumber { get; set; }   
        /// <summary>
        /// کد تایید پیامکی
        /// </summary>
        public string? Otp { get; set; }  
        /// <summary>
        /// تاریخ ایجاد کد پیامکی
        /// </summary>  
        public DateTime? OtpCreated { get; set; }
        /// <summary>
        /// تصویر
        /// </summary>
        public byte[]? Image { get; set; }

        #region Navigation
        public virtual ICollection<Doctor>? Doctors { get; set; }
        public virtual ICollection<Patient>? Patients { get; set; }
        public virtual ICollection<UserClaim> Claims { get; set; }
        public virtual ICollection<UserLogin> Logins { get; set; }
        public virtual ICollection<UserToken> Tokens { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
        #endregion

    }
}
