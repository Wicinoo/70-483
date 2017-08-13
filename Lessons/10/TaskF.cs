using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Lessons._10
{
    public class TaskF
    {
        public static void Run()
        {
            var exam = new Exam()
            {
                Code = "423563",
                Description = "ASDASDASD",
                ScoreToPassInPercentages = 5,
                EmailToSupport = "xxxxasdfs@ahaha.cz"
            };

            var valResults = new List<ValidationResult>();

            Validator.TryValidateObject(exam, new ValidationContext(exam), valResults);

            Console.WriteLine(valResults.ToString());
        }
    }

    class Exam
    {
        [Required]
        [StringLength(4, MinimumLength = 4)]
        [CustomValidation(typeof(ExamCodeValidator), "IsValid")]
        public string Code { get; set; }

        [Required]
        [MaxLength(255)]
        public string Description { get; set; }

        [Required]
        [Range(0, 100)]
        public decimal ScoreToPassInPercentages { get; set; }

        [Required]
        [EmailAddress]
        public string EmailToSupport { get; set; }
    }

    class ExamCodeValidator
    {
        public ValidationResult IsValid(string @object, ValidationContext context)
        {
            foreach (char c in @object)
            {
                if (!Char.IsDigit(c))
                {
                    return new ValidationResult(null);
                }
            }

            return ValidationResult.Success;
        }
    }
}
