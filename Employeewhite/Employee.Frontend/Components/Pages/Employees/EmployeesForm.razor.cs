using Employee.shared.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Diagnostics.Metrics;

namespace Employee.Frontend.Components.Pages.Employees;

public partial class EmployeesForm
{
    private EditContext editContext = null!;

    [EditorRequired, Parameter] public EmployeeBD Employee { get; set; } = null!;
    [EditorRequired, Parameter] public EventCallback OnValidSubmit { get; set; }
    [EditorRequired, Parameter] public EventCallback ReturnAction { get; set; }

    protected override void OnInitialized()
    {
        editContext = new(Employee);
    }
}