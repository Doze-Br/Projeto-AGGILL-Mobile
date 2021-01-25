using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace Mobile.Login
{
    public class EmailValidation : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry entry)
        {
            entry.TextChanged += EmailEntryChanged;
            base.OnAttachedTo(entry);
        }

        private void EmailEntryChanged(object sender, TextChangedEventArgs e)
        {
            Entry entry = (Entry)sender;
            if (!string.IsNullOrEmpty(entry.Text))
            {
                string emailRegex = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
                bool IsMatched = Regex.IsMatch(entry.Text, emailRegex);
                if (IsMatched)
                {
                    entry.TextColor = Color.Black;
                }
                else
                {
                    entry.TextColor = Color.DarkRed;
                }
            }
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            entry.TextChanged -= EmailEntryChanged;
            base.OnDetachingFrom(entry);
        }
    }
}
