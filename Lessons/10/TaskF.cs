using System;

namespace Lessons._10
{
    public class TaskF
    {
        class Exam
        {
            // Is mandatory.
            // Must be of length 4.
            // Must be used ExamCodeValidator.IsValid method to validate it.
            //[Required, MaxLength(4)]
            public string Code { get; set; }

            // Is mandatory.
            // Must be of maximum length 255.
            //[Required, MaxLength(255)]
            public string Description { get; set; }

            // Is mandatory.
            // Must be between 0 and 100.
            //[Required, Range(0, 100)]
            public decimal ScoreToPassInPercentages { get; set; }

            // Is mandatory.
            // Must be a valid email address.
            //[Required, RegularExpression("(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|"(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])")]
            public string EmailToSupport { get; set; }
        }

        class ExamCodeValidator
        {
            public bool IsValid(object @object)
            {
                //Cannot seem to import the entity framework
                return false;
            }
        }
    }
}