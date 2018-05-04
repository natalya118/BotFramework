using System;
using Microsoft.Bot.Builder.FormFlow;

namespace MultidialogBot.Models
{
    public enum PlacesOptions {
        One, Two, Four
    }
    

    [Serializable]
    public class TableOrder
    {
        public PlacesOptions? Places;
        public string Name;
        [Pattern("^(\\+\\d{1,2}\\s)?\\(?\\d{3}\\)?[\\s.-]?\\d{3}[\\s.-]?\\d{4}$")]
        public string Phone;
        public static IForm<TableOrder> BuildForm()
        {
            return new FormBuilder<TableOrder>()
                .Message("Choose table options")
                .Build();
        }
    }
}