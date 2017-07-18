using System;
using System.Collections.Generic;
using System.Globalization;
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
            foreach (DeveloperType value in Enum.GetValues(typeof(DeveloperType)))
            {
                Console.WriteLine($"Skills for {value.ToString()} are:");
                var skills = value.GetSkills();
                foreach (var skill in skills)
                {
                    Console.WriteLine(skill.ToString());
                }
                Console.WriteLine();
            }
        }
    }

    public static class EnumExtension
    {
        public static IEnumerable<DeveloperSkillType> GetSkills(this DeveloperType type)
        {
            return type.GetType().GetTypeInfo().GetDeclaredField(type.ToString())
                .GetCustomAttributes<RequiredSkillAttribute>().Select(x => x.SkillType);
        }
    }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class RequiredSkillAttribute : Attribute
    {
        public DeveloperSkillType SkillType { get; }

        public RequiredSkillAttribute(DeveloperSkillType type)
        {
            SkillType = type;
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
        LegacyCodeDeveloper,

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
}