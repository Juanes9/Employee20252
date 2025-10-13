using Employee.Frontend.Repositories;
using Employee.shared.Entities;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Diagnostics.Metrics;

namespace Employee.Frontend.Components.Pages.Employees;

public partial class EmployeesCreate
{
    private EmployeeBD employee = new();

    [Inject] private IRepository Repository { get; set; } = null!;
    [Inject] private NavigationManager NavigationManager { get; set; } = null!;
    [Inject] private ISnackbar Snackbar { get; set; } = null!;

    private async Task CreateAsync()
    {
        var responseHttp = await Repository.PostAsync("/api/Employees", employee);
        if (responseHttp.Error)
        {
            var message = await responseHttp.GetErrorMessageAsync();
            Snackbar.Add(message!, Severity.Error);
            return;
        }

        Return();
        Snackbar.Add("Registro creado", Severity.Success);
    }

    private void Return()
    {
        NavigationManager.NavigateTo("/Employees");
    }
}