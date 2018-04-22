using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Data.Entity;
using AHPortfolio.Models;

namespace AHPortfolio.Models
{
    [Table("User")]
    public class User
    {
        [Index]
        public int userId { get; set; }
        public string userFirstName { get; set; }
        public string userLastName { get; set; }
        public string userMiddleName { get; set; }
        public string userFullName
        {
            get
            {
                return (userFirstName + " " + userLastName).ToString();
            }
            set
            {
                userFullName = value;
            }
        }
        public Address userAddress { get; set; }
        public string userEmail { get; set; }
        public bool userUSAuthorized { get; set; }
    }

    [Table("Employment")]
    public class Employment : Date
    {
        [Index]
        public int employmentId { get; set; }
        public Company employmentName { get; set; }
        public string employmentPosition { get; set; }
        public DateTime employmentStartDate { get; set; }
        public DateTime employmentEndDate { get; set; }
        public TimeDuration employmentDuration
        {
            get
            {
                int years = 0;
                int months = 0;
                int days = 0;
                int hours = 0;
                int minutes = 0;
                int seconds = 0;
                int milliseconds = 0;
                GetElapsedTime(employmentStartDate, employmentEndDate, out years, out months, out days, out hours, out minutes, out seconds, out milliseconds);
                TimeDuration employmentDuration = new TimeDuration
                {
                    years = years,
                    months = months,
                    days = days,
                    hours = hours
                };
                return employmentDuration;
            }
            set
            {
                employmentDuration = value;
            }
        }
        public Address employmentAddress { get; set; }
        public bool employmentCurrently { get; set; }
        public IList<Responsibilities> employmentResponsibilities { get; set; }
    }

    public class TimeDuration
    {
        public int years { get; set; }
        public int months { get; set; }
        public int days { get; set; }
        public int hours { get; set; }

    }

    [Table("Address")]
    public class Address
    {
        [Index]
        public int addressId { get; set; }
        public string addressStreet1 { get; set; }
        public string addressStreet2 { get; set; }
        public string addressCity { get; set; }
        public string addressState { get; set; }
        public long addressZip { get; set; }

    }

    [Table("Company")]
    public class Company
    {
        [Index]
        public int companyId { get; set; }
        public string companyName { get; set; }
        public Address companyAddress { get; set; }
        public string companyWebsite { get; set; }
        public string companyTelephone { get; set; }
        public string companyIndustry { get; set; }
        public string companyType { get; set; }
    }

    [Table("Skills")]
    public class Skills
    {
        [Index]
        public int skillId { get; set; }
        public string skillName { get; set; }
        public int skillYears { get; set; }
        public SkillLevel skillLevel { get; set; }
        public string skillDescription { get; set; }

    }

    public enum SkillLevel
    {
        NA,
        Fundamental,
        Novice,
        Intermediate,
        Advanced,
        Expert
    }

    [Table("Responsibilities")]
    public class Responsibilities
    {
        [Index]
        public int responsibilityId { get; set; }
        public Company responsibilityCompany { get; set; }
        public string responsibilityDescription { get; set; }
    }

    [Table("Education")]
    public class Education
    {
        public int educationId { get; set; }
        public Schools educationSchool { get; set; }
        public DegreeTypes educationDegree { get; set; }
        public string educationFocus { get; set; }
        public bool educationComplete { get; set; }
        public IList<Skills> educationSkills { get; set; }

    }

    public class Schools : Company
    {
        public int schoolId { get; set; }
        public IList<SchoolTypes> schoolType { get; set; }

    }
    public enum SchoolTypes
    {
        Private,
        Public,
        Vocational,
        Technical,
        Four_Year,
        Two_Year,
        Online,
        University

    }
    public enum DegreeTypes
    {
        Diploma,
        Certification,
        Associates,
        Bachelors,
        Graduates,
        Professional
    }
}
public partial class EmploymentDBEntities : DbContext
{
    public virtual DbSet<Employment> Employments { get; set; }
    public virtual DbSet<Address> Addresses { get; set; }
    public virtual DbSet<Company> Companies { get; set; }
    public virtual DbSet<Skills> Skill { get; set; }
    public virtual DbSet<Responsibilities> Responsibility { get; set; }
}

