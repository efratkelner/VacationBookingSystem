using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using BE;
using System.Windows.Data;

namespace PLWPF
    {
        public class MyAreaEnumToString : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                switch ((Enums.Area)value)
                {
                    case Enums.Area.דרום:
                        return "דרום";
                    case Enums.Area.ירושלים:
                        return "ירושלים";
                    case Enums.Area.מרכז:
                        return "מרכז";
                    case Enums.Area.צפון:
                        return "צפון";
                    default:
                        throw new NotImplementedException();
                }
            }
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
        public class MyWishEnumToString : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                switch ((Enums.Pool)value)
                {
                    case Enums.Pool.אפשרי:
                        return "ייתכן";
                    case Enums.Pool.לא_מעונין:
                        return "לא מעוניין";
                    case Enums.Pool.נחוץ:
                        return "נחוץ";
                    default:
                        throw new NotImplementedException();
                }
            }
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
        public class MyStatusEnumToString : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                switch ((Enums.GuestRequestStatus)value)
                {
                    case Enums.GuestRequestStatus.נסגר_מפאת_פקיעת_תוקף:
                        return "לא רלוונטי";
                    case Enums.GuestRequestStatus.פתוחה:
                        return "פתוחה";
                    case Enums.GuestRequestStatus.נסגרה_דרך_האתר:
                        return "נסגרה באתר";
                    default:
                        throw new NotImplementedException();
                }
            }
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
        public class MyUnitEnumToString : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                switch ((Enums.Type)value)
                {
                    case Enums.Type.דירה:
                        return "דירה";
                    case Enums.Type.מחנאות:
                        return "מחנאות";
                    case Enums.Type.חדר_מלון:
                        return "מלון";
                    case Enums.Type.צימר:
                        return "צימר";
                    default:
                        throw new NotImplementedException();
                }
            }
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
        public class YesOrNo : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                switch ((bool)value)
                {
                    case true:
                        return "כן";
                    case false:
                        return "לא";
                    default:
                        throw new NotImplementedException();
                }
            }
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
        public class StatusOrderEnumToString : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                switch ((Enums.orderStatus)value)
                {
                    case Enums.orderStatus.לא_טופלה:
                        return "לא מטופל";
                    case Enums.orderStatus.נסגר_מהיענות:
                        return "נסגר עם מענה";
                    case Enums.orderStatus.נסגרה_מחוסר_היענות:
                        return "נסגר עקב חוסר מענה";
                    case Enums.orderStatus.נשלח_מייל:
                        return "נשלח מייל";
                    default:
                        throw new NotImplementedException();
                }
            }
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }

        }
    }


