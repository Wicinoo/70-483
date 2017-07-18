using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            PrintSkills(DeveloperType.FrontEndDeveloper);
            PrintSkills(DeveloperType.LagacyCodeDeveloper);
            PrintSkills(DeveloperType.ServiceDeveloper);
        }

        public static void PrintSkills(DeveloperType developerType)
        {
            var developerTypeName = Enum.GetName(developerType.GetType(), developerType);
            Console.WriteLine(developerTypeName.ToString());

            var developerSkills = developerType.GetSkills();
            foreach (var developerSkill in developerSkills)
            {
                Console.WriteLine(developerSkill);
            }
        }
    }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class RequiredSkillAttribute : Attribute
    {
        public DeveloperSkillType RequiredSkill { get; set; }

        public RequiredSkillAttribute(DeveloperSkillType requiredSkill)
        {
            RequiredSkill = requiredSkill;
        }
    }

    public static class DeveloperTypeExtensions
    {
        public static IEnumerable<DeveloperSkillType> GetSkills(this DeveloperType developerType)
        {
            var developerTypeName = Enum.GetName(developerType.GetType(), developerType);
            var developerTypeMemberInfo = developerType.GetType().GetMember(developerTypeName).Single();
            var attributes = Attribute.GetCustomAttributes(developerTypeMemberInfo);

            foreach (RequiredSkillAttribute attribute in attributes)
            {
                yield return attribute.RequiredSkill;
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
}
