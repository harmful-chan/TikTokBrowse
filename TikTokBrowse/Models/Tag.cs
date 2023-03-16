using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TikTokBrowse.Models
{
    public class Tag : IEquatable<Tag>
    {

        private char _symbol;

        public char Symbol
        {
            get { return _symbol; }
            set { _symbol = value; }
        }


        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public Tag()
        {

        }
        public Tag(char symbol, string name)
        {
            _symbol = symbol;
            _name = name;
        }

        public override string ToString()
        {
            return _symbol + _name;
        }
        public static Tag Convert(string raw)
        {
            return new Tag()
            {
                Symbol = raw[0],
                Name = raw.Substring(1)
            };
        }

        public static Tag[] Converts(params string[] raws)
        {
            string[] ss = raws.Where(r => !string.IsNullOrWhiteSpace(r)).ToArray();
            return Array.ConvertAll(ss,  r=> Convert(r));
        }

        public bool Equals(Tag other)
        {
            if (other is null)
                return false;

            return _name.IndexOf(other.Name, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        public override bool Equals(object obj) => Equals(obj as Tag);
        public override int GetHashCode() => (_symbol, _name).GetHashCode();
    }
}
