using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using MultidialogBot.Models;

namespace MultidialogBot.Dialogs
{
    [Serializable]
    public class BookTableDialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            context.Call(MakeTableOrderDialog(), this.ResumeAfterHotelsFormDialog);
        }

        private async Task ResumeAfterHotelsFormDialog(IDialogContext context, IAwaitable<TableOrder> result)
        {
            await context.PostAsync("Waiting for you today!");
            context.Done(Task.CompletedTask);
            
        }

        internal static IDialog<TableOrder> MakeTableOrderDialog()
        {
            return Chain.From(() => FormDialog.FromForm(TableOrder.BuildForm));
        }

        
    }
}