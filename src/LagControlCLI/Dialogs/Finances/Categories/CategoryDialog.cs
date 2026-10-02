using LagControlCLI.Dialogs.Bases;
using LagControlCLI.Dialogs.Interfaces.Finances;
using LagControlCLI.Extensions;
using LagControlCLI.Options;
using LagControlCLI.Prompts;
using LagControlUtil.Extensions;
using LagFinanceApplication.Dtos.Accounts;
using LagFinanceApplication.Queries.Accounts;
using LagFinanceDomain.Enums;
using MediatR;
using Spectre.Console;
using LagControlCLI.Resources;
using static LagControlCLI.Options.CategoryDialogOptions;

namespace LagControlCLI.Dialogs.Finances.Categories
{
    internal class CategoryDialog(IAnsiConsole console, IMediator mediator, IAddCategoryDialog addCategoryDialog, IEditCategoryDialog editCategoryDialog) : LoopDialogBase(console), ICategoryDialog
    {
        protected ExpensesByCategoryDto ExpensesByCategory { get; set; } = default!;

        protected override async Task LoadAsync()
        {
            await Console.LoadingAsync(Resource.LoadingCategories, async _ =>
            {
                ExpensesByCategory = await mediator.Send(new ExpensesByCategoryQuery());
            });
        }

        protected override async Task ExecuteAsync()
        {
            RenderBreakdowns();

            var action = SelectionPrompt.Ask(Console, Resource.SelectAction.Color("yellow"), CategoryDialogOptions.Options);

            switch (action)
            {
                case CategoryDialogOptionEnum.AddCategory:
                    await addCategoryDialog.Show();
                    await LoadAsync();
                    break;

                case CategoryDialogOptionEnum.Edit:
                    await editCategoryDialog.Show();
                    await LoadAsync();
                    break;

                case CategoryDialogOptionEnum.Back:
                    Stop();
                    break;
            }
        }

        private void RenderBreakdowns()
        {
            var colors = new Color[] { Color.Blue, Color.Green, Color.Red, Color.Purple, Color.BlueViolet, Color.Cyan, Color.DarkOrange, Color.Gold1, Color.Fuchsia, Color.Violet, Color.Wheat1, Color.Yellow };
            var width = Console.Profile.Width / 3;

            var incomeChart = new BreakdownChart().Compact().UseValueFormatter(value => $"R$ {value}");
            var expenseChart = new BreakdownChart().Compact().UseValueFormatter(value => $"R$ {value}");

            incomeChart.Width = width;
            expenseChart.Width = width;

            foreach (var group in ExpensesByCategory.ExpensesByCategoryGroup)
            {
                var totalAmount = double.Parse(group.TotalAmount.ToString());

                switch (group.Type)
                {
                    case CategoryTypeEnum.Income:
                        incomeChart.AddItem(group.Category, totalAmount, colors[incomeChart.Data.Count]);
                        break;

                    case CategoryTypeEnum.Expense:
                        expenseChart.AddItem(group.Category, totalAmount, colors[expenseChart.Data.Count]);
                        break;
                }
            }

            var income = ChartPanel(CategoryTypeEnum.Income.GetDescription(), incomeChart);
            var expense = ChartPanel(CategoryTypeEnum.Expense.GetDescription(), expenseChart);
            var charts = new Columns(income, expense);

            Console.Write(new Panel(new Rows(charts))
            {
                Border = BoxBorder.None,
                Padding = new Padding(3),
                Expand = true
            });
        }

        private static Panel ChartPanel(string title, BreakdownChart chart)
        {
            var rows = new Rows(new Text(string.Empty),
                                chart,
                                new Text(string.Empty));

            return new Panel(rows)
            {
                Header = new PanelHeader(title, Justify.Center),
                Border = BoxBorder.Rounded,
                Padding = new Padding(1, 3),
                Expand = true
            };
        }
    }
}
