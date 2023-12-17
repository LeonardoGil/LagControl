using AutoMapper;
using LagControlForms.Forms.MovimentacaoForms.Controls;
using LagControlForms.Models;
using LagFinanceLib.Domain;
using LagFinanceLib.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LagControlForms.Forms.MainForms
{
    public partial class MainForms : Form
    {
        protected MovimentacaoViewControl movimentacaoViewControl;

        public MainForms()
        {
            InitializeComponent();

            Load();
        }

        private async Task Load()
        {
            movimentacaoViewControl = Program.ServiceProvider.GetRequiredService<MovimentacaoViewControl>();

            panelView.Controls.Add(movimentacaoViewControl);
            movimentacaoViewControl.Dock = DockStyle.Fill;
        }
    }
}
