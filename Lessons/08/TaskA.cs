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
            Enum.GetValues(typeof(DeveloperType)).OfType<DeveloperType>().ForEach(x =>
            {
                Console.WriteLine($"Developer type {x}");
                x.GetSkills().ForEach(y => Console.WriteLine(y.ToString()));
            });
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

    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class RequiredSkillAttribute : Attribute

{
        public readonly DeveloperSkillType SkillType;

        public RequiredSkillAttribute(DeveloperSkillType skillType)
        {
            this.SkillType = skillType;
        }
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

    public static class DeveloperTypeExtensions
    {
        public static IEnumerable<DeveloperSkillType> GetSkills(this DeveloperType type)
        {
            var memInfo = typeof(DeveloperType).GetMember(type.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(RequiredSkillAttribute), false);
            return attributes.Any() ? attributes.Select(x => ((RequiredSkillAttribute)x).SkillType) : null;
        }
    }

}
