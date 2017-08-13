using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Lessons._10
{
    public class TaskF
    {
        public static void Run()
        {
        }
    }

    public partial class Exam
    {
        // Is mandatory.
        // Must be of length 4.
        // Must be used ExamCodeValidator.IsValid method to validate it.
        [StringLength(4), Required]
        public string Code { get; set; }

        // Is mandatory.
        // Must be of maximum length 255.
        [MaxLength(255), Required]
        public string Description { get; set; }

        // Is mandatory.
        // Must be between 0 and 100.
        [Range(0,100)]
        public decimal ScoreToPassInPercentages { get; set; }

        // Is mandatory.
        // Must be a valid email address.
        [Email, Required]
        public string EmailToSupport { get; set; }
    }

    public class ExamCodeValidator
    {
        public bool IsValid(object @object)
        {
            var vc = new ValidationContext(@object, null, null);
            return Validator.TryValidateObject(@object, vc, null, true);
        }
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property,
    AllowMultiple = false, Inherited = true)]
    public class EmailAttribute :  RegularExpressionAttribute
    {
        public EmailAttribute()
            : base(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")
        { }
    }
}