using System;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lessons._10
{
    internal class TaskF
    {
        public static void Run()
        {
            var examCodeValidator = new ExamCodeValidator();
            var exam1 = new Exam
            {
                Code = "12345",
                Description = "asdasdasd",
                ScoreToPassInPercentages = 80,
                EmailToSupport = "abc@abc.cz"
            };
            var exam2 = new Exam
            {
                Code = "1234",
                Description = "asdasdasd",
                ScoreToPassInPercentages = -10,
                EmailToSupport = "abc@abc.cz"
            };
            var exam3 = new Exam
            {
                Code = "1234",
                Description = "asdasdasd",
                ScoreToPassInPercentages = 70,
                EmailToSupport = "abc@abc.cz"
            };
            
            Console.WriteLine(examCodeValidator.IsValid(exam1));
            Console.WriteLine(examCodeValidator.IsValid(exam2));
            Console.WriteLine(examCodeValidator.IsValid(exam3));
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