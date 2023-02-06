using System.Collections.Generic;

namespace GainChangerSpecFlow
{
    public class JsonObjects
    {
        public string metaTitle { get; set; }
        public string metaDescription { get; set; }
        public string headingOneTag { get; set; }

        public List<HeadingTwoTag> headingTwoTags { get; set; }
        public List<ParagraphTag> paragraphTags { get; set; }
    }

    public class HeadingTwoTag
    {
        public string heading2Value { get; set; }
    }

    public class ParagraphTag
    {
        public string paragraphValue { get; set; }
    }
}
