using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDSidekick.Business.Models
{
    public class SkillViewModel
    {
        public SkillViewModel(string skillName)
        {
            SkillName = skillName;
        }

        public string SkillName { get; set; }

        private int modifier;
        public int Modifier
        {
            get { return modifier; }
            set
            {
                modifier = value;
                if (modifier > 0) ModifierText = $"+{modifier}";
                else ModifierText = modifier.ToString();
            }
        }

        public string ModifierText { get; set; }
    }
}
