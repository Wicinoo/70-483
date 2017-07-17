using System;

namespace Lessons._08
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    internal sealed class RequiredSkillAttribute : Attribute
    {
        public RequiredSkillAttribute(DeveloperSkillType developerSkillType)
        {
            DeveloperSkillType = developerSkillType;
        }

        public DeveloperSkillType DeveloperSkillType { get; }
    }
}