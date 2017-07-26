using System;
using System.Linq;
using System.Reflection;
using Castle.Core.Internal;
using FluentAssertions.Common;
using Xunit.Sdk;

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
            foreach (DeveloperType developer in Enum.GetValues(typeof (DeveloperType)))
            {
                developer.GetSkills();
            }
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

    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class RequiredSkillAttribute : Attribute
    {
        public RequiredSkillAttribute(DeveloperSkillType cSharp)
        {
            throw new NotImplementedException();
        }
    }

    public static class ExtensionMethods
    {
        public static void GetSkills(this DeveloperType type)
        {
            var skills = typeof(DeveloperType).GetFields()
                .Where(field => field.HasAttribute<RequiredSkillAttribute>())
                .Select(field => field.GetValue(null))
                .Cast<DeveloperSkillType>();

            foreach (var skill in skills)
            {
                Console.WriteLine(skill.ToString());
            }
        }
    }
}
