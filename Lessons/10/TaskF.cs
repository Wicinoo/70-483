using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons._10
{
    public class TaskF
    {
        public static void Run()
        {
            Exam exam = new Exam() { Code = "EX01", Description = "Exam 01", ScoreToPassInPercentages = 90, EmailToSupport = "ex01@exam.com" };
            Exam exam2 = new Exam() { Code = "aX02", Description = "Exam 02", ScoreToPassInPercentages = 190, EmailToSupport = "ex02exam.com" };
            Exam exam3 = new Exam() { Code = "EX03", ScoreToPassInPercentages = -5, EmailToSupport = "ex03@examcom" };

            Validate(exam);
            Validate(exam2);
            Validate(exam3);
        }

        public static void Validate<T>(T entity)
        {
            var context = new ValidationContext(entity, null, null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(entity, context, results, true);

            if (!isValid)
            {
                Console.WriteLine($"Invalid - {entity.ToString()}");
                foreach (var validationResult in results)
                {
                    Console.WriteLine(validationResult.ErrorMessage);
                }
            }
            else
            {
                Console.WriteLine($"Is valid - {entity.ToString()}");
            }
            Console.WriteLine("");
        }
    }

    public class Exam
    {
        // Is mandatory.
        // Must be of length 4.
        // Must be used ExamCodeValidator.IsValid method to validate it.
        [StringLength(4), Required]
        [CustomValidation(typeof(ExamCodeValidator), "IsValid")]
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

        public override string ToString()
        {
            return $"{Code} : {Description} : {ScoreToPassInPercentages} : {EmailToSupport}";
        }
    }

    public class ExamCodeValidator
    {
        public static ValidationResult IsValid(object @object)
        {
            string code = (string)@object;
            if (code != null && code.StartsWith("EX"))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Exam code must start with EX.");
            }
        }
    }
}
