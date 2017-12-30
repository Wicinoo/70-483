using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Lessons._10
{
    public class TaskF
    {
        public static void Run()
        {
            var exam = new Exam
            {
                Code = "5487",
                Description = "blah",
                ScoreToPassInPercentages = 55m,
                EmailToSupport = "blah@blah.com"
            };

            var validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(exam, new ValidationContext(exam), validationResults, true);
            Console.WriteLine(validationResults.Count);
        }
    }

    class Exam
    {
        [Required]
        [StringLength(4, MinimumLength = 4)]
        [CustomValidation(typeof(ExamCodeValidator),"IsValid")]
        public string Code { get; set; }

        [Required]
        [StringLength(255)]
        public string Description { get; set; }

        [Required]
        [Range(0,100)]
        public decimal ScoreToPassInPercentages { get; set; }

        [Required]
        [EmailAddress()]
        public string EmailToSupport { get; set; }
    }

    public class ExamCodeValidator
    {
        public static ValidationResult IsValid(object @object)
        {
            return ValidationResult.Success;
        }
    }
}
