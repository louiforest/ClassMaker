using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassMaker
{
    public class CSqlItem
    {
        private string _Name = string.Empty;
        private string _RawDataType = string.Empty;
        private enumDataType _DataType = enumDataType.Undefined;

        public string Name { get { return _Name; } set { _Name = value; } }
        public string RawDataType { get { return _RawDataType; } set { _RawDataType = value; } }
        public enumDataType DataType { get { return _DataType; } set { _DataType = value; } }

        public string DataTypeToString
        {
            get
            {
                switch (_DataType)
                {
                    case enumDataType.Astring:
                        return "string";
                    case enumDataType.Aint:
                        return "int";
                    case enumDataType.Adouble:
                        return "double";
                    case enumDataType.Afloat:
                        return "float";
                    case enumDataType.ADateTime:
                        return "DateTime";
                    case enumDataType.Undefined:                        
                    case enumDataType.Invalid:
                    default:
                        return string.Empty;
                }
            }
        }

        public string PrivateInitiator
        {
            get
            {
                switch (_DataType)
                {
                    case enumDataType.Astring:
                        return " = string.Empty;";
                    case enumDataType.Aint:                        
                    case enumDataType.Adouble:
                    case enumDataType.Afloat:
                        return " = 0;";
                    case enumDataType.ADateTime:
                        return " = new DateTime(1900, 1, 1);";
                    case enumDataType.Undefined:
                    case enumDataType.Invalid:
                    default:
                        return string.Empty;
                }
            }
        }

        public CSqlItem() { }

        public CSqlItem(string Line)
        {
            string[] SplitString;
            int NonEmptyItemIndex = 0;

            SplitString = Line.Replace('\t',' ').Split(' ');

            for (int ithItem = 0; ithItem < SplitString.Length; ithItem++)
            {
                if (!string.IsNullOrEmpty(SplitString[ithItem]) && SplitString.Length > 1)
                {
                    if (NonEmptyItemIndex == 0)
                        _Name = SplitString[ithItem].Trim();
                    else if (NonEmptyItemIndex == 1)
                    {
                        _RawDataType = SplitString[ithItem];
                        _DataType = ConvertRawDataType(_RawDataType);
                    }

                    NonEmptyItemIndex++;
                }
            }
        }
        
        private enumDataType ConvertRawDataType(string Raw)
        {
            string[] SplitString;

            SplitString = Raw.Replace(",","").ToUpper().Split('(');
            switch (SplitString[0])
            {
                case "VARCHAR":
                case "TEXT":
                    return enumDataType.Astring;
                case "INT":
                    return enumDataType.Aint;
                case "DOUBLE":
                    return enumDataType.Adouble;
                case "FLOAT":
                    return enumDataType.Afloat;
                case "KEY":
                    return enumDataType.Invalid;
                case "DATETIME":
                    return enumDataType.ADateTime;
                default:
                    return enumDataType.Undefined;                    
            }
        }
        
    }
        
    public enum enumDataType
    {
        Undefined,
        Invalid,
        Astring,
        Aint,
        Adouble,
        ADateTime,
        Afloat
    }
}
