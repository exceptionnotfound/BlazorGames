using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace BlazorGames.Models.Common
{
    public static class EnumExtensions
    {
        /// <summary>
		///  Retrieves the annotated enumerator display value corresponding to any given enumerator value. This method assumes the [Display] attribute is being used over the fields in the enumerator definition with the Name = "" parameter
		/// </summary>
		/// <param name="en">An enumerator value to have its display name attribute looked up.</param>
        /// <returns>A string corresponding to the display name attribute above the enumerator value. Returns the enumerator value's name if no display attribute was used or null if the enumerator was null</returns>
		public static string GetDisplayName(this Enum en)
        {
            if (en == null)
                return "<none selected>";

            try
            {
                FieldInfo field = en.GetType().GetField(en.ToString());

                if (field == null)
                    return en.ToString();

                NameAttribute[] attributes = (NameAttribute[])field.GetCustomAttributes(typeof(NameAttribute), false);

                if (attributes.Length > 0)
                    return attributes[0].Name;
                else
                    return en.ToString();
            }
            catch
            {
                return en.ToString();
            }
        }

        public static string GetDisplayDescription(this Enum en)
        {
            if (en == null)
                return "<none selected>";

            try
            {
                FieldInfo field = en.GetType().GetField(en.ToString());

                if (field == null)
                    return en.ToString();

                NameAttribute[] attributes = (NameAttribute[])field.GetCustomAttributes(typeof(NameAttribute), false);

                if (attributes.Length > 0)
                    return attributes[0].Description;
                else
                    return en.ToString();
            }
            catch
            {
                return en.ToString();
            }
        }
    }
}
