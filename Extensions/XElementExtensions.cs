using DMCal3d.Net.Builders.Mesh;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace DMCal3d.Net
{
    public static class XElementExtensions
    {
        private static readonly List<string> _overflowValues = new()
        {
            "10000000000 10000000000 10000000000",
            "1E+10 1E+10 1E+10"
        };
        private static readonly Random _rnd = new();

        /// <summary>
        /// Compares the element value against the overflow values list
        /// </summary>
        /// <param name="element"></param>
        /// <returns>True if the element value contains any of the overflow values</returns>
        public static bool ContainsOverflowInteger(this XElement element)
        {
            string elementValue = element.Value;

            foreach (string overflowValue in _overflowValues)
            {
                int index = elementValue.IndexOf(overflowValue);
                int lastIndex = elementValue.LastIndexOf(overflowValue);

                if (index != -1 && lastIndex != -1)
                {
                    if (index == lastIndex)
                        return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Grabs a specific XAttribute from an XElement
        /// </summary>
        /// <param name="element">The XElement containing the XAttribute</param>
        /// <param name="attributeName">The XAttribute name</param>
        /// <param name="matchWholeWord"></param>
        /// <returns></returns>
        public static XAttribute GetAttribute(this XElement element, string attributeName, bool matchWholeWord = false)
        {
            StringComparison comparison = StringComparison.InvariantCultureIgnoreCase;

            if (matchWholeWord)
                return element.Attributes().FirstOrDefault(x => x.Name.LocalName.Equals(attributeName, comparison));
            
            return element.Attributes().FirstOrDefault(x => x.Name.LocalName.IndexOf(attributeName, comparison) != -1);
        }     
        
        /// <summary>
        /// Gets the children elements with matching tag names
        /// </summary>
        /// <param name="element">The parent XElement to search the children of</param>
        /// <param name="tagName">The child tag name</param>
        /// <param name="matchWholeWord">Allow partial matches</param>
        /// <returns></returns>
        public static List<XElement> GetChildren(this XElement element, string tagName, bool matchWholeWord = false)
        {
            StringComparison comparison = StringComparison.InvariantCultureIgnoreCase;

            if (matchWholeWord)
                return element.Descendants().Where(x => x.Name.LocalName.Equals(tagName, comparison)).ToList();
            else
                return element.Descendants().Where(x => x.Name.LocalName.IndexOf(tagName, comparison) != -1).ToList();
        }

        /// <summary>
        /// Get child XElements whose tag name matches a regular expression
        /// </summary>
        /// <param name="element">The parent XElement to search inside of</param>
        /// <param name="pattern">The regular expression to match</param>
        /// <returns></returns>
        public static List<XElement> GetChildren(this XElement element, string pattern)
        {
            return element.Descendants()
                .Where(x => Regex.IsMatch(x.Name.LocalName, pattern, RegexOptions.IgnoreCase))
                .ToList();
        }

        /// <summary>
        /// Get a child element with a matching tag name
        /// </summary>
        /// <param name="element">The parent XElement to search the children of</param>
        /// <param name="tagName">The child tag name</param>
        /// <param name="matchWholeWord">Allow partial matches</param>
        /// <returns></returns>
        public static XElement GetChild(this XElement element, string tagName, bool matchWholeWord = false)
        {
            return GetChildren(element, tagName, matchWholeWord).LastOrDefault();
        }

        /// <summary>
        /// Removes each element in the collection from their parent
        /// </summary>
        /// <param name="elementsToRemove">A collection of XElements</param>
        public static void Remove(this List<XElement> elements)
        {
            foreach (XElement element in elements)
            {
                element.Remove();
            }
        }

        /// <summary>
        /// Takes a list of XElements and renames them in a sequential order starting at a given number
        /// </summary>
        /// <param name="elementsToRenumber">The collection XElements to renumber</param>
        /// <param name="tagName">The name of the element, used in the replace method</param>
        /// <param name="startingNumber"></param>
        public static void Renumber(this List<XElement> elementsToRenumber, string tagName, int startingNumber = 0)
        {
            foreach (XElement element in elementsToRenumber)
            {
                element.Name = Regex.Replace(element.Name.ToString(), $"{tagName}(\\d.*|)", $"{tagName}{startingNumber}", RegexOptions.IgnoreCase);
                ++startingNumber;
            }
        }

        /// <summary>
        /// Randomizes the order of the XElements in the collection 
        /// </summary>
        /// <param name="elementsToShuffle">A collection of XElements</param>
        /// <returns>The collection of XElements in a reordered sequence</returns>
        public static List<XElement> Shuffle(this List<XElement> elementsToShuffle)
        {
            return elementsToShuffle.OrderBy(item => _rnd.Next()).ToList();
        }

        /// <summary>
        /// Grabs a number from the tag name e.g. <Tag0></Tag0>
        /// </summary>
        /// <param name="element">The XElement to get the number from</param>
        /// <param name="tagName">The part of the tag name to ignore</param>
        /// <returns></returns>
        public static int GetTagNumber(this XElement element, string tagName)
        {
            string tagNumberAsString = element.Name.LocalName
                .ToLower()
                .Replace(tagName, "");

            //We set the id to -1 instead of 0 because an element can have an id of 0
            int tagNumber = int.TryParse(tagNumberAsString, out tagNumber) ? tagNumber : -1;
            return tagNumber;
        }

        public static int GetMinMaxTagId(this List<XElement> elements, string tagName, bool min = true)
        {
            List<int> tagIds = new();

            foreach (XElement element in elements)
            {
                int tagNumber = GetTagNumber(element, tagName);

                if (tagNumber == -1)
                {
                    continue;
                }

                tagIds.Add(tagNumber);
            }

            if (tagIds.Count == 0)
            {
                return -1;
            }

            tagIds.Sort();

            return min ? tagIds.First() : tagIds.Last();
        }

        /// <summary>
        /// Sorts a collection of XElements by a id number in the tag name
        /// </summary>
        /// <param name="elements">The collection of XElements to sort</param>
        /// <param name="tagName">The portion of the tag name to be removed when searching for an id</param>
        /// <returns></returns>
        public static List<XElement> SortByTagId(this List<XElement> elements, string tagName)
        {
            SortedDictionary<int, XElement> dic = new();  

            foreach (XElement element in elements)
            {
                //We set the id to -1 instead of 0 because an element can have an id of 0
                int id = int.TryParse(element.Name.LocalName.ToLower().Replace(tagName, ""), out id) ? id : -1;

                if (id == -1)
                    continue;

                dic.Add(id, element);
            }

            return dic.Values.ToList();
        }

        /// <summary>
        /// Gets an XElement value formatted as doubles
        /// </summary>
        /// <param name="elementValue"></param>
        /// <param name="valueLimit"></param>
        /// <returns></returns>
        public static List<double> GetValues(this XElement element, int valueLimit = 3)
        {
            List<double> buffer = new();

            string dirtyValues = element.Value;

            //compensate for any malformed element values by removing any leading or trailing spaces
            dirtyValues = dirtyValues.Trim();
            string[] values = dirtyValues.Split(' ');

            if (values.Length > valueLimit)
            {
                string[] s = new string[valueLimit];

                for (int i = 0; i < valueLimit; i++)
                    s[i] = values[i];

                values = s;
            }

            foreach (string value in values)
            {
                string s = value;

                if (value.Contains("E-"))
                {
                    s = value.Split(new string[] { "E-" }, StringSplitOptions.None)[0];
                }

                if (double.TryParse(s, NumberStyles.Float, CultureInfo.InvariantCulture, out double d))
                {
                    buffer.Add(d);
                }
            }

            return buffer;
        }

        /// <summary>
        /// Gets an XElement value formatted strings
        /// </summary>
        /// <param name="element">The XElement to grab the values from</param>
        /// <param name="valueLimit">The max number of values to return</param>
        /// <returns>A collection of strings representing the XElement value</returns>
        public static List<string> GetValuesAsString(this XElement element, int valueLimit = 3)
        {
            List<string> buffer = new();

            string dirtyValues = element.Value;

            //compensate for any malformed element values by removing any leading or trailing spaces
            dirtyValues = dirtyValues.Trim();
            string[] values = dirtyValues.Split(' ');

            if (values.Length > valueLimit)
            {
                string[] s = new string[valueLimit];

                for (int i = 0; i < valueLimit; i++)
                    s[i] = values[i];

                values = s;
            }

            foreach (string value in values)
            {
                string s = value;

                if (value.Contains("E-"))
                {
                    s = value.Split(new string[] { "E-" }, StringSplitOptions.None)[0];
                }

                buffer.Add(s);
            }

            return buffer;
        }
    
        /// <summary>
        /// Get a child XElement with a matching attrbitue value
        /// </summary>
        /// <param name="element">The parent XElenent to search the children of</param>
        /// <param name="childName">The tag name of the child element to search for</param>
        /// <param name="attributeName">The attribute to look at</param>
        /// <param name="attributeValue">The attribute value to compare against</param>
        /// <param name="matchWholeWord">Allow partial tag name matching</param>
        /// <returns></returns>
        public static XElement? GetChildByAttribute(this XElement element, string childName, string attributeName, string attributeValue, bool matchWholeWord = false)
        {
            List<XElement> children = element.GetChildren(childName, matchWholeWord);

            foreach (XElement child in children) 
            {
                XAttribute? attribute = child.GetAttribute(attributeName, matchWholeWord);

                if (attribute != null)
                {
                    if (attribute.Value.ToLower().Equals(attributeValue))
                    {
                        return child;
                    }
                }
            }

            return null;
        }
    
        public static bool AttributeContains(this XElement element, string attributeName, List<string> attributeValues, out string matchedBoneType)
        {
            foreach (string attributeValue in attributeValues)
            {
                string elementAttributeValue = element.GetAttribute(attributeName).Value.ToLower();

                int index = elementAttributeValue.IndexOf(attributeValue);

                if (index == 0)
                {
                    matchedBoneType = attributeValue;
                    return true;
                }
            }

            matchedBoneType = "";
            return false;
        }
    }
}
