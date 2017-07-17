using System.Collections.Generic;

namespace Lessons._08
{
    public static class DeveloperTypeExtensions
    {
        public static IEnumerable<DeveloperSkillType> GetSkills(this DeveloperType developerType)
        {
            var type = developerType.GetType();
            var memInfo = type.GetMember(developerType.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(RequiredSkillAttribute), false);
            var list = new List<DeveloperSkillType>();
            foreach (var attribute in attributes)
            {
                var requiredSkillAttribute = (RequiredSkillAttribute)attribute;
                list.Add(requiredSkillAttribute.DeveloperSkillType);
            }
            return list;
        }
    }
}
