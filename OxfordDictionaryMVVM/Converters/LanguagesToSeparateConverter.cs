﻿using System;
using System.Collections.Generic;
using System.Linq;
using OxfordDictionaryMVVM.Models;
using Windows.UI.Xaml.Data;

namespace OxfordDictionaryMVVM.Converters
{
    /// <summary>
    /// A basic converter to transform the languages of result.
    /// </summary>
    public class LanguagesToSeparateConverter : IValueConverter
    {
        /// <summary>
        /// This method makes the conversion to seperate languages. Without it, languages that has multiple target language will be shown many times.
        /// </summary>
        /// <param name="value">The value that needs to be converted.</param>
        /// <param name="targetType">The type of the controller's property.</param>
        /// <param name="parameter">Optional extra parameter.</param>
        /// <param name="language">Culture information for localization, optional.</param>
        /// <returns>Languages in converted form</returns>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var tempLangs = from r in value as ICollection<Result>
                            group r by r.sourceLanguage.id into s
                            let first = s.First()
                            select first;

            var separateLanguages = tempLangs.ToList();

            if (separateLanguages == null)
            {
                return null;
            }

            return separateLanguages;
        }

        /// <summary>
        /// This method makes the conversion back to original value.
        /// </summary>
        /// <param name="value">The value that needs to be converted.</param>
        /// <param name="targetType">The type of the controller's property.</param>
        /// <param name="parameter">Optional extra parameter.</param>
        /// <param name="language">Culture information for localization, optional.</param>
        /// <returns>Languages in deconverted form.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
