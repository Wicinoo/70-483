using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Lessons._10
{
	public class Exam
	{
		// Is mandatory.
		// Must be of length 4.
		// Must be used ExamCodeValidator.IsValid method to validate it.
		[Required]
		[StringLength(4, MinimumLength = 4)]
		[CustomValidation(typeof(ExamCodeValidator), "IsValid")]
		public string Code { get; set; }

		// Is mandatory.
		// Must be of maximum length 255.
		[Required]
		[MaxLength(255)]
		public string Description { get; set; }

		// Is mandatory.
		// Must be between 0 and 100.
		[Required]
		[Range(0, 100)]
		public decimal ScoreToPassInPercentages { get; set; }

		// Is mandatory.
		// Must be a valid email address.
		[Required]
		[EmailAddress]
		public string EmailToSupport { get; set; }
	}

	public class ExamCodeValidator
	{
		public static ValidationResult IsValid(object @object)
		{
			return System.ComponentModel.DataAnnotations.ValidationResult.Success;
		}
	}

	public class TaskF
	{

		public static void Run()
		{
			var exam = new Exam() { Code = "1324", Description = "a", ScoreToPassInPercentages = 1M, EmailToSupport = "Tomas.Brychta@fnz.co.uk" };

			var results = new List<ValidationResult>();
			var context = new ValidationContext(exam, null, null);
			Validator.TryValidateObject(exam, context, results, true);
			
		}
	}
}
