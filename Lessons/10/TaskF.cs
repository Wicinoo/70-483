using System;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lessons._10
{
    /*
     * Use attributes from DataAnnotations to set validation rules for entity Exam.
     */

    internal class TaskF
    {
        public static void Run()
        {
            var examCodeValidator = new ExamCodeValidator();
            var exam1 = new Exam
            {
                Code = "blaaa",
                Description = "aaa",
                EmailToSupport = "test@fnz.co.uk",
                ScoreToPassInPercentages = 100m
            };
            var exam2 = new Exam
            {
                Code = "blah",
                Description = new StringBuilder().Append('a', 256).ToString(),
                EmailToSupport = "test@fnz.co.uk",
                ScoreToPassInPercentages = 99m
            };
            var exam3 = new Exam
            {
                Code = "blah",
                Description = "aaa",
                EmailToSupport = "test@fnz.co.uk",
                ScoreToPassInPercentages = -1m
            };
            var exam4 = new Exam
            {
                Code = "blah",
                Description = "aaa",
                EmailToSupport = "test@ddd@fnz.co.uk",
                ScoreToPassInPercentages = 99m
            };
            var exam5 = new Exam
            {
                Code = "blah",
                Description = "aaa",
                EmailToSupport = "test@fnz.co.uk",
                ScoreToPassInPercentages = 99m
            };
            Console.WriteLine(examCodeValidator.IsValid(exam1));
            Console.WriteLine(examCodeValidator.IsValid(exam2));
            Console.WriteLine(examCodeValidator.IsValid(exam3));
            Console.WriteLine(examCodeValidator.IsValid(exam4));
            Console.WriteLine(examCodeValidator.IsValid(exam5));
        }

        private class Exam
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
            [Range(0, 100), Required]
            public decimal ScoreToPassInPercentages { get; set; }

            // Is mandatory.
            // Must be a valid email address.
            [EmailAddress, Required]
            public string EmailToSupport { get; set; }
        }
        
        private class ExamCodeValidator
        {
            public bool IsValid(object @object)
            {
                var validatorContext = new ValidationContext(@object, null, null);
                return Validator.TryValidateObject(@object, validatorContext, null, true);
            }
        }
    }
}
