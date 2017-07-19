using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    public static class TaskA
    {
        public static void Run()
        {
            foreach (var value in (DeveloperType[])Enum.GetValues(typeof(DeveloperType)))
            {
                Console.WriteLine();
                Console.WriteLine(value);
                value.GetSkills().ForEach(x => Console.WriteLine(x.ToString()));
            }
        }

        public static IEnumerable<DeveloperSkillType> GetSkills(this DeveloperType developerType)
        {
            var type = typeof(DeveloperType);

            var memInfo = type.GetMember(developerType.ToString());

            var attributes = (RequiredSkillAttribute[])memInfo[0].GetCustomAttributes(typeof (RequiredSkillAttribute), false);
            
            return attributes.Select(x => x.SkillType);
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
    public class RequiredSkillAttribute : Attribute
    {
        public DeveloperSkillType SkillType { get; set; }

        public RequiredSkillAttribute(DeveloperSkillType skillType)
        {
            SkillType = skillType;
        }
    }
}
