using System;

namespace Lessons._08
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using Castle.Core.Internal;

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
            var types = Enum.GetNames(typeof(DeveloperType));
            foreach (var type in types)
            {
                DeveloperType developerType;
                Enum.TryParse(type, out developerType);

                var developerSkills = developerType.GetSkills();

                developerSkills.ForEach(x => Console.WriteLine(x.ToString()));
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

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class RequiredSkill : System.Attribute
    {
        private DeveloperSkillType _skill;

        public RequiredSkill(DeveloperSkillType skill)
        {
            _skill = skill;
        }

        public DeveloperSkillType GetSkill()
        {
            return _skill;
        }
    }

    public static class DeveloperTypeExtension
    {
        public static IEnumerable<DeveloperSkillType> GetSkills(this DeveloperType developerType)
        {
            var attributes = typeof(DeveloperType).GetMember(developerType.ToString())[0].GetCustomAttributes(
                typeof(RequiredSkill),
                false);

            return attributes.Select(x => ((RequiredSkill)x).GetSkill());
        } 
    }


}
