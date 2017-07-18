using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using FluentAssertions;
using Rhino.Mocks.Constraints;

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
            var developerTypes = Enum.GetValues(typeof(DeveloperType));

            foreach (var developerType in developerTypes)
            {
                Console.WriteLine($"Required skills for {developerType} are:");
                Console.WriteLine(Format(((DeveloperType)developerType).GetSkills()));
                Console.WriteLine();
            }
        }

        public static string Format(List<DeveloperSkillType> values)
        {
            var result = new StringBuilder();
            foreach (var developerSkillType in values)
            {
                result.Append(developerSkillType);
                result.Append(", ");
            }
            result.Length--;
            result.Length--;

            return result.ToString();
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

    public static class RequiredSkillAttributeProvider
    {
        public static List<DeveloperSkillType> GetSkills(this DeveloperType developerType)
        {
            var test = Attribute
                        .GetCustomAttributes(ForValue(developerType), typeof(RequiredSkillAttribute))
                        .ToList()
                        .OfType<RequiredSkillAttribute>();

            return test.Select(requiredSkillAttribute => requiredSkillAttribute.Get()).ToList();
        }

        private static MemberInfo ForValue(DeveloperType developerType)
        {
            return typeof(DeveloperType).GetField(Enum.GetName(typeof(DeveloperType), developerType));
        }
    }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class RequiredSkillAttribute : Attribute
    {
        private readonly DeveloperSkillType _skillType;

        public RequiredSkillAttribute(DeveloperSkillType skillType)
        {
            _skillType = skillType;
        }

        public DeveloperSkillType Get()
        {
            return _skillType;
        }
    }

}
