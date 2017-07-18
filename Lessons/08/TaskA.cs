using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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
            foreach (DeveloperType skill in Enum.GetValues(typeof(DeveloperType)))
            {
                Console.WriteLine($"Attributes of {skill.ToString()}:");
                PrintAttributes(skill);

                Console.WriteLine();
            }
        }

        private static void PrintAttributes(DeveloperType skillType)
        {
            var attributes = GetSkills(skillType);

            foreach (var attribute in attributes)
            {
                Console.WriteLine(attribute.ToString());
            }
        }

        private static IEnumerable<DeveloperSkillType> GetSkills(DeveloperType type)
        {
            var memberInfo = typeof(DeveloperType).GetMember(type.ToString()).FirstOrDefault();

            return memberInfo.GetCustomAttributes(typeof(RequiredSkill))
                            .Cast<RequiredSkill>()
                            .Select(x => x.SkillType);
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

    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class RequiredSkill : Attribute
    {
        public DeveloperSkillType SkillType { get; private set; }

        public RequiredSkill(DeveloperSkillType skillType)
        {
            SkillType = skillType;
        }
    }
}
