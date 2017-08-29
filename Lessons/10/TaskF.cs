//F.Use attributes from DataAnnotations to set validation rules for entity Exam.

//    class Exam
//{
//    // Is mandatory.
//    // Must be of length 4.
//    // Must be used ExamCodeValidator.IsValid method to validate it.
//    public string Code { get; set; }

//    // Is mandatory.
//    // Must be of maximum length 255.
//    public string Description { get; set; }

//    // Is mandatory.
//    // Must be between 0 and 100.
//    public decimal ScoreToPassInPercentages { get; set; }

//    // Is mandatory.
//    // Must be a valid email address.
//    public string EmailToSupport { get; set; }
//}

//class ExamCodeValidator
//{
//    public bool IsValid(object @object)
//    {
//        throw new NotImplementedException();
//    }
//} 


using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons._10
{
    static class TaskF
    {
        public static void Run()
        {
            var entityPass = new Exam() {
                Code = "1",
                Description = "asdf",
                EmailToSupport = "sdfa@sdf.cz",
                ScoreToPassInPercentages = 10 };

            var entityWrong = new Exam() {
                Code = "12345",
                Description = new string('a', 256),
                EmailToSupport = "sdfasdf.cz",
                ScoreToPassInPercentages = 101 };

            var validator = GenericValidator<Exam>.Validate(entityPass);
            PrintResult(validator);
            var validator2 = GenericValidator<Exam>.Validate(entityWrong);
            PrintResult(validator2);
        }

        private static void PrintResult(IList<ValidationResult> validator)
        {
            Console.WriteLine("Validation results");
            if (validator.Any())
            {
                foreach (var item in validator)
                {
                    Console.WriteLine($"{item.ErrorMessage}");
                }
            }
            else
            {
                Console.WriteLine("Without error");
            }
        }
    }

    static class GenericValidator<T>
    {
        public static IList<ValidationResult> Validate(T entity)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(entity, null, null);
            Validator.TryValidateObject(entity, context, results, true);
            return results;

        }
    }

    public class ExamCodeValidator
    {
        public static ValidationResult IsValid(object @object)
        {
            string value = (string)@object;
            if (value!="1")
            {
                return new ValidationResult("ExamCodeValidator error");
            }
            return ValidationResult.Success;
        }
    }
    class Exam
    {
        // Is mandatory.
        // Must be of length 4.
        // Must be used ExamCodeValidator.IsValid method to validate it.
        [Required, MaxLength(4), CustomValidation(typeof(ExamCodeValidator), "IsValid")]
        public string Code { get; set; }

        // Is mandatory.
        // Must be of maximum length 255.
        [Required, MaxLength(255)]
        public string Description { get; set; }

        // Is mandatory.
        // Must be between 0 and 100.
        [Required, Range(0, 100)]
        public decimal ScoreToPassInPercentages { get; set; }

        // Is mandatory.
        // Must be a valid email address.
        [Required, EmailAddress]
        public string EmailToSupport { get; set; }
    }
}

