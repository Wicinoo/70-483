using System;
using System.Collections.Generic;
using System.Linq;

using Castle.Core.Internal;

namespace Lessons._08
{
    /// <summary>
    /// Have enum types DeveloperType and DeveloperSkillType.
    /// Uncomment lines with [RequiredSkill(...)].
    /// Implement RequiredSkill attribute.
    /// Create an extension method GetSkills():
    ///     IEnumerable<DeveloperSkillType> GetSkills() for DeveloperType type.
    /// Print out all skills for every developer type to the console. 
    /// Use static class Enum to get all values of DeveloperType.
    /// </summary>
    public class TaskA
    {
        public static void Run()
        {
            var vals = typeof(DeveloperType).GetEnumValues();

            foreach (var val in vals)
            {
                Console.WriteLine($"{val}");
                ((DeveloperType)val).GetSkills().ForEach(skill => Console.WriteLine($"- {skill}"));
            }

            DeveloperType.FrontEndDeveloper.GetSkills();
        }
    }

    public enum DeveloperSkillType
    {
        CSharp,
        VisualBasic,
        MsSql,
        SoapRest,
        Mvc,
        React,
        JavaScript
    }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class RequiredSkillAttribute : Attribute
    {
        public RequiredSkillAttribute(DeveloperSkillType developerSkillType)
        {
            Skill = developerSkillType;
        }

        public DeveloperSkillType Skill { get; set; }
    }

    public enum DeveloperType
    {
        [RequiredSkill(DeveloperSkillType.CSharp)]
        [RequiredSkill(DeveloperSkillType.VisualBasic)]
        [RequiredSkill(DeveloperSkillType.MsSql)]
        LagacyCodeDeveloper,

        [RequiredSkill(DeveloperSkillType.CSharp)]
        [RequiredSkill(DeveloperSkillType.JavaScript)]
        [RequiredSkill(DeveloperSkillType.Mvc)]
        [RequiredSkill(DeveloperSkillType.React)]
        FrontEndDeveloper,

        [RequiredSkill(DeveloperSkillType.CSharp)]
        [RequiredSkill(DeveloperSkillType.MsSql)]
        [RequiredSkill(DeveloperSkillType.SoapRest)]
        ServiceDeveloper
    }
    
    public static class SkillsExtensions
    {
        public static IEnumerable<DeveloperSkillType> GetSkills(this DeveloperType developerType)
        {
            var requiredSkillAttributes =
                (typeof(DeveloperType).GetMember(developerType.ToString())
                     .First()
                     .GetCustomAttributes(typeof(RequiredSkillAttribute), false) as RequiredSkillAttribute[]);
            
            return requiredSkillAttributes?.Select(attr => attr.Skill).ToList();
        }
    }
}
